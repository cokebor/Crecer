using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Presentacion
{
    public partial class frmFacturaCompra : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        public Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor;
        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();
        Entidades.FacturaCompra objEFacturaCompra = new Entidades.FacturaCompra();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago;
        


        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLogicaTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();
        Logica.Sucursal objLSucursal = new Logica.Sucursal();
        Logica.FacturaCompra objLFacturaCompra = new Logica.FacturaCompra();
        Logica.PorcentajeIva objLPorcentajeIva = new Logica.PorcentajeIva();

        frmCompraDirecta frmCompraD = new frmCompraDirecta();
        frmCompraDirectaNC frmCompraDNC = new frmCompraDirectaNC();
        frmCompraDirectaNCAjuste frmCompraDNCA = new frmCompraDirectaNCAjuste();
        frmCompraDirectaND frmCompraDND = new frmCompraDirectaND();

        string tipo = "BU";

        frmFormasDePago frmFormas;// = new frmFormasDePago("Compras");

        public double Neto
        {
            get
            {
                double n1, n2;
                if (txtNeto1.Text.Trim().Equals(""))
                {
                    n1 = 0;
                }
                else
                {
                    n1 = Convert.ToDouble(txtNeto1.Text.Trim());
                }
                if (txtNeto2.Text.Trim().Equals(""))
                {
                    n2 = 0;
                }
                else
                {
                    n2 = Convert.ToDouble(txtNeto2.Text.Trim());
                }
                return Utilidades.Redondear.DosDecimales(n1 + n2);
            }
        }

        
        private double IvaGastosVariable(double valor)
        {
            double iva = 0;
                foreach (DataGridViewRow dgr in dgvGastos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA3"].Value) == valor)
                    {
                        iva += Convert.ToDouble(dgr.Cells["IVA2"].Value);
                    }
                }

            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double NetoGastosVariable(double valor)
        {
            double neto = 0;
            foreach (DataGridViewRow dgr in dgvGastos.Rows)
            {
                if (Convert.ToDouble(dgr.Cells["PorcIVA3"].Value) == valor)
                {
                    neto += Convert.ToDouble(dgr.Cells["Neto2"].Value);
                }
            }

            return Utilidades.Redondear.DosDecimales(neto);
        }
        public double NetoGastos
        {
            get
            {
                double neto=0;
                foreach (DataGridViewRow fila in dgvGastos.Rows) {
                    neto+=Convert.ToDouble(fila.Cells["Neto2"].Value);
                }
                return Utilidades.Redondear.DosDecimales(neto);
            }
        }
        public double Iva
        {
            get
            {
                double i1, i2;
                if (txtIva1.Text.Trim().Equals(""))
                {
                    i1 = 0;
                }
                else
                {
                    i1 = Convert.ToDouble(txtIva1.Text.Trim());
                }
                if (txtIva2.Text.Trim().Equals(""))
                {
                    i2 = 0;
                }
                else
                {
                    i2 = Convert.ToDouble(txtIva2.Text.Trim());
                }
                return Utilidades.Redondear.DosDecimales(i1 + i2);
            }

        }

        public double IvaGastos
        {
            get
            {
                double iva = 0;
                foreach (DataGridViewRow fila in dgvGastos.Rows)
                {
                    iva += Convert.ToDouble(fila.Cells["IVA2"].Value);
                }
                return Utilidades.Redondear.DosDecimales(iva);
            }
        }
        public double NoGravado
        {
            get
            {
                double nogra;
                if (txtNoGravado.Text.Trim().Equals(""))
                {
                    nogra = 0;
                }
                else
                {
                    nogra = Convert.ToDouble(txtNoGravado.Text.Trim());
                }
                return Utilidades.Redondear.DosDecimales(nogra);
            }

        }

        public double NoGravadoGastos
        {
            get
            {
                double nogra = 0;
                foreach (DataGridViewRow fila in dgvGastos.Rows)
                {
                    nogra += Convert.ToDouble(fila.Cells["NoGravado2"].Value);
                }
                return Utilidades.Redondear.DosDecimales(nogra);
            }
        }
        public double Exento
        {
            get
            {
                double exento;
                if (txtExento.Text.Trim().Equals(""))
                {
                    exento = 0;
                }
                else
                {
                    exento = Convert.ToDouble(txtExento.Text.Trim());
                }
                return Utilidades.Redondear.DosDecimales(exento);
            }

        }

        public double ExentoGastos
        {
            get
            {
                double exe = 0;
                foreach (DataGridViewRow fila in dgvGastos.Rows)
                {
                    exe += Convert.ToDouble(fila.Cells["Exento2"].Value);
                }
                return Utilidades.Redondear.DosDecimales(exe);
            }

        }

        public double OtrosImpuestos
        {
            get
            {
                double otros = 0;
                foreach (DataGridViewRow dgvr in dgvDatos.Rows)
                {
                    otros += Convert.ToDouble(dgvr.Cells["Importe"].Value);
                }
                return Utilidades.Redondear.DosDecimales(otros);
            }
        }


        public double Total
        {
            get
            {
                return Iva + Neto + NoGravado + OtrosImpuestos + Exento;
            }

        }

        public double TotalGastos
        {
            get
            {
                return IvaGastos + NetoGastos + NoGravadoGastos + OtrosImpuestos + ExentoGastos;
            }

        }




        public frmFacturaCompra()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            frmFormas = new frmFormasDePago("Compras", this);
            Utilidades.Combo.Llenar(cbSucursal, objLSucursal.ObtenerTodos(), "Codigo", "Descripcion");
            ObtenerValor();
            if (Singleton.Instancia.Empresa.Codigo == 10) {
                this.ucNumeroComprobante.DesHabilitar();
            }

            if(Singleton.Instancia.Empresa.Codigo==2 || Singleton.Instancia.Empresa.Codigo == 6)
                cbSucursal.Visible=false;
        }

        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE FACTURAS DE COMPRAS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNeto1, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNeto2, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoImpuesto, 2);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNoGravado, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtExento, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 9);

            Utilidades.CajaDeTexto.LimiteTamaño(txtNeto3, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNoGravado3, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtExento3, 15);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbCuenta);
            Utilidades.Combo.Formato(cbSucursal);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Grilla.Formato(dgvGastos);
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            Utilidades.Combo.Formato(cbPorcIva1);
            Utilidades.Combo.Formato(cbPorcIva2);
            Utilidades.Combo.Formato(cbPorcIva3);
            dgvDatos.Columns["Impuesto"].Width = 150;
        }

        private void BotonesInicial()
        {
            //   Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    
                    if (objEntidadProveedor != null)
                    {
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                        //    if(optBienC.Checked)
                        frmCompraD.ObjProveedor = objEntidadProveedor;

                        frmCompraDNC.ObjProveedor = objEntidadProveedor;


                        frmCompraDNCA.ObjProveedor = objEntidadProveedor;

                        frmCompraDND.ObjProveedor = objEntidadProveedor;
                    }
                    else
                    {
                        objEntidadProveedor = new Entidades.Proveedor();

                        lblNombreProveedor.Text = "";
                        //  if (optBienC.Checked)
                        frmCompraD.ObjProveedor = new Entidades.Proveedor();
                        frmCompraDNC.ObjProveedor = new Entidades.Proveedor();
                        frmCompraDNCA.ObjProveedor = new Entidades.Proveedor();
                        frmCompraDND.ObjProveedor = new Entidades.Proveedor();
                        //cbTipoComprobante.DataSource = null;
                    }
                }
                else
                {
                    objEntidadProveedor = null;
                    //if (optBienC.Checked)
                    objETipoDocumentoProveedor = null;
                    frmCompraD.ObjProveedor = new Entidades.Proveedor();
                    frmCompraDNC.ObjProveedor = new Entidades.Proveedor();
                    frmCompraDNCA.ObjProveedor = new Entidades.Proveedor();
                    frmCompraDND.ObjProveedor = new Entidades.Proveedor();
                    lblNombreProveedor.Text = "";
                    //cbTipoComprobante.DataSource = null;
                }

                //ObtenerComprobantes();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerComprobantes()
        {
            if (objEntidadProveedor != null)
            {
                Utilidades.Combo.Llenar(cbTipoComprobante, objLogicaTipoDocumentoProveedor.ObtenerTodosDeTipoFacturas(objEntidadProveedor.TipoInscripcion.Codigo, objEntidadProveedor.FormaPago), "Codigo", "Descripcion");
                if (objEntidadProveedor.FormaPago)
                    btnFormaDePago.Visible = true;
                else
                    btnFormaDePago.Visible = false;
            }
            else
            {
                cbTipoComprobante.DataSource = null;
            }
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("FacturaCompra", this));
                    break;
                case (char)Keys.F7:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmImpuestoBuscar("FacturaCompra", this));
                    break;
            }

        }

        private void cbTipoInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTipoComprobante.SelectedIndex != -1)
            {
                try
                {

                    objETipoDocumentoProveedor = objLogicaTipoDocumentoProveedor.ObtenerUno(Convert.ToInt32(cbTipoComprobante.SelectedValue));
                    

                    Limpiar3();
                    //ucNumeroComprobante.txtLetra.Text = objETipoDocumentoProveedor.Letra.ToString();
                    frmFormas = new frmFormasDePago("Compras",this);
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC")) { 
                        chkAjuste.Visible = true;
                        chkAjuste.Checked = false;
                    }
                    else { 
                        chkAjuste.Visible = false;
                        chkAjuste.Checked = false;
                    }
                    if (objETipoDocumentoProveedor.AfectaCtaCte.Equals('N'))
                    {
                        btnFormaDePago.Enabled = true;
                    }
                    else
                    {
                        btnFormaDePago.Enabled = false;
                    }
                    if (objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
                    {
                        //txtPorcIva1.Text = "";
                        //txtPorcIva2.Text = "";
                        cbPorcIva1.Enabled = false;
                        //txtPorcIva1.Enabled = false;
                        cbPorcIva2.Enabled = false;
                        cbPorcIva3.Enabled = false;
                        //txtPorcIva2.Enabled = false;
                        txtNeto1.Enabled = false;
                        txtNeto2.Enabled = false;
                        txtNeto3.Enabled = false;
                        txtNeto1.Text = "";
                        txtNeto2.Text = "";
                        txtNeto3.Text = "";
                        txtNoGravado.Text = "";
                        txtNoGravado3.Text = "";
                        txtExento.Text = "";
                        txtExento3.Text = "";
                        txtCodigoImpuesto.Text = "";
                        txtImporte.Text = "";
                        dgvDatos.Rows.Clear();
                    }
                    else
                    {
                        Limpiar2();
                        /*frmCompraD = new frmCompraDirecta();
                        frmCompraDNC = new frmCompraDirectaNC();
                        frmFormas = new frmFormasDePago("Compras");*/
                    }
                    ObtenerNumeracion();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                Limpiar2();
            }

        }

        private void ObtenerNumeracion() {
            ucNumeroComprobante.txtLetra.Text = objETipoDocumentoProveedor.Letra.ToString();
            ucNumeroComprobante.txtPuntoVenta.Text=string.Format("{0:0000}", 1);
            //ucNumeroComprobante.txtNumero.Text = new Logica.FacturaCompra().ObtenerSiguienteNumero(objETipoDocumentoProveedor, objEntidadProveedor).ToString();
            
            ucNumeroComprobante.txtNumero.Text = string.Format("{0:00000000}", new Logica.FacturaCompra().ObtenerSiguienteNumero(objETipoDocumentoProveedor, objEntidadProveedor));
            
            cbCuenta.Focus();
            cbCuenta.Focus();
        }


        private void Limpiar3() {
            foreach (DataGridViewRow dg in frmCompraD.dgvDatos.Rows) {
                dg.Cells["PrecioUnitario"].Value = "";
            }
            foreach (DataGridViewRow dg in frmCompraDNC.dgvDatos.Rows)
            {
                dg.Cells["CantidadDevuelta"].Value = "";
            }
            foreach (DataGridViewRow dg in frmCompraDNCA.dgvDatos.Rows)
            {
                dg.Cells["DescuentoU"].Value = "";
            }
            foreach (DataGridViewRow dg in frmCompraDND.dgvDatos.Rows)
            {
                dg.Cells["DescuentoU"].Value = "";
            }
        }


        private void Limpiar2() {
            ucNumeroComprobante.Limpiar();
            //            txtPorcIva1.Text = "10,50";
            Utilidades.Combo.SeleccionarPrimerValor(cbPorcIva1);
            //txtPorcIva2.Text = "21,00";
            Utilidades.Combo.SeleccionarSegundoValor(cbPorcIva2);
            Utilidades.Combo.SeleccionarPrimerValor(cbPorcIva3);
            //txtPorcIva1.Enabled = true;
            cbPorcIva1.Enabled = true;
            //txtPorcIva2.Enabled = true;
            cbPorcIva2.Enabled = true;
            cbPorcIva3.Enabled = true;
            txtNeto1.Enabled = true;
            txtNeto2.Enabled = true;
            txtNeto3.Enabled = true;
            txtNeto1.Text = "";
            txtNeto2.Text = "";
            txtNeto3.Text = "";
            txtNoGravado.Text = "";
            txtNoGravado3.Text = "";
            txtExento.Text = "";
            txtExento3.Text = "";
            txtCodigoImpuesto.Text = "";
            txtImporte.Text = "";
            dgvDatos.Rows.Clear();

            objEImpuesto = new Entidades.Impuesto();
           /* objEntidadProveedor = new Entidades.Proveedor();
            objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
            */
            
            
            optBienU.Checked = true;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            /*objEFacturaCompra = new Entidades.FacturaCompra();
            objEAsiento = new Entidades.Asiento();
            frmCompraD = new frmCompraDirecta();*/
           // frmFormas = new frmFormasDePago("Compras", this);
            
        }

        private void dtFechaCont_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime FechaEmision, FechaContable;
            FechaEmision = dtFechaEmision.Value.Date;
            FechaContable = dtFechaCont.Value.Date;

            if (ValidarComprobante().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProveedor.Focus();
                return;
            }
           /* if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA"))
            {
                foreach (DataGridViewRow dgvr in frmCompraD.dgvDatos.Rows)
                {
                    if (dgvr.Cells["PrecioUnitario"].Value == null || dgvr.Cells["PrecioUnitario"].Value.Equals("") || dgvr.Cells["PrecioUnitario"].Value.Equals("0,00") || dgvr.Cells["PrecioUnitario"].Value.Equals("0"))
                    {
                        MessageBox.Show("Falta ingresar precios de productos!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }*/

            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked==false)
            {
                frmCompraDNC.ObtenerDatos();
                if (frmCompraDNC.Detalle.Count == 0) {
                    MessageBox.Show("Faltan ingresar cantidades devueltas de productos!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == true)
            {
                frmCompraDNCA.ObtenerDatos();
                if (frmCompraDNCA.Detalle.Count == 0)
                {
                    MessageBox.Show("Faltan ingresar descuentos de productos!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
            {
                frmCompraDND.ObtenerDatos();
                if (frmCompraDND.Detalle.Count == 0)
                {
                    MessageBox.Show("Faltan ingresar ajustes de precio de productos!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (tipo.Equals("G")) {
                if (dgvGastos.Rows.Count == 0) {
                    MessageBox.Show("Faltan ingresar detalles de gastos!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (Utilidades.Validar.ValidarFechas(FechaEmision, FechaContable).Equals(false))
            {
                MessageBox.Show("Fecha Contable no puede ser inferior a Fecha de Emision de Comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!tipo.Equals("G") && Total == 0)
            {
                MessageBox.Show("Total de factura no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tipo.Equals("G") && TotalGastos == 0)
            {
                MessageBox.Show("Total de factura no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (btnFormaDePago.Enabled)
            {
                if(tipo.Equals("G"))
                    frmFormas.Total = TotalGastos;
                else
                    frmFormas.Total = Total;
                frmFormas.ActualizarValores();
                if (frmFormas.Saldo != 0)
                {
                    MessageBox.Show("El saldo del comprobante debe ser $0.00 o debitarse completamente de cuenta corriente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            DateTime fechaMax = Convert.ToDateTime(FechaContable.Year + "-" + FechaContable.Month + "-" + DateTime.DaysInMonth(FechaContable.Year, FechaContable.Month));

            if (fechaMax < DateTime.Now.Date)
            {
                if (MessageBox.Show("Esta cargando una Factura de un mes ya cerrado.\n ¿Esta Seguro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else {
                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }

            try
            {
         
                Comprobante();
                Asiento();

                if ((objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == true) || objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND")) {
                    objLFacturaCompra.AgregarAjustes(objEFacturaCompra, objEAsiento);
                }
                else {
                    if ((objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == false)) {
                        objLFacturaCompra.ValidarStock(objEFacturaCompra);
                    }
                    objLFacturaCompra.Agregar(objEFacturaCompra, objEAsiento);
                }
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);

            objEImpuesto = new Entidades.Impuesto();
            objEntidadProveedor = new Entidades.Proveedor();
            objETipoDocumentoProveedor = null;// new Entidades.TipoDocumentoProveedor();

            //txtPorcIva1.Text = "10,50";
            Utilidades.Combo.SeleccionarPrimerValor(cbPorcIva1);
            //txtPorcIva2.Text = "21,00";
            Utilidades.Combo.SeleccionarSegundoValor(cbPorcIva2);
            Utilidades.Combo.SeleccionarPrimerValor(cbPorcIva3);
            ucNumeroComprobante.Limpiar();
            optBienU.Checked = true;
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            objEFacturaCompra = new Entidades.FacturaCompra();
            chkAjuste.Checked = false;
            dgvGastos.Rows.Clear();
            //objEFacturaDetalle = new Entidades.Factura_Detalle();
            objEAsiento = new Entidades.Asiento();
            frmCompraD = new frmCompraDirecta();
            frmCompraDNC = new frmCompraDirectaNC();
            frmCompraDNCA = new frmCompraDirectaNCAjuste();
            frmCompraDND = new frmCompraDirectaND();
            frmFormas = new frmFormasDePago("Compras", this);
            Utilidades.ControlesGenerales.LimpiarControles(this);
            txtCodigoProveedor.Focus();
            
        }

        private void Asiento()
        {
            
                CargarAsiento();
         }
        private void Comprobante()
        {
                CargarValoresFactura();
                // objEFactura=FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
        }

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            //objEAsiento.Fecha = objEFacturaCompra.FechaEmision;
            objEAsiento.Fecha = objEFacturaCompra.FechaContable;
            objEAsiento.FechaEmision = objEFacturaCompra.FechaEmision;
            objEAsiento.Sucursal = Convert.ToInt32(cbSucursal.SelectedValue);
            if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA"))
                objEAsiento.Descripcion = "Factura de Compra N°: " + objEFacturaCompra.Numero + " de " + lblNombreProveedor.Text;
            else if(objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                objEAsiento.Descripcion = "Nota de Crédito N°: " + objEFacturaCompra.Numero + " de " + lblNombreProveedor.Text;
            else if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
                objEAsiento.Descripcion = "Nota de Débito N°: " + objEFacturaCompra.Numero + " de " + lblNombreProveedor.Text;
            Entidades.Asiento_Detalle asientoDetalle;

            if (!tipo.Equals("G"))
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(cbCuenta.SelectedValue));
                if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Neto + NoGravado + Exento;
                }
                else
                {
                    asientoDetalle.Debe = Neto + NoGravado + Exento;
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            else
            {
                foreach (DataGridViewRow fila in dgvGastos.Rows)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(fila.Cells["CuentaContable2"].Value));
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                    {
                        asientoDetalle.Debe = 0;
                        asientoDetalle.Haber = Convert.ToDouble(fila.Cells["Neto2"].Value) + Convert.ToDouble(fila.Cells["NoGravado2"].Value) + Convert.ToDouble(fila.Cells["Exento2"].Value);
                    }
                    else
                    {
                        asientoDetalle.Debe = Convert.ToDouble(fila.Cells["Neto2"].Value) + Convert.ToDouble(fila.Cells["NoGravado2"].Value) + Convert.ToDouble(fila.Cells["Exento2"].Value);
                        asientoDetalle.Haber = 0;
                    }
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }
            if (!tipo.Equals("G"))
            {
                if (Iva != 0)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 10105010000;
                    if (!objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
                    {
                        if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                        {
                            asientoDetalle.Debe = 0;
                            asientoDetalle.Haber = Iva;
                        }
                        else
                        {
                            asientoDetalle.Debe = Iva;
                            asientoDetalle.Haber = 0;
                        }
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                }
            }
            else
            {
                if (IvaGastos != 0)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 10105010000;
                    if (!objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
                    {
                        if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                        {
                            asientoDetalle.Debe = 0;
                            asientoDetalle.Haber = IvaGastos;
                        }
                        else
                        {
                            asientoDetalle.Debe = IvaGastos;
                            asientoDetalle.Haber = 0;
                        }
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                }
            }
            if (!btnFormaDePago.Enabled)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaPago.ObtenerUno(4);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC")) {
                    if(!tipo.Equals("G"))
                        asientoDetalle.Debe = Total;
                    else
                        asientoDetalle.Debe = TotalGastos;
                    asientoDetalle.Haber = 0;
                }
                else { 
                    asientoDetalle.Debe = 0;
                    if (!tipo.Equals("G"))
                        asientoDetalle.Haber = Total;
                    else
                        asientoDetalle.Haber = TotalGastos;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            else
            {
                foreach (Entidades.Factura_Efectivo fe in objEFacturaCompra.FacturaEfectivo)
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
                            case 2:
                            case 6:
                                cuenta = 10101020100;
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
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                    {
                        asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                        asientoDetalle.Haber = 0;
                    } else { 
                        asientoDetalle.Debe = 0;
                        asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                    }
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
                foreach (Entidades.Cheque che in objEFacturaCompra.Cheques)
                {

                    asientoDetalle = new Entidades.Asiento_Detalle();
                    objEFormaDePago = objLFormaPago.ObtenerUno(3);
                    asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                    {
                        asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(Math.Abs(che.Importe) * che.Moneda.Cotizacion);
                        asientoDetalle.Haber = 0;
                    } else { 
                        asientoDetalle.Debe = 0;
                        asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(che.Importe) * che.Moneda.Cotizacion);
                    }
                    objEAsiento.Detalle.Add(asientoDetalle);
                }

                foreach (Entidades.Cheque che in objEFacturaCompra.ChequesPropios)
                {

                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                    {
                        asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(Math.Abs(che.Importe) * che.Moneda.Cotizacion);
                        asientoDetalle.Haber = 0;
                    } else { 
                        asientoDetalle.Debe = 0;
                        asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(che.Importe) * che.Moneda.Cotizacion);
                    }
                    objEAsiento.Detalle.Add(asientoDetalle);
                }

                foreach (Entidades.Tranferencia tran in objEFacturaCompra.Tranferencias)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                    if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                    {
                        asientoDetalle.Debe = Math.Abs(tran.Importe) * tran.Moneda.Cotizacion;
                        asientoDetalle.Haber = 0;
                    }
                    else {
                        asientoDetalle.Debe = 0;
                        asientoDetalle.Haber = Math.Abs(tran.Importe) * tran.Moneda.Cotizacion;
                    }
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }


            foreach (Entidades.FacturaImpuesto fi in objEFacturaCompra.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = fi.Impuesto.CuentaContable;
                if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = System.Math.Abs(fi.Importe);
                }
                else {
                    asientoDetalle.Debe = System.Math.Abs(fi.Importe);
                    asientoDetalle.Haber = 0;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

        }

        private void CargarValoresFactura()
        {
            objEFacturaCompra = new Entidades.FacturaCompra();
            if (Singleton.Instancia.Empresa.Codigo == 2 || Singleton.Instancia.Empresa.Codigo == 6)
                objEFacturaCompra.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
            else
                objEFacturaCompra.Sucursal.Codigo = Convert.ToInt32(cbSucursal.SelectedValue);

            objEFacturaCompra.TipoDocumentoProveedor.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            objEFacturaCompra.Letra = ucNumeroComprobante.Letra;
            objEFacturaCompra.PuntoDeVenta = ucNumeroComprobante.PuntoDeVenta;
            objEFacturaCompra.Numero = ucNumeroComprobante.Numero;
            objEFacturaCompra.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEFacturaCompra.FechaEmision = dtFechaEmision.Value;
            objEFacturaCompra.FechaContable = dtFechaCont.Value;
            objEFacturaCompra.TipoCompra = tipo;

            int mult = 1;
            if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") ) {
                mult = -1;
            }
            if (tipo.Equals("G")) {
                int i = 0;
                foreach (DataRowView o in cbPorcIva3.Items) {
                    if (IvaGastosVariable(Convert.ToDouble(o[1].ToString())) != 0) {
                        if (i == 0)
                        {
                            objEFacturaCompra.Neto1 = mult * Convert.ToDouble(NetoGastosVariable(Convert.ToDouble(o[1].ToString())));
                            objEFacturaCompra.DescripImp1 = Convert.ToDouble(o[1].ToString());
                            objEFacturaCompra.ImporteImp1 = mult * IvaGastosVariable(Convert.ToDouble(o[1].ToString()));
                            i++;
                        }
                        else if (i == 1) {
                            objEFacturaCompra.Neto2 = mult * Convert.ToDouble(NetoGastosVariable(Convert.ToDouble(o[1].ToString())));
                            objEFacturaCompra.DescripImp2 = Convert.ToDouble(o[1].ToString());
                            objEFacturaCompra.ImporteImp2 = mult * IvaGastosVariable(Convert.ToDouble(o[1].ToString()));
                        }
                    }
                }
            }
            else { 
                if (!txtNeto1.Text.Trim().Equals("") && !txtNeto1.Text.Trim().Equals("0,00"))
                {
                    objEFacturaCompra.Neto1 = mult * Convert.ToDouble(txtNeto1.Text.Trim());
                    objEFacturaCompra.DescripImp1 = Convert.ToDouble(cbPorcIva1.SelectedValue);
                    objEFacturaCompra.ImporteImp1 = mult * Convert.ToDouble(txtIva1.Text.Trim());
                }

                if (!txtNeto2.Text.Trim().Equals("") && !txtNeto2.Text.Trim().Equals("0,00"))
                {
                    objEFacturaCompra.Neto2 = mult * Convert.ToDouble(txtNeto2.Text.Trim());
                    objEFacturaCompra.DescripImp2 = Convert.ToDouble(cbPorcIva2.SelectedValue);
                    objEFacturaCompra.ImporteImp2 = mult * Convert.ToDouble(txtIva2.Text.Trim());
                }
            }
            /*
                if (txtPorcIva1.Text.Trim().Equals(""))
                {
                    if (!txtPorcIva2.Text.Trim().Equals(""))
                    {
                        if (!txtNeto2.Text.Trim().Equals("") && !txtNeto2.Text.Trim().Equals("0,00"))
                        {
                            objEFacturaCompra.Neto1 = mult * Convert.ToDouble(txtNeto2.Text.Trim());
                            objEFacturaCompra.DescripImp1 = Convert.ToDouble(txtPorcIva2.Text.Trim());
                            objEFacturaCompra.ImporteImp1 =mult * Convert.ToDouble(txtIva2.Text.Trim());
                        }
                    }
                }
                else
                {
                    if (txtNeto1.Text.Trim().Equals("") || txtNeto1.Text.Trim().Equals("0,00"))
                    {
                        if (!txtPorcIva2.Text.Trim().Equals(""))
                        {
                            if (!txtNeto2.Text.Trim().Equals("") && !txtNeto2.Text.Trim().Equals("0,00"))
                            {
                                objEFacturaCompra.Neto1 = mult * Convert.ToDouble(txtNeto2.Text.Trim());
                                objEFacturaCompra.DescripImp1 = Convert.ToDouble(txtPorcIva2.Text.Trim());
                                objEFacturaCompra.ImporteImp1 = mult * Convert.ToDouble(txtIva2.Text.Trim());
                            }
                        }
                    }
                    else
                    {
                        objEFacturaCompra.Neto1 = mult * Convert.ToDouble(txtNeto1.Text.Trim());
                        objEFacturaCompra.DescripImp1 = Convert.ToDouble(txtPorcIva1.Text.Trim());
                        objEFacturaCompra.ImporteImp1 = mult * Convert.ToDouble(txtIva1.Text.Trim());
                        if (!txtPorcIva2.Text.Trim().Equals(""))
                        {
                            if (!txtNeto2.Text.Trim().Equals("") && !txtNeto2.Text.Trim().Equals("0,00"))
                            {
                                objEFacturaCompra.Neto2 = mult * Convert.ToDouble(txtNeto2.Text.Trim());
                                objEFacturaCompra.DescripImp2 = Convert.ToDouble(txtPorcIva2.Text.Trim());
                                objEFacturaCompra.ImporteImp2 = mult * Convert.ToDouble(txtIva2.Text.Trim());
                            }
                        }

                    }
                }
        */

            if (tipo.Equals("G")) {
                objEFacturaCompra.NoGravado = mult * NoGravadoGastos;//(string.IsNullOrEmpty(txtNoGravado3.Text.Trim()) ? 0 : Convert.ToDouble(txtNoGravado3.Text.Trim()));
                objEFacturaCompra.Exento = mult * ExentoGastos;//(string.IsNullOrEmpty(txtExento3.Text.Trim()) ? 0 : Convert.ToDouble(txtExento3.Text.Trim()));
            }
            else { 
            objEFacturaCompra.NoGravado = mult * (string.IsNullOrEmpty(txtNoGravado.Text.Trim()) ? 0 : Convert.ToDouble(txtNoGravado.Text.Trim()));
            objEFacturaCompra.Exento = mult * (string.IsNullOrEmpty(txtExento.Text.Trim()) ? 0 : Convert.ToDouble(txtExento.Text.Trim()));
            
            }
            objEFacturaCompra.Usuario = Singleton.Instancia.Usuario;
            objEFacturaCompra.PuestoCaja = Singleton.Instancia.Puesto;
            objEFacturaCompra.Impuestos.Clear();

            foreach (DataGridViewRow imp in dgvDatos.Rows)
            {
                Entidades.FacturaImpuesto fi = new Entidades.FacturaImpuesto();
                fi.Impuesto.Codigo = Convert.ToInt32(imp.Cells["Codigo"].Value);
                fi.Impuesto.CuentaContable.Codigo = Convert.ToInt64(imp.Cells["CuentaContable"].Value);
                fi.Importe = mult * Convert.ToDouble(imp.Cells["Importe"].Value);
                objEFacturaCompra.Impuestos.Add(fi);
            }
            frmFormas.ObtenerDatos();
            objEFacturaCompra.FacturaEfectivo.Clear();
            if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC")) {
                foreach (Entidades.Factura_Efectivo fe in frmFormas.ListaFacturaEfectivo) {
                    fe.Importe = mult * fe.Importe;
                }
            }

            objEFacturaCompra.FacturaEfectivo = frmFormas.ListaFacturaEfectivo;
            objEFacturaCompra.Cheques.Clear();
            if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
            {
                foreach (Entidades.Cheque fe in frmFormas.Cheques)
                {
                    fe.Importe = mult * fe.Importe;
                }
            }
            objEFacturaCompra.Cheques = frmFormas.Cheques;
            objEFacturaCompra.ChequesPropios.Clear();
            if (objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
            {
                foreach (Entidades.Cheque fe in frmFormas.ChequesPropios)
                {
                    fe.Importe = mult * fe.Importe;
                }
            }

            objEFacturaCompra.ChequesPropios = frmFormas.ChequesPropios;
            objEFacturaCompra.Tranferencias.Clear();
            objEFacturaCompra.Tranferencias = frmFormas.Tranferencias;
            if (!objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
            {
                foreach (Entidades.Tranferencia t in frmFormas.Tranferencias)
                {
                    t.Importe=-1 * t.Importe;
                }
            }

            objEFacturaCompra.Detalle.Clear();
            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA"))
            {
                objEFacturaCompra.Remito.Codigo = Convert.ToInt32(frmCompraD.cbRemitos.SelectedValue);
                frmCompraD.ObtenerDatos();
                objEFacturaCompra.Detalle = frmCompraD.Detalle;
            }
            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked==false)
            {
                objEFacturaCompra.Detalle = frmCompraDNC.Detalle;
            }

            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == true)
            {
                foreach (Entidades.FacturaCompra_Detalle fc in frmCompraDNCA.Detalle) {
                    fc.PrecioUnitario = mult * fc.PrecioUnitario;
                }
                objEFacturaCompra.Detalle = frmCompraDNCA.Detalle;
            }

            if (tipo.Equals("BC") && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
            {
                objEFacturaCompra.Detalle = frmCompraDND.Detalle;
            }

            if (btnFormaDePago.Enabled)
            {
                objEFacturaCompra.Imputacion = 'T';
            }
            else
            {
                objEFacturaCompra.Imputacion = 'F';
            }
        }
    
        

        private void CargarTotales() {
            if(!tipo.Equals("G"))
            lblTotal.Text = Total.ToString("C2");
            else
                lblTotal.Text = TotalGastos.ToString("C2");
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void cbTipoDomprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void ucNumeroComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtFechaEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtFechaCont_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void optBienU_CheckedChanged(object sender, EventArgs e)
        {
            if (objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
            {
                //txtPorcIva1.Text = "";
                //txtPorcIva2.Text = "";
                //txtPorcIva1.Enabled = false;
                //txtPorcIva2.Enabled = false;
                cbPorcIva1.Enabled = false;
                cbPorcIva2.Enabled = false;
                txtNeto1.Enabled = false;
                txtNeto2.Enabled = false;
                txtNeto1.Text = "";
                txtNeto2.Text = "";
                txtNoGravado.Text = "";
                txtExento.Text = "";
                txtCodigoImpuesto.Text = "";
                txtImporte.Text = "";
                dgvDatos.Rows.Clear();
            }

            if (optBienU.Checked)
            {
                tipo = "BU";
                panelBUBC.Visible = true;
                panelG.Visible = false;
                ObtenerValor();
            }
            CargarTotales();
        }

        private void ObtenerValor()
        {
            try
            {
                DataTable dt=new DataTable();
                switch (tipo) {
                    case "BU":
                        dt = objLCuentaContable.ObtenerBienesDeUso();
                        break;
                    case "BC":
                        dt = objLCuentaContable.ObtenerBienesDeCambio();
                        break;
                    case "G":
                        dt = objLCuentaContable.ObtenerGastos();
                        break;
                }
                Utilidades.Combo.Llenar(cbCuenta, dt, "Codigo", "Nombre");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optBienC_CheckedChanged(object sender, EventArgs e)
        {
            if (objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
            {
                //txtPorcIva1.Text = "";
                //txtPorcIva2.Text = "";
                //txtPorcIva1.Enabled = false;
                //txtPorcIva2.Enabled = false;
                cbPorcIva1.Enabled = false;
                cbPorcIva2.Enabled = false;
                txtNeto1.Enabled = false;
                txtNeto2.Enabled = false;
                txtNeto1.Text = "";
                txtNeto2.Text = "";
                txtNoGravado.Text = "";
                txtExento.Text = "";
                txtCodigoImpuesto.Text = "";
                txtImporte.Text = "";
                dgvDatos.Rows.Clear();
            }
            if (optBienC.Checked)
            {
                tipo = "BC";
                ObtenerValor();
                panelBUBC.Visible = true;
                panelG.Visible = false;
                // txtPorcIva1.Enabled = false;
                //  txtPorcIva2.Enabled = false;
                cbPorcIva1.Enabled = false;
                cbPorcIva2.Enabled = false;
                txtNeto1.Enabled = false;
                txtNeto2.Enabled = false;
                // frmCompraD.ObjProveedor = objEntidadProveedor;
                if (objETipoDocumentoProveedor !=null && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked==false) {
                    frmCompraDNC.FormularioAnterior = this;
                    frmCompraDNC.ShowDialog();
                }
                else if(objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA")) { 
                frmCompraD.FormularioAnterior = this;
                    frmCompraD.dgvDatos.Enabled = true;
                frmCompraD.ShowDialog();
                }
                else if (objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && chkAjuste.Checked == true)
                {
                    frmCompraDNCA.FormularioAnterior = this;
                    frmCompraDNCA.ShowDialog();
                }
                else if (objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
                {
                    frmCompraDND.FormularioAnterior = this;
                    frmCompraDND.ShowDialog();
                }

            }
            else {
                if (objETipoDocumentoProveedor != null && objETipoDocumentoProveedor.AfectaIVA.Equals('N')) {
                    //txtPorcIva1.Enabled = false;
                    // txtPorcIva2.Enabled = false;
                    cbPorcIva1.Enabled = false;
                    cbPorcIva2.Enabled = false;
                }
                else { 
               // txtPorcIva1.Enabled = true;
                //txtPorcIva2.Enabled = true;
                    cbPorcIva1.Enabled = true;
                    cbPorcIva2.Enabled = true;
                }
                txtNeto1.Enabled = true;
                txtNeto2.Enabled = true;
                txtNeto1.Text = "";
                txtNeto2.Text = "";
            }
            CargarTotales();
        }

        private void optGastos_CheckedChanged(object sender, EventArgs e)
        {
            if (objETipoDocumentoProveedor!=null && objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
            {
                //txtPorcIva1.Text = "";
               // txtPorcIva2.Text = "";
              //  txtPorcIva1.Enabled = false;
            //    txtPorcIva2.Enabled = false;
                cbPorcIva1.Enabled = false;
                cbPorcIva2.Enabled = false;
                txtNeto1.Enabled = false;
                txtNeto2.Enabled = false;
                txtNeto1.Text = "";
                txtNeto2.Text = "";
                txtNoGravado.Text = "";
                txtExento.Text = "";
                txtCodigoImpuesto.Text = "";
                txtImporte.Text = "";
                dgvDatos.Rows.Clear();
            }
            if (optGastos.Checked)
            {
                tipo = "G";
                panelBUBC.Visible = false;
                panelG.Visible = true;
                ObtenerValor();
            }
            CargarTotales();
        }

        private void frmFacturaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                Utilidades.Combo.Llenar(cbPorcIva1, objLPorcentajeIva.ObtenerTodos(), "Descripcion", "Descripcion");
                Utilidades.Combo.Llenar(cbPorcIva2, objLPorcentajeIva.ObtenerTodos(), "Descripcion", "Descripcion");
                Utilidades.Combo.Llenar(cbPorcIva3, objLPorcentajeIva.ObtenerTodos(), "Descripcion", "Descripcion");
                Utilidades.Combo.SeleccionarSegundoValor(cbPorcIva2);
                //Utilidades.Combo.SeleccionarSegundoValor(cbPorcIva3);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnFormaDePago_Click(object sender, EventArgs e)
        {
            if(!tipo.Equals("G"))
            frmFormas.Total = Total;
            else
                frmFormas.Total = TotalGastos;
            frmFormas.ActualizarValores();

            Utilidades.Formularios.Abrir(this.MdiParent, frmFormas);
        }

        private void txtPorcIva1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtNeto1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtIva1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtPorcIva2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtNeto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtIva2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtNoGravado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoImpuesto.Text.Trim().Equals(""))
                {
                    //objEImpuesto = objLImpuesto.ObtenerUnoCompraActivo(Convert.ToInt32(txtCodigoImpuesto.Text.Trim()));
                    objEImpuesto = objLImpuesto.ObtenerUnoVentaActivo(Convert.ToInt32(txtCodigoImpuesto.Text.Trim()));
                    if (objEImpuesto != null)
                    {
                        lblImpuesto.Text = objEImpuesto.Descripcion;
                    }
                    else
                    {
                        objEImpuesto = new Entidades.Impuesto();
                        lblImpuesto.Text = "";
                        //cbTipoComprobante.DataSource = null;
                    }
                }
                else
                {
                    objEImpuesto = null;
                    lblImpuesto.Text = "";
                    //cbTipoComprobante.DataSource = null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPorcIva1_TextChanged(object sender, EventArgs e)
        {
            txtIva1.Text = CalcularIVA(cbPorcIva1, txtNeto1).ToString();
            CargarTotales();
        }

        private double CalcularIVA(ComboBox porcIva, TextBox neto) {
            double iva=0;
            if (!porcIva.Text.Trim().Equals("") && !neto.Text.Trim().Equals(""))
            {
                double n=0, i=0;
                n = Convert.ToDouble(neto.Text.Trim());
                i = Convert.ToDouble(porcIva.Text.Trim());
                iva = Utilidades.Redondear.DosDecimales(n * (i / 100));
            }
            else {
                iva = 0;
            }


            return iva;
        }

        private void txtNeto1_TextChanged(object sender, EventArgs e)
        {
            txtIva1.Text = CalcularIVA(cbPorcIva1, txtNeto1).ToString();
            CargarTotales();
        }

        private void txtPorcIva2_TextChanged(object sender, EventArgs e)
        {
            txtIva2.Text = CalcularIVA(cbPorcIva2, txtNeto2).ToString();
            CargarTotales();
        }

        private void txtNeto2_TextChanged(object sender, EventArgs e)
        {
            txtIva2.Text = CalcularIVA(cbPorcIva2, txtNeto2).ToString();
            CargarTotales();
        }

        private void txtCodigoImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoImpuesto.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvDatos.Rows) {
                if (Convert.ToInt32(fila.Cells["Codigo"].Value) == objEImpuesto.Codigo) {
                    MessageBox.Show("Impuesto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            dgvDatos.Rows.Add(objEImpuesto.Codigo, objEImpuesto.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim())), objEImpuesto.CuentaContable.Codigo);
            txtCodigoImpuesto.Text = "";
            txtImporte.Text = "";
            CargarTotales();
            txtCodigoImpuesto.Focus();
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblImpuesto);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            return res;
        }

        private bool ValidarGasto()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuenta);
            res = res && ( Utilidades.Validar.TextBoxEnBlanco(txtNeto3) || Utilidades.Validar.TextBoxEnBlanco(txtNoGravado3) || Utilidades.Validar.TextBoxEnBlanco(txtExento3));
            return res;
        }
        private bool ValidarComprobante()
        {
            bool res = false;
            res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor);
            if(Singleton.Instancia.Empresa.Codigo==1)
                res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbSucursal);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbTipoComprobante);
            res = res || NumeroDocumentoBlanco(ucNumeroComprobante);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuenta);
            return res;
        }

        public static bool NumeroDocumentoBlanco(ucNumeroComprobante txt)
        {
            bool res = false;
            if (txt.txtLetra.Text.Trim().Equals("") || txt.txtPuntoVenta.Text.Trim().Equals("") || txt.txtNumero.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CargarTotales();
            }
        }

        private void txtNoGravado_TextChanged(object sender, EventArgs e)
        {
            CargarTotales();
        }

        private void cbSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtExento_TextChanged(object sender, EventArgs e)
        {
            CargarTotales();
        }

        private void txtExento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtIva1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipo = "BC";
            ObtenerValor();
            frmCompraDNCA.FormularioAnterior = this;
            frmCompraDNCA.ShowDialog();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.FacturaCompra objFacturaCompra =new Entidades.FacturaCompra();
                objFacturaCompra.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
                objFacturaCompra.Proveedor.Nombre = lblNombreProveedor.Text.Trim();
                objFacturaCompra.TipoDocumentoProveedor.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
                objFacturaCompra.Letra = ucNumeroComprobante.Letra;
                objFacturaCompra.PuntoDeVenta = ucNumeroComprobante.PuntoDeVenta;
                objFacturaCompra.Numero = ucNumeroComprobante.Numero;
                if (objLFacturaCompra.ValidarExistencia(objFacturaCompra) == 1)
                {
                    MessageBox.Show("El comprobante numero " + objFacturaCompra.Numero + " del proveedor " + objFacturaCompra.Proveedor.Nombre + " ya se encuentra ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    MessageBox.Show("Comprobante no ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtNoGravado_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtExento_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbPorcIva1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIva1.Text = CalcularIVA(cbPorcIva1, txtNeto1).ToString();
            CargarTotales();
        }

        private void cbPorcIva2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIva2.Text = CalcularIVA(cbPorcIva2, txtNeto2).ToString();
            CargarTotales();
        }

        private void txtCodigoProveedor_Leave(object sender, EventArgs e)
        {
            ObtenerComprobantes();
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (ValidarGasto().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoImpuesto.Focus();
                return;
            }



            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                if (Convert.ToInt64(fila.Cells["CuentaContable2"].Value) == Convert.ToInt64(cbCuenta.SelectedValue))
                {
                    //Aca validar y que permita ingresar solo si es distinto el iva
               //     MessageBox.Show("Gasto ya ingresado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
               //     return;
                }
            }

            //double[] cant = new double[5]; int a = 0;
            List<double> valores = new List<double>();
            valores.Add(Convert.ToDouble(cbPorcIva3.Text.Trim()));
            foreach (DataGridViewRow fila in dgvGastos.Rows)
            {
                if (!valores.Exists(element=>element==Convert.ToDouble(fila.Cells["PorcIva3"].Value))) {
                    valores.Add(Convert.ToDouble(fila.Cells["PorcIva3"].Value));
                }
                /*if (cant.)
                cant[a] = Convert.ToDouble(fila.Cells["PorcIva3"].Value);*/
            }

            if (valores.Count > 2) {
                MessageBox.Show("No se puede ingresar mas de dos porcentajes distintos de iva", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        
            dgvGastos.Rows.Add(cbCuenta.Text.Trim(), txtNeto3.Text.Trim().Equals("")?0:Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtNeto3.Text.Trim())), Utilidades.Redondear.DosDecimales(Convert.ToDouble(cbPorcIva3.Text)), txtIVA3.Text.Trim().Equals("")?0:Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtIVA3.Text.Trim())), txtNoGravado3.Text.Trim().Equals("")?0:Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtNoGravado3.Text)), txtExento3.Text.Trim().Equals("")?0:Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtExento3.Text.Trim())),Convert.ToInt64(cbCuenta.SelectedValue));
                //objEImpuesto.Codigo, objEImpuesto.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtImporte.Text.Trim())), objEImpuesto.CuentaContable.Codigo);
            txtCodigoImpuesto.Text = "";
            Utilidades.Combo.SeleccionarPrimerValor(cbCuenta);
            txtNeto3.Text = "";
            Utilidades.Combo.SeleccionarPrimerValor(cbPorcIva3);
            txtIVA3.Text = "";
            txtNoGravado3.Text = "";
            txtExento3.Text = "";
            CargarTotales();
            cbCuenta.Focus();
        }

        private void txtNeto3_TextChanged(object sender, EventArgs e)
        {
            txtIVA3.Text = CalcularIVA(cbPorcIva3, txtNeto3).ToString();
            CargarTotales();
        }

        private void txtNeto3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtIVA3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtNoGravado3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtExento3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void cbPorcIva1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbPorcIva3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIVA3.Text = CalcularIVA(cbPorcIva3, txtNeto3).ToString();
            CargarTotales();
        }

        private void cbPorcIva2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbPorcIva3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvGastos.CurrentRow != null)
            {
                dgvGastos.Rows.Remove(dgvGastos.CurrentRow);
                CargarTotales();
            }
        }


    }
}
