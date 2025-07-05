using ExamOOP.Models;

namespace ExamOOP.Services
{
    //public class RentalManager
    //{
    //    private CarRentalService service;

    //    public RentalManager(CarRentalService service)
    //    {
    //        this.service = service;
    //    }

    //    public bool Execute(string command)
    //    {
    //        var parts = command.Split(' ', 2);
    //        string action = parts[0].ToLower();

    //        try
    //        {
    //            switch (action)
    //            {
    //                case "add":
    //                    Console.WriteLine("Enter: ID,Make,Model,Year,Type");
    //                    var values = Console.ReadLine().Split(',');
    //                    var car = new Car
    //                    {
    //                        Id = int.Parse(values[0]),
    //                        Make = values[1],
    //                        Model = values[2],
    //                        Year = int.Parse(values[3]),
    //                        Type = values[4],
    //                        Status = "Available"
    //                    };
    //                    service.AddCar(car);
    //                    break;

    //                case "rent":
    //                    Console.Write("Car ID: ");
    //                    int id = int.Parse(Console.ReadLine());
    //                    Console.Write("Customer Name: ");
    //                    string name = Console.ReadLine();
    //                    Console.Write("Customer ID: ");
    //                    string custId = Console.ReadLine();
    //                    service.RentCar(id, name, custId, DateTime.Now);
    //                    break;

    //                case "return":
    //                    Console.Write("Car ID: ");
    //                    service.ReturnCar(int.Parse(Console.ReadLine()));
    //                    break;

    //                case "list":
    //                    foreach (var c in service.ListCars())
    //                        c.DisplayInfo();
    //                    break;

    //                case "search":
    //                    Console.Write("Search by model/status: ");
    //                    var arg = Console.ReadLine();
    //                    var result = service.SearchByModel(arg);
    //                    if (!result.Any()) result = service.SearchByStatus(arg);
    //                    foreach (var carR in result)
    //                        carR.DisplayInfo();
    //                    break;

    //                case "remove":
    //                    Console.Write("Car ID to remove: ");
    //                    service.RemoveCar(int.Parse(Console.ReadLine()));
    //                    break;

    //                case "save":
    //                    return false;

    //                default:
    //                    Console.WriteLine("Unknown command.");
    //                    break;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Error: " + e.Message);
    //        }

    //        return true;
    //    }
    //}
}