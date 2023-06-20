using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmGrupoDeUsuario : Presentacion.frmBaseTextBox
    {
        Logica.GrupoDeUsuario objLogicaGrupoDeUsuario = new Logica.GrupoDeUsuario();
        Entidades.GrupoDeUsuario objEntidadesGrupoDeUsuario = new Entidades.GrupoDeUsuario();
        public frmGrupoDeUsuario()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            this.Text = "ADMINISTRACION DE GRUPOS DE USUARIOS";
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            TraerGrupos();
        }

        private void TraerGrupos()
        {
            try
            {
                dgvDatos.DataSource = objLogicaGrupoDeUsuario.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                objEntidadesGrupoDeUsuario.Codigo = 0;
            }
            else
            {
                objEntidadesGrupoDeUsuario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesGrupoDeUsuario.Descripcion = txtDescripcion.Text.Trim();

            try
            {

                if (objEntidadesGrupoDeUsuario.Codigo == 0)
                {
                    objLogicaGrupoDeUsuario.Agregar(objEntidadesGrupoDeUsuario);
                    MessageBox.Show("Grupo de Usuario agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaGrupoDeUsuario.Agregar(objEntidadesGrupoDeUsuario);
                        MessageBox.Show("Grupo de Usuario modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesGrupoDeUsuario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Grupo de Usuario seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaGrupoDeUsuario.Eliminar(objEntidadesGrupoDeUsuario);
                    TraerGrupos();
                    Limpiar();
                    MessageBox.Show("Grupo de Usuario eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
