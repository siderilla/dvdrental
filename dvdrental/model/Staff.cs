using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public string Email { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public bool Active { get; set; } = true;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }
        public string Picture { get; set; } = string.Empty;

        public Address Address { get; set; } = new Address();
        public Store Store { get; set; } = new Store();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
     

    }
}
