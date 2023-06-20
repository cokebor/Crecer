using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura_Detalle
    {
        public Factura_Detalle() {
            Producto = new Producto();
            MovStock_Lotes = new MovStock_Lotes();
        }

        private int renglon;
        private Producto producto;
        private int cantidad;
        private double kilos;
        private double precioUnitario;
        private double precioUnitarioConDescuento;
        private double porIva;
        private double iva;
        private MovStock_Lotes movStock_Lotes;
        private int renglonFactura;
        private int codigofactura;
        public bool FacturaPorCubeta { get; set; }
        public double PrecioUnitarioPorKilo { get; set; }
        public double PrecioUnitarioPorKiloConDescuento { get; set; }

        public int Renglon
        {
            get
            {
                return renglon;
            }

            set
            {
                renglon = value;
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

        public double PrecioUnitario
        {
            get
            {
                //return Utilidades.Redondear.DosDecimales(precioUnitario);
                return precioUnitario;
            }

            set
            {
                precioUnitario = value;
            }
        }

        public double PorIva
        {
            get
            {
                return porIva;
            }

            set
            {
                porIva = value;
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

        public MovStock_Lotes MovStock_Lotes
        {
            get
            {
                return movStock_Lotes;
            }

            set
            {
                movStock_Lotes = value;
            }
        }

        public double Kilos
        {
            get
            {
                return kilos;
            }

            set
            {
                kilos = value;
            }
        }

        public double PrecioUnitarioConDescuento
        {
            get
            {
                return precioUnitarioConDescuento;
            }

            set
            {
                precioUnitarioConDescuento = value;
            }
        }

        public int RenglonFactura
        {
            get
            {
                return renglonFactura;
            }

            set
            {
                renglonFactura = value;
            }
        }

        public int Codigofactura
        {
            get
            {
                return codigofactura;
            }

            set
            {
                codigofactura = value;
            }
        }
        public double SubTotal()
        {
            return Math.Round(movStock_Lotes.Cantidad * PrecioUnitario, 2);
        }
    }
}
