using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAnulacionFacturaManual : Presentacion.frmColor
    {
        Logica.TipoDocumentoCliente objLTipoDocCliente = new Logica.TipoDocumentoCliente();
        Logica.Factura objLFactura = new Logica.Factura();

        Entidades.Factura objEFactura = new Entidades.Factura();
        public frmAnulacionFacturaManual()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }
        private void Titulo()
        {
            this.Text = "ANULACION DE COMPROBANTES";
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
        }

        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            ucNumeroComprobante.Limpiar();
        }

        private void frmAnulacionFacturaManual_Load(object sender, EventArgs e)
        {
            try
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCliente.ObtenerFacturasManuales(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarFactura();
                /*if (objEFactura.TipoDocumentoCliente.TipoDoc.Equals("CR")) {
                    if (MessageBox.Show("¿Esta seguro que desea anular el comprobante?\nSe eliminaran Imputacion del Pago correspondiente al Contrarecibo", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                        return;
                    }
                }
                else*/
                if (MessageBox.Show("¿Esta seguro que desea anular el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLFactura.Anular(objEFactura);
                MessageBox.Show("Comprobante anulado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFactura() {
            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            objEFactura.Letra = Convert.ToChar(ucNumeroComprobante.txtLetra.Text.Trim());
            objEFactura.PuntoDeVenta = Convert.ToInt32(ucNumeroComprobante.txtPuntoVenta.Text.Trim());
            objEFactura.Numero = Convert.ToInt32(ucNumeroComprobante.txtNumero.Text.Trim());
        }
    }
}
