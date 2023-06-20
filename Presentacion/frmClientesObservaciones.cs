using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmClientesObservaciones : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocCliente = new Logica.TipoDocumentoCliente();
        Logica.Factura objLFactura = new Logica.Factura();

        Entidades.Cliente objECliente = new Entidades.Cliente();
        public frmClientesObservaciones()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
            // CargarValores();
        }

        private void Titulo()
        {
            this.Text = "OBSERVACIONES COMPROBANTES DE CLIENTES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbComprobantes);
        }
        private void Limpiar()
        {
            txtCodigoCliente.Text = "";
            cbTipoComprobante.DataSource = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.ComboBoxSinSeleccionar(cbComprobantes))
            {
                MessageBox.Show("No existe Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.TextBoxEnBlanco(txtObservaciones))
            {
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

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));

                    if (objECliente != null)
                    {
                        lblNombreCliente.Text = objECliente.Nombre;
                        ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        cbTipoComprobante.DataSource = null;


                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    cbTipoComprobante.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerComprobantes()
        {
            if (objECliente != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCliente.ObtenerTiposPorClientes(objECliente.TipoInscripcion.Codigo), "Codigo", "Descripcion");
            }
            else
            {
                cbTipoComprobante.DataSource = null;
            }
        }
        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 200);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("ClienteObservaciones", this));
                    break;
            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (objECliente != null && cbTipoComprobante.SelectedValue != null)
                {
                    Utilidades.Combo.Llenar(cbComprobantes, objLFactura.ObtenerPorCliente(objECliente, Convert.ToInt32(cbTipoComprobante.SelectedValue)), "Codigo", "Numero");
                }
                else
                {
                    cbComprobantes.DataSource = null;
                    txtObservaciones.Text = "";
                }

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
