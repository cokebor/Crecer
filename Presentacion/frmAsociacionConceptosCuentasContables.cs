using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAsociacionConceptosCuentasContables : Presentacion.frmColor
    {
        Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.ConceptoAsociado objLConcAsoc = new Logica.ConceptoAsociado();
        Entidades.Concepto objEConcepto = new Entidades.Concepto();
        public frmAsociacionConceptosCuentasContables()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmAsociacionConceptosCuentasContables(Entidades.Concepto pConcepto)
        {
            InitializeComponent();
            ConfiguracionInicial(pConcepto);
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
           // BotonesInicial();
            CargarValores();
        }

        private void ConfiguracionInicial(Entidades.Concepto pConcepto)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            CargarValores();
            if (cbConcepto.Items.Count > 0)
                cbConcepto.SelectedValue = pConcepto.Codigo;
        }
        private void Titulo()
        {
            this.Text = "ASOCIACION DE CUENTAS CONTABLES A CONCEPTOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 30);
        }
        private void Formatos()
        {
            Utilidades.Combo.Formato(cbConcepto);
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            //dgvDatos.AllowUserToOrderColumns = false;
            //dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripcion"].Width = 150;
            dgvDatos.Columns["CuentaContable"].Width = 100;
            dgvDatos.Columns["DebeOHaber"].Width = 70;
        }

        private void CargarValores()
        {

            try
            {
                CargarConceptos();
                CargarCuentasContables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarConceptos()
        {
                Utilidades.Combo.Llenar(cbConcepto, objLConcepto.ObtenerTodos(), "Codigo", "Descripcion");
   
        }
        private void CargarCuentasContables()
        {

                Utilidades.Combo.Llenar(cbCuentaContable, new Logica.CuentaContable().ObtenerTodos(), "Codigo", "NombreCompleto");
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (ValidarCuenta().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CuentaContable"].Value) == Convert.ToInt32(cbCuentaContable.SelectedValue))
                {
                    MessageBox.Show("Cuenta Contable ya ingresada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (fila.Cells["Descripcion"].Value.Equals(txtDescripcion.Text))
                {
                    MessageBox.Show("Descripción ya ingresada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            dgvDatos.Rows.Add(txtDescripcion.Text, cbCuentaContable.SelectedValue, (rbDebe.Checked) ? "Debe" : "Haber", (rbDebe.Checked) ? "D" : "H");

            txtDescripcion.Text = "";
            rbDebe.Checked = true;
        }

        private bool ValidarCuenta()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtDescripcion));
            return res;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (dgvDatos.Rows.Count > 0) {
                CargarAsociaciones();
                //objLConcepto.Asociar(objEConcepto);
                MessageBox.Show("Asociacion realizada exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else{
                MessageBox.Show("No dispone de Conceptos para Asociar!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarAsociaciones() {
            /*objEConcepto = new Entidades.Concepto();
            objEConcepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);*/
            objEConcepto.Usuario.Codigo = Singleton.Instancia.Usuario.Codigo;
            Entidades.CuentaContable cuentasContables; 
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                cuentasContables = new Entidades.CuentaContable();
                cuentasContables.Codigo = Convert.ToInt32(item.Cells["CuentaContable"].Value);
                cuentasContables.Nombre = item.Cells["Descripcion"].Value.ToString();
                cuentasContables.Tipo = Convert.ToChar(item.Cells["DebeOHaber2"].Value);
               // objEConcepto.CuentasContables.Add(cuentasContables);
            }
        }

        private void cbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                objEConcepto.Codigo= Convert.ToInt32(cbConcepto.SelectedValue);
                CargarGrilla();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla() {
            DataTable dt = objLConcAsoc.ObtenerAsociaciones(objEConcepto);
            dgvDatos.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                dgvDatos.Rows.Add(item["Descripcion"], item["CodigoCuentaContable"], (Convert.ToChar(item["DebeOHaber"]).Equals('D')) ? "Debe" : "Haber", item["DebeOHaber"]);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objEConcepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);
                objLConcepto.EliminarCuentasAsociadas(objEConcepto);
                CargarGrilla();
                MessageBox.Show("Asociacion eliminada exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}