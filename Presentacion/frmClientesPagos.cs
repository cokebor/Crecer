using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Entidades;

namespace Presentacion
{
    public partial class frmClientesPagos : Presentacion.frmColor
    {
        Entidades.PagoCliente objEPago = new Entidades.PagoCliente();
        Entidades.Cliente objECliente;
        Entidades.TipoDocumentoCliente objETipoDocCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();
        DataView dvComprobantes = new DataView();

        Entidades.FormaDePago objEFormaDePago;

        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        
        Logica.PagoCliente objLPagoCliente = new Logica.PagoCliente();
        Logica.TipoDocumentoCliente objLTipoDocCliente = new Logica.TipoDocumentoCliente();

        Logica.Cliente objLCliente = new Logica.Cliente();
        PagoClientesCalculos objValores = new PagoClientesCalculos();
        Logica.Factura objFactura = new Logica.Factura();


        public frmClientesPagos()
        {
            InitializeComponent();
            ucFormasPagoVentas.FormularioInicial = this;
            ConfiguracionInicial();

        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
            objECliente = new Entidades.Cliente();
            ucFormasPagoVentas.Cliente = objECliente;
            ucFormasPagoVentas.FormularioInicial = this;


            this.ucFormasPagoVentas.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoVentas.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPagoVentas.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoVentas.ucCheque.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoVentas.ucDebitoCredito.btnAgregar.Click += ActualizarValores;

            this.ucFormasPagoVentas.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoVentas.btnEliminar.Click += ActualizarValores;
            /*
            this.dtFecha.ValueChanged += ActualizarValores;
            */
        }

        private void Titulo()
        {
            this.Text = "PAGO DE CLIENTES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbRecibos);
            Utilidades.TabControl.Formato(tcPagosClientes, frmColor.Color);
            tcPagosClientes.TabPages.Remove(tpFormasDePago);
            tcPagosClientes.TabPages.Remove(tpImputacion);
            tcPagosClientes.TabPages.Remove(tpImpuestos);

            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDatos.Columns["Seleccionado"].ReadOnly = false;

            dgvDatos.Columns["Seleccionado"].Width = 25;
            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["Tipo"].Width = 30;
            dgvDatos.Columns["Numero"].Width = 90;
            dgvDatos.Columns["Total2"].Width = 81;
            dgvDatos.Columns["Imputado"].Width = 81;
            dgvDatos.Columns["Pendiente"].Width = 81;
            dgvDatos.Columns["AAplicar"].Width = 80;
            dgvDatos.Columns["AAplicar"].ReadOnly = false;

            FormatoValores();
        }

