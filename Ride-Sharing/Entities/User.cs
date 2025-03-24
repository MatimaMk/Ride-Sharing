using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Sharing.Entities
{
    // user class that is a parent class to two child classes (driver and passanger)
    abstract class User
    {
        private static int idCounter = 1;
        public int Id { get; }
        public string Name { get; }

        public string Email { get; }

        protected User(string name , string email)
        {
            Id = idCounter++;
            Name = name;
            Email = email;
        }

        public abstract void ShowMenu(List<RideRequest> rideRequests, List<User> users);


    }


}

