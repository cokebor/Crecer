using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmEgresosCaja : frmColor
    {

        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.TipoDocumentoCaja objLTipoDocCaja = new Logica.TipoDocumentoCaja();
        Logica.Caja objLCaja = new Logica.Caja();
        Logica.Movimiento objLMovimiento = new Logica.Movimiento();
        List<Entidades.Cheque> cheques;
       // List<Entidades.Cheque> chequesPropios;

        List<Entidades.Factura_Efectivo> listaFacturaEfectivo;
        Entidades.Cheque cheque;
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Caja objECaja = new Caja();
        frmChequesCartera frmCheque = new frmChequesCartera();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        public static string busqueda = "";
        public frmEgresosCaja()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucChequesTerceros.btnChequesTerceros.Click += new System.EventHandler(this.btnChequesTerceros_Click);
            Formatos();
            CargarValores();
            ListaFacturaEfectivo = new List<Factura_Efectivo>();
            Cheques = new List<Cheque>();
            this.ucContado.cbMoneda.SelectedIndexChanged += CbMoneda_SelectedIndexChanged;
        }

        private void CbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int pCodigoMoneda = Convert.ToInt32(ucContado.cbMoneda.SelectedValue);
                ucContado.txtImporte.Text= objLMovimiento.ObtenerMontoEfectivoSinCierre(Singleton.Instancia.Puesto, pCodigoMoneda).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Titulo()
        {
            this.Text = "EGRESO DE CAJA";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe"].Width = 90;
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 100);
        }


        public void CargarValores()
        {
            try
            {
                    Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerParaEgreso(), "Codigo", "Descripcion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cbFormasDePago.Text.Equals("CONTADO"))
             {
                 ucContado.Visible = true;
                 ucChequesTerceros.Visible = false;

             }
             else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS"))
             {
                 ucContado.Visible = false;
                 ucChequesTerceros.Visible = true;
             }
             objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
             
        }

        private void btnAgregarEfectivo_Click(object sender, EventArgs e)
        {
            if (this.ucContado.ValidarEfectivo().Equals(true))
            {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucContado.txtImporte.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1 && Convert.ToInt32(fila.Cells["CodigoMoneda"].Value) == Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue))
                {
                    MessageBox.Show("Forma de Pago ya ingresada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double cotizacion = Convert.ToDouble(this.ucContado.lblCotizacion.Text);
            double importe = Convert.ToDouble(this.ucContado.txtImporte.Text);
            double total =/* cotizacion **/ importe;

            if (total <= 0) {
                MessageBox.Show("El monto a Egresar debe ser mayor a 0.!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C4"), objEFormaDePago.CuentaContable.Codigo);
            //Valores += total;
            Total += total;
            ActualizarValores();
            LimpiarEfectivo();
        }

        private double total;
        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public void ActualizarValores()
        {
            lblTotal.Text = Total.ToString("C2");
        }

        private void LimpiarEfectivo()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucContado.cbMoneda);
            this.ucContado.txtImporte.Text = "";
        }

        private void cbFormasDePago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                //Valores -= total;
                Total -= total;
                ActualizarValores();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                this.cbFormasDePago.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value);

                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 1)
                {
                    this.ucContado.Visible = true;
                    this.ucChequesTerceros.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    Total -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }


                

                else
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3)
                {
                    for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                        {
                            double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                            dgvDatos.Rows.RemoveAt(i);
                            //Valores -= total;
                            Total -= total;
                            ActualizarValores();
                        }
                    }

                    this.ucContado.Visible = false;
                    this.ucChequesTerceros.Visible = true;
       
                        frmCheque.ShowDialog();
                    CargarCheques();
          
                }

                ActualizarValores();
                
    
            }
        }

        private void btnChequesTerceros_Click(object sender, EventArgs e)
        {
            for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(dgvDatos.Rows[i].Cells["FormaDePago"].Value) == 3)
                {
                    double total = Convert.ToDouble(dgvDatos.Rows[i].Cells["Cotizacion"].Value) * Convert.ToDouble(dgvDatos.Rows[i].Cells["Importe2"].Value);
                    dgvDatos.Rows.RemoveAt(i);
                    Total -= total;
                    ActualizarValores();
                }
            }

            frmCheque.ShowDialog();
            CargarCheques();
         //   Utilidades.Formularios.Abrir(this.MdiParent,frmCheque);
        }

        private void CargarCheques() {
            try
            {
                if (busqueda.Equals("ChequesTerceros"))
                {

                    foreach (DataGridViewRow dr in frmCheque.dgvDatos.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Seleccionado"].Value))
                        {
                            objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
                            double total = Convert.ToDouble(dr.Cells["Cotizacion"].Value) * Convert.ToDouble(dr.Cells["Importe2"].Value);
                            if (Convert.ToInt32(dr.Cells["CodigoCuentaContable"].Value) == 0)
                                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, objEFormaDePago.CuentaContable.Codigo, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value, dr.Cells["Codigo"].Value);
                            else
                                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, dr.Cells["CodigoMoneda"].Value, dr.Cells["Banco"].Value + "  Nº: " + dr.Cells["Numero"].Value + " - " + dr.Cells["Moneda"].Value, dr.Cells["Cotizacion"].Value, dr.Cells["Importe2"].Value, dr.Cells["Importe"].Value, dr.Cells["CodigoCuentaContable"].Value, dr.Cells["CodigoBanco"].Value, dr.Cells["FechaEmision"].Value, dr.Cells["FechaPago"].Value, dr.Cells["Librador"].Value, dr.Cells["Numero"].Value, dr.Cells["CUIT"].Value, 0, dr.Cells["Codigo"].Value, dr.Cells["Codigo"].Value);
                            //Valores += total;
                            Total += total;
                            ActualizarValores();
                        }

                    }
                }


                busqueda = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Factura_Efectivo> ListaFacturaEfectivo
        {
            get
            {
                return listaFacturaEfectivo;
            }

            set
            {
                listaFacturaEfectivo = value;
            }
        }

        public List<Cheque> Cheques
        {
            get
            {
                return cheques;
            }

            set
            {
                cheques = value;
            }
        }
        /*
        public List<Cheque> ChequesPropios
        {
            get
            {
                return chequesPropios;
            }

            set
            {
                chequesPropios = value;
            }
        }*/
        public void ObtenerDatos()
        {
            ListaFacturaEfectivo.Clear();
            Cheques.Clear();
         //   ChequesPropios.Clear();

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {



                Entidades.Factura_Efectivo facturaEfectivo;
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1)
                {
                    facturaEfectivo = new Entidades.Factura_Efectivo();
                    facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    facturaEfectivo.Importe =  Convert.ToDouble(fila.Cells["Importe2"].Value);
                    listaFacturaEfectivo.Add(facturaEfectivo);
                }

                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3)
                {
                    cheque = new Entidades.Cheque();
                    cheque.Codigo = Convert.ToInt32(fila.Cells["CodigoCheque"].Value);
                    cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    cheque.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    cheque.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CuentaContable"].Value); ;
                    cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                    cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                    cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                    cheque.Librador = fila.Cells["Librador"].Value.ToString();
                    cheque.Cuit = fila.Cells["CUIT"].Value.ToString();
                    cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    cheques.Add(cheque);
                }
               /* if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 6)
                {
                    cheque = new Entidades.Cheque();
                    cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    cheque.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    cheque.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt32(fila.Cells["CuentaContable"].Value);
                    cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                    cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                    cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                    cheque.Librador = fila.Cells["Librador"].Value.ToString();
                    cheque.Cuit = fila.Cells["CUIT"].Value.ToString();
                    cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    chequesPropios.Add(cheque);
                }*/
            }
        }

        private void CargarInfo()
        {
            objECaja = new Entidades.Caja();

            objECaja.TipoDocumentoCaja = objLTipoDocCaja.ObtenerUno(7);

            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = DateTime.Now;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Observaciones = txtObservaciones.Text.Trim();

            ObtenerDatos();

            objECaja.FacturaEfectivo.Clear();
            objECaja.FacturaEfectivo = ListaFacturaEfectivo;
            objECaja.Cheques.Clear();
            objECaja.Cheques = Cheques;

        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {


                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                CargarInfo();
                Asiento();

                int codigo = objLCaja.Agregar(objECaja, objEAsiento, "Egreso");
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Informe(Logica.Informes.CajaEgresosSucursales(codigo, Singleton.Instancia.Empresa.NombreSucursal), "repCajaEgresoSucursal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Informe(List<DataTable> lista, String informe)
        {
            try
            {
                Utilidades.Formularios.AbrirFuera(new frmInformes("EGRESO DE CAJA", lista, informe));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar() {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Total = 0;
            ActualizarValores();
        }




        private void Asiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECaja.Fecha;
            objEAsiento.FechaEmision = objECaja.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = objECaja.TipoDocumentoCaja.Descripcion + "  N° " + objECaja.Numdoc;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            Entidades.Asiento_Detalle asientoDetalle;
            /*
            asientoDetalle = new Entidades.Asiento_Detalle();
            if (cbLiquidaciones.Checked)
                asientoDetalle.CuentaContable.Codigo = 201010200;
            else
                asientoDetalle.CuentaContable.Codigo = 201010100;

            if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            {
                asientoDetalle.Debe = Convert.ToDouble(frmFormas.Total);
                asientoDetalle.Haber = 0;
            }
            else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Convert.ToDouble(frmFormas.Total);
            }
            objEAsiento.Detalle.Add(asientoDetalle);
            */

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
                asientoDetalle.Haber = fe.Importe * fe.Moneda.Cotizacion;

                objEAsiento.Detalle.Add(asientoDetalle);

                
                asientoDetalle = new Asiento_Detalle();

                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable.Codigo = 10101010100;
                else
                    asientoDetalle.CuentaContable.Codigo = 10101020100;

                asientoDetalle.Debe = fe.Importe * fe.Moneda.Cotizacion;
                asientoDetalle.Haber = 0;

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

                asientoDetalle = new Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10101030100;

                asientoDetalle.Debe= che.Importe * che.Moneda.Cotizacion;
                asientoDetalle.Haber = 0;
                asientoDetalle.Cheque = che;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

        }

    }
}
