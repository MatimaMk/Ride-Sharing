using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Sharing.Entities
{
    internal class RideRequest
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public int PassengerId { get; set; }
        public bool IsAccepted { get; set; }

        public RideRequest(int id, string pickup, string dropoff, int passengerId, int distanceKms)
        {
            Id = id;
            PickupLocation = pickup;
            DropOffLocation = dropoff;
            PassengerId = passengerId;
            IsAccepted = false;
        }

    }
}
