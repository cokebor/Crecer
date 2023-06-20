using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProveedorBuscar : frmColor
    {
       Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
       Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        TextBox text;

       // DataTable dtEmpleados = new DataTable("dtEmpleados");
       DataView dvProveedores = new DataView();

       public frmProveedorBuscar(string llamada, Form f)
       {
           InitializeComponent();
           ConfiguracionInicial();
           Llamada = llamada;
           FormularioAnterior = f;
            text = null;
       }

        public frmProveedorBuscar(string llamada, Form f, TextBox t)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Llamada = llamada;
            FormularioAnterior = f;
            text = t;
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
            dgvDatos.Columns["Codigo"].Width = 37;
            dgvDatos.Columns["CUIT"].Width = 63;
            dgvDatos.Columns["Estado"].Width = 39;
        }
        
        private void Titulo()
        {
            this.Text = "BUSQUEDA DE PROVEEDORES";
        }
        
        private void CargarValores()
        {
            TraerProveedores();
        }

        private void TraerProveedores() {
            try
            {
                dvProveedores = objLogicaProveedor.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvProveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvProveedores.RowFilter = "Nombre like '%" + txtDato.Text.Trim() + "%' or CUIT like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvProveedores;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {

            llamado(dgvDatos);
        }

        private void llamado(DataGridView sender) {
            DataGridView dg = sender;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    try
                    {
                        objEntidadProveedor = objLogicaProveedor.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        DataTable dt = objLogicaProveedor.ObtenerComunicaciones(objEntidadProveedor);
                        switch (Llamada)
                        {
                            case "RemitoProveedor":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeRemitoProveedor":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "FacturaCompra":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeUtilidades":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProveedor.Focus();
                                }
                                else
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ProveedorObservaciones":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmProveedoresObservaciones)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmProveedoresObservaciones)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "CambioDeCheques":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmCambioDeCheques)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmCambioDeCheques)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NDCheque":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNDChequesRechazadosProveedores)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmNDChequesRechazadosProveedores)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PagosProveedores":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmProveedoresPagos)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmProveedoresPagos)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PagoProveedores":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmProveedoresPagos)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmProveedoresPagos)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PreciosLote":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmPreciosLotes)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmPreciosLotes)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionRemitoProveedor":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                 
                                }
                                else
                                {
                                    ((frmLiquidacionRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeStockLoteProveedor":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmStockLoteProveedorInforme)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmStockLoteProveedorInforme)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ImputacionProveedor":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmImputacionProveedores)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmImputacionProveedores)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionesProveedoresPendientes":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedoresPendientes)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedoresPendientes)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                            case "LiquidacionRemitoProveedorDeposito":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    //((frmLiquidacionRemitoProveedorDeposito)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                    text.Text = objEntidadProveedor.Codigo.ToString();
                                    
                                }
                                else
                                {
                                    ((frmLiquidacionRemitoProveedorDeposito)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "RemitoProveedorSinFacturas":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitosPendientesFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitosPendientesFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeLiquidacionesPorLote":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedoresPorLote)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedoresPorLote)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "DevolucionMercaderia":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmDevolucionMercaderia)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmDevolucionMercaderia)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "SaldoInicial":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSaldoInicialProveedor)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmSaldoInicialProveedor)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "AnulacionDeComprobantes":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmAnulacionFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmAnulacionFacturaCompra)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeStock":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmStockInforme)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmStockInforme)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionesPendientesLiquidar":
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmLiquidacionesProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionesProveedores":
                                ((frmLiquidacionesProveedores)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                break;
                            case "MovimientosCuentaCorriente":
                                Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorMovimientosCuentaCorriente(objEntidadProveedor));
                                break;
                            case "Alta":
                                Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedor(objEntidadProveedor, dt));
                                break;

                        }

                        this.Close();



                        /*
                        if (Llamada.Equals("RemitoProveedor"))
                        {
                            if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                            {
                                ((frmRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                            }
                            else
                            {
                                ((frmRemitoProveedor)formularioAnterior).txtCodigoProveedor.Text = "";
                                MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (Llamada.Equals("InformeRemitoProveedor"))
                            {
                                if (objEntidadProveedor.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = objEntidadProveedor.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmRemitoProveedorInformeFiltro)formularioAnterior).txtCodigoProveedor.Text = "";
                                    MessageBox.Show("Proveedor Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (Llamada.Equals("Alta"))
                                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedor(objEntidadProveedor, dt));
                            }
                        }
                        this.Close();*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string llamada;

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

        private Form formularioAnterior;
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

        private void frmProveedorBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objEntidadProveedor.Codigo == 0)
            {
                switch (Llamada)
                {
                    case "Alta":
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedor());
                        break;

                }

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
