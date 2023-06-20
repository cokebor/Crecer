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
    public partial class frmListadosDeCaja : Presentacion.frmColor
    {
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        Entidades.CierreDeCaja objECierreDeCaja=new Entidades.CierreDeCaja();

        Logica.CierreCaja objLCierreDeCaja = new Logica.CierreCaja();
        public frmListadosDeCaja()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
         //   LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["FechaApertura"].Width = 100;
            dgvDatos.Columns["FechaCierre"].Width = 100;

            //dgvDatos.Columns["Empleado"].Width = 130;
            dgvDatos.Columns["PuestoCaja"].Width = 100;

            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        //    dtDesde.Value = dtDesde.Value.AddDays(-15);
         //   Busqueda();
        }

        private void Titulo()
        {
            this.Text = "LISTADO DE CAJAS";
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                cbSucursales.SelectedValue = 1;
            }
        }

        DateTime desde, hasta;

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    Informe(Convert.ToInt32(cbSucursales.SelectedValue),Convert.ToInt32(row.Cells["Codigo"].Value));
                    /*switch (row.Cells["Tipo"].Value.ToString())
                    {
                        case "FA":
                        case "NC":
                        case "ND":
                       //     InformeFacturas(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                        case "LQ":
                            MessageBox.Show("Liquidaciones");
                            break;
                        case "RC":
                            MessageBox.Show("Recibo");
                            break;
                        case "CR":
                            MessageBox.Show("Contra Recibo");
                            break;
                    }*/
                }
            }
        }

        private void Informe(int pCodigoSucursal, int pCodigo) {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                List<DataTable> lista2 = new List<DataTable>();
                List<DataTable> lista3 = new List<DataTable>();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = pCodigoSucursal;
                    lista.Add(new Logica.CierreCaja().ObtenerEfectivo(pCodigo, "Dolares", "dsMovimientosDolares", objESucursal));
                    lista.Add(new Logica.CierreCaja().ObtenerEfectivo(pCodigo, "Pesos", "dsMovimientosPesos", objESucursal));
                    lista2.Add(new Logica.CierreCaja().ObtenerCheques(pCodigo, "Egreso", "dsChequesEgresos", objESucursal));
                    lista2.Add(new Logica.CierreCaja().ObtenerCheques(pCodigo, "Ingreso", "dsChequesIngresos", objESucursal));
                    lista3.Add(new Logica.Movimiento().ObtenerTransferenciasSinCierre(Singleton.Instancia.Puesto, pCodigo, objESucursal));
                }
                else
                {
                    lista.Add(new Logica.CierreCaja().ObtenerEfectivo(pCodigo, "Dolares", "dsMovimientosDolares"));
                    lista.Add(new Logica.CierreCaja().ObtenerEfectivo(pCodigo, "Pesos", "dsMovimientosPesos"));
                    lista2.Add(new Logica.CierreCaja().ObtenerCheques(pCodigo, "Egreso", "dsChequesEgresos"));
                    lista2.Add(new Logica.CierreCaja().ObtenerCheques(pCodigo, "Ingreso", "dsChequesIngresos"));
                    lista3.Add(new Logica.Movimiento().ObtenerTransferenciasSinCierre(Singleton.Instancia.Puesto,pCodigo));
                }

          
                string titulo = "Movimientos de Caja";
                
                frmInformes informe = new frmInformes("MOVIMIENTO DE CAJA", lista, "repMovimientos");
                
                titulo += " N°: " + pCodigo;

                if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                {
                    titulo += " Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }


                    

                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);

                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                
                


                frmInformes informe2 = new frmInformes("MOVIMIENTO DE CAJA", lista2, "repChequesMovimientos");

                ReportParameter[] parametros2 = new ReportParameter[3];
                parametros2[0] = new ReportParameter("Titulo", titulo);
                parametros2[1] = new ReportParameter("Tipo", "Egreso");
                parametros2[2] = new ReportParameter("Tipo2", "Ingreso");

                informe2.reportViewer1.LocalReport.SetParameters(parametros2);

                informe2.reportViewer1.RefreshReport();


                frmInformes informe3 = new frmInformes("MOVIMIENTO DE CAJA", lista3, "repMovimientosSinCierreTransferencias");

                ReportParameter[] parametros3 = new ReportParameter[1];
                parametros3[0] = new ReportParameter("Titulo", titulo);
                

                informe3.reportViewer1.LocalReport.SetParameters(parametros3);

                informe3.reportViewer1.RefreshReport();


                Utilidades.Formularios.AbrirFuera(informe, informe2, informe3);

//                Utilidades.Formularios.AbrirFuera(informe3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void Busqueda() {
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


                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dgvDatos.DataSource = objLCierreDeCaja.ObtenerTodos(desde, hasta, objESucursal);
                }
                else
                {
                    dgvDatos.DataSource = objLCierreDeCaja.ObtenerTodos(desde, hasta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
