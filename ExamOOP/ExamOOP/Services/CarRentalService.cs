using ExamOOP.Models;
using ExamOOP.Interfaces;

namespace ExamOOP.Services
{
//    public class CarRentalService : IRentable, ISearchable
//    {
//        private List<Car> cars;

//        public CarRentalService(List<Car> cars)
//        {
//            this.cars = cars;
//        }

//        public void AddCar(Car car) => cars.Add(car);

//        public void EditCar(int id, Car updated)
//        {
//            var index = cars.FindIndex(c => c.Id == id);
//            if (index >= 0) cars[index] = updated;
//        }

//        public void RemoveCar(int id)
//        {
//            var car = SearchById(id);
//            if (car != null) car.Status = "Removed";
//        }

//        public List<Car> ListCars() => cars;

//        public void RentCar(int id, string name, string customerId, DateTime rentalDate)
//        {
//            var car = SearchById(id);
//            if (car != null && car.Status == "Available")
//            {
//                car.Status = "Rented";
//                car.CurrentRenter = name;
//            }
//        }

//        public void ReturnCar(int id)
//        {
//            var car = SearchById(id);
//            if (car != null && car.Status == "Rented")
//            {
//                car.Status = "Available";
//                car.CurrentRenter = "";
//            }
//        }

//        public Car SearchById(int id) => cars.FirstOrDefault(c => c.Id == id);

//        public List<Car> SearchByModel(string model) =>
//            cars.Where(c => c.Model.ToLower().Contains(model.ToLower())).ToList();

//        public List<Car> SearchByStatus(string status) =>
//            cars.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
//    }
}