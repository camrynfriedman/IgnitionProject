using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Mappers;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Repositories;

namespace WebAgentPro.Api.Services
{
    public interface IVehicleService {
        Task<List<VehicleDTO>> GetAllVehicles();
        Task<VehicleDTO> GetVehicle(int id);
        Task AddVehicle(VehicleDTO v);
        Task EditVehicle(int id, VehicleDTO v);
        Task RemoveVehicle(int id);

    }
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;
        private VehicleMapper map;
        public VehicleService(IVehicleRepository vehicleRepo) {
            _vehicleRepo = vehicleRepo;
            map = new VehicleMapper();
        
        }

        public async Task<List<VehicleDTO>> GetAllVehicles()
        {
            return (await _vehicleRepo.GetAllVehiclesAsync())
                .Select(v => map.VehicleToDto(v)).ToList();
        }

        public async Task<VehicleDTO> GetVehicle(int id) {

            if (_vehicleRepo.GetVehicleAsync(id) == null) {
                throw new VehicleNotFoundException("Vehicle not found with specified ID");
            }

            return map.VehicleToDto(await _vehicleRepo.GetVehicleAsync(id));
            
        }

        public async Task AddVehicle(VehicleDTO v) {
            //implement get vehicle by id checking
            await _vehicleRepo.AddVehicleAsync(map.DtoToVehicle(v));
        }

        public async Task EditVehicle(int id, VehicleDTO v) {
            if (await _vehicleRepo.GetVehicleAsync(id) == null) {
                throw new VehicleNotFoundException("Vehicle not found with specified id");
            }
            await _vehicleRepo.EditVehicleAsync(id, map.DtoToVehicle(v));
        }

        public async Task RemoveVehicle(int id)
        {
            try
            {
                await _vehicleRepo.RemoveVehicleAsync(id);
            }
            catch {
                throw new VehicleNotFoundException("Vehicle not found with requested id");
            }
        }
    }
}
