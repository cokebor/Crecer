using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RemitoProveedor_D_Productos
    {
        public RemitoProveedor_D_Productos() {
            producto = new Producto();
            movStock_Lotes = new MovStock_Lotes();
        }

        private int renglon;
        private Producto producto;
        private MovStock_Lotes movStock_Lotes;

        public int Renglon
        {
            get
            {
                return renglon;
            }

            set
            {
                renglon = value;
            }
        }

        public Producto Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public MovStock_Lotes MovStock_Lotes
        {
            get
            {
                return movStock_Lotes;
            }

            set
            {
                movStock_Lotes = value;
            }
        }
    }
}
