using System;

using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPais : frmBaseTextBox
    {
        Logica.Pais objLogicaPais = new Logica.Pais();
        Entidades.Pais objEntidadesPais = new Entidades.Pais();
        public frmPais()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE PAISES";
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
        }
        private void CargarValores()
        {
            TraerPaises();
        }
        private void TraerPaises()
        {
            try
            {
                dgvDatos.DataSource = objLogicaPais.ObtenerTodos();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                objEntidadesPais.Codigo = 0;
            }
            else {
                objEntidadesPais.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            
            objEntidadesPais.Descripcion = txtDescripcion.Text.Trim();

            try
            {
                
                if (objEntidadesPais.Codigo == 0)
                {
                    objLogicaPais.Agregar(objEntidadesPais);
                    MessageBox.Show("Pais agregado exitosamente!",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaPais.Agregar(objEntidadesPais);
                        MessageBox.Show("Pais Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerPaises();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesPais.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Pais?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaPais.Eliminar(objEntidadesPais);
                    TraerPaises();
                    Limpiar();
                    MessageBox.Show("Pais Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
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