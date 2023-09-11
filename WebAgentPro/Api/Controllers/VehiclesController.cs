using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAgentPro.Api.Models;
using WebAgentPro.Api.Services;
using WebAgentPro.Data;

namespace WebAgentPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly WapDbContext _context;

        public VehiclesController(IVehicleService vehicleService, WapDbContext context)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            try
            {
                var vehicle = await _vehicleService.GetAllVehicles();
                return Ok(vehicle);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicle(id);
                return Ok(vehicle);
            }
            catch (VehicleNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleDto vehicle)
        {
            try
            {
                await _vehicleService.EditVehicle(id, vehicle);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/
        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDto vehicleDto)
        {
            try
            {
                await _vehicleService.AddVehicle(vehicleDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            return CreatedAtAction("GetVehicle", new { id = vehicleDto.VehicleId }, vehicleDto);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleDto>> DeleteVehicle(int id)
        {
            try
            {
                VehicleDto vehicle = await _vehicleService.GetVehicle(id);
                await _vehicleService.RemoveVehicle(id);
                return Ok(vehicle);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

    }
}
