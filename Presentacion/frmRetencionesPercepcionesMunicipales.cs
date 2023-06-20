using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRetencionesPercepcionesMunicipales : Presentacion.frmColor
    {
        public frmRetencionesPercepcionesMunicipales()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }

        private void Titulo()
        {
            this.Text = "Retenciones y Percepciones Municipales";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
            sfdVentas.Filter = "Archivos de texto (*.rtn)|*.rtn";
        }

        private void rbCompras_CheckedChanged(object sender, EventArgs e)
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

        DateTime desde, hasta;

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

        private void LlenarComboMeses()
        {
            if (rbMensual.Checked)
            {
                if (rbPercepciones.Checked)
                {
                    Utilidades.Combo.Llenar(cbMeses, new Logica.Factura().ObtenerFechasPerMunicipales(Singleton.Instancia.Empresa.Codigo), "Fecha", "Meses");
                }
                else
                {
                    Utilidades.Combo.Llenar(cbMeses, new Logica.Pago().ObtenerFechasRetMunicipales(), "Fecha", "Meses");
                }
            }
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

        //  List<Entidades.CITIVentas> lista;
        //  List<Entidades.CITICompras> listaC;

        private void frmCITIComprasyVentas_Load(object sender, EventArgs e)
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            StreamWriter objStrePercepciones = null;

            bool res = Fecha();

            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
            {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (res == true)
            {
                if (rbPercepciones.Checked)
                {
                    sfdVentas.Title = "Nombre de Archivo de Percepciones";
                    sfdVentas.FileName = "DJP" + cbMeses.SelectedValue.ToString().Substring(0, 4) + cbMeses.SelectedValue.ToString().Substring(5, 2) + ".rtn";
//                        dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00") + ".rtn";
                    if (sfdVentas.ShowDialog() == DialogResult.OK)
                    {
                        objStrePercepciones = new StreamWriter(sfdVentas.FileName, false, System.Text.Encoding.Default);


                        objStrePercepciones.Flush();
                        try
                        {
                            List<Entidades.PercepcionesMunicipales> lista = new Logica.Factura().ObtenerPercepcionesMunicipales(desde, hasta, Singleton.Instancia.Empresa.Codigo);
                            if (lista == null)
                            {
                                MessageBox.Show("No se registran Percepciones en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            foreach (Entidades.PercepcionesMunicipales item in lista)
                            {

                                objStrePercepciones.WriteLine(";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(0, 2) + ";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(2, 8) + ";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(10, 1) + ";" + item.PeriodoPresentacion() + ";" + item.NroPercepcion + ";" + item.LetraPercepcion + ";" + item.Comprobante + ";" +
                                item.TipoCuitCliente() + ";" + item.NumeroCUITCliente() + ";" + item.DigitoVerificadorCuitCliente() + ";" + item.BaseImponibleStr() + ";" + item.AlicuotaStr() + ";" + item.MontoPercepcionStr() + ";" + item.Estado + ";" + item.FechaCargaPercepcion() + ";" + item.FechaAnulacionPercepcion() + ";" + item.NombreCliente + ";" +
                                item.Calle + ";" + item.Numero + ";" + item.Piso + ";" + item.Departamento + ";" + item.BarrioLocalidad + ";" + item.CodigoPostal + ";" + item.FechaInicioPercepcionFormato() + ";"+item.FechaCambiosDatosFormato()+";");

                            }
                            MessageBox.Show("Archivo exportado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            objStrePercepciones.Close();
                        }
                    }

                }
                else
                {
                    sfdVentas.Title = "Nombre de Archivo de Retenciones";
                    sfdVentas.FileName = "DJ" + cbMeses.SelectedValue.ToString().Substring(0, 4) + cbMeses.SelectedValue.ToString().Substring(5, 2) + ".rtn";
                    if (sfdVentas.ShowDialog() == DialogResult.OK)
                    {
                        objStrePercepciones = new StreamWriter(sfdVentas.FileName, false, System.Text.Encoding.Default);


                        objStrePercepciones.Flush();
                        try
                        {
                            List<Entidades.RetencionesMunicipales> lista = new Logica.Pago().ObtenerRetencionesMunicipales(desde, hasta);
                            if (lista == null)
                            {
                                MessageBox.Show("No se registran Retenciones en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            foreach (Entidades.RetencionesMunicipales item in lista)
                            {

                                objStrePercepciones.WriteLine(";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(0, 2) + ";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(2, 8) + ";" + Singleton.Instancia.Empresa.CUITSinGuion.Substring(10, 1) + ";" + item.PeriodoPresentacion() + ";" + item.NroRetencion + ";" + item.LetraRetencion + ";" + item.Comprobante + ";" +
                                item.TipoCuitProveedor() + ";" + item.NumeroCUITProveedor() + ";" + item.DigitoVerificadorCuitProveedor() + ";" + item.BaseImponibleStr() + ";" + item.AlicuotaStr() + ";" + item.MontoRetencionStr() + ";" + item.Estado + ";" + item.FechaCargaRetencion() + ";" + item.FechaAnulacionRetencion() + ";" + item.NombreProveedor + ";" +
                                item.Calle + ";" + item.Numero + ";" + item.Piso + ";" + item.Departamento + ";" + item.BarrioLocalidad + ";" + item.CodigoPostal + ";" + item.FechaInicioRetencionFormato() + ";" + item.FechaCambiosDatosFormato() + ";");

                            }
                            MessageBox.Show("Archivo exportado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            objStrePercepciones.Close();
                        }
                    }

                }
            }


        }


    }
}
