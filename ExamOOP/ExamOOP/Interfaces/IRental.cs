
using ExamOOP.Models;

namespace ExamOOP.Interfaces
{
    public interface IRental
    {
        int CarId { get; set; }
        Customer Customer { get; set; }
        DateTime RentalDate { get; set; }
        DateTime? ReturnDate { get; set; }
    }
}
