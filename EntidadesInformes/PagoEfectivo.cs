using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class PagoEfectivo
    {
        private string descripcion;
        private double cotizacion;
        private double importe;
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
    }
}
