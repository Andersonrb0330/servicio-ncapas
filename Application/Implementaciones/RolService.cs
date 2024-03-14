using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Application.Implementaciones
{
    public class RolService : IRolService
	{
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolService(
            IRolRepository rolRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
		{
            _rolRepository = rolRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public async Task<List<RolDto>> Get()
        {
            List<Rol> roles = await _rolRepository.Get();
            List<RolDto> rolDto = _mapper.Map<List<RolDto>>(roles);
            return rolDto ;
        }

        public async Task<RolDto> GetById(int id)
        {
            Rol rol = await _rolRepository.GetById(id);
            RolDto rolDto = _mapper.Map<RolDto>(rol);
            return rolDto;
        }

        public async Task<int> Crete(RolParametroDto rolParametroDto)
        {
            Rol rol = new Rol
            {
                Nombre = rolParametroDto.Nombre
            };

            await _rolRepository.Create(rol);
            await _unitOfWork.SaveChangesAsync();
            return rol.Id;
        }

        public async Task Update(RolParametroDto rolParametroDto)
        {
            Rol rol = await _rolRepository.GetById(rolParametroDto.Id);
            if (rol == null)
            {
                throw new Exception($"No existe el rol con este ID: {rolParametroDto.Id}");
            };

            rol.Nombre = rolParametroDto.Nombre;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Rol rol = await _rolRepository.GetById(id);
            if (rol == null)
            {
                throw new Exception($"No existe el rol con este ID: {id}");
            };
            _rolRepository.Delete(rol);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

