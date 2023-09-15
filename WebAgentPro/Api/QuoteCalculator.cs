using System;
using System.Collections.Generic;
using System.Linq;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api
{
    public class QuoteCalculator
    {
        //constructor
        public QuoteCalculator() {
 
        }

        /*
         * Person multipliers get applied to the person and to vehicle person is assigned to
         * Vehicle multipliers get applied to the vehicle
         * Quote multipliers get applied to the quote total
         */

        // Discount Percentages:
        /*
         * Positive means less of a discount/costs more money. Add 1 to this percentage every time before multiplying it by the multiplier
         * */

        //function that will calculate the price of a given quote
        public decimal CalculatePrice(Quote q, Discount discount)
        {

            var vehicleSubtotalCost = 0m;
            var driverSubtotalCost = 0m;
            var policyCost = 0m;

            // Deal with drivers
            foreach (var driver in q.Drivers)
            {
                var driverCost = GetBaseDriverCost();
                driver.QuoteMultiplier = 1; //ensure multiplier is initialized to proper value
                if (driver.SafeDrivingSchool) driver.QuoteMultiplier *= FixDiscount(discount.SafeDrivingSchool); ;
                if (driver.DriverDOB > DateTime.Now.AddYears(-23)) driver.QuoteMultiplier *= FixDiscount(discount.YoungDriver);
                driverCost *= driver.QuoteMultiplier; //apply multiplier to driver cost
                driverSubtotalCost += driverCost; //add subtotal for individual driver to total driver cost
            }

            // Deal with vehicles
            foreach (var vehicle in q.Vehicles)
            {
                var vehicleCost = GetBaseVehicleCost(vehicle.CurrentValue);
                vehicle.QuoteMultiplier = 1;
                if (vehicle.AnnualMileage < 6000) vehicle.QuoteMultiplier *= FixDiscount(discount.LowAnnualMileage);
                if (vehicle.AntilockBrakes) vehicle.QuoteMultiplier *= FixDiscount(discount.AntilockBrakes);
                if (vehicle.AntiTheft) vehicle.QuoteMultiplier *= FixDiscount(discount.AntitheftInstalled);
                if (vehicle.DaysDrivenPerWeek > 4) vehicle.QuoteMultiplier *= FixDiscount(discount.HighDaysDrivenPerWeek);
                if (vehicle.MilesDrivenToWork < 25) vehicle.QuoteMultiplier *= FixDiscount(discount.LowMilesDrivenToWork);
                if (vehicle.DaytimeRunningLights) vehicle.QuoteMultiplier *= FixDiscount(discount.DaytimeRunningLights);
                if (vehicle.GarageAddressDifferentFromResidence) vehicle.QuoteMultiplier *= FixDiscount(discount.GarageAddressDifferent);
                if (vehicle.PassiveRestraints) vehicle.QuoteMultiplier *= FixDiscount(discount.PassiveRestraints); ;
                if (vehicle.ReducedUsedDiscount) vehicle.QuoteMultiplier *= FixDiscount(discount.ReduceUse);
                var primaryOperator = q.Drivers.Find(d => d.DriverID == vehicle.DriverID);
                if (primaryOperator != null) vehicle.QuoteMultiplier *= primaryOperator.QuoteMultiplier;
                vehicleCost *= vehicle.QuoteMultiplier; //apply multiplier to vehicle cost
                vehicleSubtotalCost += vehicleCost; //add subtotal for individual vehicle to total vehicle cost
            }
            policyCost = GetBasePolicyCost();
            q.QuoteMultiplier = 1;
            policyCost += driverSubtotalCost + vehicleSubtotalCost;
            if (q.ClaimInLast5Years) q.QuoteMultiplier *= FixDiscount(discount.RecentClaims);
            if (q.ForceMultiCarDiscount || q.Vehicles.Count > 1) q.QuoteMultiplier *= FixDiscount(discount.MultiCar);
            if (q.LessThan3YearsDriving) q.QuoteMultiplier *= FixDiscount(discount.LowDrivingExperience);
            if (q.MovingViolationInLast5Years) q.QuoteMultiplier *= FixDiscount(discount.RecentMovingViolations);
            if (q.PreviousCarrier == "Lizard Insurance") q.QuoteMultiplier *= FixDiscount(discount.PreviousCarrierLizard);
            if (q.PreviousCarrier == "Pervasive Insurance") q.QuoteMultiplier *= FixDiscount(discount.PreviousCarrierPervasive);
            policyCost *= q.QuoteMultiplier;

            return policyCost;

        }


        private static decimal GetBasePolicyCost()
        {
            return 100m;
        }

        private static decimal GetBaseVehicleCost(decimal currentValue)
        {
            return currentValue * .03m; //currentValue * 3%
        }

        private static decimal GetBaseDriverCost()
        {
            return 200m;
        }

        private decimal FixDiscount(decimal discountPercentage)
        {
            decimal fixedDiscount;
            if (discountPercentage < 0) { fixedDiscount = 1.0m - Math.Abs(discountPercentage);}
            else { fixedDiscount = 1.0m + Math.Abs(discountPercentage); }
            return fixedDiscount;
        }
    }
}
