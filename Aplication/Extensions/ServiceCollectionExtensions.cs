using System.Reflection;
using Aplication.Dtos.Request;
using Aplication.Implementaciones;
using Aplication.Interfaces;
using Aplication.Validacion;
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

            // Aquì damos a enteder que van a trabajar juntos las VALIDACIONES
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<ProductoParametroDto>, ProductoParametroDtoValidator>();
            services.AddTransient<IValidator<TipoProductoParametroDto>, TipoProductoParametroDtoValidator>();
            services.AddTransient<IValidator<EmpresaParametroDto>, EmpresaParametroDtoValidator>();
            services.AddTransient<IValidator<EmpleadoParametroDto>, EmpleadoParametroDtoValidator>();
            services.AddTransient<IValidator<UsuarioParametroDto>, UsuarioParametroDtoValidator>();

        }
    }
}