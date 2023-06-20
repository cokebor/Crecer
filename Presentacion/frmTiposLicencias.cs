using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmTiposLicencias : Presentacion.frmColor
    {
        Logica.TipoLicencia objLTipoLicencia = new Logica.TipoLicencia();
        Entidades.TipoLicencia objETipoLicencia = new Entidades.TipoLicencia();
        public frmTiposLicencias()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            CargarValores();
        }

        public void Titulo()
        {
            this.Text = "ADMINISTRACION DE TIPOS DE LICENCIAS";
        }

        public void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDias, 2);
        }
        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 30;
            //dgvDatos.Columns["Descripción"].Width = 100;
            dgvDatos.Columns["Estado"].Width = 50;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        public void CargarValores()
        {
            try
            {
                TraerTiposLicencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerTiposLicencias()
        {
            try
            {
                dgvDatos.DataSource = objLTipoLicencia.ObtenerTodos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            else
            {
                lblCodigo.Text = "(Codigo)";
                Utilidades.ControlesGenerales.LimpiarControles(this);
                Utilidades.ControlesGenerales.Deshabilitar(this);
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            txtDescripcion.Text = "";
            txtDias.Text = "";
            cbDescuento.Checked = false;
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Deshabilitar(this);
            dgvDatos.Enabled = true;
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    txtDias.Text = row.Cells["LiquidacionSobre"].Value.ToString();
                    cbDescuento.Checked = Convert.ToBoolean(row.Cells["Descuento"].Value);
                }
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
                objETipoLicencia.Codigo = 0;
            }
            else
            {
                objETipoLicencia.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objETipoLicencia.Descripcion = txtDescripcion.Text.Trim();
            objETipoLicencia.Descuento = cbDescuento.Checked;
            objETipoLicencia.LiquidacionSobre = Convert.ToInt32(txtDias.Text.Trim());
            
            try
            {
                if (objETipoLicencia.Codigo == 0)
                {
                    objLTipoLicencia.Agregar(objETipoLicencia);
                    MessageBox.Show("Tipo de Licencia agregado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLTipoLicencia.Agregar(objETipoLicencia);
                        MessageBox.Show("Tipo de Licencia Modificado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerTiposLicencias();
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
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDias);
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objETipoLicencia.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Tipo de Licencia?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLTipoLicencia.Eliminar(objETipoLicencia);
                    TraerTiposLicencias();
                    Limpiar();
                    MessageBox.Show("Tipo de Licencia eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
