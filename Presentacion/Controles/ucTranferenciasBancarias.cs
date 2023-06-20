using System;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class ucTranferenciasBancarias : UserControl
    {
        //Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();


        public Entidades.Moneda objEMoneda = new Entidades.Moneda();
       // Entidades.Banco objEBanco = new Entidades.Banco();
        public Entidades.CuentaBancaria objECuentaBancaria;// = new Entidades.CuentaBancaria();
        private Entidades.Banco objEBanco = new Entidades.Banco();

        public Banco ObjEBanco
        {
            get
            {
                return objEBanco;
            }

            set
            {
                objEBanco = value;
            }
        }

        /* public Banco ObjEBanco
{
    get
    {
        return objEBanco;
    }

    set
    {
        objEBanco = value;
    }
}*/

        public ucTranferenciasBancarias()
        {
            InitializeComponent();
            ConfiguracionInicial();
           // objEBanco = null;
        }


        private void ConfiguracionInicial()
        {
            Formatos();
            LimitesTamaños();
            CargarBancos();
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancos);
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
        }

        public bool ValidarTranferencia()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaBancaria);
            return res;
        }

        public void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivasParaTransferenciasClientes(), "CodigoBanco", "Banco");
                if (cbBancos.SelectedValue != null)
                {
                    ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancosParaTransferenciasClientes(ObjEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    ObjEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancosParaTransferenciasClientes(ObjEBanco), "Codigo", "NumeroCuenta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                objEMoneda = objECuentaBancaria.Moneda;
                lblCotizacion.Text = objECuentaBancaria.Moneda.Cotizacion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public bool ValidarMonto()
        {
            bool res = false;
            if (txtImporte.Text.Length > 0 && Convert.ToDouble(txtImporte.Text) <= 0)
                res = false;
            else
                res = true;
            return res;
        }
    }
}
