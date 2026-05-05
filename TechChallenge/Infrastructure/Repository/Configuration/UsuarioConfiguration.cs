using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(u => u.IsAdmin)
                .HasColumnType("BIT")
                .IsRequired();
        }
    }
}
