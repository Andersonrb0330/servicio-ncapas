using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class EcommerceContext : DbContext, IEcommerceContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
