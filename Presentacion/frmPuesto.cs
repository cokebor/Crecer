using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPuesto : Presentacion.frmBaseTextBox
    {
        Logica.Puesto objLogicaPuesto = new Logica.Puesto();
        Entidades.Puesto objEntidadesPuesto = new Entidades.Puesto();
        public frmPuesto()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            this.Text = "ACTUALIZACION DE PUESTOS";
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBasico, 10);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns.Add("Basico", "Basico");
            dgvDatos.Columns["Basico"].ReadOnly = true;
            dgvDatos.Columns["Estado"].Visible = false;
            TraerPuestos();
        }

        private void TraerPuestos()
        {
            try
            {
                dgvDatos.DataSource = objLogicaPuesto.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    
                }
            }
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
                objEntidadesPuesto.Codigo = 0;
            }
            else
            {
                objEntidadesPuesto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadesPuesto.Descripcion = txtDescripcion.Text.Trim();
            objEntidadesPuesto.Basico = Convert.ToDouble(txtBasico.Text.Trim());

            try
            {

                if (objEntidadesPuesto.Codigo == 0)
                {
                    objLogicaPuesto.Agregar(objEntidadesPuesto);
                    MessageBox.Show("Puesto agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaPuesto.Agregar(objEntidadesPuesto);
                        MessageBox.Show("Puesto Modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerPuestos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadesPuesto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Puesto seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaPuesto.Eliminar(objEntidadesPuesto);
                    TraerPuestos();
                    Limpiar();
                    MessageBox.Show("Puesto eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmPuesto_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
