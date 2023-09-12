using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.Mappers
{
    public class DiscountMapper
    {
        public DiscountDto DiscountToDto(Discount d) {

            DiscountDto returnedDiscountDto = new DiscountDto()
            {
                State = d.State,
                DaytimeRunningLights = d.DaytimeRunningLights,
                LowAnnualMileage = d.LowAnnualMileage,
                PassiveRestraints = d.PassiveRestraints,
                AntitheftInstalled = d.AntitheftInstalled,
                HighDaysDrivenPerWeek = d.HighDaysDrivenPerWeek,
                LowMilesDrivenToWork = d.LowMilesDrivenToWork,
                ReduceUse = d.ReduceUse,
                GarageAddressDifferent = d.GarageAddressDifferent,
                LowDrivingExperience = d.LowDrivingExperience,
                PreviousCarrierLizard = d.PreviousCarrierLizard,
                PreviousCarrierPervasive = d.PreviousCarrierPervasive,
                RecentMovingViolations = d.RecentMovingViolations,
                RecentClaims = d.RecentClaims,
                MultiCar = d.MultiCar,
                YoungDriver = d.YoungDriver,
                SafeDrivingSchool = d.SafeDrivingSchool
            };
            return returnedDiscountDto;
        }

        public Discount DtoToDiscount(DiscountDto d)
        {
            Discount returnedDiscount = new Discount()
            {
                State = d.State,
                DaytimeRunningLights = d.DaytimeRunningLights,
                LowAnnualMileage = d.LowAnnualMileage,
                PassiveRestraints = d.PassiveRestraints,
                AntitheftInstalled = d.AntitheftInstalled,
                HighDaysDrivenPerWeek = d.HighDaysDrivenPerWeek,
                LowMilesDrivenToWork = d.LowMilesDrivenToWork,
                ReduceUse = d.ReduceUse,
                GarageAddressDifferent = d.GarageAddressDifferent,
                LowDrivingExperience = d.LowDrivingExperience,
                PreviousCarrierLizard = d.PreviousCarrierLizard,
                PreviousCarrierPervasive = d.PreviousCarrierPervasive,
                RecentMovingViolations = d.RecentMovingViolations,
                RecentClaims = d.RecentClaims,
                MultiCar = d.MultiCar,
                YoungDriver = d.YoungDriver,
                SafeDrivingSchool = d.SafeDrivingSchool
            };
            return returnedDiscount;
        }

    }
}
