using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiDTO.Models
{
    public class ValidationDto
    {
        public DateTime ValidationDate { get; } = DateTime.Now;
        public bool IsValid { get; set; } = true;
        public string? Message { get; set; }
    }
}
