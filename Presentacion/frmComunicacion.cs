using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmComunicacion : Presentacion.frmBaseTextBox
    {
        Logica.Comunicacion objLogicaComunicacion = new Logica.Comunicacion();
        Entidades.Comunicacion objEntidadesComunicacion = new Entidades.Comunicacion();

        public frmComunicacion()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            this.Text = "ADMINISTRACION DE MODOS DE COMUNICACION";
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            TraerComunicaciones();
        }

        private void TraerComunicaciones()
        {
            try
            {
                dgvDatos.DataSource = objLogicaComunicacion.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true)){
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }


            if (lblCodigo.Text == "(Codigo)")
            {
                objEntidadesComunicacion.Codigo = 0;
            }
            else
            {
                objEntidadesComunicacion.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesComunicacion.Descripcion = txtDescripcion.Text.Trim();

            try
            {

                if (objEntidadesComunicacion.Codigo == 0)
                {
                    objLogicaComunicacion.Agregar(objEntidadesComunicacion);
                    MessageBox.Show("Comunicacion agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaComunicacion.Agregar(objEntidadesComunicacion);
                        MessageBox.Show("Comunicacion Modificada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerComunicaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesComunicacion.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Modo de Comunicación seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaComunicacion.Eliminar(objEntidadesComunicacion);
                    TraerComunicaciones();
                    Limpiar();
                    MessageBox.Show("Modo de Comunicación eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validar() {
            bool res = false;
            res= Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }

        private void frmComunicacion_Load(object sender, EventArgs e)
        {

        }

        
    }
}
