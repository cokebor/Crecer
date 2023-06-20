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
    public partial class frmBaseTextBox : frmColor
    {
        public frmBaseTextBox()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            BotonesInicial();
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);//, frmColor.Color);
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripción"].Width = 150;
        }
        public virtual void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }



        public virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public virtual void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enabled = true;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
            /*Utilidades.Formatos.DataGridView_Inahabilitar(dgvDatos);*/
//            this.dgvDatos.SelectionMode=DataGridViewSelectionMode.
        }




        public virtual void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
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

        public virtual void Limpiar() {
            this.dgvDatos.ClearSelection();
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            else {
                lblCodigo.Text = "(Codigo)";
                this.txtDescripcion.Text = "";
                
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            }

            this.txtDescripcion.Enabled = false;
        }

        public virtual void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        public virtual void dgvDatos_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
