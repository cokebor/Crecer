using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moneda : DatosGenerales
    {
        public Moneda() {
        }
        public Moneda(int pCodigo, string pDescripcion, DateTime pFecha, double pCotizacion) : base(pCodigo) {
            this.Descripcion = pDescripcion;
            this.fechaCotizacion = pFecha;
            this.Cotizacion = pCotizacion;        
        }


        private string descripcion;
        private DateTime fechaCotizacion;
        private double cotizacion;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public DateTime FechaCotizacion
        {
            get
            {
                return fechaCotizacion;
            }

            set
            {
                fechaCotizacion = value;
            }
        }

        public double Cotizacion
        {
            get
            {
                return cotizacion;
            }

            set
            {
                cotizacion = value;
            }
        }
    }
}
