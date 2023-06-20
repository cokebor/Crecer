using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Egreso
    {
        private DateTime fechaEgreso;
        private string causa;

        public Egreso() { }
        public Egreso(DateTime pFechaEgreso, string pCausa)
        {
            this.FechaEgreso = pFechaEgreso;
            this.Causa = pCausa;
        }

        public DateTime FechaEgreso
        {
            get
            {
                return fechaEgreso;
            }

            set
            {
                fechaEgreso = value;
            }
        }

        public string Causa
        {
            get
            {
                return causa;
            }

            set
            {
                causa = value;
            }
        }
    }
}
