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
        public VehicleDTO VehicleToDto(Vehicle v) {
            
            VehicleDTO returnedVehicleDTO = new VehicleDTO()
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
                
            };
            return returnedVehicleDTO;
        }

        public Vehicle DtoToVehicle(VehicleDTO v) {

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
/*                Drivers = null,
*/            };
            return returnedVehicle;
    }
    }
}
