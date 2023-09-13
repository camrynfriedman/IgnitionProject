using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Mappers;

namespace WebAgentPro.Api.Services
{
    /*
     * The service uses the QuoteDto rather than Quote 
     * and calls methods from the repository.
     * 
     * 
     *
     * */

    public interface IQuoteService
    {
        Task<List<QuoteDto>> GetAllQuotes();
        Task<QuoteDto> GetQuote(int quoteID);
        Task EditQuote(QuoteDto q);
        Task<QuoteDto> AddQuote(QuoteDto q);
        Task RemoveQuote(int quoteID);
    }

    public class QuoteService : IQuoteService
    {
        //use QuoteRepository
        private readonly IQuoteRepository _quoteRepo;

        //add Vehicle and Driver repos
        private readonly IVehicleRepository _vehicleRepo;

        private readonly IDriverRepository _driverRepo;

        //use driverMapper
        private QuoteMapper quoteMap;
        private DriverMapper driverMap;
        private VehicleMapper vehicleMap;


        //constructor
        public QuoteService(IQuoteRepository quoteRepo, IVehicleRepository vehicleRepo, IDriverRepository driverRepo)
        {
            _quoteRepo = quoteRepo;
            _vehicleRepo = vehicleRepo;
            _driverRepo = driverRepo;

            quoteMap = new QuoteMapper();
            driverMap = new DriverMapper();
            vehicleMap = new VehicleMapper();
      
        }
        public async Task<List<QuoteDto>> GetAllQuotes()
        {

            var quotes = (await _quoteRepo.GetAllQuotes());
            List < QuoteDto > returnedQuotes = new List<QuoteDto>();

            if (quotes == null)
            {
                return null;
            }

            foreach (Quote qu in quotes) {
                try {
                    returnedQuotes.Add(quoteMap.QuoteToDto(qu));
                }
                catch {
                    await _quoteRepo.RemoveQuote(qu.QuoteID);
                }
            }

            return quotes.Select(q => quoteMap.QuoteToDto(q)).ToList();

            /*List<QuoteDto> quoteDtos = quotes.Select(q => quoteMap.QuoteToDto(q)).ToList();
            foreach (QuoteDto q in quoteDtos) {
                foreach (DriverDto d in q.Drivers) {
                    if (d.Vehicles == null)
                    {
                        d.Vehicles = new List<VehicleDto>();
                    }
                    foreach (VehicleDto v in q.Vehicles) {
                        if (v.DriverID == d.DriverID) {
                            d.addVehicleToDriver(v);
                        }
                    }
                }
            }*/
        }

        public async Task<QuoteDto> GetQuote(int quoteID)
        {
            if (await _quoteRepo.GetQuote(quoteID) == null)
            {
                return null;
            }
            //use the quoteMap to get the quote
            QuoteDto returnedQuoteDto = quoteMap.QuoteToDto(await _quoteRepo.GetQuote(quoteID));

            return returnedQuoteDto;
        }

        public async Task EditQuote(QuoteDto q)
        {


            Quote quote = quoteMap.DtoToQuote(q);
            quote.Drivers = null;
            quote.Vehicles = null;
            await _quoteRepo.EditQuote(quote);

            //Removing drivers and vehicles from existing quote
            //if the driver exists in the driverRepo
            QuoteDto oldQuote = await GetQuote(q.QuoteID);
            foreach (DriverDto d in oldQuote.Drivers)
            {
                bool flag = false;
                foreach (DriverDto d2 in q.Drivers) {
                    if (d.DriverID == d2.DriverID) {
                        flag = true;
                    }
                }
                if (flag == false) {
                    await _driverRepo.RemoveDriver(d.DriverID);
                }
            }
            foreach (VehicleDto v in oldQuote.Vehicles)
            {
                bool flag = false;
                foreach (VehicleDto v2 in q.Vehicles)
                {
                    if (v.VehicleID == v2.VehicleID)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    await _vehicleRepo.RemoveVehicle(v.VehicleID);
                }
            }

            //adding drivers and vehicles to quote
            //Check if the QuoteDTO -- vehicles or drivers are a add or update
            foreach (DriverDto d in q.Drivers) {
                if (d.DriverID == 0)
                {
                    Driver dTemp = driverMap.DtoToDriver(d);
                    dTemp.QuoteID = q.QuoteID;
                    await _driverRepo.AddDriver(dTemp);
                }
                else {
                    Driver dTemp = driverMap.DtoToDriver(d);
                    dTemp.QuoteID = q.QuoteID;
                    await _driverRepo.EditDriver(dTemp.DriverID, dTemp);
                }
            }
            foreach (VehicleDto d in q.Vehicles)
            {
                if (d.VehicleID == 0)
                {
                    Vehicle dTemp = vehicleMap.DtoToVehicle(d);
                    dTemp.QuoteID = q.QuoteID;
                    await _vehicleRepo.AddVehicle(dTemp);
                }
                else
                {
                    Vehicle dTemp = vehicleMap.DtoToVehicle(d);
                    dTemp.QuoteID = q.QuoteID;
                    await _vehicleRepo.EditVehicle(dTemp.VehicleID, dTemp);
                }
            }
        }


        public async Task<QuoteDto> AddQuote(QuoteDto q)
        {
            List<Driver> driversList = new List<Driver>();
            List<Vehicle> vehiclesList = new List<Vehicle>();
            //string driverLicenseNum;
            Driver newDriver;
            Vehicle newVehicle;

            //calculation of the Quote Price
            foreach (DriverDto d in q.Drivers) {
                d.Vehicles = new List<VehicleDto>();
            }
            Quote quote = quoteMap.DtoToQuote(q);
            //set quote price after calculation
            quote.QuotePrice = 0;
            quote.Drivers = null;
            quote.Vehicles = null;
            quote = await _quoteRepo.AddQuote(quote);

            /*Populate Drivers List*/
            foreach (DriverDto d in q.Drivers){

                //create driver
                Driver driver2 = driverMap.DtoToDriver(d);
                driver2.QuoteID = quote.QuoteID;
                driver2.Vehicles = new List<Vehicle>();
                newDriver = await _driverRepo.AddDriver(driver2); //create driver

            }

            /*Populate Vehicles List*/
            foreach (VehicleDto v in q.Vehicles)
            {
                //create vehicle, check if the vehicle has a valid driver in database
                try
                {
                    Vehicle vehicle2 = vehicleMap.DtoToVehicle(v);
                    vehicle2.QuoteID = quote.QuoteID;
                    newVehicle = await _vehicleRepo.AddVehicle(vehicle2);

                    //add vehicle to driver list
                    await _driverRepo.AddVehicle(newVehicle.DriverSSN, vehicle2);
                }
                catch {
                    await _quoteRepo.RemoveQuote(quote.QuoteID);
                    throw new Exception("No driver with DriverID for Vehicle is found");
                }
            }

            //return QuoteDTO by id
            return await GetQuote(quote.QuoteID);
            
        }


        public async Task RemoveQuote(int quoteID)
        {
            if (_quoteRepo.GetQuote(quoteID) == null)
            {
                throw new Exception("Quote does not exists.");
            }
            await _quoteRepo.RemoveQuote(quoteID);
        }
    }
}
