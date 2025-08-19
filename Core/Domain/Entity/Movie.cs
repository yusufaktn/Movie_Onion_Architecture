using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            MovieGenres = new List<MovieGenre>();
        }
        public int MovieId { get; set; }
        public bool Adult { get; set; }
        public string CoverImageUrl { get; set; }    
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Release_date { get; set; }
        public string Title { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }

        // Navigation Properties
        public virtual ICollection<MovieGenre> MovieGenres { get; set; } 
        public virtual ICollection<Genre> Genres { get; set; } 
    }   
}
