using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class DetalleLiquidacionProveedores
    {
        private int lote;
        private int codigoProducto;
        private string producto;
        private int bultos;
        private double precioUnitario;
        private int cantidadLiquidada;
        private double importe;

        public int Lote
        {
            get
            {
                return lote;
            }

            set
            {
                lote = value;
            }
        }

        public int CodigoProducto
        {
            get
            {
                return codigoProducto;
            }

            set
            {
                codigoProducto = value;
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

        public int Bultos
        {
            get
            {
                return bultos;
            }

            set
            {
                bultos = value;
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

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }
    }
}
