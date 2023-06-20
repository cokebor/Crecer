using System;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class ucDebitoCredito : UserControl
    {
        //Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.TipoDeTarjeta objLTipoTarjeta = new Logica.TipoDeTarjeta();

        public Entidades.Moneda objEMoneda = new Entidades.Moneda();
       // Entidades.Banco objEBanco = new Entidades.Banco();
        public Entidades.CuentaBancaria objECuentaBancaria;// = new Entidades.CuentaBancaria();
        private Entidades.Banco objEBanco = new Banco();

        public bool Ventas { get; set; }
        public Banco ObjEBanco
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


        public ucDebitoCredito()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public ucDebitoCredito(bool pVentas)
        {
            InitializeComponent();
            Ventas = pVentas;
            ConfiguracionInicial();

        }


        private void ConfiguracionInicial()
        {
            Formatos();
            LimitesTamaños();
            CargarBancos();
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Combo.Formato(cbCuotas);
            cbCuotas.SelectedIndex = 0;
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNroCupon, 15);
        }

        public bool ValidarDebito()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaBancaria);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNroCupon);
            return res;
        }

        public bool ValidarCredito()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaBancaria);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuotas);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNroCupon);
            return res;
        }
        public void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerBancoCuentaDebitoCredito(Ventas, true), "CodigoBanco", "Banco");
                // cbBancos.SelectedValue = 1;
                Utilidades.Combo.Llenar(cbTipo, objLTipoTarjeta.ObtenerTodosActivos(), "Codigo", "Descripcion");
                if (cbBancos.SelectedValue != null)
                {
                    ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(ObjEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerCuentasDebitoCreditoDeBancos(ObjEBanco), "Codigo", "NumeroCuenta");
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
                objEMoneda = objECuentaBancaria.Moneda;
                lblCotizacion.Text = objECuentaBancaria.Moneda.Cotizacion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtNroCupon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
        /*
        public Entidades.CreditoDebito ObtenerDatosDebito() {
            Entidades.CreditoDebito debito = new Entidades.CreditoDebito();
            if (!ValidarDebito())
            {
                debito.Banco = objEBanco;
                debito.CuentaBancaria = objECuentaBancaria;
                debito.NroCupon = txtNroCupon.Text.Trim();
                debito.TipoDeTarjetas.Codigo = Convert.ToInt32(cbTipo.SelectedValue);
                debito.TipoDeTarjetas.Descripcion = cbTipo.Text.ToString();
                debito.Moneda = objEMoneda;
                debito.Importe = Convert.ToDouble(txtImporte.Text.Trim());
            }
            else {
                throw new Exception("Faltan de ingresar datos");
            }
            return debito;
        }
        */
        public Entidades.CreditoDebito ObtenerDatosCreditoDebito()
        {
            Entidades.CreditoDebito debitoCredito = new Entidades.CreditoDebito();
            if (!ValidarCredito())
            {
                debitoCredito.Banco = objEBanco;
                debitoCredito.CuentaBancaria = objECuentaBancaria;
                debitoCredito.NroCupon = txtNroCupon.Text.Trim();
                debitoCredito.TipoDeTarjetas.Codigo = Convert.ToInt32(cbTipo.SelectedValue);
                debitoCredito.Moneda = objEMoneda;
                debitoCredito.TipoDeTarjetas.Descripcion = cbTipo.Text.ToString();
                debitoCredito.Cuotas = Convert.ToInt32(cbCuotas.Text);
                debitoCredito.Importe = Convert.ToDouble(txtImporte.Text.Trim());
            }
            else
            {
                throw new Exception("Faltan de ingresar datos");
            }
            return debitoCredito;
        }
        public void Debito() {
            lblCuotas.Visible = false;
            cbCuotas.Visible = false;
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerBancoCuentaDebitoCredito(Ventas, true), "CodigoBanco", "Banco");
        }
        public void Credito()
        {
            lblCuotas.Visible = true;
            cbCuotas.Visible = true;
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerBancoCuentaDebitoCredito(Ventas, false), "CodigoBanco", "Banco");
        }

        public void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbTipo);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuotas);
            txtNroCupon.Text = "";
            txtImporte.Text = "";
        }
        public bool ValidarMonto()
        {
            bool res = false;
            if (txtImporte.Text.Length > 0 && Convert.ToDouble(txtImporte.Text) <= 0)
                res = false;
            else
                res = true;
            return res;
        }

    }
}
