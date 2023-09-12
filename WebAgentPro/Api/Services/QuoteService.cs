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
        Task AddQuote(QuoteDto q);
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
            await _quoteRepo.EditQuote(quoteMap.DtoToQuote(q));
        }


        public async Task AddQuote(QuoteDto q)
        {
            List<Driver> driversList = new List<Driver>();
            List<Vehicle> vehiclesList = new List<Vehicle>();
            //string driverLicenseNum;
            Driver newDriver;
            Vehicle newVehicle;
            
            /*Populate Drivers List*/
            foreach (DriverDto d in q.Drivers){

                //create driver
                newDriver = await _driverRepo.AddDriver(driverMap.DtoToDriver(d)); //create driver

                //add driver to list
                driversList.Add(newDriver);
            }

            /*Populate Vehicles List*/
            foreach (VehicleDto v in q.Vehicles)
            {
                //create vehicle
                newVehicle = await _vehicleRepo.AddVehicle(vehicleMap.DtoToVehicle(v)); 

                //add vehicle to list
                vehiclesList.Add(newVehicle);
            }

            Quote quote = quoteMap.DtoToQuote(q);
            quote.Drivers = driversList;
            quote.Vehicles = vehiclesList;
            await _quoteRepo.AddQuote(quote); 
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
