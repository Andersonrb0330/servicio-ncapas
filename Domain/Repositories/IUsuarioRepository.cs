﻿using Domain.Entity;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
	{
        Task<List<Usuario>> Get();
        Task<Usuario> GetById(int id);
        void Delete(Usuario usuario);
        Task Create(Usuario usuario);
        Task<bool> VerificarEmail(string email);
        Task<bool> VerificarEmpleadoUsuario(int idEmpleado);
        Task<Usuario> LoginInfo(string email, string clave);
        Task<List<Usuario>> GetPaginado (IQueryable<Usuario> queryable, int limite, int excluir);
        Task<IQueryable<Usuario>> GetQueryable();
    }
}

