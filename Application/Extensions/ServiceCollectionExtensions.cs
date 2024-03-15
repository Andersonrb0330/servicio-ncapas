using System.Reflection;
using Application.Dtos.Request;
using Application.Implementaciones;
using Application.Interfaces;
using Application.Validacion;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
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
            services.AddTransient<ISeguridadService, SeguridadService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IDetalleRolEmpleadoService, DetalleRolEmpleadoService>();

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