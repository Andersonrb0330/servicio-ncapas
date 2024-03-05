using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmpleadoEntityConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public EmpleadoEntityConfiguration()
        {
        }

        void IEntityTypeConfiguration<Empleado>.Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
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

            builder.Property(e => e.Dni)
                .HasColumnName("Dni");
               
            builder.Property(e => e.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IdEmpresa");

            builder.HasOne(e => e.Empresa)
                .WithMany(e => e.Empleados)
                .HasForeignKey(e => e.IdEmpresa);
        }
    }
}

