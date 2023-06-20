using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utilidades;

namespace Presentacion
{
    public partial class frmPreciosLotes : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Lote objELote = new Entidades.Lote();
        Entidades.Canal objECanal = new Entidades.Canal();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Lote objLLote = new Logica.Lote();
        Logica.Canal objLCanal = new Logica.Canal();

        DataView dvProductos = new DataView();
        public frmPreciosLotes()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            CargarCanales();
        }

        private void CargarCanales()
        {
            try
            {
                Utilidades.Combo.Llenar(cbCanal, objLCanal.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbCanal);
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.Columns["FechaIngreso"].Width = 63;
            dgvDatos.Columns["Proveedor"].Width = 130;
            dgvDatos.Columns["Canal"].Width = 82;
            dgvDatos.Columns["Producto"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 57;
            dgvDatos.Columns["Ingreso"].Width = 55;
            dgvDatos.Columns["Stock"].Width = 55;
            dgvDatos.Columns["PrecioPromedio"].Width = 60;
            dgvDatos.Columns["PrecioDeseado"].Width = 60;
            dgvDatos.Columns["PrecioVenta"].Width = 60;
            dgvDatos.Columns["PrecioCargado"].Width = 60;
            dgvDatos.Columns["PrecioDeseado"].ReadOnly = false;
            dgvDatos.MultiSelect = false;
            dgvDatos.AutoGenerateColumns = false;
        }
        private void Titulo()
        {
            this.Text = "CARGA DE PRECIOS DE PRODUCTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCanal, 2);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 5);
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null)
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                    else
                        lblNombreProveedor.Text = "";
                }
                else
                {
                    objEntidadProveedor = new Entidades.Proveedor();
                    lblNombreProveedor.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProveedores_CheckedChanged(object sender, EventArgs e)
        {

            if (cbProveedores.Checked)
            {
                this.txtCodigoProveedor.Enabled = false;
                this.lblProveedor.Enabled = false;
                this.txtCodigoProveedor.Text = "";

            }
            else
            {
                this.txtCodigoProveedor.Enabled = true;
                this.lblProveedor.Enabled = true;
                this.txtCodigoProveedor.Focus();
            }
            dgvDatos.DataSource = null;
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
                    if (!cbProveedores.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("PreciosLote", this));
                    break;
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("PreciosLote", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void cbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductos.Checked)
            {
                this.txtCodigoProducto.Enabled = false;
                this.lblProducto.Enabled = false;
                this.txtCodigoProducto.Text = "";
            }
            else
            {
                this.txtCodigoProducto.Enabled = true;
                this.lblProducto.Enabled = true;
                this.txtCodigoProducto.Focus();
            }
            dgvDatos.DataSource = null;
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            try
            {
                if (!txtCodigoProducto.Text.Trim().Equals(""))
                {
                    objEProducto = objLProducto.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProducto.Text.Trim()));
                    if (objEProducto != null)
                        lblNombreProducto.Text = objEProducto.Descripcion;
                    else
                        lblNombreProducto.Text = "";
                }
                else
                {
                    objEProducto = new Entidades.Producto();
                    lblNombreProducto.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoLote_TextChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            try
            {
                if (!txtCodigoLote.Text.Trim().Equals(""))
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(txtCodigoLote.Text.Trim()));
                    if (objELote != null)
                        lblNombreLote.Text = objELote.Producto.Descripcion + " - " + objELote.Proveedor.Nombre;
                    else
                        lblNombreLote.Text = "";
                }
                else
                {
                    objELote = new Entidades.Lote();
                    lblNombreLote.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLotes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLotes.Checked)
            {
                this.txtCodigoLote.Enabled = false;
                this.lblLote.Enabled = false;
                this.txtCodigoLote.Text = "";
            }
            else
            {
                this.txtCodigoLote.Enabled = true;
                this.lblLote.Enabled = true;
                this.txtCodigoLote.Focus();
            }
            dgvDatos.DataSource = null;
        }



        private bool Validar()
        {
            if (!cbProveedores.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (!cbProductos.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProducto))
            {
                MessageBox.Show("Seleccione un Producto Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (!cbLotes.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreLote))
            {
                MessageBox.Show("Seleccione un Lote Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            /*if (!cbCanales.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreCanal))
            {
                MessageBox.Show("Seleccione un Canal Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }*/

            return false;
        }

        private void cbCanales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCanales.Checked)
            {
                this.txtCodigoCanal.Enabled = false;
                this.lblNombreCanal.Enabled = false;
                this.lblCanal.Enabled = false;
                this.txtCodigoCanal.Text = "";
            }
            else
            {
                this.txtCodigoCanal.Enabled = true;
                this.lblNombreCanal.Enabled = true;
                this.lblCanal.Enabled = true;
                this.txtCodigoCanal.Focus();
            }
        }

        private void txtCodigoCanal_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoCanal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoCanal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCanal.Text.Trim().Equals(""))
                {
                    objECanal = objLCanal.ObtenerUno(Convert.ToInt32(txtCodigoCanal.Text.Trim()));
                    if (objECanal != null)
                        lblNombreCanal.Text = objECanal.Descripcion;
                    else
                        lblNombreCanal.Text = "";
                }
                else
                {
                    objECanal = new Entidades.Canal();
                    lblNombreCanal.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double Calculo(double pPrecioDeseado, int pCantidadIngresada, double pPrecioPromedio,int pCantidadVendida) {
            double netoTotal = Utilidades.Redondear.DosDecimales(pPrecioDeseado * pCantidadIngresada);
            double netoVentas = Utilidades.Redondear.DosDecimales(pPrecioPromedio * pCantidadVendida);
            double netoFaltante = Utilidades.Redondear.DosDecimales(netoTotal) - Utilidades.Redondear.DosDecimales(netoVentas);
            double precioPromedio = Utilidades.Redondear.DosDecimales(netoFaltante / (pCantidadIngresada - pCantidadVendida));
            return precioPromedio;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

       }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows[e.RowIndex].Cells["PrecioDeseado"].Value != null) { 
                double valor = Calculo(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioDeseado"].Value), Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Ingreso"].Value), Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioPromedio"].Value), Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantVendida"].Value));
                if (Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioDeseado"].Value) == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioDeseado"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioVenta"].Value = "";
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else { 
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioVenta"].Value = valor;
                    if (valor < 0 & cbPrecioAFacturar.Checked==false)
                    {
                        dgvDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        dgvDatos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                    else {
                        dgvDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvDatos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
                // validar.KeyDown += new KeyEventHandler(this.dgvDatos_KeyDown);
                //dgvDatos_KeyDown
            }
        }

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (dgvDatos.CurrentCell.ColumnIndex == 10)
            {*/
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacionCuatroDecimales(sender, e);
            /*}
            else
            {
                Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            }*/
            //Utilidades.ControlesGenerales.CambiarFoco(e);

        }
        DataTable temp = new DataTable();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Validar().Equals(false))
                {
                    CargarValores();
                    if (dvProductos.Count == 0)
                    {
                        MessageBox.Show("No se registran Productos con Stock disponible", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                         }
                /*Calculos();

                dt = objLFactura.ObtenerLiquidacionesPorProveedor(desde, hasta, objEntidadProveedor);

               

                dgvDatos.DataSource = dt;
                Calculos();

*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string filtro = "";
        private void CargarValores()
        {
            filtro="";
                dvProductos = objLProducto.ObtenerParaCargarPrecios(Singleton.Instancia.Empresa, cbSoloPoductosConSaldoEnSucursales.Checked).DefaultView;
                
                if (!cbProveedores.Checked)
                    filtro = "CodigoProveedor=" + Convert.ToInt32(txtCodigoProveedor.Text);
                
                if (!cbProductos.Checked) { 
                    filtro=AgregarAND(filtro);
                    filtro = filtro + "CodigoProducto=" + Convert.ToInt32(txtCodigoProducto.Text);
                }
                if (!cbLotes.Checked){
                filtro = AgregarAND(filtro);
                filtro = filtro + "Lote=" + Convert.ToInt32(txtCodigoLote.Text);
                }
              //  if (!cbCanales.Checked) {
                filtro = AgregarAND(filtro);
                //filtro = filtro + "CodigoCanal=" + Convert.ToInt32(txtCodigoCanal.Text);
                filtro = filtro + "CodigoCanal=" + Convert.ToInt32(cbCanal.SelectedValue);
            //}
                dvProductos.RowFilter = filtro;
                dgvDatos.DataSource = dvProductos;
             }
        
        private string AgregarAND(string filtro) {
            if (filtro.Length > 0)
                filtro = filtro + " AND ";
            return filtro;
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try {
                List<Entidades.PreciosLote> precios = new List<Entidades.PreciosLote>();
                if (ValidarPrecios().Equals(false))
                {
                    MessageBox.Show("No se cargo ningun Precio!!\nRecuerde que no se guardan precios negativos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Entidades.PreciosLote precio;
                
                precios.Clear();
                if (!cbPrecioAFacturar.Checked)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (fila.Cells["PrecioVenta"].Value != null && !fila.Cells["PrecioVenta"].Value.Equals(""))
                        {
                            double prec = Convert.ToDouble(fila.Cells["PrecioVenta"].Value);
                            if (prec > 0)
                            {
                                precio = new Entidades.PreciosLote();
                                precio.Lote = Convert.ToInt32(fila.Cells["Lote"].Value);
                                precio.PrecioUnitario = prec;
                                precios.Add(precio);
                            }
                        }
                    }
                }
                else {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (fila.Cells["PrecioDeseado"].Value != null && !fila.Cells["PrecioDeseado"].Value.Equals(""))
                        {
                            double prec = Convert.ToDouble(fila.Cells["PrecioDeseado"].Value);
                            if (prec > 0)
                            {
                                precio = new Entidades.PreciosLote();
                                precio.Lote = Convert.ToInt32(fila.Cells["Lote"].Value);
                                precio.PrecioUnitario = prec;
                                precios.Add(precio);
                            }
                        }
                    }
                }
                

                if (MessageBox.Show("¿Esta seguro que desea guardar los precios?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLProducto.AgregarPrecios(Singleton.Instancia.Usuario, precios);
                Limpiar();
                MessageBox.Show("Precios guardados exitosamente!\nRecuerde que no se guardan precios negativos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            cbProveedores.Checked = true;
            cbProductos.Checked = true;
            cbLotes.Checked = true;
            cbCanales.Checked = true;
            dgvDatos.DataSource = null;
        }

        private bool ValidarPrecios()
        {
            if (!cbPrecioAFacturar.Checked)
            {
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (fila.Cells["PrecioVenta"].Value != null && !fila.Cells["PrecioVenta"].Value.Equals("") && Convert.ToDouble(fila.Cells["PrecioVenta"].Value) > 0)
                    {
                        return true;
                    }
                }
            }
            else {
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (fila.Cells["PrecioDeseado"].Value != null && !fila.Cells["PrecioDeseado"].Value.Equals("") && Convert.ToDouble(fila.Cells["PrecioDeseado"].Value) > 0)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void cbPrecioAFacturar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrecioAFacturar.Checked)
            {
                dgvDatos.Columns["PrecioVenta"].Visible = false;
                dgvDatos.Columns["PrecioDeseado"].HeaderText = "Precio a Cargar";
            }
            else {
                dgvDatos.Columns["PrecioVenta"].Visible = true;
                dgvDatos.Columns["PrecioDeseado"].HeaderText = "Precio a Liq.";
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                DataTable dt = new DataTable();
                dt.Columns.Add("FechaIngreso", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("Proveedor", System.Type.GetType("System.String"));
                dt.Columns.Add("Canal", System.Type.GetType("System.String"));
                dt.Columns.Add("Producto", System.Type.GetType("System.String"));
                dt.Columns.Add("Lote", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Ingreso", System.Type.GetType("System.Int32"));
                dt.Columns.Add("Stock", System.Type.GetType("System.Int32"));
                dt.Columns.Add("PrecioPromedio", System.Type.GetType("System.Double"));
                dt.Columns.Add("CantVendida", System.Type.GetType("System.Int32"));
                
                

                dt = Utilidades.Grilla.ObtenerDataTable(dgvDatos);
                if (dt.Rows.Count == 0) { 
                    MessageBox.Show("No se registran Productos con Stock disponible", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("FechaIngreso", System.Type.GetType("System.DateTime"));
                dt2.Columns.Add("NombreProveedor", System.Type.GetType("System.String"));
                dt2.Columns.Add("NombreProducto", System.Type.GetType("System.String"));
                dt2.Columns.Add("Lote", System.Type.GetType("System.Int32"));
                dt2.Columns.Add("CantidadIngresada", System.Type.GetType("System.Int32"));
                dt2.Columns.Add("Stock", System.Type.GetType("System.Int32"));
                dt2.Columns.Add("PrecioPromedio", System.Type.GetType("System.Double"));
                dt2.Columns.Add("Ventas", System.Type.GetType("System.Int32"));

                foreach (DataRow item in dt.Rows)
                {
                    dt2.Rows.Add(item["FechaIngreso"], item["Proveedor"], item["Producto"], item["Lote"], item["Ingreso"], item["Stock"], item["PrecioPromedio"], item["CantVendida"]);
                }
               
                dt2.TableName = "dsPrecios";
   
                lista.Add(dt2);
                frmInformes informe = new frmInformes(this.Text, lista, "repPreciosLotes");
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", this.Text);
                informe.reportViewer1.LocalReport.SetParameters(parametros);
                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cbCanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            if (Convert.ToInt32(cbCanal.SelectedValue) == 2)
            {
                cbPrecioAFacturar.Checked = true;
                cbPrecioAFacturar.Enabled = false;
            }
            else {
                cbPrecioAFacturar.Enabled = true;
                cbPrecioAFacturar.Checked = false;
            }
            
        }
    }

 
    
}
