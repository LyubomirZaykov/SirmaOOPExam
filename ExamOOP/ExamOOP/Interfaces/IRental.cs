
using ExamOOP.Models;

namespace ExamOOP.Interfaces
{
    public interface IRental
    {
        
        IVehicle Vehicle { get;}
        ICustomer Customer { get;}
       // DateOnly RentalDate { get;}
       // DateOnly ReturnDate { get; }
    }
}
