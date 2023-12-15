using MoviesApiDAL.Interfaces;

namespace MoviesApiDAL.Models;

internal class GenreRepository : IRepository<GenreModel>
{
    private readonly MoviesDbContext _dbContext;

    public GenreRepository(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<GenreModel> GetAll()
    {
        return _dbContext.Genres;
    }

    public GenreModel GetById(Guid id)
    {
        return _dbContext.Genres
            .FirstOrDefault(g => g.Id == id);
    }

    public void Add(GenreModel model)
    {
        _dbContext.Genres.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(GenreModel model)
    {
        _dbContext.Genres.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(GenreModel model)
    {
        _dbContext.Genres.Remove(model);
        _dbContext.SaveChanges();
    }
}

