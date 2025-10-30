using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("CLIENTE");

        builder.HasKey(c => c.Ruc);
        builder.Property(c => c.Ruc)
               .HasColumnName("RUC")
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(c => c.RazonSocial)
               .HasColumnName("RAZON_SOCIAL")
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(c => c.TelefonoContacto)
               .HasColumnName("TELEFONO_CONTACTO")
               .HasPrecision(18, 0);

        builder.Property(c => c.CorreoContacto)
               .HasColumnName("CORREO_CONTACTO")
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(c => c.Direccion)
               .HasColumnName("DIRECCION")
               .HasMaxLength(300)
               .IsRequired(false);
    }
}