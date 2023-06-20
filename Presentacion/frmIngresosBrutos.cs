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
    public partial class frmIngresosBrutos : Presentacion.frmColor
    {
        public frmIngresosBrutos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            try
            {
                LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }

        private void Titulo()
        {
            this.Text = "INGRESOS BRUTOS";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.AllowUserToOrderColumns = false;
            
            dgvDatos.Columns["Tipo"].Width = 180;
            dgvDatos.Columns["FacturasA"].Width = 90;
            dgvDatos.Columns["FacturasB"].Width = 90;
            dgvDatos.Columns["NotasDeCreditoA"].Width = 90;
            dgvDatos.Columns["NotasDeCreditoB"].Width = 90;
            dgvDatos.Columns["NotasDeDebitoA"].Width = 85;
            dgvDatos.Columns["NotasDeDebitoB"].Width = 85;
            //dgvDatos.Columns["Total"].Width = 100;
        }

        DateTime desde, hasta;
        private bool Fecha()
        {
            bool res = false;
            if (rbMensual.Checked)
            {
                if (cbMeses.Items.Count > 0)
                {
                    desde = Convert.ToDateTime(cbMeses.SelectedValue + "-01");
                    hasta = Convert.ToDateTime(cbMeses.SelectedValue + "-" + DateTime.DaysInMonth(Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(0, 4)), Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(5, 2))));
                    res = true;
                }
            }
            else if (rbPersonalizado.Checked)
            {
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;
                res = true;
            }
            return res;
        }

        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = true;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
        }

        private void rbPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
        }

        //List<DataTable> lista;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = Fecha();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    //dgvDatos.DataSource = null;
                    dgvDatos.DataSource = null;
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (res == true)
                {
                  //  lista = new List<DataTable>();

                 //   lista.Add(new Logica.Factura().ObtenerIngresosBrutos(desde, hasta, Singleton.Instancia.Empresa.Codigo));
                    dgvDatos.DataSource = new Logica.Factura().ObtenerIngresosBrutos(desde, hasta, Singleton.Instancia.Empresa.Codigo);

                    if (dgvDatos.Rows.Count == 0)
                    {
                        MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }



                    /*
                    if () {

                    }
                    */

                    /*
                    if (rbVentas.Checked)
                    {

                        lista.Add(new Logica.Factura().ObtenerIVA(desde, hasta));

                        if (lista[0].Rows.Count == 0)
                        {
                            MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        frmInformes informe = new frmInformes("IVA Ventas", lista, "repIVAVentas");
                        string titulo = "IVA Ventas del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                        ReportParameter[] parametros = new ReportParameter[1];
                        parametros[0] = new ReportParameter("Titulo", titulo);
                        informe.reportViewer1.LocalReport.SetParameters(parametros);

                        informe.reportViewer1.RefreshReport();

                        Utilidades.Formularios.AbrirFuera(informe);
                    }
                    else
                    {
                        lista.Add(new Logica.FacturaCompra().ObtenerIVA(desde, hasta));

                        if (lista[0].Rows.Count == 0)
                        {
                            MessageBox.Show("No se registran Compras en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        frmInformes informe = new frmInformes("IVA Compras", lista, "repIVACompras");
                        string titulo = "IVA Compras del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                        ReportParameter[] parametros = new ReportParameter[1];
                        parametros[0] = new ReportParameter("Titulo", titulo);
                        informe.reportViewer1.LocalReport.SetParameters(parametros);

                        informe.reportViewer1.RefreshReport();

                        Utilidades.Formularios.AbrirFuera(informe);
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                bool res = Fecha();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    //dgvDatos.DataSource = null;
                    dgvDatos.DataSource = null;
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dt;
                if (res == true)
                {

                    dt = new Logica.Factura().ObtenerIngresosBrutos(desde, hasta, Singleton.Instancia.Empresa.Codigo);
                    lista.Add(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dt.TableName = "dsIngresosBrutos";

                    string titulo = "Ingresos Brutos ";

                    if (rbMensual.Checked)
                    {
                        titulo += cbMeses.Text;
                    }
                    else
                    {
                        titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                    }

                    frmInformes informe = new frmInformes("INGRESOS BRUTOS", lista, "repIngresosBrutos");

                    ReportParameter[] parametros = new ReportParameter[1];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    informe.reportViewer1.LocalReport.SetParameters(parametros);

                    informe.reportViewer1.RefreshReport();

                    Utilidades.Formularios.AbrirFuera(informe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void LlenarComboMeses()
        {
            if (rbMensual.Checked)
            {
                    Utilidades.Combo.Llenar(cbMeses, new Logica.Factura().ObtenerFechasIntegracion(Singleton.Instancia.Empresa.Codigo), "Fecha", "Meses");
            }
        }
    }
}
