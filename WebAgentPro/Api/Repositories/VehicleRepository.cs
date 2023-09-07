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
        Task<List<Vehicle>> GetAllVehicles();
    }
    public class VehicleRepository: IVehicleRepository
    {
        private readonly WapDbContext _context;

        public VehicleRepository(WapDbContext context) {
            _context = context;
        }

        public Task<List<Vehicle>> GetAllVehicles()
        {
            return _context.Vehicles.ToListAsync();
        }
    }
}
