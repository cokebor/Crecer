namespace Entidades
{
    public class TipoContribuyente
    {
        private int codigo;
        private string descripcion;
        private double porcentajePercepcion;
        private double porcentajeRetencion;
        private double minimoRetencion;
        private int estado;

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

        public double PorcentajePercepcion
        {
            get
            {
                return porcentajePercepcion;
            }

            set
            {
                porcentajePercepcion = value;
            }
        }
        
        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public double PorcentajeRetencion
        {
            get
            {
                return porcentajeRetencion;
            }

            set
            {
                porcentajeRetencion = value;
            }
        }

        public double MinimoRetencion
        {
            get
            {
                return minimoRetencion;
            }

            set
            {
                minimoRetencion = value;
            }
        }
    }
}