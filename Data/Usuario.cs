using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class Usuario
    {
        private Database database = new Database();
        
        public string CrearUsuario(Entities.Usuario usuario)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@name", usuario.Nombre),
                new SqlParameter("@password", usuario.Password)
            };

            try
            {
                return database.Write("CrearUsuario", parameters);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string IniciarSesion(Entities.Usuario usuario)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@password", usuario.Password)
            };

            try
            {
                return database.Write("IniciarSesion", parameters);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
