using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class EncabezadoRemitoSucursal
    {
        private string numRemito;
        private DateTime fecha;
        private string sucursalOrigen;
        private string sucursalDestino;

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
    }
}
