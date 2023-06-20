using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2
{
    public partial class txtNumeroComprobante : UserControl
    {
        public txtNumeroComprobante()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtLetra.Text = "";
            txtPuntoVenta.Text = "";
            txtNumero.Text = "";
        }

        public void Habilitar()
        {
            txtLetra.Enabled = true;
            txtPuntoVenta.Enabled = true;
            txtNumero.Enabled = true;
        }

        public void DesHabilitar()
        {
            txtLetra.Enabled = false;
            txtPuntoVenta.Enabled = false;
            txtNumero.Enabled = false;
        }
        public string ValorConFormato
        {
            get
            {
                return txtLetra.Text.Trim() + "-" + txtPuntoVenta.Text.Trim() + "-" + txtNumero.Text.Trim();
            }
        }

        public string Valor
        {
            get
            {
                return txtLetra.Text.Trim() + txtPuntoVenta.Text.Trim() + txtNumero.Text.Trim();
            }
        }

        private void txtCUIL2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCUIL3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCUIL1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (char)Keys.Back==e.KeyChar)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
                e.Handled = true;

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCUIL1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCUIL1_TextChanged(object sender, EventArgs e)
        {
            if (txtLetra.TextLength == 1)
                txtPuntoVenta.Focus();
        }

        private void txtCUIL2_TextChanged(object sender, EventArgs e)
        {
            if (txtPuntoVenta.TextLength == 4)
                txtNumero.Focus();

            
        }

        private void txtCUIL2_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public static string FormatoCuatroCeros(TextBox txt)
        {
            string resultado="";
            try{
            if (txt.Text.Equals(""))
                txt.Text = "0";
                resultado = string.Format("{0:0000}", Convert.ToInt32(txt.Text.Trim()));
               return resultado;
        }
            catch (Exception)
            {
                
            }
            return resultado;
        }
        public static string FormatoOchoCeros(TextBox txt)
        {
            string resultado="";
            try
            {
                
                if (txt.Text.Equals(""))
                    txt.Text = "0";
                resultado = string.Format("{0:00000000}", Convert.ToInt32(txt.Text.Trim()));
                
            }
            catch (Exception)
            {
                
            }
            return resultado;
        }

        private void txtCUIL2_Leave(object sender, EventArgs e)
        {
            txtPuntoVenta.Text = FormatoCuatroCeros(txtPuntoVenta);
        }

        private void txtCUIL3_Leave(object sender, EventArgs e)
        {
            txtNumero.Text = FormatoOchoCeros(txtNumero);
        }

        public void cargarValor(string valor) {
            txtLetra.Text = valor.Substring(0, 1);
            txtPuntoVenta.Text = valor.Substring(1, 4);
            txtNumero.Text = valor.Substring(5, 8);
        }
    }
}
