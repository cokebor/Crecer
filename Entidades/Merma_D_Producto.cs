namespace Entidades
{
    public class Merma_D_Producto
    {
        public Merma_D_Producto() {
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

        public MovStock_Lotes Movstock_Lotes
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