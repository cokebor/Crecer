using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class IngresosBrutos
    {
        private string tipo;
        private double facturas_A;
        private double facturas_B;
        private double nD_A;
        private double nD_B;
        private double nC_A;
        private double nC_B;
        private double total;

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public double Facturas_A
        {
            get
            {
                return facturas_A;
            }

            set
            {
                facturas_A = value;
            }
        }

        public double Facturas_B
        {
            get
            {
                return facturas_B;
            }

            set
            {
                facturas_B = value;
            }
        }

        public double ND_A
        {
            get
            {
                return nD_A;
            }

            set
            {
                nD_A = value;
            }
        }

        public double ND_B
        {
            get
            {
                return nD_B;
            }

            set
            {
                nD_B = value;
            }
        }

        public double NC_A
        {
            get
            {
                return nC_A;
            }

            set
            {
                nC_A = value;
            }
        }

        public double NC_B
        {
            get
            {
                return nC_B;
            }

            set
            {
                nC_B = value;
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
