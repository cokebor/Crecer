using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmGastosTranferencia : Presentacion.frmColor
    {
        Logica.Caja objLCaja = new Logica.Caja();
        public int CodigoCaja { get; set; }
        public string Datos { get; set; }
        public frmGastosTranferencia(string datos,int pCaja)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Datos = datos;
            this.Text = "Transferencias de " + Datos;
            CodigoCaja = pCaja;
            LLenarGrillaTranferencias();
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
            dgvDetalle.Columns["Banco"].Width = 180;
            dgvDetalle.Columns["NroCuenta"].Width = 100;
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
        void LLenarGrillaTranferencias() {
            try {
                dgvDetalle.DataSource = objLCaja.ObtenerTranferenciasGasto(CodigoCaja);
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
