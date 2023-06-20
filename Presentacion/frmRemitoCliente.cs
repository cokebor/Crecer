using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRemitoCliente : Presentacion.frmColor
    {
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.TipoRemitoCliente objLogicaTipo = new Logica.TipoRemitoCliente();
        Logica.Numerador objLogicaNumerador = new Logica.Numerador();
        Logica.Lote objLogicaLote = new Logica.Lote();
        
                
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.RemitoCliente objLogicaRemito = new Logica.RemitoCliente();

        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.TipoRemitoCliente objEntidadTipo = new Entidades.TipoRemitoCliente();
        Entidades.Numerador objENumerador = new Entidades.Numerador();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();
        Entidades.RemitoCliente_M objEntidadRemito = new Entidades.RemitoCliente_M();
        Entidades.Lote objEntidadLote = new Entidades.Lote();
        Entidades.RemitoCliente_D_Producto objEntidadRemitoProductos = null;
        public frmRemitoCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        
        public frmRemitoCliente(Entidades.RemitoCliente_M pRemito)
        {
            InitializeComponent();
            ConfiguracionInicial(pRemito);
        }
        
        private void ConfiguracionInicial(Entidades.RemitoCliente_M pRemito)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
            CargarValoresRemitoSeleccionado(pRemito);
            
        }

        private void CargarValoresRemitoSeleccionado(Entidades.RemitoCliente_M pRemito)
        {
            
            CodigoRemito = pRemito.Codigo;
            dtpFecha.Value = pRemito.Fecha;
            txtCodigoCliente.Text = pRemito.Cliente.Codigo.ToString();
            txtNumeroComprobante1.cargarValor(pRemito.NumRemito);
            cbTipo.SelectedValue = pRemito.TipoRemitoCliente.Codigo;
           
            dgvDatos.Rows.Clear();
            foreach (Entidades.RemitoCliente_D_Producto r in pRemito.Productos) {
                dgvDatos.Rows.Add(r.Renglon, r.Producto.Codigo, r.Producto.Descripcion,r.Movstock_Lotes.IdLote.IdLote, r.Movstock_Lotes.Cantidad, r.Movstock_Lotes.Codigo, r.Movstock_Lotes.IdLote.IdLote, r.Movstock_Lotes.Cantidad);
            }
            
        }
  
        private void ConfiguracionInicial()
        {
            Titulo();
            //txtNumeroComprobante1.txtCUIL1.Text = "R";
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE REMITOS DE CLIENTES";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("Remito", this));
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 5);
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals("")) {
                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if(objEntidadCliente != null)
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                    else
                        lblNombreCliente.Text = "";
                }
                else {
                    objEntidadCliente = null;
                    lblNombreCliente.Text = "";
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
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Combo.Formato(cbLote);
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Lote"].Width = 50;
            dgvDatos.Columns["Cantidad"].Width = 70;
            /*
            dgvDatos.Columns["Tipo"].Width = 90;

            DataColumn CodigoComunicacion = dtComunicaciones.Columns.Add("CodigoComunicacion", typeof(int));
            DataColumn Descripcion = dtComunicaciones.Columns.Add("Descripcion", typeof(string));
            */
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
        }

        private void CargarValores()
        {

            try
            {
                CargarTipoRemito();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarTipoRemito()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTipo, objLogicaTipo.ObtenerSalientes(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CargarNumeroRemito()
        {
            try
            {
                objEntidadTipo = objLogicaTipo.ObtenerUno(Convert.ToInt32(cbTipo.SelectedValue));
                objENumerador = objLogicaNumerador.ObtenerUno(objEntidadTipo.Numerador.Codigo);
                txtNumeroComprobante1.txtLetra.Text = objENumerador.Letra;
                txtNumeroComprobante1.txtPuntoVenta.Text = objENumerador.PuntoVenta.ToString("0000");
                txtNumeroComprobante1.txtNumero.Text = objENumerador.Numero.ToString("00000000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            TextProducto();
        }

        private void TextProducto() {
            try
            {
                if (!txtProducto.Text.Trim().Equals(""))
                {
                    objEntidadProducto = objLogicaProducto.ObtenerUnoActivo(Convert.ToInt32(txtProducto.Text.Trim()));
                    if (objEntidadProducto != null)
                    {
                        lblProducto.Text = objEntidadProducto.Descripcion;
                        //Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad.Text = "1";
                        lblStock.Text = "";
                        lblProveedor.Text = "";
                        LlenarLotes();
                        /*
                        DataTable dt= new DataTable();
                        if (Convert.ToInt32(lblLoteViejo.Text.Trim()) != 0) {
                            //Convert.ToInt32(lblCantidad.Text.Trim())
                            dt = cbLote.DataSource as DataTable;
                            bool res = false;
                            foreach (DataRow dr in dt.Rows) {
                                if (Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(lblLoteViejo.Text.Trim()))
                                {

                                    dr["Stock"] = Convert.ToInt32(dr["Stock"]) + Convert.ToInt32(lblCantidad.Text.Trim());
                                    res = true;
                                    break;
                                }
                            }

                            if (res == false) {
                                dt.Rows.Add(Convert.ToInt32(lblLoteViejo.Text.Trim()), 0, Convert.ToInt32(txtProducto.Text.Trim()), 0, Convert.ToInt32(lblCantidad.Text.Trim()));
                            }
                            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
                        }
                        */
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        //cbLote.Items.Clear();
                        lblStock.Text = "";
                        lblProveedor.Text = "";
                        cbLote.DataSource = null;
                    }
                }
                else
                {
                    objEntidadProducto = null;
                    lblProducto.Text = "";
                    cbLote.DataSource = null;
                    lblStock.Text = "";
                    lblProveedor.Text = "";
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
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock("RemitoCliente", this));
                    //Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("RemitoCliente", this));
                    break;
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("RemitoCliente", this));
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

        private void Agregar() {
            if (lblLoteViejo.Text.Equals("0"))
                dgvDatos.Rows.Add(lblRenglon.Text, txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, lblMovStock.Text, cbLote.SelectedValue);
            else
                dgvDatos.Rows.Add(lblRenglon.Text, txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, lblMovStock.Text, lblLoteViejo.Text);

            txtProducto.Text = "";
            txtCantidad.Text = "";
            lblRenglon.Text = "0";
            lblLoteViejo.Text = "0";
            lblMovStock.Text = "0";
            lblCantidad.Text = "0";
            txtProducto.Focus();
        }


        private bool SePuedeAgregar() {
            bool res=false;
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                if (Convert.ToInt32(dg.Cells["Codigo"].Value) == Convert.ToInt32(txtProducto.Text))
                {
                    res= true;
                    break;
                }
                /*else
                {
                    if (dgvDatos.Rows.Count < 2)
                    {
                        res= true;
                        break;

                    }
                    else
                    {
                        res= false;
                        break;
                    }
                }*/
            }

            if (!res) {
                List<int> lista = new List<int>();
                
                foreach (DataGridViewRow dg in dgvDatos.Rows)
                {
                    if(!lista.Exists(element=>element==Convert.ToInt32(dg.Cells["Codigo"].Value)))
                        lista.Add(Convert.ToInt32(dg.Cells["Codigo"].Value));
                }
                /*
                if (!valores.Exists(element => element == Convert.ToDouble(fila.Cells["PorcIva3"].Value)))
                {
                    valores.Add(Convert.ToDouble(fila.Cells["PorcIva3"].Value));
                }
                */



                //if (dgvDatos.Rows.Count < 10)
                if(lista.Count<11)
                {
                    res = true;
                }
                else {
                    res = false;
                }
            }

            return res;
        }
        private void AgregarAGrilla() {

            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                if (cbLote.SelectedValue!=null) { 
                    if (fila.Cells["Codigo"].Value.ToString() ==txtProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString()) {
                        MessageBox.Show("Producto ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            /*if (dgvDatos.Rows.Count <= 21)
            {*/
                if (!lblProducto.Text.Equals(""))
                {
                    if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        if (cbLote.SelectedValue != null)
                        {
                        if (SePuedeAgregar())
                        {
                            Agregar();
                        }
                        else {
                            MessageBox.Show("Se alcanzo cantidad maxima de Productos por Remito.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        }
                        else {
                            if (!lblLoteViejo.Text.Equals("0")) {
                                if (!lblCantidad.Text.Equals("0")) {
                                    try
                                    {
                                        objEntidadLote = objLogicaLote.ObtenerUno(Convert.ToInt32(lblLoteViejo.Text));
                                    }
                                    catch (Exception ex) {
                                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    objEntidadLote.Stock = objEntidadLote.Stock + Convert.ToInt32(lblCantidad.Text);
                                    if (Convert.ToInt32(txtCantidad.Text) <= objEntidadLote.Stock)
                                    {
                                        dgvDatos.Rows.Add(lblRenglon.Text, txtProducto.Text.Trim(), lblProducto.Text, lblLoteViejo.Text, txtCantidad.Text, lblMovStock.Text, lblLoteViejo.Text, lblCantidad.Text);
                                    }
                                    else {
                                        MessageBox.Show("Cantidad en lote insuficiente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }


 

                                txtProducto.Text = "";
                                txtCantidad.Text = "";
                                lblRenglon.Text = "0";
                                lblLoteViejo.Text = "0";
                                lblMovStock.Text = "0";
                                lblCantidad.Text = "0";
                                txtProducto.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Lote no seleccionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                    
            /*}
            else {
                MessageBox.Show("Se alcanzo cantidad maxima de Productos por Remito.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(dgvDatos.CurrentRow!=null)
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                lblLoteViejo.Text = dgvDatos.SelectedRows[0].Cells["LoteViejo"].Value.ToString();
                if (dgvDatos.SelectedRows[0].Cells["CantidadVieja"].Value != null)
                    lblCantidad.Text = dgvDatos.SelectedRows[0].Cells["CantidadVieja"].Value.ToString();
                txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                txtCantidad.Text = dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                
                
                lblRenglon.Text= dgvDatos.SelectedRows[0].Cells["Renglon"].Value.ToString();
                cbLote.SelectedValue = dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();
                
                lblMovStock.Text = dgvDatos.SelectedRows[0].Cells["CodigoMovStock"].Value.ToString();

               // LlenarLotes(dgvDatos.CurrentRow);
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                txtProducto.Enabled = false;
                txtCantidad.Focus();
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreCliente);
            res = res || Utilidades.Validar.NumeroDocumentoBlanco(txtNumeroComprobante1);
            res = res || Utilidades.Validar.GrillaVacia(dgvDatos);
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            objEntidadRemito.Codigo= Convert.ToInt32(CodigoRemito);
            objEntidadRemito.Fecha = dtpFecha.Value;
            objEntidadRemito.Cliente.Codigo = Convert.ToInt32(txtCodigoCliente.Text.Trim());
            objEntidadRemito.TipoRemitoCliente.Codigo =Convert.ToInt32(cbTipo.SelectedValue);
            objEntidadRemito.NumRemito = txtNumeroComprobante1.Valor;
            
            
            int renglon = 1;
            objEntidadRemito.Productos.Clear();
            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                objEntidadRemitoProductos = new Entidades.RemitoCliente_D_Producto();
                objEntidadRemitoProductos.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                objEntidadRemitoProductos.Movstock_Lotes.Cantidad= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                if(objEntidadRemito.Codigo==0)
                    objEntidadRemitoProductos.Renglon = renglon;
                else
                    objEntidadRemitoProductos.Renglon=Convert.ToInt32(fila.Cells["Renglon"].Value);

                objEntidadRemitoProductos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["LoteViejo"].Value);
                objEntidadRemitoProductos.Movstock_Lotes.Codigo = Convert.ToInt32(fila.Cells["CodigoMovStock"].Value);
                objEntidadRemitoProductos.LoteNuevo.IdLote= Convert.ToInt32(fila.Cells["Lote"].Value);

                renglon += 1;
                objEntidadRemito.Productos.Add(objEntidadRemitoProductos);
            }
            try
            {
                if (CodigoRemito == 0)
                {
                    foreach (DataGridViewRow dg in dgvDatos.Rows) {
                        int stock=objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                        if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value)) {
                            MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    CodigoRemito= objLogicaRemito.Agregar(objEntidadRemito);
                    Limpiar();
                    MessageBox.Show("Remito creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Informe();
    
                    CodigoRemito = 0;
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objEntidadRemito.Codigo = CodigoRemito;
                        /*
                        foreach (DataGridViewRow dg in dgvDatos.Rows)
                        {
                            int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                            if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                            {
                                MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }*/
                        objLogicaRemito.Agregar(objEntidadRemito);
                        Limpiar();
                        MessageBox.Show("Remito modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Informe();
                        // Utilidades.Formularios.AbrirFuera(new frmRemitoClienteImpresion(CodigoRemito));
                        CodigoRemito = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Informe() {
            List<DataTable> lista = new List<DataTable>();
            lista.Add(new Logica.Empresa().ObtenerDataTable());
            lista.Add(new Logica.RemitoCliente().ObtenerDataTable(CodigoRemito));
            lista.Add(new Logica.RemitoCliente().ObtenerDataTableDetalle(CodigoRemito));
            Utilidades.Formularios.AbrirFuera(new frmInformes("REMITO DE CLIENTE", lista, "repRemitoCliente"));
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

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (objEntidadCliente != null)
                Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoClienteBuscar("Remito", this, objEntidadCliente.Codigo));
            
            else
                Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoClienteBuscar("Remito", this, 0));
            this.Close();
         
        }

        private void frmRemitoProveedor_Activated(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CargarNumeroRemito();
            Utilidades.ControlesGenerales.Habilitar(this);
            txtNumeroComprobante1.Enabled = false;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            dtpFecha.Focus();
        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            txtNumeroComprobante1.Limpiar();
            BotonesInicial();
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CodigoRemito = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
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

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            lblStock.Text = "";
            lblProveedor.Text = "";
            if (txtCantidad.Text.Trim().Equals("") || lblProducto.Text.Trim().Equals(""))
                cbLote.DataSource = null;
            else
                try
                {
                    //Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim())), "Lote", "Lote");
                    LlenarLotes();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
        }


        private void LlenarLotes() {
            DataTable dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (((Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dg.Cells["Lote"].Value)))) //&& (Convert.ToInt32(dg.Cells["CodigoMovStock"].Value)==0)))
                    {

                        dr["Stock"] = Convert.ToInt32(dr["Stock"]) - Convert.ToInt32(dg.Cells["Cantidad"].Value);
                    }
                }
            }

            if (dgvDatos.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                //foreach (DataRow dr in dt.Rows)
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    //MessageBox.Show("Lote: " + dt.Rows[i]["Lote"].ToString() + "Stock: " + dt.Rows[i]["Stock"].ToString() + " Indice: " + i);
                    if (Convert.ToInt32(dt.Rows[i]["Stock"]) == 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }

            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
        }

        private void LlenarLotes(DataGridViewRow dgvr)
        {
            DataTable dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));
            //foreach (DataGridViewRow dg in dgvDatos.Rows)
            //{
                foreach (DataRow dr in dt.Rows)
                {
                    if (((Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dgvr.Cells["Lote"].Value)))) //&& (Convert.ToInt32(dg.Cells["CodigoMovStock"].Value)==0)))
                    {

                        dr["Stock"] = Convert.ToInt32(dr["Stock"]) + Convert.ToInt32(dgvr.Cells["Cantidad"].Value);
                    }
                }
           // }
           /*
            if (dgvDatos.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                //foreach (DataRow dr in dt.Rows)
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    //MessageBox.Show("Lote: " + dt.Rows[i]["Lote"].ToString() + "Stock: " + dt.Rows[i]["Stock"].ToString() + " Indice: " + i);
                    if (Convert.ToInt32(dt.Rows[i]["Stock"]) == 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }*/

            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
        }
        private void cbLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        Entidades.Lote objELote;
        Logica.Lote objLLote = new Logica.Lote();
        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /*if (cbLote.SelectedIndex != -1)
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    lblStock.Text = objELote.Stock.ToString();
                }
                else
                {
                    lblStock.Text = "";
                }*/

                if (cbLote.SelectedIndex != -1)
                {
                    int cant = 0;
                    foreach (DataGridViewRow dr in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(dr.Cells["Lote"].Value) == Convert.ToInt32(cbLote.SelectedValue))
                        {
                            cant = Convert.ToInt32(dr.Cells["Cantidad"].Value);
                        }
                    }
                    objEntidadLote = objLogicaLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue), cant);
                    //objEntidadLote.Stock += cant*2;
                    if (objEntidadLote == null)
                    {
                        lblStock.Text = "";
                        lblProveedor.Text = "";
                    }
                    else
                    {
                        lblStock.Text = objEntidadLote.Stock.ToString();
                        lblProveedor.Text = objEntidadLote.Proveedor.Nombre;
                    }
                }
                else
                {
                    lblStock.Text = "";
                    lblProveedor.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}
