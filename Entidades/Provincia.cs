using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia : DatosGenerales
    {
        public Provincia() {
            pais = new Pais();
            
        }
        public Provincia(int pCodigo, string pNombre, Pais pPais) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Pais = pPais;
            
        }

        private string nombre;

        private Pais pais;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                // nombre = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
                nombre = value.ToUpper();
            }
        }

        public Pais Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }


    }
}
