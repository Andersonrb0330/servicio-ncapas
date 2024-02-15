using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TipoProductoEntityConfiguration : IEntityTypeConfiguration<TipoProducto>
    {
		public TipoProductoEntityConfiguration()
		{
		}

        void IEntityTypeConfiguration<TipoProducto>.Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.ToTable("TipoProducto");
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired() // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired
                .IsUnicode(false);
        }
    }
}

