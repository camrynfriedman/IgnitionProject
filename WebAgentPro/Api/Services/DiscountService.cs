using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    public interface IDiscountService {
        DbSet<Discount> GetDiscounts();
    }
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepo;

        public DiscountService(IDiscountRepository discountRepo) {
            _discountRepo = discountRepo;
        }

        public DbSet<Discount> GetDiscounts()
        {
            return _discountRepo.GetAllDiscounts();
        }
    }
}
