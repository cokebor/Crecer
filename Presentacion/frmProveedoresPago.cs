using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Entidades;

namespace Presentacion
{
    public partial class frmProveedoresPago : Presentacion.frmColor
    {
        Entidades.Proveedor objEProveedor;
        Entidades.TipoDocumentoProveedor objETipoDocProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.Pago objEPago = new Entidades.Pago();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago;

        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocProveedor = new Logica.TipoDocumentoProveedor();
        Logica.FacturaCompra objFC = new Logica.FacturaCompra();
        Logica.Pago objLPagoProveedor = new Logica.Pago();
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();

        List<TipoDocumentoProveedor> tiposG;
        List<TipoDocumentoProveedor> tiposI;

        public double Valores { get; set; }
        public double Efectivo { get; set; }
        public double Dolares { get; set; }
        public double Total { get; set; }
        public double RetencionesGanancias { get; set; }
        public double RetencionesIva { get; set; }
        public frmProveedoresPago()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }
        private void ConfiguracionInicial()
        {
            objEProveedor = new Entidades.Proveedor();
            ucFormasPagoCompras.Proveedor = objEProveedor;
            ucFormasPagoCompras.FormularioInicial = this;
            Titulo();
            Formatos();
            LimitesTamaño();
            CargarValores();


            this.ucFormasPagoCompras.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            this.dtFecha.ValueChanged += ActualizarValores;
        }

