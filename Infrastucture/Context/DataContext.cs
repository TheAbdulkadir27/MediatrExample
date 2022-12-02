using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthors>().HasKey(x => new { x.WriterId, x.BookId });
        }
        public DbSet<Admin> AdminS { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writers> Writers { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
    }
}
