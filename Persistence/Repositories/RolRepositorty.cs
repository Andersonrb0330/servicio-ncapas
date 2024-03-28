using System;
using System.Collections.Generic;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class RolRepositorty : IRolRepository
	{
        private readonly EcommerceContext _ecommerceContext;

		public RolRepositorty(
            EcommerceContext ecommerceContext)
		{
            _ecommerceContext = ecommerceContext;
		}

        public async Task<List<Rol>> Get()
        {
            List<Rol> rols = await _ecommerceContext.Roles.ToListAsync();
            return rols;
        }

        public async Task<Rol> GetById(int id)
        {
            Rol rol = await _ecommerceContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return rol;
        }

        public async Task Create(Rol rol)
        {
            await _ecommerceContext.AddAsync(rol);
        }

        public void Delete(Rol rol)
        {
            _ecommerceContext.Roles.Remove(rol);
        }

        public async Task<bool> ExisteRol(int id)
        {
            bool existeRol = await _ecommerceContext.Roles.AnyAsync(e => e.Id == id);
            return existeRol;
        }
    }
}

