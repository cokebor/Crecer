using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Redondear
    {
        public static double CuatroDecimales(double numero) {
            return Math.Round(numero, 4);
        }

        public static double DosDecimales(double numero)
        {
            return Math.Round(numero, 2);
        }

        public static double SinDecimales(double numero)
        {
            return Math.Round(numero, 0);
     
        }

        public static int SinDecimalesEntero(double numero)
        {
            int a = (int)Math.Round((decimal)numero, 0, MidpointRounding.AwayFromZero);
            return a;
        }
    }
}
