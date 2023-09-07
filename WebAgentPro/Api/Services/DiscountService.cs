using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    //service interface specyfying Discount Service Functions
    public interface IDiscountService {
        DbSet<Discount> GetDiscounts();
    }
    public class DiscountService : IDiscountService
    {
        //service class contains instances of repositories
        private readonly IDiscountRepository _discountRepo;

        //service constructor
        public DiscountService(IDiscountRepository discountRepo) {
            _discountRepo = discountRepo;
        }

        //service function calls the repository function
        public DbSet<Discount> GetDiscounts()
        {
            return _discountRepo.GetAllDiscounts();
        }
    }
}
