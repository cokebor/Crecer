using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaImpuesto
    {
        public FacturaImpuesto() {
            Impuesto = new Impuesto();
        }

        private Impuesto impuesto;
        private double importe;
        private DateTime fecha;
        private long nroAgente;
        private int nroComprobante;
        public Impuesto Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
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

        public long NroAgente
        {
            get
            {
                return nroAgente;
            }

            set
            {
                nroAgente = value;
            }
        }

        public int NroComprobante
        {
            get
            {
                return nroComprobante;
            }

            set
            {
                nroComprobante = value;
            }
        }
    }
}
