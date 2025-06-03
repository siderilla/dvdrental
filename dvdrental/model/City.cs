using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class City
    {

        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public DateTime LastUpdate { get; set; }
        public Country Country { get; set; } = new Country();

        public List<Address> Addresses { get; set; } = new List<Address>();

    }
}
