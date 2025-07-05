using ExamOOP.Interfaces;
using ExamOOP.HELPERS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Models
{
    public abstract class Car : IVehicle, IRentable
    {
        private int id;
        private string make;
        private string model;
        private int year;
        private string type;
        private string availability; // Assuming availability is a string that can be "Available" or "Rented"
        private string currentRenter;
        public Car(int id, string make, string model, int year, string type, string availability, string currentRenter)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Availability = availability.ToLower();
            this.CurrentRenter = currentRenter;

        }
        public Car(int id, string make, string model, int year, string type, string availability)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Availability = availability.ToLower();

        }
        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value<=0)
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
                else if (value!="rented" || value != "available")
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Type cannot be null or empty.");
                }
                else
                {
                    this.type = value;
                }
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Type cannot be null or empty.");
                }
                else
                {
                    this.currentRenter = value;
                }
            }
        }






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
            bool isRented = this.IsRented();
            if (isRented)
            {
            Console.WriteLine($"{Id}: {Year} {Make} {Model} - {this.GetType().ToString()} - {Availability} - {CurrentRenter}");

            }
            else
            {
                Console.WriteLine($"{Id}: {Year} {Make} {Model} - {this.GetType().ToString()} - {Availability}");
            }
        }

        public void RentCar(int id, DateTime rentalDate, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void ReturnCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
