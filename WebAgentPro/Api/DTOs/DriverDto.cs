using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.DTOs
{
    public class DriverDto
    {

        public int DriverID { get; set; }

        public string DriverFName { get; set; }

        public string DriverLName { get; set; }

        public string DriverSSN { get; set; }

        
        public string DriverLicenseNumber { get; set; }

        public string DriverLicenseState { get; set; }

        
        public DateTime DriverDOB { get; set; }

        
        public bool SafeDrivingSchool { get; set; }

        
        public decimal QuoteMultiplier { get; set; }

        public int QuoteID { get; set; }

        //public List<Vehicle> Vehicles { get; set; }
    }
}
