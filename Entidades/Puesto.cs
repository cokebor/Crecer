using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Puesto:DatosGenerales
    {
        public Puesto() { }
        public Puesto(int pCodigo, string pDescripcion) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
        }

        private string descripcion;
        private double basico;

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

        public double Basico
        {
            get
            {
                return basico;
            }

            set
            {
                basico = value;
            }
        }
    }
}
