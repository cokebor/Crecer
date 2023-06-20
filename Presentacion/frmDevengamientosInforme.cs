using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDevengamientosInforme : Presentacion.frmColor
    {
        Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.Periodo objLPeriodo = new Logica.Periodo();
        Logica.Devengamiento objLDevengamiento = new Logica.Devengamiento();

        Entidades.Concepto objEConcepto=new Entidades.Concepto();
        public frmDevengamientosInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formato();
            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
            //lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            CargarValores();
            
            /*PintarGrilla();*/
            
        }

        private void Titulo()
        {
            this.Text = "INFORME DE DEVENGAMIENTOS";
        }

        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbConceptos);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Codigo"].Width = 30;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Concepto"].Width = 160;
            dgvDatos.Columns["Tipo"].Width = 110;
            dgvDatos.Columns["Periodo"].Width = 70;
           // dgvDatos.Columns["Total"].Width = 110;
        }
        public void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbConceptos, objLConcepto.ObtenerTodos(), "Codigo", "Descripcion", "Todos");
                //CargarTiposMovimientos();
                cbConceptos.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      /*  void TraerPeriodos()
        {
            try
            {
                    Utilidades.Combo.Llenar(cbPeriodo, objLPeriodo.ObtenerTodos(Convert.ToInt32(cbConceptos.SelectedValue),dtDesde.Value, dtHasta.Value), "Periodo", "Periodo");
                //cbConceptos.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
        

        private void cbPendientesDePago_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbPendientesDePago.Checked)
                {
                    dtDesde.Enabled = false;
                    dtHasta.Enabled = false;
                    cbConceptos.SelectedValue = 0;
                    cbConceptos.Enabled = false;
                    dgvDatos.DataSource = objLDevengamiento.Obtener(objEConcepto, dtDesde.Value, dtHasta.Value, cbPendientesDePago.Checked);
                }
                else
                {
                    dtDesde.Enabled = true;
                    dtHasta.Enabled = true;
                    cbConceptos.SelectedValue = 0;
                    cbConceptos.Enabled = true;
                    dgvDatos.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDatos.DataSource = objLDevengamiento.Obtener(objEConcepto, dtDesde.Value, dtHasta.Value, cbPendientesDePago.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            objEConcepto.Codigo = Convert.ToInt32(cbConceptos.SelectedValue);
            dgvDatos.DataSource = null;
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 5:
                        int codigoDevengamiento = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmDevengamientoDetalle(codigoDevengamiento));
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
