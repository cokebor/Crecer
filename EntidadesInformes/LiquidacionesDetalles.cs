using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class LiquidacionesDetalles
    {
        private double redondeo;
        private double neto;
        private double comision;
        private double iVA;

        public double Redondeo
        {
            get
            {
                return redondeo;
            }

            set
            {
                redondeo = value;
            }
        }

        public double Neto
        {
            get
            {
                return neto;
            }

            set
            {
                neto = value;
            }
        }

        public double Comision
        {
            get
            {
                return comision;
            }

            set
            {
                comision = value;
            }
        }

        public double IVA
        {
            get
            {
                return iVA;
            }

            set
            {
                iVA = value;
            }
        }
    }
}
