using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.Mappers
{
    public class QuoteMapper
    {
        VehicleMapper vmap = new VehicleMapper();
        DriverMapper dmap = new DriverMapper();
        public QuoteDto QuoteToDto(Quote quote) {
            List<DriverDto> driverList = new List<DriverDto>();
            List<VehicleDto> vehicleList = new List<VehicleDto>();

            foreach (Driver d in quote.Drivers)
            {
                driverList.Add(dmap.DriverToDto(d));
            }

            foreach (Vehicle v in quote.Vehicles)
            {
                vehicleList.Add(vmap.VehicleToDto(v));
            }

            QuoteDto returnedQuoteDto = new QuoteDto
            {
                QuoteID = quote.QuoteID,
                AgentID = quote.AgentID,
                IsSubmitted = quote.IsSubmitted,
                DeviceType = quote.DeviceType,
                CreationDate = quote.CreationDate,
                SubmissionDate = quote.SubmissionDate,
                PolicyHolderFName = quote.PolicyHolderFName,
                PolicyHolderLName = quote.PolicyHolderLName,
                AddressLine1 = quote.AddressLine1,
                AddressLine2 = quote.AddressLine2,
                City = quote.City,
                State = quote.State,
                PostalCode = quote.PostalCode,
                PolicyHolderSsn = quote.PolicyHolderSsn,
                PolicyHolderDOB = quote.PolicyHolderDOB,
                LessThan3YearsDriving = quote.LessThan3YearsDriving,
                PreviousCarrier = quote.PreviousCarrier,
                MovingViolationInLast5Years = quote.MovingViolationInLast5Years,
                ClaimInLast5Years = quote.ClaimInLast5Years,
                ForceMultiCarDiscount = quote.ForceMultiCarDiscount,
                QuotePrice = quote.QuotePrice,
                Drivers = driverList,
                Vehicles = vehicleList,
                PolicyHolderEmailAddress = quote.PolicyHolderEmailAddress,
                PolicyHolderPhoneNumber = quote.PolicyHolderPhoneNumber,
                QuoteMultiplier = quote.QuoteMultiplier
            };
            return returnedQuoteDto;
        }

        public Quote DtoToQuote(QuoteDto quote)
        {
            List<Driver> driverList = new List<Driver>();
            List<Vehicle> vehicleList = new List<Vehicle>();

            foreach (DriverDto d in quote.Drivers)
            {
                driverList.Add(dmap.DtoToDriver(d));
            }

            foreach (VehicleDto v in quote.Vehicles)
            {
                vehicleList.Add(vmap.DtoToVehicle(v));
            }

            Quote returnedQuoteDto = new Quote
            {
                QuoteID = quote.QuoteID,
                AgentID = quote.AgentID,
                IsSubmitted = quote.IsSubmitted,
                DeviceType = quote.DeviceType,
                CreationDate = quote.CreationDate,
                SubmissionDate = quote.SubmissionDate,
                PolicyHolderFName = quote.PolicyHolderFName,
                PolicyHolderLName = quote.PolicyHolderLName,
                AddressLine1 = quote.AddressLine1,
                AddressLine2 = quote.AddressLine2,
                City = quote.City,
                State = quote.State,
                PostalCode = quote.PostalCode,
                PolicyHolderSsn = quote.PolicyHolderSsn,
                PolicyHolderDOB = quote.PolicyHolderDOB,
                LessThan3YearsDriving = quote.LessThan3YearsDriving,
                PreviousCarrier = quote.PreviousCarrier,
                MovingViolationInLast5Years = quote.MovingViolationInLast5Years,
                ClaimInLast5Years = quote.ClaimInLast5Years,
                ForceMultiCarDiscount = quote.ForceMultiCarDiscount,
                QuotePrice = quote.QuotePrice,
                Drivers = driverList,
                Vehicles = vehicleList,
                PolicyHolderEmailAddress = quote.PolicyHolderEmailAddress,
                PolicyHolderPhoneNumber = quote.PolicyHolderPhoneNumber,
                QuoteMultiplier = quote.QuoteMultiplier
            };
            return returnedQuoteDto;
        }
    }
}
    
    

