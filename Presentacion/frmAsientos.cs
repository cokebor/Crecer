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
    public partial class frmAsientos : Presentacion.frmColor
    {
        private DateTime desde;
        private DateTime hasta;
        private DataTable dtAsientos;
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

        public DataTable DtAsientos
        {
            get
            {
                return dtAsientos;
            }

            set
            {
                dtAsientos = value;
            }
        }

        public frmAsientos(DataTable dtAsientos, DateTime pDesde, DateTime pHasta)
        {
            InitializeComponent();
            Titulo();
            Desde = pDesde;
            Hasta = pHasta;
            dgvAsientos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            DtAsientos = dtAsientos;
            LlenarGrilla(dtAsientos);
        }

        private void Titulo() {
            this.Text = "Asientos Contables";
        }
        private void LlenarGrilla(DataTable dtAsientos)
        {
           // string saldoDebe = "", saldoHaber = "";
           // double deudorTotal = 0, acreedorTotal = 0;
            double debeTotal = 0, haberTotal = 0;
            
            if (dtAsientos.Rows.Count > 0)
            {
                foreach (DataRow dr in dtAsientos.Rows)
                {
                    double debe = 0, haber = 0;
                    string concepto = dr["Concepto"].ToString();
                    if (!dr["Debe"].ToString().Equals(""))
                    {
                        debe = Convert.ToDouble(dr["Debe"]);
                        debeTotal += debe;
                    }
                    if (!dr["Haber"].ToString().Equals(""))
                    {
                        haber = Convert.ToDouble(dr["Haber"]);
                        haberTotal += haber;
                    }

                    if (debe == 0)
                    {
                        if (haber == 0)
                        {
                            dgvAsientos.Rows.Add(concepto, "", "");
                        }
                        else
                        {
                            dgvAsientos.Rows.Add(concepto, "", haber);
                        }
                    }
                    else
                    {
                        if (haber == 0)
                        {
                            dgvAsientos.Rows.Add(concepto, debe, "");
                        }
                        else
                        {
                            dgvAsientos.Rows.Add(concepto, debe, haber);
                        }

                    }
                }
                 //   dgvAsientos.Rows.Add("");
                dgvAsientos.Rows.Add("", debeTotal, haberTotal);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                /* DataTable dt = Utilidades.Grilla.ObtenerDataTable(dgvAsientos);
                 dt.TableName = "dsAsientos";

                 lista.Add(dt);


                 frmInformes informe = new frmInformes("ASIENTOS", lista, "repAsientos");
                 string titulo = "ASIENTOS CONTABLES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
                 ReportParameter[] parametros = new ReportParameter[1];
                 parametros[0] = new ReportParameter("Titulo", titulo);
                 informe.reportViewer1.LocalReport.SetParameters(parametros);

                 informe.reportViewer1.RefreshReport();

                 Utilidades.Formularios.AbrirFuera(informe);*/
                DtAsientos.TableName = "dsAsientos";
                lista.Add(DtAsientos);
                frmInformes informe = new frmInformes("ASIENTOS", lista, "repAsientos");
                string titulo = "ASIENTOS CONTABLES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
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
