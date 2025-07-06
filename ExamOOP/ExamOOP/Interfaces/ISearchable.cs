
using ExamOOP.Models;

namespace ExamOOP.Interfaces
{
    public  interface ISearchable
    {
        IVehicle SearchById(int id);  //Interface for searching cars by various criteria
        List<IVehicle> SearchByModel(string model);
        List<IVehicle> SearchByStatus(string status);
    }
}
