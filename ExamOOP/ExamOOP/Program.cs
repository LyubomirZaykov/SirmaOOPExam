using CarRentalSystem.Services;
using ExamOOP.Interfaces;
using ExamOOP.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        
        CarFileReader reader = new CarFileReader("D:\\engineering\\programming\\C#\\SirmaOOPExam\\ExamOOP\\ExamOOP\\input.csv");
        CarFileWriter writer = new CarFileWriter("D:\\engineering\\programming\\C#\\SirmaOOPExam\\ExamOOP\\ExamOOP\\input.csv");
        List<IVehicle> vehicles = reader.ReadCars();
        RentalManager manager = new RentalManager(vehicles);
        ConsoleReader consoleReader = new ConsoleReader(manager);
        Console.WriteLine("Welcome to the Car Rental System!");
        Console.WriteLine("Commands: add, rent, return, list, search, remove, save");

        bool running = true;
        while (running)
        {
            Console.Write("\n> ");
            string command = Console.ReadLine();
            running = consoleReader.Execute(command);
        }

        //writer.WriteCars(service.ListCars());
        //Console.WriteLine("Data saved. Goodbye!");
    }
}