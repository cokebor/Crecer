using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoSucursal_M
    {
        public RemitoSucursal_M() {
            TipoRemitoSucursal = new TipoRemitoSucursal();
            SucursalOrigen = new Sucursal();
            SucursalDestino = new Sucursal();
            Productos = new List<RemitoSucursal_D_Producto>();
        }

        private int codigo;
        private TipoRemitoSucursal tipoRemitoSucursal;
        private DateTime fecha;
        private Sucursal sucursalOrigen;
        private string numRemito;
        private Sucursal sucursalDestino;
        private List<RemitoSucursal_D_Producto  > productos;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public TipoRemitoSucursal TipoRemitoSucursal
        {
            get
            {
                return tipoRemitoSucursal;
            }

            set
            {
                tipoRemitoSucursal = value;
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

        public Sucursal SucursalOrigen
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

        public Sucursal SucursalDestino
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

        public List<RemitoSucursal_D_Producto> Productos
        {
            get
            {
                return productos;
            }

            set
            {
                productos = value;
            }
        }
    }
}
