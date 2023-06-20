using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProveedoresObservaciones : Presentacion.frmColor
    {
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocCProveedor = new Logica.TipoDocumentoProveedor();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();

        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
        public frmProveedoresObservaciones()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
        }

        private void Titulo()
        {
            this.Text = "OBSERVACIONES COMPROBANTES DE PROVEEDORES";
        }


        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbComprobantes);
        }
        private void Limpiar()
        {
            txtCodigoProveedor.Text = "";
            cbTipoComprobante.DataSource = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Proveedor Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.ComboBoxSinSeleccionar(cbComprobantes))
            {
                MessageBox.Show("No existe Comprobante para Proveedor Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.TextBoxEnBlanco(txtObservaciones)) {
                MessageBox.Show("El Campo Observaciones esta en blanco", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtObservaciones.Focus();
                return true;
            }
            
            return false;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // CargarFactura();
                if (!Validar())
                {
                    if (MessageBox.Show("¿Esta seguro que desea agregar la Observacion al Comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objLFactura.AgregarObservaciones(Convert.ToInt32(cbTipoComprobante.SelectedValue), Convert.ToInt32(cbComprobantes.SelectedValue), txtObservaciones.Text.Trim());
                    MessageBox.Show("Observacion agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {

                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEProveedor = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));

                    if (objEProveedor != null)
                    {
                        lblNombreProveedor.Text = objEProveedor.Nombre;
                        ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreProveedor.Text = "";
                        cbTipoComprobante.DataSource = null;
                        

                    }
                }
                else
                {
                    objEProveedor = null;
                    lblNombreProveedor.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerComprobantes()
        {
            if (objEProveedor != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCProveedor.ObtenerTiposPorProveedores(objEProveedor.TipoInscripcion.Codigo), "Codigo", "Descripcion");
            }
            else
            {
                cbTipoComprobante.DataSource = null;
            }
        }
        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 200);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("ProveedorObservaciones", this));
                    break;
            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (objEProveedor != null && cbTipoComprobante.SelectedValue != null)
                    Utilidades.Combo.Llenar(cbComprobantes, objLFactura.ObtenerPorProveedor(objEProveedor, Convert.ToInt32(cbTipoComprobante.SelectedValue)), "Codigo", "Numero");
                else
                    cbComprobantes.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void cbComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbComprobantes.SelectedValue != null)
                    txtObservaciones.Text = objLFactura.ObtenerObservaciones(Convert.ToInt32(cbTipoComprobante.SelectedValue), Convert.ToInt32(cbComprobantes.SelectedValue));
                else
                    txtObservaciones.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
