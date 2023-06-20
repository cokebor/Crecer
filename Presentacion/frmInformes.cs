using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmInformes : Presentacion.frmColor
    {

        public frmInformes() { }
        public frmInformes(string nombreInforme, List<DataTable> dt, string nombreReporte, bool impresion=true, bool botones=false)
        {
            InitializeComponent();
            this.Text = nombreInforme;
            DataTables = dt;
            Reporte = nombreReporte;
            CargarReporte(impresion);
            panel.Visible = botones;
        }
    


        private List<DataTable> dataTables;
        private string reporte;

        public string Reporte
        {
            get
            {
                return reporte;
            }

            set
            {
                reporte = value;
            }
        }

        public List<DataTable> DataTables
        {
            get
            {
                return dataTables;
            }

            set
            {
                dataTables = value;
            }
        }

        private void frmInformes_Load(object sender, EventArgs e)
        {


        }

        private void CargarReporte(bool impresion) {
            ReportDataSource ds;
            
            //ds.Name = "DataSet1";
            //ds.Value = DataTable;
            reportViewer1.LocalReport.DataSources.Clear();
            int i = 1;
            foreach (DataTable d in DataTables)
            {
                ds = new ReportDataSource();
                
                 ds.Name = d.TableName;//"DataSet" + i;
                
                ds.Value = d;
               // reportViewer1.PrinterSettings.Copies = 2;
                
                reportViewer1.LocalReport.DataSources.Add(ds);
                i++;
            }

            // ReportParameter Titulo = new ReportParameter("Titulo", "hola");



            //reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reportes\\" + Reporte + ".rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes." + Reporte + ".rdlc";

            Utilidades.Reporte.Formato(reportViewer1, impresion);
        }

        private string ObtenerDatosFacturaOriginal() {
            ReportParameterInfoCollection r = reportViewer1.LocalReport.GetParameters();
            foreach (var item in r)
            {
                if (item.Name.Equals("Factura"))
                {
                    return item.Values[0].ToString();
                }
            }
            return "";
        }
        private void ORIGINAL_Click(object sender, EventArgs e)
        {
            

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
            parametros[1] = new ReportParameter("Factura", ObtenerDatosFacturaOriginal());
            reportViewer1.LocalReport.SetParameters(parametros);


            this.reportViewer1.RefreshReport();
        }

        private void btnDuplicado_Click(object sender, EventArgs e)
        {
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
            parametros[1] = new ReportParameter("Factura", ObtenerDatosFacturaOriginal());
            reportViewer1.LocalReport.SetParameters(parametros);


            this.reportViewer1.RefreshReport();
        }

        private void btnTriplicado_Click(object sender, EventArgs e)
        {
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", "TRIPLICADO");
            parametros[1] = new ReportParameter("Factura", ObtenerDatosFacturaOriginal());
            reportViewer1.LocalReport.SetParameters(parametros);


            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            Utilidades.Reporte.ExportarYAbrir(e, this, this.reportViewer1);
        }
    }
}
