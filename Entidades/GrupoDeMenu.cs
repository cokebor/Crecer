
namespace Entidades
{
    public class GrupoDeMenu
    {
        private int codigo;
        private string descripcion;

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
    }
}
