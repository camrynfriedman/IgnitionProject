using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    public interface IVehicleService {
        Task<List<Vehicle>> GetVehicles();
}
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;
        public VehicleService(IVehicleRepository vehicleRepo) {
            _vehicleRepo = vehicleRepo;
        
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _vehicleRepo.GetAllVehicles();
        }
    }
}
