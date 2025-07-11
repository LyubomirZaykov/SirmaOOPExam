﻿using ExamOOP.Interfaces;
using ExamOOP.HELPERS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace ExamOOP.Models
{
    public abstract class Car : IVehicle
    {
        private int id;
        private string? make;
        private string? model;
        private int year;
        private string? type;
        private string? availability; // Assuming availability is a string that can be "Available" or "Rented"
        private string currentRenter; // Assuming CurrentRenter is a string that can be empty if no one has rented the car.

        public Car(int id, string make, string model, int year, string type, string availability, string currentRenter)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Availability = availability.ToLower();
            this.Type = type.ToLower(); // Assuming Type is a string that can be "Hatchback", "Truck", "SUV", "Sedan", or "Van"
            if (!string.IsNullOrEmpty(currentRenter))
            {
                this.CurrentRenter = currentRenter;
            }

        }
        public int Id // I am not sure what we mean by that, but I Assume it is unique 4-digit number for each car.
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be negative.");
                }
                else
                {
                    this.id = value;
                }
            }
        }
        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Make cannot be null or empty.");
                }
                else
                {
                    this.make = value;
                }
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Make cannot be null or empty.");
                }
                else
                {
                    this.model = value;
                }
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value <= 1970)
                {
                    throw new ArgumentException("Year of the vehicle cannot be less than 1970.");
                }
                else if (value > Helper.CURRENT_YEAR)
                {
                    throw new ArgumentException("Year of the vehicle cannot be greater than current year.");
                }
                else
                {
                    this.year = value;
                }
            }
        }
        public string Availability
        {
            get
            {
                return this.availability;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Make cannot be null or empty.");
                }
                else if (value != "rented" && value != "available")
                {
                    throw new ArgumentNullException("Availability status must be either rented or available.");

                }
                else
                {
                    this.availability = value;
                }
            }
        }




        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type=this.GetType().Name;
            }
        }
        public string CurrentRenter
        {
            get
            {
                return this.currentRenter;
            }
            private set
            {
                this.currentRenter = value;
            }
        } // Assuming CurrentRenter is a string that can be empty if no one has rented the car.
        // Assuming true means available, false means rented out and Initially all cars are available.
        public bool IsRented()
        {
            if (this.Availability == "rented")
            {
                return true; // Car is rented out
            }
            else
            {
                return false; // Car is available
            }
        }
        public void DisplayInfo()
        {
            if (string.IsNullOrEmpty(currentRenter))
            {
                Console.WriteLine($"{Id}: {Year} {Make} {Model} - {Type} - {Availability}");
            }
            else
            {
                Console.WriteLine($"{Id}: {Year} {Make} {Model} - {Type} - {Availability} - {currentRenter}");

            }

        }

        public void ChangeAvailability(string availability, string currentRenterName)
        {
            
            if (string.IsNullOrEmpty(availability) || (availability != "available" && availability != "rented"))
            {
                throw new ArgumentException("Availability must be either 'available' or 'rented'.");
            }
            this.Availability = availability.ToLower();
            if (this.availability == "rented")
            {
                this.CurrentRenter = currentRenterName;
            }
            else
            {
                this.CurrentRenter = "";
            }
        }
        public void ActualizeCar(string? make, string? model, int year, string? type)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Type = type;
        }
        public override string ToString()
        {
            return $"{Id},{Make},{Model},{Year},{Type},{Availability},{CurrentRenter}";
        }
    }
}
