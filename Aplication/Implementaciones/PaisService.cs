using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Aplication.Implementaciones
{
    public class PaisService : IPaisService
	{
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

		public PaisService(
            IPaisRepository paisRepository,  
            IMapper mapper)
		{
            _paisRepository = paisRepository;
            _mapper = mapper;
		}

        public List<PaisDto> Get()
        {
            List<Pais> paises = _paisRepository.Get();
            List<PaisDto> paisDtos = _mapper.Map<List<PaisDto>>(paises);
            return paisDtos;
        }

        public PaisDto GetById(int id)
        {
            Pais pais = _paisRepository.GetById(id);
            PaisDto paisDto = _mapper.Map<PaisDto>(pais);
            return paisDto;
        }

        public int Create(PaisParametroDto paisParametroDto)
        {
            Pais pais = new Pais()
            {
                Nombre = paisParametroDto.Nombre
            };
            int id = _paisRepository.Create(pais);
            return id;
        }

        public void Update(PaisParametroDto paisParametroDto)
        {
            Pais pais = _paisRepository.GetById(paisParametroDto.Id);
            if (pais == null)
            {
                throw new Exception($"El ID {paisParametroDto.Id} No existe");
            }
            pais.Nombre = paisParametroDto.Nombre;
            _paisRepository.Update(pais);
        }

        public void Delete(int id)
        {
            Pais pais = _paisRepository.GetById(id);       
            if (pais == null)
            {
                throw new Exception($"El ID: {id} no existe");
            }
            _paisRepository.Delete(pais);
            
        }

       
    }
}

 