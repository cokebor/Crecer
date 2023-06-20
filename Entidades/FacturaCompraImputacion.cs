using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaImputacion
    {
        public FacturaImputacion() {
            tipoDocumentoCliente = new TipoDocumentoCliente();
        }

        private TipoDocumentoCliente tipoDocumentoCliente;
        private int codigo;
        private double monto;
        private char codigoImputacion;
        private double imputacionAnterior;

        public TipoDocumentoCliente TipoDocumentoCliente
        {
            get
            {
                return tipoDocumentoCliente;
            }

            set
            {
                tipoDocumentoCliente = value;
            }
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public char CodigoImputacion
        {
            get
            {
                return codigoImputacion;
            }

            set
            {
                codigoImputacion = value;
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

        public double ImputacionAnterior
        {
            get
            {
                return imputacionAnterior;
            }

            set
            {
                imputacionAnterior = value;
            }
        }
    }
}
