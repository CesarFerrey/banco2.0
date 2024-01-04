using banco.Models;
using Microsoft.EntityFrameworkCore;


namespace banco.DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(x => x.Tarjeta).HasMaxLength(150);
            modelBuilder.Entity<User>().Property(x => x.Pin).HasMaxLength(150);

        }


        public DbSet<User> User { get; set; }
    
    }
}
