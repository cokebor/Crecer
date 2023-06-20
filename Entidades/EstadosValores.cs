using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadosValores
    {
        private string codigo;
        private string descripion;

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Descripion
        {
            get
            {
                return descripion;
            }

            set
            {
                descripion = value;
            }
        }
    }
}
