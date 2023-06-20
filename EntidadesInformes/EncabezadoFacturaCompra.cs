using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesInformes
{
    public class EncabezadoFacturaCompra
    {
        private DateTime fechaEmision;
        private string codigo;
        private string condicionVenta;
        private string tipoCompra;
        private string letra;
        private string numero;
        private double descripImp1;
        private double descripImp2;
        private double neto1;
        private double neto2;
        private double importeImp1;
        private double importeImp2;
        private double exento;
        private double noGravado;
        private string descripIva1;
        private string descripIva2;
        public DateTime FechaEmision
        {
            get
            {
                return fechaEmision;
            }

            set
            {
                fechaEmision = value;
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

        public string TipoCompra
        {
            get
            {
                return tipoCompra;
            }

            set
            {
                tipoCompra = value;
            }
        }

        public string Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public double DescripImp1
        {
            get
            {
                return descripImp1;
            }

            set
            {
                descripImp1 = value;
            }
        }

        public double DescripImp2
        {
            get
            {
                return descripImp2;
            }

            set
            {
                descripImp2 = value;
            }
        }

        public double Neto1
        {
            get
            {
                return neto1;
            }

            set
            {
                neto1 = value;
            }
        }

        public double Neto2
        {
            get
            {
                return neto2;
            }

            set
            {
                neto2 = value;
            }
        }

        public double ImporteImp1
        {
            get
            {
                return importeImp1;
            }

            set
            {
                importeImp1 = value;
            }
        }

        public double ImporteImp2
        {
            get
            {
                return importeImp2;
            }

            set
            {
                importeImp2 = value;
            }
        }

        public double Exento
        {
            get
            {
                return exento;
            }

            set
            {
                exento = value;
            }
        }

        public double NoGravado
        {
            get
            {
                return noGravado;
            }

            set
            {
                noGravado = value;
            }
        }

        public string DescripIva1
        {
            get
            {
                return descripIva1;
            }

            set
            {
                descripIva1 = value;
            }
        }

        public string DescripIva2
        {
            get
            {
                return descripIva2;
            }

            set
            {
                descripIva2 = value;
            }
        }
    }
}
