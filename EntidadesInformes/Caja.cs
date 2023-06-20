using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Caja
    {
        public int CodigoTipoDocumentoProveedor { get; set; }
        public char Letra { get; set; }
        public int PuntoDeVenta { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
