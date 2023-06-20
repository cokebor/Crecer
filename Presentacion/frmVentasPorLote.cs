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
    public partial class frmVentasPorLote : Presentacion.frmColor
    {
        Entidades.Lote objELote = new Entidades.Lote();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();

        Logica.Lote objLLote = new Logica.Lote();
        Logica.Venta objLVenta = new Logica.Venta();
        Logica.Merma objLMerma = new Logica.Merma();
       /* Logica.Cliente objLogicaCliente = new Logica.Cliente();


        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        

        Logica.Factura objLFactura = new Logica.Factura();*/
        public frmVentasPorLote()
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
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Fecha"].Width = 80;
            dgvDatos.Columns["Comprobante"].Width = 170;
            dgvDatos.Columns["Numero"].Width = 110;


            dgvDatos.Columns["Cliente"].Width = 200;
            //dgvDatos.Columns["Tipo"].Width = 40;
            
            
            dgvDatos.Columns["Cantidad"].Width = 80;
            dgvDatos.Columns["PrecioUnitario"].Width = 80;
            dgvDatos.Columns["Total"].Width = 80;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblPromedioSinMerma.Text= Convert.ToDouble("0").ToString("C2");
            lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");
            lblCantidadVendida.Text = Convert.ToInt32("0").ToString();
            lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
            if (Singleton.Instancia.Empresa.Codigo == 1) {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void Titulo()
        {
            this.Text = "VENTAS POR LOTE";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 5);
        }


        private void CargarValores() {
            if (Singleton.Instancia.Empresa.Codigo == 1) {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todas");
                cbSucursales.SelectedValue = 0;
            }
        }
        private void txtCodigoLote_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                Limpiar2();
                if (!txtCodigoLote.Text.Trim().Equals(""))
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(txtCodigoLote.Text.Trim()));
                    if (objELote != null)
                        lblNombreLote.Text = "(" + objELote.Producto.Codigo +") " + objELote.Producto.Descripcion + " - " + objELote.Proveedor.Nombre;
                    else
                        lblNombreLote.Text = "";
                }
                else
                {
                    objELote = new Entidades.Lote();
                    lblNombreLote.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                dgvDatos.DataSource = null;
                lblTotal.Text = Suma().ToString("C2");
                lblCantidadVendida.Text = SumaCantidad().ToString();
                lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
                lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
                lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreLote); 
            return res;
        }
        
        private double Suma() {
            double res = 0;
            foreach (DataGridViewRow dr in dgvDatos.Rows) {
                res += Convert.ToDouble(dr.Cells["Total"].Value);
            }
            return res;
        }

        private int SumaCantidad()
        {
            int res = 0;
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                res += Convert.ToInt32(dr.Cells["Cantidad"].Value);
            }
            return res;
        }
        DateTime desde, hasta;
        DataTable dt = new DataTable();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;


                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    dgvDatos.DataSource = null;
                    lblTotal.Text = Suma().ToString("C2");
                    lblCantidadVendida.Text = SumaCantidad().ToString();
                    lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
                    lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
                    lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (Validar().Equals(true))
                {
                    dgvDatos.DataSource = null;
                    lblTotal.Text=Suma().ToString("C2");
                    lblCantidadVendida.Text = SumaCantidad().ToString();
                    lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
                    lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");
                    lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
                    MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Singleton.Instancia.Empresa.Codigo == 1) {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dt= objLVenta.ObtenerTodosPorLote(objELote, desde, hasta, objESucursal);
                    dgvDatos.DataSource = dt;
                    lblCantidadMerma.Text = objLMerma.ObtenerCantidad(objELote, desde, hasta, objESucursal).ToString();
                    PonerNegrita();
                }
                else { 
                     dt = objLVenta.ObtenerTodosPorLote(objELote, desde, hasta);
                    dgvDatos.DataSource = dt;
                    lblCantidadMerma.Text = objLMerma.ObtenerCantidad(objELote, desde, hasta).ToString();
                    PonerNegrita();
                }


                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //  objLogicaRemitoCliente.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta);
                lblCantidadVendida.Text = SumaCantidad().ToString();
                if (SumaCantidad() == 0) {
                    lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
                }
                else
                lblPromedioSinMerma.Text = Convert.ToDouble(Suma() / SumaCantidad()).ToString("C2");
                lblTotal.Text=Suma().ToString("C2");
                lblPromedioConMerma.Text = Convert.ToDouble(Suma()/ (SumaCantidad() + Convert.ToInt32(lblCantidadMerma.Text.Trim()))).ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        
    }

        private void PonerNegrita()
        {
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                if ((dg.Cells["Comprobante"].Value).Equals(@"Nota de Crédito Cta Cte ""A"" L")) { 
                    dg.Cells["Fecha"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Comprobante"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Numero"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Cliente"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Cantidad"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["PrecioUnitario"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Total"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Italic);
                    dg.Cells["Fecha"].Style.ForeColor = Color.Blue;
                    dg.Cells["Comprobante"].Style.ForeColor = Color.Blue;
                    dg.Cells["Numero"].Style.ForeColor = Color.Blue;
                    dg.Cells["Cliente"].Style.ForeColor = Color.Blue;
                    dg.Cells["Cantidad"].Style.ForeColor = Color.Blue;
                    dg.Cells["PrecioUnitario"].Style.ForeColor = Color.Blue;
                    dg.Cells["Total"].Style.ForeColor = Color.Blue;
                    dg.Cells["Fecha"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["Comprobante"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["Numero"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["Cliente"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["Cantidad"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["PrecioUnitario"].Style.SelectionForeColor = Color.Blue;
                    dg.Cells["Total"].Style.SelectionForeColor = Color.Blue;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoLote.Text = "";
            Limpiar();
        }

        private void Limpiar() {
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            dgvDatos.DataSource = null;
            lblCantidadVendida.Text = SumaCantidad().ToString();
            lblTotal.Text = Suma().ToString();
            lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
            lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
            lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");

        }

        private void Limpiar2()
        {
            dgvDatos.DataSource = null;
            lblCantidadVendida.Text = SumaCantidad().ToString();
            lblTotal.Text = Suma().ToString();
            lblCantidadMerma.Text = Convert.ToInt32("0").ToString();
            lblPromedioSinMerma.Text = Convert.ToDouble("0").ToString("C2");
            lblPromedioConMerma.Text = Convert.ToDouble("0").ToString("C2");

        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            
            List<DataTable> lista = new List<DataTable>();
            try
            {
               /* desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;
                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    dgvDatos.DataSource = null;
                    lblTotal.Text = Suma().ToString("C2");
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (Validar().Equals(true))
                {
                    dgvDatos.DataSource = null;
                    lblTotal.Text = Suma().ToString("C2");
                    MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt;
                 if (Singleton.Instancia.Empresa.Codigo == 1) {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dt = objLVenta.ObtenerTodosPorLote(objELote, desde, hasta, objESucursal);
                }
                else
                    dt = objLVenta.ObtenerTodosPorLote(objELote, desde, hasta);
                    */

                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran datos para exportar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                dt.TableName = "dsVentasPorLote";
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                lista.Add(dt);

                string titulo = "Ventas por Lote";

                if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                {
                    titulo += " Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }


            
                    titulo += " Lote: " + txtCodigoLote.Text.Trim() + " " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreLote.Text);
            



                frmInformes informe = new frmInformes("COMPROBANTES DE VENTA", lista, "repVentasPorLote");
                titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                //string titulo = "COMPROBANTES DE VENTA DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
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
