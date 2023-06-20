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
    public partial class frmCuentasCorrientesClientes : Presentacion.frmColor
    {
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.Factura objLFactura =new Logica.Factura();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();


        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        public frmCuentasCorrientesClientes()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formato();
        /*   
        
            
                 


            dgvDatos.Columns["Debito"].Width = 80;
            dgvDatos.Columns["Credito"].Width = 80;
            dgvDatos.Columns["Total"].Width = 80;

        */
        }

        private void Titulo()
        {
            this.Text = "COMPROBANTES DE CUENTAS CORRIENTES";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 5);
        }

        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbSucursales);
            Utilidades.Combo.Formato(cbTiposComprobantes);

            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {

                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Fecha"].Width = 70;

            dgvDatos.Columns["Comprobante"].Width = 170;
            dgvDatos.Columns["Numero"].Width = 110;
            dgvDatos.Columns["Cliente"].Width = 200;

        }
        private void CargarValores() {
            try
            {
                CargarTiposComprobantes();
                CargarSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double SumarTotal()
        {
            double suma=0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                suma+=Convert.ToDouble(item.Cells["Total"].Value);
            }
            return suma;
        }

        private double SumarTotalSinSaldoAnterior()
        {
            double suma = 0;
            
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if(!item.Cells["Comprobante"].Value.Equals("Saldo Anterior"))
                    suma += Convert.ToDouble(item.Cells["Total"].Value);
            }
            return suma;
        }
        private void CargarTiposComprobantes() {
            List<Valor> valores = new List<Valor>();
            valores.Add(new Valor() { Clave = 'C', Mostrar = "Comprobantes de Venta" });
            valores.Add(new Valor() { Clave = 'P', Mostrar = "Pagos" });
            valores.Add(new Valor() { Clave = 'T', Mostrar = "Todos" });

            cbTiposComprobantes.DataSource = valores;
            cbTiposComprobantes.DisplayMember = "Mostrar";
            cbTiposComprobantes.ValueMember = "Clave";

            cbTiposComprobantes.SelectedValue = 'T';
        }

        private void CargarSucursales()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                cbSucursales.SelectedValue = 1;
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
            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
        }

        private void cbTiposComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            lblTotal.Text = 0.ToString("C2");
            lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
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
                lblTotal.Text = 0.ToString("C2");
                lblTotalSinSaldoAnterior.Text = 0.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    if (!cbClientes.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("CuentasCorrientesClientes", this));
                    break;
            }

        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
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
                    //lblTotal.Text = Suma().ToString("C2");
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (!Validar())
                {
             

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                        dt = objLFactura.ObtenerComprobantesCtasCorrientesClientes((char)cbTiposComprobantes.SelectedValue,objEntidadCliente, desde, hasta, objESucursal);
                        dgvDatos.DataSource = dt;
                }
                else
                {
                        dt = objLFactura.ObtenerComprobantesCtasCorrientesClientes((char)cbTiposComprobantes.SelectedValue, objEntidadCliente, desde, hasta);
                        dgvDatos.DataSource = dt;
                }
                
                    lblTotal.Text = SumarTotal().ToString("C2");
                   lblTotalSinSaldoAnterior.Text= SumarTotalSinSaldoAnterior().ToString("C2");

                    if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Comprobantes en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

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
                            InformeFacturas(Convert.ToInt32(cbSucursales.SelectedValue), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                        case "RC":
                        case "CR":
                            InformePagos(Convert.ToInt32(cbSucursales.SelectedValue), Convert.ToInt32(row.Cells["Codigo"].Value));
                            break;
                    }
                }
            }
        }

        private bool Validar()
        {

            if (!cbClientes.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            return false;
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
    }

    public class Valor {
        public char Clave { get; set; }
        public String Mostrar { get; set; }
    }
}
