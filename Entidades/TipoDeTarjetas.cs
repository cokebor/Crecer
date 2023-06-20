using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDeTarjetas:DatosGenerales
    {
        public TipoDeTarjetas(){
            proveedor=new Proveedor();
    }
        private string descripcion;
        private Proveedor proveedor;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
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
    }
}
