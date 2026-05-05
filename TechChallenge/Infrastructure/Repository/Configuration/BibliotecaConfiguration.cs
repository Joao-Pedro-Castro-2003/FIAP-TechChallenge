using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configuration
{
    public class BibliotecaConfiguration : IEntityTypeConfiguration<Biblioteca>
    {
        public void Configure(EntityTypeBuilder<Biblioteca> biblioteca)
        {
            biblioteca.ToTable("Biblioteca");

            biblioteca.HasKey(x => new { x.UsuarioId, x.JogoId });

            biblioteca.Property(x => x.UsuarioId)
                .HasColumnType("INT")
                .IsRequired();

            biblioteca.Property(x => x.JogoId)
                .HasColumnType("INT")
                .IsRequired();

            biblioteca.Property(x => x.DataAquisicao)
                .HasColumnType("DATETIME")
                .IsRequired();

            biblioteca.HasOne(x => x.Usuario)
                .WithMany(u => u.Biblioteca)
                .HasForeignKey(x => x.UsuarioId);

            biblioteca.HasOne(x => x.Jogo)
                .WithMany(j => j.Biblioteca)
                .HasForeignKey(x => x.JogoId);
        }
    }
}
