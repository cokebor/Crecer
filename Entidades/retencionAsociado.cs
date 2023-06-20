using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RetencionAsociado : DatosGenerales
    {
        public RetencionAsociado() {
            CuentaContable = new CuentaContable();
        }
        private string descripcion;
        private CuentaContable cuentaContable;
        private char debeOHaber;
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
        public char DebeOHaber
        {
            get
            {
                return debeOHaber;
            }

            set
            {
                debeOHaber = value;
            }
        }
    }
}
