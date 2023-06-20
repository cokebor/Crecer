using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{

    public class ControladorImpresionLiquidacion : IDisposable
    {


        #region Atributos

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        #endregion

        #region Métodos privados

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            try
            {
                //Routine to provide to the report renderer, in order to save an image for each page of the report.
                //Stream stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
                Stream stream = new MemoryStream();
                m_streams.Add(stream);
                return stream;
            }
            catch (Exception ex)
            {
                /*try{ 
                Stream stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
                m_streams.Add(stream);
                return stream;
                }catch(Exception exx){ */
                throw new Exception(ex.Message);
                //}
            }

        }

       
       
       private void Export(LocalReport report ,string tipo, string nombreArchivo)
       {
           //Export the given report as an EMF (Enhanced Metafile) file.
           string deviceInfo =
           "<DeviceInfo>" +
             "  <OutputFormat>EMF</OutputFormat>" +
             "  <PageWidth>8.897638in</PageWidth>" +
            "  <PageHeight>12.00787in</PageHeight>" +
             "  <MarginTop>1.9685in</MarginTop>" +
             "  <MarginLeft>0.19685in</MarginLeft>" +
             "  <MarginRight>0in</MarginRight>" +
             "  <MarginBottom>0in</MarginBottom>" +
             "</DeviceInfo>";
           Warning[] warnings;
           m_streams = new List<Stream>();

            
                report.Render(tipo, deviceInfo, CreateStream, out warnings);
           foreach (Stream stream in m_streams)
           { stream.Position = 0; }
       }



        private void PrintPage(object sender, PrintPageEventArgs ev)
       {
           //Handler for PrintPageEvents
           Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
          ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            Rectangle adjustedRect = new Rectangle(
        ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
        ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
        890, 1201);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            m_currentPageIndex++;
           ev.HasMorePages = (m_currentPageIndex<m_streams.Count);
       }
    
       private void Print()
      {
         //
         PrintDocument printDoc;

            //String printerName = "Facturas"; //'ImpresoraPredeterminada();
            String printerName = ImpresoraPredeterminada();
          if (m_streams == null || m_streams.Count == 0)
          { return; }
   
         printDoc = new PrintDocument();
          printDoc.PrinterSettings.PrinterName = printerName;
        if (!printDoc.PrinterSettings.IsValid)
         {
             string msg = String.Format("No se pudo encontrar la Impresora \"{0}\".", printerName);
             MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
             return;
         }
         printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
          printDoc.Print();
     }
     
      private string ImpresoraPredeterminada()
      {
          //
   
          for(Int32 i = 0; i<PrinterSettings.InstalledPrinters.Count ; i++)
          {
              PrinterSettings a = new PrinterSettings();
              a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
              if (a.IsDefaultPrinter)
              { return PrinterSettings.InstalledPrinters[i].ToString(); }
          }
          return "";
      }
   
      #endregion
     
      #region Métodos públicos
      
      public void Imprimir(LocalReport argReporte)
     {
            //
            Export(argReporte,"Image","");
          m_currentPageIndex = 0;
          Print();
      }
      
      #endregion
   
      #region Soporte para implementación de interfaces
      
      #region IDisposable
      
      public void Dispose()
      {
          if (m_streams != null)
         {
              foreach (Stream stream in m_streams)
              {  stream.Close(); }
              m_streams = null;
          }
      }

        #endregion

        #endregion


        public void ExportarPDF(ReportViewer rv, string archivo)
        {
            
            string mimeType;
            string encoding;
            string filenameExtension;
            string[] streamids;
            Warning[] warnings;

            
            byte[] bytes=rv.LocalReport.Render("PDF",null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            
            string direccion = System.Windows.Forms.Application.StartupPath + @"\Comprobantes\" + DateTime.Now.Year + @"\" + DateTime.Now.ToString("MMMM").ToUpper() + @"\" + DateTime.Now.ToString("dd");
            Directory.CreateDirectory(direccion);
         //   Stream stream = new FileStream(direccion + @"\" + name + "." + fileNameExtension, FileMode.Create);

            using (FileStream fs = new FileStream(direccion + @"\" + archivo + ".pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
        
}
}