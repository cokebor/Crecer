using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovStock_Lotes:DatosGenerales
    {
        public MovStock_Lotes() {
            idLote = new Lote();
        }

        private char tipo;
        private Lote idLote;
        private int cantidad;
        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public Lote IdLote
        {
            get
            {
                return idLote;
            }

            set
            {
                idLote = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
    }
}
