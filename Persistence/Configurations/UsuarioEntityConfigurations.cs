using Domain;
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

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Apellido)
                .HasColumnName("Apellido")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Edad)
                .HasColumnName("Edad")
                .IsRequired(); // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired /  caso contrario IsRequired(false)

            builder.Property(e => e.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("date");

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(100) 
                .IsUnicode(false);

            builder.Property(e => e.Clave)
                .HasColumnName("Clave")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}

