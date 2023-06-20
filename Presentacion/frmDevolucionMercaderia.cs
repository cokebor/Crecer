using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDevolucionMercaderia : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();
        Entidades.Lote objEntidadLote = new Entidades.Lote();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Lote objLogicaLote = new Logica.Lote();
        public frmDevolucionMercaderia()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaño();
            Formatos();
        }

        private void Titulo()
        {
            this.Text = "DEVOLUCION DE MERCADERIA A PROVEEDOR";
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 4);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbLote);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Proveedor"].Width = 220;
            dgvDatos.Columns["Producto"].Width = 210;
            dgvDatos.Columns["Lote"].Width = 70;
            dgvDatos.Columns["Cantidad"].Width = 70;
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("DevolucionMercaderia", this));
                    break;
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("DevolucionMercaderia", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null) { 
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                        txtCodigoProducto.Text = "";
                        txtCantidad.Text = "";
                         //LlenarLotes();
                    }
                    else { 
                        lblNombreProveedor.Text = "";
                        txtCodigoProducto.Text = "";
                        txtCantidad.Text = "";
                    }
                }
                else
                {
                    objEntidadProveedor = null;
                    lblNombreProveedor.Text = "";
                    txtCodigoProducto.Text = "";
                    txtCantidad.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
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
                        lblNombreProducto.Text = objEntidadProducto.Descripcion;
                        txtCantidad.Text = "1";
                        lblStock.Text = "";
                        LlenarLotes();
                    }
                    else
                    {
                        lblNombreProducto.Text = "";
                        txtCantidad.Text = "";
                        lblStock.Text = "";
                        cbLote.DataSource = null;
                    }
                }
                else
                {
                    objEntidadProducto = null;
                    lblNombreProducto.Text = "";
                    cbLote.DataSource = null;
                    txtCantidad.Text = "";
                    lblStock.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            lblStock.Text = "";
            if (txtCantidad.Text.Trim().Equals("") || lblNombreProducto.Text.Trim().Equals("") || lblNombreProveedor.Text.Trim().Equals("")) { 
                cbLote.DataSource = null;
                
            }
            else
                try
                {
                    //Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim())), "Lote", "Lote");
                    LlenarLotes();
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

        private void LlenarLotes()
        {


            DataTable dt = objLMovStock.ObtenerLotesSaldoPorProductoYProveedor(objEntidadProducto,objEntidadProveedor, Convert.ToInt32(txtCantidad.Text.Trim()));
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
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(dt.Rows[i]["Stock"]) == 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }


            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
        }

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


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
                    if (objEntidadLote == null)
                    {
                        lblStock.Text = "";
                    }
                    else
                    {
                        lblStock.Text = objEntidadLote.Stock.ToString();
                    }
                }
                else
                {
                    lblStock.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarAGrilla()
        {

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (cbLote.SelectedValue != null)
                {
                    if (fila.Cells["CodigoProducto"].Value.ToString() == txtCodigoProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString())
                    {
                        MessageBox.Show("Producto ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (!lblNombreProducto.Text.Equals(""))
            {
                if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                {
                    if (cbLote.SelectedValue != null)
                    {
                            Agregar();
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto valido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProducto.Focus();
            }
        }

        private void Agregar()
        {
            try
            {
                int codMovStock=objLMovStock.VerSiExisteComprobante(Convert.ToInt32(cbLote.SelectedValue));
                dgvDatos.Rows.Add(txtCodigoProveedor.Text.Trim(), lblNombreProveedor.Text, txtCodigoProducto.Text.Trim(), lblNombreProducto.Text, cbLote.SelectedValue, txtCantidad.Text, codMovStock);
                //txtCodigoProveedor.Text = "";
                txtCodigoProducto.Text = "";
                txtCantidad.Text = "";
                txtCodigoProducto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAGrilla();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
        }

        private void cbLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoProducto.Text = "";
            txtCodigoProveedor.Text = "";
            dgvDatos.Rows.Clear();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                Entidades.MovStock_Lotes msl;
                // foreach (DataGridViewRow dg in dgvDatos.Rows) {
                int j = 0;
                for(int i= dgvDatos.Rows.Count-1; i >= 0; i--) { 
                    msl = new Entidades.MovStock_Lotes();
                    msl.IdLote.Producto.Codigo = Convert.ToInt32(dgvDatos["CodigoProducto",i].Value);//dg.Cells["CodigoProducto"].Value);
                    msl.IdLote.IdLote = Convert.ToInt32(dgvDatos["Lote", i].Value);
                    msl.Codigo= Convert.ToInt32(dgvDatos["CodigoMovStock", i].Value);
                    msl.Cantidad = Convert.ToInt32(dgvDatos["Cantidad", i].Value);
                    try
                    {
                        objLMovStock.Actualizar(msl, Singleton.Instancia.Usuario);
                        j++;
                        dgvDatos.Rows.RemoveAt(i);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (j > 0) {
                    MessageBox.Show("Devolución creada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("No se puede grabar la devolucion. \nNo se cargaron Productos!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
