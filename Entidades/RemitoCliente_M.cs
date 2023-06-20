using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoCliente_M
    {
        public RemitoCliente_M() {
            tipoRemitoCliente = new TipoRemitoCliente();
            cliente = new Cliente();
            Productos = new List<RemitoCliente_D_Producto>();
        }

        private int codigo;
        private TipoRemitoCliente tipoRemitoCliente;
        private string numRemito;
        private DateTime fecha;
        private Cliente cliente;
        private List<RemitoCliente_D_Producto> productos;

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
        public TipoRemitoCliente TipoRemitoCliente
        {
            get
            {
                return tipoRemitoCliente;
            }

            set
            {
                tipoRemitoCliente = value;
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

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public List<RemitoCliente_D_Producto> Productos
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
