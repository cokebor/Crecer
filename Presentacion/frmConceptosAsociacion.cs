using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConceptosAsociacion : Presentacion.frmColor
    {
        //Entidades.ConceptoAsociadoASueldo objEConcepto = new Entidades.ConceptoAsociadoASueldo();

        //Logica.ConceptoAsociadoASueldo objLConcepto = new Logica.ConceptoAsociadoASueldo();
        //Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.ConceptoAsociado objLConAsoc = new Logica.ConceptoAsociado();
        Entidades.Concepto objEConcepto = new Entidades.Concepto();
        public Entidades.Concepto Concepto { get; set; }
        public frmConceptosAsociacion(Entidades.Concepto pConcepto)
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
            this.Text = "ASOCIACION DE CONCEPTOS A " + Concepto.Descripcion;
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
            cbMostrarEnPago.Checked = true;
            this.txtDescripcion.Enabled = false;
            cbCuentaContable.Enabled = false;
            pDebeOhaber.Enabled = false;
            //cbMostrarEnPago.Checked = true;
            cbMostrarEnPago.Enabled = false;
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
            DataTable dt = objLConAsoc.ObtenerAsociaciones(Concepto);
            dgvDatos.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                dgvDatos.Rows.Add(item["Codigo"], item["Descripcion"],item["CodigoCuentaContable"], (Convert.ToChar(item["DebeOHaber"]).Equals('D'))?"Debe":"Haber",item["DebeOHaber"], item["Estado"], item["MostrarEnPago"]);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            cbCuentaContable.Enabled = true;
            pDebeOhaber.Enabled = true;
            cbMostrarEnPago.Checked = false;
            cbMostrarEnPago.Enabled = true;
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
            cbMostrarEnPago.Enabled = true;
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
            Entidades.ConceptoAsociado conAsociado = new Entidades.ConceptoAsociado();

            if (lblCodigo.Text == "(Codigo)")
            {
                //objEConcepto.Codigo = 0;
                conAsociado.Codigo = 0;
            }
            else
            {
                conAsociado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            conAsociado.Descripcion = txtDescripcion.Text.Trim();
            conAsociado.CuentaContable.Codigo = Convert.ToInt64(cbCuentaContable.SelectedValue);
            conAsociado.DebeOHaber = rbDebe.Checked ? 'D' : 'H';
            conAsociado.MostrarEnPago = cbMostrarEnPago.Checked;
            objEConcepto.ConceptosAsociados.Clear();
            objEConcepto.ConceptosAsociados.Add(conAsociado);
            try
            {
                if (conAsociado.Codigo == 0)
                {
                    objLConAsoc.Agregar(objEConcepto);
                    MessageBox.Show("Asociacion de Concepto agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLConAsoc.Agregar(objEConcepto);
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
            cbMostrarEnPago.Enabled = false;
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
                    cbMostrarEnPago.Checked = Convert.ToBoolean(row.Cells["MostrarEnPago"].Value);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.ConceptoAsociado conAsociado = new Entidades.ConceptoAsociado();
            conAsociado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Asociacion?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLConAsoc.Eliminar(conAsociado);
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
