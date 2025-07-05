using ExamOOP.Interfaces;
using ExamOOP.Models;
using ExamOOP.Services;

namespace CarRentalSystem.Services
{
    public class CarFileReader
    {
        private string path;
        private VehicleGenerator vehicleGenerator;
        public CarFileReader(string path)
        {
            this.path = path;
            this.vehicleGenerator = new VehicleGenerator();
        }

        public List<IVehicle> ReadCars()
        {
            List<IVehicle> cars = new List<IVehicle>();
            if (!File.Exists(path)) return cars;

            using (var reader = new StreamReader(path))
            {
                reader.ReadLine(); // skip header
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';').ToArray();
                    IVehicle vehicle = vehicleGenerator.GenerateVehicle(parts);
                    cars.Add(vehicle);
                }
            }
            return cars;
        }
    }
}