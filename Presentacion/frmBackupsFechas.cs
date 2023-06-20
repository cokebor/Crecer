using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmBackupsFechas : Presentacion.frmColor
    {
        public frmBackupsFechas()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            //txtNumeroComprobante1.txtCUIL1.Text = "R";
            Formatos();
            Utilidades.Formularios.ConfiguracionInicial(this);
            dgvDatos.AutoGenerateColumns = false;
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "FECHAS DE BACKUPS";
        }

        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.Columns["Puesto"].Width = 70;
            //dgvDatos.Columns["Fecha"].Width = 50;
            dgvDatos.Columns["Archivo"].Width = 100;

        }

        private void CargarValores()
        {

            try
            {
                CargarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            if(Singleton.Instancia.Empresa.Codigo==1 )//|| Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                dgvDatos.DataSource = new Logica.Backup().ObtenerFechas(Singleton.Instancia.Empresa);

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
