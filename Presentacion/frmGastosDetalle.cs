using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmGastosDetalle : Presentacion.frmColor
    {
        Logica.Caja objLCaja = new Logica.Caja();
        public int CodigoCaja { get; set; }
        public string Datos { get; set; }
        public frmGastosDetalle(string datos,int pCaja)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Datos = datos;
            this.Text = "Detalle de " + Datos;
            CodigoCaja = pCaja;
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
            Utilidades.Grilla.Formato(dgvFormassDePago);
            dgvDetalle.Columns["Nombre"].Width = 200;
            dgvDetalle.Columns["Monto"].Width = 100;


            dgvFormassDePago.Columns["NombreFormaPago"].Width = 200;
            dgvFormassDePago.Columns["MontoFormaPago"].Width = 100;
            dgvFormassDePago.Columns["Ver"].Width = 30;
            dgvFormassDePago.Columns["NombreFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFormassDePago.Columns["MontoFormaPago"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        void LLenarGrillaDetalle() {
            try {
                dgvDetalle.DataSource = objLCaja.ObtenerDetalleGasto(CodigoCaja);
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
               dgvFormassDePago.DataSource = objLCaja.ObtenerFormasDePagoGasto(CodigoCaja);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFormassDePago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        if (dgvFormassDePago.CurrentRow.Cells["NombreFormaPago"].Value.Equals("CHEQUES: ")) { 
                            int codigoCaja = CodigoCaja;
                            //string datos = dgvDatos.CurrentRow.Cells["Descripcion"].Value.ToString();
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmGastosCheques(Datos, codigoCaja));
                        }else if (dgvFormassDePago.CurrentRow.Cells["NombreFormaPago"].Value.Equals("TRANSFERENCIA: "))
                        {
                            int codigoCaja = CodigoCaja;
                            //string datos = dgvDatos.CurrentRow.Cells["Descripcion"].Value.ToString();
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmGastosTranferencia(Datos, codigoCaja));
                        }
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
