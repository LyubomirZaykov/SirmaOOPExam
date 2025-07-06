using ExamOOP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Services
{
    public class VehicleGenerator
    {
        public IVehicle GenerateVehicle(string[] tokens)
        {
            IVehicle vehicle = null;
            int id = int.Parse(tokens[0]);
            string make = tokens[1];
            string model = tokens[2];
            int year = int.Parse(tokens[3]);
            string type = tokens[4];
            string availability = tokens[5].ToLower();
            string currentRenter = "";
            if (availability == "available")
            {
                currentRenter = "";
            }
            else
            {
                if (tokens.Length < 7)
                {
                    throw new ArgumentException("Current renter cannot be empty when the vehicle is not available.");
                }
                currentRenter = tokens[6];
                
            }

            switch (type.ToLower())
            {
                case "hatchback":
                    vehicle = new Models.Hatchback(id, make, model, year, type, availability, currentRenter);
                    break;
                case "truck":
                    vehicle = new Models.Truck(id, make, model, year, type, availability, currentRenter);
                    break;
                case "suv":
                    vehicle = new Models.Suv(id, make, model, year, type, availability, currentRenter);
                    break;
                case "sedan":
                    vehicle = new Models.Sedan(id, make, model, year, type, availability, currentRenter);
                    break;
                case "van":
                    vehicle = new Models.Van(id, make, model, year, type, availability, currentRenter);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
            return vehicle;
        }
    }
}
