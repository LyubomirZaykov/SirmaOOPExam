using ExamOOP.Interfaces;
using ExamOOP.Models;

namespace CarRentalSystem.Services
{
    public class CarFileWriter
    {
        private string path;

        public CarFileWriter(string path)
        {
            this.path = path;
        }

        public void WriteCars(List<IVehicle> vehicles)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Id,Make,Model,Year,Type,Status,CurrentRenter");
                foreach (var veh in vehicles)
                {
                    writer.WriteLine(veh.ToString());
                }
            }
        }
    }
}