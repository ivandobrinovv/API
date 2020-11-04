using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Entites;

namespace OnlineLibrary.DAL
{
    public class OnlineLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }

        public OnlineLibraryContext(DbContextOptions<OnlineLibraryContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookUser>()
                .HasKey(bu => new { bu.UserId, bu.BookId});

            modelBuilder.Entity<BookUser>()
                .HasOne(x => x.Book)
                .WithMany(b => b.BookUsers)
                .HasForeignKey(bu => bu.BookId);

            modelBuilder.Entity<BookUser>()
                .HasOne(x => x.User)
                .WithMany(u => u.BookUsers)
                .HasForeignKey(bu => bu.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
