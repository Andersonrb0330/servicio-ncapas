using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UsuarioEntityConfigurations : IEntityTypeConfiguration<Usuario>
    {
		public UsuarioEntityConfigurations()
		{
		}

        void IEntityTypeConfiguration<Usuario>.Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(100) 
                .IsUnicode(false);

            builder.Property(e => e.Clave)
                .HasColumnName("Clave")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(u => u.Empleado)
                .WithMany()
                .HasForeignKey(u => u.IdEmpleado);
        }
    }
}

