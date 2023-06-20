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
    public partial class frmStockPorSucursal : Presentacion.frmColor
    {
        Logica.Producto objLProducto = new Logica.Producto();

        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();


        DataView dvProductos = new DataView();
        public frmStockPorSucursal()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            Formatos();
           /* BotonesInicial();*/
            CargarValores();

        }

        private void Titulo()
        {
            this.Text = "STOCK POR SUCURSAL";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 40;
            dgvDatos.Columns["Rubro"].Width = 70;
            //dgvDatos.Columns["Producto"].Width = 50;
            dgvDatos.Columns["Stock"].Width = 45;
            dgvDatos.Columns["Estado"].Width = 39;

            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                cbSucursales.SelectedValue = 1;
            }
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarProductos();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                /*objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                dgvDatos.DataSource = objLCierreDeCaja.ObtenerTodos(desde, hasta, objESucursal);*/
                CargarProductos();
            }
        }
        private void CargarProductos() {
            try
            {
                objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);

                dvProductos = objLProducto.ObtenerTodos(objESucursal).DefaultView;

                if(cbStockCero.Checked)
                    dvProductos.RowFilter = "Stock<>0";
                dgvDatos.DataSource = dvProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbStockCero_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockCero.Checked)
                dvProductos.RowFilter = "Stock<>0";
            else
                dvProductos.RowFilter = "";
            dgvDatos.DataSource = dvProductos;
        }

       // frmStockPorLote frmStockPorLote;
        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  try
            {
                objEProducto = objLProducto.ObtenerUno(Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value));
                frmStockPorLote = new frmStockPorLote(objEProducto);
                Utilidades.Formularios.Abrir(this.MdiParent,frmStockPorLote);
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      //  Bitmap bmp;

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                lista.Add(new Logica.Producto().ObtenerTodosConSaldo(objESucursal));

                frmInformes informe = new frmInformes("INFORME DE STOCK POR SUCURSAL", lista, "repStock");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", "Informe de Stock al " + DateTime.Now + " Sucursal: " + cbSucursales.Text);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();
                

                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
