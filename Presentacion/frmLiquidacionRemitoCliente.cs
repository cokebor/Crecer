using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLiquidacionRemitoCliente : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.RemitoCliente objLRemitoCliente = new Logica.RemitoCliente();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Factura objLFactura = new Logica.Factura();

        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Factura_Detalle objEFacturaDetalle = new Entidades.Factura_Detalle();
        Entidades.Factura_Merma objEFacturaMerma = new Entidades.Factura_Merma();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.RemitoCliente_M objERemitoCliente = new Entidades.RemitoCliente_M();
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();

        public frmLiquidacionRemitoCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            LimitesTamaño();
            dgvDatos.AutoGenerateColumns = false;
        }
        private void Titulo()
        {
            this.Text = "LIQUIDACION DE REMITOS DE CLIENTES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbComprobante);
            lblTotalVentaNeta.Text = Convert.ToDouble("0").ToString("C2");
            lblComisiones.Text = Convert.ToDouble("0").ToString("C2");
            lblSubTotal1.Text = Convert.ToDouble("0").ToString("C2");
            lblSubTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Codigo"].Width = 55;
            dgvDatos.Columns["Descripción"].Width = 160;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["Lote"].Width = 70;
            dgvDatos.Columns["CantidadLiq"].Width = 80;
            dgvDatos.Columns["Merma"].Width = 65;
            dgvDatos.Columns["CantidadALiq"].Width = 90;
            dgvDatos.Columns["PrecioUnitario"].Width = 95;
            //dgvDatos.Columns["Total"].Width = 102;

           // dgvDatos.Columns["Merma"].ReadOnly = false;
            dgvDatos.Columns["CantidadALiq"].ReadOnly = false;
            dgvDatos.Columns["PrecioUnitario"].ReadOnly = false;
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetencionDeImp, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPerspDGR, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtFletes, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescarga, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetRG3452, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtIVACom, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtServFlete, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtServDesc, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetRG2784, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRedondeo, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPorcCom, 5);
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("LiquidacionRemitoCliente", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("LiquidacionRemitoCliente", this));
                    break;
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objECliente = objLCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));
                    if (objECliente != null)
                    {
                        lblNombreCliente.Text = objECliente.Nombre;
                        //txtPorcCom.Text = objECliente.Comision.ToString("0,00");
                        double com = objECliente.Comision;
                        txtPorcCom.Text = objECliente.Comision.ToString("0.00");
                        ObtenerTipoDocumento();
                        ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                        txtPorcCom.Text = "0,00";
                        cbComprobante.DataSource = null;
                        dgvDatos.Rows.Clear();
                        //                   Calcular();
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                    txtPorcCom.Text = "0,00";
                    cbComprobante.DataSource = null;
                    dgvDatos.Rows.Clear();
                    //Calcular();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTipoDocumento()
        {
            try
            {
                if (objECliente != null && objECliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();
                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerDeCliente(objECliente.Codigo, objETipoDocumentoCliente);

                    if (objETipoDocumentoCliente != null)
                    {
                        lblTipoComprobanteCliente.Text = objETipoDocumentoCliente.Descripcion;
                        //  lblNumero.Text = objETipoDocumentoCliente.Numerador.Valor;
                    }
                    else
                    {
                        lblTipoComprobanteCliente.Text = "";
                        // lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteCliente.Text = "";
                    // lblNumero.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerComprobantes()
        {
            try
            {

                Utilidades.Combo.Llenar(cbComprobante, objLRemitoCliente.ObtenerTodosSinLiquidar(objECliente), "Codigo", "NumRemito2");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }
            objETipoDocumentoCliente.Electronico = false;
            objETipoDocumentoCliente.TipoDoc.Codigo = "LQ";
            objETipoDocumentoCliente.AfectaStock = "NA";
            FormasDePago();
        }


        private void FormasDePago()
        {
            objETipoDocumentoCliente.AfectaCaja = 'N';
            objETipoDocumentoCliente.AfectaCtaCte = 'D';

        }



        private void cbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComprobante.SelectedIndex != -1)
            {
                try
                {
                    objERemitoCliente = objLRemitoCliente.ObtenerUnoParaLiquidar(Convert.ToInt32(cbComprobante.SelectedValue));
                    //objEFacturaOriginal = objLFactura.ObtenerUnaAjuste(Convert.ToInt32(cbComprobante.SelectedValue));


                    CargarRemitoSeleccionado();
                    Calcular();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarRemitoSeleccionado()
        {
            dgvDatos.Rows.Clear();

            int i = 0;
            foreach (Entidades.RemitoCliente_D_Producto r in objERemitoCliente.Productos)
            {
                dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.Movstock_Lotes.Cantidad, r.Movstock_Lotes.IdLote.IdLote, r.CantidadLiquidadas, "", "", "", "", r.Producto.PorcentajeIVA);//, r.PrecioUnitario, r.PrecioUnitarioConDescuento,"",0, "",r.PorIva);
                if (r.Movstock_Lotes.Cantidad - r.CantidadLiquidadas == 0) { 
                    dgvDatos.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dgvDatos.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                i++;
            }

        }


        private void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!txtCodigoVendedor.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoVendedor.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreVendedor.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                    }
                    else
                    {
                        lblNombreVendedor.Text = "";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreVendedor.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
            }
        }


        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDatos.CurrentCell.ColumnIndex == 8)
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            else
                Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
          //  Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private double Neto()
        {
            double neto = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (!dgr.Cells["Total"].Value.Equals(""))
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }
           
            neto += txtRedondeo.Text.Trim().Equals("")?0:Convert.ToDouble(txtRedondeo.Text.Trim());

            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double SubTotal()
        {
            return Utilidades.Redondear.DosDecimales(Neto()-Comision());
        }

        private double SubTotal1()
        {
            return Utilidades.Redondear.DosDecimales(SubTotal() + Ivas());
        }

        private double Total1() {
            //Falta restarle los impuestos
            return SubTotal1() ; ;
        }
        private double Neto(double valor)
        {
            double neto = 0;
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (dgr.Cells["Total"].Value!=null && !dgr.Cells["Total"].Value.Equals("") && Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value)* (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
                    }
                }
                if(valor==10.5)
                 neto += (txtRedondeo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRedondeo.Text.Trim())* (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100));
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Ivas()
        {
            double iva = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if(dgr.Cells["Iva"].Value!=null && !dgr.Cells["Iva"].Value.Equals(""))
                 iva += Convert.ToDouble(dgr.Cells["Iva"].Value);
            }
            iva += txtRedondeo.Text.Trim().Equals("") ? 0 : (Convert.ToDouble(txtRedondeo.Text.Trim()) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim()) / 100))*0.105);
              
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double Ivas(double valor)
        {
            double iva = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (dgr.Cells["Iva"].Value!=null && !dgr.Cells["Iva"].Value.Equals("") && Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                {
                    iva += Convert.ToDouble(dgr.Cells["Iva"].Value);
                }
            }
            if (valor == 10.5)
                iva += (txtRedondeo.Text.Trim().Equals("") ? 0 : (Convert.ToDouble(txtRedondeo.Text.Trim()) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100))*0.105);

            return Utilidades.Redondear.DosDecimales(iva);
        }







        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    Comprobante();
                    Asiento();
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objEFactura.Codigo = objLFactura.AgregarLiquidacion(objEFactura, objEAsiento);

                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar() {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            txtPorcCom.Text = "0,00";
            cbMermas.Checked = false;
            ucNumeroComprobante1.Limpiar();
            Calcular();
        }

        private void Comprobante()
        {

            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            //objEFactura.Letra = Convert.ToChar(ucNumeroComprobante1.txtLetra.Text.Trim());
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = Convert.ToInt32(objETipoDocumentoCliente.Numerador.PuntoVenta);
            //objEFactura.Numero = Convert.ToInt32(ucNumeroComprobante1.txtNumero.Text.Trim());
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = dtFecha.Value;
            objEFactura.Cliente = objECliente;
            objEFactura.Vendedor = objEEmpleado;
            if (txtPorcCom.Text.Trim().Equals("")) {
                objEFactura.PorcentajeComision = Convert.ToDouble(0);
            }
            else { 
            objEFactura.PorcentajeComision = Convert.ToDouble(txtPorcCom.Text.Trim());
            }
            if (objETipoDocumentoCliente.AfectaIVA.Equals('N'))
            {
                objEFactura.Neto105 = Neto();
            }
            else
            {
                objEFactura.Neto105 = Neto(10.5);// + Redondeo();
                objEFactura.Neto21 = Neto(21);
                objEFactura.Iva105 = Ivas(10.5);
                objEFactura.Iva21 = Ivas(21);
            }
            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;
            objEFactura.Imputacion = 'F';
            objEFactura.Comision = Convert.ToDouble(Comision());
            
            objEFactura.Redondeo = Redondeo();
            int renglon = 1;
            int renglon2 = 1;
            objEFactura.Detalles.Clear();
            objEFactura.Mermas.Clear();
            int cantidad = 0;
            int cantidadLiq = 0;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                cantidadLiq+= Convert.ToInt32(fila.Cells["CantidadLiq"].Value);

                if (!fila.Cells["Total"].Value.Equals(""))
                {
                    objEFacturaDetalle = new Entidades.Factura_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                    cantidadLiq += objEFacturaDetalle.MovStock_Lotes.Cantidad;
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                    
                    objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonRemito"].Value);
                    objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                   /* if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('L'))
                    {
                        objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioUnitario"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                        objEFacturaDetalle.Iva = 0;
                    }
                    else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                    {*/
                        objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioUnitario"].Value) * (1- (Convert.ToDouble(txtPorcCom.Text.Trim()) / 100)));
                    //(Convert.ToDouble(txtPorcCom.Text.Trim()) / 100)
                        objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva"].Value);
                    //}
                    //objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                    renglon += 1;
                    objEFactura.Detalles.Add(objEFacturaDetalle);
                }
                
                if (fila.Cells["Merma"].Value !=null && !fila.Cells["Merma"].Value.Equals(""))
                {
                    objEFacturaMerma = new Entidades.Factura_Merma();
                    objEFacturaMerma.Renglon = renglon2;
                    objEFacturaMerma.Merma = Convert.ToInt32(fila.Cells["Merma"].Value);
                    cantidadLiq += objEFacturaMerma.Merma;
                    objEFacturaMerma.CodigoRemito = Convert.ToInt32(cbComprobante.SelectedValue);
                    objEFacturaMerma.RenglonRemito = Convert.ToInt32(fila.Cells["RenglonRemito"].Value);
                    renglon2 += 1;
                    objEFactura.Mermas.Add(objEFacturaMerma);
                }
            }

            if (cantidad > cantidadLiq)
            {
                objEFactura.Liquidacion = 'P';
            }
            else {
                objEFactura.Liquidacion = 'T';
            }
            //Aca agregar los impuestos


        }

        private void Calcular()
        {
            lblTotalVentaNeta.Text = Neto().ToString("C2");
            lblComisiones.Text = Comision().ToString("C2");
            lblSubTotal.Text = SubTotal().ToString("C2");
            lblIVA.Text = Ivas().ToString("C2");



            lblSubTotal1.Text = SubTotal1().ToString("C2");
            lblTotal.Text = Total1().ToString("C2");
            
            //  lblTotal.Text = (Neto() + IVA()).ToString("C2");
        }

        private void Asiento() {
            
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Descripcion = objETipoDocumentoCliente.Descripcion + " N°: " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = new Logica.FormaDePago().ObtenerUno(2).CuentaContable;
                 asientoDetalle.Debe = Total1();//Neto() + Ivas()-Comision();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);



            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableVentaSucursal;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = SubTotal();
            objEAsiento.Detalle.Add(asientoDetalle);

            if (Ivas() != 0){ 
            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = Ivas();
            objEAsiento.Detalle.Add(asientoDetalle);
            }
            //
        }
        
    
        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreVendedor))
            {
                MessageBox.Show("Seleccione un Vendedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoVendedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteCliente))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }
           /* if (Utilidades.Validar.GrillaVacia(dgvDatos) && dgvDatos.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }*/

                double total = Neto() + Ivas();
                if (total == 0)
                {
                    MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
/*
            if (NumeroDocumentoBlanco(ucNumeroComprobante1)) {
                MessageBox.Show("Falta ingresar Número de comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }*/
            return false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
           txtCodigoVendedor.Focus();
        }

    



        private void txtRetencionDeImp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtPerspDGR_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtFletes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtDescarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRetRG3452_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtIVACom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtServFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtServDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRetRG2784_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtPorcCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRedondeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value) - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadLiq"].Value);
            double precioUnitario = 0;
            double porcIva= Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIva"].Value);
            int merma = 0;
            if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value!=null && !dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value.Equals(""))
            {
                merma = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value);
            }
             
            if (dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.Equals("")) {
                precioUnitario = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
            }
            int cantALiq = 0;
            if (dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value.Equals(""))
            {
                cantALiq = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value);
            }

            if (e.ColumnIndex == 6)
            {
                if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value != null && Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value) == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value = "";
                }
                if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value.Equals(""))
                {
                    if (cantidad - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value) - cantALiq < 0)
                    {

                        MessageBox.Show("Cantidad de Merma incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value = "";
                    }
                }


            }
            else if (e.ColumnIndex == 7)
            {
                if (cantALiq == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else {
                    if (precioUnitario != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value)*(1-(txtPorcCom.Text.Trim().Equals("")?0:Convert.ToDouble(txtPorcCom.Text.Trim()))/100) * (porcIva / 100);
                    }
                    else { 
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                    if (cantidad - merma - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) < 0)
                    {
                        int pendientes = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value) - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadLiq"].Value);
                        MessageBox.Show("Cantidad a Liquidar incorrecta!!\nCantidad pendiente: " +pendientes, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }

                }

            }
            else if (e.ColumnIndex == 8)
            {
                if (precioUnitario == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else {
                    if (cantALiq != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (porcIva / 100);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100);
                    }
                    else {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                }
            }

      
            Calcular();
        }

        private void txtRedondeo_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

      

        private void txtPorcCom_TextChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgv in dgvDatos.Rows) {
                double porcIva = Convert.ToDouble(dgv.Cells["PorcIva"].Value);
                if(!dgv.Cells["Total"].Value.Equals(""))
                dgv.Cells["Iva"].Value=Convert.ToDouble(dgv.Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100);
                //   dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100);
            }
            Calcular();
        }

        private double Comision() {
            double comision;
            if (!txtPorcCom.Text.Trim().Equals(""))
            {
                comision = Neto() * (Convert.ToDouble(txtPorcCom.Text.Trim()) / 100);
            }
            else
            {
                comision = 0;
            }
            return Utilidades.Redondear.DosDecimales(comision);
        }

        private double Redondeo() {
            return txtRedondeo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRedondeo.Text.Trim());
        }

        private void lblNombreVendedor_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbMermas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMermas.Checked)
            {
                dgvDatos.Columns["Merma"].ReadOnly = false;
            }
            else {
                dgvDatos.Columns["Merma"].ReadOnly = true;
            }
        }


    }
}
