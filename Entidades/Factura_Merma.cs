using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura_Merma
    {
        public Factura_Merma() {
        //    Producto = new Producto();
         //   MovStock_Lotes = new MovStock_Lotes();
        }

        private int renglon;
     
        private int merma;
       
        private int renglonRemito;
        private int codigoRemito;

        public int Renglon
        {
            get
            {
                return renglon;
            }

            set
            {
                renglon = value;
            }
        }

        public int Merma
        {
            get
            {
                return merma;
            }

            set
            {
                merma = value;
            }
        }

        public int RenglonRemito
        {
            get
            {
                return renglonRemito;
            }

            set
            {
                renglonRemito = value;
            }
        }

        public int CodigoRemito
        {
            get
            {
                return codigoRemito;
            }

            set
            {
                codigoRemito = value;
            }
        }
    }
}
