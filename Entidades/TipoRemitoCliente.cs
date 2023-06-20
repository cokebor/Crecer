using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoRemitoCliente
    {
        public TipoRemitoCliente() {
            numerador = new Numerador();
        }

        private int codigo;
        private string descripcion;
        private string afectaStock;
        private Numerador numerador;

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

        public string AfectaStock
        {
            get
            {
                return afectaStock;
            }

            set
            {
                afectaStock = value;
            }
        }

        public Numerador Numerador
        {
            get
            {
                return numerador;
            }

            set
            {
                numerador = value;
            }
        }
    }
}
