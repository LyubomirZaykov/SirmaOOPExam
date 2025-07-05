using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Models
{
    public class Sedan : Car
    {
        public Sedan(int id, string make, string model, int year, string type, string status, string currentRenter) : base(id, make, model, year, type, status, currentRenter)
        {
        }
    }
}
