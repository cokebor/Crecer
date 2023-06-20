using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDevengamientoDetalle : Presentacion.frmColor
    {
        Logica.Devengamiento objLDevengamiento = new Logica.Devengamiento();
        Logica.Caja objLCaja = new Logica.Caja();
        /*public int CodigoCaja { get; set; }
        */
        private Entidades.Devengamiento Devengamiento { get; set; }
        private Entidades.Caja Caja { get; set; }
        public frmDevengamientoDetalle(int pCodigoDevengamiento)
        {
            InitializeComponent();
            ConfiguracionInicial();
            try
            {
                Devengamiento = objLDevengamiento.ObtenerUno(pCodigoDevengamiento);
                //Caja = objLCaja.ObtenerUna(Devengamiento);
                this.Text = "Detalle de " + Devengamiento.Concepto.Descripcion + " Tipo " + Devengamiento.TipoSalario.Descripcion + " Periodo " + Devengamiento.Periodo;
               // this.lblComprobanteCaja.Text = "Comprobante Nº " + Caja.Numdoc + " Fecha: " + Caja.Fecha.Date.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            LLenarGrillaDetalle();
            LLenarGrillaFormasDePago();
           
        }
        private void ConfiguracionInicial()
        {
            Formato();
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDetalle);
            Utilidades.Grilla.Formato(dgvPagos);
            dgvDetalle.Columns["Nombre"].Width = 210;
            dgvDetalle.Columns["Debe"].Width = 100;
            dgvDetalle.Columns["Haber"].Width = 100;
            dgvDetalle.AutoGenerateColumns = false;

           /* dgvFormassDePago.Columns["NombreFormaPago"].Width = 200;
            dgvFormassDePago.Columns["MontoFormaPago"].Width = 100;
            dgvFormassDePago.Columns["Ver"].Width = 30;
            dgvFormassDePago.Columns["NombreFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFormassDePago.Columns["MontoFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;*/
            dgvPagos.Columns["Fecha"].Width = 80;
            dgvPagos.Columns["ComprobanteNro"].Width = 100;
            dgvPagos.Columns["Monto"].Width = 100;
            //dgvPagos.Columns["Ver"].Width = 30;
            dgvPagos.Columns["Fecha"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPagos.Columns["ComprobanteNro"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPagos.Columns["Monto"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPagos.AutoGenerateColumns = false;
        }
        void LLenarGrillaDetalle() {
            try {
                dgvDetalle.DataSource = objLDevengamiento.ObtenerDetalle(Devengamiento.Codigo);
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LLenarGrillaFormasDePago()
        {
            try
            {
                //dgvFormassDePago.DataSource = objLCaja.ObtenerFormasDePagoGasto(Caja.Codigo);
                dgvPagos.DataSource = objLCaja.ObtenerCajasDeVengamientos(Devengamiento);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 switch (e.ColumnIndex)
                 {
                     case 2:
                        Caja = new Entidades.Caja();
                        Caja.Codigo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells["CodigoPago"].Value);
                        Caja = objLCaja.ObtenerUna(Caja);
                       /* 
                        Caja.Letra = Convert.ToChar(dgvPagos.Rows[e.RowIndex].Cells["ComprobanteNro"].Value.ToString().Substring(0,1));
                        Caja.PuntoDeVenta=Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells["ComprobanteNro"].Value.ToString().Substring(0, 1));*/
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmDevengamientosPagosDetalles(Caja));
                            break;
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
