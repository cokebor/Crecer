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
    public partial class ucNumeroDTV : UserControl
    {
        public ucNumeroDTV()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtNumero2.Text = "";
            txtNumero.Text = "";
        }

        public void Habilitar()
        {
            txtNumero2.Enabled = true;
            txtNumero.Enabled = true;
        }

        public void DesHabilitar()
        {
            txtNumero2.Enabled = false;
            txtNumero.Enabled = false;
        }
        public string ValorConFormato
        {
            get
            {
                return txtNumero.Text.Trim() + "-" + txtNumero2.Text.Trim();
            }
        }

        public string Valor
        {
            get
            {
                return txtNumero.Text.Trim() + txtNumero2.Text.Trim();
            }
        }


        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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
            //Utilidades.ControlesGenerales.CambiarFoco(e);
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
            //Utilidades.ControlesGenerales.CambiarFoco(e);
        }

      
        public static string FormatoUnCeros(TextBox txt)
        {
            string resultado;
            if (txt.Text.Trim().Equals(""))
                txt.Text = "0";
            resultado = string.Format("{0:0}", Convert.ToInt32(txt.Text.Trim()));
            return resultado;
        }
        public static string FormatoOchoCeros(TextBox txt)
        {
            string resultado="";
            try
            {
                if (txt.Text.Trim().Equals(""))
                    txt.Text = "0";
                resultado = string.Format("{0:00000000}", Convert.ToInt32(txt.Text.Trim()));
                return resultado;
            }
            catch (Exception)
            {
               
            }
            return resultado;

        }



        public void cargarValor(string valor) {
            if (valor.Length == 9)
            {
                txtNumero.Text = valor.Substring(0, 8);
                txtNumero2.Text = valor.Substring(8, 1);
            }
            else {
                txtNumero.Text = "";
                txtNumero2.Text = "";
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.TextLength == 8)
                txtNumero2.Focus();
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            txtNumero.Text = FormatoOchoCeros(txtNumero);
        }

        private void txtNumero2_Leave(object sender, EventArgs e)
        {
            txtNumero2.Text = FormatoUnCeros(txtNumero2);
        }
    }
}
