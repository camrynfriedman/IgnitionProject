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
        DbSet<Discount> GetAllDiscounts();
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
        public DbSet<Discount> GetAllDiscounts() {
            //This is the database store of Discounts
            DbSet<Discount> discounts = _context.Discounts;

            return discounts;
        }
    }
}
