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
        Task<Vehicle> GetVehicleAsync(int vID);
        Task AddVehicleAsync(Vehicle v, List<int> driverIDs);
        Task EditVehicleAsync(int vID, Vehicle v);
        Task RemoveVehicleAsync(int vID);


    }
    public class VehicleRepository: IVehicleRepository
    {
        private readonly WapDbContext _context;

        public VehicleRepository(WapDbContext context) {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleAsync(int vID) {
            return await _context.Vehicles.FindAsync(vID);
        }

        public async Task AddVehicleAsync(Vehicle v, List<int> driverIds) {
            /*List<Driver> Drivers = new List<Driver>();

            foreach (int id in driverIds)
            {
                Drivers.Add(await _context.Drivers.FindAsync(id));
            }*/
/*            v.Drivers = Drivers;*/
            _context.Vehicles.Add(v);
            await _context.SaveChangesAsync();
        }

        public async Task EditVehicleAsync(int vID, Vehicle v) {
            /*_context.Vehicles.Remove(await _context.Vehicles.FindAsync(vID));
            _context.Vehicles.Add(v);*/
            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVehicleAsync(int vID) {
            _context.Vehicles.Remove(await _context.Vehicles.FindAsync(vID));
            await _context.SaveChangesAsync();
        }
    }
}
