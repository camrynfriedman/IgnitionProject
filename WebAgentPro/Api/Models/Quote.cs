using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{
    [DataObject] //not sure what this is, but it was included in CS-Agent
    public class Quote
    {
        [Key]
        [Required]
        public int QuoteId { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public bool IsSubmitted { get; set; }

        //expected "Mobile" or "Laptop"
        [Required]
        public string DeviceType { get; set; }

        [Required]
        public DateTime? CreationDate { get; set; }

        //is this required?
        [Required]
        public DateTime? SubmissionDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        
        // figure out how to make this optional
        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Required]
        public string PostalCode { get; set; }
        
        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string Ssn { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool LessThan3YearsDriving { get; set; }

        [Required]
        public string PreviousCarrier { get; set; }

        [Required]
        public bool MovingViolationInLast5Years { get; set; }

        [Required]
        public bool ClaimInLast5Years { get; set; }

        [Required]
        public bool ForceMultiCarDiscount { get; set; }

        //one to many relationship with drivers
        //implicity foreign keys to driverIDs
        [Required]
        public List<Driver> Drivers { get; set; }

        //one to many relationship with Vehicles
        //implicity foreign keys via VehicleIDs
        [Required]
        public List<Vehicle> Vehicles { get; set; }

        [Required]
        public decimal QuotePrice { get; set; }

        

    }
}
