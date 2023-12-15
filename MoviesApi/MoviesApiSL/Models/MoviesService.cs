using MoviesApiBL.Interfaces;
using MoviesApiDTO.Enums;
using MoviesApiDTO.Models;
using MoviesApiSL.Interfaces;

namespace MoviesApiSL.Models
{
    internal class MoviesService : IMoviesService
    {
        private readonly IMoviesManager _moviesManager;

        public MoviesService(IMoviesManager moviesManager)
        {
            _moviesManager = moviesManager;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovies(int page, int pageSize, string sortBy, string orderDirection)
        {
            var allMovies = await _moviesManager.GetAllMovies();
            var sortedMovies = SortResults(allMovies, sortBy, orderDirection);
            var pagedMovies = PageResults(sortedMovies, page, pageSize);

            return pagedMovies;
        }

        public async Task<MovieDto?> GetMovieById(Guid id)
        {
            return await _moviesManager.GetMovieById(id);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genre, int page, int pageSize, string sortBy, string orderDirection)
        {
           var allMovies = await _moviesManager.GetMoviesByGenre(genre);
           var sortedMovies = SortResults(allMovies, sortBy, orderDirection);
           var pagedMovies = PageResults(sortedMovies, page, pageSize);

           return pagedMovies;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByTitle(string title, int page, int pageSize, string sortBy, string orderDirection)
        {
            var allMovies = await _moviesManager.GetMoviesByTitle(title);
            var sortedMovies = SortResults(allMovies, sortBy, orderDirection);
            var pagedMovies = PageResults(sortedMovies, page, pageSize);

            return pagedMovies;
        }

        private IEnumerable<MovieDto> SortResults(IEnumerable<MovieDto> movies, string sortBy, string orderDirection)
        {
            Enum.TryParse<SortBy>(sortBy, ignoreCase: true, out SortBy sortByEnum);

            Enum.TryParse<OrderDirection>(orderDirection, ignoreCase: true, out OrderDirection orderDirectionEnum);

            if (sortByEnum == SortBy.Title)
            {
                if (orderDirectionEnum == OrderDirection.Ascending)
                {
                    return movies.OrderBy(m => m.Title).ToList();
                }

                return movies.OrderByDescending(m => m.Title).ToList();
            }

            if (sortByEnum == SortBy.ReleaseDate)
            {
                if (orderDirectionEnum == OrderDirection.Ascending)
                {
                    return movies.OrderBy(m => m.ReleaseDate).ToList();
                }

                return movies.OrderByDescending(m => m.ReleaseDate).ToList();
            }

            throw new InvalidOperationException(
                "Unable to sort the list as the provided sorting parameters are invalid.");
        }

        private IEnumerable<MovieDto> PageResults(IEnumerable<MovieDto> movies, int page, int pageSize)
        {
            return movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
