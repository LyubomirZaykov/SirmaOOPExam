
using ExamOOP.Interfaces;

namespace ExamOOP.Services
{

    public class ConsoleReader
    {
        private VehicleGenerator vehicleGenerator;
        private RentalManager manager;
        public ConsoleReader(RentalManager manager)
        {
            this.manager = manager;
            vehicleGenerator = new VehicleGenerator();
        }
        public bool Execute(string command)
        {
            var parts = command.Split(' ', 2);
            string action = parts[0].ToLower();

            try
            {
                switch (action)
                {
                    case "add":
                        Console.WriteLine("Enter: ID,Make,Model,Year,Type, Availability, Renter(if rented)");
                        string[] values = Console.ReadLine().Split(',').ToArray();
                        IVehicle vehicle = vehicleGenerator.GenerateVehicle(values);
                        manager.AddCar(vehicle);
                        break;

                    case "rent":
                        Console.Write("Car ID: ");
                        int carId = int.Parse(Console.ReadLine());
                        Console.Write("Customer Name: ");
                        string custName = Console.ReadLine();
                        manager.RentCar(custName,carId);
                        break;

                    case "return":
                        Console.Write("Car ID: ");
                        manager.ReturnCar(int.Parse(Console.ReadLine()));
                        break;

                    case "list":
                        foreach (IVehicle veh in manager.ListCars())
                            veh.DisplayInfo();
                        break;

                    case "search":
                        Console.WriteLine("By which criteria you would like to search: 1.Id ; 2.Model; 3. Status ( rented/available)");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.Write("Car ID: ");
                                int id = int.Parse(Console.ReadLine());
                                IVehicle car = manager.SearchById(id);
                                if (car != null)
                                    car.DisplayInfo();
                                else
                                    Console.WriteLine("Car not found.");                       
                                break;
                            case "2":
                                Console.Write("Car Model: ");
                                string model = Console.ReadLine();
                                List<IVehicle> vehicles = manager.SearchByModel(model);
                                if (vehicles != null)
                                {
                                    foreach (IVehicle veh in vehicles)
                                        veh.DisplayInfo();
                                }
                                else
                                {
                                    Console.WriteLine($"There are no cars from model {model}");
                                }
                                break;
                            case "3":
                                Console.Write("Car status: ");
                                string status = Console.ReadLine();
                                vehicles = manager.SearchByStatus(status);
                                if (vehicles != null)
                                {
                                    foreach (IVehicle veh in vehicles)
                                        veh.DisplayInfo();
                                }
                                else
                                {
                                    Console.WriteLine($"There are no cars that are {status}");

                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "remove":
                        Console.Write("Car ID to remove: ");
                        manager.RemoveCar(int.Parse(Console.ReadLine()));
                        break;

                    case "save":
                        return false;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return true;
        }
    }
}
