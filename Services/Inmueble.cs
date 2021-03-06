﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Inmueble
    {
        private Services.Usuario usuario = new Usuario();
        Logs logs = new Logs();

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
                logs.createLog($"post created: {Entities.Session._id}");
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
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Inmueble> TraerInmuebles()
        {
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerInmuebles();
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public List<Entities.Inmueble> TraerInmuebles(string busqueda)
        {
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerInmuebles(busqueda);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }


        public Entities.Inmueble TraerInmueble(string id)
        {
            Data.Inmueble inmueble = new Data.Inmueble();

            try
            {
                return inmueble.TraerInmueble(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Inmueble> TraerInmuebles(int stars)
        {
            Data.Inmueble inmueble = new Data.Inmueble();

            try
            {
                return inmueble.TraerInmuebles(stars);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<string> TraerPaises()
        {
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerPaises();
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string AgregarFavoritos(string id)
        {
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");
                logs.createLog($"fav created: {Entities.Session._id}");
                return inmueble.AgregarFavoritos(Guid.NewGuid().ToString(), id, Entities.Session._id);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        private bool validarComentario(Entities.Comentario comentario)
        {
            if(comentario.Id != "" && comentario.Id != null && comentario.Value.Length>0 && comentario.Calificacion >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AgregarComentario(Entities.Comentario comentario)
        {
            if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");
            if (!validarComentario(comentario)) throw new Exception("Por favor verifica que los datos esten completos");


            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                logs.createLog($"comment created: {Entities.Session._id}");
                return inmueble.AgregarComentario(comentario);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Comentario> TraerComentarios(string id)
        {
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerComentarios(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Inmueble> TraerFavoritos()
        {
            if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerFavoritos(Entities.Session._id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string BorrarFavoritos(string id)
        {
            if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                logs.createLog($"fav deleted: {Entities.Session._id}");
                return inmueble.BorrarFavoritos(id, Entities.Session._id);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Entities.Inmueble> TraerAlquileres()
        {
            if (!usuario.isLogged()) throw new Exception("Es necesario estar loggeado");
            Data.Inmueble inmueble = new Data.Inmueble();
            try
            {
                return inmueble.TraerAlquileres(Entities.Session._id);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
