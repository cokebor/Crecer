using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicialCliente : Presentacion.frmColor
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

        public frmSaldoInicialCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            ucNumeroComprobante.Enabled = false;
            ucNumeroComprobante.txtLetra.Text = "S";
        }

        private void Titulo()
        {
            this.Text = "SALDO INICIAL DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
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
                        lblTipoComprobanteCliente.Text = "";
                    }
                }
                else
                {
                    objEntidadCliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
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
                if (objEntidadCliente != null && objEntidadCliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();
                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerDeCliente(objEntidadCliente.Codigo, objETipoDocumentoCliente);

                    if (objETipoDocumentoCliente != null)
                    {
                        lblTipoComprobanteCliente.Text = objETipoDocumentoCliente.Descripcion;
                        //  lblNumero.Text = objETipoDocumentoCliente.Numerador.Valor;
                    }
                    else
                    {
                        lblTipoComprobanteCliente.Text = "";
                        // lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteCliente.Text = "";
                    // lblNumero.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = false;
            objETipoDocumentoCliente.TipoDoc.Codigo = "SI";
            objETipoDocumentoCliente.AfectaCaja = 'N';
            objETipoDocumentoCliente.AfectaStock = "NA";
            if(rbDebito.Checked)
                objETipoDocumentoCliente.AfectaCtaCte = 'D';
            else
                objETipoDocumentoCliente.AfectaCtaCte = 'C';
            //FormasDePago();
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("SaldoInicial", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("SaldoInicial", this));
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

        private void rbDebito_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {

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
                    //Asiento();
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    //objEFactura.Codigo = objLFactura.AgregarSaldoInicial(objEFactura, objEAsiento);
                    objEFactura.Codigo = objLFactura.AgregarSaldoInicial(objEFactura);


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
            objEAsiento.Descripcion = "Saldo Inicial N° " + objEFactura.Numdoc;
            Entidades.Asiento_Detalle asientoDetalle;

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 101020100;
                asientoDetalle.Debe = objEFactura.Total;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            


            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableVentaSucursal;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = objEFactura.Total;
            objEAsiento.Detalle.Add(asientoDetalle);

        }



        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEEmpleado = null;
            objEntidadCliente = null;
            rbDebito.Checked = true;
            objETipoDocumentoCliente = null;
            cbNumeroComprobante.Checked = false;
            ucNumeroComprobante.Enabled = false;
            ucNumeroComprobante.Limpiar();
            ucNumeroComprobante.txtLetra.Text = "S";
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
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteCliente))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
          
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
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.ModificarNumerador = !cbNumeroComprobante.Checked;
            if (cbNumeroComprobante.Checked) {
                objEFactura.PuntoDeVenta = Convert.ToInt32(ucNumeroComprobante.txtPuntoVenta.Text.Trim());
                objEFactura.Numero = Convert.ToInt32(ucNumeroComprobante.txtNumero.Text.Trim());
            }
            else {
                objEFactura.PuntoDeVenta = Convert.ToInt32(objETipoDocumentoCliente.Numerador.PuntoVenta);
                objEFactura.Numero = Convert.ToInt32(objETipoDocumentoCliente.Numerador.Numero);
            }
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = dtFecha.Value;
            objEFactura.Cliente = objEntidadCliente;
            objEFactura.Vendedor = objEEmpleado;
            

            
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

        private void rbDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void rbCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cbNumeroComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNumeroComprobante.Checked)
            {
                ucNumeroComprobante.Enabled = true;
                ucNumeroComprobante.txtLetra.Enabled = false;
                ucNumeroComprobante.txtPuntoVenta.Focus();
            }
            else {
                ucNumeroComprobante.Enabled = false;
                ucNumeroComprobante.Limpiar();
                ucNumeroComprobante.txtLetra.Text = "S";
            }
        }
    }
}
