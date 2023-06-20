using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrutarDTVe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial() {
            Formatos();
        }
        private void Formatos() {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowInTaskbar = false;

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "STOCK FRUTAR DTVe";

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsInforme.V_STOCKDTVE' Puede moverla o quitarla según sea necesario.
                this.V_STOCKDTVETableAdapter.Fill(this.dsInforme.V_STOCKDTVE);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
