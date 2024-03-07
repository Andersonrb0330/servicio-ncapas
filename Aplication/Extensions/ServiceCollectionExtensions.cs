using System.Reflection;
using Aplication.Dtos.Response;
using Aplication.Implementaciones;
using Aplication.Interfaces;
using Domain.Validacion;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aplication.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddApplicationProject(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Aquì damos a entender que esa interfaz y esa clase, trabajen juntos
            services.AddTransient<ITipoProductoService, TipoProductoService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<IValidator<ProductoDto>,ProductoDtoValidador>();
            services.AddControllersWithViews().AddFluentValidation();
        }
    }
}