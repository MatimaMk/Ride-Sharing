using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Sharing.Entities
{

    // A Driver sub class, inheriting frm the User class as the parent class
    internal class Driver : User
    {
        public decimal Earnings { get; private set; } = 0;

        public Driver(string name, string email) : base(name, email) { }

        public override void ShowMenu(List<RideRequest> rideRequests, List<User> users)
        {
            while (true)
            {
                Console.WriteLine("\nDriver Menu:");
                Console.WriteLine("1. View Available Rides");
                Console.WriteLine("2. Accept a Ride");
                Console.WriteLine("3. Complete a Ride");
                Console.WriteLine("4. View Earnings");
                Console.WriteLine("5. Logout");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAvailableRides(rideRequests);
                        break;
                    case "2":
                        AcceptRide(rideRequests);
                        break;
                    case "3":
                        CompleteRide(rideRequests);
                        break;
                    case "4":
                        ViewEarnings();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        public void ViewAvailableRides(List<RideRequest> rideRequests)
        {
            try
            {
                var availableRides = from ride in rideRequests
                                     where !ride.IsAccepted
                                     select ride;

                if (!availableRides.Any())
                {
                    Console.WriteLine("No available rides.");
                    return;
                }

                Console.WriteLine("Available Rides:");
                foreach (var ride in availableRides)
                {
                    Console.WriteLine($"Ride ID: {ride.Id}, Pickup: {ride.PickupLocation}, Drop-off: {ride.DropOffLocation}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not view available drivers, try again!!!");
            }
        }

        public void AcceptRide(List<RideRequest> rideRequests)
        {
            // LINQ query to find the first available ride
            var rideToAccept = (from ride in rideRequests
                                where !ride.IsAccepted
                                select ride).FirstOrDefault();

            if (rideToAccept == null)
            {
                Console.WriteLine("No available rides.");
                return;
            }

            rideToAccept.IsAccepted = true;
            Console.WriteLine($"Ride {rideToAccept.Id} accepted!");
        }

        public void CompleteRide(List<RideRequest> rideRequests)
        {

            var rideToComplete = (from ride in rideRequests
                                  where ride.IsAccepted
                                  select ride).FirstOrDefault();

            // Random distance between 1 and 50 km for the entered locations
            Random random = new Random();
            int distance = random.Next(1, 51);

            if (distance <= 10)
            {
                Earnings = 30;
            }
            else if (distance <= 20)
            {
                Earnings = 45;
            }
            else
            {
                Earnings = 65;

            }
            if (rideToComplete == null)
            {
                Console.WriteLine("No accepted rides to complete.");
                return;
            }

            // Removing completed ride from the list by the driver
            int numCompletedRides = 0;

            while (rideRequests.Remove(rideToComplete))
            {
                numCompletedRides++;
            }
            Console.WriteLine($"Ride {rideToComplete.Id} completed successfully! You earned R{Earnings} credits.");
            Console.WriteLine($"Total Rides completed: {numCompletedRides}");
            Earnings += Earnings;

        }

        public void ViewEarnings()
        {
            Console.WriteLine($"Total Earnings: R{Earnings} credits.");
        }
    }

}

