using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPuestos : frmColor
    {
        Logica.Puesto objLogicaPuesto = new Logica.Puesto();
        Entidades.Puesto objEntidadesPuesto = new Entidades.Puesto();
        public frmPuestos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            this.Text = "ACTUALIZACION DE PUESTOS";
            Formatos();
            BotonesInicial();
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBasico, 10);
            
            TraerPuestos();
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);//, frmColor.Color);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripción"].Width = 150;
        }
        public virtual void BotonesInicial()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);
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

        public virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public virtual void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtBasico.Text = "";
            this.txtDescripcion.Enabled = true;
            this.txtBasico.Enabled = true;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
            /*Utilidades.Formatos.DataGridView_Inahabilitar(dgvDatos);*/
//            this.dgvDatos.SelectionMode=DataGridViewSelectionMode.
        }




        public virtual void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, null);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, null);
            txtDescripcion.Enabled = false;
            txtBasico.Enabled = false;
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    txtBasico.Text= row.Cells["Basico"].Value.ToString();
                }
            }
        }

        public virtual void Limpiar() {
            this.dgvDatos.ClearSelection();
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            else {
                lblCodigo.Text = "(Codigo)";
                this.txtDescripcion.Text = "";
                this.txtBasico.Text = "";
                
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            }

            this.txtDescripcion.Enabled = false;
            this.txtBasico.Enabled = false;
        }

        public virtual void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtBasico.Enabled = true;
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

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtBasico);
            return res;
        }

        public virtual void dgvDatos_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtBasico_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBasico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
    }
}
