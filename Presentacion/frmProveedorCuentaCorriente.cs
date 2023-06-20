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
    public partial class frmProveedorCuentaCorriente : Presentacion.frmColor
    {
        Logica.Proveedor objLProveedores = new Logica.Proveedor();

        DataTable dtMovimientos;
        public frmProveedorCuentaCorriente()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);            
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            
            dgvDatos.Columns["Codigo"].Width = 65;
            dgvDatos.Columns["Saldo"].Width = 100;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            
        }

        private void Titulo()
        {
            this.Text = "INFORME DE SALDOS DE CUENTAS CORRIENTES DE PROVEEDORES";
        }

        private void CargarValores()
        {
            try
            {

                dtMovimientos = objLProveedores.ObtenerTodos();
                                                                                                        
                dgvDatos.Rows.Clear();
                double total = 0;
                
                foreach (DataRow dr in dtMovimientos.Rows)
                {
                    total += Convert.ToDouble(dr["Deuda"]);
                    //if(cbSaldoCero.Checked && !(Convert.ToDouble(dr["Deuda"])==0))
                    if(!cbSaldoCero.Checked || (cbSaldoCero.Checked && !(Convert.ToDouble(dr["Deuda"]) == 0)))
                         dgvDatos.Rows.Add(Convert.ToInt32(dr["Codigo"]), dr["Nombre"], dr["Deuda"]);

                }
                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView dg = sender as DataGridView;
                if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dg.SelectedRows[0];
                    if (row != null)
                    {
                        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
                        objEProveedor.Codigo = Convert.ToInt32(row.Cells["Codigo"].Value);
                        objEProveedor.Nombre = row.Cells["Proveedor"].Value.ToString();
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorMovimientosCuentaCorriente(objEProveedor));
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSaldoCero_CheckedChanged(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                DataTable dt;
                if (cbSaldoCero.Checked)
                {
                    DataRow[] filas = dtMovimientos.Select("Deuda <> 0");

                    dt = dtMovimientos.Clone();
                    foreach (DataRow dr in filas)
                    {
                        dt.ImportRow(dr);
                    }
                }
                else
                {
                    dt = dtMovimientos;
                }


                dt.TableName = "dsMovimientos";
                lista.Add(dt);
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                frmInformes informe = new frmInformes("INFORME DE SALDOS DE CUENTAS CORRIENTES DE PROVEEDORES", lista, "repCuentasCorrientesProveedores");
                string titulo = "INFORME DE SALDOS DE CUENTAS CORRIENTES DE PROVEEDORES";
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
