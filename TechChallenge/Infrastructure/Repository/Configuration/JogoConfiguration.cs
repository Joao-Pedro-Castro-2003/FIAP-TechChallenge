using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configuration
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> jogo)
        {
            jogo.ToTable("Jogo");

            jogo.HasKey(j => j.Id);

            jogo.Property(j => j.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            jogo.Property(j => j.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            jogo.Property(j => j.DataCriacao)
                .HasColumnType("DATETIME")
                .IsRequired();

            jogo.Property(j => j.Preco)
                .HasColumnType("DECIMAL(10,2)")
                .IsRequired();
        }
    }
}
