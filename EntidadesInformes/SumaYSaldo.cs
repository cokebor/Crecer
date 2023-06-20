using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class SumaYSaldo
    {
        private string cuenta;
        private double debe;
        private double haber;
        private double deudor;
        private double acreedor;

        public string Cuenta
        {
            get
            {
                return cuenta;
            }

            set
            {
                cuenta = value;
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

        public double Deudor
        {
            get
            {
                return deudor;
            }

            set
            {
                deudor = value;
            }
        }

        public double Acreedor
        {
            get
            {
                return acreedor;
            }

            set
            {
                acreedor = value;
            }
        }
    }
}
