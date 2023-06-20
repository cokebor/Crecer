using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class MovimientosCuentasCorrientes
    {
        private DateTime fecha;
        private string tipoDocumento;
        private string numero;
        private double debito;
        private double credito;
        private double total2;
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

        public string TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public string Numero
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

        public double Debito
        {
            get
            {
                return debito;
            }

            set
            {
                debito = value;
            }
        }

        public double Credito
        {
            get
            {
                return credito;
            }

            set
            {
                credito = value;
            }
        }

        public double Total2
        {
            get
            {
                return total2;
            }

            set
            {
                total2 = value;
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
