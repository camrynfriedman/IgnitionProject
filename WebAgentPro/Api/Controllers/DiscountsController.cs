using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Services;

namespace WebAgentPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        //instance of service class
        private readonly IDiscountService _discountService;
        private DiscountMapper map;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
            map = new DiscountMapper();
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetDiscount()
        {
            /*var returnedDiscounts = await _discountService.GetDiscountsAsync()
                .Select(d => map.DiscountToDto(d)).ToListAsync();*/
            return (await _discountService.GetDiscountsAsync()).ToList();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountDto>> GetDiscount(string id)
        {
            try
            {
                var discount = await _discountService.GetDiscountAsync(id);
                return discount;
            }
            catch (NullReferenceException e) {
                //State not in Discount database will return a NotFound error
                return NotFound(e.Message);
            }
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(string id, DiscountDto discount)
        {

            try
            {
                await _discountService.EditDiscount(id, discount);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }

            return NoContent();
     
        }

        // POST: api/Discounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(DiscountDto discountDto)
        {
            try
            {
                await _discountService.AddDiscount(discountDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("GetDiscount", new { id = discountDto.State }, discountDto);
        }

        // DELETE: api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiscountDto>> DeleteDiscount(string id)
        {
            DiscountDto discount = await _discountService.GetDiscountAsync(id);
            await _discountService.RemoveDiscount(id);

            return discount;
        }

        [HttpGet("InactiveStates")]
        public async Task<ActionResult<IEnumerable<string>>> InactiveStates()
        {
            return await _discountService.GetInactiveStates();
        }
    }
}
