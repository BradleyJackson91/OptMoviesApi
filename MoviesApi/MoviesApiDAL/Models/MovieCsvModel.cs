using MoviesApiDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiDAL.Models
{
    internal class MovieCsvModel
    {
        public DateTime Release_Date { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public float Popularity { get; set; }
        public int Vote_Count { get; set; }
        public float Vote_Average { get; set; }
        public string? Original_Language { get; set; } 
        public string? Genre { get; set; }
        public string? Poster_Url { get; set; }

        public MovieDto MapToDto()
        {
            return new MovieDto()
            {
                ReleaseDate = Release_Date,
                Title = Title,
                Overview = Overview,
                Popularity = Popularity,
                VoteCount = Vote_Count,
                VoteAverage = Vote_Average,
                OriginalLanguage = Original_Language,
                Genres = Genre?.Split(",").Select(g => new GenreDto() { Genre = g }).ToList(),
                PosterUrl = Poster_Url
            };
        }
    }
}
