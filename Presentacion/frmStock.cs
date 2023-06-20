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
    public partial class frmStock : Presentacion.frmColor
    {
        Logica.Producto objLProducto = new Logica.Producto();

        Entidades.Producto objEProducto = new Entidades.Producto();



        DataView dvProductos = new DataView();
        public frmStock()
        {
            InitializeComponent();
            ConfiguracionInicial();
            Llamada = "";
        }

        public frmStock(string llamada, Form f)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Llamada = llamada;
            FormularioAnterior = f;
        }

        private string llamada;
        private Form formularioAnterior;
        public string Llamada
        {
            get
            {
                return llamada;
            }

            set
            {
                llamada = value;
            }
        }

        public Form FormularioAnterior
        {
            get
            {
                return formularioAnterior;
            }

            set
            {
                formularioAnterior = value;
            }
        }
        private void ConfiguracionInicial()
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            Formatos();
            /* BotonesInicial();*/
            CargarValores();

        }

        private void llamado(DataGridView sender)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    try
                    {
                        objEProducto = objLProducto.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        switch (Llamada)
                        {
                            case "RemitoSucursal":
                                if (objEProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoSucursal)formularioAnterior).txtCodigoProducto.Text = objEProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoSucursal)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "RemitoCliente":
                                if (objEProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoCliente)formularioAnterior).txtProducto.Text = objEProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoCliente)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ComprobanteCaja":
                                if (objEProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    if (((frmFactura)formularioAnterior).panelPorUnidad.Visible)
                                    {
                                        ((frmFactura)formularioAnterior).txtProducto.Text = objEProducto.Codigo.ToString();
                                        ((frmFactura)formularioAnterior).txtCantidad.Focus();
                                    }
                                    else
                                    {
                                        ((frmFactura)formularioAnterior).txtProducto2.Text = objEProducto.Codigo.ToString();
                                        ((frmFactura)formularioAnterior).txtCantidad2.Focus();
                                    }
                                }
                                else
                                {
                                    ((frmFactura)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCVacios":
                                if (objEProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    if (objEProducto.Vacio)
                                    {
                                        ((frmNCVacios)formularioAnterior).txtProducto.Text = objEProducto.Codigo.ToString();
                                        ((frmNCVacios)formularioAnterior).txtCantidad.Focus();
                                    }
                                    else {
                                        ((frmNCVacios)formularioAnterior).txtProducto.Text = "";
                                        MessageBox.Show("El Producto debe ser algun tipo de Vacio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    ((frmNCVacios)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ComprobanteCajaManual":
                                if (objEProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    if (((frmFacturaManual)formularioAnterior).panelPorUnidad.Visible)
                                    {
                                        ((frmFacturaManual)formularioAnterior).txtProducto.Text = objEProducto.Codigo.ToString();
                                        ((frmFacturaManual)formularioAnterior).txtCantidad.Focus();
                                    }
                                    else
                                    {
                                        ((frmFacturaManual)formularioAnterior).txtProducto2.Text = objEProducto.Codigo.ToString();
                                        ((frmFacturaManual)formularioAnterior).txtCantidad2.Focus();
                                    }
                                }
                                else
                                {
                                    ((frmFacturaManual)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                        }


                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Titulo()
        {
            this.Text = "CONSULTA DE STOCK";
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
        }

        private void CargarValores()
        {
            try
            {

                dvProductos = objLProducto.ObtenerTodos().DefaultView;

                if (cbStockCero.Checked)
                    dvProductos.RowFilter = "Stock<>0";
                dgvDatos.DataSource = dvProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            if (cbStockCero.Checked)
                dvProductos.RowFilter = "Stock<>0 and Descripcion like '%" + txtDato.Text.Trim() + "%'";
            else
                dvProductos.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvProductos;
        }

        private void cbStockCero_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockCero.Checked)
                dvProductos.RowFilter = "Stock<>0 and Descripcion like '%" + txtDato.Text.Trim() + "%'";
            else
                dvProductos.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvProductos;
        }

        frmStockPorLote frmStockPorLote;
        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                objEProducto = objLProducto.ObtenerUno(Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value));
                frmStockPorLote = new frmStockPorLote(objEProducto);
                Utilidades.Formularios.Abrir(this.MdiParent, frmStockPorLote);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                lista.Add(new Logica.Producto().ObtenerTodosConSaldo());

                frmInformes informe = new frmInformes("INFORME DE STOCK", lista, "repStock");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", "Informe de Stock al " + DateTime.Now);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();


                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            if (!Llamada.Equals(""))
                llamado(dgvDatos);
        }

        private void txtDato_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Llamada.Equals(""))
                if (e.KeyValue == (char)Keys.Enter)
                {
                    llamado(dgvDatos);
                }
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Llamada.Equals(""))
                if (e.KeyValue == (char)Keys.Enter)
                {
                    llamado(dgvDatos);
                }
        }
    }
}
