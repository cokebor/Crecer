using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion
{
    class Singleton
    {
        public static Singleton Instancia = new Singleton();

        private Singleton() {
            usuario = new Entidades.Usuario();
            puesto = new Entidades.PuestoCaja();
        }

        private Entidades.Usuario usuario;
        private Entidades.PuestoCaja puesto;
        private Entidades.Empresa empresa;

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public PuestoCaja Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }
    }
}
