using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Inventory
    {

        public int InventoryId { get; set; } //primary key
        public int FilmId { get; set; } //foreign key
        public int StoreId { get; set; } //foreign key
        public DateTime LastUpdate { get; set; } //timestamp

        public Film Film { get; set; } = new Film();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
        public Store Store { get; set; } = new Store();
    }
}
