using System;
using System.Windows.Forms;

namespace Presentacion
{
	public partial class frmCambioDeCheques : Presentacion.frmColor
	{
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.CambiosCheques objECambioCheque = new Entidades.CambiosCheques();
        Entidades.CambiosChequesProveedores objECambioChequeP = new Entidades.CambiosChequesProveedores();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Cheque objLCheque = new Logica.Cheque();
        Logica.Pago objLPagoProv = new Logica.Pago();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Logica.CambiosCheques objLCambios = new Logica.CambiosCheques();
        Logica.CambiosChequesProveedores objLCambiosP = new Logica.CambiosChequesProveedores();

        public frmCambioDeCheques()
		{
			InitializeComponent();
            ConfiguracionInicial();
            
		}
        private void ConfiguracionInicial() {
            Titulo();
            Formato();
            SubscripcionMetodos();
            Estados();
            if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6) {
                rbCartera.Enabled = false;
                rbRechazados.Enabled = false;
                rbProveedor.Checked = true;
            }
        }

        private void SubscripcionMetodos()
        {
            rbCartera.CheckedChanged += SeleccionEstadoCheque;
            rbProveedor.CheckedChanged += SeleccionEstadoCheque;
            txtCodigoProveedor.TextChanged += ObtenerProveedor;
            txtCodigoProveedor.KeyDown += AccesosRapidos;
            txtCodigoProveedor.KeyPress += TeclaPresionada;
            cbRecibos.SelectedIndexChanged += CargarChequesProveedores;
            btnConfirmar.Click += Confirmar;
            this.ucFormasPagoCompras.FormularioInicial = this;

            // dgvCheques.CellClick += SeleccionChequesRechazados;
            dgvCheques.CellContentClick += SeleccionChequesRechazados;
            ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarMontos;
            ucFormasPagoCompras.ucChequesTerceros.btnChequesTerceros.Click += ActualizarMontos;
            ucFormasPagoCompras.ucContado.btnAgregar.Click += ActualizarMontos;
            ucFormasPagoCompras.ucTranferenciasBancarias.btnAgregar.Click += ActualizarMontos;
            ucFormasPagoCompras.btnEditar.Click += ActualizarMontos;
            ucFormasPagoCompras.btnEliminar.Click += ActualizarMontos;
            
            /*ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarValores;
            ucFormasPagoCompras.*/
        }

        private void ActualizarMontos(object sender, EventArgs e)
        {
            lblValores.Text = this.ucFormasPagoCompras.valores.ToString("C2");
            lblSaldo.Text = (TotalChequesRechazados() - this.ucFormasPagoCompras.valores).ToString("C2");
        }

