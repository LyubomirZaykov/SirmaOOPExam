
using ExamOOP.Interfaces;

namespace ExamOOP.Services
{
    public class InputCommandsManager
    {
        private List<IVehicle> vehicles;
        public InputCommandsManager(List<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException(nameof(vehicles), "Vehicles list cannot be null.");
            }
            this.vehicles = vehicles;
        }
        public List<IVehicle> GetVehicles()
        {
            if (this.vehicles.Count == 0)
            {
                throw new InvalidOperationException("No vehicles available.");
            }
            return this.vehicles;
        }

    }
}
