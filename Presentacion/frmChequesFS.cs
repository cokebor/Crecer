using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{

    public partial class frmChequesFS : Presentacion.frmColor
    {
        Logica.Cheque objLCheque = new Logica.Cheque();

    
        public frmChequesFS()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            CierreCaja = new CierreDeCaja();
            Sucursal = new Sucursal();
            Titulo();   
            Formatos();
            CargarValores();
        }
        private void Titulo()
        {
            this.Text = "CHEQUES ";
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

        private Entidades.Sucursal sucursal;

        private Entidades.CierreDeCaja cierreCaja;

        public Sucursal Sucursal
        {
            get
            {
                return sucursal;
            }

            set
            {
                sucursal = value;
            }
        }

        public CierreDeCaja CierreCaja
        {
            get
            {
                return cierreCaja;
            }

            set
            {
                cierreCaja = value;
            }
        }

        public void CargarValores()
        {
            try
            {
                //DataTable dt= objLCheque.ObtenerEnCartera();
                DataTable dt = objLCheque.ObtenerADPorCierre(CierreCaja.Codigo, Sucursal);
                dgvDatos.Rows.Clear();
                Int64 cuenta = 0;
                switch (Sucursal.Codigo)
                {
                    case 1:
                        cuenta = 10101030100;
                        break;
                    case 2:
                        cuenta = 10101030600;
                        break;
                    case 3:
                        cuenta = 10101030200;
                        break;
                    case 4:
                        cuenta = 10101030300;
                        break;
                    case 5:
                        cuenta = 10101030400;
                        break;
                    case 7:
                        cuenta = 10101030500;
                        break;

                }


                foreach (DataRow dr in dt.Rows) {

                    dgvDatos.Rows.Add(false, dr["Codigo"], dr["CodigoBanco"], dr["Banco"], dr["NroCheque"], dr["FechaEmision"], dr["FechaPago"], dr["Librador"], dr["CUIT"], dr["CodigoMoneda"], dr["Moneda"], dr["Cotizacion"], dr["Importe"], Convert.ToDouble(dr["Total"]).ToString("C4"), cuenta);//dr["CodigoCuentaContable"]);
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
            this.Hide();
           /* frmFormasDePago.busqueda = "ChequesTerceros";
            frmFormasDePagoProveedores.busqueda = "ChequesTerceros";
            frmEgresosCaja.busqueda= "ChequesTerceros";*/
            frmRendicionCaja.busqueda= "ChequesTerceros";
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index) {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
            }
        }

        private void cbSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSeleccionarTodos.Checked)
                foreach (DataGridViewRow i in dgvDatos.Rows)
                {
                    i.Cells["Seleccionado"].Value = true;
                }
            else {
                foreach (DataGridViewRow i in dgvDatos.Rows)
                {
                    i.Cells["Seleccionado"].Value = false;
                }
            }
        }

        private void frmChequesFS_Load(object sender, EventArgs e)
        {

        }
    }
}