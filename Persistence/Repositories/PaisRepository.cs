using System.Data;
using Domain.Entity;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PaisRepository : IPaisRepository
	{
        private readonly PruebaContext _pruebaContext;

		public PaisRepository(
            PruebaContext pruebaContext)
		{
            _pruebaContext = pruebaContext;
		}

        public List<Pais> Get()
        {
            using (var connection = _pruebaContext.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "usp_GetPaises";
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    var paises = new List<Pais>();
                    while (reader.Read())
                    {
                        var pais = new Pais
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        };
                        paises.Add(pais);
                    }        
                    return paises;
                }
            }
        }

        public Pais GetById(int id)
        {
            using (var connection = _pruebaContext.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "usp_GetByIdPais";
                command.CommandType = CommandType.StoredProcedure;

                var parametroIdPais = command.CreateParameter();
                parametroIdPais.ParameterName = "@IdPais";
                parametroIdPais.Value = id;
                command.Parameters.Add(parametroIdPais);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var pais = new Pais
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        };
                        return pais;
                    }
                    return null;
                }
            }
        }

        public int Create(Pais pais)
        {
            using (var connection = _pruebaContext.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "usp_InsertPais";
                command.CommandType = CommandType.StoredProcedure;

                var parametroNombre = command.CreateParameter();
                parametroNombre.ParameterName = "@Nombre";
                parametroNombre.Value = pais.Nombre;
                command.Parameters.Add(parametroNombre);

                var parametroId = command.CreateParameter();
                parametroId.ParameterName = "@PaisId";
                parametroId.DbType = DbType.Int32;
                parametroId.Direction = ParameterDirection.Output;
                command.Parameters.Add(parametroId);

                command.ExecuteNonQuery();

                if (parametroId.Value != DBNull.Value)
                {
                    pais.Id = (int)parametroId.Value;
                }
                return pais.Id;
            }
        }

        public void Update(Pais pais)
        {
            using (var connection = _pruebaContext.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "usp_UpdatePais";
                command.CommandType = CommandType.StoredProcedure;

                var parametroIdPais = command.CreateParameter();
                parametroIdPais.ParameterName = "@IdPais";
                parametroIdPais.Value = pais.Id;
                command.Parameters.Add(parametroIdPais);

                var parametroNombre = command.CreateParameter();
                parametroNombre.ParameterName = "@Nombre";
                parametroNombre.Value = pais.Nombre;
                command.Parameters.Add(parametroNombre);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Pais pais)
        {
            using (var connection = _pruebaContext.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "usp_DeletePais";
                command.CommandType = CommandType.StoredProcedure;

                var parametroIdPais = command.CreateParameter();
                parametroIdPais.ParameterName = "@IdPais";
                parametroIdPais.Value = pais.Id;
                command.Parameters.Add(parametroIdPais);

                command.ExecuteNonQuery();
            }
        }
    }
}

