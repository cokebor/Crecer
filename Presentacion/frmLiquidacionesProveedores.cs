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
    public partial class frmLiquidacionesProveedores : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();

        // Logica.RemitoCliente objLRemito = new Logica.RemitoCliente();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        public frmLiquidacionesProveedores()
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
            lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblComision.Text = Convert.ToDouble("0").ToString("C2");
            lblIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
        }

        private void Titulo()
        {
            this.Text = "LIQUIDACIONES DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Remito"].Width = 101;
            dgvDatos.Columns["Proveedor"].Width = 176;
            dgvDatos.Columns["Liquidacion"].Width = 101;
            dgvDatos.Columns["Neto"].Width = 90;
            dgvDatos.Columns["Comision"].Width = 80;
            dgvDatos.Columns["IVA"].Width = 80;
            dgvDatos.Columns["Total"].Width = 90;
            // dgvDatos.Columns["Cantidad"].Width = 70;
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("LiquidacionesProveedores", this));
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
                Calculos();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Validar().Equals(true))
                {
                    MessageBox.Show("No se selecciono ningun Proveedor!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Calculos();

                    dt = objLFactura.ObtenerLiquidacionesPorProveedor(desde, hasta, objEntidadProveedor);
                
                if (dt.Rows.Count == 0)
                    {

                        MessageBox.Show("No se registran Liquidaciones en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvDatos.DataSource = dt;
                Calculos();

                // dgvDatos.DataSource = objLRemito.ObtenerTodosPorClienteParaLiquidar(objEntidadCliente);

                /* DataTable dt = objLFactura.ObtenerFacturasSinImputar(Cliente);
                 foreach (DataRow dr in dt.Rows)
                 {

                     dgvDatos.Rows.Add(false, Convert.ToDateTime(dr["Fecha"]).ToString("d").Replace("-", "/"), dr["Tipo"], dr["Codigo"], dr["CodigoTipoDocumentoCliente"], dr["Numero"], Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Imputado"]), Convert.ToDouble(dr["Saldo"]), "", "");

                 }*/
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
            return res;
        }
        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
                Calculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                            //MessageBox.Show("Liquidaciones");
                            InformeLiquidacion(Convert.ToInt32(row.Cells["Codigo"].Value));

                    //Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }
        }

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

                DataTable dtImpuestos = objLFactura.OtenerImpuestos(pCodigo);
                lista.Add(dtImpuestos);


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
        }

        private void Calculos() {
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            txtCodigoProveedor.Text = "";
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            dgvDatos.DataSource = null;
            Calculos();
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
                    frmInformes informe = new frmInformes("INFORME DE LIQUIDACIONES DE PROVEEDORES", lista, "repLiquidacionesProveedores");
                titulo = "INFORME DE LIQUIDACIONES DE PROVEEDORES";

                if (lblNombreProveedor.Text.Trim().Length > 0) {
                    titulo += " Proveedor: " + lblNombreProveedor.Text.Trim();
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
            dgvDatos.DataSource = null;
        }

    }
}
