using System;

namespace Entidades
{
    [Serializable]
    public class Descuento
    {
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
    }
}
