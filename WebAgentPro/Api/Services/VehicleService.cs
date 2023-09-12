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
        Task<List<VehicleDto>> GetAllVehicles();
        Task<VehicleDto> GetVehicle(int id);
        Task AddVehicle(VehicleDto v);
        Task EditVehicle(int id, VehicleDto v);
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

        public async Task<List<VehicleDto>> GetAllVehicles()
        {
            return (await _vehicleRepo.GetAllVehicles())
                .Select(v => map.VehicleToDto(v)).ToList();
        }

        public async Task<VehicleDto> GetVehicle(int id) {

            if (_vehicleRepo.GetVehicle(id) == null) {
                throw new VehicleNotFoundException("Vehicle not found with specified ID");
            }

            return map.VehicleToDto(await _vehicleRepo.GetVehicle(id));
            
        }

        public async Task AddVehicle(VehicleDto v) {
            //implement get vehicle by id checking
            await _vehicleRepo.AddVehicle(map.DtoToVehicle(v));
        }

        public async Task EditVehicle(int id, VehicleDto v) {
            if (await _vehicleRepo.GetVehicle(id) == null) {
                throw new VehicleNotFoundException("Vehicle not found with specified id");
            }
            await _vehicleRepo.EditVehicle(id, map.DtoToVehicle(v));
        }

        public async Task RemoveVehicle(int id)
        {
            try
            {
                await _vehicleRepo.RemoveVehicle(id);
            }
            catch {
                throw new VehicleNotFoundException("Vehicle not found with requested id");
            }
        }
    }
}
