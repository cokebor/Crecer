using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProvincia : frmColor
    {
        Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();

        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();
        public frmProvincia()
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
            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            Utilidades.Combo.SeleccionarPrimerValor(cbPais);
        }


        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE PROVINCIAS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbPais);
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripción"].Width = 150;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void CargarValores()
        {
            try{ 
            Utilidades.Combo.Llenar(cbPais, objLogicaPais.ObtenerActivos(), "Codigo", "Descripcion");
            }catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
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
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
      
            this.txtDescripcion.Enabled = false;
            Utilidades.Combo.SeleccionarPrimerValor(cbPais);
           /* if (this.cbPais.Items.Count > 0)
            {
                this.cbPais.SelectedIndex = 0;
            }*/

            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void TraerProvincias(Entidades.Pais pPais)
        {
                dgvDatos.DataSource = objLogicaProvincia.ObtenerTodos(pPais);

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
                objEntidadProvincia.Codigo = 0;
            }
            else
            {
                objEntidadProvincia.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadProvincia.Nombre = txtDescripcion.Text.Trim();
            objEntidadProvincia.Pais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));

            try
            {
                if (objEntidadProvincia.Codigo == 0)
                {
                    objLogicaProvincia.Agregar(objEntidadProvincia);
                    MessageBox.Show("Provincia agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaProvincia.Agregar(objEntidadProvincia);
                        MessageBox.Show("Provincia modificada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerProvincias(objEntidadProvincia.Pais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    cbPais.SelectedValue = row.Cells["CodigoPais"].Value.ToString();
                }
            }
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnNuevo.Enabled == true) { 
                lblCodigo.Text = "(Codigo)";
                txtDescripcion.Text = "";
            }
            if (cbPais.SelectedIndex != -1 && txtDescripcion.Enabled == false)
            {
                try
                {
                    objEntidadPais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));
                    TraerProvincias(objEntidadPais);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadProvincia.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Provincia?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaProvincia.Eliminar(objEntidadProvincia);
                    objEntidadPais.Codigo = Convert.ToInt32(cbPais.SelectedValue);
                    TraerProvincias(objEntidadPais);
                    Limpiar();
                    MessageBox.Show("Provincia eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPais);
            return res;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmPais());
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void frmProvincia_Activated(object sender, EventArgs e)
        {
            CargarValores();
        }

    }
}
    