using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class ControlesGenerales
    {
        public static void LimpiarControles(Form formulario)
        {
            foreach (Control c in formulario.Controls)
            {
                LimpiarControl(c);
                if (c is GroupBox)
                {
                    foreach (Control a in c.Controls)
                    {
                        LimpiarControl(a);
                    }
                }
                if (c is Panel)
                {
                    foreach (Control a in c.Controls)
                    {
                        LimpiarControl(a);
                    }
                }

                if (c is System.Windows.Forms.TabControl)
                {
                    foreach (Control a in c.Controls)
                    {
                        foreach (Control b in a.Controls)
                        {
                            LimpiarControl(b);
                            if (b is CheckedListBox)
                            {
                                for (int i = 0; i <= ((CheckedListBox)b).Items.Count-1; i++)
                                {
                                    ((CheckedListBox)b).SetItemChecked(i, false);
                                }
                            }
                        }

                    }
                }
                
                if (c is CheckedListBox) {
                    for (int i = 0; i <= ((CheckedListBox)c).Items.Count;i++) {
                        ((CheckedListBox)c).SetItemChecked(i, false);
                    }
                }
            }
        }

        private static void LimpiarControl(Control c) {
            if (c is TextBox)
            {
                c.Text = "";
            }
            else if (c is ComboBox)
            {
                Combo.SeleccionarPrimerValor((ComboBox)c);
            }
            else if (c is DateTimePicker)
            {
                ((DateTimePicker)c).Value = DateTime.Now;
                ((DateTimePicker)c).Checked = false;
            }
            else if (c is Controles2.txtCUIL)
            {
                ((Controles2.txtCUIL)c).Limpiar();
            }
            else if (c is DataGridView)
            {
                if (((DataGridView)c).Rows.Count>0)
                    ((DataGridView)c).Rows.Clear();
            }
            else if (c is NumericUpDown) {
                ((NumericUpDown)c).Value = 0;
            }
        }

        public static void Habilitar(Form formulario)
        {
            foreach (Control c in formulario.Controls)
            {
                if (c is Button == false)
                {

                    c.Enabled = true;
                    if (c is GroupBox)
                    {
                        foreach (Control a in c.Controls)
                        {
                            a.Enabled = true;
                        }
                    }
                    if (c is System.Windows.Forms.TabControl) {
                        foreach (Control a in c.Controls)
                        {
                            foreach (Control b in a.Controls) {
                                b.Enabled = true;
                            }
                            
                        }
                    }
                }
            }

        }

        public static void Deshabilitar(Form formulario)
        {
            foreach (Control c in formulario.Controls)
            {
                if (c is Button == false)
                {

                    c.Enabled = false;
                    if (c is GroupBox)
                    {
                        foreach (Control a in c.Controls)
                        {
                            a.Enabled = false;
                        }
                    }
                    if (c is System.Windows.Forms.TabControl)
                    {
                        foreach (Control a in c.Controls)
                        {
                            foreach (Control b in a.Controls)
                            {
                                b.Enabled = false;
                            }

                        }
                    }
                }
            }

        }

        public static void CambiarFoco(KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static void PresionarEnter() {
            SendKeys.Send("{TAB}");
        }

    }
}