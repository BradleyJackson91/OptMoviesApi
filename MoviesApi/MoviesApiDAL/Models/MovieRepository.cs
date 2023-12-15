using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using MoviesApiDAL.Interfaces;

namespace MoviesApiDAL.Models
{
    internal class MovieRepository : IRepository<MovieModel>
    {
        private readonly MoviesDbContext _dbContext;

        public MovieRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(MovieModel model)
        {
            _dbContext.Movies.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(MovieModel model)
        {
            _dbContext.Movies.Update(model);
            _dbContext.SaveChanges();
        }

        public void Delete(MovieModel model)
        {
            _dbContext.Movies.Remove(model);
            _dbContext.SaveChanges();
        }

        public IQueryable<MovieModel> GetAll()
        {
            return _dbContext.Movies.Include(m => m.Genres);
        }

        public MovieModel? GetById(Guid id)
        {
            return _dbContext.Movies.Include(m => m.Genres)
                .FirstOrDefault(m => m.Id == id);
        }

        public IQueryable<MovieModel> GetByTitle(string title)
        {
            return _dbContext.Movies.Include(m => m.Genres)
                .Where(m => m.Title != null && m.Title.ToUpper().Contains(title.ToUpper()));
        }

        public IQueryable<MovieModel> GetByGenre(string genre)
        {
            return _dbContext.Movies.Include(m => m.Genres)
                .Where(m => m.Genres != null &&
                    m.Genres.Any(g => g.Genre != null && g.Genre.ToUpper().Contains(genre.ToUpper())));
        }
    }
}
