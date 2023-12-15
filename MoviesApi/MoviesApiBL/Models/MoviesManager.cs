using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiBL.Interfaces;
using MoviesApiDAL.Interfaces;
using MoviesApiDTO.Models;

namespace MoviesApiBL.Models
{
    internal class MoviesManager : IMoviesManager
    {
        private readonly IMovieDal _movieDal;

        public MoviesManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            return await Task.Run(() =>  _movieDal.GetAll());
        }

        public async Task<MovieDto?> GetMovieById(Guid id)
        {
            return await Task.Run(() => _movieDal.GetById(id));
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByTitle(string title)
        {
            return await Task.Run(() => _movieDal.GetByTitle(title));
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genre)
        {
            return await Task.Run(() => _movieDal.GetByGenre(genre));
        }
    }
}
