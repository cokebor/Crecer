using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    
    public partial class frmGastosInforme :  Presentacion.frmColor
    {
       // Entidades.TipoDocumentoCaja objETipo;
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
       /* Entidades.CuentaContable objECuenta;
        DataView dvFiltro;*/
        Logica.Caja objLogicaCaja = new Logica.Caja();
        //Logica.Banco objLBanco = new Logica.Banco();
        //Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        // Logica.TipoMovimientoBancario objLTipoMovimientoBancario = new Logica.TipoMovimientoBancario();

        //Entidades.Banco objEBanco = new Entidades.Banco();
        //Entidades.TipoMovimientoBancario objETipoMovimientoBancario = new Entidades.TipoMovimientoBancario();
        //Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public frmGastosInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }
        private void ConfiguracionInicial() {
            Titulo();
            Formato();
            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            CargarValores();
            TraerGastos();
            PintarGrilla();
            cbConceptos.SelectedIndexChanged += CbConceptos_SelectedIndexChanged;
        }

        private void CbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            PintarGrilla();
        }

        private void Titulo() {
            this.Text = "INFORME DE GASTOS";
        }
        private void Formato() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbConceptos);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Descripcion"].Width = 190;
            dgvDatos.Columns["Monto"].Width = 100;
            dgvDatos.Columns["Efectivo"].Width = 100;
            dgvDatos.Columns["Cheques"].Width = 100;
            dgvDatos.Columns["Tranferencia"].Width = 100;
            dgvDatos.Columns["RetencionesPercepciones"].Width = 100;
            dgvDatos.Columns["Total"].Width = 110;
        }

        public void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbConceptos, objLCuentaContable.ObtenerGastosDevengamientos(), "Codigo", "Nombre","Todos");
                //CargarTiposMovimientos();
                cbConceptos.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PintarGrilla() {
            double total=0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToDouble(item.Cells["Monto"].Value) != Convert.ToDouble(item.Cells["Total"].Value))
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new Font(dgvDatos.Font, FontStyle.Bold);
                    item.Cells["Monto"].Style = style;
                    
                }
                total += Convert.ToDouble(item.Cells["Monto"].Value);
            }
            lblTotal.Text = total.ToString("C2");
        }
        void TraerGastos() {
            try { 
                dgvDatos.DataSource = objLogicaCaja.ObtenerGastos(Convert.ToInt64(cbConceptos.SelectedValue), dtDesde.Value, dtHasta.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbConceptos);

            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
        }
               

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbConceptos.SelectedIndex != -1)
            {
                try
                {
                    //objECuenta = objLCuentaContable.ObtenerUno(Convert.ToInt32(cbConceptos.SelectedValue));
                    TraerGastos();
                    PintarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmGastosInforme_Load(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        int codigoCaja = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);
                        string datos = dgvDatos.CurrentRow.Cells["Descripcion"].Value.ToString();
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmGastosDetalle(datos,codigoCaja));
                        break;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
