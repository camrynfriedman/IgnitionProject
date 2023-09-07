﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{
    public class Mapper
    {
        public DiscountDto DiscountToDto(Discount d) {

            DiscountDto returnedDiscountDTO = new DiscountDto()
            {
                State = d.State,
                DaytimeRunningLights = d.DaytimeRunningLights,
                AntilockBrakes = d.AntilockBrakes,
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
            return returnedDiscountDTO;
        }
    }
}
