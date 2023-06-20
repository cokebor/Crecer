using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRetencionesPercepcionesPagos : Presentacion.frmColor
    {
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();
       /* public int pCodigoCuentaContable { get; set; }
        public int pCodigoImpuesto { get; set; }*/
        public frmRetencionesPercepcionesPagos() {
            InitializeComponent();
            ConfiguracionInicial();
        }
        void ConfiguracionInicial() {
            Formatos();
        }
        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            lblTotal.Text = Convert.ToDouble(0).ToString("C2");
            // dgvDatos.MultiSelect = true;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            dgvDatos.Columns["Seleccionado"].Width = 25;
            dgvDatos.Columns["CUIT"].Width = 83;
            dgvDatos.Columns["Fecha"].Width = 73;
            dgvDatos.Columns["NroAgente"].Width = 100;
            dgvDatos.Columns["NroComprobante"].Width = 110;
            dgvDatos.Columns["ProveedorCliente"].Width = 140;

        }
        public void LlenarGrilla(Int64 pCodigoCuentaContable, int pCodigoRetencionAsociado)
        {
            try
            {
                DataTable dt = objLImpuesto.ObtenerRetencionesPercepciones(Singleton.Instancia.Empresa.Codigo, pCodigoCuentaContable);//, pCodigoRetencionAsociado);
                dgvDatos.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    dgvDatos.Rows.Add(false, dr["CodigoCuentaContable"], dr["CodigoPago"], dr["CodigoFactura"], dr["Fecha"], dr["CUIT"], dr["ProveedorCliente"], dr["NroAgente"], dr["NroComprobante"], dr["Importe"], dr["CodigoImpuesto"], pCodigoRetencionAsociado, dr["CodigoSucursal"]);
                }
                lblTotal.Text = Aplicado().ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public double Aplicado()
        {
            double res = 0;
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                        res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Importe"].Value));
            }
            return res;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
                if (Convert.ToBoolean(check.Value) == true)
                {
                    lblTotal.Text = Aplicado().ToString("C2");
                }
                else
                {
                    lblTotal.Text = Aplicado().ToString("C2");
                }
            }
        }
    }
}
