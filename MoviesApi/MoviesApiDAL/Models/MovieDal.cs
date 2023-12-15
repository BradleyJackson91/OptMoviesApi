using MoviesApiDAL.Interfaces;
using MoviesApiDTO.Models;

namespace MoviesApiDAL.Models;

public class MovieDal : IMovieDal
    {
        public void AddToDb(MovieModel model)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            movieRepository.Add(model);
        }

        public void UpdateInDb(MovieModel model)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            movieRepository.Update(model);
        }

        public void DeleteFromDb(MovieModel model)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            movieRepository.Delete(model);
        }

        public IEnumerable<MovieDto> GetAll()
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            return movieRepository.GetAll()
                .Select(m => m.MapToDto())
                .ToList();
        }

        public MovieDto? GetById(Guid id)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            return movieRepository.GetById(id)?.MapToDto();
        }

        public IEnumerable<MovieDto> GetByTitle(string title)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            return movieRepository.GetByTitle(title)
                .Select(m => m.MapToDto())
                .ToList();
        }

        public IEnumerable<MovieDto> GetByGenre(string genre)
        {
            using var dbContext = new MoviesDbContext();
            var movieRepository = new MovieRepository(dbContext);
            return movieRepository.GetByGenre(genre)
                .Select(m => m.MapToDto())
                .ToList();
        }
    }
