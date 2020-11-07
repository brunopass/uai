using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Inmueble
    {
        public string AgregarInmueble(Entities.Inmueble inmueble)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", inmueble.Id),
                new SqlParameter("@title", inmueble.Title),
                new SqlParameter("@description", inmueble.Description),
                new SqlParameter("@direccion", inmueble.Address),
                new SqlParameter("@precio", inmueble.Price),
                new SqlParameter("@uri", inmueble.Uri),
                new SqlParameter("@ubicacion", inmueble.Ubication)
            };

            Database database = new Database();

            try
            {
                database.Write("AgregarInmueble", parameters);
                return "Publicacion creada con éxito";
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
