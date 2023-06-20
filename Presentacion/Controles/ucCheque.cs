using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class ucCheque : UserControl
    {
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Banco objLBanco = new Logica.Banco();

        Entidades.Moneda objEMoneda = new Entidades.Moneda();
        public ucCheque()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        

        private void ConfiguracionInicial() {
            Formatos();
            LimitesTamaños();
        }

        private void Formatos() {
            Utilidades.Combo.Formato(cbMoneda);
            Utilidades.Combo.Formato(cbBancos);
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtLibrador, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }
        private void ucCheque_Load(object sender, EventArgs e)
        {
            ucCUIT.Habilitar();
            try
            {
               ObtenerMonedas();
               ObtenerBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerMonedas()
        {
            Utilidades.Combo.Llenar(cbMoneda, objLMoneda.ObtenerActivos(), "CodigoMoneda", "Descripcion");
        }

        public void ObtenerBancos()
        {
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivos(), "Codigo", "Descripcion");
        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoneda.Items.Count > 0)
            {
                try
                {
                    objEMoneda = objLMoneda.ObtenerUno(Convert.ToInt32(cbMoneda.SelectedValue));
                    lblCotizacion.Text = objEMoneda.Cotizacion.ToString("0.00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Entidades.Cheque Cheque() {
            if (ValidarCheque().Equals(true))
            {
                MessageBox.Show("Faltan ingresar datos del Cheque!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtImporte.Focus();
                  return new Entidades.Cheque();
            }
            if (Convert.ToDouble(txtImporte.Text.Trim())==0) {
                MessageBox.Show("El importe del Cheque no puede ser cero.!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new Entidades.Cheque(); ;
            }
            
            Entidades.Cheque cheque = new Entidades.Cheque();
            cheque.Banco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
            cheque.Banco.Descripcion = cbBancos.Text;
            cheque.NumeroCheque = txtNumero.Text.Trim();
            cheque.CuentaBancaria.Codigo = 0;
            cheque.FechaEmision = dtpEmision.Value.Date;
            cheque.FechaPago = dtpPago.Value.Date;
            cheque.Librador = txtLibrador.Text.Trim();
            cheque.Cuit = ucCUIT.Valor;
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
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbMoneda);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtLibrador);
            //res = res || CUITEnBlanco(ucCUIT);
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
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

   

        private void ucCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public void LimpiarCheques() {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbMoneda);
            dtpEmision.Value = DateTime.Now;
            dtpPago.Value = DateTime.Now;
            txtLibrador.Text = "";
            ucCUIT.Limpiar();
            txtNumero.Text = "";
            txtImporte.Text = "";
        }

    }
}
