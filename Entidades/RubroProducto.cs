using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RubroProducto : DatosGenerales
    {
        public RubroProducto()
        {
        }
        public RubroProducto(int pCodigo, string pDescripcion) : base(pCodigo) {
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
                // descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
                descripcion = value.ToUpper();
            }
        }
        public bool IncluirEnInforme { get; set; }
    }
}
