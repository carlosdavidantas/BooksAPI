using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        
    }
}
