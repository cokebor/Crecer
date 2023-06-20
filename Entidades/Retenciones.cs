using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Retenciones
    {
        public Retenciones() {
            FacturaCompra = new FacturaCompra();
            PagoCliente = new PagoCliente();
            Impuesto = new Impuesto();
            RetencionAsociado = new RetencionAsociado();
        }
        public FacturaCompra FacturaCompra { get; set; }
        public PagoCliente PagoCliente { get; set; }
        public Impuesto Impuesto { get; set; }
        public RetencionAsociado RetencionAsociado { get; set; }
        public double Monto { get; set; }

        public int CodigoSucursal { get; set; }
    }
}
