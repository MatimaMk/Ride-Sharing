using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Sharing.Intafaces
{
    internal interface IRideable
    {
        public void ProcessPayment(decimal amount);
    }
}
