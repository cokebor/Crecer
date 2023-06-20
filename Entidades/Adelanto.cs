using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Adelanto
    {
        public int CodigoAdelanto { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public Moneda Moneda { get; set; }
        public double Importe { get; set; }
        public Usuario Usuario { get; set; }
        public Caja Caja { get; set; }
        //0 disponible 
        //1 ya utilizado
        public bool Estado { get; set; }
    }
}
