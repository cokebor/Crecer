using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmNCVacios : Presentacion.frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Factura_Detalle objEFacturaDetalle = new Entidades.Factura_Detalle();
        Entidades.Lote objELote;
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();


        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Lote objLLote = new Logica.Lote();
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        private double neto, iva, precioUnitario;

        public frmNCVacios()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            lblFecha.Text = DateTime.Now.ToString("d").Replace("-", "/");
            Titulo();
            LimitesTamaño();
            Formatos();
            lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblIva.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblPercepcionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
            dgvDatos.AutoGenerateColumns = false;
        }
        private void Titulo()
        {
            this.Text = "NOTAS DE CREDITO DE VACIOS";
        }
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPrecio, 10);
            ((DataGridViewTextBoxColumn)dgvDatos.Columns["Descripción"]).MaxInputLength = 25;
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
            Utilidades.Combo.Formato(cbSucursales);
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.Columns["Descripción"].ReadOnly = false;
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
                        objEEmpleado = null;
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

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("NCVacios", this));
                    break;
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("NCVacios", this));
                    break;
                case (char)Keys.F5:
                    //Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("ComprobanteCaja", this));
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock("NCVacios", this));
                    break;
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

            try
            {
                dgvDatos.Rows.Clear();
                MostrarDatos();
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));

                    if (objECliente != null)
                    {
                        lblNombreCliente.Text = objECliente.Nombre;
                        objECliente.Sucursales = objLCliente.ObtenerSucursales(objECliente);
                        if (objECliente.Sucursales.Count > 1)
                        {
                            lblSucursal.Visible = true;
                            cbSucursales.Visible = true;
                        }
                        else
                        {
                            lblSucursal.Visible = false;
                            cbSucursales.Visible = false;
                        }
                        if (objECliente.Sucursales.Count > 1)
                        {
                            DataTable dts = new DataTable();
                            dts.Columns.Add("CodigoSucursal", typeof(int));
                            dts.Columns.Add("NombreSucursal", typeof(string));
                            foreach (Entidades.SucursalCliente sc in objECliente.Sucursales)
                            {

                                dts.Rows.Add(sc.CodigoSucursal, sc.NombreSucursal);
                            }

                            Utilidades.Combo.Llenar(cbSucursales, dts, "CodigoSucursal", "NombreSucursal");
                        }
                        ObtenerTipoDocumento();
                    }
                    else
                    {
                        objECliente = null;
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTipoDocumento()
        {
            try
            {
                if (objECliente != null && objECliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();

                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerDeCliente(objECliente.Codigo, objETipoDocumentoCliente, objEFactura.Total, true);

                    if (objETipoDocumentoCliente != null)
                    {
                        lblTipoComprobanteCliente.Text = objETipoDocumentoCliente.Descripcion;
                        //  lblNumero.Text = objETipoDocumentoCliente.Numerador.Valor;
                    }
                    else
                    {
                        lblTipoComprobanteCliente.Text = "";
                        // lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteCliente.Text = "";
                    // lblNumero.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = false;// true;
            objETipoDocumentoCliente.TipoDoc.Codigo = "NC";
            objETipoDocumentoCliente.AfectaStock = "AL";


            objETipoDocumentoCliente.MiPYME = false;

            FormasDePago();
        }

        private void FormasDePago()
        {
            if (cbDevolucionEfectivo.Checked)
            {
                objETipoDocumentoCliente.AfectaCaja = 'E';
                objETipoDocumentoCliente.AfectaCtaCte = 'N';
            }
            else
            {
                objETipoDocumentoCliente.AfectaCaja = 'N';
                objETipoDocumentoCliente.AfectaCtaCte = 'C';
            }
        }
        private void MostrarDatos()
        {
            double n, i, p = 0;
            n = Neto();
            lblNeto.Text = n.ToString("C2");
            i = Iva();
            lblIva.Text = i.ToString("C2");
            p = PercepcionesMunicipales(n);
            lblPercepcionMunicipal.Text = p.ToString("C2");

            lblTotal.Text = (n + i + p).ToString("C2");
        }

        private double Neto()
        {
            double neto = 0;

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                neto += Convert.ToDouble(dgr.Cells["Total"].Value);
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Iva()
        {
            double iva = 0;

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
            }

            return Utilidades.Redondear.DosDecimales(iva);
        }
        private double PercepcionesMunicipales(double pNeto)
        {
            double per = 0;
            if (Singleton.Instancia.Empresa.PercepcionMunicipal && objECliente != null && objECliente.TipoContribuyente.PorcentajePercepcion != 0)
            {
                per = Utilidades.Redondear.DosDecimales((pNeto) * objECliente.TipoContribuyente.PorcentajePercepcion / 100);
            }
            return per;
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbDevolucionEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoVendedor.Focus();
        }
        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEEmpleado = new Entidades.Empleado();
            objECliente = new Entidades.Cliente();
            objEProducto = new Entidades.Producto();
            objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            cbDevolucionEfectivo.Checked = false;
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            dgvDatos.Rows.Clear();
            MostrarDatos();
            objEFactura = new Entidades.Factura();
            objEFacturaDetalle = new Entidades.Factura_Detalle();
            //objEAsiento = new Entidades.Asiento();
            lblSucursal.Visible = false; ;
            cbSucursales.Visible = false;
            txtCodigoVendedor.Focus();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            TraerProducto();
        }

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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

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
                        //Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad.Text = "1";
                        txtPrecio.Text = "";
                        LlenarLotes();
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        txtPrecio.Text = "";
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

        private void LlenarLotes()
        {
            Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLoteDeProducto(objEProducto.Codigo), "Lote", "Lote");
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
                MostrarDatos();
                txtCantidad.Focus();
            }

        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                MostrarDatos();
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
                            cant += Convert.ToInt32(dr.Cells["Cantidad"].Value);
                        }
                    }
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue), cant);
                    if (objELote == null)
                    {
                        txtPrecio.Text = "";
                        //   lblProveedor.Text = "";
                    }
                    else
                    {
                        txtPrecio.Text = objELote.PrecioUnitario.ToString();
                        //  lblProveedor.Text = objELote.Proveedor.Nombre.ToString();
                    }
                    // objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    //  lblStock.Text = objELote.Stock.ToString();
                }
                else
                {
                    txtPrecio.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos.EndEdit();
        }

        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objECliente.FechaValidacionCUIT.Equals(Variables.FechaNula) || objECliente.FechaValidacionCUIT < DateTime.Now.Date)
                {
                    if (MessageBox.Show("El Cliente no esta validado.\n¿Esta Seguro desea guardar el Comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (!Validar())
                {
                    if (objETipoDocumentoCliente.Electronico)
                    {
                        if (fe.f1TicketEsValido)
                        {
                            //objEFacturaOriginal = objLFactura.ObtenerUna(Convert.ToInt32(cbComprobante.SelectedValue));
                            Comprobante();
                            Asiento();
                            objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                            bool res = fe.F1CAESolicitar();
                            if (res == true && fe.F1RespuestaCantidadReg > 0)
                            {
                                objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                objEFactura.Codigo = objLFactura.Agregar(objEFactura, objEAsiento);
                                //    GuardarPDF("DUPLICADO");

                                Limpiar();
                            }
                            else
                            {
                                //for (int i = 1; i <= fe.f1ErrorItemCantidad; i++)
                                //{
                                MessageBox.Show("Error: " + fe.f1ErrorMsg1 + "\n" + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                //MessageBox.Show("Error Nro: " + fe.F1RespuestaDetalleObservacionCode + " Error: " + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }


                        }
                        else
                        {
                            if (fe.f1ObtenerTicketAcceso())
                            {
                                //  objEFacturaOriginal = objLFactura.ObtenerUna(Convert.ToInt32(cbComprobante.SelectedValue));
                                Comprobante();
                                Asiento();
                                objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                                bool res = fe.F1CAESolicitar();

                                if (res == true && fe.F1RespuestaCantidadReg > 0)
                                {

                                    objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                    objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                    objEFactura.Codigo = objLFactura.Agregar(objEFactura, objEAsiento);
                                    //      GuardarPDF("DUPLICADO");

                                    Limpiar();
                                }
                                else
                                {

                                    MessageBox.Show("Error: " + fe.f1ErrorMsg1 + "\n" + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);


                                    MessageBox.Show("No se puede guardar el comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }



                            }
                            else
                            {
                                MessageBox.Show("Error de conexion con servidores de AFIP \n" + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        Comprobante();
                        Asiento();
                        objEFactura.Codigo = objLFactura.Agregar(objEFactura, objEAsiento);
                        Limpiar();
                    }
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

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreVendedor))
            {
                MessageBox.Show("Seleccione un Vendedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoVendedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteCliente))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.GrillaVacia(dgvDatos) && dgvDatos.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarAGrilla();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarAGrilla()
        {
            if (dgvDatos.Rows.Count + objECliente.Descuentos.Count < 15)
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

                                iva = Utilidades.Redondear.CuatroDecimales(neto * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));

                                dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA);


                                //dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario , neto, iva, objEProducto.PorcentajeIVA,precioUnitario);


                                iva = 0;
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

        private void Comprobante()
        {
            Entidades.Factura objEFacturaOriginal = new Entidades.Factura();
            objEFactura = new Entidades.Factura();
            ObtenerTipoDocumento();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
            objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            //objEFactura.Numdoc = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fac);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objECliente.TipoContribuyente.PorcentajePercepcion = objEFacturaOriginal.AlicuotaMunicipal;
            objEFactura.Cliente = objECliente;
            Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
            if (cbSucursales.Visible == true)
            {
                sc.CodigoSucursal = Convert.ToInt32(cbSucursales.SelectedValue);
            }
            else
            {
                sc.CodigoSucursal = 1;
            }
            objEFactura.SucursalCliente = sc;
            objEFactura.Vendedor = objEEmpleado;
            objEFactura.FacturaKilos = false;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            //objEFormaDePago = objLFormaDePago.ObtenerUno(1);
            Entidades.Factura_Efectivo facturaEfectivo;
            double n = Neto();


            if (cbDevolucionEfectivo.Checked)
            {
                facturaEfectivo = new Entidades.Factura_Efectivo();
                facturaEfectivo.Moneda = new Logica.Moneda().ObtenerUno(1);
                facturaEfectivo.Importe = -(n + IVA() + PercepcionesMunicipales(n));
                objEFactura.FacturaEfectivo.Add(facturaEfectivo);
            }

            if (objETipoDocumentoCliente.AfectaCtaCte.Equals('N'))
            {
                objEFactura.Imputacion = 'T';
            }
            else
            {
                objEFactura.Imputacion = 'F';
            }
            if (objETipoDocumentoCliente.AfectaIVA.Equals('N'))
            {
                objEFactura.Neto105 = -Neto(0);
            }
            else
            {
                objEFactura.Neto105 = -Neto(10.5);
                objEFactura.Neto21 = -Neto(21);
                objEFactura.Iva105 = -IVA(10.5);
                objEFactura.Iva21 = -IVA(21);
            }
            objEFactura.PercepcionMunicipal = PercepcionesMunicipales(objEFactura.Neto);
            //objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;

            objEFactura.Observaciones = "";// txtObservaciones.Text.Trim();

            int renglon = 1;
            //int renglonDescuentos = 1;
            objEFactura.Detalles.Clear();

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (!fila.Cells["Cantidad"].Value.Equals(""))
                {
                    objEFacturaDetalle = new Entidades.Factura_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEFacturaDetalle.MovStock_Lotes.Cantidad = -Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                    objEFacturaDetalle.RenglonFactura = 0;// Convert.ToInt32(fila.Cells["RenglonFactura"].Value);
                    objEFacturaDetalle.Codigofactura = 0;// Convert.ToInt32(cbComprobante.SelectedValue);



                    objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PUnitario"].Value);
                    objEFacturaDetalle.Iva = -Convert.ToDouble(fila.Cells["Ivas"].Value);

                    objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                    renglon += 1;
                    objEFactura.Detalles.Add(objEFacturaDetalle);
                }
            }


        }
        private double IVA()
        {
            double iva = 0;

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (!dgr.Cells["Ivas"].Value.Equals(""))
                    iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }
        private double Neto(double valor)
        {
            double neto = 0;

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                {
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }
        private double IVA(double valor)
        {
            double iva = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                {
                    if (!dgr.Cells["Ivas"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }
        private void Asiento()
        {

            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Descripcion = "Nota de Crédito N° " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;
            double neto = Neto();
            double iva = IVA();
            double percMunicipal = PercepcionesMunicipales(neto);

            if (cbDevolucionEfectivo.Checked)
            {
                objEFormaDePago = objLFormaDePago.ObtenerUno(1);
            }
            else
            {
                objEFormaDePago = objLFormaDePago.ObtenerUno(2);
            }
            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = neto + iva + percMunicipal;
            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableDebolucionMercaderiaSucursal;
            asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(neto);
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            if (iva > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
                asientoDetalle.Debe = iva;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            if (objEFactura.PercepcionMunicipal != 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEImpuesto = objLImpuesto.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEImpuesto.CuentaContable;
                asientoDetalle.Debe = percMunicipal;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

           
        }
    }
}
