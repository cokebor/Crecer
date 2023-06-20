using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class DetallleFacturaVenta
    {
        private string producto;
        private double porcIva;
        private int cantidad;
        private int kilos;
        private double precioUnitario;
        private double precioKilo;
        private int cubetas;
        
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

        public double PorcIva
        {
            get
            {
                return porcIva;
            }

            set
            {
                porcIva = value;
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

        public int Kilos
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

        public double PrecioKilo
        {
            get
            {
                return precioKilo;
            }

            set
            {
                precioKilo = value;
            }
        }

        public double Total
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(precioUnitario*Cantidad);
            }
        }

        public double TotalKilos
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(PrecioKilo * Kilos);
            }
        }

        public int Cubetas
        {
            get
            {
                return cubetas;
            }

            set
            {
                cubetas = value;
            }
        }
    }
}
