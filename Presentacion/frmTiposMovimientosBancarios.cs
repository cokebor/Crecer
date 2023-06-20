using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmTiposMovimientosBancarios : frmColor
    {
        
        Logica.TipoMovimientoBancario objLogicaTipoMovimientoBancario = new Logica.TipoMovimientoBancario();
    
       Entidades.TipoMovimientoBancario objETipoMovimientoBancario = new Entidades.TipoMovimientoBancario();
        public frmTiposMovimientosBancarios()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }

        private void ConfiguracionInicial()
        {
            dgvDatos.AutoGenerateColumns = false;

            Titulo();

            LimitesTamaños();

            Formatos();

            BotonesInicial();

            CargarValores();


        }


        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE TIPO DE MOVIMIENTOS BANCARIOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripción"].Width = 150;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void CargarValores()
        {
            try
            {
                dgvDatos.DataSource = objLogicaTipoMovimientoBancario.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            rbAcredita.Checked = true;
            rbAcredita.Enabled = true;
            rbDebita.Enabled = true;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            rbAcredita.Checked = true;
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
      
            this.txtDescripcion.Enabled = false;
            rbAcredita.Enabled = false;
            rbDebita.Enabled = false;
            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            rbAcredita.Enabled = true;
            rbDebita.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
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
                objETipoMovimientoBancario.Codigo = 0;
            }
            else
            {
                objETipoMovimientoBancario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objETipoMovimientoBancario.Descripcion = txtDescripcion.Text.Trim();

            if (rbAcredita.Checked)
            {
                objETipoMovimientoBancario.AfectaCuenta = 'A';
            }
            else {
                objETipoMovimientoBancario.AfectaCuenta = 'D';
            }

            try
            {
                if (objETipoMovimientoBancario.Codigo == 0)
                {
                    objLogicaTipoMovimientoBancario.Agregar(objETipoMovimientoBancario);
                    MessageBox.Show("Tipo Movimiento Bancario agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaTipoMovimientoBancario.Agregar(objETipoMovimientoBancario);
                        MessageBox.Show("Tipo Movimiento Bancario modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                CargarValores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            rbAcredita.Enabled = false;
            rbDebita.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    if (row.Cells["AfectaCuenta"].Value.Equals("A"))
                    {
                        rbAcredita.Checked = true;
                    }
                    else
                        rbDebita.Checked = true;
                    
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
           objETipoMovimientoBancario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Tipo Movimiento Bancario?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaTipoMovimientoBancario.Eliminar(objETipoMovimientoBancario);
                    CargarValores();
                    Limpiar();
                    MessageBox.Show("Tipo Movimiento Bancario eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    