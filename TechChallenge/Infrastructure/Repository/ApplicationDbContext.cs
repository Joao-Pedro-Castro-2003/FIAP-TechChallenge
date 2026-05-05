using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Biblioteca> Biblioteca { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Promocao> Promocao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}