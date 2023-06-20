using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCuentaContable : Presentacion.frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();

        Entidades.CuentaContable objECuentaContable = new Entidades.CuentaContable();

        public frmCuentaContable()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            BotonesInicial();
            Formatos();
            CargarValores();
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentasPadres);
        }

        private void Titulo() {
            this.Text = "ACTUALIZACION DE CUENTAS CONTABLES";
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbCuentasPadres);
        }
        private void BotonesInicial() {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, null, btnCancelar);
        }

        private void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCuentaContable, 30);
        }
        private void CargarValores() {
            try
            {
                CargarCuentasPadres();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuentasPadres() {
            try
            {
             //   Utilidades.Combo.Llenar(cbCuentasPadres, objLCuentaContable.ObtenerPadres(), "Codigo", "Descripcion");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCuentasPadres_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            //  //  objECuentaContable = objLCuentaContable.ObtenerUno(cbCuentasPadres.SelectedValue.ToString());
            //    txtCodigoJerarquico1.CargarValor(objECuentaContable.CodigoJer);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar() {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentasPadres);
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, null, btnCancelar);
        }

        private void cbCuentasPadres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoJerarquico1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, null, btnCancelar);

        }

        private void txtCuentaContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbEsPadre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
         /*   if (Validar()) {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar dato!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCuentaContable.Focus();
                return;
            }

            objECuentaContable.Codigo = txtCodigoJerarquico1.ValorClave;
            objECuentaContable.Descripcion = txtCuentaContable.Text.Trim();
            objECuentaContable.CodigoJer = txtCodigoJerarquico1.Valor;
            objECuentaContable.CodigoCuentaPadre = Convert.ToString(cbCuentasPadres.SelectedValue);
            objECuentaContable.EsPadre = cbEsPadre.Checked;

            try
            {
                objLCuentaContable.Agregar(objECuentaContable);
                MessageBox.Show("Cuenta Contable agregada exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private bool Validar() {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentasPadres);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtCuentaContable);
            return res;
        }
    }
}
