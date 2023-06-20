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
    public partial class frmListados : Presentacion.frmColor
    {
        Logica.Ejercicio objLEjercicio = new Logica.Ejercicio();
        Logica.Asiento objLAsiento = new Logica.Asiento();

        Entidades.Ejercicio objEEjercicio = new Entidades.Ejercicio();
        public frmListados()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            
            Titulo();
            
            /*
                        LimitesTamaños();
                        */
                        Formatos();
            /*
                        BotonesInicial();
                        */
            CargarValores();
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbEjercicio);
            Utilidades.Combo.Formato(cbMeses);
        }

        private void CargarValores()
        {
            TraerEjercicios();
        }

        private void Titulo()
        {
            this.Text = "INFORMES DE ASIENTOS";
        }

        private void TraerEjercicios()
        {
            try
            {
                Utilidades.Combo.Llenar(cbEjercicio,objLEjercicio.ObtenerTodos(),"Codigo","Descripcion");
                MostrarFechayEjercicio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void optPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
            MostrarFechayEjercicio();
        }

        private void optMes_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = true;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
            MostrarFechayEjercicio();
        }

        private void optPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            cbMeses.Enabled = false;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
            MostrarFechayEjercicio();
        }

        private void cbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarFechayEjercicio();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFechayEjercicio() {

            if (cbEjercicio.SelectedValue != null) { 
                objEEjercicio = objLEjercicio.ObtenerUno(Convert.ToInt32(cbEjercicio.SelectedValue));


                lblDesde.Text = objEEjercicio.FechaInicio.ToString("d").Replace("-","/");
                lblHasta.Text = objEEjercicio.FechaFinal.ToString("d").Replace("-", "/");
                
                dtDesde.MinDate = Convert.ToDateTime("01/01/1753");
                dtDesde.MaxDate = Convert.ToDateTime("31/12/9998");

                dtDesde.MinDate = objEEjercicio.FechaInicio;
                dtDesde.MaxDate = objEEjercicio.FechaFinal;

                dtHasta.MinDate = Convert.ToDateTime("01/01/1753");
                dtHasta.MaxDate = Convert.ToDateTime("31/12/9998");

                dtHasta.MinDate = objEEjercicio.FechaInicio;
                dtHasta.MaxDate = objEEjercicio.FechaFinal;
                
                dtDesde.Value = objEEjercicio.FechaInicio;
                dtHasta.Value = objEEjercicio.FechaFinal;

                Utilidades.Combo.Llenar(cbMeses, objLAsiento.ObtenerFechas(objEEjercicio, Singleton.Instancia.Empresa.Codigo, rbFechaEmision.Checked), "Fecha", "Meses");
            }
        }

        //List<DataTable> lista;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                
                bool res=Fecha();
                //    lista = new List<DataTable>();
                //    ReportParameter[] parametros = new ReportParameter[1];
                //    frmInformes informe=null;
                if (res == true) {
                    if (objEEjercicio.Descripcion != null) {
                        /*objEEjercicio.FechaInicio = desde;
                        objEEjercicio.FechaFinal = hasta;*/
                        objLAsiento.Ordenar(objEEjercicio, Singleton.Instancia.Empresa.Codigo, rbFechaEmision.Checked);
                if (rbAsientos.Checked)
                {
                    //      lista.Add(new Logica.Asiento().Obtener(desde, hasta));
                    //      informe = new frmInformes("ASIENTOS", lista, "repAsientos");
                    //frmInformes informe = new frmInformes("LISTADO DE EMPLEADOS", lista, "repFacturas");

                    //       string titulo = "Asientos desde " + desde.ToString("d").Replace("-", "/") + " hasta " + hasta.ToString("d").Replace("-", "/");
                    //       parametros[0] = new ReportParameter("Titulo", titulo);

                    DataTable dtAsientos = new Logica.Asiento().Obtener(desde, hasta, Singleton.Instancia.Empresa.Codigo,rbFechaEmision.Checked);
                    frmAsientos asientos = new frmAsientos(dtAsientos,desde,hasta);

                    
                    Utilidades.Formularios.Abrir(this.MdiParent, asientos);
                    
                }
                else if (rbSumasySaldos.Checked)
                {
                    /*lista.Add(new Logica.Asiento().SumaYSaldo(desde, hasta));
                    informe = new frmInformes("SUMA Y SALDOS", lista, "repSumaYSaldos");

                    string titulo = "Suma y Saldo desde " + desde.ToString("d").Replace("-", "/") + " hasta " + hasta.ToString("d").Replace("-", "/");
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    */

                    DataTable dtSumas = new Logica.Asiento().SumaYSaldo(desde, hasta, Singleton.Instancia.Empresa.Codigo, rbFechaEmision.Checked);
                    frmSumasYSaldo sumas = new frmSumasYSaldo(dtSumas,desde, hasta);
                    Utilidades.Formularios.Abrir(this.MdiParent, sumas);
                }
                else if (rbLibroMayor.Checked) {
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmMayor(desde,hasta,objEEjercicio, rbFechaEmision.Checked));
                        }

                }
                }
                /*
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
                */
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime desde, hasta;

        private void frmListados_Load(object sender, EventArgs e)
        {

        }

        private void rbLibroMayor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbSumasySaldos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFechaEmision_CheckedChanged(object sender, EventArgs e)
        {
            MostrarFechayEjercicio();
        }

        private void rbFechaContable_CheckedChanged(object sender, EventArgs e)
        {
            MostrarFechayEjercicio();
        }

        private bool Fecha() {
            bool res = false;
            try
            {
                
                if (optPeriodo.Checked)
                {
                    if (objEEjercicio.Descripcion != null) { 
                        desde = objEEjercicio.FechaInicio;
                        hasta = objEEjercicio.FechaFinal;
                        res = true;
                    }
                }
                else if (optMes.Checked)
                {
                    if (cbMeses.Items.Count > 0) { 
                    desde = Convert.ToDateTime(cbMeses.SelectedValue + "-01");
                    hasta = Convert.ToDateTime(cbMeses.SelectedValue + "-" + DateTime.DaysInMonth(Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(0, 4)), Convert.ToInt32(cbMeses.SelectedValue.ToString().Substring(5, 2))));
                    res = true;
                    }
                }
                else if (optPersonalizado.Checked) {
                    desde = dtDesde.Value.Date;
                    hasta = dtHasta.Value.Date;
                    res = true;
                }
                return res;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

    
    }
}
