using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Repositories
{
    public interface IDiscountRepository {
        DbSet<Discount> GetAllDiscounts();
    }
    public class DiscountRepository : IDiscountRepository
    {
        public static WapDbContext _context;

        

        public DbSet<Discount> GetAllDiscounts() {
            //This is where the database store of Discounts will be placed
            DbSet<Discount> discounts = _context.Discounts;

            return discounts;
        }
    }
}
