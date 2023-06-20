using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DevengamientoDetalle
    {
        public DevengamientoDetalle() {
            Concepto = new ConceptoAsociado();
            CuentaContable = new CuentaContable();
        }
        public int Renglon { get; set; }
        public ConceptoAsociado Concepto { get; set; }
        public CuentaContable CuentaContable { get; set; }
        public double Debe { get; set; }
        public double Haber { get; set; }
        public double SaldoAnterior { get; set; }
    }
}
