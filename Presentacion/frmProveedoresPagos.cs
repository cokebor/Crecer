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
    public partial class frmProveedoresPagos : Presentacion.frmColor
    {
        Entidades.Pago objEPago = new Entidades.Pago();
        Entidades.Proveedor objEProveedor;
        Entidades.TipoDocumentoProveedor objETipoDocProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago;

        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Pago objLPagoProveedor = new Logica.Pago();
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.FacturaCompra objFC = new Logica.FacturaCompra();
        Logica.TipoDocumentoProveedor objLTipoDocProveedor = new Logica.TipoDocumentoProveedor();

        //List<TipoDocumentoProveedor> tiposG;
        //List<TipoDocumentoProveedor> tiposI;

        PagoProveedoresCalculos objValores = new PagoProveedoresCalculos();

        public frmProveedoresPagos()
        {
            InitializeComponent();
            ucFormasPagoCompras.FormularioInicial = this;
            ConfiguracionInicial();

        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
            objEProveedor = new Entidades.Proveedor();
            ucFormasPagoCompras.Proveedor = objEProveedor;
            ucFormasPagoCompras.FormularioInicial = this;
            // CargarValores();

            this.ucFormasPagoCompras.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucDebitoCredito.btnAgregar.Click += ActualizarValores;
            this.dtFecha.ValueChanged += ActualizarValores;
        }
        private void Titulo()
        {
            this.Text = "PAGO A PROVEEDORES";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbRecibos);
            Utilidades.TabControl.Formato(tcPagosProveedores, frmColor.Color);
            tcPagosProveedores.TabPages.Remove(tpFormasDePago);
            tcPagosProveedores.TabPages.Remove(tpImputacion);

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
            lblRetencionesGanancias.Text = Convert.ToDouble(0).ToString("C2");
            lblDisponible.Text = Convert.ToDouble("0").ToString("C2");
            lblAplicado.Text = Convert.ToDouble("0").ToString("C2");
            lblRetencionesIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblRetencionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
        }
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 150);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }
        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void ActualizarValores(object sender, EventArgs e)
        {
            try
            {
                objValores.Valores = ucFormasPagoCompras.valores;
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
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("PagoProveedores", this));
                    break;
            }
        }
        private void cbImporte_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImporte.Checked)
            {
                txtImporte.Enabled = true;
                txtImporte.Focus();
            }
            else
            {
                txtImporte.Text = "";
                txtImporte.Enabled = false;
            }
            objValores.Total = 0;
            MostrarValores();
        }
        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbChequeRechazado.Checked = false;
                cbTodosLosRecibos.Checked = false;
                ucFormasPagoCompras.Limpiar();
                cbRecibos.DataSource = null;
                CargarValoresImputacion(cbLiquidaciones.Checked);
                tcPagosProveedores.TabPages.Remove(tpFormasDePago);
                tcPagosProveedores.TabPages.Remove(tpImputacion);

                if (cbTipoComprobante.SelectedIndex != -1)
                {
                    objETipoDocProveedor = objLTipoDocProveedor.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                    ucFormasPagoCompras.TipoDoc = objETipoDocProveedor.TipoDoc.Codigo;
                    ucFormasPagoCompras.CargarValores();
                    if (objETipoDocProveedor.TipoDoc.Codigo.Equals("RC"))
                    {
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                        tcPagosProveedores.TabPages.Add(tpFormasDePago);
                        tcPagosProveedores.TabPages.Add(tpImputacion);
                        cbTodosLosRecibos.Visible = false;
                        cbChequeRechazado.Visible = false;
                        ucFormasPagoCompras.CodigoRecibo = 0;
                    }
                    else
                    {
                        lblRecibo.Visible = true;
                        cbRecibos.Visible = true;
                        tcPagosProveedores.TabPages.Add(tpFormasDePago);
                        tcPagosProveedores.TabPages.Remove(tpImputacion);
                        cbTodosLosRecibos.Visible = true;
                        cbChequeRechazado.Visible = true;
                        if (cbTodosLosRecibos.Checked)
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                        }
                        else
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                        }
                        ucFormasPagoCompras.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                        // ucFormasPagoCompras.Efectivo = Efectivo;
                        //   ucFormasPagoCompras.Dolares = Dolares;
                    }
                }
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
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                }
                else
                {
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objEProveedor = new Entidades.Proveedor();
                lblNombreProveedor.Text = "";
                ucFormasPagoCompras.Proveedor = objEProveedor;
                Limpiar();
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEProveedor = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    objValores.Proveedor = objEProveedor;
                    if (objEProveedor != null)
                    {
                        lblNombreProveedor.Text = objEProveedor.Nombre;
                        ucFormasPagoCompras.Proveedor = objEProveedor;
                        if (objEProveedor.RiesgoFiscal)
                        {
                            objEProveedor.TipoContribuyente.PorcentajeRetencion = 2 * objEProveedor.TipoContribuyente.PorcentajeRetencion;
                        }
                        CargarValoresImputacion(cbLiquidaciones.Checked);
                        if (objEProveedor.CategoriaProveedor.Codigo != 1)
                        {
                            objEProveedor.CategoriaProveedor = new Logica.CategoriaProveedor().ObtenerUno(objEProveedor.CategoriaProveedor.Codigo);
                        }
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
            if (objEProveedor != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocProveedor.ObtenerTodosDeTipoPagos(objEProveedor.TipoInscripcion.Codigo), "Codigo", "Descripcion");
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
                lblTotal.Text = objValores.Total.ToString("C2");
                lblRetencionesGanancias.Text = objValores.RetencionesGanancias(dgvDatos).ToString("C2");

                double var = txtRetIVA.Text.Equals("") ? 0.0 : (txtRetIVA.Text.Trim().Substring(0, 1).Equals(".") ? Convert.ToDouble(0 + txtRetIVA.Text.Trim()) : Convert.ToDouble(txtRetIVA.Text));
                    
                lblRetencionesIVA.Text = objValores.RetencionesIva(txtRetIVA).ToString("C2");
                lblRetencionMunicipal.Text = objValores.RetencionesMunicipales.ToString("C2");
                lblAplicado.Text = objValores.Aplicado(dgvDatos).ToString("C2");
                lblDisponible.Text = objValores.Disponible(dgvDatos).ToString("C2");
                lblValores.Text = objValores.Valores.ToString("C2");
                lblValoresPendientes.Text = objValores.ValoresPendientes.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Limpiar()
        {

            tcPagosProveedores.TabPages.Remove(tpFormasDePago);
            tcPagosProveedores.TabPages.Remove(tpImputacion);
            cbLiquidaciones.Checked = false;
            cbTodosLosRecibos.Checked = false;
            cbChequeRechazado.Checked = false;
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            cbImporte.Checked = false;
            txtObservaciones.Text = "";
            txtRetIVA.Text = "0.00";
            ucFormasPagoCompras.Limpiar();
            ucFormasPagoCompras.ObtenerDatos();
            dgvDatos.Rows.Clear();
            objValores.Total = 0;
            objValores.Valores = 0;
            objEPago = new Entidades.Pago();
            //objEFacturaDetalle = new Entidades.Factura_Detalle();
            objEAsiento = new Entidades.Asiento();
            //FormatoValores();
            MostrarValores();
        }
        private void CargarValoresImputacion(bool liquidaciones)
        {
            DataTable dt = objFC.ObtenerFacturasSinImputar(objEProveedor, liquidaciones);
            dgvDatos.Rows.Clear();
            List<TipoDocumentoProveedor> tipos = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('G');
            tipos.AddRange(new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('I'));
            int indice = 0;
            Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor;// = new TipoDocumentoProveedor();
            foreach (DataRow dr in dt.Rows)
            {
                objETipoDocumentoProveedor = new TipoDocumentoProveedor();
                objETipoDocumentoProveedor.Codigo = Convert.ToInt32(dr["CodigoTipoDocumentoProveedor"]);
                indice = tipos.IndexOf(objETipoDocumentoProveedor);
                dgvDatos.Rows.Add(false, Convert.ToDateTime(dr["FechaEmision"]).ToString("d").Replace("-", "/"), dr["Tipo"], dr["Codigo"], dr["CodigoTipoDocumentoProveedor"], dr["Numero"], Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Imputado"]), Convert.ToDouble(dr["Saldo"]), "", "", Convert.ToDouble(dr["IVA"]), Convert.ToDouble(dr["Neto"]));
                if (indice != -1)
                    dgvDatos.Rows[dgvDatos.Rows.Count - 1].Cells["AAplicar"].ReadOnly = true;
                else
                    dgvDatos.Rows[dgvDatos.Rows.Count - 1].Cells["AAplicar"].ReadOnly = false;
            }
        }

        private void cbLiquidaciones_CheckedChanged(object sender, EventArgs e)
        {
            CargarValoresImputacion(cbLiquidaciones.Checked);
            objValores.Aplicado(dgvDatos);
            MostrarValores();
        }

        private void cbRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRecibos.SelectedValue != null && Convert.ToInt32(cbRecibos.SelectedValue) != -1)
                {
                    ucFormasPagoCompras.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                    objValores.Efectivo = Math.Abs(Convert.ToDouble(objLPagoProveedor.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Efectivo"]));
                    objValores.Dolares = Math.Abs(Convert.ToDouble(objLPagoProveedor.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Dolares"]));
                }
                else
                {
                    objValores.Efectivo = 0;
                    objValores.Dolares = 0;
                }
                ucFormasPagoCompras.Efectivo = objValores.Efectivo;
                ucFormasPagoCompras.Dolares = objValores.Dolares;
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


        private void txtImporte_Leave(object sender, EventArgs e)
        {
            if (cbImporte.Checked)
            {
                objValores.Total = Utilidades.CajaDeTexto.ObtenerImporte(txtImporte);
                if (objValores.Total == 0)
                {
                    cbImporte.Checked = false;
                }
            }
            else
            {
                objValores.Total = 0;
            }
            MostrarValores();
        }
        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor);
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
                txtCodigoProveedor.Focus();
                return;
            }
            if (objValores.ValoresPendientes != 0)
            {
                MessageBox.Show("No pueden quedar Valores Pendientes", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (objValores.Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CargarValoresPago();
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC") && (objEPago.FacturasImputacion.Count == 0 || objValores.Disponible(dgvDatos ) != 0))
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
                if (cbRecibos.Visible)
                    codigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                else
                    codigoRecibo = 0;
                int codigo = objLPagoProveedor.Agregar(objEPago, objEAsiento, codigoRecibo);
                txtCodigoProveedor.Text = "";
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //     Informe(codigo);
                InformePagos(Logica.Informes.PagosProveedores(codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformePagos(List<DataTable> lista)
        {

            Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
        }
        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEPago.Fecha;
            objEAsiento.FechaEmision = objEPago.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = "Segun " + objEPago.TipoDocumentoProveedor.Descripcion + " de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            if (cbLiquidaciones.Checked)
                asientoDetalle.CuentaContable.Codigo = 20101020000;
            else
                asientoDetalle.CuentaContable.Codigo = 20101010000;

            if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            {
                asientoDetalle.Debe = Convert.ToDouble(objEPago.Total);
                asientoDetalle.Haber = 0;
            }
            else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(Convert.ToDouble(objEPago.Total));
            }
            objEAsiento.Detalle.Add(asientoDetalle);


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
                            cuenta = 10101020100;
                            break;
                        case 2:
                            cuenta = 10101020600;
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

                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = fe.Importe * fe.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
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

                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {

                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                asientoDetalle.Cheque.Codigo = che.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque che in objEPago.ChequesPropios)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Cheque.Codigo = che.Codigo;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.CreditoDebito item in objEPago.CreditosDebitos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = item.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = item.Importe * item.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);

            }
            foreach (Entidades.Tranferencia tran in objEPago.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = tran.Importe * tran.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.PagosProveedoresImpuestos ppi in objEPago.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = ppi.Impuesto.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = ppi.ImporteRetenido;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = ppi.ImporteRetenido;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }
        public List<Entidades.FacturaCompraImputacion> ObtenerImputacion()
        {
            List<Entidades.FacturaCompraImputacion> facturas = new List<Entidades.FacturaCompraImputacion>();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                Entidades.FacturaCompraImputacion factura;
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    factura = new Entidades.FacturaCompraImputacion();

                    factura.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    factura.TipoDocumentoProveedor.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoProveedor"].Value);
                    factura.Monto = Convert.ToDouble(fila.Cells["AAplicar"].Value);
                    factura.CodigoImputacion = Convert.ToChar(fila.Cells["CodigoImputacion"].Value);
                    factura.ImputacionAnterior = Convert.ToDouble(fila.Cells["Imputado"].Value);
                    facturas.Add(factura);

                }
            }
            return facturas;
        }

        public List<Entidades.PagosProveedoresImpuestos> ObtenerImpuestos()
        {
            List<Entidades.PagosProveedoresImpuestos> facturas = new List<Entidades.PagosProveedoresImpuestos>();
            int indice = 0;
           // int indice2 = 0;
            Entidades.PagosProveedoresImpuestos factura;
            List<TipoDocumentoProveedor> tipos = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('G');
            tipos.AddRange(new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('I'));

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {

                Entidades.TipoDocumentoProveedor objETipoDoc = new TipoDocumentoProveedor();
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {

                    objETipoDoc.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoProveedor"].Value);

                    indice = tipos.IndexOf(objETipoDoc);
                    if (indice != -1 )
                    {
                        objETipoDoc = objLTipoDocProveedor.ObtenerUno(objETipoDoc.Codigo);
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDoc.Impuestos)
                        {
                            factura = new Entidades.PagosProveedoresImpuestos();

                            //factura.FacturaCompra.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                            factura.Impuesto = item.Impuesto;
                            factura.TotalComprobante = objEPago.Total;
                            factura.Regimen.Codigo = item.Regimen.Codigo;
                            switch (item.Del)
                            {
                                case 'N':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                            factura.AlicuotaAplicada = item.Porcentaje;
                            facturas.Add(factura);
                        }
                    }


                }
            }
            if (objValores.RetencionesMunicipales > 0)
            {
                double val = 0;
                foreach (PagosProveedoresImpuestos item in facturas)
                {
                    val += item.ImporteRetenido;
                }

                factura = new Entidades.PagosProveedoresImpuestos();
                factura.Impuesto = new Logica.Impuesto().ObtenerUno(16);
                factura.TotalComprobante = objValores.Total;//Utilidades.Redondear.DosDecimales(objEPago.Total - val - rete);
                factura.Regimen.Codigo = 0;
                factura.AlicuotaAplicada = objEProveedor.TipoContribuyente.PorcentajeRetencion;
                factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(objValores.RetencionesMunicipales);
                facturas.Add(factura);
            }
            if (objValores.RetencionIva > 0) {
                factura = new Entidades.PagosProveedoresImpuestos();
                factura.Impuesto = new Logica.Impuesto().ObtenerUno(15);
                factura.Regimen.Codigo = 499;
                factura.AlicuotaAplicada = 100;
                factura.ImporteRetenido = objValores.RetencionIva;
                facturas.Add(factura);
            }

            return facturas;
        }

        private void CargarValoresPago()
        {

            objEPago = new Entidades.Pago();
            objEPago.TipoDocumentoProveedor = objLTipoDocProveedor.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
            objEPago.TipoDocumentoProveedor.Numerador = new Logica.Numerador().ObtenerUno(objEPago.TipoDocumentoProveedor.Numerador.Codigo);
            objEPago.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEPago.Proveedor.Nombre = lblNombreProveedor.Text.Trim();
            objEPago.Fecha = dtFecha.Value;
            objEPago.Letra = Convert.ToChar(objEPago.TipoDocumentoProveedor.Numerador.Letra);
            objEPago.PuntoDeVenta = objEPago.TipoDocumentoProveedor.Numerador.PuntoVenta;
            objEPago.Numero = objEPago.TipoDocumentoProveedor.Numerador.Numero;
            objEPago.Usuario = Singleton.Instancia.Usuario;
            objEPago.PuestoCaja = Singleton.Instancia.Puesto;
            objEPago.Observaciones = txtObservaciones.Text.Trim();
            if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                objEPago.Total = objValores.Total;
            else
            {
                objEPago.Total = -objValores.Total;
                objEPago.ChequeRechazado = cbChequeRechazado.Checked;
            }
            
            ucFormasPagoCompras.ObtenerDatos();

            objEPago.FacturaEfectivo.Clear();
            objEPago.FacturaEfectivo = ucFormasPagoCompras.Efectivos;
            objEPago.Cheques.Clear();
            objEPago.Cheques = ucFormasPagoCompras.Cheques;
            objEPago.ChequesPropios.Clear();
            objEPago.ChequesPropios = ucFormasPagoCompras.ChequesPropios;
            objEPago.Tranferencias.Clear();
            objEPago.Tranferencias = ucFormasPagoCompras.Tranferencias;
            objEPago.FacturasImputacion.Clear();
            objEPago.FacturasImputacion = ObtenerImputacion();
            objEPago.Impuestos.Clear();
            objEPago.Impuestos = ObtenerImpuestos();
            objEPago.CreditosDebitos.Clear();
            objEPago.CreditosDebitos = ucFormasPagoCompras.CreditosDebitos;


            List<PagosProveedoresImpuestos> impuestos = new List<PagosProveedoresImpuestos>();

            foreach (PagosProveedoresImpuestos item in objEPago.Impuestos)
            {
                Entidades.PagosProveedoresImpuestos ppi;
                if (impuestos.IndexOf(item) != -1)
                {
                    //impuestos[impuestos.IndexOf(item)].Impuesto = item.Impuesto;
                    //impuestos[impuestos.IndexOf(item)].TotalComprobante = item.TotalComprobante;
                    //impuestos[impuestos.IndexOf(item)].Regimen = item.Regimen;
                    impuestos[impuestos.IndexOf(item)].ImporteRetenido += item.ImporteRetenido;
                }
                else
                {
                    ppi = new PagosProveedoresImpuestos();
                    ppi.Impuesto = item.Impuesto;
                    ppi.Regimen = item.Regimen;
                    ppi.TotalComprobante = item.TotalComprobante;
                    ppi.ImporteRetenido = item.ImporteRetenido;
                    ppi.AlicuotaAplicada = item.AlicuotaAplicada;
                    impuestos.Add(ppi);
                }
            }
            objEPago.Impuestos = impuestos;

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
                    if (cbImporte.Checked)
                    {
                        DataGridViewCheckBoxCell d = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];


                        if (Convert.ToBoolean(d.Value) == true)
                        {
                            if (objValores.Disponible(dgvDatos) >= Convert.ToDouble(dgvDatos["Pendiente", e.RowIndex].Value))
                            {
                                dgvDatos["AAplicar", e.RowIndex].Value = dgvDatos["Pendiente", e.RowIndex].Value;
                                dgvDatos["CodigoImputacion", e.RowIndex].Value = "T";
                            }
                            else if (objValores.Disponible(dgvDatos) == 0)
                            {


                                //d.Value = !Convert.ToBoolean(d.Value);
                                //dgvDatos.CurrentCell.Value = false;
                                d.Value = !(Convert.ToBoolean(d.Value));
                                dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                                dgvDatos["AAplicar", e.RowIndex].Value = "";
                                //this.dgvDatos.CurrentRow.Cells[e.ColumnIndex].Value = false;
                                MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                if (Convert.ToInt32(dgvDatos["CodigoTipoDocumentoProveedor", e.RowIndex].Value) != 19)
                                {
                                    dgvDatos["AAplicar", e.RowIndex].Value = objValores.Disponible(dgvDatos);
                                    dgvDatos["CodigoImputacion", e.RowIndex].Value = "P";
                                }
                                else
                                {
                                    d.Value = !(Convert.ToBoolean(d.Value));
                                    dgvDatos["AAplicar", e.RowIndex].Value = "";
                                    dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                                    MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = "";
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                        }
                    }
                    else
                    {
                        DataGridViewCheckBoxCell d = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                        if (Convert.ToBoolean(d.Value) == true)
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = dgvDatos["Pendiente", e.RowIndex].Value;
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "T";

                        }
                        else
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = "";
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "";

                        }
                        objValores.Total = CalculoTotal();
                    }
                }
                MostrarValores();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private double CalculoTotal()
        {
            double res = 0;
            try
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionado"].Value))
                    {
                        res += Convert.ToDouble(item.Cells["AAplicar"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return res;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

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
            if (!cbImporte.Checked)

                objValores.Total = CalculoTotal();
            objValores.Aplicado(dgvDatos);
            Cambio();
            MostrarValores();
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell d = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            if (Convert.ToBoolean(d.Value))
            {
                if (Convert.ToDouble(this.dgvDatos.Rows[e.RowIndex].Cells["AAplicar"].Value) > Convert.ToDouble(this.dgvDatos.Rows[e.RowIndex].Cells["Pendiente"].Value))
                {
                    this.dgvDatos.Rows[e.RowIndex].Cells["AAplicar"].Value = "";
                    d.Value = !Convert.ToBoolean(d.Value);
                    MessageBox.Show("El Valor ingresado no puede ser mayor al Pendiente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoProveedor.Text = "";
            objEProveedor = new Proveedor();
            Limpiar();
            MostrarValores();
        }

        private void txtRetIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtRetIVA_TextChanged(object sender, EventArgs e)
        {
            MostrarValores();
        }
    }

    internal class PagoProveedoresCalculos
    {
        public Proveedor Proveedor { get; set; }
        //public Empresa Empresa { get; set; }
        private double RetencionGanancias;
        public double RetencionIva;
        public double Total { get; set; }
        public double Efectivo { get; set; }
        public double Dolares { get; set; }
        public double Valores { get; set; }
        public double RetencionesMunicipales
        {
            get
            {
                if (Singleton.Instancia.Empresa.PercepcionMunicipal && Proveedor != null && Proveedor.TipoContribuyente.PorcentajeRetencion != 0 && Proveedor.TipoContribuyente.MinimoRetencion <= Total)
                {
                    return Utilidades.Redondear.DosDecimales((Total) * Proveedor.TipoContribuyente.PorcentajeRetencion / 100);
                }
                return 0;
            }
        }

        public double Disponible(DataGridView dg)
        {
            return Utilidades.Redondear.DosDecimales(Total - Aplicado(dg));
        }

        public double ValoresPendientes
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(Total - Valores - RetencionesMunicipales - RetencionGanancias - RetencionIva);
            }
        }

        //List<TipoDocumentoProveedor> tiposG = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('G');
        public double RetencionesGanancias(DataGridView dgvDatos)
        {
            double res = 0;
            int indice = 0;
            Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new TipoDocumentoProveedor();
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                {
                    objETipoDocumentoProveedor.Codigo = Convert.ToInt32(dgv.Cells["CodigoTipoDocumentoProveedor"].Value);
                    List<TipoDocumentoProveedor> tiposG = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('G');
                    indice = tiposG.IndexOf(objETipoDocumentoProveedor);
                    if (indice != -1)
                    {
                        objETipoDocumentoProveedor = tiposG.ElementAt((indice));
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDocumentoProveedor.Impuestos)
                        {
                            switch (item.Del)
                            {
                                case 'N':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                        }
                    }

                }
            }
            RetencionGanancias = res;
            return res;
        }

        //List<TipoDocumentoProveedor> tiposI = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('I');


        public double RetencionesIva(TextBox t/*DataGridView dgvDatos*/)
        {
            /*
            double res = 0;
            int indice = 0;
            Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new TipoDocumentoProveedor();
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                {
                    objETipoDocumentoProveedor.Codigo = Convert.ToInt32(dgv.Cells["CodigoTipoDocumentoProveedor"].Value);
                    List<TipoDocumentoProveedor> tiposI = new Logica.TipoDocumentoProveedor().ObtenerTodosConImpuestos('I');
                    indice = tiposI.IndexOf(objETipoDocumentoProveedor);
                    if (indice != -1)
                    {
                        objETipoDocumentoProveedor = tiposI.ElementAt((indice));
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDocumentoProveedor.Impuestos)
                        {
                            switch (item.Del)
                            {
                                case 'N':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                        }
                    }

                }
            }*/
            RetencionIva = t.Text.Trim().Equals("")?0:Convert.ToDouble(t.Text);
            return RetencionIva;
            
        }

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
