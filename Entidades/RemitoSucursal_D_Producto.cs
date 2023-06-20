namespace Entidades
{
    public class RemitoSucursal_D_Producto
    {
        public RemitoSucursal_D_Producto() {
            producto = new Producto();
            movStock_Lotes = new MovStock_Lotes();
            Proveedor = new Proveedor();
            canal = new Canal();
        }

        private int renglon;
        private Producto producto;
        private MovStock_Lotes movStock_Lotes;
        private Proveedor proveedor;
        private Canal canal;

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

        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        public Canal Canal
        {
            get
            {
                return canal;
            }

            set
            {
                canal = value;
            }
        }
    }
}