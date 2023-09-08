using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.Mappers
{
    public class VehicleMapper
    {
        public VehicleDto VehichleToDto(Vehicle v) {

            List<int> driverIDs = new List<int>();
            if (v.Drivers != null)
            {
                foreach (Driver d in v.Drivers)
                {
                    driverIDs.Add(d.DriverId);
                }
            }
            
            VehicleDto returnedVehicleDto = new VehicleDto()
            {
                VehicleId = v.VehicleId,
                Vin = v.Vin,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                CurrentValue = v.CurrentValue,
                AnnualMileage = v.AnnualMileage,
                DaytimeRunningLights = v.DaytimeRunningLights,
                AntilockBrakes = v.AntilockBrakes,
                PassiveRestraints = v.PassiveRestraints,
                AntiTheft = v.AntiTheft,
                DaysDrivenPerWeek = v.DaysDrivenPerWeek,
                MilesDrivenToWork = v.MilesDrivenToWork,
                ReducedUsedDiscount = v.ReducedUsedDiscount,
                GarageAddressDifferentFromResidence = v.GarageAddressDifferentFromResidence,
                QuoteMultiplier = v.QuoteMultiplier,
                PrimaryDriverId = v.PrimaryDriverId,
                DriversIDs = driverIDs
            };
            return returnedVehicleDto;
        }

        public Vehicle DtoToVehicle(VehicleDto v) {

            Vehicle returnedVehicle = new Vehicle()
            {
                VehicleId = v.VehicleId,
                Vin = v.Vin,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                CurrentValue = v.CurrentValue,
                AnnualMileage = v.AnnualMileage,
                DaytimeRunningLights = v.DaytimeRunningLights,
                AntilockBrakes = v.AntilockBrakes,
                PassiveRestraints = v.PassiveRestraints,
                AntiTheft = v.AntiTheft,
                DaysDrivenPerWeek = v.DaysDrivenPerWeek,
                MilesDrivenToWork = v.MilesDrivenToWork,
                ReducedUsedDiscount = v.ReducedUsedDiscount,
                GarageAddressDifferentFromResidence = v.GarageAddressDifferentFromResidence,
                QuoteMultiplier = v.QuoteMultiplier,
                PrimaryDriverId = v.PrimaryDriverId,
                //keep Drivers as null until we have Driver data
                Drivers = null
            };
            return returnedVehicle;
    }
    }
}
