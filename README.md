# Ride-Sharing
# 🚖 Ride-Sharing System

## 📋 Project Overview
The **Ride-Sharing System** is a C# Console Application designed to facilitate seamless interactions between passengers, drivers, and administrators. The system uses object-oriented programming principles including inheritance, polymorphism, interfaces, LINQ, and exception handling to ensure functionality.

## ✨ Features
### 1. Core Functionalities

- **👥 User Manager**
  - Users can register as drivers or passengers.
  - users can login and logout using the email and the ID.

- **🚗 Ride Request section**
  - Passengers can request rides, specifying their pickup and drop-off locations ,and distance will be randomized on the the locations.
  - available drivers can accept ride requests.

- **💳 Payment section**
   - Passengers have  wallets with a starting balance of 0, must add funds to the wallet before requesting a ride.
  - Requests are denied if a passenger lacks sufficient balance, with a standard ride cost is R20. any wallet with less than R20 wont request.
  - Calculates ride cost based on distance (randomized distance).
  - Fares are deducted from the passenger's wallet and credited to the driver's earnings after ride completion (completion of ride by the driver).

- **⭐ Rating System**
  - Passengers can rate drivers after ride is completed.

- **⚠️ Exception Handling**
  - Handles errors such as insufficient balance, unavailability of drivers, and invalid ride requests.

### 2. User Interaction (Console-Based)
- Menu-driven system for text-based input.

#### Main Menu:
- **📝 Register as Passenger**
- **📝 Register as Driver**
- **🔑 Login**
- **❌ Exit**

#### Passenger Menu:
- 🚕 Request a Ride  
- 💰 View Wallet Balance  
- ➕ Add Funds to Wallet  
- 📜 View Ride History  
- ⭐ Rate a Driver  
- 🔓 Logout  

#### Driver Menu:
- 🛠️ View Available Ride Requests  
- ✅ Accept a Ride  
- 🎯 Complete a Ride  
- 💵 View Earnings  
- 🔓 Logout  

## 💻 Technologies Used
- **Language:** C#  
- **Development Environment:** Visual Studio 

## 🚀 How to Run
1. Clone the repository or download the source code.
2. Open the project in Visual Studio.
3. Build and run the application.
4. Interact with the system through the console menus.
