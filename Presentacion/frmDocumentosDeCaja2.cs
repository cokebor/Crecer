using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDocumentosDeCaja2 : Presentacion.frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        Entidades.Caja objECaja;
        Logica.Caja objLCaja = new Logica.Caja();
        Entidades.Asiento objEAsiento;

        private double totalGastos = 0;
        private double valores = 0;

        Logica.TipoDocumentoCaja objLTipoDocumento = new Logica.TipoDocumentoCaja();
        public frmDocumentosDeCaja2()
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
            this.ucFormasPagoIngresos.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.btnEliminar.Click += ActualizarValores;
            
            this.ucFormasPagoIngresos.ucCheque.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoIngresos.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            
            if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                cbSucursal.Visible = false;
        }

        private void Titulo()
        {
            this.Text = "MOVIMIENTOS DE CAJA";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservacionesIngresos, 100);
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTiposComprobantes);
            Utilidades.Combo.Formato(cbCuentaIngresos);
            Utilidades.Combo.Formato(cbSucursal);
            Utilidades.Grilla.Formato(dgvGastosIngreso);
            tpConceptosIngresos.BackColor = frmColor.Color;
            tpFormasDePagoIngresos.BackColor = frmColor.Color;
            //tpDepositar.BackColor = frmColor.Color;
            ucFormasPagoIngresos.BackColor = frmColor.Color;
            ucFormasPagoIngresos.FormularioInicial = this;
            dgvGastosIngreso.Columns["CuentaContable"].Width = 350;

        }

        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTiposComprobantes, objLTipoDocumento.ObtenerTodos(), "Codigo", "Descripcion");
                Utilidades.Combo.Llenar(cbCuentaIngresos, objLCuentaContable.ObtenerGastos(), "Codigo", "Nombre");
                Utilidades.Combo.Llenar(cbSucursal, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
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
                txtImporteIngresos.Focus();
                return;
            }
            if (txtImporteIngresos.Text.Length > 0 && Convert.ToDouble(txtImporteIngresos.Text) == 0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporteIngresos.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvGastosIngreso.Rows)
            {
                if (Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value) == Convert.ToInt64(cbCuentaIngresos.SelectedValue))
                {
                    MessageBox.Show("Gasto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            dgvGastosIngreso.Rows.Add(Convert.ToInt64(cbCuentaIngresos.SelectedValue), cbCuentaIngresos.Text.ToString(), Convert.ToDouble(txtImporteIngresos.Text.Trim()));

            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaIngresos);
            //CargarTotales();
            totalGastos += Convert.ToDouble(txtImporteIngresos.Text.Trim());
            cbCuentaIngresos.Focus();
            txtImporteIngresos.Text = "";
            MostrarImportes();
        }

        private bool ValidarGasto()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaIngresos);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtImporteIngresos));
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGastosIngreso.CurrentRow != null)
            {
                totalGastos -= Convert.ToDouble(dgvGastosIngreso.CurrentRow.Cells["Importe"].Value);
                dgvGastosIngreso.Rows.Remove(dgvGastosIngreso.CurrentRow);
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
                    valores = ucFormasPagoIngresos.valores;
                    break;
                default:
                    break;
            }
            
            lblValores.Text = valores.ToString("C2");
            lblTotal.Text = totalGastos.ToString("C2");
            lblSaldo.Text = Saldo().ToString("C2");
        }
        private double Saldo()
        {
            return Utilidades.Redondear.DosDecimales(totalGastos) - Utilidades.Redondear.DosDecimales(valores);
        }
        private void ActualizarValores(object sender, EventArgs e)
        {
            MostrarImportes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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
                    break;
                case 4:
                    if (valores <= 0)
                    {
                        MessageBox.Show("Total de Comprobante no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
            }
            
            if (Saldo() != 0)
            {
                MessageBox.Show("El saldo del comprobante debe ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                Comprobante();
                CargarAsiento();
                string valor="";
                switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
                {
                    case 1:
                        valor = "Gastos";
                        break;
                    case 4:
                        valor = "Deposito";
                        break;
                }

                objLCaja.Agregar(objECaja, objEAsiento,valor);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            objECaja.Observaciones = txtObservacionesIngresos.Text.Trim();
            
            switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
            {
                case 3: //gastos
                    ucFormasPagoIngresos.ObtenerDatos();
                    objECaja.FacturaEfectivo = ucFormasPagoIngresos.Efectivos;
                    objECaja.Cheques = ucFormasPagoIngresos.Cheques;
                    objECaja.Tranferencias = ucFormasPagoIngresos.Tranferencias;
                    objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);
                    if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                        objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;
                    else
                        objECaja.SucursalDestino = Convert.ToInt32(cbSucursal.SelectedValue);
                    break;
            }
            
        }

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECaja.Fecha;
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


            foreach (DataGridViewRow fila in dgvGastosIngreso.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value));
                asientoDetalle.Debe = Convert.ToDouble(fila.Cells["Importe"].Value);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
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
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                objEAsiento.Detalle.Add(asientoDetalle);
            }



            foreach (Entidades.Cheque che in objECaja.Cheques)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(3);
                //    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.CuentaContable.Codigo = che.CuentaBancaria.CuentaContable.Codigo;

                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque che in objECaja.ChequesPropios)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;

                objEAsiento.Detalle.Add(asientoDetalle);
            }


            foreach (Entidades.Tranferencia tran in objECaja.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.GrillaVacia(dgvGastosIngreso);
            return res;
        }

        private void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaIngresos);
            txtImporteIngresos.Text = "";
            dgvGastosIngreso.Rows.Clear();
            txtObservacionesIngresos.Text = "";
            ucFormasPagoIngresos.Limpiar();
            tcGastosIngresos.SelectedIndex = 0;
            totalGastos = 0;
            valores = 0;
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
            switch (Convert.ToInt32(cbTiposComprobantes.SelectedValue))
            {
                case 1://Gastos
                    cbSucursal.Visible = true;
                    pIngresos.Visible = true;
                    break;
               /* case 3:
                    pEgresos.Visible = false;
                    pEgresoDeposito.Visible = false;
                    break;*/
                case 4: //Egreso
                    cbSucursal.Visible = false;
                    pIngresos.Visible = false;
                    
                    break;
                default:
                    cbSucursal.Visible = false;
                    pIngresos.Visible = false;
                    
                    MessageBox.Show("Comprobante sin datos cargados!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

        }
    }
}
