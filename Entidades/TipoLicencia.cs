using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoLicencia
    {
        public int Codigo { get; set; }
        public String Descripcion { get; set; }
        //Dias sobre los cuales se va a calcular la licencia, Ejemplo vacaciones sobre 25
        public int LiquidacionSobre { get; set; }
        public Boolean Descuento { get; set; }
        public Boolean Estado { get; set; }
    }
}
