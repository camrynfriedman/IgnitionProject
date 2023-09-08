using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgentPro
{
    public class DiscountException:Exception
    {
        public DiscountException(string message) : base(message) { 
            
        }
    }
}
