using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ucFormasPagoIngresos : UserControl
    {
        public double valores = 0;
        private Form formularioInicial;
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        List<Entidades.Factura_Efectivo> efectivos; //1
        List<Entidades.Cheque> cheques; //3
        List<Entidades.Tranferencia> tranferencias;  //5


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


        public List<Entidades.Cheque> Cheques
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

        public List<Entidades.Tranferencia> Tranferencias
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

        public List<Entidades.Factura_Efectivo> Efectivos
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

        public ucFormasPagoIngresos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            Efectivos = new List<Entidades.Factura_Efectivo>();
            Cheques = new List<Entidades.Cheque>();
            Tranferencias = new List<Entidades.Tranferencia>();
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            CargarValores();
            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucCheque.btnAgregar.Click += BtnAgregar_Click;
            this.ucTranferenciasBancarias.btnAgregar.Click += btnAgregarTranferencia_Click;
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Entidades.Cheque cheque = new Entidades.Cheque();
            try
            {

                cheque = this.ucCheque.Cheque();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (!Utilidades.Validar.ValidaCUIT(cheque.Cuit))
                {
                    MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucCheque.ucCUIT.txtCUIL1.Focus();
                    return;
                }


                double total = cheque.Moneda.Cotizacion * cheque.Importe;

                //Int64 cuenta;
                /*if (cheque.FechaPago <= DateTime.Now.Date.AddDays(1))
                {
                    cuenta = cheque.CuentaBancaria.CuentaContable.Codigo;
                }
                else*/
                //cuenta = cheque.CuentaBancaria.CuentaContableValoresDiferidos.Codigo;

                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C2"), /*cheque.CuentaBancaria.CuentaContable.Codigo*/ objEFormaDePago.CuentaContable.Codigo, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit, cheque.CuentaBancaria.Codigo);
                //Valores += total;
                valores += total;
                LimpiarCheque();
                // ActualizarValores();
            }
        }

        private void LimpiarCheque()
        {
            //this.ucCheque.LimpiarCheques();
            this.ucCheque.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);

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

            
            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucTranferenciasBancarias.objEMoneda.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Descripcion + " Nº Cuenta: "
                + this.ucTranferenciasBancarias.objECuentaBancaria.NumeroCuenta + " - " + this.ucTranferenciasBancarias.objEMoneda.Descripcion,
                cotizacion, importe, total.ToString("C2"), this.ucTranferenciasBancarias.objECuentaBancaria.CuentaContable.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Codigo, null, null, null, null, null, this.ucTranferenciasBancarias.objECuentaBancaria.Codigo);

            //Valores += total;
            valores += total;
            LimpiarTranferencia();
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe3"].Width = 90;
        }

        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosIngresosFormasPago(), "Codigo", "Descripcion");
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
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS"))
            {
                ucContado.Visible = false;
                ucCheque.Visible = true;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("TRANSFERENCIA BANCARIA"))
            {
                ucContado.Visible = false;
                ucCheque.Visible = false;
                ucTranferenciasBancarias.Visible = true;
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



            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C2"), objEFormaDePago.CuentaContable.Codigo);
            valores += total;/*
            ActualizarValores();*/
            LimpiarEfectivo();
            // MostrarImportes();
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
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                } 
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = true;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucCheque.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    //  this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucCheque.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                    this.ucCheque.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                    this.ucCheque.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                    this.ucCheque.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                    this.ucCheque.txtNumero.Text = dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                    this.ucCheque.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucCheque.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 5)
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = false;
                    this.ucTranferenciasBancarias.Visible = true;
                    this.ucTranferenciasBancarias.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucTranferenciasBancarias.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucTranferenciasBancarias.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucTranferenciasBancarias.txtImporte.Focus();

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

            Entidades.Factura_Efectivo facturaEfectivo;
            Entidades.Cheque cheque;
            Entidades.Tranferencia tranferencia;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                switch (Convert.ToInt32(fila.Cells["FormaDePago"].Value))
                {
                    case 1:
                        facturaEfectivo = new Entidades.Factura_Efectivo();
                        facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        facturaEfectivo.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
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
                        tranferencia = new Entidades.Tranferencia();
                        tranferencia.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                        tranferencia.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                        tranferencia.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value);
                        tranferencia.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        tranferencia.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Tranferencias.Add(tranferencia);
                        break;
                }
            }
        }

        public void Limpiar() {
            valores = 0;
            dgvDatos.Rows.Clear();
        }
    }
}
