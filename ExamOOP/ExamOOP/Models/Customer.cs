using ExamOOP.Interfaces;

namespace ExamOOP.Models
{
    public class Customer : ICustomer
    {
        private static int nextId = 1;
        private string? name;
        private int id;

        public Customer(string name)
        {
            this.Name = name;
            this.Id = nextId++;
        }
        public string Name
        {
            get 
            { 
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this.name = value;
            }
        }


        public int Id
        {
            get 
            { 
                return this.id; 
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be negative or zero.");
                }
                this.id = value;
            }
        }

    }
}
