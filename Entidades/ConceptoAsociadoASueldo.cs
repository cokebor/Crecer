using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConceptoAsociadoASueldo : DatosGenerales
    {
        public ConceptoAsociadoASueldo() {
            //CuentaContable = new CuentaContable();
        }
        public ConceptoAsociadoASueldo(int pCodigo, double pValor):base(pCodigo)
        {
            Valor = pValor;
        }
        private string descripcion;
        //private CuentaContable cuentaContable;
        //private char debeOHaber;
        private char tipoMonto;
        private double valor;
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

        /*public CuentaContable CuentaContable
        {
            get
            {
                return cuentaContable;
            }

            set
            {
                cuentaContable = value;
            }
        }*/
       /* public char DebeOHaber
        {
            get
            {
                return debeOHaber;
            }

            set
            {
                debeOHaber = value;
            }
        }*/

        public char TipoMonto
        {
            get
            {
                return tipoMonto;
            }

            set
            {
                tipoMonto = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }
    }
}
