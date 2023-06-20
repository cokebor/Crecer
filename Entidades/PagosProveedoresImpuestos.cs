using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagosProveedoresImpuestos: IEquatable<PagosProveedoresImpuestos>
    {
        public PagosProveedoresImpuestos() {
           // FacturaCompra = new FacturaCompra();
            Impuesto = new Impuesto();
            TipoDocumento = new TipoDocumentoProveedor();
            regimen = new Regimen();
        }

        private TipoDocumentoProveedor tipoDocumento;
       // private FacturaCompra facturaCompra;
        private Impuesto impuesto;
        private double totalComprobante;
        private double importeRetenido;
        private double alicuotaAplicada;
        private Regimen regimen;

       /* public FacturaCompra FacturaCompra
        {
            get
            {
                return facturaCompra;
            }

            set
            {
                facturaCompra = value;
            }
        }*/

        public Impuesto Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
            }
        }



        public double ImporteRetenido
        {
            get
            {
                return importeRetenido;
            }

            set
            {
                importeRetenido = value;
            }
        }

        public TipoDocumentoProveedor TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public double TotalComprobante
        {
            get
            {
                return totalComprobante;
            }

            set
            {
                totalComprobante = value;
            }
        }

        public Regimen Regimen
        {
            get
            {
                return regimen;
            }

            set
            {
                regimen = value;
            }
        }

        public double AlicuotaAplicada
        {
            get
            {
                return alicuotaAplicada;
            }

            set
            {
                alicuotaAplicada = value;
            }
        }

        // override object.Equals
        public bool Equals(PagosProveedoresImpuestos obj)
        {
            return this.impuesto.Codigo == obj.impuesto.Codigo;
        }

    }
}
