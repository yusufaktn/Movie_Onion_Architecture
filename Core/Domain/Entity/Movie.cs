﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Movie:BaseEntity
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public int Duration { get; set; }
        public int CreatedYear { get; set; }
        
    }   
}
