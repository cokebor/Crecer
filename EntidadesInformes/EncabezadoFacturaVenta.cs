using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesInformes
{
    public class EncabezadoFacturaVenta
    {
        public EncabezadoFacturaVenta() {
            Empresa = new Entidades.Empresa();
        }

        private Entidades.Empresa empresa;

        private string tipoResponsabilidad;
        private Entidades.Factura factura;
        private string codigo;
        private string condicionVenta;
        private string tipoVenta;
        public string TotalEnLetras { get; set; }
        public string TipoResponsabilidad
        {
            get
            {
                return tipoResponsabilidad;
            }

            set
            {
                tipoResponsabilidad = value;
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }

        public Factura Factura
        {
            get
            {
                return factura;
            }

            set
            {
                factura = value;
            }
        }

        public string Codigo
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

        public string CondicionVenta
        {
            get
            {
                return condicionVenta;
            }

            set
            {
                condicionVenta = value;
            }
        }

        public string TipoVenta
        {
            get
            {
                return tipoVenta;
            }

            set
            {
                tipoVenta = value;
            }
        }
    }
}
