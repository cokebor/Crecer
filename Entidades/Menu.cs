using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {
        private int codigo;
        private string descripcion;
        private GrupoDeMenu grupoDeMenu;

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

        public GrupoDeMenu GrupoDeMenu
        {
            get
            {
                return grupoDeMenu;
            }

            set
            {
                grupoDeMenu = value;
            }
        }
    }
}
