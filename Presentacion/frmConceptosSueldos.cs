using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConceptosSueldos : Presentacion.frmColor
    {
        Logica.ConceptosAsociadosASueldos objLConcepto = new Logica.ConceptosAsociadosASueldos();
        Entidades.ConceptoAsociadoASueldo objEConcepto = new Entidades.ConceptoAsociadoASueldo();
        public frmConceptosSueldos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            // BotonesInicial();
            CargarValores();
            BotonesInicial();
        }

        private void Titulo()
        {
            this.Text = "ASOCIACION DE CONCEPTOS A SUELDOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            //dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Descripcion"].Width = 200;
        }

        private void CargarValores()
        {
            TraerConceptos();
        }

        private void TraerConceptos()
        {
            try
            {
                dgvDatos.DataSource = objLConcepto.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            groupBox1.Enabled = false;
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                    if (Convert.ToChar(row.Cells["TipoMonto"].Value).Equals('F'))
                    {
                        rbFijo.Checked = true;
                    }
                    else {
                        rbPorcentaje.Checked = true;
                    }
                    txtMonto.Text = row.Cells["Valor"].Value.ToString();
                }
            }
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            this.groupBox1.Enabled = true;
            this.rbFijo.Checked = true;
            this.txtMonto.Text = "";

            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtMonto.Text = "";
            this.rbFijo.Checked = true;
            
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            this.groupBox1.Enabled = false;
            this.txtDescripcion.Enabled = false;
            BotonesInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                objEConcepto.Codigo = 0;
            }
            else
            {
                objEConcepto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEConcepto.Descripcion = txtDescripcion.Text.Trim();
            if (rbFijo.Checked)
                objEConcepto.TipoMonto = 'F';
            else
                objEConcepto.TipoMonto = 'P';

            objEConcepto.Valor = Convert.ToDouble(txtMonto.Text);
            
             try
             {

                 if (objEConcepto.Codigo == 0)
                 {
                     objLConcepto.Agregar(objEConcepto);
                     MessageBox.Show("Concepto agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                        objLConcepto.Agregar(objEConcepto);
                         MessageBox.Show("Concepto Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtMonto);
            return res;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void rbFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void rbPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEConcepto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Concepto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLConcepto.Eliminar(objEConcepto);
                    TraerConceptos();
                    Limpiar();
                    MessageBox.Show("Concepto Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            groupBox1.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
    }
}
