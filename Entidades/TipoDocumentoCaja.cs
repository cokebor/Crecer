using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumentoCaja: DatosGenerales
    {
        public TipoDocumentoCaja() {
            numerador = new Numerador();
        }

        private string descripcion;
        private Numerador numerador;
        private char afectaCaja;

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

        public Numerador Numerador
        {
            get
            {
                return numerador;
            }

            set
            {
                numerador = value;
            }
        }

        public char AfectaCaja
        {
            get
            {
                return afectaCaja;
            }

            set
            {
                afectaCaja = value;
            }
        }
    }
}
