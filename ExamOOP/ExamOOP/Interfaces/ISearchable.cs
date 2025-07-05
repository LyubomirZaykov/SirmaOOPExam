
using ExamOOP.Models;

namespace ExamOOP.Interfaces
{
    public  interface ISearchable
    {
        IVehicle SearchById(int id);  //Interface for searching cars by various criteria
        IVehicle SearchByModel(string model);
        IVehicle SearchByStatus(string status);
    }
}
