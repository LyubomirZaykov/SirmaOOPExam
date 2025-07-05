
using ExamOOP.Interfaces;

namespace ExamOOP.Models
{
    public class Rental : IRental
    {
        public int CarId 
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Customer Customer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime RentalDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ReturnDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
