
using ExamOOP.Interfaces;

namespace ExamOOP.Models
{
    public class Rental : IRental
    {
        private IVehicle vehicle;
        private ICustomer customer;
        private DateOnly rentalDate;
        private DateOnly returnDate;
        public Rental(IVehicle vehicle, ICustomer customer,DateOnly rentalDate, DateOnly returnDate)
        {
            this.Vehicle = vehicle;
            this.Customer = customer;
            this.RentalDate = rentalDate;
            this.ReturnDate = returnDate;
        }

        public ICustomer Customer
        {
            get
            {
                return this.customer;
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Customer cannot be null.");
                }
                this.customer = value;
            }
        }

        public DateOnly RentalDate
        {
            get
            {
                return this.rentalDate;
            }
            set
            {
              
                this.rentalDate = value;
            }
        }

        public DateOnly ReturnDate
        {
            get
            {
                return this.returnDate;
            }
            set
            {
                
                this.returnDate = value;
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Vehicle cannot be null.");
                }
                this.vehicle = value;
            }
        }
    }
}
