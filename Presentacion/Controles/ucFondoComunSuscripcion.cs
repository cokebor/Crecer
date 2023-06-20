using System;
using System.Windows.Forms;

namespace Presentacion.Controles
{
    public partial class ucFondoComunSuscripcion : UserControl
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Fondo objLFondo = new Logica.Fondo();
        

        public string busqueda = "";
        Entidades.Banco objEBanco = new Entidades.Banco();

        private Entidades.CuentaBancaria objECuantaBancaria = new Entidades.CuentaBancaria();

        public Entidades.CuentaBancaria ObjECuantaBancaria
        {
            get
            {
                return objECuantaBancaria;
            }
        }
        public ucFondoComunSuscripcion()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Formatos();
            LimitesTamaños();
            CargarBancos();
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtValorCuotaparte, 15);
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbFondo);
        }
        public void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
                if (cbBancos.SelectedValue != null)
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtValorCuotaparte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacionNueveDecimales(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                    Utilidades.Combo.Llenar(cbFondo, objLFondo.ObtenerActivos(objEBanco), "Codigo", "Fondo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CargarFondos() {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbFondo, objLFondo.ObtenerActivos(objEBanco), "Codigo", "Fondo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbCuentaBancaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            txtValorCuotaparte.Text = "";
            txtImporte.Text = "";
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objECuantaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.FindForm().MdiParent, new frmFondos());
            busqueda = "Fondos";
        }

        private void CalculoCantidadCuotaparte() {
            double valCuota = txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(txtValorCuotaparte.Text);
            double imp = txtImporte.Text == "" ? 0 : Convert.ToDouble(txtImporte.Text);
            if (valCuota == 0)
                txtCantCuotaparte.Text = 0.ToString();
            else
                txtCantCuotaparte.Text = Utilidades.Redondear.DosDecimales((imp / valCuota)).ToString();
        }

        private void txtValorCuotaparte_TextChanged(object sender, EventArgs e)
        {
            CalculoCantidadCuotaparte();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            CalculoCantidadCuotaparte();
        }

        private void cbFondo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
