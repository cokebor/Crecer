using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAnulacionSucursal : Presentacion.frmColor
    {
        Logica.TipoDocumentoCaja objLTipoDocCaja = new Logica.TipoDocumentoCaja();
        Logica.Caja objLCaja = new Logica.Caja();

        Entidades.Caja objECaja = new Entidades.Caja();
        public frmAnulacionSucursal()
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
            this.Text = "ANULACION DE COMPROBANTES SUCURSALES";
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
        }

        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            ucNumeroComprobante.Limpiar();
        }

        private void frmAnulacionSucursales_Load(object sender, EventArgs e)
        {
            try
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCaja.ObtenerTipoComprabantesSucursales(), "Codigo", "Descripcion");
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
                CargarCaja();
                if (MessageBox.Show("¿Esta seguro que desea anular el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLCaja.AnularSucursal(objECaja);
                MessageBox.Show("Comprobante anulado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCaja() {
            objECaja = new Entidades.Caja();
            objECaja.TipoDocumentoCaja.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            objECaja.Letra = Convert.ToChar(ucNumeroComprobante.txtLetra.Text.Trim());
            objECaja.PuntoDeVenta = Convert.ToInt32(ucNumeroComprobante.txtPuntoVenta.Text.Trim());
            objECaja.Numero = Convert.ToInt32(ucNumeroComprobante.txtNumero.Text.Trim());
        }
    }
}
