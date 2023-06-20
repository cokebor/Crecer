using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class DetalleLiquidacionesMerma
    {
        private int lote;
        private string producto;
        private string causa;
        private int merma;

        public int Lote
        {
            get
            {
                return lote;
            }

            set
            {
                lote = value;
            }
        }

        public string Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public string Causa
        {
            get
            {
                return causa;
            }

            set
            {
                causa = value;
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
    }
}
