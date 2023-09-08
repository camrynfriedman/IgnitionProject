using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    //service interface specifying Discount Service Functions
    public interface IDiscountService {
        Task<IEnumerable<DiscountDto>> GetDiscountsAsync();
        Task<DiscountDto> GetDiscountAsync(string state);
        Task EditDiscount(string state, DiscountDto d);
        Task AddDiscount(DiscountDto d);
        Task RemoveDiscount(string state);
        Task<List<String>> GetInactiveStates();


    }
    public class DiscountService : IDiscountService
    {
        private DiscountMapper map;
        private string[] allStates;
        //service class contains instances of repositories
        private readonly IDiscountRepository _discountRepo;

        //service constructor
        public DiscountService(IDiscountRepository discountRepo) {
            _discountRepo = discountRepo;
            map = new DiscountMapper();
            allStates = new string[] {
                 "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
                 "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA",
                 "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY",
                 "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX",
                 "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
        }

        //service function calls the repository function and applies DTO
        public async Task<IEnumerable<DiscountDto>> GetDiscountsAsync()
        {
            var discounts = (await _discountRepo.GetAllDiscountsAsync())
                .Select(d => map.DiscountToDto(d));

            return discounts;
        }

        public async Task<DiscountDto> GetDiscountAsync(string state)
        {
            if (_discountRepo.GetDiscount(state) == null) {
                throw new DiscountException("State Discount Not Found");
            }

            DiscountDto returnedDiscount = map.DiscountToDto(await _discountRepo.GetDiscount(state));

            return returnedDiscount;
        }

        public async Task EditDiscount(string state, DiscountDto d) {
            if (state != d.State) { 
                throw new DiscountException("State Discount Not Found");
            }
            await _discountRepo.EditDiscount(map.DtoToDiscount(d));
        }

        public async Task AddDiscount(DiscountDto d) {
            if (_discountRepo.GetDiscount(d.State) != null) {
                throw new DiscountException("State Discount Already Implemented");
            }
            await _discountRepo.AddDiscount(map.DtoToDiscount(d));
        }

        public async Task RemoveDiscount(string state) {
            if (_discountRepo.GetDiscount(state) == null) {
                throw new DiscountException("State Discount Not Found");
            }
            await _discountRepo.RemoveDiscount(state);
        }

        public async Task<List<String>> GetInactiveStates() {
            var inactiveStates = allStates.Except(await _discountRepo.GetExistingStates());
            return inactiveStates.ToList();
        }
    }
}
