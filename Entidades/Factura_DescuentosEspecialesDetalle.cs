using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura_DescuentosEspecialesDetalle
    {
        private int renglon;
        private int cantidad;
        private string detalle;
        private double kilos;
        private double precioUnitario;
        private double iva;
        private int renglonFactura;
        private int codigofactura;
        private double porcentaje;
        private double renglonDescuento;

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

        public string Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public double Porcentaje
        {
            get
            {
                return porcentaje;
            }

            set
            {
                porcentaje = value;
            }
        }

        public double RenglonDescuento
        {
            get
            {
                return renglonDescuento;
            }

            set
            {
                renglonDescuento = value;
            }
        }
    }
}
