using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Impuesto :DatosGenerales
    {
        public Impuesto() {
            cuentaContable = new CuentaContable();
        }


        private string descripcion;
        private CuentaContable cuentaContable;
        private char tipo;
        private DateTime fecha;
        private long nroagente;
        private int nroComprobante;

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

        public char Tipo
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

        public long Nroagente
        {
            get
            {
                return nroagente;
            }

            set
            {
                nroagente = value;
            }
        }

        public int NroComprobante
        {
            get
            {
                return nroComprobante;
            }

            set
            {
                nroComprobante = value;
            }
        }
    }
}
