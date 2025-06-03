using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Language
    {

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<Film> Films { get; set; } = new List<Film>();


    }
}
