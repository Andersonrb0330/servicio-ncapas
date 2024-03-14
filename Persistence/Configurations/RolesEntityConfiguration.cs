using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RolesEntityConfiguration  : IEntityTypeConfiguration<Rol>
	{
		public RolesEntityConfiguration()
		{
		}

        void IEntityTypeConfiguration<Rol>.Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired() // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired
                .IsUnicode(false);
        }
    }
}

