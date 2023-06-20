using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Gastos
    {
        public string Sucursal { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public long CodigoCuentaContable { get; set; }
        public String Gasto { get; set; }
        public decimal Importe { get; set; }
        public string Observaciones { get; set; }
    }
}
