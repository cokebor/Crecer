using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion

{
    public partial class ucCUIT : UserControl
    {
        public ucCUIT()
        {
            InitializeComponent();
        }

        public void Limpiar() {
            txtCUIL1.Text = "";
            txtCUIL2.Text = "";
            txtCUIL3.Text = "";
        }

        public void Habilitar() {
            txtCUIL1.Enabled = true;
            txtCUIL2.Enabled = true;
            txtCUIL3.Enabled = true;
        }

        public void DesHabilitar()
        {
            txtCUIL1.Enabled = false;
            txtCUIL2.Enabled = false;
            txtCUIL3.Enabled = false;
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
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCUIL2_TextChanged(object sender, EventArgs e)
        {
            if (txtCUIL2.TextLength == 8)
                txtCUIL3.Focus();
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
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCUIL1_TextChanged(object sender, EventArgs e)
        {
            if (txtCUIL1.TextLength == 2)
                txtCUIL2.Focus();
        }

        public void CargarCUIT(string cuit) {
            txtCUIL1.Text = cuit.Substring(0, 2);
            txtCUIL2.Text = cuit.Substring(3, 8);
            txtCUIL3.Text = cuit.Substring(12, 1);
        }

        private void ucCUIT_Load(object sender, EventArgs e)
        {

        }
    }
}
