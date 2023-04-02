using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using servicio_empresa_abc.Entities;

namespace WebinarApiRest.Configuations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        // Fluent API
        builder.Property(p => p.nombre)
            .HasMaxLength(100);

        builder.Property(p => p.apellido)
            .HasMaxLength(100);


    }
}