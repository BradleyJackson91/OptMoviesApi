using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiBL.Interfaces;
using MoviesApiDAL.Interfaces;
using MoviesApiDAL.Models;

namespace MoviesApiBL.Models
{
    internal class DataManager : IDataManager
    {
        private readonly IDataImport _dataImport;

        public DataManager(IDataImport dataImport)
        {
            _dataImport = dataImport;
        }

        public void InitializeData()
        {
            if (_dataImport.HasDataBeenImported())
            {
                return;
            }
            _dataImport.ImportData();
        }
    }
}
