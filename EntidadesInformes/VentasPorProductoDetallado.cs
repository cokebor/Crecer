using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class VentasPorProductoDetallado
    {
        private int codigoSucursal;
        private string rubro;
        private string producto;
        private DateTime fecha;
        private string numero;
        private string cliente;
        private int cantidad;
        private double precioUnitario;
        private string codigoTipoDoc;
        private double total;
        private int idLote;

        public string Rubro
        {
            get
            {
                return rubro;
            }

            set
            {
                rubro = value;
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

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
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

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Cliente
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

        public string CodigoTipoDoc
        {
            get
            {
                return codigoTipoDoc;
            }

            set
            {
                codigoTipoDoc = value;
            }
        }

        public int CodigoSucursal
        {
            get
            {
                return codigoSucursal;
            }

            set
            {
                codigoSucursal = value;
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
    }
}
