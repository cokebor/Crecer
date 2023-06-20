using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmClientePagos : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.PagoCliente objEPago = new Entidades.PagoCliente();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago;
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();


        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLogicaTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.PagoCliente objLPago = new Logica.PagoCliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        frmFormasDePagoClientes frmFormas;
        frmImputacionClientesPagos frmImputacionPagos;

        private double total1;

        //private double total;
        private double totalImpuestos;
       // private double dolares;
        public double Total
        {
            get
            {
                // lblTotal.Text = (total1 + TotalImpuestos).ToString("C2");
                return total1;
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
                total1 -= TotalImpuestos;
                lblTotal.Text = Total1.ToString("C2");
            }
        }

        public double TotalImpuestos
        {
            get
            {
                return totalImpuestos;
            }

            set
            {
                totalImpuestos = value;
                //lblTotal.Text = Total1.ToString("C2");
            }
        }
        /*
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
        */
        public frmClientePagos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            //frmFormas.TipoDoc = "RC";
            frmFormas = new frmFormasDePagoClientes("Ventas", this);
            
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");

        }

        private void Titulo()
        {
            this.Text = "PAGOS DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 150);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoImpuesto, 2);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 9);
            Utilidades.CajaDeTexto.LimiteTamaño(txtAgente, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNroComprobante, 8);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbRecibos);
        }

        private void BotonesInicial()
        {
         //   Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            totalImpuestos = 0;
            try
            {


                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {



                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objEntidadCliente != null) { 
                        lblNombreProveedor.Text = objEntidadCliente.Nombre;
                        frmImputacionPagos = new frmImputacionClientesPagos(objEntidadCliente);
                    }
                    else
                    {
                        objEntidadCliente = new Entidades.Cliente();
                        frmImputacionPagos = new frmImputacionClientesPagos();
                        lblNombreProveedor.Text = "";
                        cbTodosLosRecibos.Visible = false;
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                    }
                }
                else
                {
                    objEntidadCliente = null;
                    frmFormas = new frmFormasDePagoClientes("Ventas", this);
                    frmFormas.TipoDoc = "RC";
                    lblNombreProveedor.Text = "";
                    cbTodosLosRecibos.Visible = false;
                    lblRecibo.Visible = false;
                    cbRecibos.Visible = false;
                }
               // Efectivo = 0;
              //  Dolares = 0;
                ObtenerComprobantes();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ObtenerComprobantes()
        {
            if (objEntidadCliente != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLogicaTipoDocumentoCliente.ObtenerTodosDeTipoPagos(objEntidadCliente.TipoInscripcion.Codigo), "Codigo", "Descripcion");
            }
            else
            {
                cbTipoComprobante.DataSource = null;
            }
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
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

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void btnFormaDePago_Click(object sender, EventArgs e)
        {
            if (cbRecibos.Visible) {
                frmFormas.TipoDoc = "CR";
                frmFormas.CodigoRemito = Convert.ToInt32(cbRecibos.SelectedValue);
                /*frmFormas.Efectivo = Efectivo;
                frmFormas.Dolares = Dolares;*/
            }
            else
            {
                frmFormas.CodigoRemito = 0;
                frmFormas.TipoDoc = "RC";
            }
                
            frmFormas.ActualizarValores();
            //frmFormas.Show();
            Utilidades.Formularios.Abrir(this.MdiParent, frmFormas);
            //frmFormas.Show();
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
            
           
            if (frmFormas.Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
          

            /*
            if (btnFormaDePago.Enabled)
            {
                if (frmFormas.Total == 0)
                {
                    MessageBox.Show("El saldo del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            */
            try
            {
                CargarValoresPago();

                
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC") && (objEPago.FacturasImputacion.Count == 0 || frmImputacionPagos.Disponible != 0))
                {
                    if (MessageBox.Show("Comprobante con Saldo sin Imputar.\n¿Desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                


                else {
                    if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC")){
                        if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else {
                        if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante? Se eliminaran las imputaciones del Recibo seleccionado", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                
                Asiento();
                int codigoRecibo;
                if (cbRecibos.Visible)
                    codigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                else
                    codigoRecibo = 0;

                int codigo=objLPago.Agregar(objEPago, objEAsiento, codigoRecibo);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
              //  Informe(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void Informe(int codigo)
        {
            List<DataTable> lista = new List<DataTable>();
            lista.Add(new Logica.Empresa().ObtenerDataTable());
            lista.Add(new Logica.Pago().ObtenerDataTable(codigo));
            lista.Add(new Logica.Pago().ObtenerEfectivoUno(codigo));
            lista.Add(new Logica.Pago().ObtenerChequesUno(codigo));
            lista.Add(new Logica.Pago().ObtenerImputacionesUno(codigo));
            Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
        }  
        */

        /*    
        private double CalcularImputacion() {
            double total=0;
            foreach (Entidades.FacturaCompraImputacion fci in objEPago.FacturasImputacion) {
                total += fci.Monto;
            }
            return total;
        }   */    
        
        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);

            objEntidadCliente = new Entidades.Cliente();
            objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            objEPago = new Entidades.PagoCliente();
            //objEFacturaDetalle = new Entidades.Factura_Detalle();
            objEAsiento = new Entidades.Asiento();
            
            frmFormas = new frmFormasDePagoClientes("Ventas", this);
            frmFormas.TipoDoc = "RC";
            Total1 = 0;

            //frmImputacionPagos.Disponible = 0;
            //frmImputacionPagos = new frmImputacionClientesPagos();
            btnFormaDePago.Enabled = false;
            btnImputacion.Enabled = false;
            TotalImpuestos = 0;
            Total1 = 0;
            txtCodigoImpuesto.Text = "";
            txtAgente.Text = "";
            txtNroComprobante.Text = "";
        }
        
        private void Asiento()
        {
                CargarAsiento();
         }

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEPago.Fecha;
            objEAsiento.FechaEmision = objEPago.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            //if(objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = "Segun " + objEPago.TipoDocumentoCliente.Descripcion +" de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
           /* else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR"))
                objEAsiento.Descripcion = "Segun Contra Recibo de pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
            */
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();

            double valor=0;

            foreach (Entidades.FacturaImpuesto fi in objEPago.Impuestos)
            {
                valor += fi.Importe;
            }

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
                if (objEPago.ChequeRechazado) {
                    asientoDetalle.CuentaContable.Codigo = 10105140000;
                }
                else { 
                    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
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
                    asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
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
                    asientoDetalle.Haber = cd.Importe * cd.Moneda.Cotizacion;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            foreach (Entidades.FacturaImpuesto fi in objEPago.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = fi.Impuesto.CuentaContable;
                if (objETipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
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
            /*
            foreach (Entidades.Cheque che in objEPago.ChequesPropios)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
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
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            */
            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = Singleton.Instancia.Empresa.CuentaContableCuentaCorrienteClientes.Codigo;
            
            
            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Convert.ToDouble(Total);
            }
            else if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR")) {
                asientoDetalle.Debe = Convert.ToDouble(Total);
                asientoDetalle.Haber = 0;
            }
            objEAsiento.Detalle.Add(asientoDetalle);
        
    
        }
        
        
        private void CargarValoresPago()
        {
            

                objEPago = new Entidades.PagoCliente();
                objEPago.TipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                //objEPago.TipoDocumentoProveedor.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
                //objEFacturaCompra.Numero = ucNumeroComprobante.Valor;
                objEPago.TipoDocumentoCliente.Numerador = new Logica.Numerador().ObtenerUno(objEPago.TipoDocumentoCliente.Numerador.Codigo);
                objEPago.Cliente.Codigo = Convert.ToInt32(txtCodigoCliente.Text.Trim());
                objEPago.Fecha = dtFecha.Value;
                objEPago.Letra = Convert.ToChar(objEPago.TipoDocumentoCliente.Numerador.Letra);
                objEPago.PuntoDeVenta = objEPago.TipoDocumentoCliente.Numerador.PuntoVenta;
                objEPago.Numero = objEPago.TipoDocumentoCliente.Numerador.Numero;
                objEPago.Usuario = Singleton.Instancia.Usuario;
                objEPago.PuestoCaja = Singleton.Instancia.Puesto;
                objEPago.Observaciones = txtObservaciones.Text.Trim();
            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC")) { 
                    objEPago.Total = Total;//Convert.ToDouble(lblTotal.Text.Replace("$", ""));
                                           //objEPago.Total=lblTotal
            }
            else { 
                objEPago.Total = -Total;
                objEPago.ChequeRechazado = cbChequeRechazado.Checked;
            }
            frmFormas.ObtenerDatos();
                objEPago.FacturaEfectivo.Clear();
                objEPago.FacturaEfectivo = frmFormas.ListaFacturaEfectivo;
                objEPago.Cheques.Clear();
                objEPago.Cheques = frmFormas.Cheques;
                objEPago.Tranferencias.Clear();
                objEPago.Tranferencias = frmFormas.Tranferencias;
                objEPago.CreditosDebitos.Clear();
            objEPago.CreditosDebitos = frmFormas.CreditosDebitos;


            //objEPago.ChequesPropios.Clear();
            // objEPago.ChequesPropios = frmFormas.ChequesPropios;
            objEPago.FacturasImputacion.Clear();
               objEPago.FacturasImputacion = frmImputacionPagos.ObtenerDatos();
            foreach (DataGridViewRow imp in dgvDatos.Rows)
            {
                Entidades.FacturaImpuesto fi = new Entidades.FacturaImpuesto();
                fi.Impuesto.Codigo = Convert.ToInt32(imp.Cells["Codigo"].Value);
                fi.Impuesto.CuentaContable.Codigo = Convert.ToInt64(imp.Cells["CuentaContable"].Value);
                fi.Impuesto.Fecha = Convert.ToDateTime(imp.Cells["Fecha"].Value);
                fi.Impuesto.Nroagente = Convert.ToInt32(imp.Cells["NroAgente"].Value);
                fi.Impuesto.NroComprobante = Convert.ToInt32(imp.Cells["NroComprobante"].Value);
                if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                    fi.Importe = Convert.ToDouble(imp.Cells["Importe"].Value);
                else
                    fi.Importe = -Convert.ToDouble(imp.Cells["Importe"].Value);
                objEPago.Impuestos.Add(fi);
            }

            if (objEPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
            {
                
                objEPago.Imputacion = 'T';
            }
            else {
                objEPago.Imputacion = 'F';
            }
        }
        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante);
            if (cbRecibos.Visible) {
                res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbRecibos);
            }
            return res;
        }
        
        private void btnImputacion_Click(object sender, EventArgs e)
        {
            if (!lblNombreProveedor.Text.Equals(""))
            {
                frmImputacionPagos.Total1 = Convert.ToDouble(Total);
                //  frmImputacionPagos.Total1 = Convert.ToDouble(lblTotal.Text.Replace("$", ""));
                frmImputacionPagos.Aplicado();
                //frmImputacionPagos
                frmImputacionPagos.ShowDialog();
            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoComprobante.SelectedIndex != -1)
            {
                try
                {
                    frmFormas = new frmFormasDePagoClientes("Ventas", this);
                    //frmFormas.TipoDoc = "RC";
                    lblTotal.Text = Convert.ToDouble("0").ToString("C2");
                    objETipoDocumentoCliente = objLogicaTipoDocumentoCliente.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                    frmFormas.TipoDoc = objETipoDocumentoCliente.TipoDoc.Codigo;
                    frmFormas.Cliente = objEntidadCliente;
                    dgvDatos.Rows.Clear();
                    if (objETipoDocumentoCliente.TipoDoc.Codigo.Equals("RC"))
                    {
                        btnImputacion.Enabled = true;
                        btnFormaDePago.Enabled = true;
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                        cbChequeRechazado.Visible = false;
                        cbChequeRechazado.Checked = false;
                       // Efectivo = 0;
                      //  Dolares = 0;
                        cbTodosLosRecibos.Visible = false;                   }
                    else
                    {
                        //frmFormas.TipoDoc = "CR";
                        btnImputacion.Enabled = false;
                        btnFormaDePago.Enabled = true;
                        lblRecibo.Visible = true;
                        cbRecibos.Visible = true;
                        cbChequeRechazado.Visible = true;
                        cbChequeRechazado.Checked = false;
                        cbTodosLosRecibos.Visible = true;
                        if (cbTodosLosRecibos.Checked) {
                            Utilidades.Combo.Llenar(cbRecibos, objLPago.ObtenerPagosPorCliente(objEntidadCliente.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                        }
                        else
                        Utilidades.Combo.Llenar(cbRecibos, objLPago.ObtenerPagosPorCliente(objEntidadCliente.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                        
                    }
         
                    frmFormas.CargarValoresVentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmProveedoresPagos_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
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

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
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

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["Codigo"].Value) == objEImpuesto.Codigo)
                {
                    MessageBox.Show("Impuesto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (txtAgente.Text.Trim().Equals(""))
                txtAgente.Text = "0";
            if (txtNroComprobante.Text.Trim().Equals(""))
                txtNroComprobante.Text = "0";

            dgvDatos.Rows.Add(objEImpuesto.Codigo, dtFechaRetencion.Value, objEImpuesto.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim())), objEImpuesto.CuentaContable.Codigo, Convert.ToInt32(txtAgente.Text.Trim()), Convert.ToInt32(txtNroComprobante.Text.Trim()));
            TotalImpuestos -= Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim()));
            
            total1 += Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim()));
            txtCodigoImpuesto.Text = "";
            txtImporte.Text = "";
            txtNroComprobante.Text = "";
            txtAgente.Text = "";
            lblTotal.Text = Total1.ToString("C2");
            txtCodigoImpuesto.Focus();
            //CargarTotales();
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblImpuesto);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            return res;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                TotalImpuestos += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe"].Value));
                total1 -= Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe"].Value));
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                
                lblTotal.Text = Total1.ToString("C2");
                //CargarTotales();
            }
        }



        private double efectivo;

        private void cbTodosLosRecibos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosLosRecibos.Checked)
            {
                Utilidades.Combo.Llenar(cbRecibos, objLPago.ObtenerPagosPorCliente(objEntidadCliente.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
            }
            else
                Utilidades.Combo.Llenar(cbRecibos, objLPago.ObtenerPagosPorCliente(objEntidadCliente.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");

        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtAgente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtNroComprobante_KeyDown(object sender, KeyEventArgs e)
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

        private void dtFechaRetencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }



}