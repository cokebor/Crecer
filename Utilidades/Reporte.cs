using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace Utilidades
{
    public static class Reporte
    {
        public static System.Environment.SpecialFolder Direccion { get; set; }
        public static void Formato(ReportViewer rep, bool impresion)
        {
            if(impresion==true)
                rep.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            
            rep.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            rep.ZoomPercent = 100;
            rep.RefreshReport();
 
        }

        public static void Formato2(ReportViewer rep, bool impresion)
        {
            if (impresion == true)
                rep.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            rep.ZoomMode = ZoomMode.PageWidth;
            rep.ZoomPercent = 100;
            rep.RefreshReport();

        }

        public static void ExportarYAbrir(ReportExportEventArgs e,IWin32Window ventana, ReportViewer rp) {
            e.Cancel = true;
            if (Direccion.Equals(""))
                Direccion = Environment.SpecialFolder.MyDocuments;



            string extension = GetRenderingExtension(e.Extension);
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Guardar Como",
                CheckPathExists = true,
                //InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                //InitialDirectory = Environment.GetFolderPath(Direccion),
                Filter = e.Extension.LocalizedName + " (*" + extension + ")|*" + extension + "|All files(*.*)|*.*",
                FilterIndex = 0
            };
            if (saveFileDialog.ShowDialog(ventana) == DialogResult.OK)
            {
                
                rp.ExportDialog(e.Extension, e.DeviceInfo, saveFileDialog.FileName);

                // Here's where I call my method to prompt user to open the file.
                OpenFileWithPrompt(saveFileDialog.FileName);
            }
        }

        private static string GetRenderingExtension(RenderingExtension extension)
        {
            switch (extension.Name)
            {
                case "PDF":
                    return ".pdf";
                case "CSV":
                    return ".csv";
                case "EXCEL":
                    return ".xls";
                case "EXCELOPENXML":
                    return ".xlsx";
                case "MHTML":
                    return ".mhtml";
                case "IMAGE":
                    return ".tif";
                case "XML":
                    return ".xml";
                case "WORD":
                    return ".doc";
                case "WORDOPENXML":
                    return ".docx";
                case "HTML4.0":
                    return ".html";
                case "NULL":
                    throw new NotImplementedException("Extension no implementada.");
            }

            throw new NotImplementedException("Extension no implementada.");
        }

        public static void OpenFileWithPrompt(string file)
        {
            if(MessageBox.Show("¿Desea abrir el archivo exportado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(file);
        }
    }
}
