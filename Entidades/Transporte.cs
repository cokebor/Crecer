using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;

namespace Entidades
{
    public class Transporte : DatosGenerales
    {
        public Transporte()
        {
        }
        public Transporte(int pCodigo, string pDescripcion) : base(pCodigo)
        {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
            this.Estado = Enumeraciones.Enumeraciones.Estados.Activo;
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
                descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }
    }
}
