using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class RemitoProveedorSinFactura
    {
        private string fecha;
        private string proveedor;
        private string numRemito;

        public string Fecha
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
    }
}
