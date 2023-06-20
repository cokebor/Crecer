using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad : DatosGenerales
    {
        public Localidad() {
            provincia = new Provincia();
        }
        public Localidad(int pCodigo, string pNombre, Provincia pProvincia) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Provincia = pProvincia;
        }

        private string nombre;

        private Provincia provincia;
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                // nombre = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
                nombre = value.ToUpper();
            }
        }

        public Provincia Provincia
        {
            get
            {
                return provincia;
            }

            set
            {
                provincia = value;
            }
        }
    }
}
