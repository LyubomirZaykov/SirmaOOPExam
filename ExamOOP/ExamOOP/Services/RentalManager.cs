using ExamOOP.Interfaces;
using ExamOOP.Models;

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
            Console.WriteLine("5. Please enter the Availability");
            string? availability = Console.ReadLine();
            Console.WriteLine("6. Please enter the Current Renter");
            string? currentRenter = Console.ReadLine(); 
            currCar.ActualizeCar(make, model, year, type, availability);

        }
        public List<IVehicle> ListCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available."); 
            }
            return cars;
        }
        public void RentCar(string customer,int carId)
        {
            Console.WriteLine("Please enter the ID of the car you want to rent:");
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
            Console.WriteLine("Please enter your name:");
          
            ICustomer? currCustomer = customers.FirstOrDefault(c => c.Name == customer);
            if (customer == null)
            {
                Console.WriteLine("Customer not found. Please register first.");
                Console.WriteLine("Please enter customer name:");
                string customerName = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please enter customer Id:");
                int customerId = int.Parse(Console.ReadLine());
                currCustomer = new Customer(customerName, customerId);
                customers.Add(currCustomer);
            }
            DateOnly rentalDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly returnDate = rentalDate.AddDays(7); // Assuming a 7-day rental period
            IRental rental= new Rental(car, currCustomer,rentalDate,returnDate);
            rentals.Add(rental);
            Console.WriteLine($"Car {car.Make} {car.Model} rented to {currCustomer.Name}.");
            car.ChangeAvailability("rented",currCustomer.Name); // Mark the car as rented
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
            DateOnly returnDate = rental.ReturnDate;
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (returnDate>currentDate)
            {
                Console.WriteLine("Succesfully returned car.");
                car.ChangeAvailability("available",""); // Mark the car as available
                return;
            }
            else
            {
                Console.WriteLine($"You missed the return date. You must pay {HELPERS.Helper.DELAYED_CAR_FINE}lv fine.");
                Console.WriteLine("Succesfully returned car.");
                car.ChangeAvailability("available",""); // Mark the car as available
                return;
            }
        }

        public IVehicle SearchById(int id)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                throw new ArgumentException("No car found with the specified id.");
            }
            return car;
        }

        public IVehicle SearchByModel(string model)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Model == model);
            if (car == null)
            {
                throw new ArgumentException("No car found with the specified model.");
            }
            return car;

        }

        public IVehicle SearchByStatus(string status)
        {
            IVehicle? car = cars.FirstOrDefault(c => c.Availability == status);
            if (car == null)
            {
                throw new ArgumentException("No car found with the specified status.");
                
            }
            return car;
        }

    }
}
