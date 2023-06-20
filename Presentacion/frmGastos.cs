using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmGastos : frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        //Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();

        //Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        // public static string busqueda = "";
        Entidades.Caja objECaja;
        Logica.Caja objLCaja = new Logica.Caja();
        Entidades.Asiento objEAsiento;

        private double totalGastos=0;
        private double valores = 0;
        
        public frmGastos()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }

        private void ConfiguracionInicial() {
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
        }

        private void Titulo()
        {
            this.Text = "GASTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 100);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbCuenta);
            //Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvGastos);
            tpConceptos.BackColor = frmColor.Color;
            tpFormasDePago.BackColor = frmColor.Color;
            //tpChequesTerceros.BackColor = frmColor.Color;
            ucFormasPagoCompras.BackColor = frmColor.Color;
            ucFormasPagoCompras.FormularioInicial = this;
            dgvGastos.Columns["CuentaContable"].Width = 350;
            // Utilidades.Grilla.Formato(dgvDatos);
            // dgvDatos.Columns["Tipo"].Width = 70;
            // dgvDatos.Columns["Importe3"].Width = 90;


        }
        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbCuenta, objLCuentaContable.ObtenerGastos(), "Codigo", "Nombre");
              //  Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosComprasFormasPago(), "Codigo", "Descripcion");
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
            if (txtImporte.Text.Length>0 && Convert.ToDouble(txtImporte.Text)==0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }


            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CodigoCuentaContable"].Value) == Convert.ToInt32(cbCuenta.SelectedValue))
                {
                        MessageBox.Show("Gasto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         return;
                }
            }


            dgvGastos.Rows.Add(Convert.ToInt32(cbCuenta.SelectedValue), cbCuenta.Text.ToString(), Convert.ToDouble(txtImporte.Text.Trim()));
            
            Utilidades.Combo.SeleccionarPrimerValor(cbCuenta);
            //CargarTotales();
            totalGastos += Convert.ToDouble(txtImporte.Text.Trim());
            cbCuenta.Focus();
            txtImporte.Text = "";
            MostrarImportes();
        }

        private bool ValidarGasto()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuenta);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtImporte) );
            return res;
        }
        /*
        public double TotalGastos
        {
            get
            {
                double total = 0;
                foreach (DataGridViewRow fila in dgvGastos.Rows)
                {
                    total += Convert.ToDouble(fila.Cells["Importe"].Value);
                }
                return Utilidades.Redondear.DosDecimales(total);
            }
        }*/
        /*private void CargarTotales()
        {
                lblTotal.Text = TotalGastos.ToString("C2");
        }*/

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tcGastos.SelectedIndex = 1;
        }



        private void tcGastos_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tcGastos.TabPages[e.Index];
            /*
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;  //optional

            // This is the rectangle to draw "over" the tabpage title
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

            // This is the default colour to use for the non-selected tabs*/
            SolidBrush sb = new SolidBrush(Color.AntiqueWhite);
            
            // This changes the colour if we're trying to draw the selected tabpage
            if (tcGastos.SelectedIndex == e.Index)
                sb.Color = frmColor.Color;
            
            // Colour the header of the current tabpage based on what we did above
            g.FillRectangle(sb, e.Bounds);

            //Remember to redraw the text - I'm always using black for title text
            g.DrawString(tp.Text, tcGastos.Font, new SolidBrush(Color.Black), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));// sf);
            
        }
        private void MostrarImportes() {
            // lblValores.Text = valores.ToString("C2");
            valores = ucFormasPagoCompras.valores;
            lblValores.Text = valores.ToString("C2");
            lblTotal.Text = totalGastos.ToString("C2");
            lblSaldo.Text = Saldo().ToString("C2");
        }

        private double Saldo() {
            return Utilidades.Redondear.DosDecimales(totalGastos) - Utilidades.Redondear.DosDecimales(valores);
        }
        private void ActualizarValores(object sender, EventArgs e) {
            MostrarImportes();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
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

                //objLCaja.Agregar(objECaja, objEAsiento);
                /*
                if ((objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == true) || objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
                {
                    objLFacturaCompra.AgregarAjustes(objEFacturaCompra, objEAsiento);
                }
                else
                {
                    if ((objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == false))
                    {
                        objLFacturaCompra.ValidarStock(objEFacturaCompra);
                    }
                    objLFacturaCompra.Agregar(objEFacturaCompra, objEAsiento);
                }*/
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
            
            objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(1);

            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = dtpFecha.Value;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Observaciones = txtObservaciones.Text.Trim();

            ucFormasPagoCompras.ObtenerDatos();
            objECaja.FacturaEfectivo = ucFormasPagoCompras.Efectivos;
            objECaja.Cheques = ucFormasPagoCompras.Cheques;
            objECaja.Tranferencias = ucFormasPagoCompras.Tranferencias;
            objECaja.ChequesPropios = ucFormasPagoCompras.ChequesPropios;
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
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;


            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoCuentaContable"].Value));
                asientoDetalle.Debe = Convert.ToDouble(fila.Cells["Importe"].Value);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            Entidades.FormaDePago objEFormaDePago= new Entidades.FormaDePago();
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
            res=Utilidades.Validar.GrillaVacia(dgvGastos);
            return res;
        }

        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbCuenta);
            txtImporte.Text = "";
            dgvGastos.Rows.Clear();
            txtObservaciones.Text = "";
            ucFormasPagoCompras.Limpiar();
            tcGastos.SelectedIndex = 0;
            totalGastos = 0;
            valores = 0;
            dtpFecha.Value = DateTime.Now;
            MostrarImportes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
