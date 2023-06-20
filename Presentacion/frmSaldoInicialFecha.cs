using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicialFecha : Presentacion.frmColor
    {
        public frmSaldoInicialFecha()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }

        private void Titulo()
        {
            this.Text = "SALDO ANTERIOR";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtFecha.Value = DateTime.Now;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmSaldoInicial(dtFecha.Value));
        }
    }
}
