using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiDAL.Models
{
    public class DalBaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
        
        public void OnUpdate()
        {
            LastModifiedDate = DateTime.Now;
        }
    }
}
