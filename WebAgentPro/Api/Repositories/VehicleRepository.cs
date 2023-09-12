using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        Task<Vehicle> GetVehicle(int vID);
        Task<Vehicle> AddVehicle(Vehicle v);
        Task EditVehicle(int vID, Vehicle v);
        Task RemoveVehicle(int vID);


    }
    public class VehicleRepository: IVehicleRepository
    {
        private readonly WapDbContext _context;

        public VehicleRepository(WapDbContext context) {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicle(int vID) {
            return await _context.Vehicles.FindAsync(vID);
        }

        public async Task<Vehicle> AddVehicle(Vehicle v) {
            EntityEntry<Vehicle> entity = _context.Vehicles.Add(v);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task EditVehicle(int vID, Vehicle v) {
            _context.Vehicles.Remove(await _context.Vehicles.FindAsync(vID));
            v.VehicleID = vID;
            _context.Vehicles.Add(v);
/*            _context.Entry(v).State = EntityState.Modified;
*/            await _context.SaveChangesAsync();
        }

        public async Task RemoveVehicle(int vID) {
            _context.Vehicles.Remove(await _context.Vehicles.FindAsync(vID));
            await _context.SaveChangesAsync();
        }
    }
}
