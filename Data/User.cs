using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class User
    {
        public string CreateUser(Entities.Usuario usuario)
        {

            Data.Database database = new Database();

            SqlParameter[] parameters =
            {
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@password", usuario.Password),
                new SqlParameter("@name", usuario.Nombre),
                new SqlParameter("@hash", usuario.Hash)
            };

            try
            {
                return database.Write("CreateUser", parameters);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public DataTable SignIn(Entities.Usuario usuario)
        {
            Data.Database database = new Database();

            SqlParameter[] parameters =
            {
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@password", usuario.Password)
            };

            try
            {
                return database.Read("IniciarSesion", parameters);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}