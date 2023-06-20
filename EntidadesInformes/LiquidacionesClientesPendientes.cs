using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class LiquidacionesClientesPendientes
    {
        private DateTime fecha;
        private string remito;
        private string producto;
        private int lote;
        private int cantidad;
        private int liquidadas;
        private int pendientes;

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

        public string Remito
        {
            get
            {
                return remito;
            }

            set
            {
                remito = value;
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

        public int Liquidadas
        {
            get
            {
                return liquidadas;
            }

            set
            {
                liquidadas = value;
            }
        }

        public int Pendientes
        {
            get
            {
                return pendientes;
            }

            set
            {
                pendientes = value;
            }
        }
    }
}
