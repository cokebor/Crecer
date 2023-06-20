using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmFondos : frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.Fondo objLogicaFondos = new Logica.Fondo();

        Entidades.Banco objEntidadBanco = new Entidades.Banco();
        Entidades.Fondo objEntidadFondo = new Entidades.Fondo();
        public frmFondos()
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


            this.cbBanco.SelectedIndexChanged += new System.EventHandler(this.cbBanco_SelectedIndexChanged);
            /* if (cbPais.Items.Count > 0)
             {
                 cbPais.SelectedIndex = -1;
                 cbPais.SelectedIndex = 0;
             }*/
            Utilidades.Combo.SeleccionarPrimerValor(cbBanco);

        }


        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE FONDOS COMUNES";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtFondo, 100);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbBanco);
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
            Utilidades.Combo.Llenar(cbBanco, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
            }catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtFondo.Text = "";
            this.txtFondo.Enabled = true;
            
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtFondo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            lblCodigo.Text = "(Codigo)";
            this.txtFondo.Text = "";
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
      
            this.txtFondo.Enabled = false;
            
            Utilidades.Combo.SeleccionarPrimerValor(cbBanco);

            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtFondo.Enabled = true;
            txtFondo.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void TraerFondos(Entidades.Banco pBanco)
        {
                dgvDatos.DataSource = objLogicaFondos.ObtenerTodos(pBanco);
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFondo.Focus();
                return;
            }

            if (lblCodigo.Text == "(Codigo)")
            {
                objEntidadFondo.Codigo = 0;
            }
            else
            {
                objEntidadFondo.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadFondo.Nombre = txtFondo.Text.Trim();
            objEntidadFondo.Banco = objLBanco.ObtenerUno(Convert.ToInt32(cbBanco.SelectedValue));

            try
            {
                if (objEntidadFondo.Codigo == 0)
                {
                    objLogicaFondos.Agregar(objEntidadFondo);
                    MessageBox.Show("Fondo agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaFondos.Agregar(objEntidadFondo);
                        MessageBox.Show("Fondo modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerFondos(objEntidadFondo.Banco);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtFondo.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtFondo.Text = row.Cells["Descripción"].Value.ToString();
                    cbBanco.SelectedValue = row.Cells["CodigoBanco"].Value.ToString();
                }
            }
        }

        private void cbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnNuevo.Enabled == true) { 
                lblCodigo.Text = "(Codigo)";
                txtFondo.Text = "";
            }
            if (cbBanco.SelectedIndex != -1 && txtFondo.Enabled == false)
            {
                try
                {
                    objEntidadBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBanco.SelectedValue));
                    TraerFondos(objEntidadBanco);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadFondo.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Fondo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaFondos.Eliminar(objEntidadFondo);
                    objEntidadBanco.Codigo = Convert.ToInt32(cbBanco.SelectedValue);
                    TraerFondos(objEntidadBanco);
                    Limpiar();
                    MessageBox.Show("Fondo eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            res = Utilidades.Validar.TextBoxEnBlanco(txtFondo);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbBanco);
            return res;
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void frmFondos_Activated(object sender, EventArgs e)
        {
            CargarValores();
        }

    }
}
    