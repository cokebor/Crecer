using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Presentacion.Controles
{
    public partial class ucFondoComunRescate : UserControl
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Inversion objLInversiones = new Logica.Inversion();
        Entidades.Banco objEBanco = new Entidades.Banco();

        private Entidades.Inversion objEInversion = new Entidades.Inversion();

        private Entidades.CuentaBancaria objECuantaBancaria = new Entidades.CuentaBancaria();

        public Entidades.CuentaBancaria ObjECuantaBancaria
        {
            get
            {
                return objECuantaBancaria;
            }
        }

        public Inversion ObjEInversion
        {
            get
            {
                return objEInversion;
            }
        }

        public ucFondoComunRescate()
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
            Utilidades.CajaDeTexto.LimiteTamaño(txtPlazo, 3);
            //Utilidades.CajaDeTexto.LimiteTamaño(txtTNA, 5);
            // Utilidades.CajaDeTexto.LimiteTamaño(txtCapital, 15);
            // Utilidades.CajaDeTexto.LimiteTamaño(txtInteres, 15);
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCodigoInversiones);
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
        private void txtCapital_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
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

        private void txtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumerosPositivos(e);
        }

        private void txtTNA_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbCodigoInversiones);
            txtPlazo.Text = "";
            txtVariacion.Text = "";
            txtCapital.Text = "";
            txtInteres.Text = "";
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDatos();
        }

        public void CargaDatos() {
            try
            {
                objECuantaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                Utilidades.Combo.Llenar(cbCodigoInversiones, objLInversiones.ObtenerCodigos(2, ObjECuantaBancaria), "Codigo", "Codigo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCodigoInversiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEInversion = objLInversiones.ObtenerUna(Convert.ToInt32(cbCodigoInversiones.SelectedValue));
                txtInteres.Text = "";
                //txtCapital.Text = ObjEInversion.CapitalInvertido.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInteres_TextChanged(object sender, EventArgs e)
        {
            double inte = txtInteres.Text.Equals("") ? 0 : Convert.ToDouble(txtInteres.Text);
            txtVariacion.Text = Convert.ToDouble((inte/objEInversion.CapitalInvertido)*100).ToString();
        }
    }
}
