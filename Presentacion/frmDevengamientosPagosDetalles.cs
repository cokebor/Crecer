using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDevengamientosPagosDetalles : Presentacion.frmColor
    {
        Logica.Caja objLCaja = new Logica.Caja();
        /*public int CodigoCaja { get; set; }
        public string Datos { get; set; }*/
        public frmDevengamientosPagosDetalles(Entidades.Caja pCaja)
        {
            InitializeComponent();
            ConfiguracionInicial();
           // Datos = pCaja.Numdoc;
            this.Text = "Comprobante Nº " + pCaja.Numdoc;

            LLenarGrillaEfectivo(pCaja);

            LLenarGrillaTranferencias(pCaja);
            LLenarGrillaLibreDisponibilidad(pCaja);
            //LLenarGrillaFormasDePago(pCaja);
            lblObservaciones.Text = pCaja.Observaciones;
        }
        private void ConfiguracionInicial()
        {
            Formato();
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvTranferencias);
            Utilidades.Grilla.Formato(dgvEfectivo);
            Utilidades.Grilla.Formato(dgvLibreDisponibilidad);
            /*  Utilidades.Grilla.Formato(dgvFormassDePago);*/
            dgvTranferencias.Columns["Banco"].Width = 180;
            dgvTranferencias.Columns["NroCuenta"].Width = 100;
            dgvTranferencias.Columns["Importe"].Width = 100;
            dgvLibreDisponibilidad.Columns["Cuenta"].Width = 250;
            dgvTranferencias.AutoGenerateColumns = false;
            /*
            dgvFormassDePago.Columns["NombreFormaPago"].Width = 200;
            dgvFormassDePago.Columns["MontoFormaPago"].Width = 100;
            dgvFormassDePago.Columns["Ver"].Width = 30;
            dgvFormassDePago.Columns["NombreFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFormassDePago.Columns["MontoFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            */
        }
        void LLenarGrillaTranferencias(Entidades.Caja pCaja) {
            try {
                dgvTranferencias.DataSource = objLCaja.ObtenerTranferenciasGasto(pCaja.Codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LLenarGrillaLibreDisponibilidad(Entidades.Caja pCaja)
        {
            try
            {
                dgvLibreDisponibilidad.DataSource = objLCaja.ObtenerLibreDisponibilidad(pCaja.Codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LLenarGrillaEfectivo(Entidades.Caja pCaja)
        {
            try
            {
                dgvEfectivo.DataSource = objLCaja.ObtenerEfectivoGasto(pCaja.Codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        void LLenarGrillaFormasDePago(int pCaja)
        {
            try
            {
              // dgvFormassDePago.DataSource = objLCaja.ObtenerFormasDePagoGasto(pCaja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    }
}
