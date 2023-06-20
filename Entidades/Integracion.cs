using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Integracion
    {
        private char tipoIntegracion;

        public char TipoIntegracion
        {
            get
            {
                return tipoIntegracion;
            }

            set
            {
                tipoIntegracion = value;
            }
        }

        public string DescripcionIntegracion
        {
            get
            {
                if(tipoIntegracion.Equals('T'))
                    return "INTEGRACION TOTAL";
                else 
                    return "INTEGRACION PARCIAL";
            }
        }
    }
}
