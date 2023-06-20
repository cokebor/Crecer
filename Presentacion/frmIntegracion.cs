using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmIntegracion : Presentacion.frmColor
    {
        Entidades.Integracion objEIntegracion = new Entidades.Integracion();

        Logica.Integracion objLIntegracion = new Logica.Integracion();
        public frmIntegracion()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "INTEGRACION DE DATOS";
        }

        private void btnIntegracionTotal_Click(object sender, EventArgs e)
        {
            objEIntegracion.TipoIntegracion= 'T';
            lblTitulo.Text = objEIntegracion.DescripcionIntegracion;
            try {
                lblInicio.Text = "Inicio: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Integrar();
                lblFinal.Text = "Finalizo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnIntegracionParcial_Click(object sender, EventArgs e)
        {
            objEIntegracion.TipoIntegracion = 'P';
            lblTitulo.Text = objEIntegracion.DescripcionIntegracion;

                lblInicio.Text = "Inicio: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Integrar();
                lblFinal.Text = "Finalizo: " + DateTime.Now;

        }


        private void Integrar() {
            try
            {
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 140;
            txtDatos.Text = "ELIMINANDO DATOS";
            this.Update();
            objLIntegracion.EliminarDatos(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
            AumentarProgress(progressBar, 20);
            txtDatos.Text += Environment.NewLine;

            txtDatos.Text += "INTEGRANDO NAVE 3";
            this.Update();
            objLIntegracion.InsertarDatosWiki(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
                AumentarProgress(progressBar, 20);
                txtDatos.Text += Environment.NewLine;

                txtDatos.Text += "INTEGRANDO NAVE 7";
            this.Update();
            objLIntegracion.InsertarDatosNave7(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
            AumentarProgress(progressBar, 20);
            txtDatos.Text += Environment.NewLine;
            txtDatos.Text += "INTEGRANDO VILLA MARIA";
            this.Update();
            objLIntegracion.InsertarDatosVillaMaria(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
            AumentarProgress(progressBar, 20);
            txtDatos.Text += Environment.NewLine;
            txtDatos.Text += "INTEGRANDO RIO CUARTO";
            this.Update();
            objLIntegracion.InsertarDatosRioCuarto(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
            AumentarProgress(progressBar, 20);
            txtDatos.Text += Environment.NewLine;
            txtDatos.Text += "INTEGRANDO SUCURSAL 6";
            this.Update();
            objLIntegracion.InsertarDatosSucursal6(objEIntegracion);
            txtDatos.Text += "    COMPLETADO";
            this.Update();
            AumentarProgress(progressBar, 20);

                txtDatos.Text += Environment.NewLine;
                txtDatos.Text += "INTEGRANDO DEPOSITO";
                this.Update();
                objLIntegracion.InsertarDatosDeposito(objEIntegracion);
                txtDatos.Text += "    COMPLETADO";
                this.Update();
                AumentarProgress(progressBar, 20);

                Logica.Backup objLBackup = new Logica.Backup();
                if (objEIntegracion.TipoIntegracion == 'T')
                    objLBackup.Agregar(8, "Total");
                else
                    objLBackup.Agregar(8, "Parcial");
            }
            catch (Exception ex)
            {
                txtDatos.Text += "    ERROR";
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AumentarProgress(ProgressBar p, int valor) {
            int total = p.Value;
            for(int x=p.Value+1;  x<= total + valor; x++)
            {
                p.Value = x;
            }
        }

        private void frmIntegracion_Load(object sender, EventArgs e)
        {

        }
    }
}
