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
    public partial class frmNDChequesRechazados : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Cheque objLCheque = new Logica.Cheque();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Logica.Factura objLFactura = new Logica.Factura();

        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Cheque objCheque = new Entidades.Cheque();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
        public frmNDChequesRechazados()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }
        private void Titulo()
        {
            this.Text = "NOTAS DE DEBITO CHEQUES RECHAZADOS";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);

            // dgvDatos.MultiSelect = true;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;

            lblTotal.Text = 0.ToString("C2");
            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Banco"].Width = 150;
        }
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtGastos, 8);
            Utilidades.CajaDeTexto.LimiteTamaño(txtMotivo, 150);
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("NDCheque", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("NDCheque", this));
                    break;
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
                        //ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                        dgvDatos.DataSource = null;
                        /* cbComprobante.DataSource = null;
                         dgvDatos.Rows.Clear();
                         dgvDatos2.Rows.Clear();*/
                        Calcular();
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                    dgvDatos.DataSource = null;
                    /* cbComprobante.DataSource = null;
                     dgvDatos.Rows.Clear();
                     dgvDatos2.Rows.Clear();*/
                    Calcular();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double Calcular()
        {
            double sum = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionado"].Value))
                {
                    sum += Convert.ToDouble(item.Cells["Importe"].Value);
                }
            }
            //lblTotal.Text = sum.ToString("C2");
            lblTotal.Text = (sum + Gastos() + IVA()).ToString("C2");
            return sum;
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

        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = false;//true;
            objETipoDocumentoCliente.TipoDoc.Codigo = "ND";
            objETipoDocumentoCliente.AfectaStock = "NA";
            FormasDePago();
        }

        private void FormasDePago()
        {
            objETipoDocumentoCliente.AfectaCaja = 'N';
            objETipoDocumentoCliente.AfectaCtaCte = 'D';
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objECliente != null)
                    dgvDatos.DataSource = objLCheque.ObtenerDeClientes(objECliente);
                else
                    dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
            }
            Calcular();
        }
        private int SumarCantidad()
        {
            int cantidad = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionado"].Value))
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        private void txtGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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

                                objEFactura.Codigo = objLFactura.AgregarChequesRechazados(objEFactura, txtMotivo.Text.Trim(), objEAsiento);
                                GuardarPDF("DUPLICADO");

                                Limpiar();
                            }
                            else
                            {
                                MessageBox.Show("Error: " + fe.f1ErrorMsg1 + " " + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                                    objEFactura.Codigo = objLFactura.AgregarChequesRechazados(objEFactura, txtMotivo.Text.Trim(), objEAsiento);
                                    GuardarPDF("DUPLICADO");

                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("Error: " + fe.f1ErrorMsg1 + " " + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //for (int i = 0; i < fe.F1RespuestaDetalleObservacionItemCantidad; i++)
                                    //{
                                    //    fe.f1IndiceItem = i;

                                    //    MessageBox.Show(fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //}
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
                        objEFactura.Codigo = objLFactura.AgregarChequesRechazados(objEFactura, txtMotivo.Text.Trim(), objEAsiento);
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

            /* int renglones = 0;
             foreach (DataRowView item in dtFacturaDetalle.Rows)
             {
                 MessageBox.Show((item["Producto"].ToString().Length / 35).ToString());
             }*/
            /*
            int filas = 15 - dtFacturaDetalle.Rows.Count;
            for (int i = 0; i <= filas; i++)
            {
                dtFacturaDetalle.Rows.Add("a");
            }*/

            lista.Add(dtEmpresa);
            lista.Add(dtEncabezado);
            lista.Add(dtFactura);
            lista.Add(dtFacturaDetalle);

            frmInformes informe = new frmInformes("NOTA DE DEBITO", lista, "repFacturas");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", tipo);
            //VER
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
                    // parametros[1] = new ReportParameter("Factura", "");
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
                    //  parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
            }


            //  ci.Imprimir(informe.reportViewer1.LocalReport);

            //   Utilidades.Formularios.AbrirFuera(informe);
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
                MessageBox.Show("El Comprobante no contiene Cheques Rechazados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            double total = NetoNoGrabado() + Gastos() + IVA();
            if (total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }
        private double NetoNoGrabado()
        {
            double neto = Calcular();
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Gastos()
        {
            double gas = txtGastos.Text.Equals("") ? 0 : Convert.ToDouble(txtGastos.Text);
            return Utilidades.Redondear.DosDecimales(gas);
        }

        private double IVA()
        {
            double iva = 0;
            iva = Gastos() * 0.21;
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private void Limpiar()
        {
            txtCodigoVendedor.Text = "";
            txtCodigoCliente.Text = "";
            txtGastos.Text = "";
            txtMotivo.Text = "";
        }
        private void lblNombreVendedor_Click(object sender, EventArgs e)
        {

        }

        private void frmNDChequesRechazados_Load(object sender, EventArgs e)
        {
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

        private void Comprobante()
        {
            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
          //  objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
          //  objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
           // objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objEFactura.Cliente = objECliente;
            Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
            sc.CodigoSucursal = 1;
            objEFactura.SucursalCliente = sc;
            objEFactura.Vendedor = objEEmpleado;
            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2020");
            //objEFactura.FacturaKilos = false;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            //objEFormaDePago = objLFormaDePago.ObtenerUno(1);

            if (objETipoDocumentoCliente.AfectaCtaCte.Equals('N'))
            {
                objEFactura.Imputacion = 'T';
            }
            else
            {
                objEFactura.Imputacion = 'F';
            }

            objEFactura.NetoNoGravado = NetoNoGrabado();
            //objEFactura.Neto105 = 0;
            objEFactura.Neto21 = Gastos();
            //objEFactura.Iva105 = 0;
            objEFactura.Iva21 = IVA();
            //objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;

            objEFactura.Cheques.Clear();
            objEFactura.FacturaKilos = false;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value))
                {
                    objCheque = new Entidades.Cheque();
                    objCheque.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objCheque.Importe = Convert.ToDouble(fila.Cells["Importe"].Value);
                    //objCheque.EstadoValor.Codigo = "RE";
                    objEFactura.Cheques.Add(objCheque);
                }
            }

        }

        private void Asiento()
        {
            /*try
            {*/
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Descripcion = "Nota de Débito N° " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            objEFormaDePago = objLFormaDePago.ObtenerUno(2);
            asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
            asientoDetalle.Debe = NetoNoGrabado() + Gastos() + IVA();
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            foreach (Entidades.Cheque che in objEFactura.Cheques)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105140000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = che.Importe;
                asientoDetalle.Cheque.Codigo = che.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }





            if (Gastos() > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 50103010102;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Gastos();
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            if (IVA() > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = IVA();
                objEAsiento.Detalle.Add(asientoDetalle);
            }

        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGastos_TextChanged(object sender, EventArgs e)
        {
            txtIVA.Text = IVA().ToString("C2");
            Calcular();
        }
    }
}
