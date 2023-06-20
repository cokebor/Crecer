using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDescuentos : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();

        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Factura objLFactura = new Logica.Factura();

        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        public frmDescuentos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            ObtenerTipoDocumento();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "DESCUENTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }
        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objEntidadCliente != null)
                    {
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                        ObtenerTipoDocumento();
                    }
                    else
                    {
                        objEntidadCliente = new Entidades.Cliente();
                        lblNombreCliente.Text = "";
                       // lblTipoComprobanteCliente.Text = "";
                    }
                }
                else
                {
                    objEntidadCliente = null;
                    lblNombreCliente.Text = "";
                  //  lblTipoComprobanteCliente.Text = "";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerTipoDocumento()
        {
            try
            {
                objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerUno(27);
                    //objLTipoDocumentoCliente.ObtenerDeCliente(objEntidadCliente.Codigo, objETipoDocumentoCliente);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("Descuentos", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("Descuentos", this));
                    break;
            }

        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    Comprobante();
                    Asiento();
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    //objEFactura.Codigo = objLFactura.AgregarSaldoInicial(objEFactura, objEAsiento);
                    objEFactura.Codigo = objLFactura.AgregarDescuento(objEFactura, objEAsiento);


                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Asiento()
        {

            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = "Descuento Supermercado N° " + objEFactura.Numdoc;
            Entidades.Asiento_Detalle asientoDetalle;

                asientoDetalle = new Entidades.Asiento_Detalle();
                  asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableDescuentosClientes;
                asientoDetalle.Debe = Math.Abs(objEFactura.Total);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            


            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableCuentaCorrienteClientes;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = Math.Abs(objEFactura.Total);
            objEAsiento.Detalle.Add(asientoDetalle);

        }



        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEEmpleado = null;
            objEntidadCliente = null;
            //rbDebito.Checked = true;
           // objETipoDocumentoCliente = null;
            txtCodigoVendedor.Focus();
        }
        private bool Validar()
        {
            if (Utilidades.Validar.LabelEnBlanco(lblNombreVendedor))
            {
                MessageBox.Show("Seleccione un Vendedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoVendedor.Focus();
                return true;
            }

            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
          /*  if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteCliente))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }*/
          
            if (txtImporte.Text.Trim().Equals("") || Convert.ToDouble(txtImporte.Text.Trim()) == 0)
            {
                MessageBox.Show("El Importe del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void Comprobante()
        {

            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
        //    objEFactura.TipoDocumentoCliente.Numerador=new Logica.Numerador().
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = Convert.ToInt32(objETipoDocumentoCliente.Numerador.PuntoVenta);
            objEFactura.Numero = Convert.ToInt32(objETipoDocumentoCliente.Numerador.Numero);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = dtFecha.Value;
            objEFactura.Cliente = objEntidadCliente;
            objEFactura.Vendedor = objEEmpleado;
            objEFactura.Observaciones = txtObservaciones.Text.Trim();

            
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;
            objEFactura.Imputacion = 'F';
            if(objETipoDocumentoCliente.AfectaCtaCte.Equals('D'))
                objEFactura.Neto105 = Convert.ToDouble(txtImporte.Text.Trim());
            else if (objETipoDocumentoCliente.AfectaCtaCte.Equals('C'))
                objEFactura.Neto105 = -Convert.ToDouble(txtImporte.Text.Trim());
        }

        private void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoVendedor.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoVendedor.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreVendedor.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                    }
                    else
                    {
                        lblNombreVendedor.Text = "";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreVendedor.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void dtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
