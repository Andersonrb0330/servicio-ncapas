using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class TipoProductoService : ITipoProductoService
    {
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

		public TipoProductoService(IEcommerceContext ecommerceContext, IMapper mapper)
		{
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
        }

        public int Crear(TipoProductoParametroDto tipoProductoParametroDto)
        {
            TipoProducto tipoProducto = new TipoProducto
            {
               Nombre = tipoProductoParametroDto.Nombre,
            };

            _ecommerceContext.TipoProductos.Add(tipoProducto);
            _ecommerceContext.SaveChanges();
            return tipoProducto.Id;
        }

        public void Eliminar(int id)
        {
            TipoProducto tipoProducto = _ecommerceContext.TipoProductos.FirstOrDefault(tp => tp.Id == id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {id}");
            }

            _ecommerceContext.TipoProductos.Remove(tipoProducto);
            _ecommerceContext.SaveChanges();
        }

        public void Modificar(TipoProductoParametroDto tipoProductoParametroDto)
        {
            TipoProducto tipoProducto = _ecommerceContext.TipoProductos.FirstOrDefault(tp => tp.Id == tipoProductoParametroDto.Id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {tipoProductoParametroDto.Id}");
            }

            tipoProducto.Nombre = tipoProductoParametroDto.Nombre;
            _ecommerceContext.SaveChanges();
        }

        public TipoProductoDto ObtenerPorId(int id)
        {
            TipoProducto tipoProducto = _ecommerceContext.TipoProductos.FirstOrDefault(tp => tp.Id == id);
            TipoProductoDto tipoProductoDto = _mapper.Map<TipoProductoDto>(tipoProducto);
            return tipoProductoDto;
        }

        public List<TipoProductoDto> ObtenerTodos()
        {
            List<TipoProducto> tipoProductos = _ecommerceContext.TipoProductos.ToList();
            List<TipoProductoDto> tipoProductoDto = _mapper.Map<List<TipoProductoDto>>(tipoProductos);
            return tipoProductoDto;
        }
    }
}

