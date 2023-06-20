using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Validar
    {
        public static bool TextBoxEnBlanco(TextBox txt) {
            bool res = false;
            if (txt.Text.Trim() == "") {
                res = true;
            }
            return res;
        }

        public static bool LabelEnBlanco(Label lbl)
        {
            bool res = false;
            if (lbl.Text.Trim() == "")
            {
                res = true;
            }
            return res;
        }
        public static bool ComboBoxSinSeleccionar(ComboBox cbo) {
            bool res = false;
            if (cbo.SelectedIndex == -1) {
                res = true;
            }
            return res;
        }

        public static bool CUITEnBlanco(Controles2.txtCUIT txt)
        {
            bool res = false;
            if (txt.txtCUIL1.Text.Trim().Equals("") || txt.txtCUIL2.Text.Trim().Equals("") || txt.txtCUIL3.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }

        
        public static bool NumeroDocumentoBlanco(Controles2.txtNumeroComprobante txt)
        {
            bool res = false;
            if (txt.txtLetra.Text.Trim().Equals("") || txt.txtPuntoVenta.Text.Trim().Equals("") || txt.txtNumero.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }
        public static bool DTVeBlanco(Controles2.ucNumeroDTV txt)
        {
            bool res = false;
            if (txt.txtNumero.Text.Trim().Equals("") || txt.txtNumero2.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }

        public static bool GrillaVacia(DataGridView dgv) {
            bool res = false;
            if (dgv.Rows.Count == 0) {
                res = true;
            }
            return res;
        }

        public static int CalcularDigitoCuit(string cuit) {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++) {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }

        public static bool ValidaCUIT(string cuit) {
            if (cuit == null) {
                return false;
            }
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }

        public static bool ValidarFechas(DateTime fecha1, DateTime fecha2) {
            return fecha1 <= fecha2;
        }
    }
}
