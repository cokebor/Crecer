namespace Entidades
{
    public class CategoriaProveedor
    {
        private int codigo;
        private string descripcion;
        private double retencionDesdeInscripto;
        private double importeMinimoRetencion;
        private double porcentajeRetencionInscripto;
        private double porcentajeRetencionNoInscripto;
        private int activo;
        private int tablaExtra;

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

        public double RetencionDesdeInscripto
        {
            get
            {
                return retencionDesdeInscripto;
            }

            set
            {
                retencionDesdeInscripto = value;
            }
        }

        public double PorcentajeRetencionInscripto
        {
            get
            {
                return porcentajeRetencionInscripto;
            }

            set
            {
                porcentajeRetencionInscripto = value;
            }
        }

        public int Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public int TablaExtra
        {
            get
            {
                return tablaExtra;
            }

            set
            {
                tablaExtra = value;
            }
        }

        public double PorcentajeRetencionNoInscripto
        {
            get
            {
                return porcentajeRetencionNoInscripto;
            }

            set
            {
                porcentajeRetencionNoInscripto = value;
            }
        }

        public double ImporteMinimoRetencion
        {
            get
            {
                return importeMinimoRetencion;
            }

            set
            {
                importeMinimoRetencion = value;
            }
        }
    }
}