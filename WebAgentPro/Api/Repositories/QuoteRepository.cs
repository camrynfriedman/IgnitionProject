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
        Task<List<Quote>> GetAllQuotes();

        // get by ID
        Task<Quote> GetQuote(int quoteID);

        // edit quote
        Task EditQuote(Quote q);

        // insert
        Task AddQuote(Quote q);

        // delete
        Task RemoveQuote(int quoteID);

  

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
        public async Task<List<Quote>> GetAllQuotes()
        {
            var quotes = await _context.Quotes.Include(x=>x.Vehicles).Include(x=>x.Drivers).ToListAsync();

            return quotes;
        }

        public async Task<Quote> GetQuote(int quoteID)
        {
            Quote quote = await _context.Quotes.Where(q => q.QuoteId == quoteID).FirstOrDefaultAsync();
            return quote;
        }

        public async Task EditQuote(Quote q)
        {
            _context.Entry(q).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddQuote(Quote q)
        {
            _context.Quotes.Add(q);
            await _context.SaveChangesAsync();
        }

        //removes quote by quoteID
        public async Task RemoveQuote(int quoteID)
        {
            _context.Quotes.Remove(_context.Quotes.Where(q=> q.QuoteId == quoteID).FirstOrDefault());
            await _context.SaveChangesAsync();
        }
    }
    
}
