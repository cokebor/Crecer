using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Novedades2
{
    class SingletonNovedad
    {
        public static SingletonNovedad Instancia = new SingletonNovedad();

        private SingletonNovedad() {
            
        }

        private Entidades.Empresa empresa;

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
