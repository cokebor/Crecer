using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Factura_Efectivo
    {
        public Factura_Efectivo(){
            moneda = new Moneda();    
        }

        private Moneda moneda;
        private double importe;

        public Moneda Moneda
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
