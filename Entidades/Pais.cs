using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pais:DatosGenerales
    {
        public Pais() {
        }
        public Pais(int pCodigo, string pDescripcion) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
        }

        private string descripcion;


        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                //descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());


                descripcion = value.ToUpper();
            }
        }

        public override string ToString()
        {
            string datos= "PAIS\n--------\n";
            datos +="Codigo: " + this.Codigo.ToString() + "\n";
            datos += "Descripción: " + this.Descripcion.ToString() + "\n\n";
            return datos;
        }
    }
}
