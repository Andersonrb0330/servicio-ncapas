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

		public TipoProductoService(
            IEcommerceContext ecommerceContext,
            IMapper mapper)
		{
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
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

