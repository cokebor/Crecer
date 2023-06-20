using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class PagoImpuestos
    {
        private string impuesto;
        private double importe;

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
