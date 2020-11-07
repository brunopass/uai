
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Casa
    {
        private string _id;
        private string titulo;
        private string descripcion;
        private string direccion;
        private float precio;
        private string ambientes;
        private string uri;
        private int estrellas;

        public Casa(string _id, string titulo, string descripcion, string direccion, float precio, string ambientes, string uri, int estrellas)
        {
            this._id = _id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.direccion = direccion;
            this.precio = precio;
            this.ambientes = ambientes;
            this.uri = uri;
            this.estrellas = estrellas;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Ambientes
        {
            get { return ambientes; }
            set { ambientes = value; }
        }

        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }

        public int Estrellas
        {
            get { return estrellas; }
            set { estrellas = value; }
        }
    }
}
