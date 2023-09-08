using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Repositories
{
    //Repository interface specifying functions in Discount Repository
    public interface IDiscountRepository {
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscount(string state);
        Task AddDiscount(Discount d);
        Task EditDiscount(Discount d);
        Task RemoveDiscount(string state);
        Task<List<String>> GetExistingStates();
    }
    public class DiscountRepository : IDiscountRepository
    {
        //connection to database context
        protected readonly WapDbContext _context;
        

        public DiscountRepository(WapDbContext context)
        {
            _context = context;
        }

        //repostiory function to get all the discounts
        //C# has lazy loading, pull list from DbSet
        public async Task<List<Discount>> GetAllDiscountsAsync() {
            //This is the database store of Discounts
            var discounts = await _context.Discounts.ToListAsync();

            return discounts;
        }

        public async Task<Discount> GetDiscount(string state) {
            Discount discount = _context.Discounts.Where(d => d.State == state).FirstOrDefault();
            await _context.SaveChangesAsync();

            return discount;
        }

        public async Task EditDiscount(Discount d) {
            _context.Entry(d).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscount(Discount discount) {
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDiscount(string state) {
            _context.Discounts.Remove(_context.Discounts.Where(d => d.State == state).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task<List<String>> GetExistingStates() {
            return await _context.Discounts
                .OrderBy(s => s.State)
                .Select(d => d.State)
                .ToListAsync();
        }
    }
}
