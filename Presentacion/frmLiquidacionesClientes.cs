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
    public partial class frmLiquidacionesClientes : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();

        Logica.Cliente objLogicaCliente = new Logica.Cliente();

        // Logica.RemitoCliente objLRemito = new Logica.RemitoCliente();
        Logica.Factura objLFactura = new Logica.Factura();
        public frmLiquidacionesClientes()
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
            this.Text = "LIQUIDACIONES DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Remito"].Width = 101;
            dgvDatos.Columns["Cliente"].Width = 176;
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
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("LiquidacionesClientes", this));
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

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Calculos();

                    dt = objLFactura.ObtenerLiquidacionesPorCliente(desde, hasta, objEntidadCliente);
                
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

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objEntidadCliente != null)
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                    else
                        lblNombreCliente.Text = "";
                }
                else
                {
                    objEntidadCliente = null;
                    lblNombreCliente.Text = "";
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
                    InformeLiquidaciones(Convert.ToInt32(row.Cells["Codigo"].Value));

                    //Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }
        }

        private void InformeLiquidaciones(int pCodigo)
        {

            List<DataTable> lista = new List<DataTable>();
            /*if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                objESucursal.Codigo = pCodigoSucursal;
                lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo, objESucursal));
            }
            else
            {*/
                lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo));
            //}

            DataTable dtEmpresa = new DataTable();
            /*if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtEmpresa = new Logica.Empresa().ObtenerDataTable(objESucursal);
            }
            else
            {*/
                dtEmpresa = new Logica.Empresa().ObtenerDataTable();
           // }

            lista.Add(dtEmpresa);

            DataTable dtLiquidacionDetalle = new DataTable();
           /* if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionDetalle = new Logica.FacturaDetalle().ObtenerDetalleLiquidacion(pCodigo, objESucursal);
            }
            else
            {*/
                dtLiquidacionDetalle = new Logica.FacturaDetalle().ObtenerDetalleLiquidacion(pCodigo);
           // }


            int filas = 12 - dtLiquidacionDetalle.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionDetalle.Rows.Add(0);
            }
            lista.Add(dtLiquidacionDetalle);

            DataTable dtLiquidacionMerma = new DataTable();
            /*if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo, objESucursal);
            }
            else
            {*/
                dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo);
//            }

            filas = 3 - dtLiquidacionMerma.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionMerma.Rows.Add(0);
            }
            lista.Add(dtLiquidacionMerma);

            DataTable dtLiquidacionDetale = new DataTable();
           /* if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionDetale = objLFactura.ObtenerDetallesLiquidacion(pCodigo, objESucursal);
            }
            else
            {*/
                dtLiquidacionDetale = objLFactura.ObtenerDetallesLiquidacion(pCodigo);
           // }
            lista.Add(dtLiquidacionDetale);

            frmInformes informe = new frmInformes("LIQUIDACION DE CLIENTES", lista, "repLiquidacionCliente");


            informe.reportViewer1.RefreshReport();

            try
            {

                /*
                if (Singleton.Instancia.Empresa.Fiscal)
                {
                    Utilidades.Impresion cii = new Utilidades.Impresion();
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista);
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor2.rdlc", lista);
                }
                else
                {*/
                Utilidades.Formularios.AbrirFuera(informe);
                // }
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
            txtCodigoCliente.Text = "";
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
                    frmInformes informe = new frmInformes("INFORME DE LIQUIDACIONES DE CLIENTES", lista, "repLiquidacionesClientes");
                titulo = "INFORME DE LIQUIDACIONES DE CLIENTES";
                
                if (lblNombreCliente.Text.Trim().Length > 0) {
                    titulo += " Cliente: " + lblNombreCliente.Text.Trim();
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
    }
}
