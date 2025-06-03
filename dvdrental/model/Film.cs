using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.model
{
    internal class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public int? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string? Rating { get; set; }
        public DateTime LastUpdate { get; set; }
        public string? SpecialFeatures { get; set; }
        public string FullText { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; } = new Language();

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public List<Inventory> Inventories { get; set; } = new List<Inventory>();

    }
}
