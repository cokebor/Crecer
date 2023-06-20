using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asiento_Detalle
    {
        public Asiento_Detalle() {
            cuentaContable = new CuentaContable();
            Cheque = new Cheque();
        }

        private CuentaContable cuentaContable;
        private double debe;
        private double haber;
        private Cheque cheque;
        public CuentaContable CuentaContable
        {
            get
            {
                return cuentaContable;
            }

            set
            {
                cuentaContable = value;
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

        public Cheque Cheque
        {
            get
            {
                return cheque;
            }

            set
            {
                cheque = value;
            }
        }
    }
}
