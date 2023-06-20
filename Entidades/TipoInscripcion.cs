namespace Entidades
{
    public class TipoInscripcion
    {
        private int codigo;
        private string descripcion;
        private string sigla;
        private double montoMaximo;
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

        public string Sigla
        {
            get
            {
                return sigla;
            }

            set
            {
                sigla = value;
            }
        }

        public double MontoMaximo
        {
            get
            {
                return montoMaximo;
            }

            set
            {
                montoMaximo = value;
            }
        }
    }
}