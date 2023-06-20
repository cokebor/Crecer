using System;

using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConcepto : frmBaseTextBox
    {
        Logica.Concepto objLogicaConcepto = new Logica.Concepto();
        Entidades.Concepto objEntidadesConcepto = new Entidades.Concepto();
        public frmConcepto()
        {
            InitializeComponent();
            ConfiguracionInicial();
            dgvDatos.CellContentClick += DgvDatos_CellContentClick;
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                objEntidadesConcepto = new Entidades.Concepto();
                objEntidadesConcepto.Codigo = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);
                objEntidadesConcepto.Descripcion = dgvDatos.CurrentRow.Cells["Descripción"].Value.ToString();

                switch (e.ColumnIndex)
                {
                    case 4:
                        if (dgvDatos.CurrentRow != null)
                        {
                            // Utilidades.Formularios.Abrir(this.MdiParent, new frmAsociacionConceptosCuentasContables(objEntidadesConcepto));
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmConceptosAsociacion(objEntidadesConcepto));
                        }
                        break;
                    case 5:
                        if (dgvDatos.CurrentRow != null)
                        {
                            // Utilidades.Formularios.Abrir(this.MdiParent, new frmAsociacionConceptosCuentasContables(objEntidadesConcepto));
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmRetencionesAsociacion(objEntidadesConcepto));
                        }
                        break;
                    case 6:
                        if (dgvDatos.CurrentRow != null)
                        {
                            // Utilidades.Formularios.Abrir(this.MdiParent, new frmAsociacionConceptosCuentasContables(objEntidadesConcepto));
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmLibreDisponibilidad(objEntidadesConcepto));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns.Add("EsImpuesto", "EsImpuesto");
            dgvDatos.Columns["EsImpuesto"].Visible = false;
            dgvDatos.Columns["EsImpuesto"].DataPropertyName = "EsImpuesto";
            dgvDatos.Columns["Estado"].Visible = true;
            
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.Text = "Asociar";
            link.Name = "Asociar";
            link.UseColumnTextForLinkValue = true;
            dgvDatos.Columns.Add(link);
            dgvDatos.Columns["Asociar"].Width = 60;
            link = new DataGridViewLinkColumn();
            link.Text = "Retenc.";
            link.Name = "Retenc.";
            link.UseColumnTextForLinkValue = true;
            dgvDatos.Columns.Add(link);
            dgvDatos.Columns["Retenc."].Width = 50;
            dgvDatos.Columns["Codigo"].Visible = false;
            dgvDatos.Columns["Retenc."].Visible = false;
            //dgvDatos.ContextMenuStrip = cmsAsociar;
            link = new DataGridViewLinkColumn();
            link.Text = "Lib. Disp.";
            link.Name = "Lib. Disp.";
            link.UseColumnTextForLinkValue = true;
            dgvDatos.Columns.Add(link);
            dgvDatos.Columns["Lib. Disp."].Width = 50;
            dgvDatos.Columns["Estado"].DisplayIndex = 6;

            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE CONCEPTOS DE CAJA";
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void CargarValores()
        {
            TraerConceptos();
        }
        private void TraerConceptos()
        {
            try
            {
                
                dgvDatos.DataSource = objLogicaConcepto.ObtenerTodos();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            cbImpuesto.Enabled = false;
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    cbImpuesto.Checked = Convert.ToBoolean(row.Cells["EsImpuesto"].Value);
                }
            }
        }

        public override void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbImpuesto.Enabled = true;
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
                objEntidadesConcepto.Codigo = 0;
            }
            else {
                objEntidadesConcepto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesConcepto.Descripcion = txtDescripcion.Text.Trim();
            objEntidadesConcepto.Impuesto = cbImpuesto.Checked;
            try
            {
                
                if (objEntidadesConcepto.Codigo == 0)
                {
                    objLogicaConcepto.Agregar(objEntidadesConcepto);
                    MessageBox.Show("Concepto agregado exitosamente!",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaConcepto.Agregar(objEntidadesConcepto);
                        MessageBox.Show("Concepto Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerConceptos();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesConcepto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Concepto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaConcepto.Eliminar(objEntidadesConcepto);
                    TraerConceptos();
                    Limpiar();
                    MessageBox.Show("Concepto Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        public override void Limpiar() {
            base.Limpiar();
            cbImpuesto.Enabled = false;
            cbImpuesto.Checked = false;
        }
        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }

        public override void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cbImpuesto.Checked = false;
            this.cbImpuesto.Enabled = true;
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        public override void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void asociarACuentaContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                objEntidadesConcepto = new Entidades.Concepto();
                objEntidadesConcepto.Codigo = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);
                Utilidades.Formularios.Abrir(this.MdiParent, new frmAsociacionConceptosCuentasContables(objEntidadesConcepto));
            }
            else {
                MessageBox.Show("No selecciono ningun Concepto", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void dgvDatos_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo lugar = dgvDatos.HitTest(e.X, e.Y);
            if (lugar.Type == DataGridViewHitTestType.Cell) {
                dgvDatos.CurrentCell = dgvDatos.Rows[lugar.RowIndex].Cells[lugar.ColumnIndex];
                dgvDatos.ContextMenuStrip = cmsAsociar;
            }else
                dgvDatos.ContextMenuStrip = null;
        }

    }
}