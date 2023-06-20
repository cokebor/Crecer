using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRubroProducto : Presentacion.frmBaseTextBox
    {
        Logica.RubroProducto objLogicaRubro = new Logica.RubroProducto();
        Entidades.RubroProducto objEntidadesRubroProducto = new Entidades.RubroProducto();
        public frmRubroProducto()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            AgregarColumna();
            LimitesTamaños();
            CargarValores();
        }
        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE RUBROS";
        }

        private void AgregarColumna() {
            dgvDatos.Columns.Add("IncluirEnInforme", "IncluirEnInforme");
            dgvDatos.Columns["IncluirEnInforme"].Visible = false;
            dgvDatos.Columns["IncluirEnInforme"].DataPropertyName = "IncluirEnInforme";
        }
        public override void BotonesInicial()
        {
            //  btnNuevo.Enabled = false;
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);

        }

        public override void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    cbIncluirEnInforme.Checked = Convert.ToBoolean(row.Cells["IncluirEnInforme"].Value);
                }
            }
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 25);
        }
        private void CargarValores()
        {
            TraerRubros();
        }

        private void TraerRubros()
        {
            try
            {
                dgvDatos.DataSource = objLogicaRubro.ObtenerTodos();

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
            return res;
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
                objEntidadesRubroProducto.Codigo = 0;
            }
            else
            {
                objEntidadesRubroProducto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesRubroProducto.Descripcion = txtDescripcion.Text.Trim();
            objEntidadesRubroProducto.IncluirEnInforme = cbIncluirEnInforme.Checked;
            try
            {

                if (objEntidadesRubroProducto.Codigo == 0)
                {
                    objLogicaRubro.Agregar(objEntidadesRubroProducto);
                    MessageBox.Show("Rubro agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaRubro.Agregar(objEntidadesRubroProducto);
                        MessageBox.Show("Rubro Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerRubros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesRubroProducto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Rubro seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaRubro.Eliminar(objEntidadesRubroProducto);
                    TraerRubros();
                    Limpiar();
                    MessageBox.Show("Rubro Eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            base.dgvDatos_DoubleClick(sender, e);
            cbIncluirEnInforme.Enabled = true;
        }
    }
}
