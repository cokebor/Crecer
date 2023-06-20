using System;

namespace EntidadesInformes
{
    public class PreciosLotes
    {
        private DateTime fechaIngreso;
        private string nombreProveedor;
        private string nombreProducto;
        private int lote;
        private int cantidadIngresada;
        private int stock;
        private int ventas;
        private double precioPromedio;

        public DateTime FechaIngreso
        {
            get
            {
                return fechaIngreso;
            }

            set
            {
                fechaIngreso = value;
            }
        }

        public string NombreProveedor
        {
            get
            {
                return nombreProveedor;
            }

            set
            {
                nombreProveedor = value;
            }
        }

        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
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

        public int CantidadIngresada
        {
            get
            {
                return cantidadIngresada;
            }

            set
            {
                cantidadIngresada = value;
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

        public int Ventas
        {
            get
            {
                return ventas;
            }

            set
            {
                ventas = value;
            }
        }

        public double PrecioPromedio
        {
            get
            {
                return precioPromedio;
            }

            set
            {
                precioPromedio = value;
            }
        }
    }
}
