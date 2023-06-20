using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRetencionesAsociacion : Presentacion.frmColor
    {

        Logica.RetencionAsociacion objLRetAsoc = new Logica.RetencionAsociacion();
        Entidades.Concepto objEConcepto = new Entidades.Concepto();
        public Entidades.Concepto Concepto { get; set; }
        public frmRetencionesAsociacion(Entidades.Concepto pConcepto)
        {
            InitializeComponent();
            Concepto = pConcepto;
            ConfiguracionInicial();
            CargarValores();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
        }
        private void Titulo()
        {
            this.Text = "ASOCIACION DE RETENCIONES/PERCEPCIONES A " + Concepto.Descripcion;
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            //dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripcion"].Width = 150;
            dgvDatos.Columns["CodigoCuentaContable"].Width = 100;
            dgvDatos.Columns["DebeOHaber"].Width = 70;
            dgvDatos.AutoGenerateColumns = false;
        }
        public void Limpiar()
        {
            //this.dgvDatos.ClearSelection();
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            rbDebe.Checked = true;
            /*Utilidades.Combo.SeleccionarPrimerValor(cbTipo);*/
            this.txtDescripcion.Enabled = false;
            cbCuentaContable.Enabled = false;
            pDebeOhaber.Enabled = false;
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            BotonesInicial();
        }
        private void CargarValores()
        {
            try
            {
                CargarCuentasContables();
                TraerConceptos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCuentasContables()
        {
                Utilidades.Combo.Llenar(cbCuentaContable, new Logica.CuentaContable().ObtenerTodos(), "Codigo", "NombreCompleto");         
        }
        private void TraerConceptos()
        {
            DataTable dt = objLRetAsoc.ObtenerAsociaciones(Concepto);
            dgvDatos.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                dgvDatos.Rows.Add(item["Codigo"], item["Descripcion"],item["CodigoCuentaContable"], (Convert.ToChar(item["DebeOHaber"]).Equals('D'))?"Debe":"Haber",item["DebeOHaber"], item["Estado"]);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            cbCuentaContable.Enabled = true;
            pDebeOhaber.Enabled = true;
            rbDebe.Checked = true;
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbCuentaContable.Enabled = true;
            pDebeOhaber.Enabled = true;
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
            objEConcepto = Concepto;
            objEConcepto.Usuario = Singleton.Instancia.Usuario;
            Entidades.RetencionAsociado retAsociado = new Entidades.RetencionAsociado();

            if (lblCodigo.Text == "(Codigo)")
            {
                //objEConcepto.Codigo = 0;
                retAsociado.Codigo = 0;
            }
            else
            {
                retAsociado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            retAsociado.Descripcion = txtDescripcion.Text.Trim();
            retAsociado.CuentaContable.Codigo = Convert.ToInt64(cbCuentaContable.SelectedValue);
            retAsociado.DebeOHaber = rbDebe.Checked ? 'D' : 'H';
            objEConcepto.RetencionesAsociados.Clear();
            objEConcepto.RetencionesAsociados.Add(retAsociado);
            try
            {
                if (retAsociado.Codigo == 0)
                {
                    objLRetAsoc.Agregar(objEConcepto);
                    MessageBox.Show("Asociacion de Retención agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLRetAsoc.Agregar(objEConcepto);
                        MessageBox.Show("Concepto modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerConceptos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validar()
        {

            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            return res;
        }
        
        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            cbCuentaContable.Enabled = false;
            pDebeOhaber.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;

            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

                    cbCuentaContable.SelectedValue = row.Cells["CodigoCuentaContable"].Value;
                    if (row.Cells["DebeOHaber"].Value.ToString().Equals("Debe"))
                    {
                        rbDebe.Checked = true;
                    }
                    else {
                        rbHaber.Checked = true;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.RetencionAsociado retAsociado = new Entidades.RetencionAsociado();
            retAsociado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Asociacion?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLRetAsoc.Eliminar(retAsociado);
                    TraerConceptos();
                   // Limpiar();
                    MessageBox.Show("Asociacion Eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
