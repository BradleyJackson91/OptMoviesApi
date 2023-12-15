using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApiDAL.Models;

namespace MoviesApiDAL
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<GenreModel> Genres { get; set; }

        private readonly string _sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "MoviesApiDb.sqlite");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={_sqlFilePath}");
    }

    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            using (var context = new MoviesDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
