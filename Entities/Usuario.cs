using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        private string email;
        private string password;
        private string nombre;
        private string hash;

        public Usuario(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }
    }
}
