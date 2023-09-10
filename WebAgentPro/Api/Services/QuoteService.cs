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
     * */

    public interface IQuoteService
    {
        Task<List<QuoteDto>> GetAllQuotesAsync();
        Task<QuoteDto> GetQuote(int quoteID);

        /*
         * ADD METHODS FROM REPO
         * */
    }

    public class QuoteService: IQuoteService
    {
        //use QuoteRepository
        private readonly IQuoteRepository _quoteRepo;

        //use mapper
        private QuoteMapper map;


        //constructor
        public QuoteService(IQuoteRepository quoteRepo)
        {
            _quoteRepo = quoteRepo;
            map = new QuoteMapper();
        }
        public async Task<List<QuoteDto>> GetAllQuotesAsync()
        {

            var quotes = (await _quoteRepo.GetAllQuotesAsync());
       
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

        public async Task EditQuote(int quoteID, Quote q)
        {
            if (quoteID != )
        }
        public async Task AddQuote(QuoteDto q)
        {
            if (await _quoteRepo.)
        }
    }
}
