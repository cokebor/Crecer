using System;
using System.Windows.Forms;

namespace Novedades
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-AR");
            //System.Globalization.CultureInfo("es-ES") culture;
            System.Globalization.CultureInfo cultura = new System.Globalization.CultureInfo("es-AR");
            cultura.NumberFormat.CurrencyDecimalSeparator = ",";
            cultura.NumberFormat.NumberDecimalSeparator = ",";
            cultura.NumberFormat.CurrencyGroupSeparator = ".";
            cultura.NumberFormat.NumberGroupSeparator = ".";
            cultura.DateTimeFormat.DateSeparator = "-";
            cultura.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";//"dd/MM/aaaa";
            
            cultura.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy";//"dd/MM/aaaa";
            
            cultura.DateTimeFormat.LongDatePattern = "dd/MM/yyyy";//"dd/MM/aaaa";

            System.Threading.Thread.CurrentThread.CurrentCulture = cultura;

            Application.Run(new frmNovedades());
            
        }
    }
}
