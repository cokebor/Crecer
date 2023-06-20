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
    public partial class frmClienteCuentaCorriente : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();

        Entidades.Sucursal objESucursal = new Entidades.Sucursal();

        DataView dtMovimientos=new DataView();
        public frmClienteCuentaCorriente()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValoresCombo();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);            
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            
            dgvDatos.Columns["Codigo"].Width = 40;
            dgvDatos.Columns["Saldo"].Width = 100;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
           
        }

        private void Titulo()
        {
            this.Text = "INFORME DE SALDOS DE CUENTAS CORRIENTES DE CLIENTES";
        }

        private void CargarValoresCombo()
        {
            try
            {
         
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todas");
                cbSucursales.SelectedValue = 0;
                }
       
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
                        Entidades.Cliente objECliente = new Entidades.Cliente();
                        objECliente.Codigo = Convert.ToInt32(row.Cells["Codigo"].Value);
                        objECliente.Nombre = row.Cells["Cliente"].Value.ToString();
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteMovimientosCuentaCorriente(objECliente, objESucursal));
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
                DataTable dt=new DataTable();
                DataRow[] filas;
                if (cbSaldoCero.Checked)
                {
                    //DataRow[] filas = dtMovimientos.Select("Deuda <> 0");
                    filas = dtMovimientos.Table.Select("Deuda<>0 AND ( Nombre Like '%" + txtDato.Text.Trim() + "%' OR CUIT like '%" + txtDato.Text.Trim() + "%')");
                    
                    
                }
                else {
                    filas = dtMovimientos.Table.Select("( Nombre Like '%" + txtDato.Text.Trim() + "%' OR CUIT like '%" + txtDato.Text.Trim() + "%')");
                }
                dt = dtMovimientos.Table.Clone();
                
                foreach (DataRow dr in filas)
                {
                    dt.ImportRow(dr);
                }
                
                dt.TableName = "dsMovimientos";
                lista.Add(dt);
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                frmInformes informe = new frmInformes("INFORME DE SALDOS DE CUENTAS CORRIENTES DE CLIENTES", lista, "repCuentasCorrientesClientes");

                string titulo = "INFORME DE SALDOS DE CUENTAS CORRIENTES DE CLIENTES";
                string titulo2=" ";
                if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                {
                    titulo2 = "Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }


                
                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Titulo", titulo);
                parametros[1] = new ReportParameter("Titulo2", titulo2);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void CargarValores() {
            /*if (dgvDatos.Rows.Count > 0)
                dgvDatos.Rows.Clear();
                */

            try
            {

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dtMovimientos = objLCliente.ObtenerTodos(objESucursal).DefaultView;
                }
                else
                    dtMovimientos = objLCliente.ObtenerTodos().DefaultView;





                //dgvDatos.Rows.Clear();
           
                    /*
                    foreach (DataRow dr in dtMovimientos.Rows)
                    {
                        total += Convert.ToDouble(dr["Deuda"]);
                        if (!cbSaldoCero.Checked || (cbSaldoCero.Checked && !(Convert.ToDouble(dr["Deuda"]) == 0)))
                            dgvDatos.Rows.Add(Convert.ToInt32(dr["Codigo"]), dr["Nombre"], dr["Deuda"]);

                    }*/
                    if (!cbSaldoCero.Checked)
                {
                    dtMovimientos.RowFilter = "Nombre Like '%" + txtDato.Text.Trim() + "%' OR CUIT like '%" + txtDato.Text.Trim() + "%'";
                }
                else {
                    dtMovimientos.RowFilter = "Deuda<>0 AND ( Nombre Like '%" + txtDato.Text.Trim() + "%' OR CUIT like '%" + txtDato.Text.Trim() + "%')";
                }

                dgvDatos.DataSource = dtMovimientos;

                double total = 0;
                foreach (DataRowView dr in dtMovimientos)
                {
                    total += Convert.ToDouble(dr["Deuda"]);
                }

                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmClienteCuentaCorriente_Load(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            CargarValores();
        }
    }
}
