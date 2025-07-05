
using ExamOOP.Models;

namespace ExamOOP.Interfaces
{
    public  interface ISearchable
    {
        Car SearchById(int id);  //Interface for searching cars by various criteria
        List<Car> SearchByModel(string model);
        List<Car> SearchByStatus(string status);
    }
}
