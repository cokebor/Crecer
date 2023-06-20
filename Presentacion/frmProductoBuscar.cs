using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProductoBuscar : Presentacion.frmColor
    {
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();


        // DataTable dtEmpleados = new DataTable("dtEmpleados");
        DataView dvProductos = new DataView();
        public frmProductoBuscar(string llamada, Form f)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Llamada = llamada;
            FormularioAnterior = f;
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }
        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 43;
            dgvDatos.Columns["Rubro"].Width = 70;
            //dgvDatos.Columns["Producto"].Width = 50;
            dgvDatos.Columns["Estado"].Width = 39;
        }
        private void Titulo()
        {
            this.Text = "BUSQUEDA DE PRODUCTOS";
        }
        private void CargarValores()
        {
            TraerProductos();
        }

        private void TraerProductos()
        {
            try
            {
                dvProductos = objLogicaProducto.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvProductos.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvProductos;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            llamado(dgvDatos);
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
                        objEntidadProducto = objLogicaProducto.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        switch (Llamada)
                        {
                            case "RemitoProveedor":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoProveedor)formularioAnterior).txtProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoProveedor)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeSalidaDeProductos":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSalidas)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmSalidas)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                           /* case "RemitoCliente":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoCliente)formularioAnterior).txtProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoCliente)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;*/
                            case "DevolucionMercaderia":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmDevolucionMercaderia)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmDevolucionMercaderia)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PreciosLote":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmPreciosLotes)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmPreciosLotes)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                            case "LiquidacionesProveedoresPendientes":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedoresPendientes)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedoresPendientes)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                /*
                            case "ComprobanteCaja":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    if (((frmFactura)formularioAnterior).panelPorUnidad.Visible)
                                    {
                                        ((frmFactura)formularioAnterior).txtProducto.Text = objEntidadProducto.Codigo.ToString();
                                        ((frmFactura)formularioAnterior).txtCantidad.Focus();
                                    }
                                    else
                                    {
                                        ((frmFactura)formularioAnterior).txtProducto2.Text = objEntidadProducto.Codigo.ToString();
                                        ((frmFactura)formularioAnterior).txtCantidad2.Focus();
                                    }
                                }
                                else
                                {
                                    ((frmFactura)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ComprobanteCajaManual":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    if (((frmFacturaManual)formularioAnterior).panelPorUnidad.Visible)
                                    {
                                        ((frmFacturaManual)formularioAnterior).txtProducto.Text = objEntidadProducto.Codigo.ToString();
                                        ((frmFacturaManual)formularioAnterior).txtCantidad.Focus();
                                    }
                                    else
                                    {
                                        ((frmFacturaManual)formularioAnterior).txtProducto2.Text = objEntidadProducto.Codigo.ToString();
                                        ((frmFacturaManual)formularioAnterior).txtCantidad2.Focus();
                                    }
                                }
                                else
                                {
                                    ((frmFacturaManual)formularioAnterior).txtProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;*/
                            case "Alta":
                                Utilidades.Formularios.Abrir(this.MdiParent, new frmProducto(objEntidadProducto));
                                break;
                            case "InformeRemitoProveedor":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeLiquidacionesPorLote":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedoresPorLote)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedoresPorLote)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "InformeStockLoteProveedor":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmStockLoteProveedorInforme)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmStockLoteProveedorInforme)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionesPendientesLiquidar":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedorInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedorInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeRemitoCliente":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoClienteInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoClienteInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "InformeRemitoSucursal":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoSucursalInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoSucursalInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            /*case "RemitoSucursal":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoSucursal)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoSucursal)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;*/
                            case "Mermas":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmMermas)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmMermas)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeUtilidades":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProducto.Focus();
                                }
                                else
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeMermas":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmMermasInforme)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmMermasInforme)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeVentaDeProductos":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmVentaPorProductoInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                    ((frmVentaPorProductoInformeFiltro)FormularioAnterior).txtCodigoProducto.Focus();
                                }
                                else
                                {
                                    ((frmVentaPorProductoInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeVentaDeProductosDetallado":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmVentaPorProductoDetalladoInformeFiltro)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                    ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoProducto.Focus();
                                }
                                else
                                {
                                    ((frmVentaPorProductoDetalladoInformeFiltro)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeStock":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmStockInforme)formularioAnterior).txtCodigoProducto.Text = objEntidadProducto.Codigo.ToString();
                                    ((frmStockInforme)FormularioAnterior).txtCodigoProducto.Focus();
                                }
                                else
                                {
                                    ((frmStockInforme)formularioAnterior).txtCodigoProducto.Text = "";
                                    MessageBox.Show("Producto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "SaldoInicialVentas":
                                if (objEntidadProducto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSaldoInicialVentas)formularioAnterior).txtProducto.Text = objEntidadProducto.Codigo.ToString();
                                    ((frmSaldoInicialVentas)FormularioAnterior).txtProducto.Focus();
                                }
                                else
                                {
                                    ((frmSaldoInicialVentas)formularioAnterior).txtProducto.Text = "";
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

        private void txtDato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                llamado(dgvDatos);
            }
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                llamado(dgvDatos);
            }
        }
    }
}
