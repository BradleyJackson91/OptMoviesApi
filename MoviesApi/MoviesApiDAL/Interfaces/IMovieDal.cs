using MoviesApiDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiDAL.Interfaces
{
    internal interface IMovieDal
    {
        IEnumerable<MovieDto> GetAll();
        MovieDto? GetById(Guid id);
        IEnumerable<MovieDto> GetByTitle(string title);
        IEnumerable<MovieDto> GetByGenre(string genre);
    }
}
