using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmClienteBuscar : frmColor
    {
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();


        // DataTable dtEmpleados = new DataTable("dtEmpleados");
        DataView dvClientes = new DataView();


        public frmClienteBuscar(string llamada, Form f)
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
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 43;
            dgvDatos.Columns["CUIT"].Width = 60;
            dgvDatos.Columns["Estado"].Width = 39;
            //dgvDatos.Columns["DNI"].Width = 60;
        }

        private void Titulo()
        {
            this.Text = "BUSQUEDA DE CLIENTES";
        }

        private void CargarValores()
        {
            TraerClientes();
        }

        private void TraerClientes()
        {
            try
            {
                dvClientes = objLogicaCliente.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvClientes.RowFilter = "Nombre like '%" + txtDato.Text.Trim() + "%' or CUIT like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvClientes;
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
                        objEntidadCliente = objLogicaCliente.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        DataTable dtComun = objLogicaCliente.ObtenerComunicaciones(objEntidadCliente);
                        DataTable dtDescuentos = objLogicaCliente.ObtenerDescuentos(objEntidadCliente);
                        switch (Llamada)
                        {
                            case "ComprobanteCaja":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFactura)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmFactura)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmFactura)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ComprobanteCajaManual":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFacturaManual)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmFacturaManual)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmFacturaManual)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ExportarPDF":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmExportarFacturasPDF)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmExportarFacturasPDF)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmExportarFacturasPDF)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "RemitoCliente":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoCliente)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmRemitoCliente)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmRemitoCliente)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break; 
                            case "InformeUtilidades":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmUtilidades)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmUtilidades)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ClienteObservaciones":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmClientesObservaciones)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmClientesObservaciones)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmClientesObservaciones)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "CuentasCorrientesClientes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmCuentasCorrientesClientes)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmCuentasCorrientesClientes)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmCuentasCorrientesClientes)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                            case "RemitosClientes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoClienteInforme)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmRemitoClienteInforme)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmRemitoClienteInforme)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NC":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNC)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmNC)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmNC)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCVacios":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCVacios)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmNCVacios)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmNC)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCAjuste":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCAjuste)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmNCAjuste)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmNCAjuste)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ND":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmND)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmND)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmND)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NDCheque":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNDChequesRechazados)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmNDChequesRechazados)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmNDChequesRechazados)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionRemitoCliente":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionRemitoCliente)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmLiquidacionRemitoCliente)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmLiquidacionRemitoCliente)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                            case "LiquidacionesClientes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesClientes)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmLiquidacionesClientes)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmLiquidacionesClientes)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PagosClientes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmClientesPagos)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmClientesPagos)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmClientesPagos)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "Descuentos":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmDescuentos)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmDescuentos)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmDescuentos)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionesClientesPendientes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionesClientesPendientes)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmLiquidacionesClientesPendientes)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmLiquidacionesClientesPendientes)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeRemitoCliente":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmRemitoClienteInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmRemitoClienteInformeFiltro)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmRemitoClienteInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "ComprobantesDeVenta":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmComprobantesDeVenta)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmComprobantesDeVenta)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmComprobantesDeVenta)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "SaldoInicial":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSaldoInicialCliente)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmSaldoInicialCliente)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmSaldoInicialCliente)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "InformeVentaDeProductos":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmVentaPorProductoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmVentaPorProductoInformeFiltro)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmVentaPorProductoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ImputacionCliente":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmImputacionClientes)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmImputacionClientes)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmImputacionClientes)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCLotes":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCLotes)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmNCLotes)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmNCLotes)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "InformeVentaDeProductosDetallado":
                                if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                    ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Focus();
                                }
                                else
                                {
                                    ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = "";
                                    MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "MovimientosCuentaCorriente":
                                //  Entidades.Cliente objECliente = new Entidades.Cliente();

                                if (Singleton.Instancia.Empresa.Codigo == 1)
                                {
                                    Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                                    objESucursal.Codigo = 0;
                                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteMovimientosCuentaCorriente(objEntidadCliente, objESucursal));
                                }
                                else {
                                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteMovimientosCuentaCorriente(objEntidadCliente));
                                }
                                
                                /*  if (objEntidadCliente.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                  {
                                      ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = objEntidadCliente.Codigo.ToString();
                                      ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Focus();
                                  }
                                  else
                                  {
                                      ((frmVentaPorProductoDetalladoInformeFiltro)FormularioAnterior).txtCodigoCliente.Text = "";
                                      MessageBox.Show("Cliente Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  }*/
                                break;
                            case "Alta":
                                Utilidades.Formularios.Abrir(this.MdiParent, new frmCliente(objEntidadCliente, dtComun, dtDescuentos));
                                break;
                        }

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

        private void frmClienteBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objEntidadCliente.Codigo == 0)
            {
                switch (Llamada)
                {
                    case "Alta":
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmCliente());
                        break;

                }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
