using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoProveedor_A_Liquidar
    {
        public RemitoProveedor_A_Liquidar() {
            producto = new Producto();
            movStock_Lotes = new MovStock_Lotes();
        }

        private int renglon;
        private Producto producto;
        private MovStock_Lotes movStock_Lotes;
        int cantidadRemitida;
        int cantidadVendida;
        int cantidadVendidaCba;
        int cantidadVendidaVM;
        int cantidadVendidaRC;
        int cantidadLiquidada;
        int cantidadMerma;
        double importeTotal;
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

        public int CantidadRemitida
        {
            get
            {
                return cantidadRemitida;
            }

            set
            {
                cantidadRemitida = value;
            }
        }

        public int CantidadVendida
        {
            get
            {
                return cantidadVendida;
            }

            set
            {
                cantidadVendida = value;
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

        public int CantidadMerma
        {
            get
            {
                return cantidadMerma;
            }

            set
            {
                cantidadMerma = value;
            }
        }

        public double ImporteTotal
        {
            get
            {
                return importeTotal;
            }

            set
            {
                importeTotal = value;
            }
        }

        public int CantidadVendidaCba
        {
            get
            {
                return cantidadVendidaCba;
            }

            set
            {
                cantidadVendidaCba = value;
            }
        }

        public int CantidadVendidaVM
        {
            get
            {
                return cantidadVendidaVM;
            }

            set
            {
                cantidadVendidaVM = value;
            }
        }

        public int CantidadVendidaRC
        {
            get
            {
                return cantidadVendidaRC;
            }

            set
            {
                cantidadVendidaRC = value;
            }
        }
    }
}
