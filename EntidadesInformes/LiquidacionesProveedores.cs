using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class LiquidacionesProveedores
    {
        private DateTime fecha;
        private string proveedor;
        private string remito;
        private string liquidacion;
        private double neto;
        private double comision;
        private double iva;
        private double total;

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

        public string Remito
        {
            get
            {
                return remito;
            }

            set
            {
                remito = value;
            }
        }

        public string Liquidacion
        {
            get
            {
                return liquidacion;
            }

            set
            {
                liquidacion = value;
            }
        }

        public double Neto
        {
            get
            {
                return neto;
            }

            set
            {
                neto = value;
            }
        }

        public double Comision
        {
            get
            {
                return comision;
            }

            set
            {
                comision = value;
            }
        }

        public double Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
