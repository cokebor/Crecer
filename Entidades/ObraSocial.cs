using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ObraSocial : DatosGenerales
    {
        public ObraSocial() { }
        public ObraSocial(int pCodigo, string pNombre) : base(pCodigo) {
            this.Nombre = pNombre;
        }

        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }
    }
}
