using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{
    public class QuoteMapper
    {
        //maps quote to quoteDto
        public QuoteDto QuoteToDto(Quote q)
        {
            QuoteDto returnedQuoteDto = new QuoteDto()
            {
                QuoteId = q.QuoteId,
                AgentId = q.AgentId,
                IsSubmitted = q.IsSubmitted,
                DeviceType = q.DeviceType,
                CreationDate = q.CreationDate,
                SubmissionDate = q.SubmissionDate,
                PolicyHolderFName = q.PolicyHolderFName,
                PolicyHolderLName = q.PolicyHolderLName,
                PolicyHolderEmailAddress = q.PolicyHolderEmailAddress,
                PolicyHolderPhoneNumber = q.PolicyHolderPhoneNumber,
                AddressLine1 = q.AddressLine1,
                AddressLine2 = q.AddressLine2,
                City = q.City,
                State = q.State,
                PostalCode = q.PostalCode,
                PolicyHolderSsn = q.PolicyHolderSsn,
                PolicyHolderDOB = q.PolicyHolderDOB,
                LessThan3YearsDriving = q.LessThan3YearsDriving,
                PreviousCarrier = q.PreviousCarrier,
                MovingViolationInLast5Years = q.MovingViolationInLast5Years,
                ClaimInLast5Years = q.ClaimInLast5Years,
                ForceMultiCarDiscount = q.ForceMultiCarDiscount,
                QuotePrice = q.QuotePrice,
                Drivers = q.Drivers,
                Vehicles = q.Vehicles,
            };
            return returnedQuoteDto;
        }
        //maps quote to quoteDto
        public Quote DtoToQuote(QuoteDto q)
        {
            Quote returnedQuote = new Quote()
            {
                QuoteId = q.QuoteId,
                AgentId = q.AgentId,
                IsSubmitted = q.IsSubmitted,
                DeviceType = q.DeviceType,
                CreationDate = q.CreationDate,
                SubmissionDate = q.SubmissionDate,
                PolicyHolderFName = q.PolicyHolderFName,
                PolicyHolderLName = q.PolicyHolderLName,
                PolicyHolderEmailAddress = q.PolicyHolderEmailAddress,
                PolicyHolderPhoneNumber = q.PolicyHolderPhoneNumber,
                AddressLine1 = q.AddressLine1,
                AddressLine2 = q.AddressLine2,
                City = q.City,
                State = q.State,
                PostalCode = q.PostalCode,
                PolicyHolderSsn = q.PolicyHolderSsn,
                PolicyHolderDOB = q.PolicyHolderDOB,
                LessThan3YearsDriving = q.LessThan3YearsDriving,
                PreviousCarrier = q.PreviousCarrier,
                MovingViolationInLast5Years = q.MovingViolationInLast5Years,
                ClaimInLast5Years = q.ClaimInLast5Years,
                ForceMultiCarDiscount = q.ForceMultiCarDiscount,
                QuotePrice = q.QuotePrice,
                Drivers = q.Drivers,
                Vehicles = q.Vehicles,
            };
            return returnedQuote;
        }
    }
}
    
    

