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
    public partial class frmFormasDePagoSaldoInicial : frmColor
    {
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Moneda objLMoneda = new Logica.Moneda();

        List<Entidades.Cheque> cheques;

        List<Entidades.Factura_Efectivo> listaFacturaEfectivo;
        Entidades.Cheque cheque;
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

       // frmChequesCartera frmCheque = new frmChequesCartera();
       // frmChequesCliente frmChequeCliente = new frmChequesCliente();

        private string tipodocumento;
        private double efectivo;
        private double dolares;
        public frmFormasDePagoSaldoInicial(string tipoDocumento, Form f)
        {
            Cheques = new List<Entidades.Cheque>();
            ListaFacturaEfectivo = new List<Entidades.Factura_Efectivo>();
            InitializeComponent();
            Tipodocumento = tipoDocumento;
            FormularioAnterior = f;
            TipoDoc = "SI";
            ConfiguracionInicial();

            this.ucContado.btnAgregar.Click += new System.EventHandler(this.btnAgregarEfectivo_Click);
            this.ucCheque.btnAgregar.Click += new System.EventHandler(this.btnAgregarCheque_Click);
            this.ucCheque.cmsBanco.Items["agregarToolStripMenuItem"].Click += new EventHandler(this.btnAgregarBanco_Click);
          //  frmChequeProveedor = new frmChequesProveedor(Proveedor);
        }

        private int codigoRemito;


        private Form formularioAnterior;
        public Form FormularioAnterior
        {
            get
            {
                return formularioAnterior;
            }

            set
            {
                formularioAnterior = value;
            }
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

        private string tipoDoc;

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

        public string Tipodocumento
        {
            get
            {
                return tipodocumento;
            }

            set
            {
                tipodocumento = value;
            }
        }


        public string TipoDoc
        {
            get
            {
                return tipoDoc;
            }

            set
            {
                tipoDoc = value;
            }
        }

        public int CodigoRemito
        {
            get
            {
                return codigoRemito;
            }

            set
            {
                codigoRemito = value;
            }
        }

        public double Efectivo
        {
            get
            {
                return efectivo;
            }

            set
            {
                efectivo = value;
            }
        }

        public double Dolares
        {
            get
            {
                return dolares;
            }

            set
            {
                dolares = value;
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);

            Formatos();
                CargarValoresVentas();

        }
        private void Titulo()
        {
            this.Text = "FORMAS DE PAGO";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe"].Width = 90;
        }

        public void CargarValoresVentas()
        {
            try
            {
                    Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosVentasSaldoInicialFormasPago(), "Codigo", "Descripcion");
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
                ucCheque.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("CHEQUE DE TERCEROS") && Tipodocumento.Equals("Ventas") && TipoDoc.Equals("SI"))
            {
                ucContado.Visible = false;
                ucCheque.Visible = true;
            }

          
            objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
        }



        private void frmFormasDePago_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregarBanco_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmBancos());
            busqueda = "Bancos";
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
            double total = cotizacion * importe;

            if (Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue) == 1)
            {
                if (TipoDoc.Equals("CR") && Efectivo < total)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else {
                if (TipoDoc.Equals("CR") && Dolares < importe)
                {
                    MessageBox.Show("Importe no puede ser mayor al ingresado en el Contra Recibo.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C4"),objEFormaDePago.CuentaContable.Codigo);
            //Valores += total;
            Total += total;
            ActualizarValores();
            LimpiarEfectivo();
        }

        private void LimpiarEfectivo()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucContado.cbMoneda);
            this.ucContado.txtImporte.Text = "";
        }

        private void LimpiarCheque()
        {
            //this.ucCheque.LimpiarCheques();
            //this.ucCheque.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            
        }

        private void LimpiarCheque2()
        {
            //this.ucCheque.LimpiarCheques();
            //this.ucCheque.LimpiarCheques();
            this.ucCheque.LimpiarCheques();
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);

        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {

            Entidades.Cheque cheque = this.ucCheque.Cheque();
            if (cheque.Librador != null)
            {

                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3 && Convert.ToInt32(fila.Cells["CodigoBanco"].Value) == Convert.ToInt32(cheque.Banco.Codigo) && fila.Cells["NumeroCheque"].Value.Equals(cheque.NumeroCheque))
                    {
                        MessageBox.Show("Cheque ya ingresado en este comprobante.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (Utilidades.Validar.ValidarFechas(cheque.FechaEmision, cheque.FechaPago).Equals(false))
                {
                    MessageBox.Show("Fecha Emision no puede ser inferior a Fecha de Pago", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*if (!Utilidades.Validar.ValidaCUIT(this.ucCheque.ucCUIT.Valor))
                {
                    MessageBox.Show("CUIT invalido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucCheque.ucCUIT.txtCUIL1.Focus();
                    return;
                }*/


                double total = cheque.Moneda.Cotizacion * cheque.Importe;
                dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, cheque.Moneda.Codigo, cheque.Banco.Descripcion + "  Nº: " + cheque.NumeroCheque + " - " + cheque.Moneda.Descripcion, cheque.Moneda.Cotizacion, cheque.Importe, total.ToString("C4"), objEFormaDePago.CuentaContable.Codigo, cheque.Banco.Codigo, cheque.FechaEmision, cheque.FechaPago, cheque.Librador, cheque.NumeroCheque, cheque.Cuit);
                //Valores += total;
                Total += total;
                LimpiarCheque2();

                //ucCheque.LimpiarCheques();
                ActualizarValores();
            }
        }
        
  
        public void ActualizarValores()
        {
            /*Saldo = Total - Valores;
            lblValores.Text = Valores.ToString("C4");
            lblSaldo.Text = Saldo.ToString("C4");*/
            lblTotal.Text = Total.ToString("C2");
        }

        public static string busqueda = "";
        private void frmFormasDePago_Activated(object sender, EventArgs e)
        {
            try
            {
                if (busqueda.Equals("Bancos"))
                    this.ucCheque.ObtenerBancos();
                
                    busqueda = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ObtenerDatos()
        {
            ListaFacturaEfectivo.Clear();
            Cheques.Clear();

            int mult = 1;
            if (tipoDoc.Equals("CR"))
            {
                mult = -1;
            }
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                Entidades.Factura_Efectivo facturaEfectivo;
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1)
                {
                    facturaEfectivo = new Entidades.Factura_Efectivo();
                    facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    facturaEfectivo.Importe = mult * Convert.ToDouble(fila.Cells["Importe2"].Value);
                    listaFacturaEfectivo.Add(facturaEfectivo);
                }

                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 3 )
                {
                    cheque = new Entidades.Cheque();
                    cheque.Codigo = Convert.ToInt32(fila.Cells["CodigoCheque"].Value);
                    cheque.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                    cheque.CuentaBancaria.Codigo= Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                    cheque.CuentaBancaria.CuentaContable.Codigo= Convert.ToInt64(fila.Cells["CuentaContable"].Value); ;
                    cheque.NumeroCheque = fila.Cells["NumeroCheque"].Value.ToString();
                    cheque.FechaEmision = Convert.ToDateTime(fila.Cells["FechaEmision"].Value);
                    cheque.FechaPago = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                    cheque.Librador = fila.Cells["Librador"].Value.ToString();
                    cheque.Cuit =  fila.Cells["CUIT"].Value.ToString();
                    cheque.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                    cheque.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                    cheques.Add(cheque);
                }
            }
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
                    this.ucCheque.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    Total -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }


                
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 3 && Tipodocumento.Equals("Ventas"))
                {
                    this.ucContado.Visible = false;
                    this.ucCheque.Visible = true;
                    this.ucCheque.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucCheque.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucCheque.dtpEmision.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaEmision"].Value);
                    this.ucCheque.dtpPago.Value = Convert.ToDateTime(dgvDatos.CurrentRow.Cells["FechaPago"].Value);
                    this.ucCheque.txtLibrador.Text = dgvDatos.CurrentRow.Cells["Librador"].Value.ToString();
                    this.ucCheque.ucCUIT.CargarCUIT(dgvDatos.CurrentRow.Cells["CUIT"].Value.ToString());
                    this.ucCheque.txtNumero.Text = dgvDatos.CurrentRow.Cells["NumeroCheque"].Value.ToString();
                    this.ucCheque.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucCheque.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    Total -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }
                ActualizarValores();
                

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ((frmSaldoInicialCaja)FormularioAnterior).Total1 = Total;
            //((frmClientePagos)FormularioAnterior).lblTotal.Text = Total.ToString("C2");
            this.Hide();
        }

        private void ucChequesTerceros_Load(object sender, EventArgs e)
        {

        }


    }
}
