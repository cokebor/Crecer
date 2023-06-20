using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vacaciones
    {
        public Vacaciones()
        {
            Empleado = new Empleado();
       }

        public Empleado Empleado { get; set; }
        public int Periodo { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int DiasTomados { get; set; }
    }
}
