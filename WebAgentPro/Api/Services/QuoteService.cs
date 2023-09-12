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


        //constructor
        public QuoteService(IQuoteRepository quoteRepo, IVehicleRepository vehicleRepo, IDriverRepository driverRepo)
        {
            _quoteRepo = quoteRepo;
            _vehicleRepo = vehicleRepo;
            _driverRepo = driverRepo;

            quoteMap = new QuoteMapper();
            driverMap = new DriverMapper();
      
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

        // needs to use vehicle repo and driver repo to create those objects before creating final quote
        // use DTOs?
     /*
     * loop over each driver, create drivers
     * loop over each vehicles, create vehicles
     * construct quote object using those IDs generated*/
        public async Task AddQuote(QuoteDto q)
        {
            List<DriverDto> driversList = new List<DriverDto>();
            List<VehicleDto> vehiclesList = new List<VehicleDto>();
            string driverLicenseNum;
            DriverDto newDriverDto;
            

            foreach (DriverDto d in q.Drivers){
                //create driver
                await _driverRepo.AddDriver(driverMap.DtoToDriver(d)); //create driver
                driverLicenseNum = d.DriverLicenseNumber; //get driverID
                newDriverDto = driverMap.DriverToDto(await _driverRepo.GetDriverByLicense(driverLicenseNum));

                //add driverDto to list
                driversList.Add(newDriverDto);

            }
            q.Drivers = driversList;
            await _quoteRepo.AddQuote(quoteMap.DtoToQuote(q));

            //figure out how to know how many drivers and vehicles to add
            //create a list of drivers and vehicles and populate using AddDriver and AddVehicle
            //get the IDs of each driver and add to Quote
            //get the IDs of each vehicle and add to Quote

     
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
