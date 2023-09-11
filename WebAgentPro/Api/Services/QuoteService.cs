using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    /*
     * The service uses the QuoteDTO rather than Quote 
     * and calls methods from the repository.
     * 
     * 
     * needs to use vehicle repo and driver repo to create those objects before creating final quote
     * 
     * loop over each driver, create drivers
     * loop over each vehicles, create vehicles
     * construct quote object using those IDs generated
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

        //use mapper
        private QuoteMapper map;


        //constructor
        public QuoteService(IQuoteRepository quoteRepo)
        {
            _quoteRepo = quoteRepo;
            map = new QuoteMapper();
        }
        public async Task<List<QuoteDto>> GetAllQuotes()
        {

            var quotes = (await _quoteRepo.GetAllQuotes());

            if (quotes == null)
            {
                return null;
            }
            return quotes.Select(q => map.QuoteToDto(q)).ToList();
        }

        public async Task<QuoteDto> GetQuote(int quoteID)
        {
            if (await _quoteRepo.GetQuote(quoteID) == null)
            {
                return null;
            }
            //use the map to get the quote
            QuoteDto returnedQuoteDto = map.QuoteToDto(await _quoteRepo.GetQuote(quoteID));

            return returnedQuoteDto;
        }

        public async Task EditQuote(QuoteDto q)
        {
            await _quoteRepo.EditQuote(map.DtoToQuote(q));
        }

        public async Task AddQuote(QuoteDto q)
        {
            if (_quoteRepo.GetQuote(q.QuoteId) != null)
            {
                throw new Exception("Quote already exists.");
            }
            await _quoteRepo.AddQuote(map.DtoToQuote(q));
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
