using CarRentalSystem.Services;
using ExamOOP.Interfaces;
using ExamOOP.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "D:\\engineering\\programming\\C#\\SirmaOOPExam\\ExamOOP\\ExamOOP\\cars.csv";
        CarFileReader reader = new CarFileReader(filePath);
        CarFileWriter writer = new CarFileWriter(filePath);
        List<IVehicle> vehicles = reader.ReadCars();
        RentalManager manager = new RentalManager(vehicles);
        ConsoleReader consoleReader = new ConsoleReader(manager);
        Console.WriteLine("Welcome to the Car Rental System!");
        

        bool running = true;
        while (running)
        {
            Console.Write("\n> ");
            Console.WriteLine("Commands: add, rent, return, list, search, remove, save");
            Console.Write("\n> ");
            string command = Console.ReadLine();
            running = consoleReader.Execute(command);
        }

        writer.WriteCars(manager.ListCars());
        Console.WriteLine("Data saved. Goodbye!");
    }
}