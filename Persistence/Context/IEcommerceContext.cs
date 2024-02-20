using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface IEcommerceContext
	{
        DbSet<Producto> Productos { get; set; }
        DbSet<TipoProducto> TipoProductos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Empresa> Empresas { get; set; }
        int SaveChanges();
    }
}