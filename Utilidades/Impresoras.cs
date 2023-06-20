using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Impresoras
    {
        public static DataTable ObtenerImpresoras() {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripcion", Type.GetType("System.String"));
                foreach (string item in PrinterSettings.InstalledPrinters)
                {
                    dt.Rows.Add(item);
                }
                return dt;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
    
        }
        public static DataTable ObtenerBandejas(string pNombreImpresora)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Codigo", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Descripcion", System.Type.GetType("System.String"));
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = pNombreImpresora;
                foreach (PaperSource item in ps.PaperSources)
                {
                    dt.Rows.Add(item.RawKind, item.SourceName);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
