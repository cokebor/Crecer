using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDocumentosDeCaja : Presentacion.frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        Entidades.Caja objECaja;
        Logica.Caja objLCaja = new Logica.Caja();
        Entidades.Asiento objEAsiento;

        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        private double totalGastos = 0;
        private double valores = 0;
        private double totalDescuentos = 0;

        Logica.TipoDocumentoCaja objLTipoDocumento = new Logica.TipoDocumentoCaja();
        public frmDocumentosDeCaja()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            CargarValores();
            this.ucFormasPagoCompras.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucDebitoCredito.btnAgregar.Click += ActualizarValores;

            this.ucFormasPagoExtraccion.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoExtraccion.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoExtraccion.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoExtraccion.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;

            this.ucFormasPagoIngresos.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.ucCheque.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;




            //if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
            cbSucursal.Visible = true;
        }

        private void Titulo()
        {
            this.Text = "MOVIMIENTOS DE CAJA";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 100);
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTiposComprobantes);
            Utilidades.Combo.Formato(cbCuenta);
            Utilidades.Combo.Formato(cbCuentaIngresos);
            Utilidades.Combo.Formato(cbSucursal);
            Utilidades.Grilla.Formato(dgvGastos);
            Utilidades.Grilla.Formato(dgvGastosIngreso);
            Utilidades.Grilla.Formato(dgvImpuestos);
            tpConceptos.BackColor = frmColor.Color;
            tpFormasDePago.BackColor = frmColor.Color;
            tpConceptosIngresos.BackColor = frmColor.Color;
            tpFormasDePagoIngresos.BackColor = frmColor.Color;
            tpDescuentos.BackColor = frmColor.Color;
            //tpDepositar.BackColor = frmColor.Color;
            panel2.BackColor = frmColor.Color;
            ucFormasPagoCompras.BackColor = frmColor.Color;
            ucFormasPagoCompras.FormularioInicial = this;
            ucFormasPagoExtraccion.FormularioInicial = this;
            ucFormasPagoIngresos.BackColor = frmColor.Color;
            ucFormasPagoIngresos.FormularioInicial = this;
            dgvGastos.Columns["CuentaContable"].Width = 350;
            dgvGastosIngreso.Columns["CuentaContableIngreso"].Width = 350;
            dgvImpuestos.Columns["Impuesto"].Width = 200;
            dgvImpuestos.Columns["ImporteImpuesto"].Width = 100;
            //dgvImpuestos.Columns["Eliminar"].Width = 150;
        }

        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTiposComprobantes, objLTipoDocumento.ObtenerTodos(), "Codigo", "Descripcion");
                Utilidades.Combo.Llenar(cbCuenta, objLCuentaContable.ObtenerGastos2(), "Codigo", "Nombre");
                Utilidades.Combo.Llenar(cbCuentaIngresos, objLCuentaContable.ObtenerIngresos(), "CodigoCuentaContable", "Descripcion");
                Utilidades.Combo.Llenar(cbSucursal, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");

                cbSucursal.SelectedValue = Singleton.Instancia.Empresa.Codigo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (ValidarGasto().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }
            if (txtImporte.Text.Length > 0 && Convert.ToDouble(txtImporte.Text) == 0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                if (Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value) == Convert.ToInt64(cbCuenta.SelectedValue))
                {
                    MessageBox.Show("Gasto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            Entidades.CuentaContable cuenta = CalcularCuentaContableGastos();

            dgvGastos.Rows.Add(cuenta.Codigo, cuenta.Nombre, Convert.ToDouble(txtImporte.Text.Trim()));

            if (cuenta.Codigo == 50104020000 || cuenta.Codigo == 50104030000)
                txtObservaciones.Text = cuenta.Nombre;


            Utilidades.Combo.SeleccionarPrimerValor(cbCuenta);
            //CargarTotales();
            totalGastos += Convert.ToDouble(txtImporte.Text.Trim());
            cbCuenta.Focus();
            txtImporte.Text = "";
            MostrarImportes();
        }

        private Entidades.CuentaContable CalcularCuentaContableGastos()
        {
            Entidades.CuentaContable objCuentaContable = new Entidades.CuentaContable();
            long cuenta = Convert.ToInt64(cbCuenta.SelectedValue);
            if (Singleton.Instancia.Empresa.Codigo != 1)
            {
                long cuenta2;
                int valor = 0;


                switch (Convert.ToInt32(cbSucursal.SelectedValue))
                {
                    case 1:
                        valor = 100;
                        break;
                    case 2:
                        valor = 600;
                        break;
                    case 3:
                        valor = 200;
                        break;
                    case 4:
                        valor = 300;
                        break;
                    case 5:
                        valor = 400;
                        break;
                    case 7:
                        valor = 500;
                        break;
                }
                cuenta2 = Convert.ToInt64(cuenta.ToString().Substring(0, 8) + "000") + valor;

                objCuentaContable = objLCuentaContable.ObtenerUno(cuenta2);
                if (objCuentaContable == null)
                {
                    objCuentaContable = objLCuentaContable.ObtenerUno(cuenta);
                }
                return objCuentaContable;
            }
            else {
   
                  objCuentaContable = objLCuentaContable.ObtenerUno(cuenta);
        
                  return objCuentaContable;
            }
        }
        private bool ValidarGasto()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuenta);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtImporte));
            return res;
        }

        private bool ValidarIngreso()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaIngresos);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtImporteIngresos));
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGastos.CurrentRow != null)
            {
                totalGastos -= Convert.ToDouble(dgvGastos.CurrentRow.Cells["Importe"].Value);
                dgvGastos.Rows.Remove(dgvGastos.CurrentRow);
                //CargarTotales();
                MostrarImportes();
            }
        }

        private void MostrarImportes()
        {
            // lblValores.Text = valores.ToString("C2");
            switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
            {
                case 1: //gastos
                    valores = ucFormasPagoCompras.valores;
                    break;
                case 3: //ingresos
                    valores = ucFormasPagoIngresos.valores;
                    break;
                case 4:
                    valores = ucFormasPagoExtraccion.valores;
                    totalGastos = valores;
                    break;
                default:
                    break;
            }

            lblValores.Text = valores.ToString("C2");
            lblDescuentos.Text = totalDescuentos.ToString("C2");
            lblTotal.Text = totalGastos.ToString("C2");
            lblSaldo.Text = Saldo().ToString("C2");
        }
        private double Saldo()
        {
            return Utilidades.Redondear.DosDecimales(Utilidades.Redondear.DosDecimales(totalGastos) - Utilidades.Redondear.DosDecimales(valores)- Utilidades.Redondear.DosDecimales(totalDescuentos));
        }
        private void ActualizarValores(object sender, EventArgs e)
        {
            MostrarImportes();
        }

        private bool ValidarFechaConciliacionCuentaCheques(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Cheque pCheque)
        {
            if (pCheque.FechaPago <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }

        private bool ValidarFechaConciliacionCuentaTranferencias(Entidades.CuentaBancaria pCuentaBancaria)
        {
            if (dtpFecha.Value.Date <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
                {
                    case 1:
                        if (ValidarComprobante().Equals(true))
                        {
                            MessageBox.Show("No se pudo guardar ya que no se ingresaron Conceptos de Gastos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (totalGastos == 0)
                        {
                            MessageBox.Show("Total de Gastos no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ucFormasPagoCompras.ObtenerDatos();
                        if (ucFormasPagoCompras.ChequesPropios.Count > 0)
                        {
                            Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                            Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                            foreach (Entidades.Cheque item in ucFormasPagoCompras.ChequesPropios)
                            {
                                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                                if (ValidarFechaConciliacionCuentaCheques(objECuentaBancaria, item).Equals(false))
                                {
                                    MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }
                        }
                        if (ucFormasPagoCompras.Tranferencias.Count > 0)
                        {
                            Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                            Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                            foreach (Entidades.Tranferencia item in ucFormasPagoCompras.Tranferencias)
                            {
                                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                                if (ValidarFechaConciliacionCuentaTranferencias(objECuentaBancaria).Equals(false))
                                {
                                    MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }
                        }

                        break;
                    case 3:
                        if (ValidarIngresos().Equals(true))
                        {
                            MessageBox.Show("No se pudo guardar ya que no se ingresaron Conceptos de Ingresos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (totalGastos == 0)
                        {
                            MessageBox.Show("Total de Ingresos no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        break;
                    case 4:
                        if (valores <= 0)
                        {
                            MessageBox.Show("Total de Comprobante no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (ValidarFechaConciliacionCuentaExtraccion().Equals(false))
                        {
                            MessageBox.Show("No se puede grabar el Comprobante.\nCuenta Conciliada el " + ucFormasPagoExtraccion.ObjECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        break;
                }

                if (Saldo() != 0)
                {
                    MessageBox.Show("El saldo del comprobante debe ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                Comprobante();
                CargarAsiento();
                string valor = "";
                switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
                {
                    case 1:
                        valor = "Gastos";
                        break;
                    case 3:
                        valor = "Ingresos";
                        break;
                    case 4:
                        valor = "Deposito";
                        break;
                }

                int codigo = objLCaja.Agregar(objECaja, objEAsiento, valor);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (objECaja.TipoDocumentoCaja.Codigo == 1 || objECaja.TipoDocumentoCaja.Codigo == 4)
                {


                    if (MessageBox.Show("¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (objECaja.TipoDocumentoCaja.Codigo == 1)
                            InformeCaja(Logica.Informes.CajaGastos(codigo, Singleton.Instancia.Empresa.NombreSucursal), "repCajaGastos");
                        else
                            InformeCaja(Logica.Informes.CajaDepositos(codigo, Singleton.Instancia.Empresa.NombreSucursal), "repCajaDepositos");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformeCaja(List<DataTable> lista, String informe)
        {
            try
            {
                Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE CAJA", lista, informe));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarFechaConciliacionCuentaExtraccion()
        {
            if (dtpFecha.Value.Date <= ucFormasPagoExtraccion.ObjECuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private void Comprobante()
        {
            objECaja = new Entidades.Caja();

            //objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(1);
            objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(Convert.ToInt32(cbTiposComprobantes.SelectedValue));

            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = dtpFecha.Value;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Observaciones = txtObservaciones.Text.Trim();

            switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
            {
                case 1: //gastos
                        //ucFormasPagoCompras.ObtenerDatos();
                    objECaja.CreditosDebitos = ucFormasPagoCompras.CreditosDebitos;
                    objECaja.FacturaEfectivo = ucFormasPagoCompras.Efectivos;
                    objECaja.Cheques = ucFormasPagoCompras.Cheques;
                    objECaja.Tranferencias = ucFormasPagoCompras.Tranferencias;
                    objECaja.ChequesPropios = ucFormasPagoCompras.ChequesPropios;
                    //objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);
                    if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                        objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;
                    else
                        objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);


                    foreach (DataGridViewRow fila in dgvGastos.Rows)
                    {
                        Entidades.Caja_Detalle cajaDetalle = new Entidades.Caja_Detalle();
                        cajaDetalle.CodigoCuentaContable = Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value);
                        cajaDetalle.Descripcion = fila.Cells["CuentaContable"].Value.ToString();
                        cajaDetalle.Importe = Convert.ToDouble(fila.Cells["Importe"].Value);
                        objECaja.Detalle.Add(cajaDetalle);
                    }
                    foreach (DataGridViewRow fila in dgvImpuestos.Rows)
                    {
                        Entidades.FacturaImpuesto cajaImpuesto = new Entidades.FacturaImpuesto();
                        cajaImpuesto.Impuesto.Codigo = Convert.ToInt32(fila.Cells["CodigoImpuesto"].Value);
                        cajaImpuesto.Impuesto.CuentaContable.Codigo= Convert.ToInt64(fila.Cells["CodigoCuentaContableImpuesto"].Value);
                        cajaImpuesto.Importe = Convert.ToDouble(fila.Cells["ImporteImpuesto"].Value);
                        objECaja.Impuestos.Add(cajaImpuesto);
                    }
                    break;
                case 3:
                    ucFormasPagoIngresos.ObtenerDatos();
                    objECaja.FacturaEfectivo = ucFormasPagoIngresos.Efectivos;
                    objECaja.Cheques = ucFormasPagoIngresos.Cheques;
                    objECaja.Tranferencias = ucFormasPagoIngresos.Tranferencias;
                    //objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);
                    if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                        objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;
                    else
                        objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);

                    foreach (DataGridViewRow fila in dgvGastosIngreso.Rows)
                    {
                        Entidades.Caja_Detalle cajaDetalle = new Entidades.Caja_Detalle();

                        cajaDetalle.CodigoCuentaContable=Convert.ToInt64(fila.Cells["CodigoCuentaContableIngreso"].Value);
                        cajaDetalle.Descripcion = fila.Cells["CuentaContableIngreso"].Value.ToString();
                        cajaDetalle.Importe = Convert.ToDouble(fila.Cells["ImporteIngreso"].Value);
                        objECaja.Detalle.Add(cajaDetalle);
                    }

                    break;
                case 4:
                    ucFormasPagoExtraccion.ObtenerDatos();
                    objECaja.FacturaEfectivo = ucFormasPagoExtraccion.Efectivos;
                    objECaja.Cheques = ucFormasPagoExtraccion.Cheques;
                    objECaja.CuentaBancaria = ucFormasPagoExtraccion.ObjECuentaBancaria;
                    objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;
                    break;
            }

        }

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECaja.Fecha;
            objEAsiento.FechaEmision = objECaja.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = objECaja.TipoDocumentoCaja.Descripcion + "  N° " + objECaja.Numdoc;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            if (Convert.ToInt32(cbTiposComprobantes.SelectedValue) == 1)
                objEAsiento.Sucursal = Convert.ToInt32(cbSucursal.SelectedValue);
            else
                objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;


            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value));
                asientoDetalle.Debe = Convert.ToDouble(fila.Cells["Importe"].Value);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            foreach (DataGridViewRow fila in dgvGastosIngreso.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(fila.Cells["CodigoCuentaContableIngreso"].Value));
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Convert.ToDouble(fila.Cells["ImporteIngreso"].Value);
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            if (Convert.ToInt32(cbTiposComprobantes.SelectedValue) == 4)
            {
                double tot = 0;
                foreach (Entidades.Cheque item in objECaja.Cheques)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = ucFormasPagoExtraccion.ObjECuentaBancaria.CuentaContable.Codigo;
                    if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                    {
                        asientoDetalle.Debe = 0;

                        asientoDetalle.Haber = item.Importe * item.Moneda.Cotizacion;
                        tot += asientoDetalle.Haber;
                    }
                    else
                    {
                        asientoDetalle.Debe = item.Importe * item.Moneda.Cotizacion;
                        asientoDetalle.Haber = 0;
                        tot += asientoDetalle.Debe;
                    }
                    asientoDetalle.Cheque = item;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }

                if (Utilidades.Redondear.DosDecimales(ucFormasPagoExtraccion.valores - tot) > 0)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = ucFormasPagoExtraccion.ObjECuentaBancaria.CuentaContable.Codigo;

                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(ucFormasPagoExtraccion.valores - tot);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }

            Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
            Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
            foreach (Entidades.Factura_Efectivo fe in objECaja.FacturaEfectivo)
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
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }



            foreach (Entidades.Cheque che in objECaja.Cheques)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(3);
                //    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.CuentaContable.Codigo = che.CuentaBancaria.CuentaContable.Codigo;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                asientoDetalle.Cheque = che;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque che in objECaja.ChequesPropios)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }


                asientoDetalle.Cheque = che;
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            foreach (Entidades.Tranferencia tran in objECaja.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = tran.Importe * tran.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            foreach (Entidades.CreditoDebito dc in objECaja.CreditosDebitos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = dc.CuentaBancaria.CuentaContable;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = dc.Importe * dc.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = dc.Importe * dc.Moneda.Cotizacion;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.FacturaImpuesto ci in objECaja.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = ci.Impuesto.CuentaContable;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = ci.Importe; 
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = ci.Importe;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.GrillaVacia(dgvGastos);
            return res;
        }
        private bool ValidarIngresos()
        {
            bool res = false;
            res = Utilidades.Validar.GrillaVacia(dgvGastosIngreso);
            return res;
        }

        private void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbCuenta);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaIngresos);
            txtImporte.Text = "";
            txtImporteIngresos.Text = "";
            dgvGastos.Rows.Clear();
            dgvGastosIngreso.Rows.Clear();
            txtObservaciones.Text = "";
            txtObservacionesIngresos.Text = "";
            dgvImpuestos.Rows.Clear();
            txtImporteImpuesto.Text = "";
            ucFormasPagoCompras.Limpiar();
            ucFormasPagoExtraccion.Limpiar();
            ucFormasPagoIngresos.Limpiar();
            tcGastos.SelectedIndex = 0;
            tcGastosIngresos.SelectedIndex = 0;
            totalGastos = 0;
            valores = 0;
            totalDescuentos = 0;
            dtpFecha.Value = DateTime.Now;
            MostrarImportes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cbTiposComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();
            tcGastos.TabPages.Remove(tpDescuentos);
            switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
            {
                case 1://Gastos
                    /*if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                        cbSucursal.Visible = true;*/
                    tcGastos.TabPages.Add(tpDescuentos);
                    pEgresos.Visible = true;
                    pEgresoDeposito.Visible = false;
                    pIngresos.Visible = false;
                    break;
                case 3:
                    pEgresos.Visible = false;
                    pEgresoDeposito.Visible = false;
                    pIngresos.Visible = true;
                    break;
                case 4: //Egreso
                        // if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                    cbSucursal.Visible = false;
                    pEgresos.Visible = false;
                    pEgresoDeposito.Visible = true;
                    pIngresos.Visible = false;
                    break;
                    /*default:
                        cbSucursal.Visible = false;
                        pEgresos.Visible = false;
                        pEgresoDeposito.Visible = false;
                        MessageBox.Show("Comprobante sin datos cargados!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;*/
            }

        }

        private void txtImporteIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporteIngresos.Focus();
                return;
            }
            if (txtImporteIngresos.Text.Length > 0 && Convert.ToDouble(txtImporteIngresos.Text) == 0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvGastosIngreso.Rows)
            {
                if (Convert.ToInt64(fila.Cells["CodigoCuentaContableIngreso"].Value) == Convert.ToInt64(cbCuenta.SelectedValue))
                {
                    MessageBox.Show("Concepto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            dgvGastosIngreso.Rows.Add(Convert.ToInt64(cbCuentaIngresos.SelectedValue), cbCuentaIngresos.Text.ToString(), Convert.ToDouble(txtImporteIngresos.Text.Trim()));
            if (Convert.ToInt64(cbCuentaIngresos.SelectedValue) == 40102040000 || Convert.ToInt64(cbCuentaIngresos.SelectedValue) == 40102050000)
                txtObservaciones.Text = cbCuentaIngresos.Text.ToString();

            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaIngresos);
            //CargarTotales();
            totalGastos += Convert.ToDouble(txtImporteIngresos.Text.Trim());
            cbCuentaIngresos.Focus();
            txtImporteIngresos.Text = "";
            MostrarImportes();
        }

        private void btnEliminarIngreso_Click(object sender, EventArgs e)
        {
            if (dgvGastosIngreso.CurrentRow != null)
            {
                totalGastos -= Convert.ToDouble(dgvGastosIngreso.CurrentRow.Cells["ImporteIngreso"].Value);
                dgvGastosIngreso.Rows.Remove(dgvGastosIngreso.CurrentRow);
                //CargarTotales();
                MostrarImportes();
            }
        }

        private void txtCodigoImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F7:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmImpuestoBuscar("DocumentosCaja", this));
                    break;
            }
        }
        private void txtCodigoImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
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

        private void txtImporteImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtImporteImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
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


            dgvImpuestos.Rows.Add(objEImpuesto.Codigo, objEImpuesto.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporteImpuesto.Text.Trim())), objEImpuesto.CuentaContable.Codigo);
            //           objValores.Impuestos += Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim()));
            totalDescuentos += Convert.ToDouble(txtImporteImpuesto.Text.Trim());

            txtCodigoImpuesto.Text = "";
            txtImporteImpuesto.Text = "";
            txtCodigoImpuesto.Focus();
            MostrarImportes();
  //          MostrarValores();
        }
        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblImpuesto);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporteImpuesto);
            return res;
        }

        private void dgvImpuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) {
                totalDescuentos -= Convert.ToDouble(dgvImpuestos.Rows[e.RowIndex].Cells["ImporteImpuesto"]);
                dgvImpuestos.Rows.RemoveAt(e.RowIndex);
                MostrarImportes();
            }
        }

    }
}

