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
        public QuoteDTO QuoteToDTO(Quote quote)
        {
            List<DriverDTO> driverList = new List<DriverDTO>();
            List<VehicleDTO> vehicleList = new List<VehicleDTO>();

            foreach (Driver d in quote.Drivers)
            {
                driverList.Add(dmap.DriverToDto(d));
            }

            foreach (Vehicle v in quote.Vehicles)
            {
                vehicleList.Add(vmap.VehicleToDto(v));
            }

            QuoteDTO returnedQuoteDto = new QuoteDTO
            {
                QuoteId = quote.QuoteId,
                AgentId = quote.AgentId,
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
                PolicyHolderPhoneNumber = quote.PolicyHolderPhoneNumber
            };
            return returnedQuoteDto;
        }

        public Quote DTOToQuote(QuoteDTO quote)
        {
            List<Driver> driverList = new List<Driver>();
            List<Vehicle> vehicleList = new List<Vehicle>();

            foreach (DriverDTO d in quote.Drivers)
            {
                driverList.Add(dmap.DtoToDriver(d));
            }

            foreach (VehicleDTO v in quote.Vehicles)
            {
                vehicleList.Add(vmap.DtoToVehicle(v));
            }

            Quote returnedQuoteDto = new Quote
            {
                QuoteId = quote.QuoteId,
                AgentId = quote.AgentId,
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
                PolicyHolderPhoneNumber = quote.PolicyHolderPhoneNumber
            };
            return returnedQuoteDto;
        }
    }
}
