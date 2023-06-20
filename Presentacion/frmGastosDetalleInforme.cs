using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{

    public partial class frmGastosDetalleInforme : Presentacion.frmColor
    {

        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();

        Logica.Caja objLogicaCaja = new Logica.Caja();

        public frmGastosDetalleInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formato();
            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            CargarValores();
            //TraerGastos();
            //PintarGrilla();
            cbConceptos.SelectedIndexChanged += CbConceptos_SelectedIndexChanged;

        }

        private void CbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            //PintarGrilla();
            CalcularTotal();
        }

        private void Titulo()
        {
            this.Text = "INFORME DE GASTOS";
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbConceptos);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Sucursal"].Width = 100;
            dgvDatos.Columns["Numero"].Width = 100;
            dgvDatos.Columns["Gasto"].Width = 200;
            dgvDatos.Columns["Monto"].Width = 110;
            dgvDatos.Columns["Observaciones"].Width = 300;

            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        public void CargarValores()
        {
            try
            {
                //Utilidades.Combo.Llenar(cbConceptos, objLCuentaContable.ObtenerGastosDevengamientos(), "Codigo", "Nombre", "Todos");
                Utilidades.Combo.Llenar(cbConceptos, objLCuentaContable.ObtenerGastos2(), "Codigo", "Nombre", "Todos");
                //CargarTiposMovimientos();
                cbConceptos.SelectedValue = 0;
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todas");
                    cbSucursales.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PintarGrilla()
        {
            /*double total=0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToDouble(item.Cells["Monto"].Value) != Convert.ToDouble(item.Cells["Total"].Value))
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new Font(dgvDatos.Font, FontStyle.Bold);
                    item.Cells["Monto"].Style = style;
                    
                }
                total += Convert.ToDouble(item.Cells["Monto"].Value);
            }
            lblTotal.Text = total.ToString("C2");*/
        }

        void CalcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                total += Convert.ToDouble(item.Cells["Monto"].Value);
            }
            lblTotal.Text = total.ToString("C2");
        }

        DataTable dt = new DataTable();
        DateTime desde, hasta;
        void TraerGastos()
        {
            try
            {
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dt = objLogicaCaja.ObtenerGastosSucursales(Convert.ToInt64(cbConceptos.SelectedValue), desde, hasta, objESucursal);
                }
                else
                {
                    dt= objLogicaCaja.ObtenerGastosSucursales(Convert.ToInt64(cbConceptos.SelectedValue), desde, hasta);
                    
                }
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbConceptos);

            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbConceptos.SelectedIndex != -1)
            {
                try
                {
                    //objECuenta = objLCuentaContable.ObtenerUno(Convert.ToInt32(cbConceptos.SelectedValue));
                    TraerGastos();

                    CalcularTotal();
                    //    PintarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*
         * 
         *                 if (Singleton.Instancia.Empresa.Codigo == 1) {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dt= objLVenta.ObtenerTodosPorLote(objELote, desde, hasta, objESucursal);
                    dgvDatos.DataSource = dt;
                    lblCantidadMerma.Text = objLMerma.ObtenerCantidad(objELote, desde, hasta, objESucursal).ToString();
                    PonerNegrita();
                }
                else { 
                     dt = objLVenta.ObtenerTodosPorLote(objELote, desde, hasta);
                    dgvDatos.DataSource = dt;
                    lblCantidadMerma.Text = objLMerma.ObtenerCantidad(objELote, desde, hasta).ToString();
                    PonerNegrita();
                }*/
        private void frmGastosInforme_Load(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvDatos.Columns[e.ColumnIndex].Name)
                {
                    case "Detalle":
                        int codigoCaja = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCaja"].Value);
                        List<DataTable> listaDt = new List<DataTable>();
                        if (Singleton.Instancia.Empresa.Codigo == 1)
                        {
                            Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                            objESucursal.Codigo = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoSucursal"].Value);
                            objESucursal = new Logica.Sucursal().ObtenerSucursal(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoSucursal"].Value));

                            listaDt = Logica.Informes.CajaGastos(codigoCaja, objESucursal.RazonSocial);

                        }
                        else {
                        
                        }
                        /*desde = dtDesde.Value.Date;
                        hasta = dtHasta.Value.Date;
                        if (Singleton.Instancia.Empresa.Codigo == 1)
                        {
                            Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                            objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                            dt = objLogicaCaja.ObtenerGastosSucursales(Convert.ToInt64(cbConceptos.SelectedValue), desde, hasta, objESucursal);
                        }
                        else
                        {
                            dt = objLogicaCaja.ObtenerGastosSucursales(Convert.ToInt64(cbConceptos.SelectedValue), desde, hasta);

                        }
                        dgvDatos.DataSource = dt;
                        */

                        // if (objECaja.TipoDocumentoCaja.Codigo == 1)
                        InformeCaja(Logica.Informes.CajaGastos(codigoCaja, Singleton.Instancia.Empresa.NombreSucursal), "repCajaGastos");
                       // else
                       //     InformeCaja(Logica.Informes.CajaDepositos(codigo, Singleton.Instancia.Empresa.NombreSucursal), "repCajaDepositos");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void InformeCaja(int pCodigoSucursal, int codigoCaja)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();


                Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE CAJA", lista, informe));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void InformeCaja(List<DataTable> lista, String informe)
        {
            try
            {
                Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE CAJA", lista, informe));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            //PintarGrilla();
            CalcularTotal();
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            //PintarGrilla();
            CalcularTotal();
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            //PintarGrilla();
            CalcularTotal();
        }

        private void frmGastosDetalleInforme_Load(object sender, EventArgs e)
        {

        }

 

        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran datos para exportar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                dt.TableName = "dsGastos";
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                lista.Add(dt);

                string titulo = "Informe de Gastos";

                if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                {
                    titulo += " Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }



                titulo += " Gasto: " + cbConceptos.Text.Trim();




                frmInformes informe = new frmInformes("INFORME DE GASTOS", lista, "repGastos");
                titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                //string titulo = "COMPROBANTES DE VENTA DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
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
