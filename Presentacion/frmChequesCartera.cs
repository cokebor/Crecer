using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{

    public partial class frmChequesCartera : Presentacion.frmColor
    {
        Logica.Cheque objLCheque = new Logica.Cheque();

    
        public frmChequesCartera()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            Titulo();   
            Formatos();
            CargarValores();
        }
        private void Titulo()
        {
            this.Text = "CHEQUES EN CARTERA";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);

           // dgvDatos.MultiSelect = true;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            

            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Banco"].Width = 100;
           // dgvDatos.Columns["Descripción"].Width = 150;
        }

        private void CargarValores()
        {
            try
            {
                DataTable dt= objLCheque.ObtenerEnCartera();
                dgvDatos.Rows.Clear();
                foreach (DataRow dr in dt.Rows) {

                    dgvDatos.Rows.Add(false, dr["Codigo"], dr["CodigoBanco"], dr["Banco"], dr["NroCheque"], dr["FechaEmision"], dr["FechaPago"], dr["Librador"], dr["CUIT"], dr["CodigoMoneda"], dr["Moneda"], dr["Cotizacion"], dr["Importe"], Convert.ToDouble(dr["Total"]).ToString("C2"), dr["CodigoCuentaContable"]);
                }
                
                //dgvDatos.DataSource = objLCheque.ObtenerEnCartera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            frmFormasDePago.busqueda = "ChequesTerceros";
            //frmFormasDePagoProveedores.busqueda = "ChequesTerceros";
            frmEgresosCaja.busqueda = "ChequesTerceros";
            this.Hide();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index) {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
            }
        }
    }
}