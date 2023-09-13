using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.DTOs
{
    public class QuoteDto
    {
        public int QuoteID { get; set; }
        public string AgentID { get; set; }
        public bool IsSubmitted { get; set; }
        public string DeviceType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string PolicyHolderFName { get; set; }
        public string PolicyHolderLName { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PolicyHolderSsn { get; set; }
        public DateTime PolicyHolderDOB { get; set; }
        public bool LessThan3YearsDriving { get; set; }
        public string PreviousCarrier { get; set; }
        public bool MovingViolationInLast5Years { get; set; }
        public bool ClaimInLast5Years { get; set; }
        public bool ForceMultiCarDiscount { get; set; }
        public decimal QuoteMultiplier { get; set; }
        public decimal QuotePrice { get; set; }
        public string PolicyHolderEmailAddress { get; set; }
        public string PolicyHolderPhoneNumber { get; set; }


        public List<DriverDto> Drivers { get; set; }

        //one to many relationship with Vehicles
        //implicity foreign keys via VehicleIDs
        
        public List<VehicleDto> Vehicles { get; set; }
    }
}
