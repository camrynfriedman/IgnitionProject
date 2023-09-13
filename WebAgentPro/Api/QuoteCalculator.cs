using System;
using System.Collections.Generic;
using System.Linq;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api
{
    public class QuoteCalculator
    {
        //constructor
        public QuoteCalculator() { }

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

            var totalQuoteMultiplier = 1;

            // Deal with drivers
            foreach (var driver in q.Drivers)
            {
                var driverCost = GetBaseDriverCost();
                driver.QuoteMultiplier = 1; //ensure multiplier is initialized to proper value
                if (driver.SafeDrivingSchool) driver.QuoteMultiplier *= discount.SafeDrivingSchool;
                if (driver.DriverDOB > DateTime.Now.AddYears(-23)) driver.QuoteMultiplier *= (1.0m+discount.YoungDriver); //add 1 to multiplier to account for positive percentages 
                driverCost *= driver.QuoteMultiplier; //apply multiplier to driver cost
                driverSubtotalCost += driverCost; //add subtotal for individual driver to total driver cost
            }

            // Deal with vehicles
            foreach (var vehicle in q.Vehicles)
            {
                var vehicleCost = GetBaseVehicleCost(vehicle.CurrentValue);
                vehicle.QuoteMultiplier = 1;
                if (vehicle.AnnualMileage < 6000) vehicle.QuoteMultiplier *= .98m;
                if (vehicle.AntilockBrakes) vehicle.QuoteMultiplier *= .98m;
                if (vehicle.AntiTheft) vehicle.QuoteMultiplier *= .97m;
                if (vehicle.DaysDrivenPerWeek > 4) vehicle.QuoteMultiplier *= 1.02m;
                if (vehicle.MilesDrivenToWork < 25) vehicle.QuoteMultiplier *= .98m;
                if (vehicle.DaytimeRunningLights) vehicle.QuoteMultiplier *= .99m;
                if (vehicle.GarageAddressDifferentFromResidence) vehicle.QuoteMultiplier *= 1.03m;
                if (vehicle.PassiveRestraints) vehicle.QuoteMultiplier *= .97m;
                if (vehicle.ReducedUsedDiscount) vehicle.QuoteMultiplier *= .94m;
                var primaryOperator = q.Drivers.Find(d => d.DriverID == vehicle.DriverID);
                if (primaryOperator != null) vehicle.QuoteMultiplier *= primaryOperator.QuoteMultiplier;
                vehicleCost *= vehicle.QuoteMultiplier; //apply multiplier to vehicle cost
                vehicleSubtotalCost += vehicleCost; //add subtotal for individual vehicle to total vehicle cost
            }
            policyCost = GetBasePolicyCost();
            q.QuoteMultiplier = 1;
            policyCost += driverSubtotalCost + vehicleSubtotalCost;
            if (q.ClaimInLast5Years) q.QuoteMultiplier *= 1.2m;
            if (q.ForceMultiCarDiscount || q.Vehicles.Count > 1) q.QuoteMultiplier *= .95m;
            if (q.LessThan3YearsDriving) q.QuoteMultiplier *= 1.15m;
            if (q.MovingViolationInLast5Years) q.QuoteMultiplier *= 1.20m;
            if (q.PreviousCarrier == "Lizard Insurance") q.QuoteMultiplier *= 1.05m;
            if (q.PreviousCarrier == "Pervasive Insurance") q.QuoteMultiplier *= .97m;
            policyCost *= q.QuoteMultiplier;

            return policyCost;

        }


        private decimal GetBasePolicyCost()
        {
            return 100m;
        }

        private decimal GetBaseVehicleCost(decimal currentValue)
        {
            return currentValue * .03m; //currentValue * 3%
        }

        private decimal GetBaseDriverCost()
        {
            return 200m;
        }
    }
}
