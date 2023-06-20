namespace Entidades
{
    public class Producto : DatosGenerales
    {
        public Producto()
        {
            rubroProducto = new RubroProducto();
        }
        public Producto(int pCodigo, string pDescripcion, RubroProducto pRubroProducto, string pUnidad, double pPeso, int pStockMinimo, int pStock, string pCodigoBarra, double pPorcentajeIVA, bool pFacturacionPorCubeta, bool pVacio) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
            this.RubroProducto = pRubroProducto;
            this.UnidadDeMedida = pUnidad;
            this.Peso = pPeso;
            this.StockMinimo = pStockMinimo;
            this.Stock = pStock;
            this.CodigoBarra = pCodigoBarra;
            this.PorcentajeIVA = pPorcentajeIVA;
            this.FacturacionPorCubeta = pFacturacionPorCubeta;
            this.Vacio = pVacio;
        }

        private string descripcion;
        private RubroProducto rubroProducto;
        private string unidadDeMedida;
        private double peso;
        private int stockMinimo;
        private int stock;
        private string codigoBarra;
        private double porcentajeIVA;
        public bool FacturacionPorCubeta { get; set; }
        public bool Vacio { get; set; }
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                //descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
                descripcion = value.ToUpper();
            }
        }

        public RubroProducto RubroProducto
        {
            get
            {
                return rubroProducto;
            }

            set
            {
                rubroProducto = value;
            }
        }

        public string UnidadDeMedida
        {
            get
            {
                return unidadDeMedida;
            }

            set
            {
                unidadDeMedida = value;
            }
        }

        public double Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public int StockMinimo
        {
            get
            {
                return stockMinimo;
            }

            set
            {
                stockMinimo = value;
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public string CodigoBarra
        {
            get
            {
                return codigoBarra;
            }

            set
            {
                codigoBarra = value;
            }
        }

        public double PorcentajeIVA
        {
            get
            {
                return porcentajeIVA;
            }

            set
            {
                porcentajeIVA = value;
            }
        }
    }
}
