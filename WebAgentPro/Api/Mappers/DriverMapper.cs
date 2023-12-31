﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgentPro.Api.DTOs;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Api.Mappers
{
    public class DriverMapper
    {
        public DriverDto DriverToDto(Driver d)
        {
            DriverDto returnedDriver = new DriverDto
            {
                DriverID = d.DriverID,
                DriverFName = d.DriverFName,
                DriverLName = d.DriverLName,
                DriverSSN = d.DriverSSN,
                DriverLicenseNumber = d.DriverLicenseNumber,
                DriverLicenseState = d.DriverLicenseState,
                DriverDOB = d.DriverDOB,
                SafeDrivingSchool = d.SafeDrivingSchool,
                QuoteMultiplier = d.QuoteMultiplier,
                QuoteID = d.QuoteID,
                //Vehicles = d.Vehicles
            };
            return returnedDriver;
        }

        public Driver DtoToDriver(DriverDto d)
        {
            Driver returnedDriver = new Driver
            {
                DriverID = d.DriverID,
                DriverFName = d.DriverFName,
                DriverLName = d.DriverLName,
                DriverSSN = d.DriverSSN,
                DriverLicenseNumber = d.DriverLicenseNumber,
                DriverLicenseState = d.DriverLicenseState,
                DriverDOB = d.DriverDOB,
                SafeDrivingSchool = d.SafeDrivingSchool,
                QuoteMultiplier = d.QuoteMultiplier,
                QuoteID = d.QuoteID,
                //Vehicles = d.Vehicles
            };
            return returnedDriver;
        }


    }
}
