using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fondo : DatosGenerales
    {
        public Fondo() {
            banco = new Banco();
            
        }
        public Fondo(int pCodigo, string pNombre, Banco pBanco) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Banco = pBanco;
            
        }

        private string nombre;

        private Banco banco;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public Banco Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }


    }
}
