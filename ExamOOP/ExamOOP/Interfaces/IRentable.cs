using ExamOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Interfaces
{
    public interface IRentable //Interface for items (cars) that can be rented
    {
        void RentCar(int id, DateTime rentalDate, Customer customer);
        void ReturnCar(int id);
    }
}
