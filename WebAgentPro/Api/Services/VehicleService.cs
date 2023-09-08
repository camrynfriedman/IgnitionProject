﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return (await _vehicleRepo.GetAllVehiclesAsync())
                .Select(v => map.VehichleToDto(v)).ToList();
        }

        public async Task<VehicleDto> GetVehicle(int id) {

            if (_vehicleRepo.GetVehicleAsync(id) == null) {
                throw new VehicleNotFoundException("Vehicle not found with specified ID");
            }

            return map.VehichleToDto(await _vehicleRepo.GetVehicleAsync(id));
            
        }

        public async Task AddVehicle(VehicleDto v) {
            //implement get vehicle by id checking
            await _vehicleRepo.AddVehicleAsync(map.DtoToVehicle(v), v.DriversIDs);
        }

        public async Task EditVehicle(int id, VehicleDto v) {
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
