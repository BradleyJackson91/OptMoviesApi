using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiBL.Interfaces;
using MoviesApiSL.Interfaces;

namespace MoviesApiIL.Models
{
    internal class DataService : IDataService
    {
        private readonly IDataManager _dataManager;

        public DataService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Initialize()
        {
            _dataManager.InitializeData();
        }
    }
}
