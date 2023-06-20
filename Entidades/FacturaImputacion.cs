using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaCompraImputacion
    {
        public FacturaCompraImputacion() {
            tipoDocumentoProveedor = new TipoDocumentoProveedor();
        }

        private TipoDocumentoProveedor tipoDocumentoProveedor;
        private int codigo;
        private double monto;
        private char codigoImputacion;
        private double imputacionAnterior;

        public TipoDocumentoProveedor TipoDocumentoProveedor
        {
            get
            {
                return tipoDocumentoProveedor;
            }

            set
            {
                tipoDocumentoProveedor = value;
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
