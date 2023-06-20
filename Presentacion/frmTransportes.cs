using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmTransportes : Presentacion.frmBaseTextBox
    {
        Logica.Transporte objLogicaTransporte = new Logica.Transporte();
        Entidades.Transporte objEntidadesTransporte = new Entidades.Transporte();
        public frmTransportes()
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
            this.Text = "ACTUALIZACION DE TRANSPORTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void CargarValores()
        {
            TraerTransportes();
        }
        private void TraerTransportes()
        {
                dgvDatos.DataSource = objLogicaTransporte.ObtenerTodos();
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
                objEntidadesTransporte.Codigo = 0;
            }
            else
            {
                objEntidadesTransporte.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesTransporte.Descripcion = txtDescripcion.Text.Trim();

            try
            {
                if (objEntidadesTransporte.Codigo == 0)
                {
                    objLogicaTransporte.Agregar(objEntidadesTransporte);
                    MessageBox.Show("Transporte agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaTransporte.Agregar(objEntidadesTransporte);
                        MessageBox.Show("Transporte Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesTransporte.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Transporte?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaTransporte.Eliminar(objEntidadesTransporte);
                    //TraerTransportes();
                    Limpiar();
                    TraerTransportes();
                    MessageBox.Show("Transporte Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
