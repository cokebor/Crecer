using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso
    {
        private GrupoDeUsuario grupoDeUsuario;
        private Menu menu;

        public GrupoDeUsuario GrupoDeUsuario
        {
            get
            {
                return grupoDeUsuario;
            }

            set
            {
                grupoDeUsuario = value;
            }
        }

        public Menu Menu
        {
            get
            {
                return menu;
            }

            set
            {
                menu = value;
            }
        }
    }
}
