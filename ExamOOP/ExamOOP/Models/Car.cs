using ExamOOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Models
{
    public class Car : IVehicle, IRentable
    {
        private int id;
        private string make;
        private string model;
        private int year;
        private string type;
        public Car(int id, string make, string model, int year, string type, string status, string currentRenter)
        {
         this.Id = id;
            this.Make = make;

        }
        public int Id { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Type { get; private set; }
        public bool Availability { get; private set; } = true; // Assuming true means available, false means rented out and Initially all cars are available.
        public string CurrentRenter { get; private set; } = "";

        //public override string ToString() //Not sure if this is needed, but it can be used to return a string representation of the car object
        //{
        //    return $"{Id},{Make},{Model},{Year},{Type},{Status},{CurrentRenter}";
        //}

        public void DisplayInfo()
        {
            Console.WriteLine($"{Id}: {Year} {Make} {Model} - {Type} - {Status} - {CurrentRenter}");
        }

        public void RentCar(int id, DateTime rentalDate, string customerName, string customerId)
        {
            throw new NotImplementedException();
        }

        public void ReturnCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
