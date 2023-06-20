using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmBancos : Presentacion.frmBaseTextBox
    {
        Logica.Banco objLogicaBanco = new Logica.Banco();
        Entidades.Banco objEntidadesBanco = new Entidades.Banco();
        public frmBancos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }
        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE BANCOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void CargarValores()
        {
            TraerBancos();
        }
        private void TraerBancos()
        {
                dgvDatos.DataSource = objLogicaBanco.ObtenerTodos();
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
                objEntidadesBanco.Codigo = 0;
            }
            else
            {
                objEntidadesBanco.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesBanco.Descripcion = txtDescripcion.Text.Trim();

            try
            {

                if (objEntidadesBanco.Codigo == 0)
                {
                    objLogicaBanco.Agregar(objEntidadesBanco);
                    MessageBox.Show("Banco agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaBanco.Agregar(objEntidadesBanco);
                        MessageBox.Show("Banco Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesBanco.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Banco?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaBanco.Eliminar(objEntidadesBanco);
                    TraerBancos();
                    Limpiar();
                    MessageBox.Show("Banco Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
