using Microsoft.Reporting.WinForms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMayorCompleto : Presentacion.frmColor
    {


        public frmMayorCompleto(DateTime pDesde, DateTime pHasta,Entidades.Ejercicio pEjercicio, bool pPorFechaEmision)// DateTime pFechaInicioEjercicio)
        {
            InitializeComponent();
            try
            {
                this.Text = "LIBRO MAYOR " + pEjercicio.Descripcion;
                Utilidades.Formularios.ConfiguracionInicial(this);
                Utilidades.Reporte.Formato(reportViewer1, true);
                Listar(pDesde, pHasta, pEjercicio, pPorFechaEmision);
                this.reportViewer1.ReportExport += new ExportEventHandler(this.reportViewer1_ReportExport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void frmMayorCompleto_Load(object sender, EventArgs e)
        {
            //  this.reportViewer1.ReportExport += new ExportEventHandler(this.reportViewer1_ReportExport);
        }

        private void Listar(DateTime pDesde, DateTime pHasta, Entidades.Ejercicio pEjercicio, bool pPorFechaEmision) {
           string titulo = this.Text;
            string fecha = "Inicio Ejercio: " + pEjercicio.FechaInicio.Date.ToString("d") + " Fin Ejercicio: " + pEjercicio.FechaFinal.ToString("d");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Titulo", titulo);
            parametros[1] = new ReportParameter("Fechas", fecha);
            this.reportViewer1.LocalReport.SetParameters(parametros);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";

            
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                this.SP_MAYORCOMPLETO_SELECTBindingSource.DataMember = "SP_MAYORCOMPLETO_SELECT";
                rds.Value = this.SP_MAYORCOMPLETO_SELECTBindingSource;
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                
                this.SP_MAYORCOMPLETO_SELECTTableAdapter.Fill(this.dsFrutar.SP_MAYORCOMPLETO_SELECT, pDesde, pHasta, pEjercicio.FechaInicio, pPorFechaEmision);
            }
            else {
                //rds.Value = this.SP_MAYORCOMPLETO_SELECTBindingSource1;
                this.SP_MAYORCOMPLETO_SELECTBindingSource.DataMember = "sP_MAYORCOMPLETO_SELECTSUCURSALES";
                rds.Value = this.SP_MAYORCOMPLETO_SELECTBindingSource;
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.sP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter.Fill(this.dsFrutar.SP_MAYORCOMPLETO_SELECTSUCURSALES, pDesde, pHasta, pEjercicio.FechaInicio, pPorFechaEmision);
            }

                
            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            Utilidades.Reporte.ExportarYAbrir(e, this, this.reportViewer1);
          
        }

    }
}
