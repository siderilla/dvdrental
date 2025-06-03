using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Rental
    {

        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();

        //public int CustomerId { get; set; } //foreign key
        //public int StaffId { get; set; } //foreign key

    }
}
