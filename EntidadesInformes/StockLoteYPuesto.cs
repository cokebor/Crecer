using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class StockLoteYPuesto
    {
        private int lote;
        private int codigoProducto;
        private string producto;
        private int codigoProveedor;
        private string proveedor;
        private int stock;
        private int codigoSucursal;
        private string descripcion;

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

        public int CodigoSucursal
        {
            get
            {
                return codigoSucursal;
            }

            set
            {
                codigoSucursal = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
