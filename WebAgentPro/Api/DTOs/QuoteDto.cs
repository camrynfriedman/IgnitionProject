using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{
    public class QuoteDto
    {
        [Key]
        [Required]
        public int QuoteId { get; set; }

        [Required]
        [EmailAddress]
        public string AgentId { get; set; }

        [Required]
        public bool IsSubmitted { get; set; }

        //expected "Mobile" or "Laptop"
        [Required]
        public string DeviceType { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        //can be null if IsSubmitted = false
        [Required]
        public DateTime? SubmissionDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string PolicyHolderFName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PolicyHolderLName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string PolicyHolderEmailAddress { get; set; }

        [Required]
        [MaxLength(10)]
        [Phone]
        public string PolicyHolderPhoneNumber { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string PolicyHolderSsn { get; set; }

        [Required]
        public DateTime PolicyHolderDOB { get; set; }

        [Required]
        public bool LessThan3YearsDriving { get; set; }

        // Expected "Lizard" or "Pervasive"
        [Required]
        [MinLength(6)]
        [MaxLength(9)]
        public string PreviousCarrier { get; set; }

        [Required]
        public bool MovingViolationInLast5Years { get; set; }

        [Required]
        public bool ClaimInLast5Years { get; set; }

        [Required]
        public bool ForceMultiCarDiscount { get; set; }

        [Required]
        public decimal QuotePrice { get; set; }


        // Add relationships

        //one to many relationship with drivers
        //implicity foreign keys to driverIDs
        [Required]
        public List<Driver> Drivers { get; set; }

        //one to many relationship with Vehicles
        //implicity foreign keys via VehicleIDs
        [Required]
        public List<Vehicle> Vehicles { get; set; }
    }
}
