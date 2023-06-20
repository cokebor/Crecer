using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConciliacionProveedores : Presentacion.frmColor
    {
        Logica.Pago objLPagoProveedores = new Logica.Pago();
        Logica.ConciliacionesProveedores objLConciliacionesProveedores = new Logica.ConciliacionesProveedores();

        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        Entidades.Caja objECaja = new Entidades.Caja();
        Entidades.Pago objEPagoProveedor = new Entidades.Pago();
        Entidades.Asiento objEAsientoCaja;
        Entidades.Asiento objEAsientoPago;
        Entidades.FormaDePago objEFormaPago;

        //List<Entidades.MovimientoBancario> movimientos = new List<Entidades.MovimientoBancario>();
        //Logica.Banco objLBanco = new Logica.Banco();
        //Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        //Logica.Cheque objLCheque = new Logica.Cheque();
        //Logica.MovimientoBancario objLMovimiento = new Logica.MovimientoBancario();

        //Entidades.Asiento objEAsiento = new Entidades.Asiento();
        //Entidades.Banco objEBanco = new Entidades.Banco();
        //Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();

        private double total;
        public frmConciliacionProveedores()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();

            Formatos();
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "CONCILIACION DE PAGOS DE PROVEEDORES EN SUCURSALES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbSucursales);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;

            dgvDatos.Columns["Seleccionar"].Width = 30;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Documento"].Width = 80;
            dgvDatos.Columns["Proveedor"].Width = 153;
            dgvDatos.Columns["Numero"].Width = 100;
            dgvDatos.Columns["Efectivo"].Width = 100;
            dgvDatos.Columns["Cheques"].Width = 100;
            dgvDatos.Columns["TotalPago"].Width = 100;

            dgvDatos.Columns["Seleccionar"].ReadOnly = false;
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerSucursales(), "Codigo", "Descripcion", "<<Seleccionar>>");
                cbSucursales.SelectedValue = 0;
            }
        }





        private void CargarAsiento()
        {
            //objEAsiento = new Entidades.Asiento();
            //objEAsiento.Fecha = dtpFecha.Value;
            //objEAsiento.FechaEmision = dtpFecha.Value;

            //objEAsiento.Descripcion = "Conciliacion Cheques " + objEAsiento.Fecha.ToShortDateString();

            //objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            //Entidades.Asiento_Detalle asientoDetalle;

            //foreach (DataGridViewRow item in dgvDatos.Rows)
            //{
            //    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
            //    {
            //        asientoDetalle = new Entidades.Asiento_Detalle();
            //        asientoDetalle.CuentaContable.Codigo = objECuentaBancaria.CuentaContableValoresDiferidos.Codigo;

            //        asientoDetalle.Debe = Convert.ToDouble(item.Cells["Importe"].Value);
            //        asientoDetalle.Haber = 0;
            //        asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Cells["CodigoCheque"].Value);
            //        objEAsiento.Detalle.Add(asientoDetalle);

            //        asientoDetalle = new Entidades.Asiento_Detalle();
            //        asientoDetalle.CuentaContable.Codigo = objECuentaBancaria.CuentaContable.Codigo;

            //        asientoDetalle.Debe = 0;
            //        asientoDetalle.Haber = Convert.ToDouble(item.Cells["Importe"].Value);
            //        asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Cells["CodigoCheque"].Value);
            //        objEAsiento.Detalle.Add(asientoDetalle);
            //    }
            //}


        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)dgvDatos.CurrentRow.Cells["Seleccionar"];
                celda.Value = !Convert.ToBoolean(celda.Value);
            }
            CalcularTotal();
            lblTotal.Text = total.ToString("C2");

        }
        private void CalcularTotal()
        {
            total = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    total += Convert.ToDouble(item.Cells["TotalPago"].Value);
                }
            }
        }

        private void PonerEnRojo()
        {
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                if (Convert.ToInt32(dg.Cells["CodigoTipoDocumentoProveedor"].Value) == 6)
                {
                    // dg.Cells["ImporteConNC"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Regular);
                    dg.Cells["Fecha"].Style.ForeColor = Color.Red;
                    dg.Cells["Documento"].Style.ForeColor = Color.Red;
                    dg.Cells["Proveedor"].Style.ForeColor = Color.Red;
                    dg.Cells["Numero"].Style.ForeColor = Color.Red;
                    dg.Cells["Efectivo"].Style.ForeColor = Color.Red;
                    dg.Cells["Cheques"].Style.ForeColor = Color.Red;
                    dg.Cells["TotalPago"].Style.ForeColor = Color.Red;
                }

            }
        }
        private void ObtenerValores()
        {
            //movimientos.Clear();
            //Entidades.MovimientoBancario movimiento;
            //foreach (DataGridViewRow item in dgvDatos.Rows)
            //{
            //    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
            //    {
            //        movimiento = new Entidades.MovimientoBancario();
            //        movimiento.Codigo = Convert.ToInt32(item.Cells["CodigoMovimientoBancario"].Value);
            //        movimiento.CuentaBancaria.Codigo = Convert.ToInt32(cbCuentaBancaria.SelectedValue);
            //        movimientos.Add(movimiento);
            //    }
            //}
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int val = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    val = 1;
                    break;
                }
            }

            if (val == 0)
            {
                MessageBox.Show("No se pudo guardar ya que no se seleciono ningun comprobante!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        ObtenerDatos(item);
                        ObtenerAsientos();
                        objLConciliacionesProveedores.Agregar(objECaja, objEAsientoCaja, objEPagoProveedor, objEAsientoPago);
                        item.Cells["Seleccionar"].Value = false;
                    }
                }
                CargarDatos();
                MessageBox.Show("Comprobantes Conciliados exitosamente!!",Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CargarDatos();
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //    ObtenerValores();
            //    CargarAsiento();
            //    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }
            //    objLMovimiento.Actualizar(movimientos, objEAsiento, Singleton.Instancia.Usuario,objECuentaBancaria);
            //    ObtenerCheques();
            //    CalcularTotal();
            //    lblTotal.Text = total.ToString("C2");
            //    MessageBox.Show("Conciliacion creada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ObtenerDatos(DataGridViewRow item)
        {
            //Ingresos
            objECaja = new Entidades.Caja();
            objEPagoProveedor = new Entidades.Pago();

            if (Convert.ToInt32(item.Cells["CodigoTipoDocumentoProveedor"].Value) == 5)
            {
                objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(9);
                objECaja.Observaciones = "Ingresos por Pago a Proveedor " + item.Cells["Proveedor"].Value.ToString() + " Sucursal: " + cbSucursales.Text + " Recibo: " + item.Cells["Numero"].Value.ToString();
                objEPagoProveedor.Observaciones = "Recibo Proveedor Sucursal " + cbSucursales.Text + " Nro: " + item.Cells["Numero"].Value.ToString(); ;

            }
            else if (Convert.ToInt32(item.Cells["CodigoTipoDocumentoProveedor"].Value) == 6)
            {
                objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(10);
                objECaja.Observaciones = "Egresos por Pago a Proveedor " + item.Cells["Proveedor"].Value.ToString() + " Sucursal: " + cbSucursales.Text + " Contra Recibo: " + item.Cells["Numero"].Value.ToString();
                objEPagoProveedor.Observaciones = "Contra Recibo Proveedor Sucursal " + cbSucursales.Text + " Nro: " + item.Cells["Numero"].Value.ToString(); ;
            }

            objEPagoProveedor.TipoDocumentoProveedor = new Logica.TipoDocumentoProveedor().ObtenerUno(Convert.ToInt32(item.Cells["CodigoTipoDocumentoProveedor"].Value));
            objEPagoProveedor.TipoDocumentoProveedor.Numerador = new Logica.Numerador().ObtenerUno(objEPagoProveedor.TipoDocumentoProveedor.Numerador.Codigo);

            objEPagoProveedor.Codigo= Convert.ToInt32(item.Cells["CodigoPagoSucursal"].Value);
            objEPagoProveedor.Proveedor.Codigo = Convert.ToInt32(item.Cells["CodigoProveedor"].Value);
            objEPagoProveedor.Proveedor.Nombre = item.Cells["Proveedor"].Value.ToString();
            objEPagoProveedor.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
            objEPagoProveedor.Letra = Convert.ToChar(objEPagoProveedor.TipoDocumentoProveedor.Numerador.Letra);
            objEPagoProveedor.PuntoDeVenta = objEPagoProveedor.TipoDocumentoProveedor.Numerador.PuntoVenta;
            objEPagoProveedor.Numero = objEPagoProveedor.TipoDocumentoProveedor.Numerador.Numero;
            objEPagoProveedor.Usuario = Singleton.Instancia.Usuario;
            objEPagoProveedor.PuestoCaja = Singleton.Instancia.Puesto;
            objEPagoProveedor.Total = Convert.ToDouble(item.Cells["TotalPago"].Value);
            objEPagoProveedor.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);


            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = objEPagoProveedor.Fecha;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.SucursalDestino = Convert.ToInt32(cbSucursales.SelectedValue);


            //int pCodigoPagoSucursal = Convert.ToInt32(item.Cells["CodigoPagoSucursal"].Value);

            DataTable dtEfectivo = objLPagoProveedores.ObtenerEfectivoUno(objEPagoProveedor.Codigo, objESucursal);
            DataTable dtCheques = objLPagoProveedores.ObtenerChequesUno(objEPagoProveedor.Codigo, objESucursal);

            Entidades.Factura_Efectivo fe, fep;

            foreach (DataRow efectivo in dtEfectivo.Rows)
            {
                fe = new Entidades.Factura_Efectivo();
                fe.Moneda.Codigo = Convert.ToInt32(efectivo["CodigoMoneda"]);
                fe.Moneda.Cotizacion = Convert.ToDouble(efectivo["Cotizacion"]);
                if (objEPagoProveedor.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                    fe.Importe = Convert.ToDouble(efectivo["Importe"]);
                else
                    fe.Importe = -Convert.ToDouble(efectivo["Importe"]);
                objECaja.FacturaEfectivo.Add(fe);

                fep = new Entidades.Factura_Efectivo();
                fep.Moneda = fe.Moneda;
                fep.Importe = -fe.Importe;

                objEPagoProveedor.FacturaEfectivo.Add(fep);
            }

            Entidades.Cheque cheque;
            foreach (DataRow c in dtCheques.Rows)
            {
                cheque = new Entidades.Cheque();
                cheque.Codigo = Convert.ToInt32(c["CodigoCheque"]);
                cheque.Banco.Codigo = Convert.ToInt32(c["CodigoBanco"]);
                cheque.CuentaBancaria.Codigo = Convert.ToInt32(c["CodigoCuentaBancaria"]);
                cheque.CodigoCierreCaja = Convert.ToInt32(item.Cells["CodigoCierreCaja"].Value);
                cheque.CuentaBancaria.CuentaContable.Codigo = objEFormaPago.CuentaContable.Codigo;
                cheque.NumeroCheque = c["NroCheque"].ToString();
                cheque.FechaEmision = Convert.ToDateTime(c["FechaEmision"]);
                cheque.FechaPago = Convert.ToDateTime(c["FechaPago"]);
                cheque.Librador = c["Librador"].ToString();
                cheque.Cuit = c["CUIT"].ToString();
                cheque.Moneda.Codigo = Convert.ToInt32(c["CodigoMoneda"]);
                cheque.Moneda.Cotizacion= Convert.ToDouble(c["Cotizacion"]);
                cheque.Importe = Convert.ToDouble(c["Importe"]);
                
                objECaja.Cheques.Add(cheque);
                objEPagoProveedor.Cheques.Add(cheque);
            }

            //objECaja.FacturaEfectivo = objLPagoProveedores.ObtenerEfectivoUno(Convert.ToInt32(item.Cells["CodigoPago"].Value),objESucursal);
        }

        private void ObtenerAsientos()
        {
            #region AsientoCaja
            objEAsientoCaja = new Entidades.Asiento();
            //Controlar Descripcion
            objEAsientoCaja.Descripcion = objECaja.Observaciones;
            objEAsientoCaja.Fecha = objECaja.Fecha;
            objEAsientoCaja.FechaEmision = objECaja.Fecha;
            objEAsientoCaja.Sucursal = Singleton.Instancia.Empresa.Codigo;

            Entidades.Asiento_Detalle asientoDetalle;
            foreach (Entidades.Factura_Efectivo fe in objECaja.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                Int64 cuenta = 0;
                if (fe.Moneda.Codigo == 1)
                {

                    switch (objECaja.SucursalDestino)
                    {
                        case 1:
                            cuenta = 10101010100;
                            break;
                        case 2:
                            cuenta = 10101010600;
                            break;
                        case 3:
                            cuenta = 10101010200;
                            break;
                        case 4:
                            cuenta = 10101010300;
                            break;
                        case 5:
                            cuenta = 10101010400;
                            break;
                        case 7:
                            cuenta = 10101010500;
                            break;

                    }
                    asientoDetalle.CuentaContable.Codigo = cuenta;
                }
                else
                {
                    //int cuenta = 0;
                    switch (objECaja.SucursalDestino)
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
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                }
                else
                {
                    asientoDetalle.Debe = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                }



                objEAsientoCaja.Detalle.Add(asientoDetalle);


                asientoDetalle = new Asiento_Detalle();

                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable.Codigo = 10101010100;
                else
                    asientoDetalle.CuentaContable.Codigo = 10101020100;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                }
                else
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                }
                objEAsientoCaja.Detalle.Add(asientoDetalle);

            }

            foreach (Entidades.Cheque che in objECaja.Cheques)
            {
                asientoDetalle = new Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('I'))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                else
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsientoCaja.Detalle.Add(asientoDetalle);

                asientoDetalle = new Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10101030100;
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
                objEAsientoCaja.Detalle.Add(asientoDetalle);
            }

            #endregion

            objEAsientoPago = new Entidades.Asiento();
            //Controlar Descripcion
            //objEAsientoPago.Descripcion = objEPagoProveedor.Observaciones;
            objEAsientoPago.Descripcion = "Segun " + objEPagoProveedor.TipoDocumentoProveedor.Descripcion + " de Pago N° " + objEPagoProveedor.Numdoc + " de " + objEPagoProveedor.Proveedor.Nombre;
            objEAsientoPago.Fecha = objEPagoProveedor.Fecha;
            objEAsientoPago.FechaEmision = objEPagoProveedor.Fecha;
            objEAsientoPago.Sucursal = Singleton.Instancia.Empresa.Codigo;


            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objEPagoProveedor.CuentaContable;


            if (objEPagoProveedor.TipoDocumentoProveedor.AfectaCaja.Equals('E'))
            {
                asientoDetalle.Debe = Math.Abs(Convert.ToDouble(objEPagoProveedor.Total));
                asientoDetalle.Haber = 0;
            }
            else if (objEPagoProveedor.TipoDocumentoProveedor.AfectaCaja.Equals('I'))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(Convert.ToDouble(objEPagoProveedor.Total));
            }
            objEAsientoPago.Detalle.Add(asientoDetalle);


            foreach (Entidades.Factura_Efectivo fe in objEPagoProveedor.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                
                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable.Codigo = 10101010100;
                else
                    asientoDetalle.CuentaContable.Codigo = 10101020100;

                if (objEPagoProveedor.TipoDocumentoProveedor.AfectaCaja.Equals('E'))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                }
                else
                {
                    asientoDetalle.Debe = Math.Abs(fe.Importe * fe.Moneda.Cotizacion);
                    asientoDetalle.Haber = 0;
                }



                objEAsientoPago.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque che in objEPagoProveedor.Cheques)
            {
                /*
                asientoDetalle = new Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                if (objEPagoProveedor.TipoDocumentoProveedor.AfectaCaja.Equals('E'))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                else
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsientoPago.Detalle.Add(asientoDetalle);*/

                asientoDetalle = new Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10101030100;
                if (objEPagoProveedor.TipoDocumentoProveedor.AfectaCaja.Equals('E'))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                else
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsientoPago.Detalle.Add(asientoDetalle);
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = total > 0;
            return res;
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos() {
            objESucursal = new Entidades.Sucursal();
            objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
            objEFormaPago = new Logica.FormaDePago().ObtenerUno(3, objESucursal);
            dgvDatos.DataSource = objLPagoProveedores.ObtenerPagosPendientesConciliar(objESucursal);
            CalcularTotal();
            lblTotal.Text = total.ToString("C2");
            PonerEnRojo();
        }
    }
}
