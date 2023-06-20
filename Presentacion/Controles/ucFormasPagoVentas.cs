 using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class ucFormasPagoVentas : UserControl
    {
        //public double valores = 0;
        public double valores { get; set; }
        private Form formularioInicial;
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        List<Entidades.Factura_Efectivo> efectivos; //1
        List<Entidades.Cheque> cheques; //3
        List<Entidades.Cheque> chequesTerceros; //3
        List<Entidades.Tranferencia> tranferencias;  //5
        List<CreditoDebito> creditosDebitos;

        CreditoDebito creditoDebito;
        public frmChequesCartera frmCheque = new frmChequesCartera();
        frmChequesCliente frmChequeCliente = new frmChequesCliente();

        //private string tipoDocumento;
        private int codigoRecibo;
        private string tipoDoc;

        public double Efectivo { get; set; }
        public double Dolares { get; set; }
        public double Tranferencia { get; set; }

        private Entidades.Cliente cliente=new Entidades.Cliente();

        public Form FormularioInicial
        {
            get
            {
                return formularioInicial;
            }

            set
            {
                formularioInicial = value;
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

        public List<Cheque> ChequesTerceros
        {
            get
            {
                return chequesTerceros;
            }

            set
            {
                chequesTerceros = value;
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

        public List<Factura_Efectivo> Efectivos
        {
            get
            {
                return efectivos;
            }

            set
               {
                efectivos = value;
            }
        }

        public string TipoDoc
        {
            get
            {
                return tipoDoc;
            }

            set
            {
                tipoDoc = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
                if(Cliente!=null)
                if (TipoDoc.Equals("RC"))
                {
                    frmChequeCliente.CargarValores(Cliente);
                }
                else {
                        frmChequeCliente.CargarValores(Cliente, CodigoRecibo);
                }
            }
        }

        public int CodigoRecibo
        {
            get
            {
                return codigoRecibo;
            }

            set
            {
                codigoRecibo = value;
                if (TipoDoc.Equals("CR"))
                {
                    frmChequeCliente.CargarValores(Cliente, CodigoRecibo);
                }
            }
        }

        public List<CreditoDebito> CreditosDebitos
        {
            get
            {
                return creditosDebitos;
            }

            set
            {
                creditosDebitos = value;
            }
        }

        public ucFormasPagoVentas()
        {
            TipoDoc = "RC";
            InitializeComponent();
            ConfiguracionInicial();
            Efectivos = new List<Entidades.Factura_Efectivo>();
            Cheques = new List<Cheque>();
            ChequesTerceros = new List<Cheque>();
            Tranferencias = new List<Tranferencia>();
            CreditosDebitos = new List<CreditoDebito>();
        }
        public ucFormasPagoVentas(string pTipo)
        {
            TipoDoc = pTipo;
            InitializeComponent();
            ConfiguracionInicial();
            Efectivos = new List<Entidades.Factura_Efectivo>();
            Cheques = new List<Cheque>();
            ChequesTerceros = new List<Cheque>();
            Tranferencias = new List<Tranferencia>();
            CreditosDebitos = new List<CreditoDebito>();
        }
      
        private void ConfiguracionInicial()
        {
            Formatos();
            CargarValores();
            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucChequesTerceros.btnChequesTerceros.Click += btnChequesTerceros_Click;
            this.ucTranferenciasBancarias.btnAgregar.Click += btnAgregarTranferencia_Click;
            this.ucCheque.btnAgregar.Click += btnAgregarCheque_Click;
            this.ucDebitoCredito.btnAgregar.Click += btnAgregarDebitoCredito_Click;             
        }

        private void btnAgregarDebitoCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ucDebitoCredito.ValidarMonto().Equals(false))
                {
                    MessageBox.Show("El importe ingresado no puede ser 0 o menor!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ucDebitoCredito.txtImporte.Focus();
                    return;
                }
                double cotizacion = Convert.ToDouble(this.ucDebitoCredito.lblCotizacion.Text);
                double importe = this.ucDebitoCredito.txtImporte.Text.Equals("") ? 0 : Convert.ToDouble(this.ucDebitoCredito.txtImporte.Text);
                double total = cotizacion * importe;

                Entidades.CreditoDebito cd = ucDebitoCredito.ObtenerDatosCreditoDebito();
                if (Convert.ToInt32(cbFormasDePago.SelectedValue) == 7)
                {

                    dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cd.Moneda.Codigo, /*d.Banco.Descripcion + " Nº Cuenta: "
                + d.CuentaBancaria.NumeroCuenta + " - " + d.Moneda.Descripcion*/cd.TipoDeTarjetas.Descripcion + " Nro Cupon:" + cd.NroCupon,
                    cotizacion, importe, total.ToString("C2"), cd.CuentaBancaria.CuentaContableTranferencias.Codigo, cd.Banco.Codigo, null, null, null, null, null, cd.CuentaBancaria.Codigo, null, cd.TipoDeTarjetas.Codigo, null, cd.NroCupon);

                }
                else if (Convert.ToInt32(cbFormasDePago.SelectedValue) == 8)
                {
                    //Entidades.CreditoDebito c = ucDebitoCredito.ObtenerDatosCredito();

                    dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cd.Moneda.Codigo, /*c.Banco.Descripcion + " Nº Cuenta: "
                + c.CuentaBancaria.NumeroCuenta + " - " + c.Moneda.Descripcion*/ cd.TipoDeTarjetas.Descripcion + " Nro Cupon:" + cd.NroCupon + " Cuotas: " + cd.Cuotas,
                    cotizacion, importe, total.ToString("C2"), cd.CuentaBancaria.CuentaContableTranferencias.Codigo, cd.Banco.Codigo, null, null, null, null, null, cd.CuentaBancaria.Codigo, null, cd.TipoDeTarjetas.Codigo, cd.Cuotas, cd.NroCupon);

                }
                //Total += total;
                //ActualizarValores();
                valores += total;
                ucDebitoCredito.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChequesTerceros_Click(object sender, EventArgs e)
        {
            for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                {
                    double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                    dgvDatos.Rows.RemoveAt(i);
                    valores -= total;
                }
            }
            if (TipoDoc.Equals("RC"))
            {
                Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmCheque);
                CargarCheques();
            }
            else
            {
                Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmChequeCliente);
                CargarChequesClientes();
            }


        }
        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            Entidades.Cheque cheque = this.ucCheque.Cheque();
            if (cheque.Librador != null) {
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3 && Convert.ToInt32(fila.Cells["CodigoBanco"].Value) == Convert.ToInt32(cheque.Banco.Codigo) && fila.Cells["NumeroCheque"].Value.Equals(cheque.NumeroCheque)) {
                        MessageBox.Show("Cheque ya ingresado en este comprobante.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (Utilidades.Validar.ValidarFechas(cheque.FechaEmision, cheque.FechaPago).Equals(false)) {
                    MessageBox.Show("Fecha Emision no puede ser inferior a Fecha de Pago.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*if (!Utilidades.Validar.ValidaCUIT(this.ucCheque.ucCUIT.Valor)) {
                    MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucCheque.ucCUIT.txtCUIL1.Focus();
                    return;
                }*/
                double total = cheque.Moneda.Cotizacion * cheque.Importe;
                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C4"), objEFormaDePago.CuentaContable.Codigo, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit);
                valores += total;
                LimpiarCheque2();
            }
        }

        private void btnAgregarTranferencia_Click(object sender, EventArgs e)
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

                if (TipoDoc.Equals("CR") && Tranferencia < total)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucTranferenciasBancarias.objEMoneda.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Descripcion + " Nº Cuenta: "
                + this.ucTranferenciasBancarias.objECuentaBancaria.NumeroCuenta + " - " + this.ucTranferenciasBancarias.objEMoneda.Descripcion,
                cotizacion, importe, total.ToString("C2"), this.ucTranferenciasBancarias.objECuentaBancaria.CuentaContableTranferencias.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Codigo, null, null, null, null, null, this.ucTranferenciasBancarias.objECuentaBancaria.Codigo);

            //Valores += total;
            valores += total;
            LimpiarTranferencia();
        }

       
        private void LimpiarCheque2()
        {
            //this.ucCheque.LimpiarCheques();
            this.ucCheque.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);

        }
        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe3"].Width = 90;
        }

        public void CargarValores()
        {
            try
            {
                if(TipoDoc !=null && TipoDoc.Equals("RC"))
                    Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosVentasFormasPago(), "Codigo", "Descripcion");
                else
                    Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosVentasSaldoInicialFormasPago(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucContado.Visible = false; 
            ucCheque.Visible = false;
            ucTranferenciasBancarias.Visible = false;
            ucDebitoCredito.Visible = false;
            ucChequesTerceros.Visible = false;
            if (cbFormasDePago.Text.Equals("CONTADO"))
            {
                ucContado.Visible = true;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS") && TipoDoc.Equals("RC"))
            {
                ucCheque.Visible = true;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS") && TipoDoc.Equals("CR"))
            {
                ucChequesTerceros.Visible = true;
            }
            else if (cbFormasDePago.Text.Equals("TRANSFERENCIA BANCARIA"))
            {
                ucTranferenciasBancarias.Visible = true;

            } else if (cbFormasDePago.Text.Equals("DEBITO"))
            {
                ucDebitoCredito.Visible = true;
                ucDebitoCredito.Debito();
            }
            else if (cbFormasDePago.Text.Equals("TARJETA DE CREDITO"))
            {
                ucDebitoCredito.Visible = true;
                ucDebitoCredito.Credito();
            }
            objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
        }

        private void btnAgregarEfectivo_Click(object sender, EventArgs e)
        {
            if (this.ucContado.ValidarEfectivo().Equals(true))
            {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucContado.txtImporte.Focus();
                return;
            }
            else if (this.ucContado.ValidarMonto().Equals(false))
            {
                MessageBox.Show("El importe ingresado no puede ser 0 o menor!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            /*
            if (Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue) == 1)
            {
                if (TipoDoc.Equals("CR") && Efectivo < total) {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else {
                if (TipoDoc.Equals("CR") && Dolares < total)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            */

            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C2"), objEFormaDePago.CuentaContable.Codigo);
            valores += total;/*
            ActualizarValores();*/
            LimpiarEfectivo();
            // MostrarImportes();
        }
        
        private void CargarCheques() {
            try
            {
                foreach (DataGridViewRow dr in frmCheque.dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Seleccionado"].Value))
                    {
                        objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
                        double total = Convert.ToDouble(dr.Cells["Cotizacion"].Value) * Convert.ToDouble(dr.Cells["Importe2"].Value);
                        if (Convert.ToInt64(dr.Cells["CodigoCuentaContable"].Value) == 0)
                            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, objEFormaDePago.CuentaContable.Codigo, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value, dr.Cells["Codigo"].Value);
                        else
                            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, dr.Cells["CodigoCuentaContable"].Value, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value, dr.Cells["Codigo"].Value);
                        valores += total;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarChequesClientes()
        {
            try
            {
                foreach (DataGridViewRow dr in frmChequeCliente.dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Seleccionado"].Value))
                    {
                        objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
                        double total = Convert.ToDouble(dr.Cells["Cotizacion"].Value) * Convert.ToDouble(dr.Cells["Importe2"].Value);
                        if (Convert.ToInt64(dr.Cells["CodigoCuentaContable"].Value) == 0)
                            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, objEFormaDePago.CuentaContable.Codigo, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value);
                        else
                            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, dr.Cells["CodigoCuentaContable"].Value, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value);
                        valores += total;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarEfectivo()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucContado.cbMoneda);
            this.ucContado.txtImporte.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                this.cbFormasDePago.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value);

                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 1)
                {
                    this.ucContado.Visible = true;
                    this.ucCheque.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    this.ucDebitoCredito.Visible = false;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                } else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3)
                {
                    for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                        {
                            this.ucCheque.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                            this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                            this.ucCheque.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                            this.ucCheque.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                            this.ucCheque.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                            this.ucCheque.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                            this.ucCheque.txtNumero.Text = dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                            this.ucCheque.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                            this.ucCheque.txtImporte.Focus();
                            double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                            dgvDatos.Rows.RemoveAt(i);
                            //Valores -= total;
                            valores -= total;
                        }
                    }

                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucDebitoCredito.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    /*if(TipoDoc.Equals("RC"))
                     {
                         Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmCheque);
                         CargarCheques();
                     }else*/
                    if (TipoDoc.Equals("CR"))
                    {
                        this.ucChequesTerceros.Visible = true;
                        Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmChequeCliente);
                        CargarChequesClientes();
                    }
                    else {
                        this.ucCheque.Visible = true;
                    }

                }
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 6)
                {
                    /*this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucChequePropio.Visible = true;
                    this.ucTranferenciasBancarias.Visible = false;
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
                    //Valores -= total;
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                    */
                }else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 5)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucTranferenciasBancarias.Visible = true;
                    this.ucChequesTerceros.Visible = false;
                    this.ucDebitoCredito.Visible = false;
                    this.ucTranferenciasBancarias.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucTranferenciasBancarias.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucTranferenciasBancarias.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucTranferenciasBancarias.txtImporte.Focus();

                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);

                }
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 7)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    this.ucDebitoCredito.Visible = true;
                    this.ucDebitoCredito.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucDebitoCredito.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucDebitoCredito.cbTipo.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoTipoTarjeta"].Value);
                    //this.ucDebitoCredito.cbCuotas.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cuotas"].Value);
                    this.ucDebitoCredito.txtNroCupon.Text= dgvDatos.CurrentRow.Cells["NroCupon"].Value.ToString();
                    this.ucDebitoCredito.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucDebitoCredito.txtImporte.Focus();

                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);

                }
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 8)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucChequesTerceros.Visible = false;
                    this.ucDebitoCredito.Visible = true;
                    this.ucDebitoCredito.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucDebitoCredito.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucDebitoCredito.cbTipo.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoTipoTarjeta"].Value);
                    this.ucDebitoCredito.cbCuotas.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cuotas"].Value);
                    this.ucDebitoCredito.txtNroCupon.Text = dgvDatos.CurrentRow.Cells["NroCupon"].Value.ToString();
                    this.ucDebitoCredito.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucDebitoCredito.txtImporte.Focus();

                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);

                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                //Valores -= total;
                valores -= total;
            }
        }

        private void LimpiarTranferencia()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucTranferenciasBancarias.cbBancos);
            this.ucTranferenciasBancarias.txtImporte.Text = "";
        }

        public void ObtenerDatos()
        {
            Logica.Moneda objLMoneda = new Logica.Moneda();
            Efectivos.Clear();
            Cheques.Clear();
            Tranferencias.Clear();
            ChequesTerceros.Clear();
            CreditosDebitos.Clear();

            Entidades.Factura_Efectivo facturaEfectivo;
            Entidades.Cheque cheque;
            Entidades.Tranferencia tranferencia;
            int mult = 1;
            if (TipoDoc.Equals("CR"))
                mult = -1;

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                switch (Convert.ToInt32(fila.Cells["FormaDePago"].Value))
                {
                    case 1:
                        facturaEfectivo = new Entidades.Factura_Efectivo();
                        facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        facturaEfectivo.Importe = mult*Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Efectivos.Add(facturaEfectivo);
                        break;
                    case 3:
                        cheque = new Entidades.Cheque();
                        cheque.Codigo = Convert.ToInt32(fila.Cells["CodigoCheque"].Value);
                        cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                        cheque.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                        cheque.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value); 
                        cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                        cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                        cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                        cheque.Librador = fila.Cells["Librador"].Value.ToString();
                        cheque.Cuit = fila.Cells["CUIT"].Value.ToString();
                        cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Cheques.Add(cheque);
                        break;
                    case 5:
                        tranferencia = new Tranferencia();
                        tranferencia.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                        tranferencia.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                        tranferencia.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value);
                        tranferencia.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        tranferencia.Importe = mult*Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Tranferencias.Add(tranferencia);
                        break;
                    case 7:
                    case 8:
                        creditoDebito = new Entidades.CreditoDebito();
                        creditoDebito.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                        creditoDebito.FormaDePago.Codigo = Convert.ToInt32(fila.Cells["FormaDePago"].Value);
                        creditoDebito.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                        creditoDebito.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value);
                        creditoDebito.TipoDeTarjetas.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoTarjeta"].Value);
                        creditoDebito.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        creditoDebito.NroCupon = fila.Cells["NroCupon"].Value.ToString();
                        creditoDebito.Cuotas = Convert.ToInt32(fila.Cells["Cuotas"].Value);
                        creditoDebito.Importe = mult*Convert.ToDouble(fila.Cells["Importe2"].Value);
                        CreditosDebitos.Add(creditoDebito);
                        break;
                }
            }
        }

        public void Limpiar() {
            frmCheque = new frmChequesCartera();
            frmChequeCliente = new frmChequesCliente();
            valores = 0;
            dgvDatos.Rows.Clear();
        }

        private void cbFormasDePago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}
