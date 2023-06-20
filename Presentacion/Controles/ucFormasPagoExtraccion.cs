using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ucFormasPagoExtraccion : UserControl
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Entidades.Banco objEBanco = new Entidades.Banco();
        private Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();

        public double valores = 0;
        private Form formularioInicial;
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        List<Entidades.Factura_Efectivo> efectivos; //1
        List<Entidades.Cheque> cheques; //3


        public frmChequesCartera frmCheque = new frmChequesCartera();

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

        public Entidades.Banco ObjEBanco
        {
            get
            {
                return objEBanco;
            }

            set
            {
                objEBanco = value;
            }
        }

        public Entidades.CuentaBancaria ObjECuentaBancaria
        {
            get
            {
                return objECuentaBancaria;
            }

            set
            {
                objECuentaBancaria = value;
            }
        }

        public ucFormasPagoExtraccion()
        {
            InitializeComponent();
            ConfiguracionInicial();
            Efectivos = new List<Entidades.Factura_Efectivo>();
            Cheques = new List<Entidades.Cheque>();
    //        ChequesPropios = new List<Cheque>();
    //        Tranferencias = new List<Tranferencia>();
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            CargarValores();
            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucChequesTerceros.btnChequesTerceros.Click += btnChequesTerceros_Click;
//            this.ucChequePropio.btnAgregar.Click += BtnAgregar_Click;
  //          this.ucTranferenciasBancarias.btnAgregar.Click += btnAgregarTranferencia_Click;
        }
        /*
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
        }*/
        /*
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Entidades.Cheque cheque = new Entidades.Cheque();
            try
            {

                cheque = this.ucChequePropio.Cheque();
            }
            catch (Exception ex)
            {
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

                int cuenta;

                    cuenta = cheque.CuentaBancaria.CuentaContableValoresDiferidos.Codigo;

                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C2"),  cuenta, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit, cheque.CuentaBancaria.Codigo);
                //Valores += total;
                valores += total;
                LimpiarCheque();
               // ActualizarValores();
            }
        }*/
        /*
        private void LimpiarCheque()
        {
            //this.ucCheque.LimpiarCheques();
            this.ucChequePropio.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);

        }*/

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe3"].Width = 90;
        }

        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosComprasContraReciboFormasPago(), "Codigo", "Descripcion");
                CargarBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarBancos()
        {
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
            if (cbBancos.SelectedValue != null)
            {
                ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(ObjEBanco), "Codigo", "NumeroCuenta");
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormasDePago.Text.Equals("CONTADO"))
            {
                ucContado.Visible = true;
                ucChequesTerceros.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS"))
            {
                ucContado.Visible = false;
                ucChequesTerceros.Visible = true;
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
            }else if (this.ucContado.ValidarMonto().Equals(false)) {
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

            Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmCheque);
            CargarCheques();
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
                        if (Convert.ToInt32(dr.Cells["CodigoCuentaContable"].Value) == 0)
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
                    this.ucChequesTerceros.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    //Total -= total;
                    valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                } else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3)
                {
                    for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                        {
                            double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                            dgvDatos.Rows.RemoveAt(i);
                            //Valores -= total;
                            valores -= total;
                        }
                    }

                    this.ucContado.Visible = false;
                    this.ucChequesTerceros.Visible = true;

                    Utilidades.Formularios.AbrirShowDialog(FormularioInicial.MdiParent, frmCheque);
                    CargarCheques();
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


        public void ObtenerDatos()
        {
            Logica.Moneda objLMoneda = new Logica.Moneda();
            Efectivos.Clear();
            Cheques.Clear();

            Entidades.Factura_Efectivo facturaEfectivo;
            Entidades.Cheque cheque;
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
                }
            }
        }

        public void Limpiar() {
            frmCheque = new frmChequesCartera();
            valores = 0;
            dgvDatos.Rows.Clear();
        }

        private void ucFormasPagoExtraccion_Load(object sender, EventArgs e)
        {

        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(ObjEBanco), "Codigo", "NumeroCuenta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*public Entidades.CuentaBancaria ObtenerCuentaBancaria() {
            objECuentaBancaria.CuentaContable.Codigo;
            Entidades.CuentaBancaria objCuenta = new Entidades.CuentaBancaria();
            objECuentaBancaria
            return objCuenta;
        }*/
    }
}
