using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public static class BaseDatos
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
        public static string StringConexion
        {
            get
            {
                    return Properties.Settings.Default.StringConexion + ObtenerServidor();
            }
        }

        public static string StringConexionNave7
        {
            get
            {
                return Properties.Settings.Default.StringConexionNave7 + ObtenerServidor();
            }
        }

        public static string StringConexionVillaMaria
        {
            get
            {
                return Properties.Settings.Default.StringConexionVillaMaria + ObtenerServidor();
            }
        }

        public static string StringConexionRioCuarto
        {
            get
            {
                return Properties.Settings.Default.StringConexionRioCuarto + ObtenerServidor();
            }
        }

        public static string StringConexionGuias
        {
            get
            {
                return Properties.Settings.Default.StringConexionGuias + ObtenerServidor();
            }
        }
        public static string StringConexionSucursal6
        {
            get
            {
                return Properties.Settings.Default.StringConexionSucursal6 + ObtenerServidor();
            }
        }

        public static string StringConexionWiki
        {
            get
            {
                return Properties.Settings.Default.StringConexionWiki + ObtenerServidor();
            }
        }
        public static string StringConexionIntegracion
        {
            get
            {
                return Properties.Settings.Default.StringConexionIntegracion + ObtenerServidor();
            }
        }

        public static string StringConexionWeb
        {
            get
            {
                return Properties.Settings.Default.StringConexionWeb;
            }
        }
        /*
        public static string StringConexionMaster
        {
            get
            {
                return Properties.Settings.Default.StringConexionMaster;
            }
        }*/
    }
}