        private void FormatoValores()
        {
            lblTotal.Text = Convert.ToDouble(0).ToString("C2");
            lblValores.Text = Convert.ToDouble(0).ToString("C2");
            lblValorImpuesto.Text = Convert.ToDouble(0).ToString("C2");
            lblDisponible.Text = Convert.ToDouble("0").ToString("C2");
            lblAplicado.Text = Convert.ToDouble("0").ToString("C2");
            // lblRetencionesIVA.Text = Convert.ToDouble("0").ToString("C2");
            //  lblRetencionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 150);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void ActualizarValores(object sender, EventArgs e)
        {
            try
            {
                objValores.Valores = ucFormasPagoVentas.valores;
                //objValores.Total = objValores.Valores;
                MostrarValores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("PagosClientes", this));
                    break;
                case (char)Keys.F7:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmImpuestoBuscar("PagosClientes", this));
                    break;
            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbChequeRechazado.Checked = false;
                cbTodosLosRecibos.Checked = false;
                ucFormasPagoVentas.Limpiar();
                cbRecibos.DataSource = null;
                CargarValoresImputacion();
                tcPagosClientes.TabPages.Remove(tpFormasDePago);
                tcPagosClientes.TabPages.Remove(tpImputacion);
                tcPagosClientes.TabPages.Remove(tpImpuestos);

                if (cbTipoComprobante.SelectedIndex != -1)
                {
                    objETipoDocCliente = objLTipoDocCliente.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                    ucFormasPagoVentas.TipoDoc = objETipoDocCliente.TipoDoc.Codigo;
                    ucFormasPagoVentas.CargarValores();
                    if (objETipoDocCliente.TipoDoc.Codigo.Equals("RC"))
                    {
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                        tcPagosClientes.TabPages.Add(tpFormasDePago);
                        tcPagosClientes.TabPages.Add(tpImpuestos);
                        tcPagosClientes.TabPages.Add(tpImputacion);
                        cbTodosLosRecibos.Visible = false;
                        cbChequeRechazado.Visible = false;
                        ucFormasPagoVentas.CodigoRecibo = 0;
                    }
                    else
                    {
                        lblRecibo.Visible = true;
                        cbRecibos.Visible = true;
                        tcPagosClientes.TabPages.Add(tpFormasDePago);
                        tcPagosClientes.TabPages.Add(tpImpuestos);
                        tcPagosClientes.TabPages.Remove(tpImputacion);
                        
                        cbTodosLosRecibos.Visible = true;
                        cbChequeRechazado.Visible = true;
                        if (cbTodosLosRecibos.Checked)
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoCliente.ObtenerPagosPorCliente(objECliente.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                        }
                        else
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoCliente.ObtenerPagosPorCliente(objECliente.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                        }
                        ucFormasPagoVentas.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                    }
                }
                //FormasPagoVentas.ObtenerDatos();
                objValores.Valores = ucFormasPagoVentas.valores;
                MostrarValores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbTodosLosRecibos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTodosLosRecibos.Checked)
                {
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoCliente.ObtenerPagosPorCliente(objECliente.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                }
                else
                {
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoCliente.ObtenerPagosPorCliente(objECliente.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dvComprobantes = null;
                objECliente = new Entidades.Cliente();
                lblNombreCliente.Text = "";
                ucFormasPagoVentas.Cliente = objECliente;
                Limpiar();
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    objValores.Cliente = objECliente;
                    if (objECliente != null)
                    {
                        lblNombreCliente.Text = objECliente.Nombre;
                        ucFormasPagoVentas.Cliente = objECliente;
                        CargarValoresImputacion();
                    }
                }
                ObtenerTipoComprobante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ObtenerTipoComprobante()
        {
            if (objECliente != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCliente.ObtenerTodosDeTipoPagos(objECliente.TipoInscripcion.Codigo), "Codigo", "Descripcion");
            }
            else
            {
                cbRecibos.DataSource = null;
                cbTipoComprobante.DataSource = null;
            }
        }

        private void MostrarValores()
        {
            try
            {
                
                //    lblRetencionesGanancias.Text = objValores.RetencionesGanancias(dgvDatos).ToString("C2");
                //    lblRetencionesIVA.Text = objValores.RetencionesIva(dgvDatos).ToString("C2");
                //    lblRetencionMunicipal.Text = objValores.RetencionesMunicipales.ToString("C2");
                lblAplicado.Text = objValores.Aplicado(dgvDatos).ToString("C2");
                lblDisponible.Text = objValores.Disponible(dgvDatos).ToString("C2");
                lblValores.Text = objValores.Valores.ToString("C2");
                lblValorImpuesto.Text = objValores.Impuestos.ToString("C2");
                //  lblValoresPendientes.Text = objValores.ValoresPendientes.ToString("C2");
                lblTotal.Text = objValores.Total().ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Limpiar()
        {

            tcPagosClientes.TabPages.Remove(tpFormasDePago);
            tcPagosClientes.TabPages.Remove(tpImpuestos);
            tcPagosClientes.TabPages.Remove(tpImputacion);
            
            cbTodosLosRecibos.Checked = false;
            cbChequeRechazado.Checked = false;
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            txtObservaciones.Text = "";
            ucFormasPagoVentas.Limpiar();
            ucFormasPagoVentas.ObtenerDatos();
            dgvDatos.DataSource = null;
            objValores.Impuestos = 0;
            objValores.Valores = 0;
            objEPago = new Entidades.PagoCliente();
            dgvImpuestos.Rows.Clear();
            ////objEFacturaDetalle = new Entidades.Factura_Detalle();
            objEAsiento = new Entidades.Asiento();
            ////FormatoValores();
            MostrarValores();
        }
        
        private void CargarValoresImputacion()
        {
            if (objECliente != null) { 
                //dgvDatos.DataSource = objFactura.ObtenerFacturasParaImputar(objECliente);
                dvComprobantes =objFactura.ObtenerFacturasParaImputar(objECliente).DefaultView;
                dvComprobantes.RowFilter = "Saldo<>0";
                /* else
                     dgvDatos.DataSource = null;
                */
                dgvDatos.DataSource = dvComprobantes;
            }
        }

        
        private void cbRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRecibos.SelectedValue != null && Convert.ToInt32(cbRecibos.SelectedValue) != 1)
                {
                    ucFormasPagoVentas.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                    objValores.Efectivo = Math.Abs(Convert.ToDouble(objLPagoCliente.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Efectivo"]));
                    objValores.Dolares = Math.Abs(Convert.ToDouble(objLPagoCliente.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Dolares"]));
                    objValores.Tranferencia= Math.Abs(Convert.ToDouble(objLPagoCliente.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Dolares"]));
                }
                else
                {
                    objValores.Efectivo = 0;
                    objValores.Dolares = 0;
                }
                ucFormasPagoVentas.Efectivo = objValores.Efectivo;
                ucFormasPagoVentas.Dolares = objValores.Dolares;
                ucFormasPagoVentas.Tranferencia = objValores.Tranferencia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }



        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreCliente);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante);
            return res;
        }

          private bool ValidarFechaConciliacionCuenta(Entidades.CuentaBancaria pCuentaBancaria)
          {
        if (dtFecha.Value.Date <= pCuentaBancaria.FechaConciliacion)
            return false;
        else
            return true;
          }

        private bool ValidarFechaConciliacionCuentaCheques(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Cheque pCheque)
        {
            if (pCheque.FechaPago <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime Fecha;
            Fecha = dtFecha.Value.Date;
            if (ValidarComprobante().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoCliente.Focus();
                return;
            }
            //if (objValores.ValoresPendientes != 0)
            //{
            //    MessageBox.Show("No pueden quedar Valores Pendientes", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (objValores.Total() == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CargarValoresPago();
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC") && (objEPago.FacturasImputacion.Count == 0 || objValores.Disponible(dgvDatos ) != 0))
                {
                    if (MessageBox.Show("Comprobante con Saldo sin Imputar.\n¿Desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                DateTime fechaMax = Convert.ToDateTime(Fecha.Year + "-" + Fecha.Month + "-" + DateTime.DaysInMonth(Fecha.Year, Fecha.Month));


                if (fechaMax < DateTime.Now.Date)
                {
                    if (MessageBox.Show("Esta cargando un Pago de un mes ya cerrado.\n ¿Esta Seguro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (objEPago.Tranferencias.Count > 0)
                    {
                        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                        foreach (Entidades.Tranferencia item in objEPago.Tranferencias)
                        {
                            objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                            if (ValidarFechaConciliacionCuenta(objECuentaBancaria).Equals(false))
                            {
                                MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    if (objEPago.ChequesPropios.Count > 0)
                    {
                        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                        foreach (Entidades.Cheque item in objEPago.ChequesPropios)
                        {
                            objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                            if (ValidarFechaConciliacionCuentaCheques(objECuentaBancaria, item).Equals(false))
                            {
                                MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }



                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                }
                CargarAsiento();
                int codigoRecibo;
                //if (cbRecibos.Visible)
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                        codigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                else
                    codigoRecibo = 0;
                int codigo = objLPagoCliente.Agregar(objEPago, objEAsiento, codigoRecibo);
                txtCodigoCliente.Text = "";
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //     Informe(codigo);
            //    InformePagos(Logica.Informes.PagosProveedores(codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformePagos(List<DataTable> lista)
        {

            //Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
        }
        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEPago.Fecha;
            objEAsiento.FechaEmision = objEPago.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = "Segun " + objEPago.TipoDocumentoCliente.Descripcion + " de Pago N° " + objEPago.Numdoc + " de " + lblNombreCliente.Text;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            //asientoDetalle = new Entidades.Asiento_Detalle();
            //if (cbLiquidaciones.Checked)
            //    asientoDetalle.CuentaContable.Codigo = 20101020000;
            //else
            //    asientoDetalle.CuentaContable.Codigo = 20101010000;

            //if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            //{
            //    asientoDetalle.Debe = Convert.ToDouble(objEPago.Total);
            //    asientoDetalle.Haber = 0;
            //}
            //else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
            //{
            //    asientoDetalle.Debe = 0;
            //    asientoDetalle.Haber = Convert.ToDouble(objEPago.Total);
            //}
            //objEAsiento.Detalle.Add(asientoDetalle);


            foreach (Entidades.Factura_Efectivo fe in objEPago.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(1);
                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                else
                {
                    Int64 cuenta = 0;
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


                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = fe.Importe * fe.Moneda.Cotizacion;// - valor;
                    asientoDetalle.Haber = 0;
                }
                else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = -fe.Importe * fe.Moneda.Cotizacion;// + valor;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }



            foreach (Entidades.Cheque che in objEPago.Cheques)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(3);
                //    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                if (objEPago.ChequeRechazado)
                {
                    asientoDetalle.CuentaContable.Codigo = 10105140000;
                }
                else
                {
                    asientoDetalle.CuentaContable.Codigo = che.CuentaBancaria.CuentaContable.Codigo;
                }
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                {

                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                asientoDetalle.Cheque.Codigo = che.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Tranferencia tran in objEPago.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = tran.Importe * tran.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = -tran.Importe * tran.Moneda.Cotizacion;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.CreditoDebito cd in objEPago.CreditosDebitos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = cd.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = cd.Importe * cd.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = -cd.Importe * cd.Moneda.Cotizacion;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.FacturaImpuesto fi in objEPago.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = fi.Impuesto.CuentaContable;
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = System.Math.Abs(fi.Importe);
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = System.Math.Abs(fi.Importe);
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = Singleton.Instancia.Empresa.CuentaContableCuentaCorrienteClientes.Codigo;


            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Convert.ToDouble(objEPago.Total);
            }
            else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
            {
                asientoDetalle.Debe = -Convert.ToDouble(objEPago.Total);
                asientoDetalle.Haber = 0;
            }
            objEAsiento.Detalle.Add(asientoDetalle);
        }
        public List<Entidades.FacturaImputacion> ObtenerImputacion()
        {
        List<Entidades.FacturaImputacion> facturas = new List<Entidades.FacturaImputacion>();
        foreach (DataGridViewRow fila in dgvDatos.Rows)
        {
            Entidades.FacturaImputacion factura;
            if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
            {
                factura = new Entidades.FacturaImputacion();

                factura.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                factura.TipoDocumentoCliente.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoCliente"].Value);
                factura.Monto = Convert.ToDouble(fila.Cells["AAplicar"].Value);
                factura.CodigoImputacion = Convert.ToChar(fila.Cells["CodigoImputacion"].Value);
                factura.ImputacionAnterior = Convert.ToDouble(fila.Cells["Imputado"].Value);
                facturas.Add(factura);

            }

            }
        return facturas;
        }

        public List<Entidades.FacturaImpuesto> ObtenerImpuestos()
        {
            List<Entidades.FacturaImpuesto> lista=new List<FacturaImpuesto>();
            foreach (DataGridViewRow imp in dgvImpuestos.Rows)
            {
                Entidades.FacturaImpuesto fi = new Entidades.FacturaImpuesto();
                fi.Impuesto.Codigo = Convert.ToInt32(imp.Cells["CodigoImpuesto"].Value);
                fi.Impuesto.CuentaContable.Codigo = Convert.ToInt64(imp.Cells["CuentaContable"].Value);
                fi.Impuesto.Fecha = Convert.ToDateTime(imp.Cells["FechaImpuesto"].Value);
                fi.Impuesto.Nroagente = Convert.ToInt64(imp.Cells["NroAgente"].Value);
                fi.Impuesto.NroComprobante = Convert.ToInt32(imp.Cells["NroComprobante"].Value);
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                    fi.Importe = Convert.ToDouble(imp.Cells["Importe"].Value);
                else
                    fi.Importe = -Convert.ToDouble(imp.Cells["Importe"].Value);
                lista.Add(fi);
            }
            return lista;
        }

        private void CargarValoresPago()
        {

            objEPago = new Entidades.PagoCliente();
            objEPago.TipoDocumentoCliente = objLTipoDocCliente.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
            //objEPago.TipoDocumentoCliente.Numerador = new Logica.Numerador().ObtenerUno(objEPago.TipoDocumentoCliente.Numerador.Codigo);
            objEPago.Letra= Convert.ToChar(objEPago.TipoDocumentoCliente.Numerador.Letra);
            objEPago.PuntoDeVenta = objEPago.TipoDocumentoCliente.Numerador.PuntoVenta;
            objEPago.Numero = objEPago.TipoDocumentoCliente.Numerador.Numero;
            
            objEPago.Cliente.Codigo = Convert.ToInt32(txtCodigoCliente.Text.Trim());
            objEPago.Cliente.Nombre = lblNombreCliente.Text.Trim();
            objEPago.Fecha = dtFecha.Value;
        
            objEPago.Usuario = Singleton.Instancia.Usuario;
            objEPago.PuestoCaja = Singleton.Instancia.Puesto;
            objEPago.Observaciones = txtObservaciones.Text.Trim();
            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                objEPago.Total = objValores.Total();
            else
            {
                objEPago.Total = -objValores.Total();
                objEPago.ChequeRechazado = cbChequeRechazado.Checked;
            }

            ucFormasPagoVentas.ObtenerDatos();

            objEPago.FacturaEfectivo.Clear();
            objEPago.FacturaEfectivo = ucFormasPagoVentas.Efectivos;
            objEPago.Cheques.Clear();
            objEPago.Cheques = ucFormasPagoVentas.Cheques;
            //objEPago.ChequesPropios.Clear();
            //objEPago.ChequesPropios = ucFormasPagoVentas.ChequesPropios;
            objEPago.Tranferencias.Clear();
            objEPago.Tranferencias = ucFormasPagoVentas.Tranferencias;
            objEPago.CreditosDebitos.Clear();
            objEPago.CreditosDebitos = ucFormasPagoVentas.CreditosDebitos;

            objEPago.FacturasImputacion.Clear();
            objEPago.FacturasImputacion = ObtenerImputacion();
            objEPago.Impuestos.Clear();
            objEPago.Impuestos = ObtenerImpuestos();

            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            {
                if(objValores.Disponible(dgvDatos)==0)
                    objEPago.Imputacion = 'T';
                else
                    objEPago.Imputacion = 'F';
            }
            else
            {
                objEPago.Imputacion = 'F';
            }

        }
        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDatos.IsCurrentCellDirty)
            {
                dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void Cambio()
        {
            foreach (DataGridViewRow d in dgvDatos.Rows)
            {
                if (d.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    d.Cells["Seleccionado"].Value = false;
                }
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
                {

                    
                    DataGridViewCheckBoxCell d = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                    
                    if (Convert.ToBoolean(d.Value) == true)
                    {
                        if (objValores.Disponible(dgvDatos) >= Convert.ToDouble(dgvDatos["Pendiente", e.RowIndex].Value))
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = dgvDatos["Pendiente", e.RowIndex].Value;
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "T";
                            if (Convert.ToDouble(dgvDatos["AAplicar", e.RowIndex].Value) == 0)
                            {
                                dgvDatos["AAplicar", e.RowIndex].Value = "";
                                //d.Value = !(Convert.ToBoolean(d.Value));
                                dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"].Value = false;
                            }
                        }
                        else if (objValores.Disponible(dgvDatos) == 0)
                        {

                            d.Value = !(Convert.ToBoolean(d.Value));
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                            dgvDatos["AAplicar", e.RowIndex].Value = "";
                            MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = objValores.Disponible(dgvDatos);
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "P";

                        }



                    }
                    else
                    {
                        dgvDatos["AAplicar", e.RowIndex].Value = "";
                        dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                        d.Value = !Convert.ToBoolean(d.Value);
                    }
                  //  objValores.Total = objValores.Valores;

                }
                MostrarValores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }









        //private double CalculoTotal()
        //{
        //    double res = 0;
        //    try
        //    {
        //        foreach (DataGridViewRow item in dgvDatos.Rows)
        //        {
        //            if (Convert.ToBoolean(item.Cells["Seleccionado"].Value))
        //            {
        //                res += Convert.ToDouble(item.Cells["AAplicar"].Value);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    return res;
        //}

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += Validar_KeyPress;
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            //objValores.Total = CalculoTotal();
            objValores.Aplicado(dgvDatos);
            Cambio();
            MostrarValores();
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell d = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            if (Convert.ToBoolean(d.Value))
            {
                if (!this.dgvDatos.Rows[e.RowIndex].Cells["AAplicar"].Value.Equals(""))
                {
                    if (Convert.ToDouble(this.dgvDatos.Rows[e.RowIndex].Cells["AAplicar"].Value) > Convert.ToDouble(this.dgvDatos.Rows[e.RowIndex].Cells["Pendiente"].Value))
                    {
                        this.dgvDatos.Rows[e.RowIndex].Cells["AAplicar"].Value = "";
                        d.Value = !Convert.ToBoolean(d.Value);
                        MessageBox.Show("El Valor ingresado no puede ser mayor al Pendiente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Text = "";
            objECliente = new Cliente();
            Limpiar();
            MostrarValores();
        }

        
        private void txtCodigoImpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoImpuesto.Text.Trim().Equals(""))
                {
                    objEImpuesto = objLImpuesto.ObtenerUnoVentaActivo(Convert.ToInt32(txtCodigoImpuesto.Text.Trim()));
                    if (objEImpuesto != null)
                    {
                        lblImpuesto.Text = objEImpuesto.Descripcion;
                    }
                    else
                    {
                        objEImpuesto = new Entidades.Impuesto();
                        lblImpuesto.Text = "";
                        //cbTipoComprobante.DataSource = null;
                    }
                }
                else
                {
                    objEImpuesto = null;
                    lblImpuesto.Text = "";
                    //cbTipoComprobante.DataSource = null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigoImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtAgente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtAgente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtNroComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtNroComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblImpuesto);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            return res;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoImpuesto.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvImpuestos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CodigoImpuesto"].Value) == objEImpuesto.Codigo)
                {
                    MessageBox.Show("Impuesto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (txtAgente.Text.Trim().Equals(""))
                txtAgente.Text = "0";
            if (txtNroComprobante.Text.Trim().Equals(""))
                txtNroComprobante.Text = "0";

            dgvImpuestos.Rows.Add(objEImpuesto.Codigo, dtFechaRetencion.Value, objEImpuesto.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim())), objEImpuesto.CuentaContable.Codigo, Convert.ToInt64(txtAgente.Text.Trim()), Convert.ToInt32(txtNroComprobante.Text.Trim()));
            objValores.Impuestos += Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim()));

            //total1 += Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim()));
            txtCodigoImpuesto.Text = "";
            txtImporte.Text = "";
            txtNroComprobante.Text = "";
            txtAgente.Text = "";
            txtCodigoImpuesto.Focus();
            MostrarValores();
        }
    }

    internal class PagoClientesCalculos
    {
        public Cliente Cliente { get; set; }
        //public Empresa Empresa { get; set; }
        //public double Total { get; set; }
        public double Efectivo { get; set; }
        public double Dolares { get; set; }
        public double Tranferencia { get; set; }
        public double Valores { get; set; }

        public double Impuestos { get; set; }

        public double Total() {
            return Utilidades.Redondear.DosDecimales(Valores +Impuestos);
        }

        public double Disponible(DataGridView dg)
        {
            return Utilidades.Redondear.DosDecimales(Total() - Aplicado(dg));
        }


        //List<TipoDocumentoProveedor> tiposG = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('G');


        //List<TipoDocumentoProveedor> tiposI = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('I');




        public double Aplicado(DataGridView dgvDatos)
        {
            double res = 0;
                foreach (DataGridViewRow dgv in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                        if (!(dgv.Cells["AAplicar"].Value == null) && !dgv.Cells["AAplicar"].Value.Equals(""))
                            res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["AAplicar"].Value));

                }
                return res;
        }
    }
}
