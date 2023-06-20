using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAnulacionFacturaCompra : Presentacion.frmColor
    {
        //Logica.TipoDocumentoCliente objLTipoDocCliente = new Logica.TipoDocumentoCliente();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        Logica.TipoDocumentoProveedor objLTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();

        Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();

        public frmAnulacionFacturaCompra()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Formatos();
        }
        private void Titulo()
        {
            this.Text = "ANULACION DE FACTURAS DE COMPRAS";
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
        }

        private void Limpiar() {
            txtCodigoProveedor.Text = "";
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            ucNumeroComprobante.Limpiar();
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
                if (MessageBox.Show("¿Esta seguro que desea anular el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLFactura.Anular(objEFactura);
                MessageBox.Show("Comprobante anulado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();

            }
            catch (Exception ex) {
               // MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFactura() {
            objEFactura = new Entidades.FacturaCompra();
            objEFactura.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEFactura.TipoDocumentoProveedor.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            objEFactura.Letra = ucNumeroComprobante.Letra;
            objEFactura.PuntoDeVenta = ucNumeroComprobante.PuntoDeVenta;
            objEFactura.Numero=ucNumeroComprobante.Numero;
            
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
                        //    if(optBienC.Checked)

                    }
                    else
                    {
                        objEntidadProveedor = new Entidades.Proveedor();

                        lblNombreProveedor.Text = "";
                        //  if (optBienC.Checked)

                        //cbTipoComprobante.DataSource = null;
                    }
                }
                else
                {
                    objEntidadProveedor = null;
                    //if (optBienC.Checked)
                    objETipoDocumentoProveedor = null;
                    lblNombreProveedor.Text = "";
                    //cbTipoComprobante.DataSource = null;
                }
                ObtenerComprobantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerComprobantes()
        {
            if (objEntidadProveedor != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocumentoProveedor.ObtenerTodosAAnular(objEntidadProveedor.Codigo), "Codigo", "Descripcion");
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
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("AnulacionDeComprobantes", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
