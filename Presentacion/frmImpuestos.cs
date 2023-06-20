using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmImpuestos : frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        Logica.Impuesto objLImpuestos = new Logica.Impuesto();

        Entidades.CuentaContable objECuentaContable = new Entidades.CuentaContable();
        Entidades.Impuesto objEImpuestos = new Entidades.Impuesto();
        public frmImpuestos()
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
            Utilidades.Combo.SeleccionarPrimerValor(cbTipo);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
        }


        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE IMPUESTOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
        }
        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 50;
            dgvDatos.Columns["Descripción"].Width = 120;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores()
        {
            CargarValoresTipos();
            //CargarCuentas();
            TraerImpuestos();
        }

        private void CargarValoresTipos()
        {
            cbTipo.Items.Clear();
            cbTipo.Items.Add("Compra");
            cbTipo.Items.Add("Venta");
            if (cbTipo.SelectedValue != null)
            {
                CargarCuentas();
            }
        }
        private void CargarCuentas() {
            try {

                char tipo =cbTipo.SelectedItem.ToString().Equals("Compra") ? 'C' : 'V';
                Utilidades.Combo.Llenar(cbCuentaContable, objLCuentaContable.ObtenerImpuestosTodos(tipo), "Codigo", "Nombre");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerImpuestos()
        {
            try
            {
               dgvDatos.DataSource = objLImpuestos.ObtenerTodos();
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
            cbCuentaContable.Enabled = true;
            cbTipo.Enabled = true;
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
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            Utilidades.Combo.SeleccionarPrimerValor(cbTipo);
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
            this.txtDescripcion.Enabled = false;
            cbCuentaContable.Enabled = false;
            cbTipo.Enabled = false;
            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbCuentaContable.Enabled = true;
            cbTipo.Enabled = true;
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
                objEImpuestos.Codigo = 0;
            }
            else
            {
                objEImpuestos.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            
            objEImpuestos.Descripcion= txtDescripcion.Text.Trim();
            objEImpuestos.CuentaContable.Codigo = Convert.ToInt64(cbCuentaContable.SelectedValue);
            objEImpuestos.Tipo = cbTipo.SelectedItem.ToString().Equals("Compra") ? 'C' : 'V';
            
            try
            {
                if (objEImpuestos.Codigo == 0)
                {
                    objLImpuestos.Agregar(objEImpuestos);
                    MessageBox.Show("Impuesto agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLImpuestos.Agregar(objEImpuestos);
                        MessageBox.Show("Impuesto modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerImpuestos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            cbCuentaContable.Enabled = false;
            cbTipo.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    cbTipo.SelectedItem = row.Cells["Tipo"].Value;

                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    cbCuentaContable.SelectedValue= row.Cells["CodigoCuentaContable"].Value;
                }
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEImpuestos.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Impuesto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLImpuestos.Eliminar(objEImpuestos);
                    TraerImpuestos();
                    Limpiar();
                    MessageBox.Show("Impuesto eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            return res;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (cbTipo.SelectedIndex != -1) {
                CargarCuentas();
                Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            }*/

           /* if (btnNuevo.Enabled == true)
            {
                lblCodigo.Text = "(Codigo)";
                txtDescripcion.Text = "";
            }*/
            if (cbTipo.SelectedIndex != -1)
            {
                try
                {
                    CargarCuentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
    