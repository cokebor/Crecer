using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmFormasDePago : frmColor
    {
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Moneda objLMoneda = new Logica.Moneda();

        List<Entidades.Cheque> cheques;
        List<Entidades.Cheque> chequesPropios;
        List<Entidades.Tranferencia> tranferencias;
        List<Entidades.Factura_Efectivo> listaFacturaEfectivo;
        Entidades.Cheque cheque;
        Entidades.Tranferencia tranferencia;
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        frmChequesCartera frmCheque = new frmChequesCartera();

        private string tipodocumento;
        public frmFormasDePago(string tipoDocumento, Form f)
        {
            
            Cheques = new List<Entidades.Cheque>();
            ChequesPropios = new List<Cheque>();
            ListaFacturaEfectivo = new List<Entidades.Factura_Efectivo>();
            Tranferencias = new List<Tranferencia>();
            FormularioAnterior = f;
            Tipodocumento = tipoDocumento;
            InitializeComponent();
            ConfiguracionInicial();

            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucCheque.btnAgregar.Click += new System.EventHandler(this.btnAgregarCheque_Click);
            this.ucChequePropio.btnAgregar.Click += new System.EventHandler(this.btnAgregarChequePropio_Click);
            this.ucChequesTerceros.btnChequesTerceros.Click += new System.EventHandler(this.btnChequesTerceros_Click);
            this.ucTranferenciasBancarias.btnAgregar.Click += new System.EventHandler(this.btnTranferencia_Click);
            this.ucCheque.cmsBanco.Items["agregarToolStripMenuItem"].Click += new EventHandler(this.btnAgregarBanco_Click);

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

        private double total;
        private double valores;
        private double saldo;

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public List<Factura_Efectivo> ListaFacturaEfectivo
        {
            get
            {
                return listaFacturaEfectivo;
            }

            set
            {
                listaFacturaEfectivo = value;
            }
        }

        public List<Cheque> Cheques
        {
            get
            {
                return cheques;
            }

            set
            {
                cheques = value;
            }
        }

        public double Valores
        {
            get
            {
                return valores;
            }

            set
            {
                valores = value;
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public string Tipodocumento
        {
            get
            {
                return tipodocumento;
            }

            set
            {
                tipodocumento = value;
            }
        }

        public List<Cheque> ChequesPropios
        {
            get
            {
                return chequesPropios;
            }

            set
            {
                chequesPropios = value;
            }
        }

        public List<Tranferencia> Tranferencias
        {
            get
            {
                return tranferencias;
            }

            set
            {
                tranferencias = value;
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);

            Formatos();
            if (Tipodocumento.Equals("Ventas"))
                CargarValoresVentas();
            else if (Tipodocumento.Equals("Compras"))
                CargarValoresCompras();

        }
        private void Titulo()
        {
            this.Text = "FORMAS DE PAGO";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe"].Width = 90;
        }

        private void CargarValoresVentas()
        {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosVentasFormasPago(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarValoresCompras()
        {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosComprasFormasPago(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormasDePago.Text.Equals("CONTADO"))
            {
                ucContado.Visible = true;
                ucCheque.Visible = false;
                ucChequePropio.Visible = false;
                ucChequesTerceros.Visible = false;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS") && Tipodocumento.Equals("Ventas"))
            {
                ucContado.Visible = false;
                ucCheque.Visible = true;
                ucChequePropio.Visible = false;
                ucChequesTerceros.Visible = false;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS") && Tipodocumento.Equals("Compras"))
            {
                ucContado.Visible = false;
                ucCheque.Visible = false;
                ucChequePropio.Visible = false;
                ucChequesTerceros.Visible = true;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE PROPIO") && Tipodocumento.Equals("Compras"))
            {
                ucChequePropio.txtLibrador.Text = Singleton.Instancia.Empresa.RazonSocial;
                ucChequePropio.ucCUIT.CargarCUIT(Singleton.Instancia.Empresa.CUIT);

                ucContado.Visible = false;
                ucCheque.Visible = false;
                ucChequePropio.Visible = true;
                ucChequesTerceros.Visible = false;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("TRANSFERENCIA BANCARIA") /*&& Tipodocumento.Equals("Compras")*/)
            {
                ucContado.Visible = false;
                ucCheque.Visible = false;
                ucChequePropio.Visible = false;
                ucChequesTerceros.Visible = false;
                ucTranferenciasBancarias.Visible = true;
            }
            try
            {
                objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTranferencia_Click(object sender, EventArgs e)
        {
            if (this.ucTranferenciasBancarias.ValidarTranferencia().Equals(true))
            {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucTranferenciasBancarias.txtImporte.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 5)// && Convert.ToInt32(fila.Cells["CodigoMoneda"].Value) == Convert.ToInt32(objE.Moneda))
                {
                    MessageBox.Show("Forma de Pago ya ingresada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double cotizacion = Convert.ToDouble(this.ucTranferenciasBancarias.lblCotizacion.Text);
            double importe = Convert.ToDouble(this.ucTranferenciasBancarias.txtImporte.Text);
            double total = cotizacion * importe;

            /*
            if (Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue) == 1)
            {
                if (TipoDoc.Equals("CR") && Efectivo < total)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (TipoDoc.Equals("CR") && Dolares < importe)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }*/


            //dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucTranferenciasBancarias.objEMoneda.Codigo, this.ucTranferenciasBancarias.objEMoneda.Descripcion, cotizacion, importe, total.ToString("C4"), this.ucTranferenciasBancarias.objECuentaBancaria.CuentaContable.Codigo);
            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucTranferenciasBancarias.objEMoneda.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Descripcion + " Nº Cuenta: "
                + this.ucTranferenciasBancarias.objECuentaBancaria.NumeroCuenta + " - " + this.ucTranferenciasBancarias.objEMoneda.Descripcion,
                cotizacion, importe, total.ToString("C4"), this.ucTranferenciasBancarias.objECuentaBancaria.CuentaContable.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Codigo, null, null, null, null, null, this.ucTranferenciasBancarias.objECuentaBancaria.Codigo);

            Valores += total;
           // Total += total;
            ActualizarValores();
            LimpiarTranferencia();
        }

        private void LimpiarTranferencia()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucTranferenciasBancarias.cbBancos);
            this.ucTranferenciasBancarias.txtImporte.Text = "";
        }

        private void frmFormasDePago_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregarBanco_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this.MdiParent, new frmBancos());
            Utilidades.Formularios.Abrir(this.MdiParent, new frmBancos());
            busqueda = "Bancos";
        }

        private void btnChequesTerceros_Click(object sender, EventArgs e) {
            /*foreach (DataGridViewRow dd in this.dgvDatos.Rows)
            {
                if (Convert.ToUInt32(dd.Cells["FormaDePago"].Value) == 3)
                {
                    double total = Convert.ToDouble(dd.Cells["Cotizacion"].Value) * Convert.ToDouble(dd.Cells["Importe2"].Value);
                    dgvDatos.Rows.Remove(dd);
                    Valores -= total;
                    ActualizarValores();
                }
            }*/
            for (int i = dgvDatos.Rows.Count-1; i >=0 ; i--) {
                if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3) {
                    double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                    dgvDatos.Rows.RemoveAt(i);
                    Valores -= total;
                    ActualizarValores();
                }
            }
            //frmCheque.ShowDialog();
            Utilidades.Formularios.Abrir(this.MdiParent, frmCheque);
        }



        private void btnAgregarEfectivo_Click(object sender, EventArgs e)
        {
            if (this.ucContado.ValidarEfectivo().Equals(true))
            {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucContado.txtImporte.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1 && Convert.ToInt32(fila.Cells["CodigoMoneda"].Value) == Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue))
                {
                    MessageBox.Show("Forma de Pago ya ingresada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double cotizacion = Convert.ToDouble(this.ucContado.lblCotizacion.Text);
            double importe = Convert.ToDouble(this.ucContado.txtImporte.Text);
            double total = cotizacion * importe;
            

            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C4"),objEFormaDePago.CuentaContable.Codigo);
            Valores += total;
            ActualizarValores();
            LimpiarEfectivo();
        }

        private void LimpiarEfectivo()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucContado.cbMoneda);
            this.ucContado.txtImporte.Text = "";
        }

        private void LimpiarCheque()
        {
            //this.ucCheque.LimpiarCheques();
            this.ucChequePropio.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            
        }

        private void LimpiarChequeTerceros()
        {
            //this.ucCheque.LimpiarCheques();
            this.ucCheque.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);

        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {

            Entidades.Cheque cheque = this.ucCheque.Cheque();
            if (cheque.Librador != null)
            {


                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3 && Convert.ToInt32(fila.Cells["CodigoBanco"].Value) == Convert.ToInt32(cheque.Banco.Codigo) && fila.Cells["NumeroCheque"].Value.Equals(cheque.NumeroCheque))
                    {
                        MessageBox.Show("Cheque ya ingresado en este comprobante.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (Utilidades.Validar.ValidarFechas(cheque.FechaEmision, cheque.FechaPago).Equals(false))
                {
                    MessageBox.Show("Fecha Emision no puede ser inferior a Fecha de Pago", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Utilidades.Validar.ValidaCUIT(this.ucCheque.ucCUIT.Valor))
                {
                    MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucCheque.ucCUIT.txtCUIL1.Focus();
                    return;
                }


                double total = cheque.Moneda.Cotizacion * cheque.Importe;
                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C4"), objEFormaDePago.CuentaContable.Codigo, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit);
                Valores += total;
                //LimpiarCheque();
                LimpiarChequeTerceros();
                ActualizarValores();
            }
        }
        
        private void btnAgregarChequePropio_Click(object sender, EventArgs e)
        {
            Entidades.Cheque cheque=new Cheque();
            try
            {

                cheque = this.ucChequePropio.Cheque();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cheque.Librador != null)
            {


                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 6 && Convert.ToInt32(fila.Cells["CodigoBanco"].Value) == Convert.ToInt32(cheque.Banco.Codigo) && fila.Cells["NumeroCheque"].Value.Equals(cheque.NumeroCheque))
                    {
                        MessageBox.Show("Cheque ya ingresado en este comprobante.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (Utilidades.Validar.ValidarFechas(cheque.FechaEmision, cheque.FechaPago).Equals(false))
                {
                    MessageBox.Show("Fecha Emision no puede ser inferior a Fecha de Pago", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Utilidades.Validar.ValidaCUIT(cheque.Cuit))
                {
                    MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucCheque.ucCUIT.txtCUIL1.Focus();
                    return;
                }


                double total = cheque.Moneda.Cotizacion * cheque.Importe;

                Int64 cuenta;
               /* if (cheque.FechaPago <= DateTime.Now.Date.AddDays(1))
                {
                    cuenta = cheque.CuentaBancaria.CuentaContable.Codigo;
                }
                else*/
                    cuenta = cheque.CuentaBancaria.CuentaContableValoresDiferidos.Codigo;

                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C4"), cuenta/*cheque.CuentaBancaria.CuentaContable.Codigo*/, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit, cheque.CuentaBancaria.Codigo);
                Valores += total;
                LimpiarCheque();
                ActualizarValores();
            }
            
        }
        public void ActualizarValores()
        {
            Saldo = Utilidades.Redondear.CuatroDecimales(Total) - Utilidades.Redondear.CuatroDecimales(Valores);
            lblValores.Text = Valores.ToString("C2");
            lblSaldo.Text = Saldo.ToString("C2");
            lblTotal.Text = Total.ToString("C2");
        }

        public static string busqueda = "";
        private void frmFormasDePago_Activated(object sender, EventArgs e)
        {
            try
            {
                if (busqueda.Equals("Bancos"))
                    this.ucCheque.ObtenerBancos();
                if (busqueda.Equals("ChequesTerceros")) {
                    
                    foreach (DataGridViewRow dr in frmCheque.dgvDatos.Rows) {
                        if (Convert.ToBoolean(dr.Cells["Seleccionado"].Value)) {
                            objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
                            double total = Convert.ToDouble(dr.Cells["Cotizacion"].Value) * Convert.ToDouble(dr.Cells["Importe2"].Value);
                            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, objEFormaDePago.CuentaContable.Codigo, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0,dr.Cells["Codigo"].Value);

                            Valores += total;
                            ActualizarValores();
                        }
                        
                    }
                    busqueda = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ObtenerDatos()
        {
            ListaFacturaEfectivo.Clear();
            Cheques.Clear();
            ChequesPropios.Clear();
            Tranferencias.Clear();

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                Entidades.Factura_Efectivo facturaEfectivo;
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1)
                {
                    facturaEfectivo = new Entidades.Factura_Efectivo();
                    facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    facturaEfectivo.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    listaFacturaEfectivo.Add(facturaEfectivo);
                }

                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3 )
                {
                    cheque = new Entidades.Cheque();
                    cheque.Codigo = Convert.ToInt32(fila.Cells["CodigoCheque"].Value);
                    cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    cheque.CuentaBancaria.Codigo= Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                    cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                    cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                    cheque.Librador = fila.Cells["Librador"].Value.ToString();
                    cheque.Cuit =  fila.Cells["CUIT"].Value.ToString();
                    cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    cheques.Add(cheque);
                }
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 6)
                {
                    cheque = new Entidades.Cheque();
                    cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    cheque.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    cheque.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt32(fila.Cells["CuentaContable"].Value);
                    cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                    cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                    cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                    cheque.Librador = fila.Cells["Librador"].Value.ToString();
                    cheque.Cuit = fila.Cells["CUIT"].Value.ToString();
                    cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    chequesPropios.Add(cheque);
                }
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 5)
                {
                    tranferencia = new Tranferencia();
                    tranferencia.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    tranferencia.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    tranferencia.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CuentaContable"].Value);
                    tranferencia.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    tranferencia.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    Tranferencias.Add(tranferencia);
                }
            }
        }
        

        private void cbFormasDePago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                Valores -= total;
                ActualizarValores();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                this.cbFormasDePago.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value);

                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 1) {
                    this.ucContado.Visible = true;
                    this.ucCheque.Visible = false;
                    this.ucChequePropio.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue= Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text= dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    Valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }else
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3 && Tipodocumento.Equals("Ventas"))
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = true;
                    this.ucChequePropio.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    this.ucCheque.cbBancos.SelectedValue= Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucCheque.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                    this.ucCheque.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                    this.ucCheque.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                    this.ucCheque.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                    this.ucCheque.txtNumero.Text= dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                    this.ucCheque.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucCheque.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    Valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }else
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3 && Tipodocumento.Equals("Compras"))
                {
                    for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                        {
                            double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                            dgvDatos.Rows.RemoveAt(i);
                            Valores -= total;
                            ActualizarValores();
                        }
                    }
                    
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucChequePropio.Visible = false;
                    this.ucChequesTerceros.Visible = true;
                    /*this.ucCheque.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucCheque.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                    this.ucCheque.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                    this.ucCheque.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                    this.ucCheque.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                    this.ucCheque.txtNumero.Text = dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                    this.ucCheque.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();*/
                    //frmCheque.ShowDialog();
                    Utilidades.Formularios.Abrir(this.MdiParent, frmCheque);
                    //double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                }else
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 6 && Tipodocumento.Equals("Compras"))
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucChequePropio.Visible = true;
                    this.ucChequesTerceros.Visible = false;
                    this.ucChequePropio.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucChequePropio.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                  //  this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucChequePropio.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                    this.ucChequePropio.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                    this.ucChequePropio.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                    this.ucChequePropio.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                    this.ucChequePropio.txtNumero.Text = dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                    this.ucChequePropio.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucChequePropio.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    Valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                    
                }
                else
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 5)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucChequePropio.Visible = false;
                    this.ucTranferenciasBancarias.Visible = true;
                    this.ucChequesTerceros.Visible = false;
                    this.ucTranferenciasBancarias.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucTranferenciasBancarias.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucTranferenciasBancarias.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucTranferenciasBancarias.txtImporte.Focus();

                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    Total -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);

                }
                ActualizarValores();
                

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //((frmFacturaCompra)FormularioAnterior).lblTotal.Text = Total.ToString("C2");
            this.Hide();
        }

        private void ucChequesTerceros_Load(object sender, EventArgs e)
        {

        }
    }
}
