using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lote
    {
        public Lote() {
            proveedor = new Proveedor();
            producto = new Producto();
        }

        private int idLote;
        private Proveedor proveedor;
        private Producto producto;
        private int stock;
        private double precioUnitario;
        //private string dTVe;
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

        public Proveedor Proveedor
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

        public Producto Producto
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

        /*public string DTVe
        {
            get
            {
                return dTVe;
            }

            set
            {
                dTVe = value;
            }
        }*/
    }
}
