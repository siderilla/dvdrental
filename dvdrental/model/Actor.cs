using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Actor
    {

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<Film> Films { get; set; } = new List<Film>();


    }
}
