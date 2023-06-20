using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLogo : Presentacion.frmColor
    {
        Logica.Empresa objLEmpresa = new Logica.Empresa();
        public frmLogo()
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
            this.Text = "LOGO DE LA EMPRESA";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            ofd.FileName = "";
            ofd.Filter = "Todas las imagenes|*.png; *.jpg";//"Todas las imagenes | *.jpeg, *.jpe, *.jpg, *.png, *.bmp, *.*";
            DialogResult r = ofd.ShowDialog();
            if (r == DialogResult.OK)
            {
                txtRuta.Text = ofd.FileName;
                pictureBox1.Load(txtRuta.Text);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            byte[] data = System.IO.File.ReadAllBytes(txtRuta.Text);
           // string qry = "update Empresa set Logo=@prImagen";

            try
            {
                objLEmpresa.ActualizaLogo(data);

                // De no haber error, mostrar mensaje de confirmación
                MessageBox.Show("Logo agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
