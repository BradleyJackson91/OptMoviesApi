using MoviesApiDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSL.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAllMovies(int page, int pageSize, string sortBy, string orderDirection);
        Task<MovieDto?> GetMovieById(Guid id);
        Task<IEnumerable<MovieDto>> GetMoviesByTitle(string title, int page, int pageSize, string sortBy, string orderDirection);
        Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genre, int page, int pageSize, string sortBy, string orderDirection);
    }
}
