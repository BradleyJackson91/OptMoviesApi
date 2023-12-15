using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiDTO.Models;

namespace MoviesApiDAL.Interfaces;

internal interface IDataImport
{
    public bool HasDataBeenImported();
    public ProgressDto ImportData();
}

