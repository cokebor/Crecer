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
    public partial class frmVentaPorEmpleado : Presentacion.frmColor
    {

        Entidades.Sucursal objESucursal = new Entidades.Sucursal();


        public frmVentaPorEmpleado()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            /*Formatos();
            BotonesInicial();
            
            CargarValores();*/
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void Titulo()
        {
            this.Text = "INFORME DE VENTAS POR EMPLEADO";
        }

        private void LimitesTamaños()
        {
            ;
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                cbSucursales.SelectedValue = 1;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;


            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
            {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<DataTable> lista = new List<DataTable>();
            try
            {
                if (rbVentasPorEmpleado.Checked)
                {
                    if (Singleton.Instancia.Empresa.Codigo == 1)
                    {
                        objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                        lista.Add(new Logica.Factura().VentasPorEmpleados(desde, hasta, objESucursal));
                    }
                    else
                        lista.Add(new Logica.Factura().VentasPorEmpleados(desde, hasta));

                    if (lista[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se registran ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    string titulo = "";

                    if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                    {
                        titulo += @"Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                    }

                    frmInformes informe = new frmInformes("INFORME DE VENTA POR EMPLEADOS", lista, "repVentasEmpleados");
                    //frmInformes informe = new frmInformes("INFORME DE VENTA POR EMPLEADOS", lista, "repVentasPorEmpleado");
                    titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");

                    ReportParameter[] parametros = new ReportParameter[1];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    informe.reportViewer1.LocalReport.SetParameters(parametros);

                    informe.reportViewer1.RefreshReport();
                    Utilidades.Formularios.AbrirFuera(informe);
                }
                else if (rbventaEmpleadoDetallado.Checked)
                {
                    if (Singleton.Instancia.Empresa.Codigo == 1)
                    {
                        objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                        lista.Add(new Logica.Factura().VentasPorEmpleadosDetalle(desde, hasta, objESucursal));
                    }
                    else
                        lista.Add(new Logica.Factura().VentasPorEmpleadosDetalle(desde, hasta));

                    if (lista[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se registran ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    string titulo = "";

                    if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                    {
                        titulo += @"Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                    }

                    frmInformes informe = new frmInformes("INFORME DE VENTA POR EMPLEADOS", lista, "repVentasEmpleadosDetalle");
                    
                    titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");

                    ReportParameter[] parametros = new ReportParameter[1];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    
                    informe.reportViewer1.RefreshReport();
                    Utilidades.Formularios.AbrirFuera(informe);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            rbVentasPorEmpleado.Checked = true;

        }
    }
}
