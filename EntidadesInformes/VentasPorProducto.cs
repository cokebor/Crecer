using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class VentasPorProducto
    {
        private int codigoRubro;
        private string rubro;
        private int codigoProducto;
        private string producto;
        private int idLote;
        private int cantidad;
        private double precioUnitario;
        private double total;
        private int stock;
        private int mermas;

        public int CodigoRubro
        {
            get
            {
                return codigoRubro;
            }

            set
            {
                codigoRubro = value;
            }
        }

        public string Rubro
        {
            get
            {
                return rubro;
            }

            set
            {
                rubro = value;
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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
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

        public int Stock { get => stock; set => stock = value; }
        public int Mermas { get => mermas; set => mermas = value; }
    }
}
