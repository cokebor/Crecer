using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRemitoSucursal : Presentacion.frmColor
    {
        Entidades.Sucursal objEntidadSucursal = new Entidades.Sucursal();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();
        Entidades.Lote objEntidadLote = new Entidades.Lote();
        Entidades.RemitoSucursal_M objEntidadRemito = new Entidades.RemitoSucursal_M();
        Entidades.RemitoSucursal_D_Producto objEntidadRemitoProductos = null;

        Logica.Sucursal objLogicaSucursal = new Logica.Sucursal();
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Lote objLogicaLote = new Logica.Lote();
        Logica.RemitoSucursal objLogicaRemito = new Logica.RemitoSucursal();
        public frmRemitoSucursal()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }


  
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
         //   BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "DISTRIBUCION DE GUIAS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoSucursal, 2);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 5);
        }

        private void Formatos()
        {

            Utilidades.Combo.Formato(cbLote);
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Lote"].Width = 70;
            //dgvDatos.Columns["DTV"].Width = 50;
            dgvDatos.Columns["Cantidad"].Width = 80;
        }
/*
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(null, btnConfirmar, null, btnCancelar);
        }**/

        private void txtCodigoSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

           private void AccesosRapidos(KeyEventArgs e) {
            switch (e.KeyValue){
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock("RemitoSucursal", this));//frmProductoBuscar("RemitoSucursal", this));
                    //Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("RemitoSucursal", this));
                    break;
                case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock());
                    break;
                case (char)Keys.F7:
                    btnConfirmar.PerformClick();
                    break;
            }

        }
        private void txtCodigoSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoSucursal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoSucursal.Text.Trim().Equals("")) {
                    objEntidadSucursal = objLogicaSucursal.ObtenerSucursal(Singleton.Instancia.Empresa.Codigo, Convert.ToInt32(txtCodigoSucursal.Text.Trim()));
                    if(objEntidadSucursal != null)
                        lblNombreSucursal.Text = objEntidadSucursal.RazonSocial;
                    else
                        lblNombreSucursal.Text = "";
                }
                else {
                    objEntidadSucursal = null;
                    lblNombreSucursal.Text = "";
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            TextProducto();
        }
        private void TextProducto()
        {
            try
            {
                if (!txtCodigoProducto.Text.Trim().Equals(""))
                {
                    objEntidadProducto = objLogicaProducto.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProducto.Text.Trim()));
                    if (objEntidadProducto != null)
                    {
                        lblProducto.Text = objEntidadProducto.Descripcion;
                        lblStock.Text = "";
                        txtCantidad.Text = "1";
                        lblProveedor.Text = "";

                        LlenarLotes();
                        /*int cant = 0;
                        DataTable dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));
                        foreach (DataGridViewRow dg in dgvDatos.Rows)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dg.Cells["Lote"].Value))
                                {

                                    dr["Stock"] = Convert.ToInt32(dr["Stock"]) - Convert.ToInt32(dg.Cells["Cantidad"].Value);
                                }
                            }
                        }

                        if (dgvDatos.Rows.Count > 0)
                        {
                            //foreach (DataRow dr in dt.Rows)
                            for (int i = dt.Rows.Count; i == 0; i--) { 

                                if (Convert.ToInt32(dt.Rows[i]["Stock"]) == 0) {
                                    dt.Rows.Remove(dt.Rows[i]);
                                }
                            }
                        }
                        Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
                        */
                       // lblProveedor.Text = "";
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        //cbLote.Items.Clear();
                        cbLote.DataSource = null;
                        lblStock.Text = "";
                        lblProveedor.Text = "";
                    }
                }
                else
                {
                    objEntidadProducto = null;
                    lblProducto.Text = "";
                    cbLote.DataSource = null;
                    lblStock.Text = "";
                    txtCantidad.Text = "";
                    lblProveedor.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

       // DataTable dt;
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim().Equals("") || lblProducto.Text.Trim().Equals(""))
                cbLote.DataSource = null;
            else
                try
                {
                    LlenarLotes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void LlenarLotes() {
            //int cant = 0;
            DataTable dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dg.Cells["Lote"].Value))
                    {

                        dr["Stock"] = Convert.ToInt32(dr["Stock"]) - Convert.ToInt32(dg.Cells["Cantidad"].Value);
                    }
                }
            }

            if (dgvDatos.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                //foreach (DataRow dr in dt.Rows)
                for (int i = dt.Rows.Count-1; i >= 0; i--)
                {
                    //MessageBox.Show("Lote: " + dt.Rows[i]["Lote"].ToString() + "Stock: " + dt.Rows[i]["Stock"].ToString() + " Indice: " + i);
                    if (Convert.ToInt32(dt.Rows[i]["Stock"]) == 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }


           /* for (int i = 0; i < dt.Rows.Count; i++) {
                MessageBox.Show("Lote: " + dt.Rows[i]["Lote"].ToString() + "Stock: " + dt.Rows[i]["Stock"].ToString() + " Indice: " + i);
            }
            **/


            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
        }

        private void dtpIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtpIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLote.SelectedIndex != -1)
                {
                    int cant=0;
                    foreach (DataGridViewRow dr in dgvDatos.Rows) {
                        if (Convert.ToInt32(dr.Cells["Lote"].Value) == Convert.ToInt32(cbLote.SelectedValue)) {
                            cant = Convert.ToInt32(dr.Cells["Cantidad"].Value);
                        }
                    }
                    objEntidadLote = objLogicaLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue),cant);
                    if (objEntidadLote == null) {
                        lblStock.Text = "";
                        lblProveedor.Text = "";
         //               lblDTVe.Text = "";
                    }
                    else { 
                    lblStock.Text = objEntidadLote.Stock.ToString();
                    lblProveedor.Text = objEntidadLote.Proveedor.Nombre.ToString();
                        //lblDTVe.Text = objEntidadLote.DTVe.ToString();
                    }
                }
                else
                {
                    lblStock.Text = "";
                    lblProveedor.Text = "";
           //         lblDTVe.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAGrilla();
        }
        private void AgregarAGrilla() {

            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                if (cbLote.SelectedValue!=null) { 
                    if (fila.Cells["Codigo"].Value.ToString() ==txtCodigoProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString()) {
                        MessageBox.Show("Producto ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            if (dgvDatos.Rows.Count < 15)
            {
                if (!lblProducto.Text.Equals(""))
                {
                    if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        if (cbLote.SelectedValue != null)
                        {
                            dgvDatos.Rows.Add(txtCodigoProducto.Text.Trim(), lblProducto.Text,/*lblDTVe.Text,*/ cbLote.SelectedValue, txtCantidad.Text);
                            txtCodigoProducto.Text = "";
                            txtCantidad.Text = "";
                            txtCodigoProducto.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Lote no seleccionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtCodigoProducto.Focus();
                }
                    
            }
            else {
                MessageBox.Show("Se alcanzo cantidad maxima de Productos por Remito.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(dgvDatos.CurrentRow!=null)
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                txtCodigoProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                txtCantidad.Text= dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                cbLote.SelectedValue = dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();

                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                txtCantidad.Focus();
            }
        }

        Logica.Lote objLLote = new Logica.Lote();
        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreSucursal);
            res = res || Utilidades.Validar.GrillaVacia(dgvDatos);
            return res;
        }
        int codigoRemito;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            objEntidadRemito.TipoRemitoSucursal = ObtenerTipoRemito();
            //objEntidadRemito.Fecha = dtpFecha.Value;
            objEntidadRemito.SucursalOrigen.Codigo = Singleton.Instancia.Empresa.Codigo;
            objEntidadRemito.SucursalOrigen.RazonSocial = Singleton.Instancia.Empresa.RazonSocial;
           // Entidades.Numerador numerador = new Logica.Numerador().ObtenerUno(4);
           // objEntidadRemito.TipoRemitoSucursal.Numerador = numerador;
            //objEntidadRemito.NumRemito = numerador.Letra + "-" + numerador.PuntoVenta.ToString("0000") + "-" + numerador.Numero.ToString("00000000");
            objEntidadRemito.SucursalDestino.Codigo = Convert.ToInt32(txtCodigoSucursal.Text.Trim());

            int renglon = 1;
            objEntidadRemito.Productos.Clear();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                objEntidadRemitoProductos = new Entidades.RemitoSucursal_D_Producto();
                objEntidadRemitoProductos.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                objEntidadRemitoProductos.Movstock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                objEntidadRemitoProductos.Renglon = renglon;


                objEntidadRemitoProductos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);

                objEntidadRemito.Productos.Add(objEntidadRemitoProductos);
                renglon += 1;
                
            }
            try
            {

                foreach (DataGridViewRow dg in dgvDatos.Rows)
                {
                    int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                    if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                    {
                        MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                codigoRemito =objLogicaRemito.Agregar(objEntidadRemito);
                    Limpiar();
                    MessageBox.Show("Remito creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Informe();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    private Entidades.TipoRemitoSucursal ObtenerTipoRemito() {
            Entidades.TipoRemitoSucursal objETipoRemitoSucursal=new Entidades.TipoRemitoSucursal();
            objETipoRemitoSucursal.Codigo = 1;
            objETipoRemitoSucursal.AfectaStock = "BA";
            return objETipoRemitoSucursal;
    }


        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            txtCodigoSucursal.Focus();
        //    BotonesInicial();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        
private void Informe() {
   List<DataTable> lista = new List<DataTable>();
   lista.Add(new Logica.Empresa().ObtenerDataTable());
   lista.Add(new Logica.RemitoSucursal().ObtenerDataTable(codigoRemito));
   lista.Add(new Logica.RemitoSucursal().ObtenerDataTableDetalle(codigoRemito));
   Utilidades.Formularios.AbrirFuera(new frmInformes("REMITO DE SUCURSALES", lista, "repRemitoSucursal"));
}

        private void frmRemitoSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
