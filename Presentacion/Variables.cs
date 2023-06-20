using System;

namespace Presentacion
{
    public static class Variables
    {
        public static string Codigo {
            get {
                return "(Codigo)";
            }
        } 

        public static DateTime FechaNula {
            get {
                return Convert.ToDateTime("01/01/1900");
            }
        }

    }
}
