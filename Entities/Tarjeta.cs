using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tarjeta
    {
        private string nombre;
        private int cvc;
        private string vencimiento;
        private double numero;

        public Tarjeta(double numero, string nombre, string vencimiento, int cvc)
        {
            this.nombre = nombre;
            this.numero = numero;
            this.vencimiento = vencimiento;
            this.cvc = cvc;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public int CVC
        {
            get { return cvc; }
        }

        public string Vencimiento
        {
            get { return vencimiento; }
        }

        public double Numero
        {
            get { return numero; }
        }
    }
}
