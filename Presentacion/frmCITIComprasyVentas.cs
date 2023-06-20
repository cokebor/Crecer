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
	public partial class frmCITIComprasyVentas : Presentacion.frmColor
	{
		public frmCITIComprasyVentas()
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
            this.Text = "CITI Compras y Ventas";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbMeses);
            sfdVentas.Filter = "Archivos de texto (*.txt)|*.txt";
            sfdAlicuotasVentas.Filter = "Archivos de texto (*.txt)|*.txt";
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
                if (rbVentas.Checked)
                {
                    Utilidades.Combo.Llenar(cbMeses, new Logica.Factura().ObtenerFechasIntegracion(Singleton.Instancia.Empresa.Codigo), "Fecha", "Meses");
                }
                else
                {
                    Utilidades.Combo.Llenar(cbMeses, new Logica.FacturaCompra().ObtenerFechas(), "Fecha", "Meses");
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

        List<Entidades.CITIVentas> lista;
        List<Entidades.CITICompras> listaC;

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
            StreamWriter objStreVentas = null;
            StreamWriter objStreAlicuotasVentas = null;
            
                bool res = Fecha();
                
                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (res == true)
                {
                    lista = new List<Entidades.CITIVentas>();
                    if (rbVentas.Checked)
                    {
                    sfdVentas.Title = "Nombre de Archivo de Ventas";
                    sfdAlicuotasVentas.Title = "Nombre de Archivo de Alicuotas Ventas";
                    if (sfdVentas.ShowDialog() == DialogResult.OK)
                        {
                            if (sfdAlicuotasVentas.ShowDialog() == DialogResult.OK)
                            {

                                objStreVentas = new StreamWriter(sfdVentas.FileName,false, System.Text.Encoding.Default);
                                objStreAlicuotasVentas = new StreamWriter(sfdAlicuotasVentas.FileName, false, System.Text.Encoding.Default);
                                objStreVentas.Flush();
                                objStreAlicuotasVentas.Flush();
                                try
                                {
                                    lista = new Logica.Factura().ObtenerCITIVentas(desde, hasta, Singleton.Instancia.Empresa.Codigo);
                                    if (lista == null)
                                    {
                                        MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    foreach (Entidades.CITIVentas item in lista)
                                    {
                                        objStreVentas.WriteLine(item.Fecha.ToString("yyyyMMdd") +item.CodigoTipoDocumentoAFIP.ToString("000")+item.PuntoDeVenta.ToString("00000")+item.Numero.ToString().PadLeft(20,'0') + item.Numero.ToString().PadLeft(20, '0')+ item.CodigoDocumentoComprador.ToString("00")+item.CUIT.PadLeft(20,'0') 
                                            +item.Cliente.PadRight(30)+item.Total.ToString().PadLeft(15,'0')+item.TotalConceptosQueNoIntegranNetoGravado.ToString().PadLeft(15,'0')+item.PercepcionNoCategorizados.ToString().PadLeft(15,'0')+item.OperacionesExentas.ToString().PadLeft(15,'0') + item.ImportePercepciones.ToString().PadLeft(15, '0')+item.ImportePercepcionesIIBB.ToString().PadLeft(15, '0')+item.ImportePercepcionesMunicipales.ToString().PadLeft(15, '0')+item.ImporteImpuestosInternos.ToString().PadLeft(15, '0')+item.CodigoMoneda+item.TipoCambio.ToString("0000")+"000000"+item.CantAlicuotas().ToString()+item.CodigoOperacion+item.OtrosTributos.ToString().PadLeft(15, '0')+"00000000");
                                        //"coke".PadRight(20)
                                        foreach (Entidades.CITIVentasAlicuotas item2 in item.Alicuotas)
                                        {
                                            objStreAlicuotasVentas.WriteLine(item.CodigoTipoDocumentoAFIP.ToString("000") + item.PuntoDeVenta.ToString("00000") + item.Numero.ToString().PadLeft(20, '0')+item2.NetoGravado.ToString().PadLeft(15, '0') +item2.CodigoAlicuotaAFIP.ToString("0000")+item2.ImpuestoLiquidado.ToString().PadLeft(15, '0'));
                                        }
                                    }
                                    MessageBox.Show("Archivos exportados exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    objStreVentas.Close();
                                    objStreAlicuotasVentas.Close();
                                }

                            }
                        }



                    }
                    else
                    {
                        sfdVentas.Title = "Nombre de Archivo de Compras";
                        sfdAlicuotasVentas.Title = "Nombre de Archivo de Alicuotas Compras";
                        if (sfdVentas.ShowDialog() == DialogResult.OK)
                        {
                            if (sfdAlicuotasVentas.ShowDialog() == DialogResult.OK)
                            {
                                objStreVentas = new StreamWriter(sfdVentas.FileName, false, System.Text.Encoding.Default);
                            objStreAlicuotasVentas = new StreamWriter(sfdAlicuotasVentas.FileName, false, System.Text.Encoding.Default);
                            objStreVentas.Flush();
                                objStreAlicuotasVentas.Flush();
                                try
                                {
                                    listaC = new Logica.Factura().ObtenerCITICompras(desde, hasta, Singleton.Instancia.Empresa);
                                    if (listaC == null)
                                    {
                                        MessageBox.Show("No se registran Compras en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    foreach (Entidades.CITICompras item in listaC)
                                    {
                                    objStreVentas.WriteLine(item.Fecha.ToString("yyyyMMdd") + item.CodigoTipoDocumentoAFIP.ToString("000") + item.PuntoDeVenta.ToString("00000") + item.Numero.ToString().PadLeft(20, '0') + item.DespachoImportacion.PadRight(16) + item.CodigoDocumentoVendedor.ToString("00") + item.CUIT.PadLeft(20, '0') + item.Proveedor.PadRight(30) + item.Total.ToString().PadLeft(15, '0') + item.TotalConceptosQueNoIntegranNetoGravado.ToString().PadLeft(15, '0')
                                                                                                                                                                                                                                                                                                                                                                             + item.OperacionesExentas.ToString().PadLeft(15, '0') + item.ImportePercepcionesIVA.ToString().PadLeft(15, '0') + item.ImportePercepciones.ToString().PadLeft(15, '0') + item.ImportePercepcionesIIBB.ToString().PadLeft(15, '0') + item.ImportePercepcionesMunicipales.ToString().PadLeft(15, '0')
                                                                                                                                                                                                                                                                                                                                                                             + item.ImporteImpuestosInternos.ToString().PadLeft(15, '0') + item.CodigoMoneda + item.TipoCambio.ToString("0000") + "000000" + item.CantAlicuotas().ToString() + item.CodigoOperacion +item.CreditoFiscal.ToString().PadLeft(15, '0') + item.OtrosTributos.ToString().PadLeft(15, '0') +item.CUITEmisor.PadLeft(11, '0')
                                                                                                                                                                                                                                                                                                                                                                             + item.NombreEmisor.PadRight(30)+item.IVAComision.ToString().PadLeft(15, '0'));
                                    foreach (Entidades.CITIVentasAlicuotas item2 in item.Alicuotas)
                                    {
                                        objStreAlicuotasVentas.WriteLine(item.CodigoTipoDocumentoAFIP.ToString("000") + item.PuntoDeVenta.ToString("00000") + item.Numero.ToString().PadLeft(20, '0')+ item.CodigoDocumentoVendedor.ToString("00") + item.CUIT.PadLeft(20, '0')+item2.NetoGravado.ToString().PadLeft(15, '0') + item2.CodigoAlicuotaAFIP.ToString("0000")+item2.ImpuestoLiquidado.ToString().PadLeft(15, '0'));
                                    }
                                }
                                MessageBox.Show("Archivos exportados exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    objStreVentas.Close();
                                    objStreAlicuotasVentas.Close();
                                }
                    }
                        }
                            /* lista.Add(new Logica.FacturaCompra().ObtenerIVA(desde, hasta));

                             if (lista[0].Rows.Count == 0)
                             {
                                 MessageBox.Show("No se registran Compras en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 return;
                             }
                */
                        }
                }
            

        }

        
    }
}
