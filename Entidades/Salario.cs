using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Salario
    {
        public Salario() {
            TipoSalario = new TipoSalario();
            Empleado = new Empleado();
            FormaDePago = new FormaDePago();
        }

        public TipoSalario TipoSalario { get; set; }
        public string Periodo { get; set; }
        public Empleado Empleado { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public DateTime Fecha { get; set; }
        public Caja Caja { get; set; }
        public double Monto { get; set; }
    }
}
