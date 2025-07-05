using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP.Interfaces
{
    public interface IVehicle
    {
        int Id { get; }
        string Make { get; }
        string Model { get; }
        int Year { get; }
        string Type { get; }
        bool Availability { get; }
        string CurrentRenter { get;}

        void DisplayInfo();
    }
}
