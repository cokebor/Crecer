using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoMovimientoBancario:DatosGenerales
    {
        private string descripcion;
        private char afectaCuenta;
        private int comportamientoPredeterminado;

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

        public char AfectaCuenta
        {
            get
            {
                return afectaCuenta;
            }

            set
            {
                afectaCuenta = value;
            }
        }

        public int ComportamientoPredeterminado
        {
            get
            {
                return comportamientoPredeterminado;
            }

            set
            {
                comportamientoPredeterminado = value;
            }
        }
    }
}
