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
    public partial class frmChequesListado : Presentacion.frmColor
    {
        public frmChequesListado()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "LISTADO DE CHEQUES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTiposEstados);
        }

        private void CargarValores() {
            try
            {
                Utilidades.Combo.Llenar(cbTiposEstados, new Logica.TipoEstadoValor().ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            rbEmision.Checked = true;
            Utilidades.Combo.SeleccionarPrimerValor(cbTiposEstados);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;

            try
            {

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
            {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                char rango;
                if (rbEmision.Checked)
                {
                    rango = 'E';
                }
                else if (rbVencimiento.Checked) {
                    rango = 'V';
                } else {
                    rango = 'I';
                }



            List<DataTable> lista = new List<DataTable>();
            DataTable dt = new Logica.Cheque().ObtenerChequesPorEstado(desde, hasta, rango, cbTiposEstados.SelectedValue.ToString());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Cheques en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lista.Add(dt);


            string titulo = "Listado de Cheques";
            titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");

                
                frmInformes informe;
                if (rango.Equals('I'))
                    informe = new frmInformes("INFORME DE CHEQUES", lista, "repCheques");
                else
                    informe = new frmInformes("INFORME DE CHEQUES", lista, "repChequesOrden");
                ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Titulo", titulo);
            parametros[1] = new ReportParameter("TipoEstadoValor", cbTiposEstados.Text.Trim());
                

            informe.reportViewer1.LocalReport.SetParameters(parametros);

            informe.reportViewer1.RefreshReport();


            Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
