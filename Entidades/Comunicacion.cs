using System;

namespace Entidades
{
    [Serializable]
    public class Comunicacion : DatosGenerales
    {
        public Comunicacion() { }
        public Comunicacion(int pCodigo, string pDescripcion) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
        }

        private string descripcion;

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
