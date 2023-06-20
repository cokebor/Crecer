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
    public partial class frmStockPorFecha : Presentacion.frmColor
    {
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        Logica.Canal objLogicaCanal = new Logica.Canal();
        public frmStockPorFecha()
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
            this.Text = "STOCK POR FECHAS";
        }

        
        private void CargarValores()
        {
            try
            {
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                    cbSucursales.SelectedValue = 1;
                }
                Utilidades.Combo.Llenar(cbCanal, objLogicaCanal.ObtenerTodos(), "Codigo", "Descripcion", "Todos");
                cbCanal.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbCanal);
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }




        DateTime hasta;
        List<DataTable> lista;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                hasta = dtFecha.Value;
                lista = new List<DataTable>();
                
                 objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                Entidades.Canal objECanal = new Entidades.Canal();
                objECanal.Codigo = Convert.ToInt32(cbCanal.SelectedValue);
                // dvProductos = objLProducto.ObtenerTodos(objESucursal).DefaultView;
                if (Singleton.Instancia.Empresa.Codigo == 1)
                    lista.Add(new Logica.MovStock_Lote().ObtenerStockPorFecha(hasta,objECanal,objESucursal));
                else
                    lista.Add(new Logica.MovStock_Lote().ObtenerStockPorFecha(hasta,objECanal));
                if (lista[0].Rows.Count == 0)
                        {
                            MessageBox.Show("No se registra Stock a la Fecha indicada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                frmInformes informe = new frmInformes("INFORME DE STOCK POR FECHA", lista, "repStock");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", "Informe de Stock al " + hasta.Date.ToString("dd/MM/yyyy") + " Sucursal: " + cbSucursales.Text +"\nCanal: " + cbCanal.Text);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                

                    informe.reportViewer1.RefreshReport();

                    Utilidades.Formularios.AbrirFuera(informe);
               
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
