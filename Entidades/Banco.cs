using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banco : DatosGenerales
    {
        private string descripcion;
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
    }
}
