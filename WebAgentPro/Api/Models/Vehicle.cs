using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.Models
{

    public class Vehicle
    {
        [Key]
        [Required]
        public int VehicleId { get; set; }

        [Required]
        [MinLength(17)]
        [MaxLength(17)]
        public string Vin { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Year { get; set; }

        [Required]
        public decimal CurrentValue { get; set; }

        [Required]
        public int AnnualMileage { get; set; }

        [Required]
        public bool DaytimeRunningLights { get; set; }

        [Required]
        public bool AntilockBrakes { get; set; }

        [Required]
        public bool PassiveRestraints { get; set; }

        [Required]
        public bool AntiTheft { get; set; }

        [Required]
        public int DaysDrivenPerWeek { get; set; }

        [Required]
        public int MilesDrivenToWork { get; set; }

        [Required]
        public bool ReducedUsedDiscount { get; set; }

        [Required]
        public bool GarageAddressDifferentFromResidence { get; set; }

        [Required]
        public decimal QuoteMultiplier { get; set; }
        
        // Add relationships
        [Required]
        [ForeignKey("Driver")]
        public int PrimaryDriverId { get; set; }

        [Required]
        public List<Driver> Drivers { get; set; }
    }
}
