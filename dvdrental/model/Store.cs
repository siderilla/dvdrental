using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Store
    {

        public int StoreId { get; set; }
        public int ManagerStaffId { get; set; }
        public int AddressId { get; set; }
        public DateTime LastUpdate { get; set; }
        public Staff Manager { get; set; } = new Staff();

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Inventory> Inventories { get; set; } = new List<Inventory>();
        public List<Staff> Staffs { get; set; } = new List<Staff>();
    }
}
