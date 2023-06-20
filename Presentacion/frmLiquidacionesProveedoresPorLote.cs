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
    public partial class frmLiquidacionesProveedoresPorLote : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Lote objELote = new Entidades.Lote();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Lote objLLote = new Logica.Lote();

        // Logica.RemitoCliente objLRemito = new Logica.RemitoCliente();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        public frmLiquidacionesProveedoresPorLote()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            //txtNumeroComprobante1.txtCUIL1.Text = "R";
            LimitesTamaños();
            Formatos();
          //  BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
            //   CargarValores();
           /* lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblComision.Text = Convert.ToDouble("0").ToString("C2");
            lblIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");*/
        }

        private void Titulo()
        {
            this.Text = "LIQUIDACIONES DE PROVEEDORES POR LOTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 5);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Lote"].Width = 75;
            dgvDatos.Columns["Proveedor"].Width = 176;
            dgvDatos.Columns["Liquidacion"].Width = 101;
            dgvDatos.Columns["Producto"].Width = 176;
            dgvDatos.Columns["Cantidad"].Width = 75;

            /* dgvDatos.Columns["Lote"].Width = 80;
             dgvDatos.Columns["Can"].Width = 80;
             dgvDatos.Columns["Total"].Width = 90;*/
            // dgvDatos.Columns["Cantidad"].Width = 70;
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    if (!cbProveedores.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("InformeLiquidacionesPorLote", this));
                    break;
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("InformeLiquidacionesPorLote", this));
                    break;
            }

        }

        DataTable dt;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde, hasta;
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;

                dgvDatos.DataSource = null;

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Validar().Equals(true))
                {
                    MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                //  Calculos();

                dt = objLFactura.ObtenerLiquidacionesPorProveedor(desde, hasta, objEntidadProveedor, objEProducto, objELote);
                
                if (dt.Rows.Count == 0)
                    {

                        MessageBox.Show("No se registran Liquidaciones en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvDatos.DataSource = dt;
               // Calculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            bool res = false;
            if (!cbProveedores.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreLote); }
            /*if (!cbProveedores.Checked) { res = Utilidades.Validar.TextBoxEnBlanco(txtCodigoProveedor); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoLote); }*/
            return res;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {/*
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                            InformeLiquidacion(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }*/
        }
        /*
        private void InformeLiquidacion(int pCodigo)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
            lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo));

            DataTable dtLiquidacionDetalle = new DataTable();
            dtLiquidacionDetalle = objLFactura.ObtenerDetalleLiquidacion(pCodigo);

            //MessageBox.Show(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo).Rows[0]["Redondeo"].ToString());

            int filas = 12 - dtLiquidacionDetalle.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionDetalle.Rows.Add(0);
            }
            lista.Add(dtLiquidacionDetalle);

            DataTable dtLiquidacionMerma = new DataTable();
            dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo);

            filas = 3 - dtLiquidacionMerma.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionMerma.Rows.Add(0);
            }
            lista.Add(dtLiquidacionMerma);


            // lista.Add(new Logica.Empresa().ObtenerDataTable());
            //   lista.Add(new Logica.RemitoCliente().ObtenerDataTable(CodigoRemito));
            //   lista.Add(new Logica.RemitoCliente().ObtenerDataTableDetalle(CodigoRemito));
            // Utilidades.Formularios.AbrirFuera(new frmInformes("LIQUIDACION DE PROVEEDORES", lista, "repLiquidacionProveedor"));


            frmInformes informe = new frmInformes("LIQUIDACION DE PROVEEDORES", lista, "repLiquidacionProveedor");


            informe.reportViewer1.RefreshReport();

            


                Utilidades.Formularios.AbrirFuera(informe);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/

       /* private void Calculos() {
            double neto=0;
            double comision=0;
            double iva = 0;
            double total = 0;
            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                neto += Convert.ToDouble(fila.Cells["Neto"].Value);
                comision += Convert.ToDouble(fila.Cells["Comision"].Value);
                iva += Convert.ToDouble(fila.Cells["IVA"].Value);
                total += Convert.ToDouble(fila.Cells["Total"].Value);
            }
            lblNeto.Text = neto.ToString("C2");
            lblComision.Text = comision.ToString("C2");
            lblIVA.Text = iva.ToString("C2");
            lblTotal.Text = total.ToString("C2");
        }
        */
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            txtCodigoProveedor.Text = "";
            txtCodigoLote.Text = "";
            txtCodigoProducto.Text = "";
            cbProveedores.Checked = true;
            cbProductos.Checked = true;
            cbLotes.Checked = true;
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            dgvDatos.DataSource = null;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnBuscar_Click(sender,e);
            List<DataTable> lista = new List<DataTable>();
            try
            {
                dt.TableName = "dsLiquidaciones";
                lista.Add(dt);
        
                string titulo;
                    frmInformes informe = new frmInformes("INFORME DE LIQUIDACIONES DE PROVEEDORES", lista, "repLiquidacionesProveedoresPorLote");
                titulo = "INFORME DE LIQUIDACIONES DE PROVEEDORES";

                if (lblNombreProveedor.Text.Trim().Length > 0) {
                    titulo += " Proveedor: " + lblNombreProveedor.Text.Trim();
                }
                if (lblNombreProducto.Text.Trim().Length > 0)
                {
                    titulo += " Producto: " + lblNombreProducto.Text.Trim();
                }
                if (lblNombreLote.Text.Trim().Length > 0)
                {
                    titulo += " Lote: " + txtCodigoLote.Text.Trim();
                }

                titulo += " del " + dtDesde.Value.ToString("d") + " al " + dtHasta.Value.ToString("d");

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
        }

        private void cbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductos.Checked)
            {
                this.txtCodigoProducto.Enabled = false;
                this.lblProducto.Enabled = false;
                this.txtCodigoProducto.Text = "";
            }
            else
            {
                this.txtCodigoProducto.Enabled = true;
                this.lblProducto.Enabled = true;
                this.txtCodigoProducto.Focus();
            }
        }

        private void cbLotes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLotes.Checked)
            {
                this.txtCodigoLote.Enabled = false;
                this.lblLote.Enabled = false;
                this.txtCodigoLote.Text = "";
            }
            else
            {
                this.txtCodigoLote.Enabled = true;
                this.lblLote.Enabled = true;
                this.txtCodigoLote.Focus();
            }
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProducto.Text.Trim().Equals(""))
                {
                    objEProducto = objLProducto.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProducto.Text.Trim()));
                    if (objEProducto != null)
                        lblNombreProducto.Text = objEProducto.Descripcion;
                    else
                        lblNombreProducto.Text = "";
                }
                else
                {
                    objEProducto = new Entidades.Producto();
                    lblNombreProducto.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoLote_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoLote.Text.Trim().Equals(""))
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(txtCodigoLote.Text.Trim()));
                    if (objELote != null)
                        lblNombreLote.Text = objELote.Producto.Descripcion + " - " + objELote.Proveedor.Nombre;
                    else
                        lblNombreLote.Text = "";
                }
                else
                {
                    objELote = new Entidades.Lote();
                    lblNombreLote.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor_KeyDown_1(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }
    }
}
