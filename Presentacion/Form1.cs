using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.Asiento objLAsiento = new Logica.Asiento();
                if (textBox1.Text.Trim().Length > 0) { 
                    objLAsiento.Agrupar(dtFecha.Value, Convert.ToInt32(textBox1.Text.Trim()), Singleton.Instancia.Puesto, Singleton.Instancia.Empresa);
                      textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Valor ingresado no valido");
                }
            }
            catch (Exception) {
                MessageBox.Show("Valor ingresado no valido");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }
    }
}
