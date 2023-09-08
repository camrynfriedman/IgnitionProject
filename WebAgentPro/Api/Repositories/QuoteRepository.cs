using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Repositories
{
    /*
     * Contains the QuoteRepo interface as well as the QuoteRepo object class.
     */
public interface IQuoteRepository
    {
        // Get all quotes
        Task<List<Quote>> GetAllQuotesAsync();

        // get by ID
        Task<Quote> GetQuote(int quoteID);

        // insert

        // update

        // delete

        //

    }
    public class QuoteRepository : IQuoteRepository
    {
        //connection to database context
        private readonly WapDbContext _context;


        public QuoteRepository(WapDbContext context)
        {
            _context = context;

        }

        //Implement methods
        public async Task<List<Quote>> GetAllQuotesAsync()
        {
            var quotes = await _context.Quotes.ToListAsync();

            return quotes;
        }

        public async Task<Quote> GetQuote(int quoteID)
        {
            Quote quote = await _context.Quotes.Where(q => q.QuoteId == quoteID).FirstOrDefaultAsync();
            return quote;
        }

    }
    
}
