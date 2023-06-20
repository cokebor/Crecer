using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmInfomeRendicionesCaja : Presentacion.frmColor
    {
        Entidades.Sucursal objEntidadSucursal = new Entidades.Sucursal();
        Logica.Sucursal objLogicaSucursal = new Logica.Sucursal();

        Logica.Caja objLogicaCaja = new Logica.Caja();
        public frmInfomeRendicionesCaja()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Fecha"].Width = 80;
           // dgvDatos.Columns["Comprobante"].Width = 170;
            dgvDatos.Columns["Numero"].Width = 110;
            dgvDatos.Columns["Observaciones"].Width = 210;

            /*
            dgvDatos.Columns["Cliente"].Width = 200;
            //dgvDatos.Columns["Tipo"].Width = 40;


            dgvDatos.Columns["Cantidad"].Width = 80;
            dgvDatos.Columns["PrecioUnitario"].Width = 80;
            dgvDatos.Columns["Total"].Width = 80;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
            lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");
            lblCantidadVendida.Text = Convert.ToInt32("0").ToString();
            lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }*/
        }


        private void Titulo()
        {
            this.Text = "INFORME DE RENDICIONES DE CAJAS";
        }

        private void txtCodigoSucursal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoSucursal.Text.Trim().Equals(""))
                {
                    objEntidadSucursal= objLogicaSucursal.ObtenerSucursal(Convert.ToInt32(txtCodigoSucursal.Text.Trim()));
                    if (objEntidadSucursal != null)
                        lblNombreSucursal.Text = objEntidadSucursal.RazonSocial;
                    else
                        lblNombreSucursal.Text = "";
                }
                else
                {
                    objEntidadSucursal = new Entidades.Sucursal();
                    lblNombreSucursal.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        DateTime desde, hasta;

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {

                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;


                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    dgvDatos.DataSource = null;
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int sucursal=0;
                if (txtCodigoSucursal.Text.Trim().Equals("")) {
                    sucursal = 0;
                } else {
                    sucursal = Convert.ToInt32(txtCodigoSucursal.Text.Trim());
                }


                dgvDatos.DataSource = objLogicaCaja.ObtenerRendiciones(desde, hasta, sucursal);

                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Rendiciones en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreSucursal);
            return res;
        }
    }
}
