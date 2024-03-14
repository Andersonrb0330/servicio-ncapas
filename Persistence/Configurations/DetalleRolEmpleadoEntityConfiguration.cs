using System;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class DetalleRolEmpleadoEntityConfiguration : IEntityTypeConfiguration<DetalleRolEmpleado> 
    {
		public DetalleRolEmpleadoEntityConfiguration()
		{
		}

		void IEntityTypeConfiguration<DetalleRolEmpleado>.Configure(EntityTypeBuilder<DetalleRolEmpleado> builder)
		{
            builder.ToTable("DetalleRolEmpleado");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IdRol)
                .HasColumnName("IdRol");

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.DetalleRolEmpleado)
                .HasForeignKey(e => e.IdRol);

            builder.Property(e => e.IdEmpleado)
               .HasColumnName("IdEmpleado");

            builder.HasOne(e => e.Empleado)
                .WithMany(e => e.DetalleRolEmpleado)
                .HasForeignKey(e => e.IdEmpleado);
        }
	}
}

