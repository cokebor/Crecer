using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmImpresoras : Presentacion.frmColor
    {
        Logica.Empresa objEmpresa = new Logica.Empresa();

        public frmImpresoras()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Titulo();
            Formatos();
            CargarImpresoras();
            SeleccionCombo();
        }

        private void Titulo()
        {
            this.Text = "SELECCION DE IMPRESORAS";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbImpresorasComprobantes);
 //           Utilidades.Combo.Formato(cbImpresorasInformes);
            Utilidades.Combo.Formato(cbImpresorasInformes);
  //          Utilidades.Combo.Formato(cbBandejaInformes);
        }

        private void CargarImpresoras()
        {
            try
            {
                Utilidades.Combo.Llenar(cbImpresorasComprobantes, Utilidades.Impresoras.ObtenerImpresoras(), "Descripcion", "Descripcion");
                Utilidades.Combo.Llenar(cbImpresorasInformes, Utilidades.Impresoras.ObtenerImpresoras(), "Descripcion", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SeleccionCombo() {
            try
            {
                cbImpresorasComprobantes.SelectedValue = Singleton.Instancia.Usuario.ImpresoraComprobantes;
                cbImpresorasInformes.SelectedValue = Singleton.Instancia.Usuario.ImpresoraInformes;
                cbTermica.Checked = Singleton.Instancia.Usuario.Termica;

      //          cbImpresorasInformes.SelectedValue = Singleton.Instancia.Usuario.ImpresoraInformes;
       //         cbBandejaInformes.SelectedValue = Singleton.Instancia.Usuario.BandejaInformes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                objEmpresa.ActualizarImpresoras(Singleton.Instancia.Usuario.Codigo,cbImpresorasComprobantes.Text,cbTermica.Checked, cbImpresorasInformes.Text);
                Singleton.Instancia.Usuario.ImpresoraComprobantes = cbImpresorasComprobantes.Text;
                Singleton.Instancia.Usuario.Termica = cbTermica.Checked;
                Singleton.Instancia.Usuario.ImpresoraInformes = cbImpresorasInformes.Text;
         //       Singleton.Instancia.Usuario.ImpresoraInformes = cbImpresorasInformes.Text;
         //       Singleton.Instancia.Usuario.BandejaInformes = Convert.ToInt32(cbBandejaInformes.SelectedValue);
                MessageBox.Show("Datos actualizados exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void cbImpresorasComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Utilidades.Combo.Llenar(cbImpresorasInformes, Utilidades.Impresoras.ObtenerBandejas(cbImpresorasComprobantes.Text), "Codigo", "Descripcion");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        
    }
}
