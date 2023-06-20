using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRetencionesPercepciones : Presentacion.frmColor
    {
        public frmRetencionesPercepciones()
        {
            InitializeComponent();
            ConfiguracionInicial();
            try
            {
                dtDesde.Value = Convert.ToDateTime(@"1/" + dtDesde.Value.Month + @"/" + dtDesde.Value.Year);
                LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }
        private void Titulo()
        {
            this.Text = "Retenciones y Percepciones";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
        }

        private void LlenarComboMeses()
        {
            if (rbMensual.Checked)
            {
                Utilidades.Combo.Llenar(cbMeses, new Logica.Impuesto().ObtenerFechas(Singleton.Instancia.Empresa.Codigo), "Fecha", "Meses");
            }
        }


        DateTime desde, hasta;

        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = true;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
        }

        private void rbPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
        }
        List<DataTable> lista;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = Fecha();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    //dgvDatos.DataSource = null;
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (res == true)
                {
                        lista = new List<DataTable>();

                        lista.Add(new Logica.Impuesto().ObtenerRetenciones(desde, hasta, Singleton.Instancia.Empresa.Codigo));
                        lista.Add(new Logica.Impuesto().ObtenerPercepciones(desde, hasta));

                    if (lista[0].Rows.Count == 0 && lista[1].Rows.Count == 0)
                        {
                            MessageBox.Show("No se registran Impuestos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        frmInformes informe = new frmInformes("Retenciones y Percepciones", lista, "repRetencionesPercepciones");

                        string titulo = "Retenciones y Percepciones ";

                        if (rbMensual.Checked)
                        {
                            titulo += cbMeses.Text;
                        }
                        else
                        {
                            titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                        }


                    ReportParameter[] parametros = new ReportParameter[1];
                        parametros[0] = new ReportParameter("Titulo", titulo);
                        informe.reportViewer1.LocalReport.SetParameters(parametros);

                        informe.reportViewer1.RefreshReport();

                        Utilidades.Formularios.AbrirFuera(informe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Fecha()
        {
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
            else if (rbPersonalizado.Checked)
            {
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;
                res = true;
            }
            return res;
        }
    }
}
