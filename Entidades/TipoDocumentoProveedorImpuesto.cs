using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumentoProveedorImpuesto
    {
        public TipoDocumentoProveedorImpuesto() {
            Impuesto = new Impuesto();
            Regimen = new Regimen();
        }

        private Impuesto impuesto;
        private double porcentaje;
        private char del;
        private Regimen regimen;

        public Impuesto Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
            }
        }

        public double Porcentaje
        {
            get
            {
                return porcentaje;
            }

            set
            {
                porcentaje = value;
            }
        }

        public char Del
        {
            get
            {
                return del;
            }

            set
            {
                del = value;
            }
        }

        public Regimen Regimen
        {
            get
            {
                return regimen;
            }

            set
            {
                regimen = value;
            }
        }

        public string ObtenerDel() {
            if (Del.Equals('N'))
            {
                return "Neto";
            }
            else if (Del.Equals('I'))
            {
                return "IVA";
            }
            else {
                return "Total";
            }
        }
    }
}
