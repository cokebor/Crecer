using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Retenciones
    {
        private string cUIT;
        private string impuesto;
        private DateTime fechaRetencion;
        private int nroComprobante;
        private int nroAgente;
        private double importe;

        public string CUIT
        {
            get
            {
                return cUIT;
            }

            set
            {
                cUIT = value;
            }
        }

        public string Impuesto
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

        public DateTime FechaRetencion
        {
            get
            {
                return fechaRetencion;
            }

            set
            {
                fechaRetencion = value;
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

        public int NroAgente
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
    }
}
