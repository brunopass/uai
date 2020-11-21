using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;


namespace Services
{
    public class Usuario
    {

        Security security = new Security();

        private void verify(string nombre, string email, string password)
        {
            if(nombre.Length == 0 || nombre == null)
            {
                throw new Exception("El nombre no puede estar vacío");
            }

            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch
            {
                throw new Exception("El email no es válido");
            }

            if(password.Length < 8)
            {
                throw new Exception("La contraseña debe contener al menos 8 caracteres");
            }
        }

        private void verify(string email, string password)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                
            }
            catch
            {
                throw new Exception("El email no es válido");
            }

            if (password.Length < 8)
            {
                throw new Exception("La contraseña debe contener al menos 8 caracteres");
            }
        }

        public string crearUsuario(string nombre, string email, string password)
        {
            try
            {
                verify(nombre, email, password);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            string hash = Guid.NewGuid().ToString();
            string passphrase = security.SHA256(password);

            Entities.Usuario usuario = new Entities.Usuario(email, passphrase);
            usuario.Nombre = nombre;
            usuario.Hash = hash;
            try
            {
                Data.User user = new User();
                string msg = user.CreateUser(usuario);

                return "Cuenta creada con éxito";
            }
            catch
            {
                throw new Exception("Error al crear usuario");
            }
        }

        public string iniciarSesion(string email, string password)
        {
            try
            {
                verify(email, password);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            string passphrase = security.SHA256(password);
            Entities.Usuario usuario = new Entities.Usuario(email, passphrase);

            try
            {
                Data.User user = new User();
                DataTable dataTable = user.SignIn(usuario);

                Session.join(dataTable.Rows[0]["hash"].ToString());

                if(String.IsNullOrEmpty(Session._id))
                {
                    throw new Exception("Error Al iniciar Sesión");
                }

                return "Sesion iniciada";
            }
            catch
            {
                throw new Exception("Error Al iniciar Sesión");
            }
        }
        
        public string CerrarSesion()
        {
            try
            {
                Session.logout();
                return "Sesión Cerrada con éxito";
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public bool isLogged()
        {
            if(Session._id != null && Session._id != "")
            {
                return true;
            }
            else
            {
                throw new Exception("Es necesario iniciar Sesión");
            }
        }

    }
}
