using System;
using System.Collections.Generic;
using System.Linq;
using Ride_Sharing.Entities;

namespace Ride_Sharing
{
    internal class Program
    {
        static List<User> users = new List<User>();
        static List<RideRequest> rideRequests = new List<RideRequest>();
        static UserManager userManager = new UserManager(users, rideRequests);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nRide-Sharing System");
                Console.WriteLine("1. Register as Passenger");
                Console.WriteLine("2. Register as Driver");
                Console.WriteLine("3. Login");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        userManager.RegisterUser("Passenger");
                        break;
                    case "2":
                        userManager.RegisterUser("Driver");
                        break;
                    case "3":
                        userManager.Login();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}

