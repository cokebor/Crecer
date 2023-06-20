using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class MovimientosCuentasCorrientesImputados
    {
        private DateTime fecha;
        private string tipoDocumento;
        private string numero;
        private double total;
        private double imputado;
        private double saldo;

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

        public double Imputado
        {
            get
            {
                return imputado;
            }

            set
            {
                imputado = value;
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }
    }
}
