using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
	public partial class frmPreciosVentaInforme : Presentacion.frmColor
	{
		public frmPreciosVentaInforme()
		{
			InitializeComponent();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Reporte.Formato(reportViewer1,true);
            Text = "Precios de Venta";
		}

        private void frmPreciosVentaInforme_Load(object sender, EventArgs e)
        {
           
            // TODO: esta línea de código carga datos en la tabla 'dsFrutar.SP_PRECIOSVENTA_INFORME' Puede moverla o quitarla según sea necesario.
            this.SP_PRECIOSVENTA_INFORMETableAdapter.Fill(this.dsFrutar.SP_PRECIOSVENTA_INFORME);

            this.reportViewer1.RefreshReport();
        }
    }
}
