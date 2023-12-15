using MoviesApiDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiBL.Interfaces
{
    internal interface IMoviesManager
    {
        Task<IEnumerable<MovieDto>> GetAllMovies();
        Task<MovieDto?> GetMovieById(Guid id);
        Task<IEnumerable<MovieDto>> GetMoviesByTitle(string title);
        Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genre);
    }
}
