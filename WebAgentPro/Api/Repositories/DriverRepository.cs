using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Repositories
{
    /*
     * Contains the driverRepo interface as well as the driverRepo object class.
     */
public interface IDriverRepository
    {
        // Get all drivers
        Task<List<Driver>> GetAllDrivers();

        // get by ID
        Task<Driver> GetDriver(int driverID);

        // get by License Number
        Task<Driver> GetDriverByLicense(string driversLicenseNum);

        // edit driver
        Task EditDriver(Driver d);

        // insert
        Task AddDriver(Driver d);

        // delete
        Task RemoveDriver(int driverID);

  

    }
    public class DriverRepository : IDriverRepository
    {
        //connection to database context
        private readonly WapDbContext _context;


        public DriverRepository(WapDbContext context)
        {
            _context = context;

        }

        //Implement methods
        public async Task<List<Driver>> GetAllDrivers()
        {
            var drivers = await _context.Drivers.ToListAsync();

            return drivers;
        }

        public async Task<Driver> GetDriver(int driverID)
        {
            Driver driver = await _context.Drivers.Where(d => d.DriverId == driverID).FirstOrDefaultAsync();
            return driver;
        }

        public async Task<Driver> GetDriverByLicense(string driverLicenseNum)
        {
            Driver driver = await _context.Drivers.Where(d => d.DriverLicenseNumber == driverLicenseNum).FirstOrDefaultAsync();
            return driver;
        }
        public async Task EditDriver(Driver d)
        {
            _context.Entry(d).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddDriver(Driver d)
        {
            _context.Drivers.Add(d);
            await _context.SaveChangesAsync();
        }

        //removes driver by driverID
        public async Task RemoveDriver(int driverID)
        {
            _context.Drivers.Remove(_context.Drivers.Where(d=> d.DriverId == driverID).FirstOrDefault());
            await _context.SaveChangesAsync();
        }
    }
    
}
