using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Licencia
    {
        public Licencia() {
            Empleado = new Empleado();
            TipoLicencia = new TipoLicencia();
            Certificado = new byte[0];
        }
        public int Codigo { get; set; }
        public Empleado Empleado { get; set; }
        public TipoLicencia TipoLicencia { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int Dias { get; set; }
        public string Observaciones { get; set; }
        public byte[] Certificado { get; set; }
        
        
        public bool Estado { get; set; }
    }
}
