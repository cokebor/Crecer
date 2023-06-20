using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRioCuarto
{
    public static class Conexion
    {
        public static string ObtenerServidor()
        {
            // string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\conexion.ini";
          /*  string a = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            a=System.IO.Path.GetDirectoryName(a) + @"\conexion.ini";*/
            string servidor = "";

            //using (StreamReader sr = new StreamReader(@"D:\Datos\Escritorio\Proyecto\Mercado\Presentacion\bin\Debug\conexion.ini"))
            using (StreamReader sr = new StreamReader(@"conexion.ini"))
            {
                servidor = sr.ReadToEnd();
            }
            return servidor;
        }
    }
}
