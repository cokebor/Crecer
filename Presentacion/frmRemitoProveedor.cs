using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRemitoProveedor : Presentacion.frmColor
    {
        public static string busqueda = "";

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Canal objLogicaCanal = new Logica.Canal();
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Logica.RemitoProveedor objLogicaRemito = new Logica.RemitoProveedor();
        Logica.Lote objLogicaLote = new Logica.Lote();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Lote objLLote = new Logica.Lote();
        Logica.Transporte objLTransporte = new Logica.Transporte();

        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();
        Entidades.RemitoProveedor_M objEntidadRemito = new Entidades.RemitoProveedor_M();
        Entidades.RemitoProveedor_D_Producto objEntidadRemitoProductos = null;
        Entidades.Lote objEntidadesLote = new Entidades.Lote();

        private int cantItems;
        public frmRemitoProveedor()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public frmRemitoProveedor(Entidades.RemitoProveedor_M pRemito)
        {
            InitializeComponent();
            ConfiguracionInicial2(pRemito);
        }

        private void ConfiguracionInicial2(Entidades.RemitoProveedor_M pRemito)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            txtNumeroComprobante1.txtLetra.Text = "R";
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
            CargarValoresRemitoSeleccionado(pRemito);
            cantItems = 12;
            if (Singleton.Instancia.Empresa.Codigo == 10)
            {
                cantItems = 20;
            }
        }

        private void CargarValoresRemitoSeleccionado(Entidades.RemitoProveedor_M pRemito)
        {
            CodigoRemito = pRemito.Codigo;
            dtpFecha.Value = pRemito.Fecha;
            dtpFechaEmbarque.Value = pRemito.FechaEmbarque;
            txtCodigoProveedor.Text = pRemito.Proveedor.Codigo.ToString();
            cbRemito.Checked = !pRemito.Provisorio;
            if (!cbRemito.Checked)
                txtNumeroComprobante1.DesHabilitar();
            
            txtNumeroComprobante1.cargarValor(pRemito.NumRemito);
            /*txtNumeroDTV.cargarValor(pRemito.DTVE);
            if (!txtNumeroDTV.Valor.Equals("")) {
                cbDTVe.Checked = true;
            }*/
            cbCanal.SelectedValue = pRemito.Canal.Codigo;
            
            cbTransportes.SelectedValue = pRemito.Transporte.Codigo;
            nudPallets.Value = pRemito.Pallets;
            dgvDatos.Rows.Clear();
            foreach (Entidades.RemitoProveedor_D_Producto r in pRemito.Productos) {
                //dgvDatos.Rows.Add(r.MovStock_Lotes.IdLote.DTVe.Equals("")?false:true,r.Renglon, r.Producto.Codigo, r.Producto.Descripcion,r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.Codigo);
                dgvDatos.Rows.Add(r.Renglon, r.Producto.Codigo, r.Producto.Descripcion, r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.Codigo/*,r.MovStock_Lotes.IdLote.DTVe*/);
            }

        }

        private void ConfiguracionInicial()
        {
            Titulo();
            txtNumeroComprobante1.txtLetra.Text = "R";
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
            cantItems = 12;
            if (Singleton.Instancia.Empresa.Codigo == 10)
            {
                cantItems = 20;
            }
        }

        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE REMITOS DE PROVEEDORES";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (objEntidadProveedor != null)
                Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoProveedorBuscar("Remito", this, objEntidadProveedor.Codigo));

            else
                Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoProveedorBuscar("Remito", this, 0));
            this.Close();
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 5);
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals("")) { 
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if(objEntidadProveedor!=null)
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                    else
                        lblNombreProveedor.Text = "";
                }
                else { 
                    objEntidadProveedor = null;
                    lblNombreProveedor.Text = "";
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCanal);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbTransportes);
            dgvDatos.Columns["Codigo"].Width = 40;
            dgvDatos.Columns["Descripción"].Width = 100;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos.Columns["Cantidad"].Width = 80;

        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            //btnAgregar.Enabled = true;
        }

        private void CargarValores()
        {

            try
            {
                CargarCanales();
                CargarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCanales()
        {
            try
            {
                Utilidades.Combo.Llenar(cbCanal, objLogicaCanal.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarTransportes()
        {
            try
            {
                /*DataTable dt = objNTransporte.ObtenerActivos();
                DataRow dr = dt.NewRow();
                dr["Descripcion"] = "<< Seleccione Transporte>>";
                dr["Codigo"] = 0;
                dt.Rows.InsertAt(dr, 0);
                */

                Utilidades.Combo.Llenar(cbTransportes, objLTransporte.ObtenerActivos(), "Codigo", "Descripcion");
                cbTransportes.SelectedValue = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtProducto.Text.Trim().Equals(""))
                {
                    objEntidadProducto = objLogicaProducto.ObtenerUnoActivo(Convert.ToInt32(txtProducto.Text.Trim()));
                    if (objEntidadProducto != null)
                        lblProducto.Text = objEntidadProducto.Descripcion;
                    else
                        lblProducto.Text = "";
                }
                else
                {
                    objEntidadProducto = null;
                    lblProducto.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e) {
            switch (e.KeyValue){
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("RemitoProveedor", this));
                    break;
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("RemitoProveedor", this));
                    break;
            }

        }

        private void dtpIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtNumeroComprobante1_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbCanal_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnConfirmar_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbCanal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAGrilla();
            txtProducto.Enabled = true;
        }
        private void AgregarAGrilla() {
/*
            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                if (fila.Cells["Codigo"].Value.ToString() ==txtProducto.Text.Trim()) {
                    MessageBox.Show("Producto ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }*/
            
            if (dgvDatos.Rows.Count < cantItems)
            {
                if (!lblProducto.Text.Equals(""))
                {
                    if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        //Aca validar la modificacion
                        objEntidadesLote = objLogicaLote.ObtenerUno(Convert.ToInt32(lblLote.Text));
                        int cantidad = Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(lblCantidadVieja.Text);

                        if (objEntidadesLote==null || objEntidadesLote.Stock + cantidad >= 0)
                        {
                                dgvDatos.Rows.Add(lblRenglon.Text, txtProducto.Text.Trim(), lblProducto.Text, lblLote.Text, txtCantidad.Text, lblCantidadVieja.Text, lblMovStock.Text);
                            txtProducto.Text = "";
                            txtCantidad.Text = "";
                            lblRenglon.Text = "0";
                            lblLote.Text = "0";
                            lblMovStock.Text = "0";
                            lblCantidadVieja.Text = "0";
                            txtProducto.Focus();
                        }
                        else {
                            MessageBox.Show("No cuenta con Stock suficiente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCantidad.Focus();
                    }
                }
                else {
                    MessageBox.Show("Debe seleccionar un producto valido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProducto.Focus();
                }
                    
            }
            else {
                MessageBox.Show("Se alcanzo cantidad maxima de Productos por Remito.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["Lote"].Value) != 0)
                {
                    objEntidadesLote = objLogicaLote.ObtenerUno(Convert.ToInt32(dgvDatos.CurrentRow.Cells["Lote"].Value));
                    if (objLMovStock.CantidadDeMovimientosPorLote(objEntidadesLote) > 1)
                        MessageBox.Show("No se puede eliminar ya que este Lote contiene movimientos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else {
                        dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                    }
                }
                else
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                txtProducto.Enabled = false;
                txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                txtCantidad.Text= dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                lblCantidadVieja.Text = dgvDatos.SelectedRows[0].Cells["CantidadVieja"].Value.ToString();
                lblRenglon.Text= dgvDatos.SelectedRows[0].Cells["Renglon"].Value.ToString();
                lblLote.Text= dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();
                lblMovStock.Text = dgvDatos.SelectedRows[0].Cells["CodigoMovStock"].Value.ToString();

                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                txtCantidad.Focus();
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor);
            if(cbRemito.Checked)
                res = res || Utilidades.Validar.NumeroDocumentoBlanco(txtNumeroComprobante1);
            res = res || Utilidades.Validar.GrillaVacia(dgvDatos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTransportes);
            return res;
        }

        private bool ValidarDatos()
        {
            bool res = false;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                
                objEntidadesLote = objLogicaLote.ObtenerUno(Convert.ToInt32(fila.Cells["Lote"].Value));
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value) - Convert.ToInt32(fila.Cells["CantidadVieja"].Value);
                if (!(objEntidadesLote == null || objEntidadesLote.Stock + cantidad >= 0)) {
                    return true;
                }

            }
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ValidarDatos().Equals(true)) {
                MessageBox.Show("No se pueden realizar las Modificaciones debido a que no cuenta con Stock de alguno de los productos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtProducto.Enabled == false) {
                MessageBox.Show("Contiene productos sin agregar a la grilla!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                objEntidadRemito.Codigo = Convert.ToInt32(CodigoRemito);

            
                if (objLogicaRemito.ExisteFactura(objEntidadRemito))
                {
                    MessageBox.Show("No se pueden guardar las modificaciones.\nFactura de Remito ya cargada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (objLogicaRemito.ExisteLiquidacion(objEntidadRemito))
                {
                    MessageBox.Show("No se pueden guardar las modificaciones.\nRemito ya posee Liquidacion asociada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            


            objEntidadRemito.Fecha = dtpFecha.Value;
            objEntidadRemito.FechaEmbarque = dtpFechaEmbarque.Value;
            objEntidadRemito.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEntidadRemito.Provisorio = !cbRemito.Checked;
            objEntidadRemito.NumRemito = txtNumeroComprobante1.Valor;
            /*if (cbDTVe.Checked)
                objEntidadRemito.DTVE = txtNumeroDTV.Valor;
            else
                objEntidadRemito.DTVE = "";*/
            objEntidadRemito.Canal.Codigo= Convert.ToInt32(cbCanal.SelectedValue);
            
            objEntidadRemito.TipoRemitoProveedor.Codigo = 1;
            objEntidadRemito.Pallets = Convert.ToInt32(nudPallets.Value);
            Entidades.Transporte objETransporte = new Entidades.Transporte();
            objETransporte.Codigo = Convert.ToInt32(cbTransportes.SelectedValue);
            objEntidadRemito.Transporte = objETransporte;
                objEntidadRemito.Usuario = Singleton.Instancia.Usuario;
                int renglon = 1;
            objEntidadRemito.Productos.Clear();
            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                objEntidadRemitoProductos = new Entidades.RemitoProveedor_D_Producto();
                objEntidadRemitoProductos.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                objEntidadRemitoProductos.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                objEntidadRemitoProductos.MovStock_Lotes.Cantidad= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                if(objEntidadRemito.Codigo==0)
                    objEntidadRemitoProductos.Renglon = renglon;
                else
                    objEntidadRemitoProductos.Renglon=Convert.ToInt32(fila.Cells["Renglon"].Value);

                objEntidadRemitoProductos.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                objEntidadRemitoProductos.MovStock_Lotes.Codigo = Convert.ToInt32(fila.Cells["CodigoMovStock"].Value);
            //    objEntidadRemitoProductos.MovStock_Lotes.IdLote.DTVe = fila.Cells["DTVe"].Value == null ? null : (fila.Cells["DTVe"].Value.ToString().Trim().Equals("")?null: fila.Cells["DTVe"].Value.ToString());
                /*
                if (cbDTVe.Checked) {
                    
                    if (Convert.ToBoolean(fila.Cells["DTVe"].Value)) {
                        objEntidadRemitoProductos.MovStock_Lotes.IdLote.DTVe = txtNumeroDTV.Valor;
                    }
                }*/
                renglon += 1;
                objEntidadRemito.Productos.Add(objEntidadRemitoProductos);
            }
            
                if (CodigoRemito == 0)
                {
                    int cod=objLogicaRemito.Agregar(objEntidadRemito);
                    Limpiar();
                    CodigoRemito = 0;
                    MessageBox.Show("Remito Nº "+ cod + " creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objEntidadRemito.Codigo = CodigoRemito;
                        foreach (DataGridViewRow dg in dgvDatos.Rows)
                        {
                            if (Convert.ToInt32(dg.Cells["Lote"].Value) != 0) { 
                            //int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                            int ingreso = objLLote.ObtenerIngreso(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                            int cantNueva = Convert.ToInt32(dg.Cells["Cantidad"].Value);
                                /*if (!((ingreso <= Convert.ToInt32(dg.Cells["Cantidad"].Value)) || (stock <= ingreso - Convert.ToInt32(dg.Cells["Cantidad"].Value)))){
                                    MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }*/
                                if (ingreso > cantNueva) {
                                    int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                                    if (stock<ingreso-cantNueva) {
                                        MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }

                            }
                            /* if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                             {
                                 MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 return;
                             }*/
                        }
                        objLogicaRemito.Agregar(objEntidadRemito);
                        Limpiar();
                        CodigoRemito = 0;
                        MessageBox.Show("Remito modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int codigoRemito;

        public int CodigoRemito
        {
            get
            {
                return codigoRemito;
            }

            set
            {
                codigoRemito = value;
            }
        }



        private void frmRemitoProveedor_Activated(object sender, EventArgs e)
        {
            if (busqueda.Equals("Transportes"))
                CargarTransportes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNumeroComprobante1.txtLetra.Text = "R";

            Utilidades.ControlesGenerales.Habilitar(this);
            txtNumeroComprobante1.DesHabilitar();
            cbRemito.Checked = false;
            //dtpFecha.Enabled = false;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            //dtpFecha.Focus();
            txtCodigoProveedor.Focus();
        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            txtNumeroComprobante1.Limpiar();
            cbRemito.Checked = false;
            BotonesInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CodigoRemito = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        //    objEntidadRemito.Codigo = objEntidadRemito.Codigo;
            if (MessageBox.Show("¿Desea eliminar el Remito seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objEntidadRemito.Codigo = CodigoRemito;
                    objLogicaRemito.Eliminar(objEntidadRemito);
                    Limpiar();
                    CodigoRemito = 0;
                    MessageBox.Show("Remito eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbRemito_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemito.Checked)
            {
                txtNumeroComprobante1.Habilitar();
                txtNumeroComprobante1.txtPuntoVenta.Focus();
            }
            else {
                txtNumeroComprobante1.DesHabilitar();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblProducto_Click(object sender, EventArgs e)
        {

        }
        

        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDatos.IsCurrentCellDirty)
            {
                dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmTransportes());
            busqueda = "Transportes";
        }

    }
}
