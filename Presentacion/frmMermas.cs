using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMermas : Presentacion.frmColor
    {
        Entidades.Producto objEntidadProducto = new Entidades.Producto();
        Entidades.Lote objEntidadLote = new Entidades.Lote();
        Entidades.Merma objEntidadMerma = new Entidades.Merma();
        Entidades.Merma_D_Producto objEntidadMermaProductos = null;

        Logica.Producto objLogicaProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Lote objLogicaLote = new Logica.Lote();
        Logica.Merma objLogicaMerma = new Logica.Merma();


        /*Entidades.Sucursal objEntidadSucursal = new Entidades.Sucursal();
        
        
        
        

        Logica.Sucursal objLogicaSucursal = new Logica.Sucursal();
        
        */
        public frmMermas()
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
            this.Text = "MERMAS DE PRODUCTOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 5);
        }

        private void Formatos()
        {

            Utilidades.Combo.Formato(cbLote);
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Lote"].Width = 50;
            dgvDatos.Columns["Cantidad"].Width = 70;
        }
/*
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(null, btnConfirmar, null, btnCancelar);
        }**/
        
           private void AccesosRapidos(KeyEventArgs e) {
            switch (e.KeyValue){
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("Mermas", this));
                    break;
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
                lblStock.Text = "";
                if (!txtCodigoProducto.Text.Trim().Equals(""))
                {
                    objEntidadProducto = objLogicaProducto.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProducto.Text.Trim()));
                    if (objEntidadProducto != null)
                    {
                        lblProducto.Text = objEntidadProducto.Descripcion;
                        Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad.Text = "";
                        //lblStock.Text = "";
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        //cbLote.Items.Clear();
                        cbLote.DataSource = null;
                    }
                }
                else
                {
                    objEntidadProducto = null;
                    lblProducto.Text = "";
                    lblStock.Text = "";
                    cbLote.DataSource = null;
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

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim().Equals("") || lblProducto.Text.Trim().Equals(""))
                cbLote.DataSource = null;
            else
                try
                {
                    Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEntidadProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim())), "Lote", "Lote");
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
                    objEntidadLote = objLogicaLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    lblStock.Text = objEntidadLote.Stock.ToString();
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
        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnConfirmar_KeyDown(object sender, KeyEventArgs e)
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
                            dgvDatos.Rows.Add(txtCodigoProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text);
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
                MessageBox.Show("Se alcanzo cantidad maxima de Productos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool Validar()
        {
            bool res = false;
            res = res || Utilidades.Validar.GrillaVacia(dgvDatos);
            return res;
        }
        int codigoMerma;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objEntidadMerma.Fecha = dtpFecha.Value;
            Entidades.Numerador numerador = new Logica.Numerador().ObtenerUno(19);
            objEntidadMerma.NumDoc= numerador.Letra + "-" + numerador.PuntoVenta.ToString("0000") + "-" + numerador.Numero.ToString("00000000");
            objEntidadMerma.Usuario.Codigo = Singleton.Instancia.Usuario.Codigo;

            int renglon = 1;
            objEntidadMerma.Productos.Clear();

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                objEntidadMermaProductos = new Entidades.Merma_D_Producto();
                objEntidadMermaProductos.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                objEntidadMermaProductos.Movstock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                objEntidadMermaProductos.Renglon = renglon;


                objEntidadMermaProductos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);

                objEntidadMerma.Productos.Add(objEntidadMermaProductos);
                renglon += 1;

            }
            try
            {
                foreach (DataGridViewRow dg in dgvDatos.Rows)
                {
                    int stock = objLogicaLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                    if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                    {
                        MessageBox.Show("No se puede emitir el remito ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                codigoMerma = objLogicaMerma.Agregar(objEntidadMerma);
                Limpiar();
                MessageBox.Show("Merma dada de Alta exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            txtCodigoProducto.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
