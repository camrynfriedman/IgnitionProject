using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.Mappers
{
    public class VehicleMapper
    {
        public VehicleDto VehicleToDto(Vehicle v) {

            VehicleDto returnedVehicleDto = new VehicleDto()
            {
                VehicleID = v.VehicleID,
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
                DriverSSN = v.DriverSSN,
                QuoteID = v.QuoteID
                
            };
            return returnedVehicleDto;
        }

        public Vehicle DtoToVehicle(VehicleDto v) {

            Vehicle returnedVehicle = new Vehicle()
            {
                VehicleID = v.VehicleID,
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
                DriverSSN = v.DriverSSN,
                QuoteID = v.QuoteID
/*                Drivers = null,
*/            };
            return returnedVehicle;
    }
    }
}
