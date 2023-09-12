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

            if (quotes == null)
            {
                return null;
            }
            return quotes.Select(q => quoteMap.QuoteToDto(q)).ToList();
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
                newDriver = await _driverRepo.AddDriver(driver2); //create driver

                //add driver to list
/*                driversList.Add(newDriver);*/
            }

            /*Populate Vehicles List*/
            foreach (VehicleDto v in q.Vehicles)
            {
                //create vehicle
                Vehicle vehicle2 = vehicleMap.DtoToVehicle(v);
                vehicle2.QuoteID = quote.QuoteID;
                newVehicle = await _vehicleRepo.AddVehicle(vehicle2); 

                //add vehicle to list
/*                vehiclesList.Add(newVehicle);*/
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
