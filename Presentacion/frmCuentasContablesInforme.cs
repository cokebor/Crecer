using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCuentasContablesInforme : Presentacion.frmColor
    {
        public frmCuentasContablesInforme()
        {
            InitializeComponent();
            
        }

        private void frmCuentasContablesInforme_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsFrutar.V_CUENTASCONTABLESINFORME' Puede moverla o quitarla según sea necesario.
                dsFrutar.EnforceConstraints = false;
                this.V_CUENTASCONTABLESINFORMETableAdapter.Fill(this.dsFrutar.V_CUENTASCONTABLESINFORME);

                this.reportViewer1.RefreshReport();
                Utilidades.Reporte.Formato(reportViewer1, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
