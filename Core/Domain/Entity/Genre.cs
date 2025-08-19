using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Genre : BaseEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public virtual ICollection<MovieGenre> MovieGenres { get; set; } 
        public virtual ICollection<Movie> Movies { get; set; } 
    }
}
