using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AsientoTemp
    {
        public AsientoTemp() {
            cuentaContable = new CuentaContable();
        }

        private DateTime fecha;
        private CuentaContable cuentaContable;
        private double debe;
        private double haber;
        private int tipo;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

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

        public int Tipo
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
    }
}
