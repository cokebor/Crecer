using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caja_Detalle
    {
        public int Renglon { get; set; }
        public Int64 CodigoCuentaContable { get; set; }
        public String Descripcion { get; set; }
        public  double Importe { get; set; }
    }
}
