using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Payment
    {

        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Staff Staff { get; set; } = new Staff();
        public Customer Customer { get; set; } = new Customer();
        public Rental Rental { get; set; } = new Rental();

    }
}
