using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicialVentas : frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.SaldoInicialVentas objEVentas = new Entidades.SaldoInicialVentas();
        //Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Factura_Detalle objEVentaDetalle = new Entidades.Factura_Detalle();
        //Entidades.FormaDePago objEFormasDePago = new Entidades.FormaDePago();
        //Entidades.Asiento objEAsiento = new Entidades.Asiento();



        //List<Entidades.AsientoTemp> listaAsientosTemporales;

        Logica.Empleado objLEmpleado = new Logica.Empleado();
        //Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Venta objLVenta = new Logica.Venta();
        //Logica.Factura objLFactura = new Logica.Factura();
        //Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        //Logica.Moneda objLMoneda = new Logica.Moneda();

        //frmFormasDePago frmFormas = new frmFormasDePago("Ventas");



        private double neto, precioUnitario;
        public frmSaldoInicialVentas()
        {
            InitializeComponent();
            ConfiguracionInicial();
            panelPorUnidad.Visible = true;
        }

        private void ConfiguracionInicial()
        {

            Titulo();
            LimitesTamaño();
            Formatos();
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");

        }
        

        private void Titulo()
        {
            this.Text = "VENTAS INICIALES";
        }

        private void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoVendedor.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoVendedor.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreVendedor.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                    }
                    else
                    {
                        lblNombreVendedor.Text = "";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreVendedor.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void Formatos()
        {

            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 45;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["PUnitario"].Width = 90;
            Utilidades.Combo.Formato(cbLote);
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)

        {
            AccesosRapidos(e);
        }

        
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPrecio, 10);
        }



        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("SaldoInicialVentas", this));
                    break;
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("SaldoInicialVentas", this));
                    break;
                case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock());
                    break;
            }
        }


        /*
        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = false;
            objETipoDocumentoCliente.TipoDoc.Codigo = "FA";
            FormasDePago();
            //    }
        }
        */

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAGrilla();
            lblTotal.Text = Neto().ToString("C2");
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            TraerProducto();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int saldo = 0;
            if (txtCantidad.Text.Trim().Equals("") || lblProducto.Text.Trim().Equals(""))
                cbLote.DataSource = null;
            else
                try
                {
                    dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));


                    foreach (DataRow dr in dt.Rows)
                    {
                        saldo = Convert.ToInt32(dr["Stock"].ToString());
                        if (!txtCantidad.Text.Trim().Equals(""))
                        {
                            foreach (DataGridViewRow fila in dgvDatos.Rows)
                            {


                                // if (fila.Cells["Codigo"].Value.Equals(txtProducto.Text.Trim()) && fila.Cells["Lote"].Value.Equals(cbLote.SelectedValue)) {
                                //  MessageBox.Show(dr["Lote"].ToString()  + " " + fila.Cells["Lote"].Value);
                                if (fila.Cells["Codigo"].Value.Equals(txtProducto.Text.Trim()) && fila.Cells["Lote"].Value.ToString().Equals(dr["Lote"].ToString()))
                                {
                                    saldo -= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                                }
                                /*
                                if(cbLote.SelectedValue!=null || (fila.Cells["Codigo"].Value.ToString() == txtProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString())) 
                                {
                                        saldo-= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                                }*/
                            }

                        }
                        saldo -= Convert.ToInt32(txtCantidad.Text.Trim());
                        if (saldo < 0)
                        {
                            dr.Delete();
                        }


                    }


                    Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
                  //  Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim())), "Lote", "Lote");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();

                txtCantidad.Text = dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                cbLote.Text = dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();
                    txtPrecio.Text = dgvDatos.SelectedRows[0].Cells["PUnitario"].Value.ToString();
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                
                lblTotal.Text = Neto().ToString("C2");
                txtCantidad.Focus();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                lblTotal.Text = Neto().ToString("C2");
            }
        }


        private void TraerProducto()
        {
            try
            {
                if (!txtProducto.Text.Trim().Equals(""))
                {
                    objEProducto = objLProducto.ObtenerUnoActivo(Convert.ToInt32(txtProducto.Text.Trim()));
                    if (objEProducto != null)
                    {
                        lblProducto.Text = objEProducto.Descripcion;
                        Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad.Text = "";
                        txtPrecio.Text = "";
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        txtPrecio.Text = "";
                        //cbLote.Items.Clear();
                        cbLote.DataSource = null;
                    }
                }
                else
                {
                    objEProducto = null;
                    lblProducto.Text = "";
                    txtCantidad.Text = "";
                    cbLote.DataSource = null;
                    txtPrecio.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
                private void btnAgregar_Click(object sender, EventArgs e)
                {
                    lblNeto.Text = txtfacturarPorUnidad1.Neto.ToString("C4");
                    lblIva.Text = txtfacturarPorUnidad1.IvaTotal.ToString("C4");
                    lblTotal.Text = (Convert.ToDouble(txtfacturarPorUnidad1.Neto) + Convert.ToDouble(txtfacturarPorUnidad1.IvaTotal)).ToString("C4");
                }
                */


        private void AgregarAGrilla()
        {


            int cant = Convert.ToInt32(txtCantidad.Text);
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (cbLote.SelectedValue != null)
                {
                    if (fila.Cells["Codigo"].Value.ToString() == txtProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString())
                    {
                        cant += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    }
                }
            }

            if (!lblStock.Text.Trim().Equals(""))
            {
                if (cant <= Convert.ToInt32(lblStock.Text.Trim()))
                {
                    if (dgvDatos.Rows.Count < 15)
                    {
                        if (!lblProducto.Text.Equals(""))
                        {
                            if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                            {
                                if (cbLote.SelectedValue != null)
                                {
                                    if (!txtPrecio.Text.Equals("") && Convert.ToDouble(txtPrecio.Text.Trim()) > 0)
                                    {

                                        precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(txtPrecio.Text));
                                        neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(txtCantidad.Text));
                                        //iva = Utilidades.Redondear.CuatroDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100)) * Convert.ToInt32(txtCantidad.Text));

                                        dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, Convert.ToDouble(txtPrecio.Text), neto, 0, objEProducto.PorcentajeIVA);

                                        txtProducto.Text = "";
                                        txtCantidad.Text = "";
                                        txtPrecio.Text = "";

                                        txtProducto.Focus();
                                    }
                                    else
                                    {
                                        txtPrecio.Focus();
                                        MessageBox.Show("El Precio debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Lote no seleccionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                txtCantidad.Focus();
                                MessageBox.Show("La cantidad debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un producto valido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtProducto.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo cantidad maxima de Productos por Factura.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No dispone de Saldo suficiente para este lote.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lote no seleccionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

       
        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        

        DataTable dt;

        

        private double Neto()
        {
            double neto = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
            //return neto;
        }
        /*
        private double Neto(double valor)
        {
            double neto = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["Total"].Value);
                    }
                }
            }
            
            return Utilidades.Redondear.DosDecimales(neto);
        }*/
        /*
        private double Iva()
        {
            double iva = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                }
            }
            
            return Utilidades.Redondear.DosDecimales(iva);
            //return iva;
        }
        */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Validar())
                {
                    Comprobante();
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objEVentas.Codigo=objLVenta.Agregar(objEVentas);
                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Se ha producido un error durante el procesamiento local de informes."))
                {
                    Limpiar();
                }
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEEmpleado = null;
            objEProducto = null;
            objETipoDocumentoCliente = null;
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            dgvDatos.Rows.Clear();
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            txtCodigoVendedor.Focus();
        }

        private void Comprobante()
        {
                CargarValoresFactura();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoVendedor.Focus();
        }

        private void CargarValoresFactura()
        {
            objEVentas = new Entidades.SaldoInicialVentas();
            objETipoDocumentoCliente= objLTipoDocumentoCliente.ObtenerUno(25);
            objEVentas.TipoDocumentoCliente = objETipoDocumentoCliente;

            objEVentas.TipoDocumentoCliente.Numerador = new Logica.Numerador().ObtenerUno(objEVentas.TipoDocumentoCliente.Numerador.Codigo);
            objEVentas.Letra = Convert.ToChar(objEVentas.TipoDocumentoCliente.Numerador.Letra);
            objEVentas.PuntoDeVenta = objEVentas.TipoDocumentoCliente.Numerador.PuntoVenta;
            objEVentas.Numero = objEVentas.TipoDocumentoCliente.Numerador.Numero;
            objEVentas.Fecha = dtFecha.Value;
            objEVentas.Vendedor = objEEmpleado;
            objEVentas.PuestoCaja = Singleton.Instancia.Puesto;
            objEVentas.Usuario = Singleton.Instancia.Usuario;

            
            

            int renglon = 1;
            objEVentas.Detalle.Clear();
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    objEVentaDetalle = new Entidades.Factura_Detalle();
                    objEVentaDetalle.Renglon = renglon;
                    objEVentaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEVentaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEVentaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    //objEventaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);


                    objEVentaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PUnitario"].Value);
                    // objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Ivas"].Value);

                    objEVentaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                    renglon += 1;
                    objEVentas.Detalle.Add(objEVentaDetalle);

                }
            }

        }

        Entidades.Lote objELote;
        Logica.Lote objLLote = new Logica.Lote();

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLote.SelectedIndex != -1)
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    lblStock.Text = objELote.Stock.ToString();
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

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreVendedor))
            {
                MessageBox.Show("Seleccione un Vendedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoVendedor.Focus();
                return true;
            }

            if (Utilidades.Validar.GrillaVacia(dgvDatos) && dgvDatos.Visible==true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }
    }
}