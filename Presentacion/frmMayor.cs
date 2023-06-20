using Microsoft.Reporting.WinForms;
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
    public partial class frmMayor : Presentacion.frmColor
    {
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();

        private DateTime desde;
        private DateTime hasta;
        //private DateTime fechaInicioEjercicio;
        private Entidades.Ejercicio pEjercicio=new Ejercicio();
        private bool porFechaEmision;

        public DateTime Desde
        {
            get
            {
                return desde;
            }

            set
            {
                desde = value;
            }
        }
        /*public DateTime FechaInicioEjercicio
        {
            get
            {
                return fechaInicioEjercicio;
            }

            set
            {
                fechaInicioEjercicio = value;
            }
        }*/
        public DateTime Hasta
        {
            get
            {
                return hasta;
            }

            set
            {
                hasta = value;
            }
        }

        public Ejercicio PEjercicio
        {
            get
            {
                return pEjercicio;
            }

            set
            {
                pEjercicio = value;
            }
        }

        public bool PorFechaEmision
        {
            get
            {
                return porFechaEmision;
            }

            set
            {
                porFechaEmision = value;
            }
        }

        public frmMayor(DateTime pDesde, DateTime pHasta, Entidades.Ejercicio pEjercicio, bool pPorFechaEmision)
        {
            InitializeComponent();
            dgvAsientos.AutoGenerateColumns = false;
            Desde = pDesde;
            Hasta = pHasta;
            PEjercicio = pEjercicio;
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Formularios.ConfiguracionInicial(this);
            PorFechaEmision = pPorFechaEmision;
            CargarCuentas(pPorFechaEmision);
            Titulo();
        }

        private void Titulo()
        {
            this.Text = "Libro Mayor";
        }

        private void CargarCuentas(bool pPorFechaEmision)
        {
            try
            {
                Utilidades.Combo.Llenar(cbCuentaContable, objLCuentaContable.ObtenerDelPeriodo(Desde, Hasta, Singleton.Instancia.Empresa.Codigo, pPorFechaEmision), "Codigo", "NombreCompleto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarGrilla()
        {
            DataTable dtMayor= new Logica.Asiento().LibroMayor(Desde, Hasta,PEjercicio.FechaInicio, Convert.ToInt64(cbCuentaContable.SelectedValue), Singleton.Instancia.Empresa.Codigo, PorFechaEmision);
            dgvAsientos.DataSource = dtMayor;
            /*double saldo = 0;
            dgvAsientos.Rows.Clear();
            if (dtMayor.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMayor.Rows)
                {
                    string fecha = dr["Fecha"].ToString();
                    string descripcion = dr["Descripcion"].ToString();
                    double importe = Convert.ToDouble(dr["Importe"]);
                    int numero = Convert.ToInt32(dr["Numero"]);

                    if (Convert.ToInt32(dr["Tipo"]) == 0)
                    {
                        saldo += importe;
                        dgvAsientos.Rows.Add(fecha, numero, descripcion, importe, "", saldo);
                    }
                    else {
                        saldo -= importe;
                        dgvAsientos.Rows.Add(fecha, numero, descripcion, "", importe, saldo);
                    }
                    
                }
                
                
            }*/
        }

        private void cbCuentaContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarGrilla();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try {
                DataTable dt = new Logica.Asiento().LibroMayor(Desde, Hasta, pEjercicio.FechaInicio, Convert.ToInt64(cbCuentaContable.SelectedValue), Singleton.Instancia.Empresa.Codigo, PorFechaEmision);
                dt.TableName = "dsLibroMayor";
                lista.Add(dt);
                
                
                frmInformes informe = new frmInformes("LIBRO MAYOR", lista, "repLibroMayor");
                string titulo = "LIBRO MAYOR DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/") + "\n" + "CUENTA CONTABLE: " + cbCuentaContable.Text;
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Utilidades.Formularios.Abrir(this.MdiParent, new frmMayorCompleto(desde, hasta, PEjercicio, PorFechaEmision));
        }
    }
}
