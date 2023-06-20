using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicialCaja : Presentacion.frmColor
    {
        
       // Entidades.PagoCliente objEPago = new Entidades.PagoCliente();
        Entidades.CajaInicial objECaja = new Entidades.CajaInicial();
        Entidades.TipoDocumentoCaja objETipoDocumentoCaja = new Entidades.TipoDocumentoCaja();


       // Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.TipoDocumentoCaja objLogicaTipoDocumentoCaja = new Logica.TipoDocumentoCaja();
        Logica.CajaInicial objLCajaInicial = new Logica.CajaInicial();
       // Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
       // Logica.PagoCliente objLPago = new Logica.PagoCliente();
       
        //Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();

        frmFormasDePagoSaldoInicial frmFormas;

        private double total1;

        private double total;
        private double dolares;
        public double Total
        {
            get
            {
                return total1; //+TotalImpuestos;
            }
        }

        public double Total1
        {
            get
            {
                return total1;
            }

            set
            {
                total1 = value;
                lblTotal.Text = Total1.ToString("C2");
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

        public frmSaldoInicialCaja()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            frmFormas = new frmFormasDePagoSaldoInicial("Ventas", this);
            frmFormas.TipoDoc = "SI";
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
        }

        private void Titulo()
        {
            this.Text = "SALDO INICIAL CAJA";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 100);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void BotonesInicial()
        {
         //   Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        
        
        private void btnFormaDePago_Click(object sender, EventArgs e)
        {
            frmFormas.ActualizarValores();
            Utilidades.Formularios.Abrir(this.MdiParent, frmFormas);
            //frmFormas.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            DateTime Fecha;
            Fecha = dtFecha.Value.Date;
           
            if (frmFormas.Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
          
            try
            {
                CargarValores();

                        if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }




                // int codigo=objLPago.Agregar(objEPago, objEAsiento, codigoRecibo);
                objLCajaInicial.Agregar(objECaja);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);

            objETipoDocumentoCaja = new Entidades.TipoDocumentoCaja();
            
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            objECaja = new Entidades.CajaInicial();
           
            
            frmFormas = new frmFormasDePagoSaldoInicial("Ventas", this);
            Total1 = 0;
            
            btnFormaDePago.Enabled = false;
            
        }
        
        
        
        private void CargarValores()
        {


              objECaja = new Entidades.CajaInicial();
            // objEPago.TipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
            objETipoDocumentoCaja = objLogicaTipoDocumentoCaja.ObtenerUno(8);
            objECaja.TipoDocumentoCaja = objETipoDocumentoCaja;

            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Fecha = dtFecha.Value;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Usuario = Singleton.Instancia.Usuario;


            objECaja.Observaciones = txtObservaciones.Text.Trim();

            frmFormas.ObtenerDatos();
            objECaja.FacturaEfectivo.Clear();
            objECaja.FacturaEfectivo = frmFormas.ListaFacturaEfectivo;
            objECaja.Cheques.Clear();
            objECaja.Cheques = frmFormas.Cheques;

        }


 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

   
   
   
        private double efectivo;

   
    }



}