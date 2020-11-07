using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Inmueble
    {
        private Services.Usuario usuario = new Usuario();

        public string CrearAlquiler(string titulo, string descripcion, string direccion, string ubicacion, float precio,  string uri)
        {
            if(titulo == "" || direccion == "" || precio == 0 || uri== "")
            {
                throw new Exception("Falta informacion");
            }

            if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");

            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.AgregarInmueble(
                        new Entities.Inmueble(
                                Guid.NewGuid().ToString(),
                                titulo,
                                descripcion,
                                direccion,
                                ubicacion,
                                precio,
                                uri
                            )
                    );
            }
            catch
            {
                throw new Exception("Error al crear publicación, vuelve a intentar en unos minutos");
            }
        }
    }
}
