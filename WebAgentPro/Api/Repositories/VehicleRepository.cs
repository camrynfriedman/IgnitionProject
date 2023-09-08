using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Repositories
{
    public interface IVehicleRepository {
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task AddVehicleAsync(Vehicle v);
    }
    public class VehicleRepository: IVehicleRepository
    {
        private readonly WapDbContext _context;

        public VehicleRepository(WapDbContext context) {
            _context = context;
        }

        public Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return _context.Vehicles.ToListAsync();
        }

        public async Task AddVehicleAsync(Vehicle v) {
            _context.Vehicles.Add(v);
            await _context.SaveChangesAsync();
        }
    }
}
