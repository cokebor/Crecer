using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class TransferenciasRecibidas
    {
        public int CodigoPago { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoMovimientoBancario { get; set; }
        public int CodigoCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public int CodigoBanco { get; set; }
        public string Banco { get; set; }
        public int CodigoCuentaBancaria { get; set; }
        public string NumeroCuenta { get; set; }
        public string Moneda { get; set; }

        public double Importe { get; set; }
    }
}
