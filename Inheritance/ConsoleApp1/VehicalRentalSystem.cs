using System;

namespace VehicleRentalSystem
{
    // Encapsulation: Base class for Vehicle
    public abstract class Vehicle : IVehicleRental
    {
        protected string VehicleName { get; set; }
        protected string RegistrationNumber { get; set; }
        protected double PricePerDay { get; set; }

        // Constructor to initialize a vehicle
        protected Vehicle(string vehicleName, string registrationNumber, double pricePerDay)
        {
            VehicleName = vehicleName;
            RegistrationNumber = registrationNumber;
            PricePerDay = pricePerDay;
        }

        // Abstract methods to be implemented by derived classes
        public abstract double CalculateRentalPrice(int daysRented);
        public abstract void DisplayVehicleDetails();
    }

    // Interface: Rentable vehicles should implement this
    public interface IVehicleRental
    {
        double CalculateRentalPrice(int daysRented);
        void DisplayVehicleDetails();
    }

    // Concrete class for Car
    public class Car : Vehicle
    {
        public Car(string vehicleName, string registrationNumber, double pricePerDay)
            : base(vehicleName, registrationNumber, pricePerDay)
        { }

        // Polymorphism: Override CalculateRentalPrice for Car
        public override double CalculateRentalPrice(int daysRented)
        {
            return PricePerDay * daysRented; // Simple daily rate for Car
        }

        // Display details specific to Car
        public override void DisplayVehicleDetails()
        {
            Console.WriteLine($"Car: {VehicleName}, Registration No: {RegistrationNumber}, Price/Day: {PricePerDay}");
        }
    }

    // Concrete class for Bike
    public class Bike : Vehicle
    {
        public Bike(string vehicleName, string registrationNumber, double pricePerDay)
            : base(vehicleName, registrationNumber, pricePerDay)
        { }

        // Polymorphism: Override CalculateRentalPrice for Bike
        public override double CalculateRentalPrice(int daysRented)
        {
            return PricePerDay * daysRented; // Simple daily rate for Bike
        }

        // Display details specific to Bike
        public override void DisplayVehicleDetails()
        {
            Console.WriteLine($"Bike: {VehicleName}, Registration No: {RegistrationNumber}, Price/Day: {PricePerDay}");
        }
    }

    // Concrete class for Truck
    public class Truck : Vehicle
    {
        private double LoadingFee { get; set; }

        public Truck(string vehicleName, string registrationNumber, double pricePerDay, double loadingFee)
            : base(vehicleName, registrationNumber, pricePerDay)
        {
            LoadingFee = loadingFee;
        }

        // Polymorphism: Override CalculateRentalPrice for Truck
        public override double CalculateRentalPrice(int daysRented)
        {
            return (PricePerDay * daysRented) + LoadingFee; // Truck has an additional loading fee
        }

        // Display details specific to Truck
        public override void DisplayVehicleDetails()
        {
            Console.WriteLine($"Truck: {VehicleName}, Registration No: {RegistrationNumber}, Price/Day: {PricePerDay}, Loading Fee: {LoadingFee}");
        }
    }

    // Abstract class to provide common vehicle details functionality
    public abstract class VehicleDetails
    {
        public abstract void DisplayDetails();
    }

    // Class to manage vehicle rentals
    public class VehicleRentalSystem
    {
        public void RentVehicle(Vehicle vehicle, int daysRented)
        {
            vehicle.DisplayVehicleDetails();
            double rentalPrice = vehicle.CalculateRentalPrice(daysRented);
            Console.WriteLine($"Total rental price for {daysRented} days: {rentalPrice:C}\n");
        }
    }

    // Main program to test the functionality
    class Program
    {
        static void Main()
        {
            // Create some vehicles
            Vehicle car = new Car("Toyota Corolla", "XYZ1234", 30);
            Vehicle bike = new Bike("Yamaha R15", "ABC5678", 15);
            Vehicle truck = new Truck("Ford F-150", "LMN9012", 50, 100);

            // Create rental system
            VehicleRentalSystem rentalSystem = new VehicleRentalSystem();

            // Rent vehicles for 5 days
            rentalSystem.RentVehicle(car, 5);
            rentalSystem.RentVehicle(bike, 5);
            rentalSystem.RentVehicle(truck, 5);
        }
    }
}
