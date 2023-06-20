using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicial : Presentacion.frmColor
    {
        Logica.Caja objLCaja = new Logica.Caja();
        public frmSaldoInicial(DateTime pFecha)
        {
            InitializeComponent();
            ConfiguracionInicial();
            LlenarGrilla(pFecha);
            lblTitulo.Text = "Saldo Inicial al : " + pFecha.Date.ToString("dd/MM/yyyy");
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

        private void LlenarGrilla(DateTime pFecha) {
            try { 
            dgvDatos.DataSource = objLCaja.ObtenerSaldoInicial(pFecha);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
