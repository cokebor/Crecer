using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class VentasEmpleadoDetalle
    {
        public int CodigoVendedor { get; set; }
        public string Empleado { get; set; }
        public int CodigoProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}
