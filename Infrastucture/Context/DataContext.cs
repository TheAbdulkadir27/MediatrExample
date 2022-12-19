using Domain.Entity;
using Domain.Entity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastucture.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<Admin> AdminS { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writers> Writers { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
