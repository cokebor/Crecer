using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SalarioDetalle
    {
        public SalarioDetalle() {
            ConceptoSalario = new ConceptoSalario();
        }
        public ConceptoSalario ConceptoSalario { get; set; }

        private string descripcion;

        private double unidades;

        public double Monto { get; set; }

        public string Descripcion
        {
            get
            {
                if (descripcion == null) {
                    descripcion = "";
                }
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public double Unidades
        {
            get
            {
               return unidades;
            }

            set
            {
                unidades = value;
            }
        }
    }
}
