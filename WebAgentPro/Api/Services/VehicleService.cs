using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Mappers;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    public interface IVehicleService {
        Task<List<Vehicle>> GetVehicles();
        Task AddVehicle(VehicleDto v);
}
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;
        private VehicleMapper map;
        public VehicleService(IVehicleRepository vehicleRepo) {
            _vehicleRepo = vehicleRepo;
            map = new VehicleMapper();
        
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _vehicleRepo.GetAllVehiclesAsync();
        }

        public async Task AddVehicle(VehicleDto v) {
            //implement get vehicle by id checking
            await _vehicleRepo.AddVehicleAsync(map.DtoToVehicle(v));
        }
    }
}
