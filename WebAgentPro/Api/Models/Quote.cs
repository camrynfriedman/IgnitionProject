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
        public Guid Id { get; set; }
        [Required]
        public DateTime QuoteDateTime { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Ssn { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public bool LessThan3YearsDriving { get; set; }
        [Required]
        public string PreviousCarrier { get; set; }
        [Required]
        public bool MovingVioliationInLast5Years { get; set; }
        [Required]
        public bool ClaimInLast5Years { get; set; }
        [Required]
        public bool ForceMultiCarDiscount { get; set; }
        [Required]
        public List<Driver> Drivers { get; set; }
        [Required]
        public List<Vehicle> Vehicles { get; set; }
        [Required]
        public decimal QuoteMultiplier { get; set; }
        [Required]
        public decimal QuotePrice { get; set; }


        public Quote()
        {
            Id = Guid.NewGuid();
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            State = "";
            Zip = "";
            Ssn = "";
            PreviousCarrier = "";
            QuoteDateTime = DateTime.Now;
            Drivers = new List<Driver>();
            Vehicles = new List<Vehicle>();
        }

    }
}
