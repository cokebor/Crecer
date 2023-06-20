using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoProveedor_M
    {
        public RemitoProveedor_M() {
            proveedor = new Proveedor();
            tipoRemitoProveedor = new TipoRemitoProveedor();
            canal = new Canal();
            Productos = new List<RemitoProveedor_D_Producto>();
            liquidar = new List<RemitoProveedor_A_Liquidar>();
            usuario = new Usuario();
        }

        private int codigo;
        private Proveedor proveedor;
        private TipoRemitoProveedor tipoRemitoProveedor;
        private DateTime fecha;
        private DateTime fechaEmbarque;
        private bool provisorio;
        private string numRemito;
        private Canal canal;
        private Transporte transporte;
        private int pallets;
        private Usuario usuario;

        private List<RemitoProveedor_D_Producto> productos;
        private List<RemitoProveedor_A_Liquidar> liquidar;
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

        public Proveedor Proveedor
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

        public TipoRemitoProveedor TipoRemitoProveedor
        {
            get
            {
                return tipoRemitoProveedor;
            }

            set
            {
                tipoRemitoProveedor = value;
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

        public bool Provisorio
        {
            get
            {
                return provisorio;
            }

            set
            {
                provisorio = value;
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

        public Canal Canal
        {
            get
            {
                return canal;
            }

            set
            {
                canal = value;
            }
        }

        public List<RemitoProveedor_D_Producto> Productos
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

        public List<RemitoProveedor_A_Liquidar> Liquidar
        {
            get
            {
                return liquidar;
            }

            set
            {
                liquidar = value;
            }
        }

        public DateTime FechaEmbarque
        {
            get
            {
                return fechaEmbarque;
            }

            set
            {
                fechaEmbarque = value;
            }
        }

        public Transporte Transporte
        {
            get
            {
                return transporte;
            }

            set
            {
                transporte = value;
            }
        }

        public int Pallets
        {
            get
            {
                return pallets;
            }

            set
            {
                pallets = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
    }
}
