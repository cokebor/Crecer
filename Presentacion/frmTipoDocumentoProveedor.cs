using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmTipoDocumentoProveedor : Presentacion.frmColor
    {
        Logica.TipoDoc objLTipoDoc = new Logica.TipoDoc();
        Logica.TipoDocumentoProveedor objLTipoDocProveedor = new Logica.TipoDocumentoProveedor();
        Logica.TipoInscripcion objLTipoInscripcion = new Logica.TipoInscripcion();
        Logica.Numerador objLNumerador = new Logica.Numerador();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        Entidades.TipoDocumentoProveedor objETipoDocProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.TipoInscripcion objETipoInscripcion = new Entidades.TipoInscripcion();
        Entidades.Numerador objENumeradores = new Entidades.Numerador();
        public frmTipoDocumentoProveedor()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmTipoDocumentoProveedor(Entidades.TipoDocumentoProveedor pTipo){
            InitializeComponent();
            ConfiguracionInicial(pTipo);
        }

        private void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            Utilidades.TabControl.Formato(tabTipoDocumentoCliente, frmColor.Color);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbLetra);
            CargarValores();
        }

        private void ConfiguracionInicial(Entidades.TipoDocumentoProveedor pTipo)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbLetra);
            Utilidades.TabControl.Formato(tabTipoDocumentoCliente, frmColor.Color);
            CargarValores();
            CargarvaloresTipoSeleccionado(pTipo);
        }

        private void CargarvaloresTipoSeleccionado(Entidades.TipoDocumentoProveedor pTipo) {
            TipoDocumentoProveedor = pTipo.Codigo;
            lblCodigo.Text = TipoDocumentoProveedor.ToString();
            cbTipo.SelectedValue = pTipo.TipoDoc.Codigo;
            txtDescripcion.Text = pTipo.Descripcion;
            txtCodigoNumerador.Text = pTipo.Numerador.Codigo.ToString();
            cbLetra.Text = Convert.ToString(pTipo.Letra);
            switch (pTipo.AfectaCtaCte){
                case 'D':
                    rbACCDebito.Checked=true;
                    break;
                case 'C':
                    rbACCCredito.Checked = true;
                    break;
                case 'N':
                    rbACCNoAfecta.Checked = true;
                    break;
            }

            switch (pTipo.AfectaCaja)
            {
                case 'I':
                    rbACIngreso.Checked = true;
                    break;
                case 'E':
                    rbACEgreso.Checked = true;
                    break;
                case 'N':
                    rbACNoAfecta.Checked = true;
                    break;
            }

            switch (pTipo.AfectaIVA)
            {
                case 'D':
                    rbAIDebito.Checked = true;
                    break;
                case 'C':
                    rbAICredito.Checked = true;
                    break;
                case 'N':
                    rbAINoDiscrimina.Checked = true;
                    break;
            }

            switch (pTipo.TipoDiscIVA)
            {
                case 'L':
                    rbLinea.Checked = true;
                    break;
                case 'P':
                    rbPie.Checked = true;
                    break;
                case 'N':
                    rbNoDiscrimina.Checked = true;
                    break;
            }
            
            for (int i = 0; i < cblTipoIVAAsociados.Items.Count; i++)
            {
                foreach (Entidades.TipoInscripcion ti in pTipo.TiposInscripcion) {
                    DataRowView dt = (DataRowView)cblTipoIVAAsociados.Items[i];
                    if(Convert.ToInt32(dt["Codigo"])==ti.Codigo)
                        cblTipoIVAAsociados.SetItemChecked(i, true);
                }
                
            }
            foreach (Entidades.TipoDocumentoProveedorImpuesto item in pTipo.Impuestos)
            {
                dgvDatos.Rows.Add(item.Impuesto.Codigo, item.Impuesto.Descripcion, item.Porcentaje, item.ObtenerDel(), item.Del, item.Regimen.Codigo);
            }
        }
        private void Titulo() {
            this.Text = "ADMINISTRACION DE TIPO DE DOCUMENTOS PROVEEDORES";
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoNumerador, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPorcentaje, 4);
        }

        private void Formatos() {
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Combo.Formato(cbRetenciones);
            Utilidades.Combo.Formato(cbRegimenes);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        }

        private void BotonesInicial() {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores() {
            try
            {
                CargarTipoDoc();
                CargarTipoIvaAsociados();
                CargarImpuestos();
                CargarRegimenes();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTipoDoc() {
            try
            {
                Utilidades.Combo.Llenar(cbTipo, objLTipoDoc.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRegimenes()
        {
            try
            {
                Utilidades.Combo.Llenar(cbRegimenes,new Logica.Regimen().ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImpuestos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbRetenciones, objLImpuesto.ObtenerTodosCompras(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarTipoIvaAsociados()
        {
            try
            {
                ((ListBox)cblTipoIVAAsociados).DataSource= objLTipoInscripcion.ObtenerTodos();
                ((ListBox)cblTipoIVAAsociados).DisplayMember = "Descripcion";
                ((ListBox)cblTipoIVAAsociados).ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            txtDescripcion.Focus();
        }
        
        
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        
        private bool Validar() {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNumerador);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }

        private bool ValidarRetencion()
        {
            if (txtPorcentaje.Text.Equals(""))
                return false;
            else if (Convert.ToDouble(txtPorcentaje.Text) > 0 && Convert.ToDouble(txtPorcentaje.Text) <= 100)
                return true;
            else
                return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            TipoDocumentoProveedor = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            objETipoDocProveedor.Codigo = Convert.ToInt32(TipoDocumentoProveedor);
            objETipoDocProveedor.Descripcion = txtDescripcion.Text.Trim();
            objETipoDocProveedor.TipoDoc.Codigo = cbTipo.SelectedValue.ToString();
            objETipoDocProveedor.Numerador.Codigo = Convert.ToInt32(txtCodigoNumerador.Text.Trim());
            if(cbLetra.Text.Trim()!="")
                objETipoDocProveedor.Letra = Convert.ToChar(cbLetra.Text);
            if (rbACCDebito.Checked)
            {
                objETipoDocProveedor.AfectaCtaCte = Convert.ToChar("D");
            }
            else if (rbACCCredito.Checked)
            {
                objETipoDocProveedor.AfectaCtaCte = Convert.ToChar("C");
            }
            else if (rbACCNoAfecta.Checked)
            {
                objETipoDocProveedor.AfectaCtaCte = Convert.ToChar("N");
            }

            if (rbACIngreso.Checked)
            {
                objETipoDocProveedor.AfectaCaja = Convert.ToChar("I");
            }
            else if (rbACEgreso.Checked)
            {
                objETipoDocProveedor.AfectaCaja = Convert.ToChar("E");
            }
            else if (rbACNoAfecta.Checked)
            {
                objETipoDocProveedor.AfectaCaja = Convert.ToChar("N");
            }

            if (rbAIDebito.Checked)
            {
                objETipoDocProveedor.AfectaIVA = Convert.ToChar("D");
            }
            else if (rbAICredito.Checked)
            {
                objETipoDocProveedor.AfectaIVA = Convert.ToChar("C");
            }
            else if (rbAINoDiscrimina.Checked)
            {
                objETipoDocProveedor.AfectaIVA = Convert.ToChar("N");
            }

            if (rbLinea.Checked)
            {
                objETipoDocProveedor.TipoDiscIVA = Convert.ToChar("L");
            }
            else if (rbPie.Checked)
            {
                objETipoDocProveedor.TipoDiscIVA = Convert.ToChar("P");
            }
            else if (rbNoDiscrimina.Checked)
            {
                objETipoDocProveedor.TipoDiscIVA = Convert.ToChar("N");
            }

            objETipoDocProveedor.TiposInscripcion.Clear();
            foreach (DataRowView dr in cblTipoIVAAsociados.CheckedItems) {
                Entidades.TipoInscripcion ti = new Entidades.TipoInscripcion();
                ti.Codigo = Convert.ToInt32(dr["Codigo"]);
                ti.Descripcion = dr["Descripcion"].ToString();
                objETipoDocProveedor.TiposInscripcion.Add(ti);
            }

            objETipoDocProveedor.Impuestos.Clear();
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                Entidades.TipoDocumentoProveedorImpuesto tdp = new Entidades.TipoDocumentoProveedorImpuesto();
                tdp.Impuesto.Codigo= Convert.ToInt32(dr.Cells["CodigoImpuesto"].Value);
                tdp.Porcentaje = Convert.ToDouble(dr.Cells["Porcentaje"].Value);
                tdp.Del = Convert.ToChar(dr.Cells["Del2"].Value);
                tdp.Regimen.Codigo = Convert.ToInt32(dr.Cells["CodigoRegimen"].Value);
                objETipoDocProveedor.Impuestos.Add(tdp);
            }
            
            try {
                if (TipoDocumentoProveedor == 0) {
                    objLTipoDocProveedor.Agregar(objETipoDocProveedor);
                    Limpiar();
                    MessageBox.Show("Tipo agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objETipoDocProveedor.Codigo = TipoDocumentoProveedor;
                        objLTipoDocProveedor.Agregar(objETipoDocProveedor);
                        Limpiar();
                        MessageBox.Show("Tipo modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar() {
            lblCodigo.Text = "(Codigo)";
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            BotonesInicial();
            rbACCNoAfecta.Checked = true;
            rbACNoAfecta.Checked = true;
            rbAINoDiscrimina.Checked = true;
            rbNoDiscrimina.Checked = true;
            rbNeto.Checked = true;
            tabTipoDocumentoCliente.SelectedIndex = 0;
        }




        private int tipoDocumentoProveedor;

        public int TipoDocumentoProveedor
        {
            get
            {
                return tipoDocumentoProveedor;
            }

            set
            {
                tipoDocumentoProveedor = value;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el Tipo de Documento seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objETipoDocProveedor.Codigo = TipoDocumentoProveedor;
                    objLTipoDocProveedor.Eliminar(objETipoDocProveedor);
                    Limpiar();
                    MessageBox.Show("Tipo eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmTipoDocumentoProveedorBuscar("TipoDocumento", this));
            this.Close();
        }

        private void txtCodigoNumerador_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoNumerador.Text.Trim().Equals(""))
                {
                    objENumeradores = objLNumerador.ObtenerUno(Convert.ToInt32(txtCodigoNumerador.Text.Trim()));
                    if (objENumeradores != null)
                        lblNumerador.Text = objENumeradores.Descripcion;
                    else
                        lblNumerador.Text = "";
                }
                else
                {
                    objENumeradores = null;
                    lblNumerador.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoNumerador_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        public void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmNumeradorBuscar("TipoDocumentoProveedor", this));
                    break;
            }
        }

        private void txtCodigoNumerador_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACCDebito_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACCCredito_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACCNoAfecta_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbACNoAfecta_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbAIDebito_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbAICredito_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbAINoDiscrimina_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbLinea_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbPie_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void rbNoDiscrimina_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbRetenciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpRetenciones_Click(object sender, EventArgs e)
        {

        }

        private void txtPocentaje_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarRetencion().Equals(false))
            {
                MessageBox.Show("El Porcentaje debe ser mayor a cero y menor a cien!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CodigoImpuesto"].Value) == Convert.ToInt32(cbRetenciones.SelectedValue))
                {
                    MessageBox.Show("Impuesto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string del="";
            string del2 = "";
            if (rbNeto.Checked) {
                del = rbNeto.Text;
                del2 = rbNeto.Tag.ToString();
            }else if (rbIVA.Checked)
            {
                del = rbIVA.Text;
                del2 = rbIVA.Tag.ToString();
            }
            else if (rbTotal.Checked)
            {
                del = rbTotal.Text;
                del2 = rbTotal.Tag.ToString();
            }

            dgvDatos.Rows.Add(Convert.ToInt32(cbRetenciones.SelectedValue), cbRetenciones.Text, Convert.ToDouble(txtPorcentaje.Text), del, del2, Convert.ToInt32(cbRegimenes.SelectedValue));

            Utilidades.Combo.SeleccionarPrimerValor(cbRetenciones);
            txtPorcentaje.Text = "";
            rbNeto.Checked = true;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
            }
        }

        private void txtPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtPorcentaje_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}
