using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
    public class Inmueble
    {
        public string AgregarInmueble(Entities.Inmueble inmueble)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", inmueble.Id),
                new SqlParameter("@titulo", inmueble.Title),
                new SqlParameter("@descripcion", inmueble.Description),
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

        public List<Entities.Inmueble> TraerInmuebles()
        {
            Database database = new Database();
            List<Entities.Inmueble> inmuebles = new List<Entities.Inmueble>();
            try
            {
                DataTable dataTable = database.Read("TraerInmuebles", null);
                foreach(DataRow data in dataTable.Rows)
                {
                    inmuebles.Add(
                            new Entities.Inmueble(
                                    data["id"].ToString(),
                                    data["titulo"].ToString(),
                                    data["descripcion"].ToString(),
                                    data["direccion"].ToString(),
                                    data["ubicacion"].ToString(),
                                    float.Parse(data["precio"].ToString()),
                                    data["uri"].ToString()
                                )
                        );
                }

                return inmuebles;
            }catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<string> TraerPaises()
        {
            Database database = new Database();
            List<string> paises = new List<string>();

            try
            {
                DataTable dataTable = database.Read("TraerPaises", null);
                foreach(DataRow data in dataTable.Rows)
                {
                    paises.Add(data["pais"].ToString());
                }
                return paises
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
