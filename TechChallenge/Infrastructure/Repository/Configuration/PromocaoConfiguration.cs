using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configuration
{
    public class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> promocao)
        {
            promocao.ToTable("Promocao");

            promocao.HasKey(p => p.Id);

            promocao.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            promocao.Property(p => p.DataCriacao)
                .HasColumnType("DATETIME")
                .IsRequired();

            promocao.Property(p => p.DataInicio)
                .HasColumnType("DATETIME")
                .IsRequired();

            promocao.Property(p => p.DataFim)
                .HasColumnType("DATETIME")
                .IsRequired();

            promocao.Property(p => p.PercentualDesconto)
                .HasColumnType("INT")
                .IsRequired();

            promocao.Property(p => p.JogoId)
                .HasColumnType("INT")
                .IsRequired();

            promocao.Property(p => p.Ativa)
                .HasColumnType("BIT")
                .IsRequired();

            promocao.HasOne(p => p.Jogo)
                .WithMany(j => j.Promocoes)
                .HasForeignKey(p => p.JogoId);
        }
    }
}
