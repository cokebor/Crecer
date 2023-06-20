using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Presentacion
{
    public partial class frmInformeIVAVentas : Presentacion.frmColor
    {
        public frmInformeIVAVentas()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formato();
            try
            {
                LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;*/
        }
        private void Titulo()
        {
            this.Text = "IVA VENTAS";
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
            Utilidades.Reporte.Formato2(rvInforme, true);
        }
        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = true;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void rbPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void LlenarComboMeses() {
            if (rbMensual.Checked) {
                Utilidades.Combo.Llenar(cbMeses, new Logica.Factura().ObtenerFechasIntegracion(Singleton.Instancia.Empresa.Codigo), "Fecha", "Meses");
            }
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = Fecha();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false)) {
                    this.rvInforme.LocalReport.ReportEmbeddedResource = "";
                    this.rvInforme.RefreshReport();
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (res == true) {
                    this.rvInforme.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repIVAVentasSucursales.rdlc";
                    Listar(0, desde, hasta);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime desde, hasta;
        private bool Fecha() {
            bool res = false;
            if (rbMensual.Checked)
            {
                if (cbMeses.Items.Count > 0)
                {
                    desde = Convert.ToDateTime(cbMeses.SelectedValue + "-01");
                    hasta = Convert.ToDateTime(cbMeses.SelectedValue + "-" + DateTime.DaysInMonth(Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(0, 4)), Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(5, 2))));
                    res = true;
                }
            }
            else if (rbPersonalizado.Checked) {
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;
                res = true;
            }
            return res;
        }

        private void frmInformeIVAVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsFrutar.SP_IVASUCURSALES' Puede moverla o quitarla según sea necesario.
            

        }

        private void Listar(int pCodigoProveedor, DateTime pDesde, DateTime pHasta)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsFrutar.SP_MOVIMIENTOSBANCARIOS_SELECT' Puede moverla o quitarla según sea necesario.
            this.SP_IVASUCURSALESTableAdapter.Fill(this.dsFrutar.SP_IVASUCURSALES, pDesde, pHasta);
            this.rvInforme.RefreshReport();
            ReportParameter paramTitulo;
            if (rbMensual.Checked)
                paramTitulo = new ReportParameter("Titulo", "Periodo: " + cbMeses.Text);
            else
                paramTitulo = new ReportParameter("Titulo", "Periodo: " + pDesde + " - " + pHasta);

            rvInforme.LocalReport.SetParameters(new ReportParameter[] { paramTitulo });
            this.rvInforme.RefreshReport();
        }
    }
}
