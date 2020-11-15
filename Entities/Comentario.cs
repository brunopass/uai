using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comentario
    {
        private string _id;
        private string value;
        private int calificacion;

        public Comentario(string _id, string value, int calificacion)
        {
            this._id = _id;
            this.value = value;
            this.calificacion = calificacion;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Value
        {
            get { return value; }
        }

        public int Calificacion
        {
            get { return calificacion; }
        }
    }
}
