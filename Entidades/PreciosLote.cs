using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PreciosLote
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int Lote { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
