using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class StockPorCanal
    {
        private int codigoCanal;
        private string canal;
        private int codigoRubroProducto;
        private string rubroProducto;
        private int codigoProducto;
        private string producto;
        private int codigoProveedor;
        private string proveedor;
        private int lote;
        private int stock;

        public int CodigoCanal
        {
            get
            {
                return codigoCanal;
            }

            set
            {
                codigoCanal = value;
            }
        }

        public string Canal
        {
            get
            {
                return canal;
            }

            set
            {
                canal = value;
            }
        }

        public int CodigoRubroProducto
        {
            get
            {
                return codigoRubroProducto;
            }

            set
            {
                codigoRubroProducto = value;
            }
        }

        public string RubroProducto
        {
            get
            {
                return rubroProducto;
            }

            set
            {
                rubroProducto = value;
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

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public int CodigoProveedor
        {
            get
            {
                return codigoProveedor;
            }

            set
            {
                codigoProveedor = value;
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
    }
}
