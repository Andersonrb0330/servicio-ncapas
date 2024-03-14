using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmpresaEntityConfiguration : IEntityTypeConfiguration<Empresa>
    {
		public EmpresaEntityConfiguration()
		{

		}

        void IEntityTypeConfiguration<Empresa>.Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired() // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired
                .IsUnicode(false);
        }
    }
}

