using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoProveederInforme
    {
        private int codigo;
        private int codigoProveedor;
        private string nombre;
        private DateTime fecha;
        private string numRemito;
        private string rubroProducto;
        private int codigoProducto;
        private string producto;
        private int idLote;
        private int cantidad;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
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
    }
}
