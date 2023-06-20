using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConceptoAsociado : DatosGenerales
    {
        public ConceptoAsociado() {
            CuentaContable = new CuentaContable();
        }
        private string descripcion;
        private CuentaContable cuentaContable;
        private char debeOHaber;
        private bool mostrarEnPago;
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

        public bool MostrarEnPago
        {
            get
            {
                return mostrarEnPago;
            }

            set
            {
                mostrarEnPago = value;
            }
        }
    }
}
