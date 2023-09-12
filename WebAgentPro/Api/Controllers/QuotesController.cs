using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Mappers;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Services;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Controllers
{
    /*
 * The controller uses the QuoteDto rather than Quote 
 * and calls methods from the service.
 * */

    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // GET: api/Quotes
        // get a list of all quotes
        [HttpGet]
        public async Task<ActionResult<List<QuoteDto>>> GetQuotes()
        {
            var quotes = await _quoteService.GetAllQuotes();
            //if there no quotes are created, return an empty list
            if (quotes == null)
            {
                return NotFound();
            }
            return quotes;
        }

        // GET: api/Quotes/5
        // get an individual quote by id
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteDto>> GetQuote(int id)
        {
            var quote = await _quoteService.GetQuote(id);

            if (quote is null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // Corresponds to EditQuote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<QuoteDto>> PutQuote(int id, QuoteDto quote)
        {
            if (id != quote.QuoteID || quote is null)
            {
                return BadRequest();
            }
            await _quoteService.EditQuote(quote);
            return Ok();
        }

        // POST: api/Quotes
        // Corresponds to AddQuote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuoteDto>> PostQuote(QuoteDto quote)
        {
            await _quoteService.AddQuote(quote);

            return CreatedAtAction("GetQuote", new { id = quote.QuoteID }, quote);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuoteDto>> DeleteQuote(int id)
        {
            var quote = await _quoteService.GetQuote(id);
            if (quote == null)
            {
                return NotFound();
            }
           await _quoteService.RemoveQuote(id);

            return Ok();
        }

    }

}
