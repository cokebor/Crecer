using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class PagoCheques
    {
        private string moneda;
        private string banco;
        private string nroCheque;
        private DateTime fechaPago;
        private string librador;
        private double cotizacion;
        private double importe;
        private double total;

        public string Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                moneda = value;
            }
        }

        public string Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }

        public DateTime FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                fechaPago = value;
            }
        }

        public double Cotizacion
        {
            get
            {
                return cotizacion;
            }

            set
            {
                cotizacion = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
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

        public string NroCheque
        {
            get
            {
                return nroCheque;
            }

            set
            {
                nroCheque = value;
            }
        }

        public string Librador
        {
            get
            {
                return librador;
            }

            set
            {
                librador = value;
            }
        }
    }
}
