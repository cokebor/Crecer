using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProveedor : frmColor
    {
        Logica.TipoInscripcion objLogicaTipoInscripcion = new Logica.TipoInscripcion();
        Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();
        Logica.Localidad objLogicaLocalidad = new Logica.Localidad();
        Logica.CategoriaProveedor objLogicaCategoriaProveedor = new Logica.CategoriaProveedor();
        Logica.Comunicacion objLogicaComunicacion = new Logica.Comunicacion();
        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.TipoContribuyente objLogicaTContribuyente = new Logica.TipoContribuyente();


        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();
        Entidades.Comunicacion objEntidadComunicacion = new Entidades.Comunicacion();
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();

        DataTable dtComunicaciones = new DataTable("dtComunicaciones");

        string busqueda = "";

        public frmProveedor()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmProveedor(Entidades.Proveedor pProveedor, DataTable pComunicaciones)
        {
            InitializeComponent();
            ConfiguracionInicial2(pProveedor, pComunicaciones);

        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            CargarValores();
        }

        private void ConfiguracionInicial2(Entidades.Proveedor pProveedor, DataTable pComunicaciones)
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            Utilidades.ControlesGenerales.Habilitar(this);
            CargarValores();
            txtCUIT.Habilitar();
            CargarValoresProveedorSeleccionado(pProveedor, pComunicaciones);
        }
        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombre, 60);
            Utilidades.CajaDeTexto.LimiteTamaño(txtIngresosBrutos, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDireccion, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBarrio, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoPostal,10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtComunicacion,40);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 250);
        }

        private void Formatos() {
            Utilidades.Grilla.Formato(dgvComunicaciones);
            Utilidades.Combo.Formato(cbTipoInscripcion);
            Utilidades.Combo.Formato(cbPais);
            Utilidades.Combo.Formato(cbProvincias);
            Utilidades.Combo.Formato(cbLocalidades);
            Utilidades.Combo.Formato(cbCategoria);
            Utilidades.Combo.Formato(cbComunicaciones);
            Utilidades.Combo.Formato(cbTipoContribuyente);
            Utilidades.Formularios.ConfiguracionInicial(this);
            dgvComunicaciones.Columns["Tipo"].Width = 90;

            DataColumn CodigoComunicacion = dtComunicaciones.Columns.Add("CodigoComunicacion", typeof(int));
            DataColumn Descripcion = dtComunicaciones.Columns.Add("Descripcion", typeof(string));
        }

        private void CargarValoresProveedorSeleccionado(Entidades.Proveedor pProveedor, DataTable pComunicaciones) {
            lblCodigo.Text = pProveedor.Codigo.ToString();
            txtNombre.Text = pProveedor.Nombre;
            cbTipoInscripcion.SelectedValue = pProveedor.TipoInscripcion.Codigo;
            txtCUIT.txtCUIL1.Text = pProveedor.CUIT.Substring(0, 2);
            txtCUIT.txtCUIL2.Text = pProveedor.CUIT.Substring(3, 8);
            txtCUIT.txtCUIL3.Text = pProveedor.CUIT.Substring(12, 1);
            txtIngresosBrutos.Text = pProveedor.IngresosBrutos;
            txtDireccion.Text = pProveedor.Domicilio.Direccion;
            txtNumero.Text = pProveedor.Domicilio.Numero;
            txtBarrio.Text = pProveedor.Domicilio.Barrio;
            txtCodigoPostal.Text = pProveedor.Domicilio.CodigoPostal;
            cbPais.SelectedValue = pProveedor.Domicilio.Localidad.Provincia.Pais.Codigo;
            cbProvincias.SelectedValue = pProveedor.Domicilio.Localidad.Provincia.Codigo;
            cbLocalidades.SelectedValue= pProveedor.Domicilio.Localidad.Codigo;
            cbCategoria.SelectedValue = pProveedor.CategoriaProveedor.Codigo;
            txtObservaciones.Text = pProveedor.Observaciones;
            nupComision.Value = Convert.ToDecimal(pProveedor.Comision);
            cbContado.Checked = pProveedor.FormaPago;
            cbInscriptoEnGanancias.Checked = pProveedor.InscriptoGanancias;
            cbTipoContribuyente.SelectedValue = pProveedor.TipoContribuyente.Codigo;
            cbRiesgoFiscal.Checked = pProveedor.RiesgoFiscal;
            int renglon = 0;
            //dgvComunicaciones.DataSource = pComunicaciones;
            renglon = dgvComunicaciones.Rows.Count;
            //dgvComunicaciones.Rows.Add(objEntidadComunicacion.Codigo, objEntidadComunicacion.Descripcion,renglon, txtComunicacion.Text.Trim());
            
            string dato;
            foreach (DataRow fila in pComunicaciones.Rows) {
                objEntidadComunicacion = objLogicaComunicacion.ObtenerUno(Convert.ToInt32(fila["CodigoComunicacion"]));
                renglon = dgvComunicaciones.Rows.Count;
                dato = fila["Dato"].ToString();
                dgvComunicaciones.Rows.Add(objEntidadComunicacion.Codigo, objEntidadComunicacion.Descripcion, renglon, dato);
            }
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores()
        {

            try
            {
                CargarCategorias();
                CargarPaises();
                CargarTipoInscripcion();
                CargarTipoContribuyente();
                CargarComunicaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarTipoContribuyente()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTipoContribuyente, objLogicaTContribuyente.ObtenerTodosDeProveedores(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComunicaciones() {
            try
            {
                Utilidades.Combo.Llenar(cbComunicaciones, objLogicaComunicacion.ObtenerActivos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTipoInscripcion()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTipoInscripcion, objLogicaTipoInscripcion.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCategorias() {
            try
            {
                Utilidades.Combo.Llenar(cbCategoria, objLogicaCategoriaProveedor.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPaises() {
            try
            {
                Utilidades.Combo.Llenar(cbPais, objLogicaPais.ObtenerActivos(), "Codigo", "Descripcion");
                if (cbPais.SelectedValue != null)
                {
                    objEntidadPais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));
                    Utilidades.Combo.Llenar(cbProvincias, objLogicaProvincia.ObtenerActivos(objEntidadPais), "Codigo", "Provincia");
                    if (cbProvincias.SelectedValue != null)
                    {
                        objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                        Utilidades.Combo.Llenar(cbLocalidades, objLogicaLocalidad.ObtenerActivos(objEntidadProvincia), "Codigo", "Localidad");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar() {
            lblCodigo.Text = "(Codigo)";
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            txtCUIT.DesHabilitar();
            txtCUIT.Limpiar();
            nupComision.Value = 0;
            cbContado.Checked = false;
            cbInscriptoEnGanancias.Checked = false;
            cbRiesgoFiscal.Checked = false;
            BotonesInicial();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            //txtCausa.Enabled = false;
            txtCUIT.Habilitar();
            //cbTipoContribuyente.Enabled = false;
            //cbRiesgoFiscal.Enabled = false;
            cbProvincias.SelectedValue = 1;
            cbLocalidades.SelectedValue = 1;
            cbCategoria.SelectedValue = 1;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAgregarComunicacion_Click(object sender, EventArgs e)
        {
            if (!txtComunicacion.Text.Trim().Equals(""))
            {
                objEntidadComunicacion.Codigo = Convert.ToInt32(cbComunicaciones.SelectedValue);
                objEntidadComunicacion.Descripcion = cbComunicaciones.Text;
                // dgvComunicaciones.Rows.Add(objEntidadComunicacion);
                int renglon;
                renglon = dgvComunicaciones.Rows.Count;
                dgvComunicaciones.Rows.Add(objEntidadComunicacion.Codigo, objEntidadComunicacion.Descripcion, renglon, txtComunicacion.Text.Trim());
                txtComunicacion.Text = "";
            }
            else
            {
                MessageBox.Show("El Campo Dato no puede estar en blanco!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarComunicacion_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dgvComunicaciones.CurrentRow;
            if (dgvr != null) { 
                dgvComunicaciones.Rows.Remove(dgvr);
            }
        }

        private bool Validar() {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtNombre);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoInscripcion);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtIngresosBrutos);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtDireccion);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtBarrio);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoPostal);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPais);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbProvincias);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbLocalidades);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCategoria);
            //res = res || Utilidades.Validar.CUITEnBlanco(txtCUIT);
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true)) {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

         /*   if (!Utilidades.Validar.ValidaCUIT(txtCUIT.Valor))
            {
                MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCUIT.txtCUIL1.Focus();
                return;
            }
         */
            dtComunicaciones.Clear();
            if (lblCodigo.Text.Equals(Variables.Codigo))
            {
                objEntidadProveedor.Codigo = 0;
            }
            else {
                objEntidadProveedor.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadProveedor.Nombre = txtNombre.Text.Trim();
            objEntidadProveedor.TipoInscripcion.Codigo = Convert.ToInt32(cbTipoInscripcion.SelectedValue);
            objEntidadProveedor.TipoContribuyente.Codigo = Convert.ToInt32(cbTipoContribuyente.SelectedValue);
            objEntidadProveedor.RiesgoFiscal = Convert.ToBoolean(cbRiesgoFiscal.Checked);
            objEntidadProveedor.CUIT = txtCUIT.Valor;
            objEntidadProveedor.IngresosBrutos = txtIngresosBrutos.Text.Trim();
            objEntidadProveedor.Domicilio.Direccion = txtDireccion.Text.Trim();
            objEntidadProveedor.Domicilio.Numero = txtNumero.Text.Trim();
            objEntidadProveedor.Domicilio.Barrio = txtBarrio.Text.Trim();
            objEntidadProveedor.Domicilio.CodigoPostal = txtCodigoPostal.Text.Trim();
            objEntidadProveedor.Domicilio.Localidad.Codigo = Convert.ToInt32(cbLocalidades.SelectedValue);
            objEntidadProveedor.CategoriaProveedor.Codigo= Convert.ToInt32(cbCategoria.SelectedValue);
            objEntidadProveedor.Observaciones = txtObservaciones.Text.Trim();
            objEntidadProveedor.Comision = Convert.ToDouble(nupComision.Value);
            objEntidadProveedor.FormaPago = cbContado.Checked;
            objEntidadProveedor.InscriptoGanancias = cbInscriptoEnGanancias.Checked;

            foreach (DataGridViewRow item in dgvComunicaciones.Rows)
            {
                 DataRow filaComunicacion = dtComunicaciones.NewRow();
                 filaComunicacion[0] = Convert.ToInt32(item.Cells["CodigoComunicacion"].Value);
                 filaComunicacion[1] = item.Cells["Descripcion"].Value;
                 dtComunicaciones.Rows.Add(filaComunicacion);
            }

            try
            {
                if (objEntidadProveedor.Codigo == 0)
                {
                    objLogicaProveedor.Agregar(objEntidadProveedor, dtComunicaciones,Singleton.Instancia.Empresa);
                    Limpiar();
                    MessageBox.Show("Proveedor agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        objLogicaProveedor.Agregar(objEntidadProveedor, dtComunicaciones, Singleton.Instancia.Empresa);
                        Limpiar();
                        MessageBox.Show("Proveedor modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmPais());
            busqueda = "Paises";
        }

       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("Alta",this));
            this.Close();
        }


        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPais.SelectedIndex != -1)
            {
                try
                {
                    objEntidadPais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));
                    Utilidades.Combo.Llenar(cbProvincias, objLogicaProvincia.ObtenerActivos(objEntidadPais), "Codigo", "Provincia");
                    objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                    if (objEntidadProvincia == null)
                        cbLocalidades.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex != -1)
            {
                try
                {
                    objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                    Utilidades.Combo.Llenar(cbLocalidades, objLogicaLocalidad.ObtenerActivos(objEntidadProvincia), "Codigo", "Localidad");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadProveedor.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Proveedor seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaProveedor.Eliminar(objEntidadProveedor);
                    Limpiar();
                    MessageBox.Show("Proveedor eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmComunicacion());
            busqueda = "Comunicaciones";
        }

        private void agregarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmProvincia());
            busqueda = "Paises";
        }

        private void agregarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmLocalidad());
            busqueda = "Paises";
        }


        private void frmEmpleado_Activated(object sender, EventArgs e)
        {
            if (busqueda.Equals("Paises"))
                CargarPaises();
            else if (busqueda.Equals("Comunicaciones"))
                CargarComunicaciones();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar = char.ToUpper(e.KeyChar);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtIngresosBrutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtBarrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbProvincias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbLocalidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbComunicaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtComunicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregarComunicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void nupComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

        }

        private void cbTipoInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTipoInscripcion.SelectedValue) != 1)
            {
                lblTipoContribuyente.Enabled = false;
                cbTipoContribuyente.SelectedValue = 6;
                cbTipoContribuyente.Enabled = false;
                cbRiesgoFiscal.Checked = false;
                cbRiesgoFiscal.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cbLocalidades.SelectedValue) == 1)
                {
                    lblTipoContribuyente.Enabled = true;
                    cbRiesgoFiscal.Enabled = true;
                    cbTipoContribuyente.Enabled = true;
                    cbTipoContribuyente.SelectedValue = 1;
                }
                else
                {
                    lblTipoContribuyente.Enabled = false;
                    cbTipoContribuyente.SelectedValue = 6;
                    cbTipoContribuyente.Enabled = false;
                    cbRiesgoFiscal.Checked = false;
                    cbRiesgoFiscal.Enabled = false;
                }


            }
        }

        private void cbLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTipoInscripcion.SelectedValue) != 1)
            {
                lblTipoContribuyente.Enabled = false;
                cbTipoContribuyente.SelectedValue = 6;
                cbTipoContribuyente.Enabled = false;
                cbRiesgoFiscal.Checked = false;
                cbRiesgoFiscal.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cbLocalidades.SelectedValue) == 1)
                {
                    lblTipoContribuyente.Enabled = true;
                    cbRiesgoFiscal.Enabled = true;
                    cbTipoContribuyente.Enabled = true;
                    cbTipoContribuyente.SelectedValue = 1;
                }
                else
                {
                    lblTipoContribuyente.Enabled = false;
                    cbTipoContribuyente.SelectedValue = 6;
                    cbTipoContribuyente.Enabled = false;
                    cbRiesgoFiscal.Checked = false;
                    cbRiesgoFiscal.Enabled = false;
                }


            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}