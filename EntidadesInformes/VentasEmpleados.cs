using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class VentasEmpleados
    {
        public int CodigoVendedor { get; set; }
        public string Empleado { get; set; }
        public int CantidadClientes { get; set; }
        public int Vales { get; set; }
        public int BultosVentas { get; set; }
        public double TotalFacturado { get; set; }
        public int ValesDevoluciones { get; set; }
        public int BultosDevoluciones { get; set; }
        public double TotalDevolucion { get; set; }
        public int ValesAjustes { get; set; }
        public double TotalAjustes { get; set; }
        public double Total { get; set; }
    }
}
