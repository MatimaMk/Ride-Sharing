using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride_Sharing.Entities;

namespace Ride_Sharing
{
    // This s the user Manager class with static method methods to register user and login
    internal class UserManager
    {
        private List<User> users;
        private List<RideRequest> rideRequests;

        public UserManager(List<User> users, List<RideRequest> rideRequests)
        {
            this.users = users;
            this.rideRequests = rideRequests;
        }
        public void RegisterUser(string role)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            User user = role == "Passenger" ? new Passenger(name, email) : new Driver(name, email);
            users.Add(user);
            Console.WriteLine($"{role} registered successfully! {role}ID: {user.Id}\nEmail: {email}");
            Console.WriteLine();
        }

        public void Login()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            User user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user != null)
            {
                Console.Write("Enter your User ID: ");
                if (int.TryParse(Console.ReadLine(), out int id) && user.Id == id)
                {
                    user.ShowMenu(rideRequests, users);
                }
                else
                {
                    Console.WriteLine("Invalid User ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Email not found. Please Register.");
            }
        }


    }
}
