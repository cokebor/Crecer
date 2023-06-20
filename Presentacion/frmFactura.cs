using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Presentacion
{
    public partial class frmFactura : frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Factura_Detalle objEFacturaDetalle = new Entidades.Factura_Detalle();
        Entidades.FormaDePago objEFormasDePago = new Entidades.FormaDePago();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();
        
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.MovStock_Lote objLMovStock = new Logica.MovStock_Lote();
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        frmFormasDePago frmFormas;// = new frmFormasDePago("Ventas", this);

        double[] porcentajes = new double[3];

        private double neto, iva, precioUnitario;

        private int cantItems;
        public frmFactura()
        {
            InitializeComponent();
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ConfiguracionInicial();
            panelPorUnidad.Visible = true;
            panelPorKilo.Visible = false;
            frmFormas = new frmFormasDePago("Ventas", this);
        }

        private void ConfiguracionInicial()
        {

            lblFecha.Text = DateTime.Now.ToString("d").Replace("-", "/");
            Titulo();
            LimitesTamaño();
            Formatos();
            txtNumeroComprobante1.txtLetra.Text = "R";
            lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblIva.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblDescuentos.Text = Convert.ToDouble("0").ToString("C2");
            lblIvaDescuentos.Text = Convert.ToDouble("0").ToString("C2");
            lblPercepcionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
            CargarValores();

            cantItems = 15;
            if (Singleton.Instancia.Empresa.Codigo == 10)
            {
                cantItems = 20;
            }
        }

        private void CargarValores() {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosVentas(), "Codigo", "Descripcion", "MIXTO");

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Titulo()
        {
            this.Text = "COMPROBANTES DE CAJA";
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
            txtNumeroComprobante1.DesHabilitar();
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Grilla.Formato(dgvDatos2);
            dgvDatos.Columns["Codigo"].Width = 45;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["PUnitario"].Width = 90;
            dgvDatos2.Columns["Codigo2"].Width = 45;
            dgvDatos2.Columns["Descripción2"].Width = 140;
            dgvDatos2.Columns["Lote2"].Width = 60;
            dgvDatos2.Columns["Cantidad2"].Width = 60;
            dgvDatos2.Columns["Kilos"].Width = 43;
            dgvDatos2.Columns["PUnitario2"].Width = 85;
            Utilidades.Combo.Formato(cbLote);
            Utilidades.Combo.Formato(cbLote2);
            Utilidades.Combo.Formato(cbSucursales);
            Utilidades.Combo.Formato(cbFormasDePago);
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos2.AllowUserToOrderColumns = false;
            dgvDatos2.Columns["Descripción2"].ReadOnly = false;
            dgvDatos.Columns["Descripción"].ReadOnly = false;
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)

        {
            AccesosRapidos(e);
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDatos.Rows.Clear();
                dgvDatos2.Rows.Clear();
                MostrarDatos();
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));


                    //objECliente.Descuentos = new List<Entidades.Descuento>();



                    //cbFormasDePago.Enabled = true;
                    cbFormasDePago.SelectedIndex = 0;

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
                        if (objECliente.Sucursales.Count > 1) { 
                        DataTable dts = new DataTable();
                        dts.Columns.Add("CodigoSucursal", typeof(int));
                        dts.Columns.Add("NombreSucursal", typeof(string));
                        foreach (Entidades.SucursalCliente sc in objECliente.Sucursales)
                        {

                                    dts.Rows.Add(sc.CodigoSucursal,sc.NombreSucursal);
                        }

                        Utilidades.Combo.Llenar(cbSucursales, dts, "CodigoSucursal", "NombreSucursal");
                        }
                        lblCtaCte.Text = objECliente.Deuda.ToString("C2");
                        if (objECliente.RiesgoFiscal == true)
                        {
                            objECliente.TipoContribuyente.PorcentajePercepcion = objECliente.TipoContribuyente.PorcentajePercepcion * 2;
                        }
                        if (objECliente.RiesgoFiscal == true)
                        {
                            objECliente.TipoContribuyente.PorcentajePercepcion = objECliente.TipoContribuyente.PorcentajePercepcion * 2;
                        }
                        if (objECliente.CtaCte)
                        {
                            cbFormasDePago.SelectedValue = 2;
                        }
                        else
                        {
                            cbFormasDePago.SelectedValue = 1;
                        }
                        /* if (objECliente.MiPYME)
                         {
                             cbFormasDePago.SelectedIndex = 1;
                             cbFormasDePago.Enabled = false;
                         }*/

                        DataTable dt = objLCliente.ObtenerDescuentos(objECliente);
                        objECliente.Descuentos = (from DataRow dr in dt.Rows
                                                  select new Entidades.Descuento()
                                                  {
                                                      Descripcion = dr["Descripcion"].ToString(),
                                                      Porcentaje = Convert.ToDouble(dr["Porcentaje"])
                                                  }).ToList();

                        ObtenerTipoDocumento();
                        if (objECliente.FacturaKilos)
                        {
                            panelPorUnidad.Visible = false;
                            panelPorKilo.Visible = true;

                        }
                        else
                        {
                            panelPorKilo.Visible = false;
                            panelPorUnidad.Visible = true;
                        }
                        btnEditarCliente.Enabled = true;
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                        lblNumero.Text = "";
                        lblCtaCte.Text = "";
                        btnEditarCliente.Enabled = false;
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                    lblNumero.Text = "";
                    lblCtaCte.Text = "";
                    btnEditarCliente.Enabled = false;
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<DataTable> lista;


        private void GuardarPDF(string tipo)
        {
            /*EntidadesInformes.EncabezadoFacturaVenta encabezado = new EntidadesInformes.EncabezadoFacturaVenta();
            encabezado.TipoResponsabilidad = "I.V.A. Responsable Inscripto";*/
            lista = new List<DataTable>();
            string codigo;
            DataTable dtEncabezado = new DataTable();
            dtEncabezado.TableName = "dsEncabezado";
            dtEncabezado.Columns.Add("TipoResponsabilidad");
            dtEncabezado.Columns.Add("Codigo");
            dtEncabezado.Columns.Add("CondicionVenta");
            dtEncabezado.Columns.Add("TipoVenta");
            dtEncabezado.Columns.Add("TotalEnLetras");
            dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta, Utilidades.Convertir.PrimeraLetra(Utilidades.NumeroEnLetras.Convertir(objEFactura.Total.ToString("#######.00"), false)));

            //lista.Add(new Logica.Sucursal().ObtenerUno(Singleton.Instancia.Empresa.Codigo));
            DataTable dtEmpresa = new DataTable();
            dtEmpresa = new Logica.Empresa().ObtenerDataTable();
            codigo = dtEmpresa.Rows[0]["CUIT"].ToString().Replace("-", "");
            codigo = codigo + objEFactura.CodigoTipoDocumento.Replace("Cod. ", "");


            DataTable dtFactura = new DataTable();
            dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo);

            codigo = codigo + Convert.ToInt32(dtFactura.Rows[0]["PuntoDeVenta"]).ToString("0000");
            codigo = codigo + dtFactura.Rows[0]["CAE"];
            codigo = codigo + Convert.ToDateTime(dtFactura.Rows[0]["FechaVenCae"]).ToString("yyyyMMdd");
            codigo = FacturaElectronica.ToI2of5(codigo);
            dtFactura.Columns.Add("CodigoBarra");
            dtFactura.Rows[0]["CodigoBarra"] = codigo;

            DataTable dtFacturaDetalle = new DataTable();
            dtFacturaDetalle = new Logica.FacturaDetalle().ObtenerUno(objEFactura.Codigo);
            /*
            int filas = 15 - dtFacturaDetalle.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtFacturaDetalle.Rows.Add(i);
            }*/

            lista.Add(dtEmpresa);
            lista.Add(dtEncabezado);
            lista.Add(dtFactura);
            lista.Add(dtFacturaDetalle);

            frmInformes informe = new frmInformes("FACTURAS", lista, "repFacturas");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", tipo);
            parametros[1] = new ReportParameter("Factura", "");

            //informe.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { Tipo, Razon, Domicilio, Puesto, Domicilio2, Letra, Codigo, Tipo2, Numero, Fecha, CUITEmpresa, Ingresos, FechaInicio });
            informe.reportViewer1.LocalReport.SetParameters(parametros);
            


            informe.reportViewer1.RefreshReport();
            try {
                Utilidades.ControladorImpresion ci = new Utilidades.ControladorImpresion();


                
                ci.ExportarPDF(informe.reportViewer1, "(" + objEFactura.TipoDocumentoCliente.TipoDoc.Codigo + ") " + objEFactura.Numdoc);
                
                ci.Dispose();

                //Utilidades.ControladorImpresion cii = new Utilidades.ControladorImpresion();
                parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
                parametros[1] = new ReportParameter("Factura", "");
                informe.reportViewer1.LocalReport.SetParameters(parametros);
                informe.reportViewer1.RefreshReport();

                if (Singleton.Instancia.Empresa.Fiscal/*==false*/)
                {
                    if (objECliente.Original == true)
                    {
                        parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
                        parametros[1] = new ReportParameter("Factura", "");
                        informe.reportViewer1.LocalReport.SetParameters(parametros);
                        
                        informe.reportViewer1.RefreshReport();

                        ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);//, Singleton.Instancia.Usuario.BandejaComprobantes);
                    }

                    if (objECliente.Duplicado == true)
                    {
                        parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                        parametros[1] = new ReportParameter("Factura", "");
                        informe.reportViewer1.LocalReport.SetParameters(parametros);
                        informe.reportViewer1.RefreshReport();

                        ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                    }

                    if (objECliente.Triplicado == true)
                    {
                        parametros[0] = new ReportParameter("Tipo", "TRIPLICADO");
                        parametros[1] = new ReportParameter("Factura", "");
                        informe.reportViewer1.LocalReport.SetParameters(parametros);
                        informe.reportViewer1.RefreshReport();

                        ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //   Utilidades.Formularios.AbrirFuera(informe);
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

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPrecio, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtProducto2, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCantidad2, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPrecio2, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtKilos, 6);
            ((DataGridViewTextBoxColumn)dgvDatos2.Columns["Descripción2"]).MaxInputLength = 25;
            ((DataGridViewTextBoxColumn)dgvDatos.Columns["Descripción"]).MaxInputLength = 25;
        }



        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("ComprobanteCaja", this));
                    break;
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("ComprobanteCaja", this));
                    break;
                case (char)Keys.F5:
                    //Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("ComprobanteCaja", this));
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock("ComprobanteCaja", this));
                    break;
                case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmStock());
                    break;
                case (char)Keys.F3:
                    if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente) == false)
                    {
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteMovimientosCuentaCorriente(objECliente));
                    }
                    break;
                case (char)Keys.F9:
                    cbIncluyenIVA.Checked = !cbIncluyenIVA.Checked;
                    break;
            }
        }



        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null) {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = true;
            objETipoDocumentoCliente.TipoDoc.Codigo = "FA";
            objETipoDocumentoCliente.MiPYME = objECliente.MiPYME;
            FormasDePago();
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void rbCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void cbNroRemito_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNroRemito.Checked)
            {
                txtNumeroComprobante1.Habilitar();
                txtNumeroComprobante1.txtPuntoVenta.Focus();
            }
            else
            {
                txtNumeroComprobante1.DesHabilitar();
                txtNumeroComprobante1.txtPuntoVenta.Text = "";
                txtNumeroComprobante1.txtNumero.Text = "";
            }
        }

        private void FormasDePago()
        {
            if (cbFormasDePago.Text.Equals("CONTADO") || cbFormasDePago.Text.Equals("MIXTO"))
            {
                objETipoDocumentoCliente.AfectaCaja = 'I';
                objETipoDocumentoCliente.AfectaCtaCte = 'N';
            }
            else {
                if (cbFormasDePago.Text.Equals("CUENTA CORRIENTE")) {
                    objETipoDocumentoCliente.AfectaCaja = 'N';
                    objETipoDocumentoCliente.AfectaCtaCte = 'D';
                }
            }

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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void ObtenerTipoDocumento()
        {
            try
            {
                if (objECliente != null && objECliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();

                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerDeCliente(objECliente.Codigo, objETipoDocumentoCliente, objEFactura.Total);

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

        private void MostrarDatos() {
            double n, i, d, id, p = 0;
            n = Neto();
            lblNeto.Text = n.ToString("C2");
            i = Iva();
            lblIva.Text = i.ToString("C2");
            d = NetoDescuentos();
            lblDescuentos.Text = d.ToString("C2");
            id = IvaDescuentos();
            lblIvaDescuentos.Text = id.ToString("C2");
            p = PercepcionesMunicipales(n-d);
            lblPercepcionMunicipal.Text = p.ToString("C2");

            lblTotal.Text = (n + i+p - d - id).ToString("C2");
        }

        private double PercepcionesMunicipales(double pNeto){
            double per = 0;
            if (Singleton.Instancia.Empresa.PercepcionMunicipal && objECliente!=null && objECliente.TipoContribuyente.PorcentajePercepcion!=0) {
                per = Utilidades.Redondear.DosDecimales((pNeto) * objECliente.TipoContribuyente.PorcentajePercepcion / 100);
            }
            return per;
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            TraerProducto();
        }
        DataTable dt;
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            //int saldo=0;
            lblStock.Text = "";
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

        private void LlenarLotes()
        {
            dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad.Text.Trim()));

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataGridViewRow dg in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dg.Cells["Lote"].Value)) {

                        dr["Stock"] = Convert.ToInt32(dr["Stock"]) - Convert.ToInt32(dg.Cells["Cantidad"].Value);
                    }
                }
            }
            if (dgvDatos.Rows.Count > 0 && dt.Rows.Count > 0) {
                for (int i = dt.Rows.Count - 1; i >= 0; i--) {

                    if (Convert.ToInt32(dt.Rows[i]["Stock"]) - Convert.ToInt32(txtCantidad.Text.Trim()) < 0) {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }

            Utilidades.Combo.Llenar(cbLote, dt, "Lote", "Lote");
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();

                txtCantidad.Text = dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                cbLote.Text = dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();
                if (cbIncluyenIVA.Checked)
                {

                    txtPrecio.Text = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.SelectedRows[0].Cells["PUnitario"].Value) * (1 + (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100))).ToString();
                }
                else {
                    txtPrecio.Text = dgvDatos.SelectedRows[0].Cells["PUnitario"].Value.ToString();
                }
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

        private void TraerProductoPorKilo()
        {
            try
            {
                if (!txtProducto2.Text.Trim().Equals(""))
                {
                    objEProducto = objLProducto.ObtenerUnoActivo(Convert.ToInt32(txtProducto2.Text.Trim()));
                    if (objEProducto != null)
                    {
                        lblProducto2.Text = objEProducto.Descripcion;
                       // Utilidades.Combo.Llenar(cbLote2, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad2.Text = "1";
                        lblStock.Text = "";
                        txtPrecio2.Text = "";
                        txtKilos.Text = "";
                        LLenarLotesKilos();
                        if (objEProducto.FacturacionPorCubeta && objECliente.FacturacionPorCubeta)
                        {
                            label14.Text = "Cubetas:";
                            txtKilos.ReadOnly = true;
                            txtKilos.Text = Convert.ToString(Utilidades.Redondear.SinDecimales(Convert.ToInt32(txtCantidad2.Text) * objEProducto.Peso));
                        }
                        else
                        {
                            label14.Text = "Kilos:";
                            txtKilos.ReadOnly = false;
                            txtKilos.Text = "";
                        }
                    }
                    else
                    {
                        lblProducto2.Text = "";
                        txtCantidad2.Text = "";
                        txtPrecio2.Text = "";
                        cbLote2.DataSource = null;
                        lblStock.Text = "";
                        txtKilos.Text = "";
                        label14.Text = "Kilos:";
                        txtKilos.ReadOnly = false;
                    }
                }
                else
                {
                    objEProducto = null;
                    lblProducto2.Text = "";
                    txtCantidad2.Text = "";
                    cbLote2.DataSource = null;
                    txtPrecio2.Text = "";
                    lblStock.Text = "";
                    txtKilos.Text = "";
                    label14.Text = "Kilos:";
                    txtKilos.ReadOnly = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        //Utilidades.Combo.Llenar(cbLote, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, 1), "Lote", "Lote");
                        txtCantidad.Text = "1";
                        txtPrecio.Text = "";
                        lblStock.Text = "";
                        LlenarLotes();
                    }
                    else
                    {
                        lblProducto.Text = "";
                        txtCantidad.Text = "";
                        txtPrecio.Text = "";
                        lblStock.Text = "";
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
                    lblStock.Text = "";
                    txtPrecio.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void AgregarAGrilla()
        {
            if (dgvDatos.Rows.Count+objECliente.Descuentos.Count < cantItems)
            {
                if (!lblProducto.Text.Equals(""))
                {
                    if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        if (cbLote.SelectedValue != null)
                        {
                            if (!txtPrecio.Text.Equals("") && Convert.ToDouble(txtPrecio.Text.Trim()) > 0)
                            {
                                double[] precioTotalDescuento = new double[3];
                                double[] ivasDescuentos = new double[3];
                                double[] porcentajes = new double[3];
                                if (cbIncluyenIVA.Checked) {
                                    precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(txtPrecio.Text) / (1 + (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100))));
                                    neto = Utilidades.Redondear.CuatroDecimales(Convert.ToInt32(txtCantidad.Text) * precioUnitario);
                                    
                                    iva = Utilidades.Redondear.CuatroDecimales(neto * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));

                                    switch (objECliente.Descuentos.Count)
                                    {
                                        case 0:
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0,0,0,0,0,0);
                                            break;
                                        case 1:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], 0, 0, 0, 0);
                                            break;
                                        case 2:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], 0, 0);
                                            break;
                                        case 3:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                            ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                            break;
                                    }
                                    
                                    
                                    
                                }
                                else {
                                    precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(txtPrecio.Text));
                                    neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(txtCantidad.Text));
                                    
                                    iva = Utilidades.Redondear.CuatroDecimales(neto * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                    switch (objECliente.Descuentos.Count)
                                    {
                                        case 0:
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0,0,0,0,0,0);
                                            break;
                                        case 1:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], 0, 0, 0, 0);
                                            break;
                                        case 2:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], 0, 0);
                                            break;
                                        case 3:
                                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                            ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                            dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario, neto, iva, objEProducto.PorcentajeIVA, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                            break;
                                    }

                                    //dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, precioUnitario , neto, iva, objEProducto.PorcentajeIVA,precioUnitario);
                                    
                                }
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

        private void AgregarAGrillaPorKilo()
        {

                if (dgvDatos2.Rows.Count+objECliente.Descuentos.Count < cantItems)
            {
                if (!lblProducto2.Text.Equals(""))
                {
                    if (!txtCantidad2.Text.Equals("") && Convert.ToInt32(txtCantidad2.Text) > 0)
                    {
                        if (cbLote2.SelectedValue != null)
                        {
                            if (!txtPrecio2.Text.Equals("") && Convert.ToDouble(txtPrecio2.Text.Trim()) > 0)
                            {
                                double[] precioTotalDescuento=new double[3];
                                double[] ivasDescuentos = new double[3];
                                double[] porcentajes = new double[3];
                                if (cbIncluyenIVA.Checked)
                                {
                                    precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(txtPrecio2.Text) / (1 + (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100))));
                                    neto = Utilidades.Redondear.CuatroDecimales(Convert.ToInt32(txtKilos.Text) * precioUnitario);
                                    iva = Utilidades.Redondear.CuatroDecimales(neto * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                    
                                    if (objEProducto.FacturacionPorCubeta && objECliente.FacturacionPorCubeta) {
                                            switch (objECliente.Descuentos.Count)
                                            {
                                                case 0:
                                                    dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, 0,0,0,0,0,0);
                                                    break;
                                                case 1:
                                                    precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                    ivasDescuentos[0]= Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0],0,0,0,0);
                                                    break;
                                                case 2:
                                                    precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                    ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                    ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1],0, 0);
                                                    break;
                                                case 3:
                                                    precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                    ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                    ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                                    ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                    dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                                    break;
                                            }

                                            
                                    }
                                    else {
                                        switch (objECliente.Descuentos.Count)
                                        {
                                            case 0:
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, 0, 0, 0,0,0,0);
                                                break;
                                            case 1:
                                                //porcentajes[0].
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], 0,0, 0,0);
                                                break;
                                            case 2:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1],0, 0);
                                                break;
                                            case 3:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                                ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                                break;
                                        }
                                        
                                    }
                                }
                                else
                                {
                                    precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(txtPrecio2.Text)));
                                    neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToDouble(txtKilos.Text));
                                    iva = Utilidades.Redondear.CuatroDecimales(neto * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));

                                    if (objEProducto.FacturacionPorCubeta && objECliente.FacturacionPorCubeta)
                                    {
                                        switch (objECliente.Descuentos.Count)
                                        {
                                            case 0:
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToDouble(txtKilos.Text), Convert.ToDouble(txtPrecio2.Text), neto, iva, objEProducto.PorcentajeIVA, 1, 0,0,0,0,0,0);
                                                break;
                                            case 1:
                                                
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0], 0,0,0, 0);
                                                break;
                                            case 2:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1],0, 0);
                                                break;
                                            case 3:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                                ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 1, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                                break;
                                        }
                                    }
                                    else {
                                        switch (objECliente.Descuentos.Count)
                                        {
                                            case 0:
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToDouble(txtKilos.Text), Convert.ToDouble(txtPrecio2.Text), neto, iva, objEProducto.PorcentajeIVA, 0, 0, 0, 0,0,0,0);
                                                break;
                                            case 1:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], 0,0,0, 0);
                                                break;
                                            case 2:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1],0, 0);
                                                break;
                                            case 3:
                                                precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                                ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                                ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                                ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100));
                                                dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], ivasDescuentos[0], precioTotalDescuento[1], ivasDescuentos[1], precioTotalDescuento[2], ivasDescuentos[2]);
                                                break;
                                        }
                                    }
                                        
                                }
                                iva = 0;

                                txtProducto2.Text = "";
                                txtCantidad2.Text = "";
                                txtPrecio2.Text = "";
                                txtKilos.Text = "";

                                txtProducto2.Focus();
                            }
                            else
                            {
                                txtPrecio2.Focus();
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
                        txtCantidad2.Focus();
                        MessageBox.Show("La cantidad debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto valido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProducto2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Se alcanzo cantidad maxima de Productos por Factura.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbIncluyenIVA_CheckedChanged(object sender, EventArgs e)
        {
            double[] precioTotalDescuento = new double[3];
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                if (panelPorUnidad.Visible)
                {
                    if (cbIncluyenIVA.Checked)
                    {
                        precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(dg.Cells["PUnitario"].Value) / (1 + (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100))));
                        dg.Cells["PUnitario"].Value = precioUnitario;

                        neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Cantidad"].Value));
                        dg.Cells["PTDescuento11"].Value = 0;
                        dg.Cells["PTDescuento22"].Value = 0;
                        dg.Cells["PTDescuento33"].Value = 0;
                        dg.Cells["IvaD11"].Value = 0;
                        dg.Cells["IvaD22"].Value = 0;
                        dg.Cells["IvaD33"].Value = 0;
                        switch (objECliente.Descuentos.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                //porcentajes[0].
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], 0, 0);
                                break;
                            case 2:
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento22"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD22"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento22"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], precioTotalDescuento[1], 0);
                                break;
                            case 3:
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento22"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["PTDescuento33"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD22"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento22"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD33"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento33"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                break;
                        }

                        dg.Cells["Total"].Value = neto;//Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Cantidad"].Value));
                        
                        //iva = Utilidades.Redondear.CuatroDecimales(precioUnitario * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100)) * Convert.ToInt32(dg.Cells["Cantidad"].Value);
                        iva = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["Total"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                        dg.Cells["Ivas"].Value = iva;
                    }
                    else
                    {
                        precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(dg.Cells["PUnitario"].Value) * (1 + (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100))));
                        dg.Cells["PUnitario"].Value = precioUnitario;
                        neto= Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Cantidad"].Value));

                        dg.Cells["PTDescuento11"].Value = 0;
                        dg.Cells["PTDescuento22"].Value = 0;
                        dg.Cells["PTDescuento33"].Value = 0;
                        dg.Cells["IvaD11"].Value = 0;
                        dg.Cells["IvaD22"].Value = 0;
                        dg.Cells["IvaD33"].Value = 0;
                        switch (objECliente.Descuentos.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                break;
                            case 2:
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento22"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD22"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento22"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                break;
                            case 3:
                                dg.Cells["PTDescuento11"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento22"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["PTDescuento33"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                dg.Cells["IvaD11"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento11"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD22"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento22"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                dg.Cells["IvaD33"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento33"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                                break;
                        }
                        dg.Cells["Total"].Value = neto;

                        iva = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["Total"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA"].Value) / 100));
                        dg.Cells["Ivas"].Value = iva;
                    }
                }
            }
            foreach (DataGridViewRow dg in dgvDatos2.Rows)
            {
                if (panelPorKilo.Visible)
                {
                    if (cbIncluyenIVA.Checked)
                    {
                        precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(dg.Cells["PUnitario2"].Value) / (1 + (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100))));
                        dg.Cells["PUnitario2"].Value = precioUnitario;

                        neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Kilos"].Value));
                        dg.Cells["PTDescuento1"].Value = 0;
                        dg.Cells["PTDescuento2"].Value = 0;
                        dg.Cells["PTDescuento3"].Value = 0;
                        dg.Cells["IvaD1"].Value = 0;
                        dg.Cells["IvaD2"].Value = 0;
                        dg.Cells["IvaD3"].Value = 0;
                        switch (objECliente.Descuentos.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                //porcentajes[0].
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], 0, 0);
                                break;
                            case 2:
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento2"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD2"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], precioTotalDescuento[1], 0);
                                break;
                            case 3:
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento2"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["PTDescuento3"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD2"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD3"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento3"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                break;
                        }
                        dg.Cells["Total2"].Value = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Kilos"].Value));
                        //iva = Utilidades.Redondear.CuatroDecimales(precioUnitario * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100)) * Convert.ToInt32(dg.Cells["Kilos"].Value);
                        iva = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["Total2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                        dg.Cells["Ivas2"].Value = iva;
                    }
                    else
                    {
                        precioUnitario = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(dg.Cells["PUnitario2"].Value) * (1 + (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100))));
                        dg.Cells["PUnitario2"].Value = precioUnitario;
                        neto = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Kilos"].Value));

                        dg.Cells["PTDescuento1"].Value = 0;
                        dg.Cells["PTDescuento2"].Value = 0;
                        dg.Cells["PTDescuento3"].Value = 0;
                        dg.Cells["IvaD1"].Value = 0;
                        dg.Cells["IvaD2"].Value = 0;
                        dg.Cells["IvaD3"].Value = 0;
                        switch (objECliente.Descuentos.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                //porcentajes[0].
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], 0, 0);
                                break;
                            case 2:
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento2"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD2"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                //dgvDatos2.Rows.Add(txtProducto2.Text.Trim(), lblProducto2.Text, cbLote2.SelectedValue, txtCantidad2.Text, Convert.ToInt32(txtKilos.Text), precioUnitario, neto, iva, objEProducto.PorcentajeIVA, 0, precioTotalDescuento[0], precioTotalDescuento[1], 0);
                                break;
                            case 3:
                                dg.Cells["PTDescuento1"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[0].Porcentaje / 100);
                                dg.Cells["PTDescuento2"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[1].Porcentaje / 100);
                                dg.Cells["PTDescuento3"].Value = Utilidades.Redondear.CuatroDecimales(neto * objECliente.Descuentos[2].Porcentaje / 100);
                                dg.Cells["IvaD1"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento1"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD2"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                                dg.Cells["IvaD3"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["PTDescuento3"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
       
                                break;
                        }
                        dg.Cells["Total2"].Value = Utilidades.Redondear.CuatroDecimales(precioUnitario * Convert.ToInt32(dg.Cells["Kilos"].Value));
                        //iva = Utilidades.Redondear.CuatroDecimales(precioUnitario * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100)) * Convert.ToInt32(dg.Cells["Kilos"].Value);
                        iva = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dg.Cells["Total2"].Value) * (Convert.ToDouble(dg.Cells["PorcIVA2"].Value) / 100));
                        dg.Cells["Ivas2"].Value = iva;
                    }
                }
            }
            MostrarDatos();
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

        private void txtProducto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCantidad2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbLote2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            AgregarAGrillaPorKilo();
            MostrarDatos();
        }

        private void txtProducto2_TextChanged(object sender, EventArgs e)
        {
            TraerProductoPorKilo();
        }

        private void LLenarLotesKilos()     {
                dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad2.Text.Trim()));

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataGridViewRow dg in dgvDatos2.Rows)
                {
                    if (Convert.ToInt32(dr["Lote"]) == Convert.ToInt32(dg.Cells["Lote2"].Value))
                    {
                        // MessageBox.Show(dr["Stock"].ToString());
                        dr["Stock"] = Convert.ToInt32(dr["Stock"]) - Convert.ToInt32(dg.Cells["Cantidad2"].Value);
                        //  MessageBox.Show(dr["Stock"].ToString());
                    }
                }
            }
            if (dgvDatos2.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    //MessageBox.Show("Lote: " + dt.Rows[i]["Lote"].ToString() + " Stock:" + dt.Rows[i]["Stock"].ToString());
                    //MessageBox.Show(dt.Rows[i]["Stock"].ToString());
                    if (Convert.ToInt32(dt.Rows[i]["Stock"])- Convert.ToInt32(txtCantidad2.Text.Trim()) < 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    /*
                    if (Convert.ToInt32(txtCantidad2.Text.Trim()) - Convert.ToInt32(dt.Rows[i]["Stock"]) < 0) {
                        dt.Rows.Remove(dt.Rows[i]);
                    }*/
                }
            }

            Utilidades.Combo.Llenar(cbLote2, dt, "Lote", "Lote");
        }
        private void txtCantidad2_TextChanged(object sender, EventArgs e)
        {
            //     int saldo = 0;
            lblStock.Text = "";
            if (txtCantidad2.Text.Trim().Equals("") || lblProducto2.Text.Trim().Equals("")) {
                cbLote2.DataSource = null;
                txtKilos.Text = "";
            }
             
            else
                try
                {
                    /*
                    dt = objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad2.Text.Trim()));

                    foreach (DataRow dr in dt.Rows)
                    {
                        saldo = Convert.ToInt32(dr["Stock"].ToString());
                        if (!txtCantidad2.Text.Trim().Equals(""))
                        {
                            foreach (DataGridViewRow fila in dgvDatos2.Rows)
                            {


                               if (fila.Cells["Codigo2"].Value.Equals(txtProducto2.Text.Trim()) && fila.Cells["Lote2"].Value.ToString().Equals(dr["Lote"].ToString()))
                                {
                                    saldo -= Convert.ToInt32(fila.Cells["Cantidad2"].Value);
                                }
               
                            }

                        }
                        saldo -= Convert.ToInt32(txtCantidad2.Text.Trim());

                        if (saldo < 0)
                        {
                            dr.Delete();
                        }
                    }
                    Utilidades.Combo.Llenar(cbLote2, dt, "Lote", "Lote");

                    */
                    LLenarLotesKilos();
                    //Utilidades.Combo.Llenar(cbLote2, objLMovStock.ObtenerLotesSaldoPorProducto(objEProducto.Codigo, Convert.ToInt32(txtCantidad2.Text.Trim())), "Lote", "Lote");
                    if (objEProducto.FacturacionPorCubeta && objECliente.FacturacionPorCubeta)
                    {
                        txtKilos.Text = Convert.ToString(Utilidades.Redondear.SinDecimales(Convert.ToInt32(txtCantidad2.Text) * objEProducto.Peso));
                    }
                    else
                    {
                        txtKilos.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void txtKilos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (dgvDatos2.CurrentRow != null)
            {
                txtProducto2.Text = dgvDatos2.SelectedRows[0].Cells["Codigo2"].Value.ToString();

                txtCantidad2.Text = dgvDatos2.SelectedRows[0].Cells["Cantidad2"].Value.ToString();
                cbLote2.Text = dgvDatos2.SelectedRows[0].Cells["Lote2"].Value.ToString();
                txtKilos.Text = dgvDatos2.SelectedRows[0].Cells["Kilos"].Value.ToString();
                if (cbIncluyenIVA.Checked)
                {

                    txtPrecio2.Text = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos2.SelectedRows[0].Cells["PUnitario2"].Value) * (1 + (Convert.ToDouble(objEProducto.PorcentajeIVA) / 100))).ToString();
                }
                else
                {
                    txtPrecio2.Text = dgvDatos2.SelectedRows[0].Cells["PUnitario2"].Value.ToString();
                }
                dgvDatos2.Rows.Remove(dgvDatos2.CurrentRow);
                MostrarDatos();
                txtCantidad2.Focus();
            }
        }

        private void btnEliminarProducto2_Click(object sender, EventArgs e)
        {
            if (dgvDatos2.CurrentRow != null)
            {
                dgvDatos2.Rows.Remove(dgvDatos2.CurrentRow);
                MostrarDatos();
            }
        }

        private double Neto() {
            double neto = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value);
                }
            }
            else {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["Total2"].Value);            
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }
        private double NetoDescuentos()
        {
            double netoD = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    netoD += (Convert.ToDouble(dgr.Cells["PTDescuento11"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento22"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento33"].Value));
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    netoD += (Convert.ToDouble(dgr.Cells["PTDescuento1"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento2"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento3"].Value));
                }
            }
            return Utilidades.Redondear.DosDecimales(netoD);
        }

        private double Neto(double valor)
        {
            double neto = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor) {
                        neto += Convert.ToDouble(dgr.Cells["Total"].Value);
                        neto-= (Convert.ToDouble(dgr.Cells["PTDescuento11"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento22"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento33"].Value));
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["Total2"].Value);
                        neto -= (Convert.ToDouble(dgr.Cells["PTDescuento1"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento2"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento3"].Value));
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double NetoDescuentos(double valor)
        {
            double neto = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["PTDescuento11"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento22"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento33"].Value);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["PTDescuento1"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento2"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento3"].Value);
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

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
            else {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    iva += Convert.ToDouble(dgr.Cells["Ivas2"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }
        private double IvaDescuentos()
        {
            double iva = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    iva += Convert.ToDouble(dgr.Cells["IvaD11"].Value) + Convert.ToDouble(dgr.Cells["IvaD22"].Value) + Convert.ToDouble(dgr.Cells["IvaD33"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    iva += (Convert.ToDouble(dgr.Cells["IvaD1"].Value) + Convert.ToDouble(dgr.Cells["IvaD2"].Value) + Convert.ToDouble(dgr.Cells["IvaD3"].Value));
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double Iva(double valor)
        {
            double iva = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                        iva -= (Convert.ToDouble(dgr.Cells["IvaD11"].Value) + Convert.ToDouble(dgr.Cells["IvaD22"].Value) + Convert.ToDouble(dgr.Cells["IvaD33"].Value));
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        iva += Convert.ToDouble(dgr.Cells["Ivas2"].Value);
                        iva -= (Convert.ToDouble(dgr.Cells["IvaD1"].Value) + Convert.ToDouble(dgr.Cells["IvaD2"].Value) + Convert.ToDouble(dgr.Cells["IvaD3"].Value));
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }
        private double IvaDescuentos(double valor)
        {
            double iva = 0;
            if (panelPorUnidad.Visible)
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        iva += Convert.ToDouble(dgr.Cells["IvaD11"].Value) + Convert.ToDouble(dgr.Cells["IvaD22"].Value) + Convert.ToDouble(dgr.Cells["IvaD33"].Value);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        iva += Convert.ToDouble(dgr.Cells["IvaD1"].Value) + Convert.ToDouble(dgr.Cells["IvaD2"].Value) + Convert.ToDouble(dgr.Cells["IvaD3"].Value);
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

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
                        if (fe.f1TicketEsValido)
                        {
                            foreach (DataGridViewRow dg in dgvDatos.Rows)
                            {
                                int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                                if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                                {
                                    MessageBox.Show("No se puede emitir el Comprobante ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                            DataTable dt = objLCliente.ObtenerDescuentos(objECliente);
                            objECliente.Descuentos = (from DataRow dr in dt.Rows
                                                      select new Entidades.Descuento()
                                                      {
                                                          Descripcion = dr["Descripcion"].ToString(),
                                                          Porcentaje = Convert.ToDouble(dr["Porcentaje"])
                                                      }).ToList();
                            if (objECliente.RiesgoFiscal == true)
                            {
                                objECliente.TipoContribuyente.PorcentajePercepcion = objECliente.TipoContribuyente.PorcentajePercepcion * 2;
                            }
                            if (objECliente.CtaCte)
                            {
                                cbFormasDePago.SelectedValue = 2;
                            }
                            else
                            {
                                cbFormasDePago.SelectedValue = 1;
                            }
                            Comprobante();
                            Asiento();
                            objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                            bool res = fe.F1CAESolicitar();
                            if (res == true && fe.F1RespuestaCantidadReg > 0)
                            {
                                objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                objEFactura.Codigo = objLFactura.Agregar(objEFactura, objEAsiento);
                                GuardarPDF("DUPLICADO");

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
                                foreach (DataGridViewRow dg in dgvDatos.Rows)
                                {
                                    int stock = objLLote.ObtenerUno(Convert.ToInt32(dg.Cells["Lote"].Value)).Stock;
                                    if (stock < Convert.ToInt32(dg.Cells["Cantidad"].Value))
                                    {
                                        MessageBox.Show("No se puede emitir el Comprobante ya que no dispone de Stock del Lote " + dg.Cells["Lote"].Value.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                                DataTable dt = objLCliente.ObtenerDescuentos(objECliente);
                                objECliente.Descuentos = (from DataRow dr in dt.Rows
                                                          select new Entidades.Descuento()
                                                          {
                                                              Descripcion = dr["Descripcion"].ToString(),
                                                              Porcentaje = Convert.ToDouble(dr["Porcentaje"])
                                                          }).ToList();

                                Comprobante();
                                Asiento();
                                objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                                bool res = fe.F1CAESolicitar();

                                if (res == true && fe.F1RespuestaCantidadReg > 0)
                                {

                                    objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                    objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                    objEFactura.Codigo = objLFactura.Agregar(objEFactura, objEAsiento);
                                    GuardarPDF("DUPLICADO");

                                    Limpiar();
                                }
                                else
                                {
                                    /*if (fe.f1ErrorItemCantidad > 0) {
                                        fe.f1IndiceItem = 0;*/

                                    MessageBox.Show("Error: " + fe.f1ErrorMsg1 + "\n" + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("Error Nro: " + fe.F1RespuestaDetalleObservacionCode + " Error: " + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    // }

                                    MessageBox.Show("No se puede guardar el comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }


                            }
                            else
                            {
                                MessageBox.Show("Error de conexion con servidores de AFIP \n" + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // MessageBox.Show("Error: " + fe.f1ErrorMsg1, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }



                    }
     

            }
            catch (Exception ex) {
                if (ex.Message.Equals("Se ha producido un error durante el procesamiento local de informes.")) {
                    Limpiar();
                }
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();



        private void frmComprobantedeCaja_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Application.StartupPath);


            bool bResultado;
            if (Singleton.Instancia.Empresa.Fiscal) {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            }
            else {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");
                
            }
            fe.ArchivoCertificadoPassword = "030302";



            if (!bResultado)
            {
                MessageBox.Show("Error: " + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
            if (cbFormasDePago.Text.Equals("MIXTO")) {
                double total = Neto() + Iva();
                frmFormas.Total = total;
                frmFormas.Tipodocumento = "Ventas";
                frmFormas.ActualizarValores();
                frmFormas.ShowDialog();
              //  Utilidades.Formularios.Abrir(this, frmFormas);
            }
        }

        private void txtPrecio2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar() {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEEmpleado = new Entidades.Empleado();
            objECliente = new Entidades.Cliente();
            objEProducto = new Entidades.Producto();
            objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            cbIncluyenIVA.Checked = false;
            cbNroRemito.Checked = false;
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtProducto2.Text = "";
            txtCantidad2.Text = "";
            txtPrecio2.Text = "";
            txtKilos.Text = "";
            dgvDatos.Rows.Clear();
            dgvDatos2.Rows.Clear();
            MostrarDatos();
            objEFactura = new Entidades.Factura();
            objEFacturaDetalle = new Entidades.Factura_Detalle();
            //objEAsiento = new Entidades.Asiento();
            frmFormas = new frmFormasDePago("Ventas", this);
            lblSucursal.Visible = false; ;
            cbSucursales.Visible = false;
            txtCodigoVendedor.Focus();
        }

        private void Comprobante() {
            //try { 
            CargarValoresFactura();

            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoVendedor.Focus();
        }

        private void CargarValoresFactura() {
            objEFactura = new Entidades.Factura();
            //objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            
            //objEFactura.Numdoc = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fac);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objEFactura.FechaVencimientoPago = Convert.ToDateTime("01/01/2000"); 
            objEFactura.Cliente = objECliente;
            objEFactura.Vendedor = objEEmpleado;
            Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
            if (cbSucursales.Visible==true)
            {
                sc.CodigoSucursal = Convert.ToInt32(cbSucursales.SelectedValue);
            }
            else {
                sc.CodigoSucursal = 1;
            }
            objEFactura.SucursalCliente = sc;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            objEFormasDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
            Entidades.Factura_Efectivo facturaEfectivo;
            if (objEFormasDePago.Codigo == 1)
            {
                facturaEfectivo = new Entidades.Factura_Efectivo();
                facturaEfectivo.Moneda = objLMoneda.ObtenerUno(1);
                double n = Neto();
                double d = NetoDescuentos();
                facturaEfectivo.Importe = Convert.ToDouble(n + Iva()+PercepcionesMunicipales(n-d)-d-IvaDescuentos());
                objEFactura.FacturaEfectivo.Add(facturaEfectivo);
            }

            if (objEFormasDePago.Codigo == 0)
            {
                frmFormas.ObtenerDatos();
                objEFactura.FacturaEfectivo = frmFormas.ListaFacturaEfectivo;
                objEFactura.Cheques = frmFormas.Cheques;
            }
            if (objETipoDocumentoCliente.AfectaCtaCte.Equals('N')) {
                objEFactura.Imputacion = 'T';
            } else {
                objEFactura.Imputacion = 'F';
            }

            if (cbNroRemito.Checked)
                objEFactura.NroRemito = txtNumeroComprobante1.Valor;
            
            objEFactura.Neto105 = Neto(10.5);
            objEFactura.Neto21 = Neto(21);
            objEFactura.Iva105 = Iva(10.5);
            objEFactura.Iva21 = Iva(21);
            objEFactura.PercepcionMunicipal = PercepcionesMunicipales(objEFactura.Neto);
            //objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;

            objEFactura.Observaciones = "";

            int renglon = 1;
            //int renglonDescuentos = 1;
            objEFactura.Detalles.Clear();
            if (panelPorUnidad.Visible)
            {
                objEFactura.FacturaKilos = false;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    objEFacturaDetalle = new Entidades.Factura_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                    /*
                                        if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('L'))
                                        {
                                            objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PUnitario"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                                            objEFacturaDetalle.Iva = 0;

                                        }
                                        else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                                        {*/

                        objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PUnitario"].Value);
                        objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Ivas"].Value);
                    Entidades.Factura_DescuentosEspecialesDetalle objEDescuentosEspe;
                    if (objECliente.Descuentos.Count > 0)
                    {
                        objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                        objEDescuentosEspe.Renglon = renglon;
                       // objEDescuentosEspe.RenglonFactura = renglon;
                  //      objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[0].Descripcion + " " + (objECliente.Descuentos[0].Porcentaje/100).ToString("##.00 %");
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento11"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[0].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD11"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    if (objECliente.Descuentos.Count > 1)
                    {
                        objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                        objEDescuentosEspe.Renglon = renglon;
                        //objEDescuentosEspe.RenglonFactura = renglon;
                        //    objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[1].Descripcion + " " + (objECliente.Descuentos[1].Porcentaje / 100).ToString("##.00 %"); ;
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento22"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[1].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD22"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    if (objECliente.Descuentos.Count > 2)
                    {
                        objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                        objEDescuentosEspe.Renglon = renglon;
                       // objEDescuentosEspe.RenglonFactura = renglon;
                      //  objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[2].Descripcion + " " + (objECliente.Descuentos[2].Porcentaje / 100).ToString("##.00 %"); ;
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento33"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[2].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD33"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    //    }
                    objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                    renglon += 1;
                    objEFactura.Detalles.Add(objEFacturaDetalle);

                }
            }
            else
            {
                objEFactura.FacturaKilos = true;
                foreach (DataGridViewRow fila in dgvDatos2.Rows)
                {
                    objEFacturaDetalle = new Entidades.Factura_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo2"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción2"].Value.ToString();
                    objEFacturaDetalle.Kilos = Convert.ToDouble(fila.Cells["Kilos"].Value);
                    objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad2"].Value);
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA2"].Value);
                    objEFacturaDetalle.FacturaPorCubeta = Convert.ToBoolean(fila.Cells["Cubetas"].Value);
                    /*
                    if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('L'))
                    {
                        objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PUnitario2"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                        objEFacturaDetalle.Iva = 0;

                    }
                    else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                    {*/
                    objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PUnitario2"].Value);
                        objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Ivas2"].Value);

                    Entidades.Factura_DescuentosEspecialesDetalle objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                    if (objECliente.Descuentos.Count > 0)
                    {
                        objEDescuentosEspe.Renglon = renglon;
                        //objEDescuentosEspe.RenglonFactura = renglon;
                        //objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[0].Descripcion + " " + (objECliente.Descuentos[0].Porcentaje / 100).ToString("##.00 %"); ;
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento1"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[0].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD1"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    if (objECliente.Descuentos.Count > 1)
                    {
                        objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                        objEDescuentosEspe.Renglon = renglon;
                        //objEDescuentosEspe.RenglonFactura = renglon;
                        //objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[1].Descripcion + " " + (objECliente.Descuentos[1].Porcentaje / 100).ToString("##.00 %"); ;
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento2"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[1].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD2"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    if (objECliente.Descuentos.Count > 2)
                    {
                        objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                        objEDescuentosEspe.Renglon = renglon;
                        //objEDescuentosEspe.RenglonFactura = renglon;
                        //objEDescuentosEspe.RenglonDescuento = renglonDescuentos++;
                        objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                        objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                        objEDescuentosEspe.Detalle = objECliente.Descuentos[2].Descripcion + " " + (objECliente.Descuentos[2].Porcentaje / 100).ToString("##.00 %"); ;
                        objEDescuentosEspe.PrecioUnitario = -Convert.ToDouble(fila.Cells["PTDescuento3"].Value);
                        objEDescuentosEspe.Porcentaje = objECliente.Descuentos[2].Porcentaje;
                        objEDescuentosEspe.Iva = -Convert.ToDouble(fila.Cells["IvaD3"].Value);
                        if (objEDescuentosEspe.PrecioUnitario != 0)
                            objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                    }
                    objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote2"].Value);
                    renglon += 1;
                    objEFactura.Detalles.Add(objEFacturaDetalle);

                    
                }

            }
            ObtenerTipoDocumento();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
            objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            if (objETipoDocumentoCliente.MiPYME) {
                objEFactura.FechaVencimientoPago = objEFactura.Fecha.AddDays(30);
            }
        }

        private void cbLote2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLote2.SelectedIndex != -1)
                {
                    int cant = 0;
                    foreach (DataGridViewRow dr in dgvDatos2.Rows)
                    {
                        if (Convert.ToInt32(dr.Cells["Lote2"].Value) == Convert.ToInt32(cbLote2.SelectedValue))
                        {
                            cant += Convert.ToInt32(dr.Cells["Cantidad2"].Value);
                        }
                    }
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote2.SelectedValue), cant);
                    if (objELote == null)
                    {
                        lblStock.Text = "";
                        //   lblProveedor.Text = "";
                    }
                    else
                    {
                        lblStock.Text = objELote.Stock.ToString();
                        //  lblProveedor.Text = objELote.Proveedor.Nombre.ToString();
                    }
                    // objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    //  lblStock.Text = objELote.Stock.ToString();
                    // objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote2.SelectedValue));
                    // lblStock.Text = objELote.Stock.ToString();
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

        Entidades.Lote objELote;
        Logica.Lote objLLote = new Logica.Lote();
        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
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
                        lblStock.Text = "";
                        txtPrecio.Text = "";
                     //   lblProveedor.Text = "";
                    }
                    else
                    {
                        lblStock.Text = objELote.Stock.ToString();
                        txtPrecio.Text = objELote.PrecioUnitario.ToString();
                      //  lblProveedor.Text = objELote.Proveedor.Nombre.ToString();
                    }
                    // objELote = objLLote.ObtenerUno(Convert.ToInt32(cbLote.SelectedValue));
                    //  lblStock.Text = objELote.Stock.ToString();
                }
                else {
                    lblStock.Text = "";
                    txtPrecio.Text = "";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProducto2_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCantidad2_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLote2_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtKilos_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtPrecio2_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            DataTable dt2 = objLCliente.ObtenerComunicaciones(objECliente);
            DataTable dt3 = objLCliente.ObtenerDescuentos(objECliente);
            Utilidades.Formularios.Abrir(this.MdiParent, new frmCliente(objECliente, dt2, dt3));
        }

        private void frmFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
       
        }

        private void dgvDatos2_EnabledChanged(object sender, EventArgs e)
        {
           /* if (dgvDatos2.Enabled == false)
                dgvDatos2.EndEdit();*/
        }

        private void dgvDatos_EnabledChanged(object sender, EventArgs e)
        {
            /*if (dgvDatos.Enabled == false)*/
               // dgvDatos.EndEdit();
        }

        private void dgvDatos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos.EndEdit();
        }

        private void dgvDatos2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos2.EndEdit();
        }

        private void Asiento()
        {

            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = "Factura de Venta N° " + objEFactura.Numdoc;
            Entidades.Asiento_Detalle asientoDetalle;
            double neto = Neto();
            double iva = Iva();
            double netoDescuentos = NetoDescuentos();
            double percMunicipal = PercepcionesMunicipales(neto-netoDescuentos);
            double ivaDescuentos = IvaDescuentos();

            if (objEFormasDePago.Codigo == 1 || objEFormasDePago.Codigo == 2)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objEFormasDePago.CuentaContable;
                asientoDetalle.Debe = neto + iva + percMunicipal - netoDescuentos - ivaDescuentos;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            if (objEFormasDePago.Codigo == 0)
            {
                foreach (Entidades.Factura_Efectivo fe in objEFactura.FacturaEfectivo)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    //
                    objEFormasDePago = objLFormaPago.ObtenerUno(1);
                    if (fe.Moneda.Codigo == 1) 
                        asientoDetalle.CuentaContable = objEFormasDePago.CuentaContable;
                    else {
                        Int64 cuenta =0;
                        switch (Singleton.Instancia.Empresa.Codigo)
                        {
                            case 1:
                            case 2:
                            case 6:
                                cuenta = 10101020100;
                                break;
                            case 3:
                                cuenta = 10101020200;
                                break;
                            case 4:
                                cuenta = 10101020300;
                                break;
                            case 5:
                                cuenta = 10101020400;
                                break;
                            case 7:
                                cuenta = 10101020500;
                                break;

                        }
                        asientoDetalle.CuentaContable.Codigo = cuenta;
                    }
                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(fe.Importe * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
                foreach (Entidades.Cheque che in objEFactura.Cheques)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    objEFormasDePago = objLFormaPago.ObtenerUno(3);
                    asientoDetalle.CuentaContable = objEFormasDePago.CuentaContable;
                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(che.Importe * che.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableVentaSucursal;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = neto;
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(iva- ivaDescuentos);
                objEAsiento.Detalle.Add(asientoDetalle);
            if (objEFactura.PercepcionMunicipal > 0) {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEImpuesto = objLImpuesto.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEImpuesto.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = percMunicipal;
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            if (objECliente.Descuentos.Count > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableAjusteSucursal;
                asientoDetalle.Debe = netoDescuentos;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private bool Validar() {
            
            if (Utilidades.Validar.LabelEnBlanco(lblNombreVendedor)) {
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
            if (Utilidades.Validar.GrillaVacia(dgvDatos2) && dgvDatos2.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (Convert.ToInt32(cbFormasDePago.SelectedValue)==0)
            { 
                double total = Neto() + Iva();
                frmFormas.Total = total;
                frmFormas.ActualizarValores();
                if (frmFormas.Saldo!=0) {
                    MessageBox.Show("El saldo del comprobante debe ser $0.00 o debitarse completamente de cuenta corriente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                    
            }
            return false; 
        }
    }
}