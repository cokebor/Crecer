using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class ucChequePropio : UserControl
    {
        //Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();


        Entidades.Moneda objEMoneda = new Entidades.Moneda();
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public ucChequePropio()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }


        private void ConfiguracionInicial()
        {
            Formatos();
            LimitesTamaños();
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancos);
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtLibrador, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }
        private void ucCheque_Load(object sender, EventArgs e)
        {
            //ucCUIT.Habilitar();
            
            try
            {
              //  txtLibrador.Text = Singleton.Instancia.Empresa.RazonSocial;
              //  ucCUIT.CargarCUIT(Singleton.Instancia.Empresa.CUIT);
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
                objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
            }
        }
        /*
        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaBancaria.Items.Count > 0)
            {
                try
                {
                    objEMoneda = objLMoneda.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                    lblCotizacion.Text = objEMoneda.Cotizacion.ToString("0.00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        */
        public Entidades.Cheque Cheque()
        {
                if (ValidarCheque().Equals(true))
                {
                    MessageBox.Show("Faltan ingresar datos del Cheque!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtImporte.Focus();
                    return new Entidades.Cheque();
                }
            if (Convert.ToDouble(txtImporte.Text.Trim()) == 0)
            {
                MessageBox.Show("El importe del Cheque no puede ser cero.!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new Entidades.Cheque(); ;
            }

            Entidades.Cheque cheque = new Entidades.Cheque();
                cheque.Banco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
                cheque.Banco.Descripcion = cbBancos.Text;
                cheque.NumeroCheque = txtNumero.Text.Trim();
                cheque.CuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                ///cheque.CuentaBancaria.Codigo = Convert.ToInt32(cbCuentaBancaria.SelectedValue);
                cheque.FechaEmision = dtpEmision.Value.Date;
                cheque.FechaPago = dtpPago.Value.Date;
                cheque.Librador = txtLibrador.Text.Trim();
                cheque.Cuit = ucCUIT.Valor;
                //objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                cheque.Moneda = objEMoneda;
                cheque.Importe = Convert.ToDouble(txtImporte.Text.Trim());

                return cheque;
        }

        private void cbBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtLibrador_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public bool ValidarCheque()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbBancos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaBancaria);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtLibrador);
            res = res || CUITEnBlanco(ucCUIT);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNumero);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            return res;
        }



        private bool CUITEnBlanco(ucCUIT txt)
        {
            bool res = false;
            if (txt.txtCUIL1.Text.Trim().Equals("") || txt.txtCUIL2.Text.Trim().Equals("") || txt.txtCUIL3.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void ucCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public void LimpiarCheques()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaBancaria);
            dtpEmision.Value = DateTime.Now;
            dtpPago.Value = DateTime.Now;
            txtLibrador.Text = "";
            ucCUIT.Limpiar();
            txtNumero.Text = "";
            txtImporte.Text = "";
        }


        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
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
    }
}
