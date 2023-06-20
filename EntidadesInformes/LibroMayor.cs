using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class LibroMayor
    {
        private DateTime fecha;
        private int numero;
        private string descripcion;
        private double debe;
        private double haber;
        private double total;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public double Debe
        {
            get
            {
                return debe;
            }

            set
            {
                debe = value;
            }
        }

        public double Haber
        {
            get
            {
                return haber;
            }

            set
            {
                haber = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
