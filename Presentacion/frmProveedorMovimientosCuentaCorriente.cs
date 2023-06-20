using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Microsoft.Reporting.WinForms;

namespace Presentacion
{
    public partial class frmProveedorMovimientosCuentaCorriente : Presentacion.frmColor
    {
        private Entidades.Proveedor proveedor;
        //DataView dvMovimientos = new DataView();

        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();

        DataTable dtMovimientos;
        public frmProveedorMovimientosCuentaCorriente(Entidades.Proveedor pProveedor)
        {
            InitializeComponent();
            Proveedor = pProveedor;
            ConfiguracionInicial();
            CargarValores();
        }

        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        private void ConfiguracionInicial() {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AllowUserToOrderColumns = false;
            dtDesde.Value = dtDesde.Value.AddDays(-10);
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["FechaContable"].Width = 65;
            dgvDatos.Columns["TipoDocumento"].Width = 140;
            dgvDatos.Columns["Numero"].Width = 95;
            dgvDatos.Columns["Remito"].Width = 60;
            dgvDatos.Columns["Debito"].Width = 100;
            dgvDatos.Columns["Credito"].Width = 100;
            dgvDatos.Columns["Suma"].Width = 100;

            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
        }

        private void Titulo()
        {
            this.Text = "MOVIMIENTOS CUENTA CORRIENTE PROVEEDOR " + Proveedor.Nombre;
        }

