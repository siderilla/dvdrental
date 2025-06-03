using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; } = null;
        public string District { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }

        public City City { get; set; } = new City();
        public List<Staff> Staffs { get; set; } = new List<Staff>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

    }
}
