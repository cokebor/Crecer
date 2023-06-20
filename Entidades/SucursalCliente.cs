
using System;

namespace Entidades
{
    [Serializable]
    public class SucursalCliente
    {
        public SucursalCliente()
        {
            domicilio = new Domicilio();
        }
        public int CodigoCliente { get; set; }
        public int CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }

        private Domicilio domicilio;
        public Domicilio Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }
    }
}
