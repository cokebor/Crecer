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
    public partial class frmRemitosPendientesFacturaCompra : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.RemitoProveedor objLRemitoProveedor = new Logica.RemitoProveedor();

        public frmRemitosPendientesFacturaCompra()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
             
             CargarValores();
        }

        private void Titulo()
        {
            this.Text = "REMITOS DE PROVEEDORES CON FACTURAS PENDIENTES";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
        }

        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Formularios.ConfiguracionInicial(this);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Fecha"].Width = 100;
            dgvDatos.Columns["Proveedor"].Width = 350;
            dgvDatos.Columns["Remito"].Width = 150;

        }

        private void CargarValores()
        {

            try
            {
                dt= objLRemitoProveedor.ObtenerRemitosSinFacturas(objEntidadProveedor);
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbProveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedores.Checked)
            {
                this.txtCodigoProveedor.Enabled = false;
                this.lblProveedor.Enabled = false;
                this.txtCodigoProveedor.Text = "";
            }
            else
            {
                this.txtCodigoProveedor.Enabled = true;
                this.lblProveedor.Enabled = true;
                this.txtCodigoProveedor.Focus();
            }
            dgvDatos.DataSource = null;
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null)
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                    else
                        lblNombreProveedor.Text = "";
                }
                else
                {
                    objEntidadProveedor = new Entidades.Proveedor();
                    lblNombreProveedor.Text = "";
                }
                dgvDatos.DataSource = null;
                // CargarValores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    if (!cbProveedores.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("RemitoProveedorSinFacturas", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void frmRemitosPendientesFacturaCompra_Load(object sender, EventArgs e)
        {

        }

        DataTable dt;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se selecciono ningun Proveedor!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarValores();
        }

        private bool Validar()
        {
            bool res = false;
            if (!cbProveedores.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor); }
            return res;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }
        }

        private void Informe(int pCodigoRemito)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                lista.Add(new Logica.RemitoProveedor().Obtener(pCodigoRemito));
                lista.Add(new Logica.RemitoProveedor().ObtenerDetalle(pCodigoRemito));
                Utilidades.Formularios.AbrirFuera(new frmInformes("REMITO DE PROVEEDOR", lista, "repRemitosProveedores"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoProveedor.Text = "";
            cbProveedores.Checked = true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //btnBuscar_Click(sender, e);
            List<DataTable> lista = new List<DataTable>();
            try
            {
                dt.TableName = "dsRemitos";
                lista.Add(dt);

                string titulo;
                frmInformes informe = new frmInformes("INFORME DE REMITOS CON FACTURAS PENDIENTES", lista, "repRemitosSinFacturas");
                titulo = "INFORME DE REMITOS CON FACTURAS PENDIENTES";

                if (lblNombreProveedor.Text.Trim().Length > 0)
                {
                    titulo += " Proveedor: " + lblNombreProveedor.Text.Trim();
                }

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
    }
}
