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
    public partial class frmIVADeposito : Presentacion.frmColor
    {
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        public frmIVADeposito()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            //LimitesTamaños();
            Formatos();
            //BotonesInicial();
            CargarValores();

        }

        private void Titulo()
        {
            this.Text = "IVA";
        }

        private void LimitesTamaños()
        {
           /* Utilidades.CajaDeTexto.LimiteTamaño(txtLegajo, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtApellido, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombres, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCausa, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDireccion, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBarrio, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoPostal, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDocumento, 8);
            Utilidades.CajaDeTexto.LimiteTamaño(txtComunicacion, 40);*/
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                cbSucursales.SelectedValue = 1;
            }
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
            /*
            Utilidades.Grilla.Formato(dgvComunicaciones);
            
            Utilidades.Combo.Formato(cbPais);
            Utilidades.Combo.Formato(cbProvincias);
            Utilidades.Combo.Formato(cbLocalidades);
            Utilidades.Combo.Formato(cbSexo);
            Utilidades.Combo.Formato(cbEstadosCiviles);
            Utilidades.Combo.Formato(cbTipoDocumento);
            Utilidades.Combo.Formato(cbObraSocial);
            Utilidades.Combo.Formato(cbComunicaciones);*/
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void rbCompras_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     

        DateTime desde, hasta;

        private bool Fecha() {
            bool res = false;
            if (rbMensual.Checked) {
                if (cbMeses.Items.Count > 0) { 
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
        private void rbVentas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboMeses() {
            if (rbMensual.Checked) { 
            if (rbVentas.Checked)
            {
                    Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                Utilidades.Combo.Llenar(cbMeses, new Logica.Factura().ObtenerFechas(objESucursal), "Fecha", "Meses");
            }
            else {
                Utilidades.Combo.Llenar(cbMeses, new Logica.FacturaCompra().ObtenerFechas(), "Fecha", "Meses");
            }
            }
        }

        private void optMes_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = true;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
        }

        private void optPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
        }

        List<DataTable> lista;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                bool res=Fecha();

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    //dgvDatos.DataSource = null;
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (res == true) { 
                lista = new List<DataTable>();
                if (rbVentas.Checked)
                {

                    lista.Add(new Logica.Factura().ObtenerIVA(desde, hasta,objESucursal));

                        if (lista[0].Rows.Count == 0)
                        {
                            MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        frmInformes informe = new frmInformes("IVA Ventas", lista, "repIVAVentas");
                    string titulo = "IVA Ventas del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                    ReportParameter[] parametros = new ReportParameter[2];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    parametros[1] = new ReportParameter("Empresa", Singleton.Instancia.Empresa.RazonSocial + " Sucursal: " + cbSucursales.Text);
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
                    ReportParameter[] parametros = new ReportParameter[2];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    parametros[1] = new ReportParameter("Empresa", Singleton.Instancia.Empresa.RazonSocial);
                    informe.reportViewer1.LocalReport.SetParameters(parametros);

                    informe.reportViewer1.RefreshReport();

                    Utilidades.Formularios.AbrirFuera(informe);
                }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
            if (objESucursal.Codigo==1) {
                rbCompras.Checked = true;
                rbCompras.Enabled = true;
            } else {
                rbVentas.Checked = true;
                rbCompras.Enabled = false;
            }
            LlenarComboMeses();
        }

        private void frmIVA_Load(object sender, EventArgs e)
        {
            dtDesde.Value = Convert.ToDateTime(@"1/" + dtDesde.Value.Month + @"/" + dtDesde.Value.Year);
            try
            {
                LlenarComboMeses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
