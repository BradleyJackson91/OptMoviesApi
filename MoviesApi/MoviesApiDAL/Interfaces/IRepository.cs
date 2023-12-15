namespace MoviesApiDAL.Interfaces;

internal interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    T? GetById(Guid id);
    void Update(T entity);
    void Delete(T entity);
}

