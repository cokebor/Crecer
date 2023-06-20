using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmObraSocial : Presentacion.frmBaseTextBox
    {
        Logica.ObraSocial objLogicaObraSocial = new Logica.ObraSocial();
        Entidades.ObraSocial objEntidadesObraSocial = new Entidades.ObraSocial();
        public frmObraSocial()
        {
            InitializeComponent();
            ConfiguracionInicial();
            this.btnNuevo.Enabled = false;
        }

        private void ConfiguracionInicial()
        {
            this.Text = "ADMINISTRACION DE OBRAS SOCIALES";
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            TraerObrasSociales();
        }
        private void TraerObrasSociales()
        {
            try
            {
                dgvDatos.DataSource = objLogicaObraSocial.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void BotonesInicial()
        {
          //  btnNuevo.Enabled = false;
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);
            
        }

        public override void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            if (lblCodigo.Text == "(Codigo)")
            {
                objEntidadesObraSocial.Codigo = 0;
            }
            else
            {
                objEntidadesObraSocial.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesObraSocial.Nombre = txtDescripcion.Text.Trim();

            try
            {

                if (objEntidadesObraSocial.Codigo == 0)
                {
                    objLogicaObraSocial.Agregar(objEntidadesObraSocial);
                    MessageBox.Show("Obra Social agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaObraSocial.Agregar(objEntidadesObraSocial);
                        MessageBox.Show("Obra Social modificada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerObrasSociales();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesObraSocial.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Obra Social seleccionada?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaObraSocial.Eliminar(objEntidadesObraSocial);
                    TraerObrasSociales();
                    Limpiar();
                    MessageBox.Show("Obra Social eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }

    }
}
