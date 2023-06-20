using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;

namespace Entidades
{
    [Serializable]
    public class DatosGenerales
    {
        public DatosGenerales() { }

        public DatosGenerales(int pCodigo) {
            this.Codigo = pCodigo;
            this.Estado = Enumeraciones.Enumeraciones.Estados.Activo;
        }

        public DatosGenerales(int pCodigo, Enumeraciones.Enumeraciones.Estados pEstado) {
            this.Codigo = pCodigo;
            this.Estado = pEstado;
        }

        private int codigo;
        private Enumeraciones.Enumeraciones.Estados estado;

        public int Codigo
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

        public Enumeraciones.Enumeraciones.Estados Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
