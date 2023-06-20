using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles2
{
    public partial class txtCUIL : UserControl
    {
        public txtCUIL()
        {
            InitializeComponent();
        }

        public void Limpiar() {
            txtCUIL1.Text = "";
            txtCUIL2.Text = "";
            txtCUIL3.Text = "";
        }


        public string Valor {
            get {
                return txtCUIL1.Text.Trim() + "-" + txtCUIL2.Text.Trim() + "-" + txtCUIL3.Text.Trim();
            }
        }

        public void Cargar(string valor) {
            txtCUIL2.Text = valor;
        }

        private void txtCUIL1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
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
        }

        private void txtCUIL1_TextChanged(object sender, EventArgs e)
        {
            if (txtCUIL1.TextLength == 2)
                txtCUIL3.Focus();
        }
    }
}
