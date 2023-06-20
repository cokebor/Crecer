using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSaldoInicialProveedor : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        public frmSaldoInicialProveedor()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "SALDO INICIAL DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
        }
        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null)
                    {
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                        ObtenerTipoDocumento();
                    }
                    else
                    {
                        objEntidadProveedor = new Entidades.Proveedor();
                        lblNombreProveedor.Text = "";
                        lblTipoComprobanteProveedor.Text = "";
                    }
                }
                else
                {
                    objEntidadProveedor = null;
                    lblNombreProveedor.Text = "";
                    lblTipoComprobanteProveedor.Text = "";
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
                if (objEntidadProveedor != null && objEntidadProveedor.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();
                    objETipoDocumentoProveedor = objLTipoDocumentoProveedor.ObtenerDeProveedor(objEntidadProveedor.Codigo, objETipoDocumentoProveedor);

                    if (objETipoDocumentoProveedor != null)
                    {
                        lblTipoComprobanteProveedor.Text = objETipoDocumentoProveedor.Descripcion;
                        //  lblNumero.Text = objETipoDocumentoCliente.Numerador.Valor;
                    }
                    else
                    {
                        lblTipoComprobanteProveedor.Text = "";
                        // lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteProveedor.Text = "";
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
            if (objETipoDocumentoProveedor == null)
            {
                objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
            }
            
            objETipoDocumentoProveedor.TipoDoc.Codigo = "SI";
            objETipoDocumentoProveedor.AfectaCaja = 'N';
            if(rbDebito.Checked)
                objETipoDocumentoProveedor.AfectaCtaCte = 'D';
            else
                objETipoDocumentoProveedor.AfectaCtaCte = 'C';
            //FormasDePago();
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("SaldoInicial", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
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
                   
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objEFactura.Codigo = objLFactura.AgregarSaldoInicial(objEFactura);
                    
                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            objEntidadProveedor = null;
            rbDebito.Checked = true;
            objETipoDocumentoProveedor = null;
            txtCodigoProveedor.Focus();
        }
        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteProveedor))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Proveedor Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
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
            
            objEFactura = new Entidades.FacturaCompra();
            objEFactura.TipoDocumentoProveedor = objETipoDocumentoProveedor;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoProveedor.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoProveedor.Numerador.PuntoVenta;
            objEFactura.Numero= objETipoDocumentoProveedor.Numerador.Numero;
            objEFactura.FechaEmision = dtFecha.Value;
            objEFactura.Proveedor = objEntidadProveedor;
            objEFactura.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;
            objEFactura.Imputacion = 'F';
            if (objETipoDocumentoProveedor.AfectaCtaCte.Equals('D'))
                objEFactura.Neto1 = Convert.ToDouble(txtImporte.Text.Trim());
            else if (objETipoDocumentoProveedor.AfectaCtaCte.Equals('C'))
                objEFactura.Neto1 = -Convert.ToDouble(txtImporte.Text.Trim());

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
    }
}
