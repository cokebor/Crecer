using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCantidadDias : Presentacion.frmColor
    {
        public int CantidadDias { get; set; }
        public frmCantidadDias()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        public frmCantidadDias(Entidades.Empleado pEmpleado)
        {
            InitializeComponent();
            this.Text = pEmpleado.NombreCompleto;
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void txtCantidadDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
//            this.Close();
        }

        private void txtCantidadDias_TextChanged(object sender, EventArgs e)
        {
            CantidadDias = txtCantidadDias.Text.Equals("") ? 0 : Convert.ToInt32(txtCantidadDias.Text);
        }
    }
}
