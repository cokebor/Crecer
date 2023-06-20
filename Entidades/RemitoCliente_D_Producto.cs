namespace Entidades
{
    public class RemitoCliente_D_Producto
    {
        public RemitoCliente_D_Producto() {
            producto = new Producto();
            movStock_Lotes = new MovStock_Lotes();
            loteNuevo = new Lote();
        }

        private int renglon;
        private Producto producto;
        private MovStock_Lotes movStock_Lotes;
        private Lote loteNuevo;
        private int cantidadLiquidadas;

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

        public Lote LoteNuevo
        {
            get
            {
                return loteNuevo;
            }

            set
            {
                loteNuevo = value;
            }
        }

        public int CantidadLiquidadas
        {
            get
            {
                return cantidadLiquidadas;
            }

            set
            {
                cantidadLiquidadas = value;
            }
        }
    }
}