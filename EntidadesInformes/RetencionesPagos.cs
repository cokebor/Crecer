using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class RetencionesPagos
    {
        private DateTime fechaRetencion;
        private string certificadoNro;
        private string logo;
        private string razonSocialAgente;
        private string cUITAgente;
        private string domicilioAgente;
        private string proveedor;
        private string cUITProveedor;
        private string direccionProveedor;
        private string impuesto;
        private string regimen;
        private string comprobante;
        private double totalComprobante;
        private double importeRetenido;
        private string puntoDeVenta;
        private string comprobante2;
        private double alicuotaAplicada;
        private string importeRetenidoEnLetras;

        public DateTime FechaRetencion
        {
            get
            {
                return fechaRetencion;
            }

            set
            {
                fechaRetencion = value;
            }
        }

        public string CertificadoNro
        {
            get
            {
                return certificadoNro;
            }

            set
            {
                certificadoNro = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        public string RazonSocialAgente
        {
            get
            {
                return razonSocialAgente;
            }

            set
            {
                razonSocialAgente = value;
            }
        }

        public string CUITAgente
        {
            get
            {
                return cUITAgente;
            }

            set
            {
                cUITAgente = value;
            }
        }

        public string DomicilioAgente
        {
            get
            {
                return domicilioAgente;
            }

            set
            {
                domicilioAgente = value;
            }
        }

        public string Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        public string CUITProveedor
        {
            get
            {
                return cUITProveedor;
            }

            set
            {
                cUITProveedor = value;
            }
        }

        public string DireccionProveedor
        {
            get
            {
                return direccionProveedor;
            }

            set
            {
                direccionProveedor = value;
            }
        }

        public string Impuesto
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

        public string Regimen
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

        public string Comprobante
        {
            get
            {
                return comprobante;
            }

            set
            {
                comprobante = value;
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

        public string PuntoDeVenta
        {
            get
            {
                return puntoDeVenta;
            }

            set
            {
                puntoDeVenta = value;
            }
        }

        public string Comprobante2
        {
            get
            {
                return comprobante2;
            }

            set
            {
                comprobante2 = value;
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

        public string ImporteRetenidoEnLetras
        {
            get
            {
                return Utilidades.NumeroEnLetras.Convertir(ImporteRetenido.ToString("#######.00"), false);
            }

            set
            {
                importeRetenidoEnLetras = value;
            }
        }
    }
}