        private void CargarValores()
        {
            try
            {
                tiposG = objLTipoDocProveedor.ObtenerTodosConImpuestos('G');
                tiposI = objLTipoDocProveedor.ObtenerTodosConImpuestos('I');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Titulo()
        {
            this.Text = "PAGO A PROVEEDORES";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbRecibos);
            Utilidades.TabControl.Formato(tcPagosProveedores, frmColor.Color);
            tcPagosProveedores.TabPages.Remove(tpFormasDePago);
            tcPagosProveedores.TabPages.Remove(tpImputacion);
            lblTotal.Text = Convert.ToDouble(0).ToString("C2");
            lblValores.Text = Convert.ToDouble(0).ToString("C2");
            lblRetenciones.Text = Convert.ToDouble(0).ToString("C2");
            lblDisponible.Text = Convert.ToDouble("0").ToString("C2");
            lblAplicado.Text = Convert.ToDouble("0").ToString("C2");
            lblRetencionesIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblRetencionMunicipal.Text = Convert.ToDouble("0").ToString("C2");

            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDatos.Columns["Seleccionado"].ReadOnly = false;

            dgvDatos.Columns["Seleccionado"].Width = 25;
            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["Tipo"].Width = 30;
            dgvDatos.Columns["Numero"].Width = 90;
            dgvDatos.Columns["Total2"].Width = 81;
            dgvDatos.Columns["Imputado"].Width = 81;
            dgvDatos.Columns["Pendiente"].Width = 81;
            dgvDatos.Columns["AAplicar"].Width = 80;
            dgvDatos.Columns["AAplicar"].ReadOnly = false;

        }
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 150);
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            tcPagosProveedores.TabPages.Remove(tpFormasDePago);
            tcPagosProveedores.TabPages.Remove(tpImputacion);
            Total = 0;
            RetencionesGanancias = 0;
            RetencionesIva = 0;
            rete = RetencionesMunicipales(Total);
            lblRetencionMunicipal.Text = (rete).ToString("C2");
            // retIva = 0;
            dgvDatos.Rows.Clear();
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEProveedor = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));

                    if (objEProveedor != null)
                    {
                        lblNombreProveedor.Text = objEProveedor.Nombre;
                        ucFormasPagoCompras.Proveedor = objEProveedor;
                        if (objEProveedor.RiesgoFiscal) {
                            objEProveedor.TipoContribuyente.PorcentajeRetencion = 2 * objEProveedor.TipoContribuyente.PorcentajeRetencion;
                        }
                        CargarValoresImputacion(cbLiquidaciones.Checked);
                        if (objEProveedor.CategoriaProveedor.Codigo != 1)
                        {
                            objEProveedor.CategoriaProveedor = new /*objLCategoriaProveedor*/Logica.CategoriaProveedor().ObtenerUno(objEProveedor.CategoriaProveedor.Codigo);
                        }
                    }
                    else
                    {
                        objEProveedor = new Entidades.Proveedor();
                        lblNombreProveedor.Text = "";
                        cbTodosLosRecibos.Visible = false;
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                        ucFormasPagoCompras.Proveedor = objEProveedor;
                        dgvDatos.DataSource = null;
                    }
                }
                else
                {
                    objEProveedor = new Proveedor();
                    lblNombreProveedor.Text = "";
                    cbTodosLosRecibos.Visible = false;
                    lblRecibo.Visible = false;
                    cbRecibos.Visible = false;
                    ucFormasPagoCompras.Proveedor = objEProveedor;
                    dgvDatos.DataSource = null;

                }
                Efectivo = 0;
                Dolares = 0;
                
                ObtenerTipoComprobante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ObtenerTipoComprobante()
        {
            if (objEProveedor != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocProveedor.ObtenerTodosDeTipoPagos(objEProveedor.TipoInscripcion.Codigo), "Codigo", "Descripcion");
            }
            else
            {
                cbRecibos.DataSource = null;
                cbTipoComprobante.DataSource = null;
            }
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("PagoProveedores", this));
                    break;
            }
        }

        private void CargarValoresImputacion(bool liquidaciones)
        {
            DataTable dt = objFC.ObtenerFacturasSinImputar(objEProveedor, liquidaciones);
            dgvDatos.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dgvDatos.Rows.Add(false, Convert.ToDateTime(dr["FechaEmision"]).ToString("d").Replace("-", "/"), dr["Tipo"], dr["Codigo"], dr["CodigoTipoDocumentoProveedor"], dr["Numero"], Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Imputado"]), Convert.ToDouble(dr["Saldo"]), "", "", Convert.ToDouble(dr["IVA"]), Convert.ToDouble(dr["Neto"]));
            }
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbChequeRechazado.Checked = false;
                cbTodosLosRecibos.Checked = false;
                cbRecibos.DataSource = null;
                CargarValoresImputacion(cbLiquidaciones.Checked);
                RetencionesGanancias = 0;
                RetencionesIva = 0;
                ucFormasPagoCompras.Limpiar();
                Aplicado();
                if (cbTipoComprobante.SelectedIndex != -1)
                {

                    tcPagosProveedores.TabPages.Remove(tpFormasDePago);
                    tcPagosProveedores.TabPages.Remove(tpImputacion);
                    objETipoDocProveedor = objLTipoDocProveedor.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                    ucFormasPagoCompras.TipoDoc = objETipoDocProveedor.TipoDoc.Codigo;
                    ucFormasPagoCompras.CargarValores();
                    if (objETipoDocProveedor.TipoDoc.Codigo.Equals("RC"))
                    {
                        lblRecibo.Visible = false;
                        cbRecibos.Visible = false;
                        tcPagosProveedores.TabPages.Add(tpFormasDePago);
                        tcPagosProveedores.TabPages.Add(tpImputacion);
                        cbTodosLosRecibos.Visible = false;
                        cbChequeRechazado.Visible = false;
                        ucFormasPagoCompras.CodigoRecibo = 0;
                    }
                    else
                    {
                        lblRecibo.Visible = true;
                        cbRecibos.Visible = true;
                        tcPagosProveedores.TabPages.Add(tpFormasDePago);
                        tcPagosProveedores.TabPages.Remove(tpImputacion);
                        cbTodosLosRecibos.Visible = true;
                        cbChequeRechazado.Visible = true;
                        if (cbTodosLosRecibos.Checked)
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                        }
                        else
                        {
                            Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                        }
                        ucFormasPagoCompras.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                        ucFormasPagoCompras.Efectivo = Efectivo;
                        ucFormasPagoCompras.Dolares = Dolares;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRecibos.SelectedValue != null && Convert.ToInt32(cbRecibos.SelectedValue) != 1)
                {
                    ucFormasPagoCompras.CodigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                    Efectivo = Math.Abs(Convert.ToDouble(objLPagoProveedor.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Efectivo"]));
                    Dolares = Math.Abs(Convert.ToDouble(objLPagoProveedor.ObtenerUno(Convert.ToInt32(cbRecibos.SelectedValue)).Rows[0]["Dolares"]));
                }
                else
                {
                    Efectivo = 0;
                    Dolares = 0;
                }
                ucFormasPagoCompras.Efectivo = Efectivo;
                ucFormasPagoCompras.Dolares = Dolares;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbLiquidaciones_CheckedChanged(object sender, EventArgs e)
        {
            CargarValoresImputacion(cbLiquidaciones.Checked);
            Aplicado();
        }

        private void cbTodosLosRecibos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTodosLosRecibos.Checked)
                {
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, Convert.ToDateTime("01/01/1900")), "Codigo", "Numero");
                }
                else
                {
                    Utilidades.Combo.Llenar(cbRecibos, objLPagoProveedor.ObtenerPagosPorProveedor(objEProveedor.Codigo, dtFecha.Value.AddDays(-10)), "Codigo", "Numero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private double RetencionesMunicipales(double pTotal)
        {
            double ret = 0;
            if (Singleton.Instancia.Empresa.PercepcionMunicipal && objEProveedor != null && objEProveedor.TipoContribuyente.PorcentajeRetencion != 0 && objEProveedor.TipoContribuyente.MinimoRetencion<=pTotal)
            {
                ret = Utilidades.Redondear.DosDecimales((pTotal) * objEProveedor.TipoContribuyente.PorcentajeRetencion / 100);
            }
            return ret;
        }
        Double rete = 0;
        private void ActualizarValores(object sender, EventArgs e)
        {
            try
            {
                //CalculoRetencionGanancias();
                //CalculoRetencionIva();
                
                if (objETipoDocProveedor.TipoDoc.Codigo != null && objETipoDocProveedor.TipoDoc.Codigo.Equals("RC"))
                {

                    Valores = ucFormasPagoCompras.valores;
                    lblValores.Text = Valores.ToString("C2");
                    lblRetenciones.Text = RetencionesGanancias.ToString("C2");
                    lblRetencionesIVA.Text = RetencionesIva.ToString("C2");
                    Total = Valores + RetencionesGanancias + RetencionesIva;
                    rete= RetencionesMunicipales(Total);
                    Total += rete;
                    lblRetencionMunicipal.Text = (rete).ToString("C2");
                    lblTotal.Text = (Total).ToString("C2");
                    lblDisponible.Text = Disponible.ToString("C2");
                    //double retGanancias= CalculoRetencionGanancias();
                    //lblRetenciones.Text = retGanancias.ToString("C2");
                    /*
                      Total = monto;
                      
                      
                      
                      
                      
                      
                      double retIva = RetencionIVA();
                      lblSaldo.Text = Saldo(monto, retGanancias, retIva).ToString("C2");*/
                }
                else
                {

                    Valores = ucFormasPagoCompras.valores;
                    lblRetenciones.Text = RetencionesGanancias.ToString("C2");
                    lblRetencionesIVA.Text = RetencionesIva.ToString("C2");
                    Total = Valores + RetencionesGanancias + RetencionesIva;
                    lblTotal.Text = Total.ToString("C2");

                    lblValores.Text = Valores.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalculoRetencionGanancias()
        {
            double retComprobantes = 0;
            try
            {
                retComprobantes = RetencionesGananciasComprobantes();
                RetencionesGanancias = retComprobantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalculoRetencionIva()
        {
            double retComprobantes = 0;
            try
            {
                retComprobantes = RetencionesIvaComprobantes();
                RetencionesIva = retComprobantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private double RetencionesGananciasComprobantes()
        {

            double res = 0;
            int indice = 0;
            Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new TipoDocumentoProveedor();
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                {
                    objETipoDocumentoProveedor.Codigo = Convert.ToInt32(dgv.Cells["CodigoTipoDocumentoProveedor"].Value);
                    indice = tiposG.IndexOf(objETipoDocumentoProveedor);
                    if (indice != -1)
                    {
                        objETipoDocumentoProveedor = tiposG.ElementAt((indice));
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDocumentoProveedor.Impuestos)
                        {
                            switch (item.Del)
                            {
                                case 'N':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                        }
                    }

                }
            }

            return res;

        }

        private double RetencionesIvaComprobantes()
        {

            double res = 0;
            int indice = 0;
            Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new TipoDocumentoProveedor();
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                {
                    objETipoDocumentoProveedor.Codigo = Convert.ToInt32(dgv.Cells["CodigoTipoDocumentoProveedor"].Value);
                    indice = tiposI.IndexOf(objETipoDocumentoProveedor);
                    if (indice != -1)
                    {
                        objETipoDocumentoProveedor = tiposI.ElementAt((indice));
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDocumentoProveedor.Impuestos)
                        {
                            switch (item.Del)
                            {
                                case 'N':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                        }
                    }

                }
            }

            return res;

        }

        public double Disponible
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(Total + RetencionesGanancias + RetencionesIva - Aplicado(false));
            }
        }
        public double Aplicado(bool actualizarDatos=true)
        {
            CalculoRetencionGanancias();
            CalculoRetencionIva();
            double res = 0;
            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                    if (!(dgv.Cells["AAplicar"].Value == null) && !dgv.Cells["AAplicar"].Value.Equals(""))
                        res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["AAplicar"].Value));
            }
            if (actualizarDatos) {
            Valores = ucFormasPagoCompras.valores;
                lblValores.Text = Valores.ToString("C2");
                lblRetenciones.Text = RetencionesGanancias.ToString("C2");
                lblRetencionesIVA.Text = RetencionesIva.ToString("C2");
                lblAplicado.Text = res.ToString("C2");
                Total = Valores + RetencionesIva + RetencionesGanancias;
                //rete = RetencionesMunicipales(Total);
                Total += rete;
                lblTotal.Text = (Total).ToString("C2");
                lblDisponible.Text = (Total - res).ToString("C2");
            }
            return res;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
                {

                    DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                    check.Value = !(Convert.ToBoolean(check.Value));

                    CalculoRetencionGanancias();
                    CalculoRetencionIva();

                    if (Convert.ToBoolean(check.Value))
                    {
                        if (Disponible >= Convert.ToDouble(dgvDatos["Pendiente", e.RowIndex].Value))
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = dgvDatos["Pendiente", e.RowIndex].Value;
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "T";


                        }
                        else if (Disponible == 0)
                        {



                            check.Value = !(Convert.ToBoolean(check.Value));
                            MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {
                            //check.Value = !(Convert.ToBoolean(check.Value));
                            //MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Convert.ToInt32(dgvDatos["CodigoTipoDocumentoProveedor",e.RowIndex].Value)!=19) {
                                dgvDatos["AAplicar", e.RowIndex].Value = Disponible;
                                dgvDatos["CodigoImputacion", e.RowIndex].Value = "P";
                            } else {
                                check.Value = !(Convert.ToBoolean(check.Value));
                                MessageBox.Show("No dispone de Saldo para imputar!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    }
                    else
                    {
                        dgvDatos["AAplicar", e.RowIndex].Value = "";
                        dgvDatos["CodigoImputacion", e.RowIndex].Value = "";

                    }
                   // CalculoRetencionGanancias();
                    //CalculoRetencionIva();
                    Aplicado();
                    //RetencionesGanancias();

                }
                // Cambio();
                //   double retGanancias = CalculoRetencionGanancias(Total);
                //  lblRetenciones.Text = retGanancias.ToString("C2");

                //  double retIva = RetencionIVA();
                //  lblSaldo.Text = Saldo(Total, retGanancias, retIva).ToString("C2");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cambio()
        {
            foreach (DataGridViewRow d in dgvDatos.Rows)
            {
                if (d.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    d.Cells["Seleccionado"].Value = false;
                }
            }
        }
        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += Validar_KeyPress;
            }
        }
        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            Aplicado();
            Cambio();
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Aplicado();
        }

        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDatos.IsCurrentCellDirty)
            {
                dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime Fecha;
            Fecha = dtFecha.Value.Date;

            if (ValidarComprobante().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProveedor.Focus();
                return;
            }

            if (Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CargarValoresPago();

                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC") && (objEPago.FacturasImputacion.Count == 0 || Disponible != 0))
                {
                    if (MessageBox.Show("Comprobante con Saldo sin Imputar.\n¿Desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                DateTime fechaMax = Convert.ToDateTime(Fecha.Year + "-" + Fecha.Month + "-" + DateTime.DaysInMonth(Fecha.Year, Fecha.Month));

                if (fechaMax < DateTime.Now.Date)
                {
                    if (MessageBox.Show("Esta cargando un Pago de un mes ya cerrado.\n ¿Esta Seguro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (objEPago.Tranferencias.Count > 0)
                    {
                        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                        foreach (Entidades.Tranferencia item in objEPago.Tranferencias)
                        {
                            objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                            if (ValidarFechaConciliacionCuenta(objECuentaBancaria).Equals(false))
                            {
                                MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }
                    if (objEPago.ChequesPropios.Count > 0)
                    {
                        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                        foreach (Entidades.Cheque item in objEPago.ChequesPropios)
                        {
                            objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                            if (ValidarFechaConciliacionCuentaCheques(objECuentaBancaria, item).Equals(false))
                            {
                                MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }



                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                }
                CargarAsiento();
                int codigoRecibo;
                if (cbRecibos.Visible)
                    codigoRecibo = Convert.ToInt32(cbRecibos.SelectedValue);
                else
                    codigoRecibo = 0;

                int codigo = objLPagoProveedor.Agregar(objEPago, objEAsiento, codigoRecibo);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
           //     Informe(codigo);
                InformePagos(Logica.Informes.PagosProveedores(codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void Informe(int codigo)
        {
            List<DataTable> lista = new List<DataTable>();
            lista.Add(new Logica.Empresa().ObtenerDataTable());
            lista.Add(new Logica.Pago().ObtenerDataTable(codigo));
            lista.Add(new Logica.Pago().ObtenerEfectivoUno(codigo));
            lista.Add(new Logica.Pago().ObtenerChequesUno(codigo));
            lista.Add(new Logica.Pago().ObtenerChequesRechazadosUno(codigo));
            lista.Add(new Logica.Pago().ObtenerImputacionesUno(codigo));
            lista.Add(new Logica.Pago().ObtenerTranferenciasUno(codigo));
            lista.Add(new Logica.Pago().ObtenerImpuestosUno(codigo));
            Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
        }*/

        private void InformePagos(List<DataTable> lista)
        {
            
            Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
           /* foreach (DataTable item in lista)
            {
                if (item.TableName.Equals("DataSet1"))
                {
                    if (item.Rows.Count > 0)
                    {
                        Utilidades.Formularios.AbrirFuera(new frmInformes("RETENCIONES DE PAGO", lista, "repRetencionesPagos"));
                    }
                }
            }*/
        }
        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);

            objEProveedor = new Entidades.Proveedor();
            objETipoDocProveedor = new Entidades.TipoDocumentoProveedor();
            Total = 0;
            ucFormasPagoCompras.Limpiar();
            RetencionesGanancias = 0;
            RetencionesIva = 0;
            rete = 0;
            Aplicado();
            lblRetencionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
            //lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            objEPago = new Entidades.Pago();
            //objEFacturaDetalle = new Entidades.Factura_Detalle();
            objEAsiento = new Entidades.Asiento();
            //Total1 = 0;

            
            cbLiquidaciones.Checked = false;
        }
        private bool ValidarFechaConciliacionCuenta(Entidades.CuentaBancaria pCuentaBancaria)
        {
            if (dtFecha.Value.Date <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }

        private bool ValidarFechaConciliacionCuentaCheques(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Cheque pCheque)
        {
            if (pCheque.FechaPago <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private void CargarValoresPago()
        {
            objEPago = new Entidades.Pago();
            objEPago.TipoDocumentoProveedor = objLTipoDocProveedor.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
            //objEPago.TipoDocumentoProveedor.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            //objEFacturaCompra.Numero = ucNumeroComprobante.Valor;
            objEPago.TipoDocumentoProveedor.Numerador = new Logica.Numerador().ObtenerUno(objEPago.TipoDocumentoProveedor.Numerador.Codigo);
            objEPago.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEPago.Proveedor.Nombre = lblNombreProveedor.Text.Trim();
            objEPago.Fecha = dtFecha.Value;
            objEPago.Letra = Convert.ToChar(objEPago.TipoDocumentoProveedor.Numerador.Letra);
            objEPago.PuntoDeVenta = objEPago.TipoDocumentoProveedor.Numerador.PuntoVenta;
            objEPago.Numero = objEPago.TipoDocumentoProveedor.Numerador.Numero;
            objEPago.Usuario = Singleton.Instancia.Usuario;
            objEPago.PuestoCaja = Singleton.Instancia.Puesto;
            objEPago.Observaciones = txtObservaciones.Text.Trim();
            if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                objEPago.Total = Convert.ToDouble(lblTotal.Text.Replace("$", ""));
            else
            {
                objEPago.Total = -Convert.ToDouble(lblTotal.Text.Replace("$", ""));
                objEPago.ChequeRechazado = cbChequeRechazado.Checked;
            }
            //objEPago.Total=lblTotal
            ucFormasPagoCompras.ObtenerDatos();

            objEPago.FacturaEfectivo.Clear();
            objEPago.FacturaEfectivo = ucFormasPagoCompras.Efectivos;
            objEPago.Cheques.Clear();
            objEPago.Cheques = ucFormasPagoCompras.Cheques;
            objEPago.ChequesPropios.Clear();
            objEPago.ChequesPropios = ucFormasPagoCompras.ChequesPropios;
            objEPago.Tranferencias.Clear();
            objEPago.Tranferencias = ucFormasPagoCompras.Tranferencias;
            objEPago.FacturasImputacion.Clear();
            objEPago.FacturasImputacion = ObtenerImputacion();
            objEPago.Impuestos = ObtenerImpuestos();

            List<PagosProveedoresImpuestos> impuestos = new List<PagosProveedoresImpuestos>();

            foreach (PagosProveedoresImpuestos item in objEPago.Impuestos)
            {
                Entidades.PagosProveedoresImpuestos ppi;
                if (impuestos.IndexOf(item) != -1)
                {
                    //impuestos[impuestos.IndexOf(item)].Impuesto = item.Impuesto;
                    //impuestos[impuestos.IndexOf(item)].TotalComprobante = item.TotalComprobante;
                    //impuestos[impuestos.IndexOf(item)].Regimen = item.Regimen;
                    impuestos[impuestos.IndexOf(item)].ImporteRetenido += item.ImporteRetenido;
                }
                else {
                    ppi = new PagosProveedoresImpuestos();
                    ppi.Impuesto = item.Impuesto;
                    ppi.Regimen = item.Regimen;
                    ppi.TotalComprobante = item.TotalComprobante;
                    ppi.ImporteRetenido = item.ImporteRetenido;
                    ppi.AlicuotaAplicada = item.AlicuotaAplicada;
                    impuestos.Add(ppi);
                }
            }
            objEPago.Impuestos = impuestos;
        }
        
        public List<Entidades.PagosProveedoresImpuestos> ObtenerImpuestos()
        {
            List<Entidades.PagosProveedoresImpuestos> facturas = new List<Entidades.PagosProveedoresImpuestos>();
            int indice = 0;
            int indice2 = 0;
            Entidades.PagosProveedoresImpuestos factura;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                
                Entidades.TipoDocumentoProveedor objETipoDoc = new TipoDocumentoProveedor();
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    
                    objETipoDoc.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoProveedor"].Value);
                    indice = tiposG.IndexOf(objETipoDoc);
                    indice2 = tiposI.IndexOf(objETipoDoc);
                    if (indice != -1 || indice2 != -1)
                    {
                        objETipoDoc = objLTipoDocProveedor.ObtenerUno(objETipoDoc.Codigo);
                        foreach (TipoDocumentoProveedorImpuesto item in objETipoDoc.Impuestos)
                        {
                            factura = new Entidades.PagosProveedoresImpuestos();

                            //factura.FacturaCompra.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                            factura.Impuesto = item.Impuesto;
                            factura.TotalComprobante = objEPago.Total;
                            factura.Regimen.Codigo = item.Regimen.Codigo;
                            switch (item.Del)
                            {
                                case 'N':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["Neto"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'I':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["IVA"].Value) * item.Porcentaje / 100);
                                    break;
                                case 'T':
                                    factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["Total2"].Value) * item.Porcentaje / 100);
                                    break;
                            }
                            factura.AlicuotaAplicada = item.Porcentaje;
                            facturas.Add(factura);
                        }
                    }


                }
            }
            if (rete > 0) {
                double val = 0;
                foreach (PagosProveedoresImpuestos item in facturas)
                {
                    val += item.ImporteRetenido;
                }

                factura = new Entidades.PagosProveedoresImpuestos();
                factura.Impuesto = new Logica.Impuesto().ObtenerUno(16);
                factura.TotalComprobante = Utilidades.Redondear.DosDecimales(objEPago.Total-val-rete);
                factura.Regimen.Codigo = 0;
                factura.AlicuotaAplicada = objEProveedor.TipoContribuyente.PorcentajeRetencion;
                factura.ImporteRetenido = Utilidades.Redondear.DosDecimales(rete);
                facturas.Add(factura);
            }


            return facturas;
        }

        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante);
            return res;
        }
        public List<Entidades.FacturaCompraImputacion> ObtenerImputacion()
        {
            List<Entidades.FacturaCompraImputacion> facturas = new List<Entidades.FacturaCompraImputacion>();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                Entidades.FacturaCompraImputacion factura;
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    factura = new Entidades.FacturaCompraImputacion();

                    factura.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    factura.TipoDocumentoProveedor.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoProveedor"].Value);
                    factura.Monto = Convert.ToDouble(fila.Cells["AAplicar"].Value);
                    factura.CodigoImputacion = Convert.ToChar(fila.Cells["CodigoImputacion"].Value);
                    factura.ImputacionAnterior = Convert.ToDouble(fila.Cells["Imputado"].Value);
                    facturas.Add(factura);

                }
            }
            return facturas;
        }


        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEPago.Fecha;
            objEAsiento.FechaEmision = objEPago.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = "Segun " + objEPago.TipoDocumentoProveedor.Descripcion + " de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            if (cbLiquidaciones.Checked)
                asientoDetalle.CuentaContable.Codigo = 20101020000;
            else
                asientoDetalle.CuentaContable.Codigo = 20101010000;

            if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            {
                asientoDetalle.Debe = Convert.ToDouble(Total+RetencionesGanancias+RetencionesIva);
                asientoDetalle.Haber = 0;
            }
            else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Convert.ToDouble(Total+ RetencionesGanancias + RetencionesIva);
            }
            objEAsiento.Detalle.Add(asientoDetalle);


            foreach (Entidades.Factura_Efectivo fe in objEPago.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(1);
                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                else
                {
                    Int64 cuenta = 0;
                    switch (Singleton.Instancia.Empresa.Codigo)
                    {
                        case 1:
                            cuenta = 10101020100;
                            break;
                        case 2:
                            cuenta = 10101020600;
                            break;
                        case 3:
                            cuenta = 10101020200;
                            break;
                        case 4:
                            cuenta = 10101020300;
                            break;
                        case 5:
                            cuenta = 10101020400;
                            break;
                        case 7:
                            cuenta = 10101020500;
                            break;

                    }
                    asientoDetalle.CuentaContable.Codigo = cuenta;
                }

                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = fe.Importe * fe.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = -fe.Importe * fe.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }



            foreach (Entidades.Cheque che in objEPago.Cheques)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(3);
                //    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                if (objEPago.ChequeRechazado)
                {
                    asientoDetalle.CuentaContable.Codigo = 10105140000;
                }
                else
                {
                    asientoDetalle.CuentaContable.Codigo = che.CuentaBancaria.CuentaContable.Codigo;
                }

                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {

                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                asientoDetalle.Cheque.Codigo = che.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque che in objEPago.ChequesPropios)
            {

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Cheque.Codigo = che.Codigo;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = che.Importe * che.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            foreach (Entidades.Tranferencia tran in objEPago.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = tran.Importe * tran.Moneda.Cotizacion;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.PagosProveedoresImpuestos ppi in objEPago.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = ppi.Impuesto.CuentaContable;
                if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = ppi.ImporteRetenido;
                }
                else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                {
                    asientoDetalle.Debe = ppi.ImporteRetenido;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
