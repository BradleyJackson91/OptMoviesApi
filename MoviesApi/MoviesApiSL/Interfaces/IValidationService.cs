using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApiDTO.Models;

namespace MoviesApiSL.Interfaces
{
    public interface IValidationService
    {
        ValidationDto ValidateGenre(string genre);
        ValidationDto ValidatePagingAndSorting(string sortBy, string orderDirection, int page, int pageSize);
    }
}
