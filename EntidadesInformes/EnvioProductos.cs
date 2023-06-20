using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class EnvioProductos
    {
        public DateTime Fecha { get; set; }
        public int CodigoSucursalDestino { get; set; }
        public string Sucursal { get; set; }
        public int CodigoProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
    }
}
