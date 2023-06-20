using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAdelantos : Presentacion.frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.Caja objECaja = new Entidades.Caja();
        Entidades.Adelanto objEAdelanto = new Entidades.Adelanto();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();

        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Caja objLCaja = new Logica.Caja();
        public frmAdelantos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
        }
        private void Titulo()
        {
            this.Text = "ADELANTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoEmpleado, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 200);
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

            private void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoEmpleado.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoEmpleado.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreEmpleado.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                    }
                    else
                    {
                        lblNombreEmpleado.Text = "";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreEmpleado.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("Adelantos", this));
                    break;
            }
        }

        private void txtCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void Limpiar() {
            dtFecha.Value = DateTime.Now;
            txtCodigoEmpleado.Text = "";
            txtImporte.Text = "";
            txtObservaciones.Text = "";
        }

        private void CargarCajaAdelanto() {
            objECaja = new Entidades.Caja();
            objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(11);
            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = dtFecha.Value;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Observaciones = "Adelanto de Sueldo " + lblNombreEmpleado.Text;

            int mult = 1;
            if (objECaja.TipoDocumentoCaja.AfectaCaja.Equals('E'))
                mult = -1;


            Entidades.Factura_Efectivo fe = new Entidades.Factura_Efectivo();
            fe.Moneda= new Logica.Moneda().ObtenerUno(1);
            fe.Importe = mult*Convert.ToDouble(txtImporte.Text);
            objECaja.FacturaEfectivo.Add(fe);

            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;

            objEAdelanto = new Entidades.Adelanto();
            //objEAdelanto.Empleado = new Entidades.Empleado();
            //objEEmpleado.Codigo = Convert.ToInt32(txtCodigoEmpleado.Text);
            objEAdelanto.Empleado = objEEmpleado;
            objEAdelanto.Fecha = dtFecha.Value;
            objEAdelanto.Observaciones = txtObservaciones.Text;
            objEAdelanto.Moneda = fe.Moneda;
            objEAdelanto.Importe = Math.Abs(fe.Importe);
            objEAdelanto.Usuario = Singleton.Instancia.Usuario;
            objEAdelanto.Caja = objECaja;
            objEAdelanto.Estado = false;

        }

        private void CargarAsiento() {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECaja.Fecha;
            objEAsiento.FechaEmision = objECaja.Fecha;
            objEAsiento.Descripcion = objECaja.TipoDocumentoCaja.Descripcion +" N° " + objECaja.Numdoc + " " + objECaja.Observaciones;

            Entidades.Asiento_Detalle asientoDetalle;

            foreach (Entidades.Factura_Efectivo fe in objECaja.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = new Logica.FormaDePago().ObtenerUno(1);
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


                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105130000;

                asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                asientoDetalle.Haber = 0;

                objEAsiento.Detalle.Add(asientoDetalle);
            }

            


        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarComprobante()) {

                    CargarCajaAdelanto();
                    if (objEAdelanto.Importe==0)
                    {
                        MessageBox.Show("El Adelanto no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CargarAsiento();
                    int codigoAdelanto=new Logica.Adelanto().Agregar(objEAdelanto, objEAsiento);
                    if (MessageBox.Show("Adelanto creado exitosamente! ¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                     //   InformeCaja(Logica.Informes.CajaGastos(codigo, Singleton.Instancia.Empresa.NombreSucursal));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
            
        }

        private bool ValidarComprobante()
        {
            if (Utilidades.Validar.LabelEnBlanco(lblNombreEmpleado))
            {
                MessageBox.Show("Seleccione un Empleado Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoEmpleado.Focus();
                return false;
            }
            if (Utilidades.Validar.TextBoxEnBlanco(txtImporte))
            {
                MessageBox.Show("Debe cargar un Impoprte valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return false;
            }

            return true;
        }
    }
}
