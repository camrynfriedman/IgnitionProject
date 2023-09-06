using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{
    public class Driver
    {
        [Key]
        [Required]
        public int DriverId { get; set; }

        [Required]
        public string DriverFName { get; set; }

        [Required]
        public string DriverLName { get; set; }

        [MinLength(9)]
        [MaxLength(9)]
        [Required]
        public string DriverSSN { get; set; }

        [Required]
        public string DriverLicenseNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string DriverLicenseState { get; set; }

        [Required]
        public DateTime DriverDOB { get; set; }

        [Required]
        public bool SafeDrivingSchool { get; set; }

        [Required]
        public decimal QuoteMultiplier { get; set; }

        // Add relationships
        // required foreign key
        // this is assuming each Driver is only associated with one Quote
        [Required]
        [ForeignKey("Quote")]
        public int QuoteId { get; set; }

        [Required]
        public List<Vehicle> Vehicles { get; set; }
        
    }
}
