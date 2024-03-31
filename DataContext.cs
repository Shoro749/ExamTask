using ExamTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamTask
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var user = modelBuilder.Entity<User>();
            //user.HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<ShelvedBooks> ShelvedBooks { get; set;} = default!;
        public DbSet<BooksWrittenOff> BooksWrittenOff { get; set; } = default!;
    }
}
