using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Impresion : IDisposable
    {

        public string Impresora { get; set; }
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private DataTable dt { get; set; }
        private string reportName { get; set; }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                              string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }


        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8,90in</PageWidth>" +
              "  <PageHeight>12.01in</PageHeight>" +
              "  <MarginTop>0,00in</MarginTop>" +
              "  <MarginLeft>0,3937in</MarginLeft>" +
              "  <MarginRight>0.00in</MarginRight>" +
              "  <MarginBottom>0.00in</MarginBottom>" +

               /*             "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8,90in</PageWidth>" +
              "  <PageHeight>12,01in</PageHeight>" +
              "  <MarginTop>1,97in</MarginTop>" +
              "  <MarginLeft>0,3937in</MarginLeft>" +
              "  <MarginRight>0.00in</MarginRight>" +
              "  <MarginBottom>0.00in</MarginBottom>" +*/
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }


        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                890,1201
               /* ev.PageBounds.Width,
                ev.PageBounds.Height*/);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private string ImpresoraPredeterminada()
        {
            //

            for (Int32 i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                { return PrinterSettings.InstalledPrinters[i].ToString(); }
            }
            return "";
        }
        private void Print(string pImpresora)
        {
            string printerName = pImpresora;//"Liquidaciones";// ImpresoraPredeterminada();//ConfigurationManager.AppSettings["Impresora"].ToString();
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;



            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("No se puede encontrar la impresora \"{0}\".", printerName);
                Console.WriteLine(msg);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrinterSettings.Copies = 1;
            printDoc.Print();
        }

        private void Run(string rs, string _datasource, DataTable _dt,string pImpresora)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = rs;
            report.DataSources.Add(new ReportDataSource(_datasource, _dt));
            Export(report);
            m_currentPageIndex = 0;
            Print(pImpresora);
        }


        private void RunDataSources(string rs, IList<DataTable> _dt, string pImpresora)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = rs;
            foreach (DataTable st in _dt)
            {
                report.DataSources.Add(new ReportDataSource(st.TableName, st));
            }

            Export(report);
            m_currentPageIndex = 0;
            Print(pImpresora);
        }


        private void RunDataSourcesParametros(string rs, IList<DataTable> _dt, IList<ReportParameter> param, string pImpresora)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = rs;
            foreach (DataTable st in _dt)
            {
                report.DataSources.Add(new ReportDataSource(st.TableName, st));
            }
            foreach (ReportParameter rparam in param)
            {
                report.SetParameters(param);
            }
            Export(report);
            m_currentPageIndex = 0;
            Print(pImpresora);
        }

        private void RunConParametros(string rs, string _datasource, IList<ReportParameter> parame, DataTable _dt, string pImpresora)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = rs;
            report.DataSources.Add(new ReportDataSource(_datasource, _dt));
            foreach (ReportParameter param in parame)
            {
                report.SetParameters(param);
            }
            Export(report);
            m_currentPageIndex = 0;
            Print(pImpresora);
        }

        private void RunConParametro(string rs, string _datasource, ReportParameter param, DataTable _dt, string pImpresora)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = rs;
            report.DataSources.Add(new ReportDataSource(_datasource, _dt));

            report.SetParameters(param);

            Export(report);
            m_currentPageIndex = 0;
            Print(pImpresora);
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
            }
        }

        public void ImprimirReporteConParametros(string _reportName, string _source, DataTable _dt, IList<ReportParameter> parametros, string pImpresora)
        {
            reportName = _reportName;
            dt = _dt;
            using (Impresion imp = new Impresion())
            {
                imp.RunConParametros(reportName, _source, parametros, _dt, pImpresora);
            }

        }
       // public string Impresora { get; set; }
        public void ImprimirReporteConDataSources(string _reportName, IList<DataTable> _dt, string pImpresora)
        {
            Impresora = pImpresora;
            using (Impresion imp = new Impresion())
            {
                imp.RunDataSources(_reportName, _dt, pImpresora);
            }

        }


        public void ImprimirReporteConDataSourcesConParametros(string _reportName, IList<DataTable> _dt, IList<ReportParameter> rparam, string pImpresora)
        {

            using (Impresion imp = new Impresion())
            {
                imp.RunDataSourcesParametros(_reportName, _dt, rparam,pImpresora);
            }

        }


        public void ImprimirReporteConParametro(string _reportName, string _source, DataTable _dt, ReportParameter parametro, string pImpresora)
        {
            reportName = _reportName;
            dt = _dt;
            using (Impresion imp = new Impresion())
            {
                imp.RunConParametro(reportName, _source, parametro, _dt,pImpresora);
            }

        }

        public void ImprimirReporte(string _reportName, string _source, DataTable _dt, string pImpresora)
        {
            reportName = _reportName;
            dt = _dt;
            using (Impresion imp = new Impresion())
            {
                imp.Run(reportName, _source, _dt,pImpresora);
            }

        }


        public static ReportParameter crearParametro(string nombre, DbType tipo, string valor)
        {
            try
            {
                ReportParameter param = new ReportParameter();
                param.Name = nombre;
                param.Values.Add(valor);

                return param;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
