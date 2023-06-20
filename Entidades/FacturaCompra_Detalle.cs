using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaCompra_Detalle
    {
        public FacturaCompra_Detalle() {
            Producto = new Producto();
            MovStock_Lotes = new MovStock_Lotes();
        }

        private int renglon;
        private int renglonRemito;
        private Producto producto;
        private int cantidad;
        private double precioUnitario;
        private double porIva;
        private double iva;
        private MovStock_Lotes movStock_Lotes;
        private int renglonFactura;
        private int codigofactura;
        private int cantCba;
        private int cantVM;
        private int cantRC;
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

        public int RenglonRemito
        {
            get
            {
                return renglonRemito;
            }

            set
            {
                renglonRemito = value;
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

        public int CantCba
        {
            get
            {
                return cantCba;
            }

            set
            {
                cantCba = value;
            }
        }

        public int CantVM
        {
            get
            {
                return cantVM;
            }

            set
            {
                cantVM = value;
            }
        }

        public int CantRC
        {
            get
            {
                return cantRC;
            }

            set
            {
                cantRC = value;
            }
        }
    }
}
