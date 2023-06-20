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
    public partial class frmClienteMovimientosCuentaCorriente : Presentacion.frmColor
    {
        private Entidades.Cliente cliente;
        private Entidades.Sucursal sucursal;

        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        //DataView dvMovimientos = new DataView();

        Logica.Factura objLFactura = new Logica.Factura();

        DataTable dtMovimientos;
        public frmClienteMovimientosCuentaCorriente(Entidades.Cliente pCliente, Entidades.Sucursal pSucursal = null)
        {
            InitializeComponent();
            Cliente = pCliente;
            Sucursal = pSucursal;
            ConfiguracionInicial();
            CargarValores();
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public Sucursal Sucursal
        {
            get
            {
                return sucursal;
            }

            set
            {
                sucursal = value;
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AllowUserToOrderColumns = false;
            dtDesde.Value = dtDesde.Value.AddDays(-10);
            dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["TipoDocumento"].Width = 140;
            dgvDatos.Columns["Numero"].Width = 95;
            dgvDatos.Columns["Debito"].Width = 120;
            dgvDatos.Columns["Credito"].Width = 120;
            dgvDatos.Columns["Suma"].Width = 120;

            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
        }

        private void Titulo()
        {
            this.Text = "MOVIMIENTOS CUENTA CORRIENTE CLIENTE " + Cliente.Nombre;
        }

        private void CargarValores()
        {
            try
            {

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtMovimientos = objLFactura.ObtenerFacturasCuentaCorriente(Cliente, dtDesde.Value, Sucursal);
                }
                else
                    dtMovimientos = objLFactura.ObtenerFacturasCuentaCorriente(Cliente, dtDesde.Value);

                if (dtMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Movimientos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtMovimientos.Columns.Add("Total2", Type.GetType("System.Double"));



                dgvDatos.Rows.Clear();
                double total = 0;
                foreach (DataRow dr in dtMovimientos.Rows)
                {
                    total += Convert.ToDouble(dr["Total"]);
                    dr["Total2"] = total;

                    dgvDatos.Rows.Add(Convert.ToInt32(dr["CodigoSucursal"]), Convert.ToInt32(dr["Codigo"]), dr["CodigoTipoDoc"], dr["Fecha"], dr["TipoDocumento"], dr["Numero"],dr["Debito"], dr["Credito"], total);

                }
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


        private void cbSaldo_CheckedChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            if (cbSaldo.Checked)
            {
                dgvDatos.Columns["Debito"].HeaderText = "Total";
                dgvDatos.Columns["Credito"].HeaderText = "Imputado";
                dgvDatos.Columns["Suma"].HeaderText = "Saldo";
                CargarValoresSinImputar();
                dtDesde.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                dgvDatos.Columns["Debito"].HeaderText = "Débito";
                dgvDatos.Columns["Credito"].HeaderText = "Crédito";
                dgvDatos.Columns["Suma"].HeaderText = "Suma";
                CargarValores();
                dtDesde.Enabled = true;
                btnBuscar.Enabled = true;
            }
        }

        private void CargarValoresSinImputar()
        {
            try
            {

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    dtMovimientos = objLFactura.ObtenerFacturasSinImputarPorCliente(Cliente, Sucursal);
                }
                else
                {
                    dtMovimientos = objLFactura.ObtenerFacturasSinImputarPorCliente(Cliente);
                }
                dgvDatos.Rows.Clear();
                double total = 0;
                foreach (DataRow dr in dtMovimientos.Rows)
                {
                    total += Convert.ToDouble(dr["Saldo"]);
                    dgvDatos.Rows.Add(Convert.ToInt32(dr["CodigoSucursal"]), Convert.ToInt32(dr["Codigo"]), dr["CodigoTipoDoc"], dr["Fecha"], dr["TipoDocumento"], dr["Numero"], dr["Total"], dr["Imputado"], dr["Saldo"]);

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
                            InformeFacturas(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                        case "LQ":
                            InformeLiquidaciones(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            //MessageBox.Show("Liquidaciones");
                            break;
                        case "RC":
                        case "CR":
                            InformePagos(Convert.ToInt32(row.Cells["CodigoSucursal"].Value), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                    }
                    /* if (row.Cells["Tipo"].Value.Equals("FA") || row.Cells["Tipo"].Value.Equals("NC") || row.Cells["Tipo"].Value.Equals("ND"))
                     {
                         InformeFacturas(Convert.ToInt32(row.Cells["Codigo"].Value));
                     }
                     else if((row.Cells["Tipo"].Value.Equals("LQ")))
                     {
                         MessageBox.Show("Liquidaciones");
                     }
                     else if ((row.Cells["Tipo"].Value.Equals("RC")))
                     {
                         MessageBox.Show("Liquidaciones");
                     }*/
                    //Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
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
                // objEFactura = objLFactura.ObtenerFactura(codigoFactura);
                string codigo;
                DataTable dtEncabezado = new DataTable();
                dtEncabezado.TableName = "dsEncabezado";
                dtEncabezado.Columns.Add("TipoResponsabilidad");
                dtEncabezado.Columns.Add("Codigo");
                dtEncabezado.Columns.Add("CondicionVenta");
                dtEncabezado.Columns.Add("TipoVenta");
                dtEncabezado.Columns.Add("TotalEnLetras");
                //dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta);

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
                /*
                int filas = 15 - dtFacturaDetalle.Rows.Count;
                for (int i = 0; i < filas; i++)
                {
                    dtFacturaDetalle.Rows.Add(i);
                }*/
                double tot = Convert.ToDouble(dtFactura.Rows[0]["Neto105"]) + Convert.ToDouble(dtFactura.Rows[0]["Neto21"]) + Convert.ToDouble(dtFactura.Rows[0]["Iva105"]) + Convert.ToDouble(dtFactura.Rows[0]["Iva21"]) + Convert.ToDouble(dtFactura.Rows[0]["NetoNoGravado"]) + Convert.ToDouble(dtFactura.Rows[0]["PercepcionMuni"]);
                dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoDocumentoCliente.Descripcion, Utilidades.Convertir.PrimeraLetra(Utilidades.NumeroEnLetras.Convertir(tot.ToString(), false)));
                lista.Add(dtEmpresa);
                lista.Add(dtEncabezado);
                lista.Add(dtFactura);
                lista.Add(dtFacturaDetalle);

                frmInformes informe = new frmInformes("FACTURAS", lista, "repFacturas", true, true);

                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
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

        private void InformePagos(int pCodigoSucursal, int codigo)
        {
            try
            {
                /*
                 if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = pCodigoSucursal;
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura, objESucursal);
                }
                else
                {
                    objEFactura = objLFactura.ObtenerFactura(codigoFactura);
                }
                 */
                List<DataTable> lista = new List<DataTable>();
                DataTable dtEmpresa = new DataTable();
                DataTable dtDetalles = new DataTable();
                DataTable dtEfectivo = new DataTable();
                DataTable dtCheques = new DataTable();
                DataTable dtImputaciones = new DataTable();
                DataTable dtImpuestos = new DataTable();
                DataTable dtTranferencias = new DataTable();
                DataTable dtCreditoDebito = new DataTable();
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = pCodigoSucursal;
                    dtEmpresa = new Logica.Empresa().ObtenerDataTable(objESucursal);
                    dtDetalles = new Logica.PagoCliente().ObtenerDataTable(codigo, objESucursal);
                    dtEfectivo = new Logica.PagoCliente().ObtenerEfectivoUno(codigo, objESucursal);
                    dtCheques = new Logica.PagoCliente().ObtenerChequesUno(codigo, objESucursal);
                    dtImpuestos = new Logica.PagoCliente().ObtenerImpuestosUno(codigo, objESucursal);
                    dtImputaciones = new Logica.PagoCliente().ObtenerImputacionesUno(codigo, objESucursal);
                    dtTranferencias = new Logica.PagoCliente().ObtenerTranferenciasUno(codigo, objESucursal);
                    dtCreditoDebito = new Logica.PagoCliente().ObtenerDebitoCreditoUno(codigo, objESucursal);
                }
                else
                {
                    dtEmpresa = new Logica.Empresa().ObtenerDataTable();
                    dtDetalles = new Logica.PagoCliente().ObtenerDataTable(codigo);
                    dtEfectivo = new Logica.PagoCliente().ObtenerEfectivoUno(codigo);
                    dtCheques = new Logica.PagoCliente().ObtenerChequesUno(codigo);
                    dtImpuestos = new Logica.PagoCliente().ObtenerImpuestosUno(codigo);
                    dtImputaciones = new Logica.PagoCliente().ObtenerImputacionesUno(codigo);
                    dtTranferencias = new Logica.PagoCliente().ObtenerTranferenciasUno(codigo);
                    dtCreditoDebito = new Logica.PagoCliente().ObtenerDebitoCreditoUno(codigo);
                }
                lista.Add(dtEmpresa);
                lista.Add(dtDetalles);
                lista.Add(dtEfectivo);
                lista.Add(dtCheques);
                lista.Add(dtTranferencias);
                lista.Add(dtImpuestos);
                lista.Add(dtImputaciones);
                lista.Add(dtCreditoDebito);
                Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repClientesPagos"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
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
                    informe = new frmInformes("INFORME DE MOVIMIENTOS DE CUENTAS CORRIENTES DE CLIENTES", lista, "repMovimientosCuentasCorrientesClientes");
                    titulo = "INFORME DE MOVIMIENTOS DE CUENTA CORRIENTE CLIENTE \n" + Cliente.Nombre;
                }
                else
                {
                    informe = new frmInformes("INFORME DE MOVIMIENTOS DE CUENTAS CORRIENTES CLIENTES", lista, "repMovimientosCuentasCorrientesClientesImputados");
                    titulo = "INFORME DE MOVIMIENTOS DE CUENTA CORRIENTE CLIENTE \n" + Cliente.Nombre;
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

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }
    }
}
