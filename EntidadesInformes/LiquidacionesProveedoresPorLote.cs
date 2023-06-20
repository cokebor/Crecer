using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class LiquidacionesProveedoresPorLote
    {
        private DateTime fecha;
        private string proveedor;
        private string liquidacion;
        private string producto;
        private int idLote;
        private int cantidadLiquidada;
        private double precioUnitario;
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

        public string Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public int IdLote
        {
            get
            {
                return idLote;
            }

            set
            {
                idLote = value;
            }
        }

        public int CantidadLiquidada
        {
            get
            {
                return cantidadLiquidada;
            }

            set
            {
                cantidadLiquidada = value;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }

            set
            {
                precioUnitario = value;
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
