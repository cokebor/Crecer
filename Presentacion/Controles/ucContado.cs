using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ucContado : UserControl
    {
        Logica.Moneda objLMoneda = new Logica.Moneda();

        Entidades.Moneda objEMoneda = new Entidades.Moneda();
        public ucContado()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Utilidades.Combo.Formato(cbMoneda);
        }

        private void ucContado_Load(object sender, EventArgs e)
        {
            try
            {
                ObtenerMonedas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObtenerMonedas()
        {
            Utilidades.Combo.Llenar(cbMoneda, objLMoneda.ObtenerActivos(), "CodigoMoneda", "Descripcion");
        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoneda.Items.Count > 0)
            {
                try
                {
                    objEMoneda = objLMoneda.ObtenerUno(Convert.ToInt32(cbMoneda.SelectedValue));
                    lblCotizacion.Text = objEMoneda.Cotizacion.ToString("0.00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        
        
        private void cbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        public bool ValidarEfectivo()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbMoneda);
            return res;
        }

        public bool ValidarMonto() {
            bool res = false;
            if (txtImporte.Text.Length > 0 && Convert.ToDouble(txtImporte.Text) <= 0)
                res = false;
            else
                res= true;
            return res;
        }

    }
}
