using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Asientos
    {
        private string concepto;
        private double debe;
        private double haber;

        public string Concepto
        {
            get
            {
                return concepto;
            }

            set
            {
                concepto = value;
            }
        }

        public double Debe
        {
            get
            {
                return debe;
            }

            set
            {
                debe = value;
            }
        }

        public double Haber
        {
            get
            {
                return haber;
            }

            set
            {
                haber = value;
            }
        }
    }
}
