using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class FondoComunInversion
    {
        private DateTime fecha;
        private string tipoOperacion;
        private string fondo;
        private string nroReferencia;
        private double debe;
        private double haber;
        private double total;
        private double intereses;

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

        public string TipoOperacion
        {
            get
            {
                return tipoOperacion;
            }

            set
            {
                tipoOperacion = value;
            }
        }

        public string Fondo
        {
            get
            {
                return fondo;
            }

            set
            {
                fondo = value;
            }
        }

        public string NroReferencia
        {
            get
            {
                return nroReferencia;
            }

            set
            {
                nroReferencia = value;
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

        public double Intereses
        {
            get
            {
                return intereses;
            }

            set
            {
                intereses = value;
            }
        }
    }
}
