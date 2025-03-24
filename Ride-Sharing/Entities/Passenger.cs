using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ride_Sharing.Entities
{
    // A passanger sub class, inheriting from the User class as the parent class
    class Passenger : User
    {
        public decimal WalletBalance { get; private set; } = 0;
        public List<string> RideHistory { get; private set; } = new List<string>();

        public Passenger(string name, string email) : base(name, email) { }

        public override void ShowMenu(List<RideRequest> rideRequests, List<User> users)
        {
            while (true)
            {
                Console.WriteLine("\nPassenger Menu:");
                Console.WriteLine("1. Request a Ride");
                Console.WriteLine("2. View Wallet Balance");
                Console.WriteLine("3. Add Funds to Wallet");
                Console.WriteLine("4. View Ride History");
                Console.WriteLine("5. Rate Driver");
                Console.WriteLine("6. Logout");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RequestRide(rideRequests, users);
                        break;
                    case "2":
                        Console.WriteLine($"Wallet Balance: {WalletBalance}");
                        break;
                    case "3":
                        AddFundsToWallet();
                        break;
                    case "4":
                        ViewRideHistory();
                        break;
                    case "5":
                        RateDriver(users);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void RequestRide(List<RideRequest> rideRequests, List<User> users)
        {
            if (WalletBalance < 20)
            {
                Console.WriteLine("Insufficient funds to request a ride.");
                return;
            }

            Console.Write("Enter Pickup Location: ");
            string pickup = Console.ReadLine();

            Console.Write("Enter Drop-off Location: ");
            string dropoff = Console.ReadLine();

            var driver = users.OfType<Driver>().FirstOrDefault();
            if (driver == null)
            {
                Console.WriteLine("No available drivers at the moment.");
                return;
            }

            // Random distance between 1 and 50 km for the entered locations
            Random random = new Random();
            int distance = random.Next(1, 51);

            RideRequest request = new RideRequest(rideRequests.Count + 1, pickup, dropoff, this.Id, distance);
            rideRequests.Add(request);

            RideHistory.Add($"Ride ID: {request.Id}, Pickup: {pickup}, Drop-off: {dropoff}, Distance: {distance} km");
            Console.WriteLine($"Ride request submitted! Estimated distance: {distance} km. Driver {driver.Name} might accept your ride.");
        }

        private void AddFundsToWallet()
        {
            try
            {
                Console.Write("Enter amount to add: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    WalletBalance += amount;
                    Console.WriteLine($"Successfully added {amount} to Wallet.\nNew Wallet Balance: {WalletBalance}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid amount,sorry could not add funds, Please try again.");
            }
        }

        private void ViewRideHistory()
        {
            if (RideHistory.Count == 0)
            {
                Console.WriteLine("No rides taken yet.");
                return;
            }

            Console.WriteLine("Ride History:");
            foreach (var ride in RideHistory)
            {
                Console.WriteLine(ride);
            }
        }

        private void RateDriver(List<User> users)
        {
            var drivers = users.OfType<Driver>().ToList();
            if (!drivers.Any())
            {
                Console.WriteLine("No drivers to rate.");
                return;
            }

            Console.WriteLine("Available Drivers to Rate:");
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Driver ID: {driver.Id}, Name: {driver.Name}");
            }

            Console.Write("Enter Driver ID to rate: ");
            if (int.TryParse(Console.ReadLine(), out int driverId))
            {
                var driver = drivers.FirstOrDefault(d => d.Id == driverId);
                if (driver != null)
                {
                    Console.Write("Enter a rating (1-5): ");
                    if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                    {
                        Console.WriteLine($"Thank you for rating Driver {driver.Name} with a {rating}!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Driver not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Driver ID.");
            }
        }
    }

}

