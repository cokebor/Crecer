using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class CajaDeTexto
    {
        public static void LimiteTamaño(TextBox txt, int tamaño) {
            txt.MaxLength = tamaño;
        }

        public static void PermitirSoloNumeros(KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void PermitirSoloNumerosPositivos(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar) && e.KeyChar!='-')
            {
                e.Handled = true;
            }
        }
        /*
        public static void PermitirNumerosPuntuacion(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }*/

        public static void PermitirSoloLetras(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static string FormatoCuatroCeros(TextBox txt) {
            string resultado;
            if (txt.Text.Equals(""))
                txt.Text = "0";
            resultado = string.Format("{0:0000}", Convert.ToInt32(txt.Text.Trim()));
            return resultado;
        }
        public static string FormatoOchoCeros(TextBox txt)
        {
            string resultado;
            if (txt.Text.Equals(""))
                txt.Text = "0";
            resultado = string.Format("{0:00000000}", Convert.ToInt32(txt.Text.Trim()));
            return resultado;
        }

        public static void SoloNumeros(KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /*
        public static void PermitirNumerosPuntuacion(KeyPressEventArgs e, TextBox text)
        {*/
             public static void PermitirNumerosPuntuacion(Object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar == 46)
            {
                e.KeyChar = ',';
            }

            if (text.Text.Contains(","))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == ',' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }*/
            TextBox tb = (TextBox)sender;
            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                if ((tb.Text.IndexOf(separadorDecimal) >= 0) && !(tb.SelectionLength != 0))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    if ((tb.TextLength == 0) || (tb.SelectionLength > 0) || ((tb.TextLength == 1) && (tb.Text[0].Equals('-'))))
                    {
                        tb.SelectedText = "0";
                    }
                    e.KeyChar = Convert.ToChar(separadorDecimal);
                    return;
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                return;
            }
           /* else if (e.KeyChar.Equals('-'))
            {
                if (tb.SelectionLength == 0)
                {
                    if (tb.Text.IndexOf('-') >= 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    e.Handled = (tb.SelectionStart != 0);
                }
            }*/
            else if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            int index = tb.Text.IndexOf(separadorDecimal);

            if (index >= 0)
            {
                string decimales = tb.Text.Substring(index + 1);
                e.Handled = (decimales.Length == 2);
            }

            if (tb.SelectionLength > 0)
            {
                e.Handled = false;
            }

        }


        public static void PermitirNumerosPuntuacionCuatroDecimales(Object sender, KeyPressEventArgs e)
        {
     
            TextBox tb = (TextBox)sender;
            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                if ((tb.Text.IndexOf(separadorDecimal) >= 0) && !(tb.SelectionLength != 0))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    if ((tb.TextLength == 0) || (tb.SelectionLength > 0) || ((tb.TextLength == 1) && (tb.Text[0].Equals('-'))))
                    {
                        tb.SelectedText = "0";
                    }
                    e.KeyChar = Convert.ToChar(separadorDecimal);
                    return;
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                return;
            }

            else if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            int index = tb.Text.IndexOf(separadorDecimal);

            if (index >= 0)
            {
                string decimales = tb.Text.Substring(index + 1);
                e.Handled = (decimales.Length == 4);
            }

            if (tb.SelectionLength > 0)
            {
                e.Handled = false;
            }

        }

        public static void PermitirNumerosPuntuacionNueveDecimales(Object sender, KeyPressEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                if ((tb.Text.IndexOf(separadorDecimal) >= 0) && !(tb.SelectionLength != 0))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    if ((tb.TextLength == 0) || (tb.SelectionLength > 0) || ((tb.TextLength == 1) && (tb.Text[0].Equals('-'))))
                    {
                        tb.SelectedText = "0";
                    }
                    e.KeyChar = Convert.ToChar(separadorDecimal);
                    return;
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                return;
            }

            else if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            int index = tb.Text.IndexOf(separadorDecimal);

            if (index >= 0)
            {
                string decimales = tb.Text.Substring(index + 1);
                e.Handled = (decimales.Length == 9);
            }

            if (tb.SelectionLength > 0)
            {
                e.Handled = false;
            }

        }
        public static double ObtenerImporte(TextBox tb)
        {
            if (tb.Text.Trim().Equals(""))
                return 0;
            else
                return Convert.ToDouble(tb.Text.Trim());
        }
    }
}
