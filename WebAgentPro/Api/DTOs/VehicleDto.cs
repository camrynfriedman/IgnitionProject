using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api.DTOs
{

    public class VehicleDto
    {

        
        public int VehicleId { get; set; }

        
        public string Vin { get; set; }

        
        public string Make { get; set; }

        
        public string Model { get; set; }

        

        public int Year { get; set; }

        
        public decimal CurrentValue { get; set; }

        
        public int AnnualMileage { get; set; }

        
        public bool DaytimeRunningLights { get; set; }

        
        public bool AntilockBrakes { get; set; }

        
        public bool PassiveRestraints { get; set; }

        
        public bool AntiTheft { get; set; }

        
        public int DaysDrivenPerWeek { get; set; }

        
        public int MilesDrivenToWork { get; set; }

        
        public bool ReducedUsedDiscount { get; set; }

        
        public bool GarageAddressDifferentFromResidence { get; set; }

        
        public decimal QuoteMultiplier { get; set; }

        
        public int PrimaryDriverId { get; set; }

        //Vehicles will no longer have multiple Drivers assigned to it
/*        public List<int> DriversIDs { get; set; }*/
    }
}
