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
    public partial class frmComprobantesDeVenta : Presentacion.frmColor
    {
        Logica.Cliente objLogicaCliente = new Logica.Cliente();


        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();

        Logica.Factura objLFactura = new Logica.Factura();
        public frmComprobantesDeVenta()
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
            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["Cliente"].Width = 200;
            dgvDatos.Columns["Tipo"].Width = 40;
            dgvDatos.Columns["Numero"].Width = 95;
            dgvDatos.Columns["TipoDocumento"].Width = 100;
            dgvDatos.Columns["FormaPago"].Width = 120;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void Titulo()
        {
            this.Text = "INFORME DE COMPROBANTES DE VENTA";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
        }


        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todas");
                cbSucursales.SelectedValue = 0;
            }
        }
        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objEntidadCliente != null)
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                    else
                        lblNombreCliente.Text = "";
                }
                else
                {
                    objEntidadCliente = new Entidades.Cliente();
                    lblNombreCliente.Text = "";
                }
                dgvDatos.DataSource = null;
                lblTotal.Text = Suma().ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClientes.Checked)
            {
                this.txtCodigoCliente.Enabled = false;
                this.lblCliente.Enabled = false;
                this.txtCodigoCliente.Text = "";
            }
            else
            {
                this.txtCodigoCliente.Enabled = true;
                this.lblCliente.Enabled = true;
                this.txtCodigoCliente.Focus();
            }
            dgvDatos.DataSource = null;
            lblTotal.Text = Suma().ToString("C2");
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    if (!cbClientes.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("ComprobantesDeVenta", this));
                    break;
            }

        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private bool Validar()
        {
            bool res = false;
            if (!cbClientes.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreCliente); }
            return res;
        }

        private double Suma()
        {
            double res = 0;
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                res += Convert.ToDouble(dr.Cells["Total"].Value);
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

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    dt = objLFactura.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta, objESucursal);
                    dgvDatos.DataSource = dt;
                }
                else
                {
                    dt = objLFactura.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta);
                    dgvDatos.DataSource = dt;
                }
                //  objLogicaRemitoCliente.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta);
                lblTotal.Text = Suma().ToString("C2");

                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran ventas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            txtCodigoCliente.Text = "";
            cbClientes.Checked = false;
            dgvDatos.DataSource = null;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    switch (row.Cells["Tipo"].Value.ToString())
                    {
                        case "FA":
                        case "NC":
                        case "ND":
                            InformeFacturas(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                        case "LQ":
                            InformeLiquidaciones(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            //MessageBox.Show("Liquidaciones");
                            break;
                        case "RC":
                            MessageBox.Show("Recibo");
                            break;
                        case "CR":
                            MessageBox.Show("Contra Recibo");
                            break;
                    }
                }
            }
        }

        private void InformeFacturas(int pCodigoSucursal, int codigoFactura)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                Logica.Factura objLFactura = new Logica.Factura();
                Entidades.Factura objEFactura = new Entidades.Factura();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = pCodigoSucursal;
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura, objESucursal);
                }
                else
                {
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura);
                }
                string codigo;
                DataTable dtEncabezado = new DataTable();
                dtEncabezado.TableName = "dsEncabezado";
                dtEncabezado.Columns.Add("TipoResponsabilidad");
                dtEncabezado.Columns.Add("Codigo");
                dtEncabezado.Columns.Add("CondicionVenta");
                dtEncabezado.Columns.Add("TipoVenta");
                dtEncabezado.Columns.Add("TotalEnLetras");


                //lista.Add(new Logica.Sucursal().ObtenerUno(Singleton.Instancia.Empresa.Codigo));
                DataTable dtEmpresa = new DataTable();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtEmpresa = new Logica.Empresa().ObtenerDataTable(objESucursal);
                }
                else
                {
                    dtEmpresa = new Logica.Empresa().ObtenerDataTable();
                }
                codigo = dtEmpresa.Rows[0]["CUIT"].ToString().Replace("-", "");
                //codigo = codigo + objEFactura.CodigoTipoDocumento.Replace("Cod. ", "");


                DataTable dtFactura = new DataTable();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo, objESucursal);
                }
                else
                {
                    dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo);
                }
                codigo = codigo + Convert.ToInt32(dtFactura.Rows[0]["PuntoDeVenta"]).ToString("0000");
                codigo = codigo + dtFactura.Rows[0]["CAE"];
                if (!dtFactura.Rows[0]["FechaVenCae"].ToString().Equals(""))
                {
                    codigo = codigo + Convert.ToDateTime(dtFactura.Rows[0]["FechaVenCae"]).ToString("yyyyMMdd");
                    codigo = FacturaElectronica.ToI2of5(codigo);
                    dtFactura.Columns.Add("CodigoBarra");
                    dtFactura.Rows[0]["CodigoBarra"] = codigo;
                }
                DataTable dtFacturaDetalle = new DataTable();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtFacturaDetalle = new Logica.FacturaDetalle().ObtenerUno(objEFactura.Codigo, objESucursal);
                }
                else
                {
                    dtFacturaDetalle = new Logica.FacturaDetalle().ObtenerUno(objEFactura.Codigo);
                }
                /*
                int renglones = 0;
                foreach (DataRow item in dtFacturaDetalle.Rows)
                {
                    renglones +=Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Convert.ToInt32(item["Producto"].ToString().Length) / (double)35)));
                }*/
                //MessageBox.Show(renglones.ToString());

                /*
                int filas = 16 - dtFacturaDetalle.Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                   dtFacturaDetalle.Rows.Add(0);
                }*/
                double tot = Convert.ToDouble(dtFactura.Rows[0]["Neto105"]) + Convert.ToDouble(dtFactura.Rows[0]["Neto21"]) + Convert.ToDouble(dtFactura.Rows[0]["Iva105"]) + Convert.ToDouble(dtFactura.Rows[0]["Iva21"]) + Convert.ToDouble(dtFactura.Rows[0]["NetoNoGravado"]) + Convert.ToDouble(dtFactura.Rows[0]["PercepcionMuni"]);

                dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoDocumentoCliente.Descripcion, Utilidades.Convertir.PrimeraLetra(Utilidades.NumeroEnLetras.Convertir(tot.ToString("#######.00"), false)));
                lista.Add(dtEmpresa);
                lista.Add(dtEncabezado);
                lista.Add(dtFactura);
                lista.Add(dtFacturaDetalle);

                frmInformes informe = new frmInformes("COMPROBANTE", lista, "repFacturas", true, true);
                ReportParameter[] parametros = new ReportParameter[2];
                string tipo = "";
                if (rbOriginal.Checked)
                    tipo = "ORIGINAL";
                else if (rbDuplicado.Checked)
                    tipo = "DUPLICADO";
                else if (rbTriplicado.Checked)
                    tipo = "TRIPLICADO";
                parametros[0] = new ReportParameter("Tipo", tipo);
                //parametros[1] = new ReportParameter("Factura", "");
                string factura = objLFactura.ObtenerFacturaAfectada(objEFactura.Codigo);
                factura += "; " + objLFactura.ObtenerObservaciones(objEFactura.TipoDocumentoCliente.Codigo, objEFactura.Codigo);
                if (factura.Length == 2)
                {
                    factura = "";
                }
                parametros[1] = new ReportParameter("Factura", factura);

                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();
                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformeLiquidaciones(int pCodigoSucursal, int pCodigo)
        {

            List<DataTable> lista = new List<DataTable>();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                objESucursal.Codigo = pCodigoSucursal;
                lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo, objESucursal));
            }
            else
            {
                lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo));
            }

            DataTable dtEmpresa = new DataTable();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtEmpresa = new Logica.Empresa().ObtenerDataTable(objESucursal);
            }
            else
            {
                dtEmpresa = new Logica.Empresa().ObtenerDataTable();
            }

            lista.Add(dtEmpresa);

            DataTable dtLiquidacionDetalle = new DataTable();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionDetalle = new Logica.FacturaDetalle().ObtenerDetalleLiquidacion(pCodigo, objESucursal);
            }
            else
            {
                dtLiquidacionDetalle = new Logica.FacturaDetalle().ObtenerDetalleLiquidacion(pCodigo);
            }


            int filas = 12 - dtLiquidacionDetalle.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionDetalle.Rows.Add(0);
            }
            lista.Add(dtLiquidacionDetalle);

            DataTable dtLiquidacionMerma = new DataTable();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo, objESucursal);
            }
            else
            {
                dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo);
            }

            filas = 3 - dtLiquidacionMerma.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionMerma.Rows.Add(0);
            }
            lista.Add(dtLiquidacionMerma);

            DataTable dtLiquidacionDetale = new DataTable();
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dtLiquidacionDetale = objLFactura.ObtenerDetallesLiquidacion(pCodigo, objESucursal);
            }
            else
            {
                dtLiquidacionDetale = objLFactura.ObtenerDetallesLiquidacion(pCodigo);
            }
            lista.Add(dtLiquidacionDetale);

            frmInformes informe = new frmInformes("LIQUIDACION DE CLIENTES", lista, "repLiquidacionCliente");


            informe.reportViewer1.RefreshReport();

            try
            {

                /*
                if (Singleton.Instancia.Empresa.Fiscal)
                {
                    Utilidades.Impresion cii = new Utilidades.Impresion();
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista);
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor2.rdlc", lista);
                }
                else
                {*/
                Utilidades.Formularios.AbrirFuera(informe);
                // }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                dgvDatos.DataSource = null;
                lblTotal.Text = Suma().ToString("C2");
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = Suma().ToString("C2");
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = Suma().ToString("C2");
        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                /*desde = dtDesde.Value.Date;
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
                    dt = objLFactura.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta, objESucursal);
                }
                else
                    dt = objLFactura.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta);
                    */
                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran datos para exportar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                dt.TableName = "dsComprobantesDeVenta";
                lista.Add(dt);
                lista.Add(new Logica.Empresa().ObtenerDataTable());

                string titulo = "Comprobantes de Venta";

                if (Convert.ToInt32(cbSucursales.SelectedValue) != 0)
                {
                    titulo += " Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }


                if (!cbClientes.Checked)
                {
                    titulo += " Cliente: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreCliente.Text);
                }



                frmInformes informe = new frmInformes("COMPROBANTES DE VENTA", lista, "repComprobantesDeVenta");
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
