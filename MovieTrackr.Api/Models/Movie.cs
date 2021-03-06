﻿using System;

namespace OMDB.Api.Adapter.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public Uri Poster { get; set; }
        public double ImdbRating { get; set; }
        public string Type { get; set; }
        public string ImdbId { get; set; }
    }
}