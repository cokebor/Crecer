using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class PagoImpuesto
    {
        private string descripcion;
        private double importeRetenido;
        private double total;

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

        public double ImporteRetenido
        {
            get
            {
                return importeRetenido;
            }

            set
            {
                importeRetenido = value;
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
