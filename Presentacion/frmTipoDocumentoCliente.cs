using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmTipoDocumentoCliente : Presentacion.frmColor
    {
        Logica.TipoDoc objLTipoDoc = new Logica.TipoDoc();
        Logica.Numerador objLNumerador = new Logica.Numerador();
        Logica.TipoDocumentoCliente objLTipoDocCliente = new Logica.TipoDocumentoCliente();
        Logica.TipoInscripcion objLTipoInscripcion = new Logica.TipoInscripcion();

        Entidades.Numerador objENumeradores = new Entidades.Numerador();
        Entidades.TipoDocumentoCliente objETipoDocCliente = new Entidades.TipoDocumentoCliente();
        Entidades.TipoInscripcion objETipoInscripcion = new Entidades.TipoInscripcion();

        public frmTipoDocumentoCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmTipoDocumentoCliente(Entidades.TipoDocumentoCliente pTipo){
            InitializeComponent();
            ConfiguracionInicial(pTipo);
        }

        private void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            Utilidades.ControlesGenerales.Deshabilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }

        private void ConfiguracionInicial(Entidades.TipoDocumentoCliente pTipo)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
            CargarvaloresTipoSeleccionado(pTipo);
        }

        private void CargarvaloresTipoSeleccionado(Entidades.TipoDocumentoCliente pTipo) {
            TipoDocumentoCliente = pTipo.Codigo;
            lblCodigo.Text = TipoDocumentoCliente.ToString();
            cbTipo.SelectedValue = pTipo.TipoDoc.Codigo;
            txtDescripcion.Text = pTipo.Descripcion;
            txtCodigoNumerador.Text = pTipo.Numerador.Codigo.ToString();
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
            cbElectronico.Checked = pTipo.Electronico;
            cbFacturasM.Checked = pTipo.FacturasM;

            for (int i = 0; i < cblTipoIVAAsociados.Items.Count; i++)
            {
                foreach (Entidades.TipoInscripcion ti in pTipo.TiposInscripcion) {
                    DataRowView dt = (DataRowView)cblTipoIVAAsociados.Items[i];
                    if(Convert.ToInt32(dt["Codigo"])==ti.Codigo)
                        cblTipoIVAAsociados.SetItemChecked(i, true);
                }
                
            }
            
      

        }
        private void Titulo() {
            this.Text = "ACTUALIZACION DE TIPO DE DOCUMENTOS CLIENTES";
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 35);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoNumerador, 4);
        }

        private void Formatos() {
            Utilidades.Combo.Formato(cbTipo);
        }

        private void BotonesInicial() {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores() {
            try
            {
                CargarTipoDoc();
                CargarTipoIvaAsociados();
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

        public void AccesosRapidos(KeyEventArgs e) {
            switch (e.KeyValue) {
                case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmNumeradorBuscar("TipoDocumento", this));
                    break;
            }
        }
        
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoNumerador_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
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

        private void txtCodigoNumerador_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
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

        private void rbAIDebito_KeyUp(object sender, KeyEventArgs e)
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

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private bool Validar() {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNumerador);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            TipoDocumentoCliente = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            objETipoDocCliente.Codigo = Convert.ToInt32(TipoDocumentoCliente);
            objETipoDocCliente.Descripcion = txtDescripcion.Text.Trim();
            objETipoDocCliente.TipoDoc.Codigo = cbTipo.SelectedValue.ToString();
            objETipoDocCliente.Numerador.Codigo = Convert.ToInt32(txtCodigoNumerador.Text.Trim());
            if (rbACCDebito.Checked)
            {
                objETipoDocCliente.AfectaCtaCte = Convert.ToChar("D");
            }
            else if (rbACCCredito.Checked)
            {
                objETipoDocCliente.AfectaCtaCte = Convert.ToChar("C");
            }
            else if (rbACCNoAfecta.Checked)
            {
                objETipoDocCliente.AfectaCtaCte = Convert.ToChar("N");
            }

            if (rbACIngreso.Checked)
            {
                objETipoDocCliente.AfectaCaja = Convert.ToChar("I");
            }
            else if (rbACEgreso.Checked)
            {
                objETipoDocCliente.AfectaCaja = Convert.ToChar("E");
            }
            else if (rbACNoAfecta.Checked)
            {
                objETipoDocCliente.AfectaCaja = Convert.ToChar("N");
            }

            if (rbAIDebito.Checked)
            {
                objETipoDocCliente.AfectaIVA = Convert.ToChar("D");
            }
            else if (rbAICredito.Checked)
            {
                objETipoDocCliente.AfectaIVA = Convert.ToChar("C");
            }
            else if (rbAINoDiscrimina.Checked)
            {
                objETipoDocCliente.AfectaIVA = Convert.ToChar("N");
            }

            if (rbLinea.Checked)
            {
                objETipoDocCliente.TipoDiscIVA = Convert.ToChar("L");
            }
            else if (rbPie.Checked)
            {
                objETipoDocCliente.TipoDiscIVA = Convert.ToChar("P");
            }
            else if (rbNoDiscrimina.Checked)
            {
                objETipoDocCliente.TipoDiscIVA = Convert.ToChar("N");
            }

            objETipoDocCliente.Electronico = cbElectronico.Checked;
            objETipoDocCliente.FacturasM = cbFacturasM.Checked;

            foreach (DataRowView dr in cblTipoIVAAsociados.CheckedItems) {
                Entidades.TipoInscripcion ti = new Entidades.TipoInscripcion();
                ti.Codigo = Convert.ToInt32(dr["Codigo"]);
                ti.Descripcion = dr["Descripcion"].ToString();
                objETipoDocCliente.TiposInscripcion.Add(ti);
            }

            
            try {
                if (TipoDocumentoCliente == 0) {
                    objLTipoDocCliente.Agregar(objETipoDocCliente);
                    Limpiar();
                    MessageBox.Show("Tipo agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objETipoDocCliente.Codigo = TipoDocumentoCliente;
                        objLTipoDocCliente.Agregar(objETipoDocCliente);
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
            tabTipoDocumentoCliente.SelectedIndex = 0;
        }




        private int tipoDocumentoCliente;

        public int TipoDocumentoCliente
        {
            get
            {
                return tipoDocumentoCliente;
            }

            set
            {
                tipoDocumentoCliente = value;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el Tipo de Documento seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objETipoDocCliente.Codigo = TipoDocumentoCliente;
                    objLTipoDocCliente.Eliminar(objETipoDocCliente);
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
            Utilidades.Formularios.Abrir(this.MdiParent, new frmTipoDocumentoClienteBuscar("TipoDocumento", this));
            this.Close();
        }
        
    }
}
