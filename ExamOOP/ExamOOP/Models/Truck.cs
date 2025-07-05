using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Models
{
    public class Truck : Car
    {
        public Truck(int id, string make, string model, int year, string type, string availability, string currentRenter)
            : base(id, make, model, year, type, availability, currentRenter)
        {
        }
        public Truck(int id, string make, string model, int year, string type, string availability)
            : base(id, make, model, year, type, availability)
        {
        }
    }
    
}
