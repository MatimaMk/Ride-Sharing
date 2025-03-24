using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Sharing.Intafaces
{
    internal interface IPayable
    {
       public  void RequestRide(string pickup, string dropoff,int distance);
        public void AcceptRide();
    }
}
