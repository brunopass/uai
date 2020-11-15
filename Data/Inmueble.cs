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
                new SqlParameter("@id_usuario", Entities.Session._id),
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
                    Entities.Inmueble _inmueble = new Entities.Inmueble(
                                    data["id"].ToString(),
                                    data["titulo"].ToString(),
                                    data["descripcion"].ToString(),
                                    data["direccion"].ToString(),
                                    data["ubicacion"].ToString(),
                                    float.Parse(data["precio"].ToString()),
                                    data["uri"].ToString()
                                );
                    if (data["promedio"].ToString() == "")
                    {
                        _inmueble.Stars = (int)Math.Round(float.Parse("0"));
                    }
                    else
                    {
                        _inmueble.Stars = (int)Math.Round(float.Parse(data["promedio"].ToString()));
                    }
                    inmuebles.Add(_inmueble);
                }

                return inmuebles;
            }catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public Entities.Inmueble TraerInmueblePorId(string id)
        {
            Database database = new Database();
            List<Entities.Inmueble> inmuebles = new List<Entities.Inmueble>();

            SqlParameter[] parameters = { new SqlParameter("@id", id)};

            try
            {
                DataTable dataTable = database.Read("TraerInmueblesPorId", parameters);
                foreach (DataRow data in dataTable.Rows)
                {

                    Entities.Inmueble _inmueble = new Entities.Inmueble(
                                    data["id"].ToString(),
                                    data["titulo"].ToString(),
                                    data["descripcion"].ToString(),
                                    data["direccion"].ToString(),
                                    data["ubicacion"].ToString(),
                                    float.Parse(data["precio"].ToString()),
                                    data["uri"].ToString()
                                );

                    if (data["promedio"].ToString() == "")
                    {
                        _inmueble.Stars = (int) Math.Round(float.Parse("0"));
                    }
                    else
                    {
                        _inmueble.Stars = (int)Math.Round(float.Parse(data["promedio"].ToString()));
                    }
                    inmuebles.Add(_inmueble);
                        
                }

                    return inmuebles[0];
            }
            catch (Exception error)
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
                return paises;
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string AgregarFavoritos(string id, string id_inmueble, string hash_usuario)
        {
            Database database = new Database();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@id", id),
                    new SqlParameter("@id_usuario", hash_usuario),
                    new SqlParameter("@id_inmueble", id_inmueble)
                };

                database.Write("AgregarFavoritos", parameters);
                return "Inmueble agregado a favoritos";
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string AgregarComentario(Entities.Comentario comentario)
        {
            Database database = new Database();
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@id", Guid.NewGuid().ToString()),
                    new SqlParameter("@id_inmueble", comentario.Id),
                    new SqlParameter("@id_usuario", Entities.Session._id),
                    new SqlParameter("@comentario", comentario.Value),
                    new SqlParameter("@calificacion", comentario.Calificacion)
                };

                database.Write("AgregarComentario", parameters);
                return "Comentario creado";
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Comentario> TraerComentarios(string id)
        {
            Database database = new Database();
            List<Entities.Comentario> comentarios = new List<Entities.Comentario>();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@id", id),
                };

                DataTable dataTable = database.Read("TraerComentarios", parameters);


                foreach(DataRow data in dataTable.Rows)
                {
                    comentarios.Add(
                            new Entities.Comentario(
                                    data["id"].ToString(),
                                    data["comentario"].ToString(),
                                    int.Parse(data["calificacion"].ToString())
                                )
                        );
                }

                return comentarios;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Inmueble> TraerFavoritos(string id)
        {
            Database database = new Database();
            List<Entities.Inmueble> inmuebles = new List<Entities.Inmueble>();
            SqlParameter[] parameters = { new SqlParameter("@id", id)};
            try
            {
                DataTable dataTable = database.Read("TraerFavoritos", parameters);
                foreach(DataRow data in dataTable.Rows)
                {
                    Entities.Inmueble _inmueble = new Entities.Inmueble(
                                    data["id"].ToString(),
                                    data["titulo"].ToString(),
                                    data["descripcion"].ToString(),
                                    data["direccion"].ToString(),
                                    data["ubicacion"].ToString(),
                                    float.Parse(data["precio"].ToString()),
                                    data["uri"].ToString()
                                );

                    if (data["promedio"].ToString() == "")
                    {
                        _inmueble.Stars = (int)Math.Round(float.Parse("0"));
                    }
                    else
                    {
                        _inmueble.Stars = (int)Math.Round(float.Parse(data["promedio"].ToString()));
                    }
                    inmuebles.Add(_inmueble);
                }
                return inmuebles;
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
