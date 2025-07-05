using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Models
{
    public class Van : Car
    {
        
        public Van(int id, string make, string model, int year, string type, string availability, string currentRenter)
            : base(id, make, model, year, type, availability, currentRenter)
        {
        }
    }
    
}
