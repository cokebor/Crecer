using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura_DescuentosEspeciales
    {

        private string descripcion;
        private double porcentajeDescuento;
        private double importe;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public double PorcentajeDescuento
        {
            get
            {
                return porcentajeDescuento;
            }

            set
            {
                porcentajeDescuento = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }
    }
}
