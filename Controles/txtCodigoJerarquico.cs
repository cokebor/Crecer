using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2
{
    public partial class txtCodigoJerarquico : UserControl
    {
        public txtCodigoJerarquico()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        public void Habilitar()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
        }

        public void DesHabilitar()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        public string Valor
        {
            get
            {
                return textBox1.Text.Trim() + "." + textBox2.Text.Trim() + "." + textBox3.Text.Trim()
                    + "." + textBox4.Text.Trim() + "." + textBox5.Text.Trim() + "." + textBox5.Text.Trim();
            }
        }

        public string ValorClave
        {
            get
            {
                return Convert.ToInt32(textBox1.Text.Trim()).ToString() +
                    Convert.ToInt32(textBox2.Text.Trim()).ToString() +
                    Convert.ToInt32(textBox3.Text.Trim()).ToString() +
                    Convert.ToInt32(textBox4.Text.Trim()).ToString() +
                    Convert.ToInt32(textBox5.Text.Trim()).ToString() +
                    Convert.ToInt32(textBox6.Text.Trim()).ToString();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 1)
                textBox2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 2)
                textBox3.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.TextLength == 2)
                textBox4.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength == 2)
                textBox5.Focus();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.TextLength == 2)
                textBox6.Focus();
        }
        public static string FormatoDosCeros(TextBox txt)
        {
            string resultado;
            if (txt.Text.Equals(""))
                txt.Text = "0";
            resultado = string.Format("{0:00}", Convert.ToInt32(txt.Text.Trim()));
            return resultado;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = FormatoDosCeros(textBox2);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = FormatoDosCeros(textBox3);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = FormatoDosCeros(textBox4);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.Text = FormatoDosCeros(textBox5);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.Text = FormatoDosCeros(textBox6);
        }

        public void CargarValor(string valor)
        {
            textBox1.Text = valor.Substring(0, 1);
            if (!textBox1.Text.Trim().Equals("0"))
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
            textBox2.Text = valor.Substring(2, 2);
            if (!textBox2.Text.Trim().Equals("00"))
                textBox2.Enabled = false;
            else
                textBox2.Enabled = true;
            textBox3.Text = valor.Substring(5, 2);
            if (!textBox3.Text.Trim().Equals("00"))
                textBox3.Enabled = false;
            else
                textBox3.Enabled = true;
            textBox4.Text = valor.Substring(8, 2);
            if (!textBox4.Text.Trim().Equals("00"))
                textBox4.Enabled = false;
            else
                textBox4.Enabled = true;
            textBox5.Text = valor.Substring(11, 2);
            if (!textBox5.Text.Trim().Equals("00"))
                textBox5.Enabled = false;
            else
                textBox5.Enabled = true;
            textBox6.Text = valor.Substring(14, 2);
            if (!textBox6.Text.Trim().Equals("00"))
                textBox6.Enabled = false;
            else
                textBox6.Enabled = true;

            if (textBox1.Enabled == false) {
                if (textBox2.Enabled == false)
                {
                    if (textBox3.Enabled == false)
                    {
                        if (textBox4.Enabled == false) {
                            if (textBox5.Enabled == false)
                            {
                                if (!textBox6.Enabled == false) {
                                    textBox6.Focus();
                                }
                            }
                            else {
                                textBox5.Focus();
                            }
                        }else
                        {
                            textBox4.Focus();
                        }
                    }
                    else {
                        textBox3.Focus();
                    }
                }
                else {
                    textBox2.Focus();
                }
            }
        }

    }
}
