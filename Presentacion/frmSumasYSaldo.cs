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
    public partial class frmSumasYSaldo : Presentacion.frmColor
    {

        private DateTime desde;
        private DateTime hasta;

        private DataTable dtSumaYSaldo;
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

        public frmSumasYSaldo(DataTable dtSumas, DateTime pDesde, DateTime pHasta)
        {
            InitializeComponent();
            Desde = pDesde;
            Hasta = pHasta;
            dgvSumas.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            dtSumaYSaldo = dtSumas;
            LlenarGrilla(dtSumas);
            Titulo();
        }

        private void Titulo()
        {
            this.Text = "Sumas y Saldos";
        }
        private void LlenarGrilla(DataTable dtSumas)
        {
            string saldoDebe = "", saldoHaber = "";
            double deudorTotal = 0, acreedorTotal = 0;
            double debeTotal = 0, haberTotal = 0;
            if (dtSumas.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSumas.Rows)
                {
                    string cuenta = dr["Cuenta"].ToString();
                    double debe = Convert.ToDouble(dr["Debe"]);
                    double haber = Convert.ToDouble(dr["Haber"]);

                    debeTotal += debe;
                    haberTotal += haber;

                    double saldo = debe - haber;
                    if (saldo == 0)
                    {
                        saldoDebe = "";
                        saldoHaber = "";
                    }
                    else if (saldo > 0)
                    {
                        saldoDebe = saldo.ToString("C2");
                        saldoHaber = "";

                        deudorTotal += saldo;
                    }
                    else if (saldo < 0)
                    {
                        saldoDebe = "";
                        saldoHaber = (-1 * saldo).ToString("C2");

                        acreedorTotal += (-1 * saldo);
                    }

                    dgvSumas.Rows.Add(cuenta, debe, haber, saldoDebe, saldoHaber);
                }
                dgvSumas.Rows.Add("");
                dgvSumas.Rows.Add("", debeTotal, haberTotal, deudorTotal, acreedorTotal);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
               // DataTable dt = Utilidades.Grilla.ObtenerDataTable(dgvSumas);
                dtSumaYSaldo.TableName = "dsSumaYSaldo";
                
                lista.Add(dtSumaYSaldo);


                frmInformes informe = new frmInformes("SUMAS Y SALDOS", lista, "repSumaYSaldos");
                string titulo = "SUMAS Y SALDOS DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
