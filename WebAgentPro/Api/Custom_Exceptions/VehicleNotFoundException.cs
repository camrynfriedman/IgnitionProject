using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro.Api
{
    public class VehicleNotFoundException:Exception
    {
        public VehicleNotFoundException(string message) : base(message)
        {

        }
    }
}