        private void CargarValores()
        {
            try
            {

                dtMovimientos = objLFactura.ObtenerFacturasCuentaCorriente(Proveedor, dtDesde.Value);//objLProducto.ObtenerTodos().DefaultView;
                                                                                                     /*
                                                                                                     if (cbStockCero.Checked)
                                                                                                         dvProductos.RowFilter = "Stock<>0";*/
                                                                                                     // dgvDatos.DataSource = dtMovimientos;
                if (dtMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Movimientos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //dtMovimientos.Columns.Add("Total2", Type.GetType("System.Double"));

                dgvDatos.DataSource = dtMovimientos;
                /*dgvDatos.Rows.Clear();*/
                double total = 0;
                DataRow fila = dtMovimientos.Rows[dtMovimientos.Rows.Count - 1];
                total = Convert.ToDouble(fila["Total"]);

               /*foreach (DataRow dr in dtMovimientos.Rows) {
                    dtMovimientos.Rows.Count
                //    total += Convert.ToDouble(dr["Total"]);
                 //   dr["Total2"] = total;
                //    dgvDatos.Rows.Add(Convert.ToInt32(dr["Codigo"]), dr["CodigoTipoDoc"], dr["Fecha"], dr["FechaContable"], dr["TipoDocumento"], dr["Numero"], dr["Debito"], dr["Credito"], total);
                }*/

                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void cbSaldo_CheckedChanged(object sender, EventArgs e)
        {
           // dgvDatos.Rows.Clear();
            if (cbSaldo.Checked)
            {
                dgvDatos.Columns["Debito"].HeaderText = "Total";
                dgvDatos.Columns["Debito"].DataPropertyName = "Total";
                dgvDatos.Columns["Credito"].HeaderText = "Imputado";
                dgvDatos.Columns["Credito"].DataPropertyName = "Imputado";
                dgvDatos.Columns["Suma"].HeaderText = "Saldo";
                dgvDatos.Columns["Suma"].DataPropertyName = "Saldo";
                CargarValoresSinImputar();
                dtDesde.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else {
                dgvDatos.Columns["Debito"].HeaderText = "Débito";
                dgvDatos.Columns["Debito"].DataPropertyName = "Debito";
                dgvDatos.Columns["Credito"].HeaderText = "Crédito";
                dgvDatos.Columns["Credito"].DataPropertyName = "Credito";
                dgvDatos.Columns["Suma"].HeaderText = "Suma";
                dgvDatos.Columns["Suma"].DataPropertyName = "Total";
                CargarValores();
                dtDesde.Enabled = true;
                btnBuscar.Enabled = true;
            }
        }

        private void CargarValoresSinImputar()
        {
            try
            {
                dtMovimientos = objLFactura.ObtenerFacturasSinImputarPorProveedor(Proveedor);

                if (dtMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Movimientos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvDatos.DataSource = dtMovimientos;
                //dgvDatos.Rows.Clear();
                double total = 0;
                foreach (DataRow dr in dtMovimientos.Rows)
                {
                    total += Convert.ToDouble(dr["Saldo"]);
                   // dgvDatos.Rows.Add(Convert.ToInt32(dr["Codigo"]), dr["CodigoTipoDoc"], dr["Fecha"], dr["FechaContable"], dr["TipoDocumento"], dr["Numero"], dr["Total"], dr["Imputado"], dr["Saldo"]);

                }
                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                        case "OT":
                        case "FL":
                        case "CO":
                            InformeFacturas(Convert.ToInt32(row.Cells["Codigo"].Value));
                            //InformeFacturas(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            //MessageBox.Show("FA, NC, ND");
                            break;
                        case "LQ":
                            //MessageBox.Show("Liquidaciones");
                            InformeLiquidacion(Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                        case "RC":
                        case "CR":
                            InformePagos(Logica.Informes.PagosProveedores(Convert.ToInt32(row.Cells["Codigo"].Value)));
                            //InformePagos(Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                    }
                 
                    //Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }
        }

        private void InformeFacturas(int pCodigoSucursal, int codigoFactura)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
                Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();
               /* if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = pCodigoSucursal;
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura, objESucursal);
                }
                else
                {
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura);
                }
                // objEFactura = objLFactura.ObtenerFactura(codigoFactura);
                string codigo;
                DataTable dtEncabezado = new DataTable();
                dtEncabezado.TableName = "dsEncabezado";
                dtEncabezado.Columns.Add("TipoResponsabilidad");
                dtEncabezado.Columns.Add("Codigo");
                dtEncabezado.Columns.Add("CondicionVenta");
                dtEncabezado.Columns.Add("TipoVenta");
                dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta);

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

                //dtEmpresa = new Logica.Empresa().ObtenerDataTable();
                codigo = dtEmpresa.Rows[0]["CUIT"].ToString().Replace("-", "");
                codigo = codigo + objEFactura.CodigoTipoDocumento.Replace("Cod. ", "");


                DataTable dtFactura = new DataTable();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo, objESucursal);
                }
                else
                {
                    dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo);
                }


                //dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo);

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
                //dtFacturaDetalle = new Logica.FacturaDetalle().ObtenerUno(objEFactura.Codigo);

                int filas = 15 - dtFacturaDetalle.Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    dtFacturaDetalle.Rows.Add(i);
                }

                lista.Add(dtEmpresa);
                lista.Add(dtEncabezado);
                lista.Add(dtFactura);
                lista.Add(dtFacturaDetalle);

                frmInformes informe = new frmInformes("FACTURAS", lista, "repFacturas");
                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                parametros[1] = new ReportParameter("Factura", "");


                informe.reportViewer1.LocalReport.SetParameters(parametros);


                informe.reportViewer1.RefreshReport();
                Utilidades.Formularios.AbrirFuera(informe);
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InformeLiquidacion(int pCodigo)
        {
            List<DataTable> lista = new List<DataTable>();
            lista.Add(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo));

            DataTable dtLiquidacionDetalle = new DataTable();
            dtLiquidacionDetalle = objLFactura.ObtenerDetalleLiquidacion(pCodigo);

            //MessageBox.Show(objLFactura.ObtenerEncabezadoLiquidacion(pCodigo).Rows[0]["Redondeo"].ToString());

            int filas = 12 - dtLiquidacionDetalle.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionDetalle.Rows.Add(0);
            }
            lista.Add(dtLiquidacionDetalle);

            DataTable dtLiquidacionMerma = new DataTable();
            dtLiquidacionMerma = objLFactura.ObtenerMermasLiquidacion(pCodigo);

            filas = 3 - dtLiquidacionMerma.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                dtLiquidacionMerma.Rows.Add(0);
            }
            lista.Add(dtLiquidacionMerma);

            DataTable dtImpuestos = objLFactura.OtenerImpuestos(pCodigo);
            lista.Add(dtImpuestos);
            // lista.Add(new Logica.Empresa().ObtenerDataTable());
            //   lista.Add(new Logica.RemitoCliente().ObtenerDataTable(CodigoRemito));
            //   lista.Add(new Logica.RemitoCliente().ObtenerDataTableDetalle(CodigoRemito));
            // Utilidades.Formularios.AbrirFuera(new frmInformes("LIQUIDACION DE PROVEEDORES", lista, "repLiquidacionProveedor"));


            frmInformes informe = new frmInformes("LIQUIDACION DE PROVEEDORES", lista, "repLiquidacionProveedor");


            informe.reportViewer1.RefreshReport();

            try
            {


                    Utilidades.Formularios.AbrirFuera(informe);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InformeFacturas(int codigoFactura)
        {
            try
            {
                
                List<DataTable> lista = new List<DataTable>();

                Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();
                Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
                objEFactura=objLFactura.ObtenerFactura(codigoFactura);

                DataTable dtEncabezado = new DataTable();
                dtEncabezado.TableName = "dsEncabezado";
                dtEncabezado.Columns.Add("FechaEmision");
                dtEncabezado.Columns.Add("Codigo");
                dtEncabezado.Columns.Add("CondicionVenta");
                dtEncabezado.Columns.Add("TipoCompra");
                dtEncabezado.Columns.Add("Letra");
                dtEncabezado.Columns.Add("Numero");
                dtEncabezado.Columns.Add("DescripImp1");
                dtEncabezado.Columns.Add("DescripImp2");
                dtEncabezado.Columns.Add("Neto1", objEFactura.Neto1.GetType());
                dtEncabezado.Columns.Add("Neto2", objEFactura.Neto2.GetType());
                dtEncabezado.Columns.Add("DescripIva1");
                dtEncabezado.Columns.Add("DescripIva2");
                dtEncabezado.Columns.Add("ImporteImp1", objEFactura.ImporteImp1.GetType());
                dtEncabezado.Columns.Add("ImporteImp2", objEFactura.ImporteImp2.GetType());
                dtEncabezado.Columns.Add("Exento", objEFactura.Exento.GetType());
                dtEncabezado.Columns.Add("NoGravado", objEFactura.NoGravado.GetType());
                dtEncabezado.Rows.Add(objEFactura.FechaEmision, objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta, 
                    objEFactura.Letra, objEFactura.Letra+"-"+objEFactura.PuntoDeVenta.ToString("0000")+"-"+ objEFactura.Numero.ToString("00000000"), "Importe Neto " + Convert.ToString(objEFactura.DescripImp1.ToString("0.00")) + "%:", 
                    "Importe Neto " + Convert.ToString(objEFactura.DescripImp2.ToString("0.00")) + "%:", objEFactura.Neto1, objEFactura.Neto2, 
                    "Importe IVA " + Convert.ToString(objEFactura.DescripImp1.ToString("0.00")) + "%:",
                    "Importe IVA " + Convert.ToString(objEFactura.DescripImp2.ToString("0.00")) + "%:", objEFactura.ImporteImp1, objEFactura.ImporteImp2, 
                    objEFactura.Exento, objEFactura.NoGravado);//,objEFactura.TipoDocumentoProveedor.
                //"Importe Neto " + Convert.ToString(objEFactura.DescripImp1.ToString("0.00")) + "%:", "Importe Neto " + Convert.ToString(objEFactura.DescripImp2.ToString("0.00")) + "%:", objEFactura.Neto1, objEFactura.Neto2, objEFactura.ImporteImp1, objEFactura.ImporteImp2, objEFactura.Exento, objEFactura.NoGravado);//,objEFactura.TipoDocumentoProveedor.
                lista.Add(dtEncabezado);

                DataTable dtEmpresa = new DataTable();
                dtEmpresa = new Logica.Proveedor().ObtenerDataTable(objEFactura.Proveedor);
                lista.Add(dtEmpresa);

                DataTable dtCliente = new DataTable();
                dtCliente = new Logica.Empresa().ObtenerDataTable();
                lista.Add(dtCliente);

                DataTable dtDetalle = new DataTable();
                if (objEFactura.TipoCompra.Equals("BC"))
                {
                    dtDetalle = objLFactura.ObtenerDetalleFacturasBC(objEFactura.Codigo);
                    int filas = 15 - dtDetalle.Rows.Count;
                    for (int i = 0; i < filas; i++)
                    {
                        dtDetalle.Rows.Add(i);
                    }
                }
                else {
                    dtDetalle = objLFactura.ObtenerDetalleFacturasGYBC(objEFactura.Codigo);
                }
                /*int filas = 15 - dtDetalle.Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    dtDetalle.Rows.Add(i);
                }*/
                lista.Add(dtDetalle);

                DataTable dtImpuestos = new DataTable();
                dtImpuestos = objLFactura.ObtenerImpuestos(objEFactura.Codigo);
                lista.Add(dtImpuestos);

                string inf = "";
                if (objEFactura.TipoCompra.Equals("BC"))
                {
                    inf = "repFacturasComprasBC";
                }
                else {
                    inf = "repFacturasComprasGYBU";
                }

                frmInformes informe = new frmInformes("FACTURAS", lista, inf);
                /*ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                parametros[1] = new ReportParameter("Factura", "");


                informe.reportViewer1.LocalReport.SetParameters(parametros);
                */

                informe.reportViewer1.RefreshReport();
                Utilidades.Formularios.AbrirFuera(informe);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformePagos(List<DataTable> lista)
        {
            /*List<DataTable> lista = new List<DataTable>();
            Logica.Pago objLPago=new Logica.Pago();
            lista.Add(new Logica.Empresa().ObtenerDataTable());
            lista.Add(objLPago.ObtenerDataTable(codigo));
            lista.Add(objLPago.ObtenerEfectivoUno(codigo));
            lista.Add(objLPago.ObtenerChequesUno(codigo));
            lista.Add(objLPago.ObtenerChequesRechazadosUno(codigo));
            lista.Add(objLPago.ObtenerImputacionesUno(codigo));
            lista.Add(objLPago.ObtenerTranferenciasUno(codigo));
            lista.Add(objLPago.ObtenerImpuestosUno(codigo));*/
            Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
           /* foreach (DataTable item in lista)
            {
                if (item.TableName.Equals("DataSet1")) {
                    if (item.Rows.Count > 0) {
                        Utilidades.Formularios.AbrirFuera(new frmInformes("RETENCIONES DE PAGO", lista, "repRetencionesPagos"));
                    }
                }
            }*/

            //DataTable dt = objLPago.ObtenerRetenciones(codigo);
            /*if (dt.Rows.Count > 0) {
                lista.Add(dt);
                Utilidades.Formularios.AbrirFuera(new frmInformes("RETENCIONES DE PAGO", lista, "repRetencionesPagos"));
            }*/
                
            
            
        }

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            List<DataTable> lista = new List<DataTable>();
            try
            {
                dtMovimientos.TableName = "dsMovimientos";
                lista.Add(dtMovimientos);
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                frmInformes informe;
                string titulo;
                if (!cbSaldo.Checked)
                {
                    informe = new frmInformes("INFORME DE MOVIMIENTOS DE CUENTAS CORRIENTES DE PROVEEDORES", lista, "repMovimientosCuentasCorrientes");
                    titulo = "INFORME DE MOVIMIENTOS DE CUENTA CORRIENTE PROVEEDOR \n" + Proveedor.Nombre;
                }
                else {
                    informe = new frmInformes("INFORME DE MOVIMIENTOS DE CUENTAS CORRIENTES DE PROVEEDORES", lista, "repMovimientosCuentasCorrientesImputados");
                    titulo = "INFORME DE MOVIMIENTOS DE CUENTA CORRIENTE PROVEEDOR \n" + Proveedor.Nombre;
                }

                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Titulo", titulo);
                parametros[1] = new ReportParameter("Saldo", lblTotal.Text);
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
