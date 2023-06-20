using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmNCVentasIniciales : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        //Logica.Factura objLFacturaOrigical = new Logica.Factura();
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();


        //List<Entidades.AsientoTemp> listaAsientosTemporales;
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Factura objEFacturaOriginal = new Entidades.Factura();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Factura_Detalle objEFacturaDetalle = new Entidades.Factura_Detalle();

        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
        public frmNCVentasIniciales()
        {
            InitializeComponent();
            ConfiguracionInicial();
            ObtenerComprobantes();
        }

        private void ConfiguracionInicial()
        {
            lblFecha.Text = DateTime.Now.ToString("d").Replace("-", "/");
            Titulo();
            Formatos();
            LimitesTamaño();
            dgvDatos.AutoGenerateColumns = false;
        }
        private void Titulo()
        {
            this.Text = "NOTAS DE CREDITO POR DEVOLUCION DE MERCADERIA";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbComprobante);
            lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblIva.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Grilla.Formato(dgvDatos2);

            dgvDatos.Columns["Codigo"].Width = 45;
            dgvDatos2.Columns["Codigo2"].Width = 45;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos2.Columns["Descripción2"].Width = 133;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos2.Columns["Cantidad2"].Width = 60;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos2.Columns["Lote2"].Width = 60;
            dgvDatos2.Columns["Kilos"].Width = 43;
            dgvDatos.Columns["PrecioFacturado"].Width = 87;
            dgvDatos2.Columns["PrecioFacturado2"].Width = 87;
            dgvDatos.Columns["PrecioNC"].Width = 89;
            dgvDatos2.Columns["PrecioNC2"].Width = 89;
            dgvDatos.Columns["CantidadDevuelta"].Width = 102;
            dgvDatos2.Columns["CantidadDevuelta2"].Width = 102;
            dgvDatos.Columns["DescuentoTotal"].Width = 102;
            dgvDatos2.Columns["DescuentoTotal2"].Width = 102;

            dgvDatos.Columns["CantidadDevuelta"].ReadOnly = false;
            dgvDatos2.Columns["CantidadDevuelta2"].ReadOnly = false;
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("NC", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("NC", this));
                    break;
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objECliente != null)
                    {
                        lblNombreCliente.Text = objECliente.Nombre;
                        ObtenerTipoDocumento();
                        // ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                        //cbComprobante.DataSource = null;
                        // dgvDatos.Rows.Clear();
                        // dgvDatos2.Rows.Clear();
                        Calcular();
                        //  lblNumero.Text = "";
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                    cbComprobante.DataSource = null;
                    dgvDatos.Rows.Clear();
                    dgvDatos2.Rows.Clear();
                    Calcular();
                    //lblNumero.Text = "";
                }

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
                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerDeCliente(objECliente.Codigo, objETipoDocumentoCliente);

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

        private void ObtenerComprobantes()
        {
            try
            {
                /* if (objECliente != null && objECliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                 {*/
                Utilidades.Combo.Llenar(cbComprobante, objLFactura.ObtenerVentasIniciales(), "Codigo", "Numero");
                /*}
                else
                {
                    
                }*/

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

        private void cbDevolucionEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void cbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComprobante.SelectedIndex != -1)
            {
                try
                {
                    objEFacturaOriginal = objLFactura.ObtenerUnaVentasIniciales(Convert.ToInt32(cbComprobante.SelectedValue));
                    if (objEFacturaOriginal.FacturaKilos)
                    {
                        dgvDatos.Visible = false;
                        dgvDatos2.Visible = true;
                    }
                    else
                    {
                        dgvDatos.Visible = true;
                        dgvDatos2.Visible = false;
                    }
                    CargarValoresFacturaSeleccionada();
                    Calcular();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarValoresFacturaSeleccionada()
        {
            dgvDatos.Rows.Clear();
            dgvDatos2.Rows.Clear();

            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (Entidades.Factura_Detalle r in objEFacturaOriginal.Detalles)
                {
                    dgvDatos2.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.Kilos, r.PrecioUnitario, r.PrecioUnitarioConDescuento, "", 0, "", r.PorIva);
                }
            }
            else
            {
                foreach (Entidades.Factura_Detalle r in objEFacturaOriginal.Detalles)
                {
                    dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.PrecioUnitario, r.PrecioUnitarioConDescuento, "", 0, "", r.PorIva);
                }
            }

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

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void frmNC_Load(object sender, EventArgs e)
        {
            // bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");
            //   bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");

            bool bResultado;
            if (Singleton.Instancia.Empresa.Fiscal)
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            }
            else
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");

            }




            fe.ArchivoCertificadoPassword = "030302";



            if (!bResultado)
            {
                MessageBox.Show("Error: " + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);

                //validar.KeyUp += new KeyEventHandler(this.Validar_TextChanged);
            }
        }

        private void dgvDatos2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);

                //validar.KeyUp += new KeyEventHandler(this.Validar_TextChanged);
            }
        }

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value) <= Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value))
            {
                double precioUnitario;
                if (cbDescontarSobrePrecioDeFacturacion.Checked)
                    precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioFacturado"].Value));
                else
                    precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioNC"].Value));

                double porcIVA = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIVA"].Value);
                int cantDevuelta = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value);
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value = Utilidades.Redondear.CuatroDecimales(cantDevuelta * precioUnitario);
                //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cantDevuelta);

                dgvDatos.Rows[e.RowIndex].Cells["Ivas"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value) * (porcIVA / 100));
                if (cantDevuelta == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "";
                }
            }
            else
            {
                MessageBox.Show("Cantidad incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "";
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["Ivas"].Value = "";
            }
            Calcular();
        }

        private double Neto()
        {
            double neto = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["DescuentoTotal2"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["DescuentoTotal"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double IVA()
        {
            double iva = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (!dgr.Cells["Iva2"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Iva2"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (!dgr.Cells["Ivas"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private void Calcular()
        {
            lblNeto.Text = Neto().ToString("C2");
            lblIva.Text = IVA().ToString("C2");
            lblTotal.Text = (Neto() + IVA()).ToString("C2");
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
                    if (objETipoDocumentoCliente.Electronico)
                    {
                        if (fe.f1TicketEsValido)
                        {
                            Comprobante();
                            Asiento();
                            objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                            bool res = fe.F1CAESolicitar();
                            if (res == true && fe.F1RespuestaCantidadReg > 0)
                            {
                                objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                objEFactura.Codigo = objLFactura.AgregarDeVentaInicial(objEFactura, objEAsiento);
                                GuardarPDF("DUPLICADO");

                                Limpiar();
                            }


                        }
                        else
                        {
                            if (fe.f1ObtenerTicketAcceso())
                            {
                                Comprobante();
                                Asiento();
                                objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                                bool res = fe.F1CAESolicitar();

                                if (res == true && fe.F1RespuestaCantidadReg > 0)
                                {

                                    objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                    objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                    objEFactura.Codigo = objLFactura.AgregarDeVentaInicial(objEFactura, objEAsiento);
                                    GuardarPDF("DUPLICADO");

                                    Limpiar();
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
                        objEFactura.Codigo = objLFactura.AgregarDeVentaInicial(objEFactura, objEAsiento);
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

        private void Limpiar()
        {
            txtCodigoVendedor.Text = "";
            txtCodigoCliente.Text = "";
            cbDescontarSobrePrecioDeFacturacion.Checked = false;
            cbDevolucionEfectivo.Checked = false;
            ObtenerComprobantes();
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
            dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta);

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
            for (int i = 0; i <= filas; i++)
            {
                dtFacturaDetalle.Rows.Add(i);
            }*/

            lista.Add(dtEmpresa);
            lista.Add(dtEncabezado);
            lista.Add(dtFactura);
            lista.Add(dtFacturaDetalle);

            frmInformes informe = new frmInformes("NOTA DE CREDITO", lista, "repFacturas");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", tipo);
            string factura = objLFactura.ObtenerFacturaAfectada(objEFactura.Codigo);
            parametros[1] = new ReportParameter("Factura", factura);

            //informe.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { Tipo, Razon, Domicilio, Puesto, Domicilio2, Letra, Codigo, Tipo2, Numero, Fecha, CUITEmpresa, Ingresos, FechaInicio });
            informe.reportViewer1.LocalReport.SetParameters(parametros);

            informe.reportViewer1.RefreshReport();

            Utilidades.ControladorImpresion ci = new Utilidades.ControladorImpresion();
            ci.ExportarPDF(informe.reportViewer1, "(" + objEFactura.TipoDocumentoCliente.TipoDoc.Codigo + ") " + objEFactura.Numdoc);
            ci.Dispose();

            parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
            informe.reportViewer1.LocalReport.SetParameters(parametros);
            informe.reportViewer1.RefreshReport();

            if (Singleton.Instancia.Empresa.Fiscal)
            {
                if (objECliente.Original == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }

                if (objECliente.Duplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                    // parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }

                if (objECliente.Triplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "TRIPLICADO");
                    // parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
            }
            // ci.Imprimir(informe.reportViewer1.LocalReport);

            //   Utilidades.Formularios.AbrirFuera(informe);
        }

        private void Comprobante()
        {
            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
            objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            //objEFactura.Numdoc = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fac);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objEFactura.Cliente = objECliente;
            objEFactura.Vendedor = objEEmpleado;
            objEFactura.FacturaKilos = false;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            //objEFormaDePago = objLFormaDePago.ObtenerUno(1);
            Entidades.Factura_Efectivo facturaEfectivo;
            if (cbDevolucionEfectivo.Checked)
            {
                facturaEfectivo = new Entidades.Factura_Efectivo();
                facturaEfectivo.Moneda = new Logica.Moneda().ObtenerUno(1);
                facturaEfectivo.Importe = -Convert.ToDouble(Neto() + IVA());
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
                objEFactura.Neto105 = -Neto();
            }
            else
            {
                objEFactura.Neto105 = -Neto(10.5);
                objEFactura.Neto21 = -Neto(21);
                objEFactura.Iva105 = -IVA(10.5);
                objEFactura.Iva21 = -IVA(21);
            }
            //objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;
            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            int renglon = 1;
            objEFactura.Detalles.Clear();
            if (objEFacturaOriginal.FacturaKilos == false)
            {
                //objEFactura.FacturaKilos = false;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (!fila.Cells["CantidadDevuelta"].Value.Equals(""))
                    {
                        objEFacturaDetalle = new Entidades.Factura_Detalle();
                        objEFacturaDetalle.Renglon = renglon;
                        objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                        objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                        objEFacturaDetalle.MovStock_Lotes.Cantidad = -Convert.ToInt32(fila.Cells["CantidadDevuelta"].Value);
                        objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                        objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonFactura"].Value);
                        objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                        /* if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('L'))
                         {
                             if (cbDescontarSobrePrecioDeFacturacion.Checked)
                                 objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioFacturado"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                             else
                                 objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioNC"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                             objEFacturaDetalle.Iva = 0;
                         }
                         else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                         {*/

                        if (cbDescontarSobrePrecioDeFacturacion.Checked)
                            objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PrecioFacturado"].Value);
                        else
                            objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PrecioNC"].Value);
                        objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Ivas"].Value);
                        //   }
                        objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                        renglon += 1;
                        objEFactura.Detalles.Add(objEFacturaDetalle);
                    }
                }
            }
            else
            {
                // objEFactura.FacturaKilos = true;
                foreach (DataGridViewRow fila in dgvDatos2.Rows)
                {
                    if (!fila.Cells["CantidadDevuelta2"].Value.Equals(""))
                    {
                        objEFacturaDetalle = new Entidades.Factura_Detalle();
                        objEFacturaDetalle.Renglon = renglon;
                        objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo2"].Value);
                        objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción2"].Value.ToString();
                        objEFacturaDetalle.Kilos = Convert.ToInt32(fila.Cells["Kilos"].Value);
                        objEFacturaDetalle.MovStock_Lotes.Cantidad = -Convert.ToInt32(fila.Cells["CantidadDevuelta2"].Value);
                        objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA2"].Value);
                        objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonFactura2"].Value);
                        objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                        /* if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('L'))
                         {
                             if (cbDescontarSobrePrecioDeFacturacion.Checked)
                                 objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioFacturado2"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                             else
                                 objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioNC2"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                             objEFacturaDetalle.Iva = 0;
                         }
                         else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                         {*/
                        if (cbDescontarSobrePrecioDeFacturacion.Checked)
                            objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PrecioFacturado2"].Value);
                        else
                            objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PrecioNC2"].Value);

                        objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva2"].Value);
                        //    }
                        objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote2"].Value);
                        renglon += 1;
                        objEFactura.Detalles.Add(objEFacturaDetalle);
                    }
                }
            }

            /*
            try
            {

                listaAsientosTemporales = new List<Entidades.AsientoTemp>();
                Entidades.AsientoTemp asientoTemp;
                if (cbDevolucionEfectivo.Checked)
                {
                    asientoTemp = new Entidades.AsientoTemp();
                    asientoTemp.Fecha = objEFactura.Fecha;
                    objEFormaDePago = objLFormaDePago.ObtenerUno(1);
                    asientoTemp.CuentaContable = objEFormaDePago.CuentaContable;
                    asientoTemp.Debe = 0;
                    asientoTemp.Haber = Neto() + IVA();
                    asientoTemp.Tipo = 3;
                    listaAsientosTemporales.Add(asientoTemp);
                }
                else {
                    asientoTemp = new Entidades.AsientoTemp();
                    asientoTemp.Fecha = objEFactura.Fecha;
                    objEFormaDePago = objLFormaDePago.ObtenerUno(2);
                    asientoTemp.CuentaContable = objEFormaDePago.CuentaContable;
                    asientoTemp.Debe = 0;
                    asientoTemp.Haber = Neto() + IVA();
                    asientoTemp.Tipo = 3;
                    listaAsientosTemporales.Add(asientoTemp);
                }
    



                
                asientoTemp = new Entidades.AsientoTemp();
                asientoTemp.Fecha = objEFactura.Fecha;
                asientoTemp.CuentaContable = Singleton.Instancia.Empresa.CuentaContableVentaSucursal;
                asientoTemp.Debe = Neto();
                asientoTemp.Haber = 0;
                asientoTemp.Tipo = 3;
                listaAsientosTemporales.Add(asientoTemp);

                asientoTemp = new Entidades.AsientoTemp();
                asientoTemp.Fecha = objEFactura.Fecha;
                asientoTemp.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
                asientoTemp.Debe = IVA();
                asientoTemp.Haber = 0;
                asientoTemp.Tipo = 3;
                listaAsientosTemporales.Add(asientoTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    */
        }

        private void Asiento()
        {
            /*try
            {*/
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Descripcion = "Nota de Crédito N° " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;
            if (cbDevolucionEfectivo.Checked)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Neto() + IVA();
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            else
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(2);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Neto() + IVA();
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableDebolucionMercaderiaSucursal;
            asientoDetalle.Debe = Neto();
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
            asientoDetalle.Debe = IVA();
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);
            /*}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
        }


        private double Neto(double valor)
        {
            double neto = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["DescuentoTotal2"].Value);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["DescuentoTotal"].Value);
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double IVA(double valor)
        {
            double iva = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        if (!dgr.Cells["Iva2"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Iva2"].Value);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        if (!dgr.Cells["Ivas"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
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
            if (Utilidades.Validar.GrillaVacia(dgvDatos2) && dgvDatos2.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            double total = Neto() + IVA();
            if (total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        private void cbDescontarSobrePrecioDeFacturacion_CheckedChanged(object sender, EventArgs e)
        {
            double precioUnitario;

            if (dgvDatos.Visible == true)
            {
                foreach (DataGridViewRow dgv in dgvDatos.Rows)
                {
                    if (cbDescontarSobrePrecioDeFacturacion.Checked)
                    {
                        precioUnitario = Convert.ToDouble(dgv.Cells["PrecioFacturado"].Value);
                    }
                    else
                    {
                        precioUnitario = Convert.ToDouble(dgv.Cells["PrecioNC"].Value);
                    }
                    double porcIVA = Convert.ToDouble(dgv.Cells["PorcIVA"].Value);
                    if (!dgv.Cells["CantidadDevuelta"].Value.Equals(""))
                    {
                        int cantDevuelta = Convert.ToInt32(dgv.Cells["CantidadDevuelta"].Value);
                        dgv.Cells["DescuentoTotal"].Value = cantDevuelta * precioUnitario;
                        dgv.Cells["Ivas"].Value = Utilidades.Redondear.CuatroDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cantDevuelta);
                    }

                }

            }
            else
            {
                foreach (DataGridViewRow dgv in dgvDatos2.Rows)
                {
                    if (cbDescontarSobrePrecioDeFacturacion.Checked)
                    {
                        precioUnitario = Convert.ToDouble(dgv.Cells["PrecioFacturado2"].Value);
                    }
                    else
                    {
                        precioUnitario = Convert.ToDouble(dgv.Cells["PrecioNC2"].Value);
                    }
                    double porcIVA = Convert.ToDouble(dgv.Cells["PorcIVA2"].Value);
                    if (!dgv.Cells["CantidadDevuelta2"].Value.Equals(""))
                    {
                        int cantDevuelta = Convert.ToInt32(dgv.Cells["CantidadDevuelta2"].Value);
                        dgv.Cells["DescuentoTotal2"].Value = cantDevuelta * precioUnitario;
                        dgv.Cells["Iva2"].Value = Utilidades.Redondear.CuatroDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cantDevuelta);
                    }

                }
            }

            Calcular();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoVendedor.Focus();
        }

        private void dgvDatos2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDatos2.Rows[e.RowIndex].Cells["CantidadDevuelta2"].Value) <= Convert.ToInt32(dgvDatos2.Rows[e.RowIndex].Cells["Cantidad2"].Value))
            {
                double precioUnitario;
                if (cbDescontarSobrePrecioDeFacturacion.Checked)
                    precioUnitario = Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["PrecioFacturado2"].Value);
                else
                    precioUnitario = Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["PrecioNC2"].Value);

                double porcIVA = Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["PorcIVA2"].Value);
                int cantDevuelta = Convert.ToInt32(dgvDatos2.Rows[e.RowIndex].Cells["CantidadDevuelta2"].Value);
                dgvDatos2.Rows[e.RowIndex].Cells["DescuentoTotal2"].Value = cantDevuelta * precioUnitario;
                dgvDatos2.Rows[e.RowIndex].Cells["Iva2"].Value = Utilidades.Redondear.CuatroDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cantDevuelta);

                if (cantDevuelta == 0)
                {
                    dgvDatos2.Rows[e.RowIndex].Cells["CantidadDevuelta2"].Value = "";
                }
            }
            else
            {
                MessageBox.Show("Cantidad incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos2.Rows[e.RowIndex].Cells["CantidadDevuelta2"].Value = "";
                dgvDatos2.Rows[e.RowIndex].Cells["DescuentoTotal2"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["Iva2"].Value = "";
            }
            Calcular();
        }
    }
}
