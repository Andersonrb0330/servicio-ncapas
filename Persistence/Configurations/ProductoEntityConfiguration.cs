using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class ProductoEntityConfiguration : IEntityTypeConfiguration<Producto>
	{
		public ProductoEntityConfiguration()
		{
		}

        void IEntityTypeConfiguration<Producto>.Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .IsRequired(); 

            builder.Property(e => e.Stock)
                .HasColumnName("Stock")
                .IsRequired(); // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired

            builder.Property(e => e.Precio)
                .HasColumnName("Precio")
                .HasColumnType("decimal(18, 2)") // En total 18 digitos pero 2 son decimales
                .IsRequired();
        }
    }
}

