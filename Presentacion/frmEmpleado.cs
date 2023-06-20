using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmEmpleado : frmColor
    {
        Logica.Puesto objLogicaPuesto = new Logica.Puesto();
        Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();
        Logica.Localidad objLogicaLocalidad = new Logica.Localidad();
        Logica.ObraSocial objLogicaObraSocial = new Logica.ObraSocial();
        Logica.Comunicacion objLogicaComunicacion = new Logica.Comunicacion();
        Logica.Empleado objLogicaEmpleado = new Logica.Empleado();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.Sucursal objLSuc = new Logica.Sucursal();

        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();
        Entidades.Comunicacion objEntidadComunicacion = new Entidades.Comunicacion();
        Entidades.Empleado objEntidadEmpleado = new Entidades.Empleado();
        Entidades.Sucursal objESuc = new Entidades.Sucursal();

        DataTable dtComunicaciones = new DataTable("dtComunicaciones");

        string busqueda = "";

        public frmEmpleado()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmEmpleado(Entidades.Empleado pEmpleado, DataTable pComunicaciones)
        {
            InitializeComponent();
            ConfiguracionInicial2(pEmpleado, pComunicaciones);

        }

        private void ConfiguracionInicial()
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            CargarValores();

        }

        private void ConfiguracionInicial2(Entidades.Empleado pEmpleado, DataTable pComunicaciones)
        {
            //dgvDatos.AutoGenerateColumns = false;

            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            Utilidades.ControlesGenerales.Habilitar(this);
            CargarValores();
            CargarValoresEmpleadoSeleccionado(pEmpleado, pComunicaciones);


        }
        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE EMPLEADOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtLegajo, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtApellido, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombres, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCausa, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDireccion,30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBarrio, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoPostal,10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDocumento,8);
            Utilidades.CajaDeTexto.LimiteTamaño(txtComunicacion,40);
        }

        private void Formatos() {
            Utilidades.Grilla.Formato(dgvComunicaciones);
            Utilidades.Combo.Formato(cbPuestos);
            Utilidades.Combo.Formato(cbPais);
            Utilidades.Combo.Formato(cbProvincias);
            Utilidades.Combo.Formato(cbLocalidades);
            Utilidades.Combo.Formato(cbSexo);
            Utilidades.Combo.Formato(cbEstadosCiviles);
            Utilidades.Combo.Formato(cbTipoDocumento);
            Utilidades.Combo.Formato(cbSucursales);
            Utilidades.Combo.Formato(cbObraSocial);
            Utilidades.Combo.Formato(cbComunicaciones);
            Utilidades.Combo.Formato(cbBancos);

            dgvComunicaciones.Columns["Tipo"].Width = 90;

            DataColumn CodigoComunicacion = dtComunicaciones.Columns.Add("CodigoComunicacion", typeof(int));
            DataColumn Descripcion = dtComunicaciones.Columns.Add("Descripcion", typeof(string));
        }

        private void CargarValoresEmpleadoSeleccionado(Entidades.Empleado pEmpleado, DataTable pComunicaciones) {
            lblCodigo.Text = pEmpleado.Codigo.ToString();
            txtLegajo.Text = pEmpleado.Legajo;
            txtApellido.Text = pEmpleado.Apellido;
            txtNombres.Text = pEmpleado.Nombres;
            txtCUIL.txtCUIL1.Text = pEmpleado.CUIL.Substring(0, 2);
            //txtCUIL.txtCUIL2.Text = pEmpleado.CUIL.Substring(3, 8);
            txtCUIL.txtCUIL3.Text = pEmpleado.CUIL.Substring(12, 1);
            cbPuestos.SelectedValue = pEmpleado.Puesto.Codigo;
            dtpIngreso.Value = pEmpleado.FechaIngreso;
            txtDireccion.Text = pEmpleado.Domicilio.Direccion;
            txtBarrio.Text = pEmpleado.Domicilio.Barrio;
            txtCodigoPostal.Text = pEmpleado.Domicilio.CodigoPostal;
            cbPais.SelectedValue = pEmpleado.Domicilio.Localidad.Provincia.Pais.Codigo;
            cbProvincias.SelectedValue = pEmpleado.Domicilio.Localidad.Provincia.Codigo;
            cbLocalidades.SelectedValue= pEmpleado.Domicilio.Localidad.Codigo;
            cbSexo.SelectedItem = pEmpleado.Sexo;
            cbEstadosCiviles.SelectedItem = pEmpleado.EstadoCivil;
            cbBancos.SelectedValue = pEmpleado.Banco.Codigo;
            nupHijos.Value = pEmpleado.CantidadHijos;
            dtpFechaNacimiento.Value = pEmpleado.FechaNacimiento;
            cbTipoDocumento.SelectedItem = pEmpleado.TipoDeDocumento;
            txtDocumento.Text = pEmpleado.NumeroDocumento;
            cbObraSocial.SelectedValue = pEmpleado.ObraSocial.Codigo;
            cbFueraDeConvenio.Checked = pEmpleado.FueraDeConvenio;
            cbSucursales.SelectedValue = pEmpleado.Sucursal.Codigo;
            //nudSueldo.Value = Convert.ToDecimal(pEmpleado.Sueldo);
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
            if (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores()
        {

            try
            {
                CargarPuestos();
                CargarPaises();
                CargarBancos();
                CargarSucursales();
                List<Enumeraciones.Enumeraciones.Sexos> listaSexo = Enum.GetValues(typeof(Enumeraciones.Enumeraciones.Sexos)).Cast<Enumeraciones.Enumeraciones.Sexos>().ToList();
                listaSexo.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
                cbSexo.DataSource = listaSexo;

                List<Enumeraciones.Enumeraciones.EstadosCiviles> listaEstadosCiviles = Enum.GetValues(typeof(Enumeraciones.Enumeraciones.EstadosCiviles)).Cast<Enumeraciones.Enumeraciones.EstadosCiviles>().ToList();
                listaEstadosCiviles.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
                cbEstadosCiviles.DataSource = listaEstadosCiviles;

                List<Enumeraciones.Enumeraciones.TiposDeDocumentos> listaTiposDeDocumentos = Enum.GetValues(typeof(Enumeraciones.Enumeraciones.TiposDeDocumentos)).Cast<Enumeraciones.Enumeraciones.TiposDeDocumentos>().ToList();
                listaTiposDeDocumentos.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
                cbTipoDocumento.DataSource = listaTiposDeDocumentos;

                CargarObraSocial();
                CargarComunicaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSucursales() {
            Utilidades.Combo.Llenar(cbSucursales, objLSuc.ObtenerLocalidades(), "Codigo", "Descripcion");
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

        private void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarObraSocial()
        {
            try
            {
                Utilidades.Combo.Llenar(cbObraSocial, objLogicaObraSocial.ObtenerActivos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPuestos() {
            try
            {
                Utilidades.Combo.Llenar(cbPuestos, objLogicaPuesto.ObtenerActivos(), "Codigo", "Descripcion");
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
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Limpiar() {
            lblCodigo.Text = "(Codigo)";
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            cbFueraDeConvenio.Checked = true;
            BotonesInicial();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtCausa.Enabled = false;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            txtLegajo.Focus();
        }

        private void dtpEgreso_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEgreso.Checked == true)
            {
                txtCausa.Enabled = true;
            }
            else {
                txtCausa.Enabled = false;
                txtCausa.Text = "";
            }
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
            res = Utilidades.Validar.TextBoxEnBlanco(txtLegajo);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtApellido);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNombres);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPuestos);
            if (dtpEgreso.Checked) {
                res = res || Utilidades.Validar.TextBoxEnBlanco(txtCausa);
            }
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDireccion);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtBarrio);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoPostal);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPais);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbProvincias);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbLocalidades);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbSexo);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbEstadosCiviles);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoDocumento);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDocumento);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbObraSocial);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbBancos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbSucursales);
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true)) {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLegajo.Focus();
                return;
            }
            dtComunicaciones.Clear();
            if (lblCodigo.Text.Equals(Variables.Codigo))
            {
                objEntidadEmpleado.Codigo = 0;
            }
            else {
                objEntidadEmpleado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadEmpleado.Legajo = txtLegajo.Text.Trim();
            objEntidadEmpleado.Apellido = txtApellido.Text.Trim();
            objEntidadEmpleado.Nombres = txtNombres.Text.Trim();
            objEntidadEmpleado.CUIL = txtCUIL.Valor;
            objEntidadEmpleado.Puesto.Codigo =Convert.ToInt32(cbPuestos.SelectedValue);
            objEntidadEmpleado.FechaIngreso = dtpIngreso.Value;
            objEntidadEmpleado.Egreso.FechaEgreso = dtpEgreso.Value;
            objEntidadEmpleado.Egreso.Causa = txtCausa.Text.Trim();
            objEntidadEmpleado.Domicilio.Direccion = txtDireccion.Text.Trim();
            objEntidadEmpleado.Domicilio.Barrio = txtBarrio.Text.Trim();
            objEntidadEmpleado.Domicilio.CodigoPostal = txtCodigoPostal.Text.Trim();
            objEntidadEmpleado.Domicilio.Localidad.Codigo= Convert.ToInt32(cbLocalidades.SelectedValue);
            objEntidadEmpleado.Banco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);

            Enumeraciones.Enumeraciones.Sexos objSexo = new Enumeraciones.Enumeraciones.Sexos();
            Enum.TryParse(cbSexo.SelectedItem.ToString(), out objSexo);
            objEntidadEmpleado.Sexo = objSexo;

            Enumeraciones.Enumeraciones.EstadosCiviles objEstadoCivil = new Enumeraciones.Enumeraciones.EstadosCiviles();
            Enum.TryParse(cbEstadosCiviles.SelectedItem.ToString(), out objEstadoCivil);
            objEntidadEmpleado.EstadoCivil = objEstadoCivil;

            objEntidadEmpleado.CantidadHijos = Convert.ToInt32(nupHijos.Value);
            objEntidadEmpleado.FechaNacimiento = dtpFechaNacimiento.Value;

            Enumeraciones.Enumeraciones.TiposDeDocumentos objTiposDeDocumentos = new Enumeraciones.Enumeraciones.TiposDeDocumentos();
            Enum.TryParse(cbTipoDocumento.SelectedItem.ToString(), out objTiposDeDocumentos);
            objEntidadEmpleado.TipoDeDocumento = objTiposDeDocumentos;

            objEntidadEmpleado.NumeroDocumento = txtDocumento.Text.Trim();
            objEntidadEmpleado.EsEmpleado = true;
            objEntidadEmpleado.FueraDeConvenio = cbFueraDeConvenio.Checked;
            objEntidadEmpleado.ObraSocial.Codigo = Convert.ToInt32(cbObraSocial.SelectedValue);
            objEntidadEmpleado.Sucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);


            //objEntidadEmpleado.Sueldo = Convert.ToDouble(nudSueldo.Value);

            foreach (DataGridViewRow item in dgvComunicaciones.Rows)
            {
                 DataRow filaComunicacion = dtComunicaciones.NewRow();
                 filaComunicacion[0] = Convert.ToInt32(item.Cells["CodigoComunicacion"].Value);
                 filaComunicacion[1] = item.Cells["Descripcion"].Value;
                 dtComunicaciones.Rows.Add(filaComunicacion);
            }
            bool egreso = dtpEgreso.Checked;



            try
            {
                if (objEntidadEmpleado.Codigo == 0)
                {
                    objLogicaEmpleado.Agregar(objEntidadEmpleado, dtComunicaciones, egreso);
                    Limpiar();
                    MessageBox.Show("Empleado agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        objLogicaEmpleado.Agregar(objEntidadEmpleado, dtComunicaciones, egreso);
                        Limpiar();
                        MessageBox.Show("Empleado modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            txtCUIL.Cargar(txtDocumento.Text.Trim());
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmPais());
            busqueda = "Paises";
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmPuestos());
            busqueda = "Puestos";
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Entidades.Empleado objEmpleado = null;
           // frmEmpleadoBuscar frmEBuscar = new frmEmpleadoBuscar();
            Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("Alta",this));
            this.Close();
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
            objEntidadEmpleado.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Empleado seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaEmpleado.Eliminar(objEntidadEmpleado);
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

        private void agregarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmObraSocial());
            busqueda = "ObraSocial";
        }

        private void frmEmpleado_Activated(object sender, EventArgs e)
        {
            if (busqueda.Equals("Paises"))
                CargarPaises();
            else if (busqueda.Equals("Puestos"))
                CargarPuestos();
            else if (busqueda.Equals("Comunicaciones"))
                CargarComunicaciones();
            else if (busqueda.Equals("ObraSocial"))
                CargarObraSocial();
        }

        private void cmsComunicacion_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void txtCUIL_Load(object sender, EventArgs e)
        {

        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCUIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbPuestos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCausa_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbEstadosCiviles_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void nupHijos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbObraSocial_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}