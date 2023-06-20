using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmGastosCheques : Presentacion.frmColor
    {
        Logica.Caja objLCaja = new Logica.Caja();
        public int CodigoCaja { get; set; }
        public frmGastosCheques(string datos,int pCaja)
        {
            InitializeComponent();
            ConfiguracionInicial();
            this.Text = "Cheques de " + datos;
            CodigoCaja = pCaja;
            LLenarGrillaCheques();
            //LLenarGrillaFormasDePago(pCaja);
        }
        private void ConfiguracionInicial()
        {
            Formato();
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDetalle);
          /*  Utilidades.Grilla.Formato(dgvFormassDePago);*/
            dgvDetalle.Columns["Banco"].Width = 170;
            dgvDetalle.Columns["NroCheque"].Width = 120;
            dgvDetalle.Columns["Importe"].Width = 100;
            dgvDetalle.AutoGenerateColumns = false;
            /*
            dgvFormassDePago.Columns["NombreFormaPago"].Width = 200;
            dgvFormassDePago.Columns["MontoFormaPago"].Width = 100;
            dgvFormassDePago.Columns["Ver"].Width = 30;
            dgvFormassDePago.Columns["NombreFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFormassDePago.Columns["MontoFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            */
        }
        void LLenarGrillaCheques() {
            try {
                dgvDetalle.DataSource = objLCaja.ObtenerChequesGasto(CodigoCaja);
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