        private void SeleccionChequesRechazados(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgvCheques.Columns["Seleccionado"].Index)
                {
                    if (e.RowIndex != -10) { 
                    DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvCheques.Rows[e.RowIndex].Cells["Seleccionado"];
                    check.Value = !(Convert.ToBoolean(check.Value));
                        
                    /*if (Convert.ToBoolean(check.Value))
                    {
                        lblTotal.Text = TotalChequesRechazados().ToString("C2");
                    }
                    else
                    {*/
                        lblTotal.Text = TotalChequesRechazados().ToString("C2");
                        //this.dgvCheques.Rows[e.RowIndex].Cells["Seleccionado"].Value = check.Value;
                        //}
                        lblSaldo.Text = (TotalChequesRechazados() - this.ucFormasPagoCompras.valores).ToString("C2");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double TotalChequesRechazados() {
            double res=0;
            foreach (DataGridViewRow item in dgvCheques.Rows)
            {
                if (Convert.ToInt32(item.Cells["Seleccionado"].Value) == 1)
                    res += Convert.ToDouble(item.Cells["Importe"].Value);
            }
            return res;
        }

        private void Confirmar(object sender, EventArgs e)
        {
            if (ValidarComprobante().Equals(false))
            {
                MessageBox.Show("Debe seleccionar un cheque para confirmar!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbProveedor.Checked && ValidarSaldo().Equals(false))
            {
                MessageBox.Show("El Saldo debe ser 0!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            try
            {
                string EstadoValor="RE";
                if (rbCartera.Checked)
                {
                    CargaDeDatosChequesDeBanco();
                    CargarAsiento();
                }
                else if (rbRechazados.Checked)
                {
                    CargaDeDatosChequesDeBanco();
                    EstadoValor = "CA";
                    CargarAsiento();
                }
                else if (rbProveedor.Checked) {
                    CargaDeDatosChequesProveedor();
                    CargarAsientoProveedores();
                }


                
                if (rbProveedor.Checked)
                {
                    objLCambiosP.Agregar(objECambioChequeP, objEAsiento);
                }
                else {
                    objLCambios.Agregar(objECambioCheque, EstadoValor, objEAsiento);
                }
                
                Limpiar();
                Estados();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaDeDatosChequesProveedor()
        {
            objECambioChequeP = new Entidades.CambiosChequesProveedores();
            objECambioChequeP.Fecha = dtFecha.Value;
            Entidades.Numerador objENumerador = new Entidades.Numerador();
            objENumerador = new Logica.Numerador().ObtenerUno(28);
            objECambioChequeP.Letra = Convert.ToChar(objENumerador.Letra);
            objECambioChequeP.PuntoDeVenta = objENumerador.PuntoVenta;
            objECambioChequeP.Numero = objENumerador.Numero;
            objECambioChequeP.Pago.Codigo = Convert.ToInt32(cbRecibos.SelectedValue);
            //objECambioChequeP.Pago.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objECambioChequeP.Usuario = Singleton.Instancia.Usuario;


            Entidades.Cheque objECheque;
            foreach (DataGridViewRow item in dgvCheques.Rows)
            {
                if (Convert.ToInt32(item.Cells["Seleccionado"].Value) == 1)
                {
                    objECheque = new Entidades.Cheque();
                    objECheque.Codigo = Convert.ToInt32(item.Cells["Codigo"].Value);
                    objECheque.Moneda = new Logica.Moneda().ObtenerUno(Convert.ToInt32(item.Cells["CodigoMoneda"].Value));
                    objECheque.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                    objECheque.CuentaBancaria.Codigo= Convert.ToInt32(item.Cells["CodigoCuentaBancaria"].Value);
                    objECambioChequeP.ChequesRechazados.Add(objECheque);
                }
            }

            ucFormasPagoCompras.ObtenerDatos();
            objECambioChequeP.FacturaEfectivo.Clear();
            objECambioChequeP.FacturaEfectivo = ucFormasPagoCompras.Efectivos;
            objECambioChequeP.ChequesTerceros.Clear();
            objECambioChequeP.ChequesTerceros = ucFormasPagoCompras.Cheques;
            objECambioChequeP.ChequesPropios.Clear();
            objECambioChequeP.ChequesPropios = ucFormasPagoCompras.ChequesPropios;
            objECambioChequeP.Tranferencias.Clear();
            objECambioChequeP.Tranferencias = ucFormasPagoCompras.Tranferencias;
        }

        private bool ValidarComprobante()
        {
            //if (rbCartera.Checked || rbRechazados.Checked) {
                foreach (DataGridViewRow item in dgvCheques.Rows)
                {
                    if (Convert.ToInt32(item.Cells["Seleccionado"].Value) == 1)
                        return true;
                }
               return false;
        }

        private bool ValidarSaldo()
        {
            
            if ((TotalChequesRechazados() - this.ucFormasPagoCompras.valores) != 0) {
                return false;
            }
            return true;
        }
        private void CargarChequesProveedores(object sender, EventArgs e)
        {
            try
            {
                dgvCheques.DataSource=objLPagoProv.ObtenerChequesUno(Convert.ToInt32(cbRecibos.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TeclaPresionada(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void ObtenerProveedor(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null)
                    {
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                        Utilidades.Combo.Llenar(cbRecibos, objLPagoProv.ObtenerPagosChequesProveedores(objEntidadProveedor.Codigo), "CodigoPago", "Recibo");
                    }
                    else {
                        lblNombreProveedor.Text = "";
                        cbRecibos.DataSource = null;
                    }
                        
                }
                else
                {
                    objEntidadProveedor = null;
                    lblNombreProveedor.Text = "";
                    cbRecibos.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccesosRapidos(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("CambioDeCheques", this));
                    break;
            }
        }

        private void SeleccionEstadoCheque(object sender, EventArgs e)
        {

                Estados();


        }

        private void Estados() {
            try
            {
                if (rbCartera.Checked || rbRechazados.Checked)
                {
                    pProveedor.Visible = false;
                    tcChequesCartera.Visible = true;
                    tcChequesProveedor.Visible = false;
                    tpCheques.Controls.Clear();
                    tpChequesCartera.Controls.Add(dgvCheques);
                    dgvCheques.DataSource = null;
                    if (rbCartera.Checked)
                        dgvCheques.DataSource = objLCheque.ObtenerEnCartera();
                    else
                        dgvCheques.DataSource = objLCheque.ObtenerRechazados();
                }
                else if (rbProveedor.Checked)
                {
                    pProveedor.Visible = true;
                    tcChequesCartera.Visible = false;
                    tcChequesProveedor.Visible = true;
                    tpChequesCartera.Controls.Clear();
                    tpCheques.Controls.Add(dgvCheques);
                    dgvCheques.DataSource = null;
                    txtCodigoProveedor.Focus();
                    //dgvCheques.DataSource = objLPagoProv.ObtenerChequesUno(Convert.ToInt32(cbRecibos.SelectedValue));
                }
                txtCodigoProveedor.Text = "";
                ucFormasPagoCompras.Limpiar();
                lblTotal.Text = 0.ToString("C2");
                lblSaldo.Text = 0.ToString("C2");
                lblValores.Text = 0.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void Titulo()
        {
            this.Text = "CAMBIO DE CHEQUES";
        }

        private void Formato() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbRecibos);
            tpCheques.BackColor = frmColor.Color;
            tpFormaDePago.BackColor = frmColor.Color;
            tpChequesCartera.BackColor = frmColor.Color;
            FormatoGrilla(dgvCheques);
            lblTotal.Text = 0.ToString("C2");
            lblSaldo.Text = 0.ToString("C2");
            lblValores.Text = 0.ToString("C2");
        }
        private void FormatoGrilla(DataGridView grilla) {
            grilla.AutoGenerateColumns = false;
            grilla.MultiSelect = true;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn item in grilla.Columns)
            {
                if (item.Name.Equals("Seleccionado"))
                {
                    item.ReadOnly = false;
                }
                else
                {
                    item.ReadOnly = true;
                }

            }
            grilla.Columns["Seleccionado"].Width = 30;
            grilla.Columns["Banco"].Width = 110;
            grilla.Columns["NroCheque"].Width = 90;
            grilla.Columns["FechaEmision"].Width = 75;
            grilla.Columns["FechaPago"].Width = 75;
            grilla.Columns["Importe"].Width = 80;
        }

        private void CargaDeDatosChequesDeBanco() {
            objECambioCheque = new Entidades.CambiosCheques();
            objECambioCheque.Fecha = dtFecha.Value;
            objECambioCheque.Usuario = Singleton.Instancia.Usuario;

            Entidades.Cheque objECheque;
            foreach (DataGridViewRow item in dgvCheques.Rows)
            {
                if (Convert.ToInt32(item.Cells["Seleccionado"].Value) == 1)
                {
                    objECheque = new Entidades.Cheque();
                    objECheque.Codigo = Convert.ToInt32(item.Cells["Codigo"].Value);
                    objECheque.Moneda = new Logica.Moneda().ObtenerUno(Convert.ToInt32(item.Cells["CodigoMoneda"].Value));
                    objECheque.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                    objECambioCheque.Cheques.Add(objECheque);
                }
            }
        }

        private void CargarAsientoProveedores()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECambioChequeP.Fecha;

            objEAsiento.FechaEmision = objECambioChequeP.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = "Cambio de Cheque: " + objECambioChequeP.Numdoc;

            Entidades.Asiento_Detalle asientoDetalle;
            foreach (Entidades.Cheque item in objECambioChequeP.ChequesRechazados)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                if (item.CuentaBancaria.Codigo != 0)
                {
                    item.CuentaBancaria = new Logica.CuentaBancaria().ObtenerUno(item.CuentaBancaria.Codigo);

                    if (objLCheque.ObtenerSiEstaConciliado(item) == 1) {
                        asientoDetalle.CuentaContable = item.CuentaBancaria.CuentaContable;
                    }
                    else {
                        asientoDetalle.CuentaContable = item.CuentaBancaria.CuentaContableValoresDiferidos;
                    }
                }
                else {
                    asientoDetalle.CuentaContable.Codigo = 10105140000;//objLFormaDePago.ObtenerUno(3).CuentaContable;
                }
                
                asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Codigo);
                asientoDetalle.Debe = item.Importe;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);

            }
            foreach (Entidades.Cheque item in objECambioChequeP.ChequesPropios)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = item.CuentaBancaria.CuentaContable;
 
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                asientoDetalle.Cheque.Codigo = item.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            foreach (Entidades.Cheque item in objECambioChequeP.ChequesTerceros)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = item.CuentaBancaria.CuentaContable.Codigo;

                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            foreach (Entidades.Factura_Efectivo item in objECambioChequeP.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(1);
                if (item.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                else
                {
                    Int64 cuenta = 0;
                    switch (Singleton.Instancia.Empresa.Codigo)
                    {
                        case 1:
                        case 2:
                        case 6:
                            cuenta = 10101020100;
                            break;
                        case 3:
                            cuenta = 10101020200;
                            break;
                        case 4:
                            cuenta = 10101020300;
                            break;
                        case 5:
                            cuenta = 10101020400;
                            break;
                        case 7:
                            cuenta = 10101020500;
                            break;

                    }
                    asientoDetalle.CuentaContable.Codigo = cuenta;
                }

                  asientoDetalle.Debe = 0;
                  asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            foreach (Entidades.Tranferencia item in objECambioChequeP.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = item.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }


        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECambioCheque.Fecha;
            objEAsiento.FechaEmision = objECambioCheque.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            if (rbCartera.Checked)
                objEAsiento.Descripcion = "Cheques en Cartera Rechazados";
            else if (rbRechazados.Checked)
                objEAsiento.Descripcion = "Anulación de Cheque en Cartera Rechazado";

            Entidades.Asiento_Detalle asientoDetalle;
            Entidades.FormaDePago objEFormaDePago;
            foreach (Entidades.Cheque item in objECambioCheque.Cheques)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(3);

                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                
                asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Codigo);
                if (rbCartera.Checked)
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = item.Importe;
                }
                else if (rbRechazados.Checked) {
                    asientoDetalle.Debe = item.Importe;
                    asientoDetalle.Haber = 0;
                }
                
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105140000;
                if (rbCartera.Checked)
                {
                    asientoDetalle.Debe = item.Importe;
                    asientoDetalle.Haber = 0;
                }
                else if (rbRechazados.Checked)
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = item.Importe;
                }
                asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Codigo);
                objEAsiento.Detalle.Add(asientoDetalle);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            dtFecha.Value = DateTime.Now;
            txtCodigoProveedor.Text = "";
            rbCartera.Checked = true;
            foreach (DataGridViewRow item in dgvCheques.Rows)
            {
                item.Cells["Seleccionado"].Value = 0;
            }
            ucFormasPagoCompras.Limpiar();
            lblTotal.Text = 0.ToString("C2");
            lblSaldo.Text = 0.ToString("C2");
            lblValores.Text = 0.ToString("C2");
        }


    }
}
