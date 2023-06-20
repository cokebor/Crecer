using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class RemitosSucursal
    {
        private string descripcion;
        private string numRemito;
        private DateTime fecha;
        private string sucursalOrigen;
        private string sucursalDestino;
        private int codigoProducto;
        private string producto;
        private string rubroProducto;
        private int idLote;
        private int cantidad;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
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

        public string SucursalOrigen
        {
            get
            {
                return sucursalOrigen;
            }

            set
            {
                sucursalOrigen = value;
            }
        }

        public string SucursalDestino
        {
            get
            {
                return sucursalDestino;
            }

            set
            {
                sucursalDestino = value;
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

        public string RubroProducto
        {
            get
            {
                return rubroProducto;
            }

            set
            {
                rubroProducto = value;
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
    }
}
