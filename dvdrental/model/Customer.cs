using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Customer
    {

        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime LastUpdate { get; set; }

        public Store Store { get; set; } = new Store();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public Address Address { get; set; } = new Address();
    }
}
