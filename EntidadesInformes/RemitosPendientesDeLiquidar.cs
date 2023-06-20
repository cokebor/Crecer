using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class RemitosPendientesDeLiquidar
    {
        private int codigoProveedor;
        private string proveedor;
        private DateTime fecha;
        private string numRemito;
        private int codigoProducto;
        private string producto;
        private int lote;
        private int ingreso;
        private int cantidad_Vendida;
        private int cantidad_Vendida_Cba;
        private int cantidad_Vendida_VM;
        private int cantidad_Vendida_R4;
        private int cantidad_Remitida;
        private int cantidad_Merma;
        private int cantidad_Liquidada;
        private int cantidad_Envios;
        private double promedio;

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string NumRemito
        {
            get
            {
                return numRemito;
            }

            set
            {
                numRemito = value;
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

        public int Ingreso
        {
            get
            {
                return ingreso;
            }

            set
            {
                ingreso = value;
            }
        }

        public int Cantidad_Vendida
        {
            get
            {
                return cantidad_Vendida;
            }

            set
            {
                cantidad_Vendida = value;
            }
        }

        public int Cantidad_Remitida
        {
            get
            {
                return cantidad_Remitida;
            }

            set
            {
                cantidad_Remitida = value;
            }
        }

        public int Cantidad_Merma
        {
            get
            {
                return cantidad_Merma;
            }

            set
            {
                cantidad_Merma = value;
            }
        }

        public int Cantidad_Liquidada
        {
            get
            {
                return cantidad_Liquidada;
            }

            set
            {
                cantidad_Liquidada = value;
            }
        }

        public int Cantidad_Envios
        {
            get
            {
                return cantidad_Envios;
            }

            set
            {
                cantidad_Envios = value;
            }
        }

        public double Promedio
        {
            get
            {
                return promedio;
            }

            set
            {
                promedio = value;
            }
        }

        public int Cantidad_Vendida_Cba
        {
            get
            {
                return cantidad_Vendida_Cba;
            }

            set
            {
                cantidad_Vendida_Cba = value;
            }
        }

        public int Cantidad_Vendida_VM
        {
            get
            {
                return cantidad_Vendida_VM;
            }

            set
            {
                cantidad_Vendida_VM = value;
            }
        }

        public int Cantidad_Vendida_R4
        {
            get
            {
                return cantidad_Vendida_R4;
            }

            set
            {
                cantidad_Vendida_R4 = value;
            }
        }
    }
}
