using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCliente : frmColor
    {
        Logica.TipoInscripcion objLogicaTipoInscripcion = new Logica.TipoInscripcion();
        Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();
        Logica.Localidad objLogicaLocalidad = new Logica.Localidad();
        Logica.Comunicacion objLogicaComunicacion = new Logica.Comunicacion();
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.TipoContribuyente objLogicaTContribuyente = new Logica.TipoContribuyente();


        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();
        Entidades.Comunicacion objEntidadComunicacion = new Entidades.Comunicacion();
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();

        DataTable dtComunicaciones = new DataTable("dtComunicaciones");
        DataTable dtDescuentos = new DataTable("dtDescuentos");

        string busqueda = "";

        public frmCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }

        public frmCliente(Entidades.Cliente pCliente, DataTable pComunicaciones, DataTable pDescuentos)
        {
            InitializeComponent();
            ConfiguracionInicial2(pCliente, pComunicaciones, pDescuentos);

        }

        private void ConfiguracionInicial()
        {
            //dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            
            //            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            //           Utilidades.Combo.SeleccionarPrimerValor(cbPais);

        }

        private void ConfiguracionInicial2(Entidades.Cliente pCliente, DataTable pComunicaciones, DataTable pDescuentos)
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            Utilidades.ControlesGenerales.Habilitar(this);
            CargarValores();
            CargarValoresClienteSeleccionado(pCliente, pComunicaciones, pDescuentos);
            //            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            //           Utilidades.Combo.SeleccionarPrimerValor(cbPais);

        }
        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombre, 60);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDireccion,50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBarrio, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoPostal,10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtComunicacion,40);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcionDescuentos, 50);
            //     Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 200);
        }

        private void Formatos() {
            Utilidades.Grilla.Formato(dgvComunicaciones);
            Utilidades.Grilla.Formato(dgvDescuentos);
            Utilidades.Combo.Formato(cbTipoInscripcion);
            Utilidades.Combo.Formato(cbPais);
            Utilidades.Combo.Formato(cbTipoDocumento);
            Utilidades.Combo.Formato(cbProvincias);
            Utilidades.Combo.Formato(cbLocalidades);
            Utilidades.Combo.Formato(cbComunicaciones);
            Utilidades.Combo.Formato(cbTipoContribuyente);
            dgvComunicaciones.Columns["Tipo"].Width = 90;
            dgvDescuentos.Columns["DescripcionDescuento"].Width = 150;

            DataColumn CodigoComunicacion = dtComunicaciones.Columns.Add("CodigoComunicacion", typeof(int));
            DataColumn Descripcion = dtComunicaciones.Columns.Add("Descripcion", typeof(string));

            DataColumn descripcionDescuentos = dtDescuentos.Columns.Add("Descripcion", typeof(string));
            DataColumn porcentaje = dtDescuentos.Columns.Add("Porcentaje", typeof(double));

        }
        
        private void CargarValoresClienteSeleccionado(Entidades.Cliente pCliente, DataTable pComunicaciones, DataTable pDescuentos) {
            lblCodigo.Text = pCliente.Codigo.ToString();
            txtNombre.Text = pCliente.Nombre;
            cbTipoInscripcion.SelectedValue = pCliente.TipoInscripcion.Codigo;
            txtCUIT.txtCUIL1.Text = pCliente.CUIT.Substring(0, 2);
            txtCUIT.txtCUIL2.Text = pCliente.CUIT.Substring(3, 8);
            txtCUIT.txtCUIL3.Text = pCliente.CUIT.Substring(12, 1);
            btnSucursales.Enabled = true;
            if (pCliente.FechaValidacionCUIT.CompareTo(Variables.FechaNula) == 0)
            {
                dtpValidado.Checked = false;
            }
            else {
                dtpValidado.Checked = true;
            }
            dtpValidado.Value = pCliente.FechaValidacionCUIT;
            txtDireccion.Text = pCliente.Domicilio.Direccion;
            txtNumero.Text = pCliente.Domicilio.Numero;
            txtBarrio.Text = pCliente.Domicilio.Barrio;
            txtCodigoPostal.Text = pCliente.Domicilio.CodigoPostal;
            cbPais.SelectedValue = pCliente.Domicilio.Localidad.Provincia.Pais.Codigo;
            cbProvincias.SelectedValue = pCliente.Domicilio.Localidad.Provincia.Codigo;
            cbLocalidades.SelectedValue = pCliente.Domicilio.Localidad.Codigo;
            cbTipoContribuyente.SelectedValue = pCliente.TipoContribuyente.Codigo;
            cbRiesgoFiscal.Checked = pCliente.RiesgoFiscal;
            cbCtaCte.Checked = pCliente.CtaCte;
            //Utilidades.Combo.Llenar(cbTipoDocumento, new Logica.TipoDocumento().Obtener(pCliente.TipoInscripcion.Codigo),"Codigo","Descripcion");
            cbTipoDocumento.SelectedValue = pCliente.TipoDocumento.Codigo;
            int renglon = 0;

            renglon = dgvComunicaciones.Rows.Count;
           
            string dato;
            foreach (DataRow fila in pComunicaciones.Rows) {
                objEntidadComunicacion = objLogicaComunicacion.ObtenerUno(Convert.ToInt32(fila["CodigoComunicacion"]));
                renglon = dgvComunicaciones.Rows.Count;
                dato = fila["Dato"].ToString();
                dgvComunicaciones.Rows.Add(objEntidadComunicacion.Codigo, objEntidadComunicacion.Descripcion, renglon, dato);
            }

            foreach (DataRow fila in pDescuentos.Rows)
            {
                
                renglon = dgvComunicaciones.Rows.Count;
                dgvDescuentos.Rows.Add(renglon, fila["Descripcion"].ToString(), Convert.ToDouble(fila["Porcentaje"]));
            }

            cbFacturaKilos.Checked = Convert.ToBoolean(pCliente.FacturaKilos);
            //txtObservaciones.Text = pCliente.Observaciones;
            nupComision.Value = Convert.ToDecimal(pCliente.Comision);
            cbOriginal.Checked = Convert.ToBoolean(pCliente.Original);
            cbDuplicado.Checked = Convert.ToBoolean(pCliente.Duplicado);
            cbTriplicado.Checked = Convert.ToBoolean(pCliente.Triplicado);
            cbFacturacionPorCubeta.Checked=Convert.ToBoolean(pCliente.FacturacionPorCubeta);
            cbMiPYME.Checked = Convert.ToBoolean(pCliente.MiPYME);
            //cbDescuentosEnFactura.Checked = Convert.ToBoolean(pCliente.DescuentoEnFactura);
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores()
        {

            try
            {
                CargarTipoInscripcion();
                CargarPaises();
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
                Utilidades.Combo.Llenar(cbTipoContribuyente, objLogicaTContribuyente.ObtenerTodosDeClientes(), "Codigo", "Descripcion");
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
            nupComision.Value = 0;
            txtCUIT.Limpiar();
            BotonesInicial();
            cbFacturaKilos.Checked = false;
            cbOriginal.Checked = true;
            cbDuplicado.Checked = false;
            cbTriplicado.Checked = true;
            cbFacturacionPorCubeta.Checked = false;
            cbMiPYME.Checked = false;
            cbRiesgoFiscal.Checked = false;
            cbCtaCte.Checked = false;
           // cbDescuentosEnFactura.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtCUIT.Habilitar();
            cbTipoDocumento.SelectedValue = 99;

            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            //cbTipoContribuyente.SelectedValue = 6;
            cbTipoContribuyente.Enabled = false;
            cbRiesgoFiscal.Enabled = false;
            cbOriginal.Checked = true;
            cbDuplicado.Checked = false;
            cbTriplicado.Checked = false;
            cbFacturacionPorCubeta.Checked = false;
            // cbDescuentosEnFactura.Checked = false;
            cbProvincias.SelectedValue = 1;
            cbLocalidades.SelectedValue = 1;
            cbMiPYME.Checked = false;
            btnSucursales.Enabled = false;
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
            else {
                MessageBox.Show("El Campo Dato no puede estar en blanco!",Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            //res = res || Utilidades.Validar.CUITEnBlanco(txtCUIT);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtDireccion);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtBarrio);
            //res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoPostal);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPais);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbProvincias);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbLocalidades);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoInscripcion);
            
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true)) {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            /*if (Convert.ToInt32(cbTipoDocumento.SelectedValue) != 99 && !Utilidades.Validar.ValidaCUIT(txtCUIT.Valor)   )
            {
                MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCUIT.txtCUIL1.Focus();
                return;
            }*/

            dtComunicaciones.Clear();
            dtDescuentos.Clear();
            if (lblCodigo.Text.Equals(Variables.Codigo))
            {
                objEntidadCliente.Codigo = 0;
            }
            else {
                objEntidadCliente.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadCliente.Nombre = txtNombre.Text.Trim();
            objEntidadCliente.TipoInscripcion.Codigo = Convert.ToInt32(cbTipoInscripcion.SelectedValue);
            objEntidadCliente.TipoContribuyente.Codigo = Convert.ToInt32(cbTipoContribuyente.SelectedValue);
            objEntidadCliente.RiesgoFiscal = Convert.ToBoolean(cbRiesgoFiscal.Checked);
            objEntidadCliente.TipoDocumento.Codigo= Convert.ToInt32(cbTipoDocumento.SelectedValue);
            objEntidadCliente.CUIT = txtCUIT.Valor;
            if (dtpValidado.Checked)
                objEntidadCliente.FechaValidacionCUIT = dtpValidado.Value;
            else
                objEntidadCliente.FechaValidacionCUIT = Variables.FechaNula;


            objEntidadCliente.Domicilio.Direccion = txtDireccion.Text.Trim();
            objEntidadCliente.Domicilio.Numero = txtNumero.Text.Trim();
            objEntidadCliente.Domicilio.Barrio = txtBarrio.Text.Trim();
            objEntidadCliente.Domicilio.CodigoPostal = txtCodigoPostal.Text.Trim();
            objEntidadCliente.Domicilio.Localidad.Codigo = Convert.ToInt32(cbLocalidades.SelectedValue);
            objEntidadCliente.FacturaKilos = cbFacturaKilos.Checked;

            objEntidadCliente.Observaciones = "";// txtObservaciones.Text.Trim();
            objEntidadCliente.Comision = Convert.ToDouble(nupComision.Value);

            objEntidadCliente.Original = Convert.ToBoolean(cbOriginal.Checked);
            objEntidadCliente.Duplicado = Convert.ToBoolean(cbDuplicado.Checked);
            objEntidadCliente.Triplicado = Convert.ToBoolean(cbTriplicado.Checked);

            objEntidadCliente.FacturacionPorCubeta=Convert.ToBoolean(cbFacturacionPorCubeta.Checked);
            objEntidadCliente.MiPYME = cbMiPYME.Checked;
            objEntidadCliente.CtaCte = cbCtaCte.Checked;
            //objEntidadCliente.DescuentoEnFactura = cbDescuentosEnFactura.Checked;

            foreach (DataGridViewRow item in dgvComunicaciones.Rows)
            {
                 DataRow filaComunicacion = dtComunicaciones.NewRow();
                 filaComunicacion[0] = Convert.ToInt32(item.Cells["CodigoComunicacion"].Value);
                 filaComunicacion[1] = item.Cells["Descripcion"].Value;
                 dtComunicaciones.Rows.Add(filaComunicacion);
            }

            foreach (DataGridViewRow item in dgvDescuentos.Rows)
            {
                DataRow filaDescuentos = dtDescuentos.NewRow();
                filaDescuentos[0] = item.Cells["DescripcionDescuento"].Value;
                filaDescuentos[1] = Convert.ToDouble(item.Cells["Porcentaje"].Value);
                dtDescuentos.Rows.Add(filaDescuentos);
            }

            bool egreso = dtpValidado.Checked;

            try
            {
                if (objEntidadCliente.Codigo == 0)
                {
                    objLogicaCliente.Agregar(objEntidadCliente, dtComunicaciones, dtDescuentos);
                    Limpiar();
                    MessageBox.Show("Cliente agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        objLogicaCliente.Agregar(objEntidadCliente, dtComunicaciones, dtDescuentos);
                        Limpiar();
                        MessageBox.Show("Cliente modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("Alta", this));
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
            objEntidadCliente.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Cliente seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaCliente.Eliminar(objEntidadCliente);
                    Limpiar();
                    MessageBox.Show("Empleado eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbTipoInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpValidado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbComunicaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void nupComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregarDescuento_Click(object sender, EventArgs e)
        {
            if (!txtDescripcionDescuentos.Text.Trim().Equals("") )
            {
                if (nupPorcentaje.Value > 0)
                {

                    
                    // dgvComunicaciones.Rows.Add(objEntidadComunicacion);
                    int renglon;
                    renglon = dgvDescuentos.Rows.Count;
                    if (renglon == 3) {
                        MessageBox.Show("Cantidad Maxima de Descuentos por Factura Alcanzado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dgvDescuentos.Rows.Add(renglon,txtDescripcionDescuentos.Text.Trim(), Convert.ToDouble(nupPorcentaje.Value));
                    txtDescripcionDescuentos.Text = "";
                    nupPorcentaje.Value = 0;
                }
                else { 
                    MessageBox.Show("El Porcentaje debe ser mayor a 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("El Campo Descripción no puede estar en blanco!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarDescuento_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dgvDescuentos.CurrentRow;
            if (dgvr != null)
            {
                dgvDescuentos.Rows.Remove(dgvr);
            }
        }

        private void cbTipoInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                Utilidades.Combo.Llenar(cbTipoDocumento, new Logica.TipoDocumento().Obtener(Convert.ToInt32(cbTipoInscripcion.SelectedValue)),"Codigo","Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        frmSucursalesClientes frmSuc;
        private void btnSucursales_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cliente objEC = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(lblCodigo.Text));
                frmSuc = new frmSucursalesClientes(objEC);
                Utilidades.Formularios.Abrir(this.MdiParent, frmSuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}