using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Filtro
    {
        private string ubicacion;
        private float minPrice;
        private float maxPrice;
        private string busqueda;

        public Filtro(string ubicacion, float minPrice, float maxPrice, string busqueda)
        {
            this.ubicacion = ubicacion;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            this.busqueda = busqueda;
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public float MinPrice
        {
            get { return minPrice; }
            set { minPrice = value; }
        }

        public float MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value;}
        }

        public string Busqueda
        {
            get { return busqueda; }
            set { busqueda = value; }
        }
    }
}
