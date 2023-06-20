using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Merma
    {
        public Merma() {
            Productos = new List<Merma_D_Producto>();
            Usuario = new Usuario();
        }

        private int codigo;
        private DateTime fecha;
        private string numDoc;
        private List<Merma_D_Producto> productos;
        private Usuario usuario;

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string NumDoc
        {
            get
            {
                return numDoc;
            }

            set
            {
                numDoc = value;
            }
        }

        public List<Merma_D_Producto> Productos
        {
            get
            {
                return productos;
            }

            set
            {
                productos = value;
            }
        }

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
    }
}
