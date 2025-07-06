using ExamOOP.Interfaces;
using ExamOOP.Models;
using System.Reflection;

namespace ExamOOP.Services
{
    public class RentalManager : IRentable, ISearchable
    {
        private List<IVehicle> cars;
        private List<ICustomer> customers;
        private List<IRental> rentals;

        public RentalManager(List<IVehicle> vehicles)
        {
            this.cars = vehicles;
            customers = new List<ICustomer>();
            rentals = new List<IRental>();
        }
        public void AddCar(IVehicle car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }
            cars.Add(car);
        }
        public void AddCustomer(ICustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }
            customers.Add(customer);
        }
        public void EditCar(IVehicle car)
        {
            IVehicle? currCar = cars.FirstOrDefault(c => c.Id == car.Id);
            if (currCar == null)
            {
                throw new ArgumentException("Car not found.");
            }
            Console.WriteLine("Please enter the details of the car in order to be edited:");
            Console.WriteLine("1. Please enter the Make:");
            string? make = Console.ReadLine();
            Console.WriteLine("2. Please enter the Model");
            string? model = Console.ReadLine();
            Console.WriteLine("3. Please enter the Year");
            int year = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("4. Please enter the Type");
            string? type = Console.ReadLine();

            currCar.ActualizeCar(make, model, year, type);

        }
        public List<IVehicle> ListCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
            }
            return cars;
        }
        public void RentCar(string customer, int carId)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                Console.WriteLine("Please choose another car");
                return;
            }
            if (car.Availability != "available")
            {
                Console.WriteLine("Car is not available for rent.");
                Console.WriteLine("Please choose another car");
                return;
            }

            ICustomer? currCustomer = customers.FirstOrDefault(c => c.Name == customer);
            if (currCustomer == null)
            {
                currCustomer = new Customer(customer);
                customers.Add(currCustomer);
            }
            //DateOnly rentalDate = DateOnly.FromDateTime(DateTime.Now);
            //DateOnly returnDate = rentalDate.AddDays(7); // Assuming a 7-day rental period

            IRental rental = new Rental(car, currCustomer);
            rentals.Add(rental);
            Console.WriteLine($"Car {car.Make} {car.Model} rented to {currCustomer.Name}.");
            car.ChangeAvailability("rented", customer); // Mark the car as rented
        }


        public void ReturnCar(int carId)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                Console.WriteLine("There is no such car that is rented");
                return;
            }
            IRental? rental = rentals.FirstOrDefault(r => r.Vehicle.Id == carId);
            //DateOnly returnDate = rental.ReturnDate; //This  cause problems if we have rented car in the beginning, which are read from  to .csv file, which don't have return date and dont exist in current rentals.
            //DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now); //I can solve it by saving rentals also in .csv file and initally all the cars to be available, but I don't want to complicate the code too much for the moment. I will comment
            rentals.Remove(rental);
            Console.WriteLine("Succesfully returned car.");
            car.ChangeAvailability("available", "");
            // Remove the rental record
            //if (returnDate>currentDate)
            //{
            //    Console.WriteLine("Succesfully returned car.");
            //    car.ChangeAvailability("available",""); // Mark the car as available
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine($"You missed the return date. You must pay {HELPERS.Helper.DELAYED_CAR_FINE}lv fine.");
            //    Console.WriteLine("Succesfully returned car.");

            //    car.ChangeAvailability("available",""); // Mark the car as available
            //    return;
            //}
        }

        public IVehicle SearchById(int id)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Id == id);

            return car;
        }

        public List<IVehicle> SearchByModel(string model)
        {
            List<IVehicle> vehicles = cars.Where(v=>v.Model==model).ToList();

            return vehicles;

        }

        public List<IVehicle> SearchByStatus(string status)
        {
            List<IVehicle> vehicles = cars.Where(v => v.Availability == status).ToList();

            return vehicles;
        }

        public void RemoveCar(int id)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                cars.Remove(cars.FirstOrDefault(c => c.Id == id));
                Console.WriteLine($"Successfully removed car with ID: {id}");
            }
            else
            {
                Console.WriteLine($"Car with ID: {id} not found.");
            }
        }
    }
}
