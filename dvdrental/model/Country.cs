using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Country
    {

        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }

        public List<City> Cities { get; set; } = new List<City>();

    }
}
