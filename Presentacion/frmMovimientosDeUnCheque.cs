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
    public partial class frmMovimientosDeUnCheque : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.Cheque objLCheque = new Logica.Cheque();
        public frmMovimientosDeUnCheque()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formato();
            ObtenerBancos();
        }
        private void Titulo()
        {
            this.Text = "MOVIMIENTOS DE CHEQUES";
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 30);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Grilla.Formato(dgvDatos);

            
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Banco"].Width = 140;
            dgvDatos.Columns["Numero"].Width = 80;
            dgvDatos.Columns["FechaEmision"].Width = 80;
            dgvDatos.Columns["FechaPago"].Width = 80;
            dgvDatos.Columns["Importe"].Width = 100;
        }

        public void ObtenerBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivos(), "Codigo", "Descripcion", "Todos");
                cbBancos.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                try
                {
                    dgvDatos.DataSource = objLCheque.ObtenerTodosLosCheques(Convert.ToInt32(cbBancos.SelectedValue), txtNumero.Text.Trim(), cbChequesDuplicados.Checked);

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 6:

                        if (!Convert.IsDBNull(dgvDatos.CurrentRow.Cells["Codigo"].Value)) {
                            List<DataTable> lista = new List<DataTable>();
                            int codigoCheque = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);

                            lista.Add(objLCheque.ObtenerUno(codigoCheque));

                            DataTable dtDetalleCheque = objLCheque.ObtenerTodosLosMovimientos(codigoCheque, Singleton.Instancia.Empresa.Codigo);
                            dtDetalleCheque.TableName = "dsCheques";
                            lista.Add(dtDetalleCheque);
                            
                            frmInformes informe = new frmInformes("MOVIMIENTOS DE UN CHEQUE", lista, "repChequesMov");
                            //string titulo = "COMPROBANTES DE VENTA DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
                            ReportParameter[] parametros = new ReportParameter[1];
                            parametros[0] = new ReportParameter("Titulo", "MOVIMIENTOS DE UN CHEQUE");
                            informe.reportViewer1.LocalReport.SetParameters(parametros);

                            informe.reportViewer1.RefreshReport();

                            Utilidades.Formularios.AbrirFuera(informe);
                            //lista.Add(dt);
                        }

                        //Utilidades.Formularios.Abrir(this.MdiParent, new frmDevengamientoDetalle(codigoDevengamiento));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbChequesDuplicados_CheckedChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }
    }
}
