using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura_Cheque
    {
        public Factura_Cheque() {
            cheques = new List<Cheque>();
        }

        private List<Cheque> cheques;

        public List<Cheque> Cheques
        {
            get
            {
                return cheques;
            }

            set
            {
                cheques = value;
            }
        }
    }
}
