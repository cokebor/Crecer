using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Devengamiento
    {
        public Devengamiento() {
            Concepto = new Concepto();
            TipoSalario = new TipoSalario();
            Secuencia = new Secuencia();
            Usuario = new Usuario();
            Asiento = new Asiento();
            Detalles = new List<DevengamientoDetalle>();
        }

        public int Codigo { get; set; }
        public Concepto Concepto { get; set; }
        public TipoSalario TipoSalario { get; set; }
        public Secuencia Secuencia { get; set; }
        public string Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public Asiento Asiento { get; set; }
        public List<DevengamientoDetalle> Detalles { get; set; }

    }
}
