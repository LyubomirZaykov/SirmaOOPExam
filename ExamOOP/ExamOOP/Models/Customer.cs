using ExamOOP.Interfaces;

namespace ExamOOP.Models
{
    public class Customer : ICustomer
    {
        private static int customerId = 1;
        private string name;
        private int id;
        private DateOnly dateOfBirth;
        public Customer(string Name, int Id, DateOnly dateOfBirth)
        {
            
        }
        public string Name
        {
            get 
        }


        public int Id => throw new NotImplementedException();

        public DateOnly DateOfBirth => throw new NotImplementedException();
    }
}
