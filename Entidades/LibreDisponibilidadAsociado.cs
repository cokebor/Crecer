using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LibreDisponibilidadAsociado : DatosGenerales
    {
        public LibreDisponibilidadAsociado() {
            CuentaContable = new CuentaContable();
        }
        private string descripcion;
        private CuentaContable cuentaContable;
        private double monto;
        
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

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }
    }
}
