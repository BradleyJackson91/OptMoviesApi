using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiDTO.Models;

namespace MoviesApiDAL.Models
{
    public class MovieModel : DalBaseModel
    {
        public DateTime ReleaseDate { get; set; } // Release_Date
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public float Popularity { get; set; }
        public int VoteCount { get; set; } // Vote_Count 
        public float VoteAverage { get; set; } // Vote_Average    
        public string? OriginalLanguage { get; set; } // Original_Language 
        public List<GenreModel>? Genres { get; set; }
        public string? PosterUrl { get; set; } // Poster_Url


        public MovieModel()
        {

        }

        public MovieModel(MovieDto dto)
        {
            Id = dto.Id;
            CreatedDate = dto.CreatedDate;
            LastModifiedDate = dto.LastModifiedDate;
            ReleaseDate = dto.ReleaseDate;
            Title = dto.Title;
            Overview = dto.Overview;
            Popularity = dto.Popularity;
            VoteCount = dto.VoteCount;
            VoteAverage = dto.VoteAverage;
            OriginalLanguage = dto.OriginalLanguage;
            PosterUrl = dto.PosterUrl;
            Genres = new List<GenreModel>();

            foreach (GenreDto genre in dto.Genres)
            {
                Genres.Add(new GenreModel(genre));
            }

        }

        public MovieDto MapToDto()
        {
            MovieDto dto = new MovieDto()
            {
                Id = Id,
                CreatedDate = CreatedDate,
                LastModifiedDate = LastModifiedDate,
                ReleaseDate = ReleaseDate,
                Title = Title,
                Overview = Overview,
                Popularity = Popularity,
                VoteCount = VoteCount,
                VoteAverage = VoteAverage,
                OriginalLanguage = OriginalLanguage,
                PosterUrl = PosterUrl
            };

            if (Genres == null || Genres.Count == 0)
            {
                return dto;
            }

            List<GenreDto> genres = new List<GenreDto>();
            foreach (GenreModel genre in Genres)
            {
                genres.Add(genre.MapToDto());
            }

            dto.Genres = genres;

            return dto;
        }
    }
}
