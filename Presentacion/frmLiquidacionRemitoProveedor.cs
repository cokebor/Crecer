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
    public partial class frmLiquidacionRemitoProveedor : Presentacion.frmColor
    {
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Logica.RemitoProveedor objLRemitoProveedor = new Logica.RemitoProveedor();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        Logica.Merma objLMerma = new Logica.Merma();

        Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();
        Entidades.FacturaCompra_Detalle objEFacturaDetalle = new Entidades.FacturaCompra_Detalle();
        Entidades.FacturaCompra_Merma objEFacturaMerma = new Entidades.FacturaCompra_Merma();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
        Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.RemitoProveedor_M objERemitoProveedor = new Entidades.RemitoProveedor_M();
        
        public frmLiquidacionRemitoProveedor()
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
            this.Text = "LIQUIDACION DE REMITOS DE PROVEEDORES";
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
            dgvDatos.Columns["CantRemitida"].Width = 83;
            dgvDatos.Columns["CantVendida"].Width = 81;
            dgvDatos.Columns["CantidadLiq"].Width = 75;
            dgvDatos.Columns["Merma"].Width = 50;
            dgvDatos.Columns["CantidadALiq"].Width = 85;
            dgvDatos.Columns["PrecioUnitario"].Width = 80;
            dgvDatos.Columns["Total"].Width = 85;
            //dgvDatos.Columns["Total"].Width = 102;

            //dgvDatos.Columns["Merma"].ReadOnly = false;
            dgvDatos.Columns["CantidadALiq"].ReadOnly = false;
            dgvDatos.Columns["PrecioUnitario"].ReadOnly = false;
           // dgvDatos.Columns["Descripción"].ReadOnly = false;
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
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
            AccesosRapidos(e, sender);
        }

        private void AccesosRapidos(KeyEventArgs e, object sender)
        {
            
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("LiquidacionRemitoProveedor", this, (TextBox)sender));
                    break;
               /* case (char)Keys.F4:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("LiquidacionRemitoProveedor", this));
                    break;*/
            }
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEProveedor = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    dgvDatos.Rows.Clear();
                       
                    if (objEProveedor != null)
                    {
                        lblNombreProveedor.Text = objEProveedor.Nombre;
                        txtPorcCom.Text = objEProveedor.Comision.ToString("0.00");
                        
                        ObtenerTipoDocumento();
                        ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreProveedor.Text = "";
                        lblTipoComprobanteProveedor.Text = "";
                        lblNumero.Text = "";
                        txtPorcCom.Text = "0.00";
                        cbComprobante.DataSource = null;
                        dgvDatos.Rows.Clear();
                    }
                }
                else
                {
                    objEProveedor = null;
                    lblNombreProveedor.Text = "";
                    lblTipoComprobanteProveedor.Text = "";
                    lblNumero.Text = "";
                    cbComprobante.DataSource = null;
                    txtPorcCom.Text = "0.00";
                    dgvDatos.Rows.Clear();
                    

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
                if (objEProveedor != null && objEProveedor.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();
                    objETipoDocumentoProveedor = objLTipoDocumentoProveedor.ObtenerDeProveedorLiquidaciones(objEProveedor.TipoInscripcion.Codigo, objETipoDocumentoProveedor);

                    if (objETipoDocumentoProveedor != null)
                    {
                        lblTipoComprobanteProveedor.Text = objETipoDocumentoProveedor.Descripcion;
                        lblNumero.Text = objETipoDocumentoProveedor.Numerador.Valor;

                    }
                    else
                    {
                        lblTipoComprobanteProveedor.Text = "";
                        lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteProveedor.Text = "";
                    lblNumero.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerValores()
        {
            if (objETipoDocumentoProveedor == null)
            {
                objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
            }
            objETipoDocumentoProveedor.TipoDoc.Codigo = "LQ";
            FormasDePago();
        }


        private void FormasDePago()
        {
            objETipoDocumentoProveedor.AfectaCaja = 'N';
            if (cbContado.Checked)
                objETipoDocumentoProveedor.AfectaCtaCte = 'N';
            else
                objETipoDocumentoProveedor.AfectaCtaCte = 'D';

        }

        
        private void ObtenerComprobantes()
        {
            try
            {

                Utilidades.Combo.Llenar(cbComprobante, objLRemitoProveedor.ObtenerTodosSinLiquidar(objEProveedor), "Codigo", "Dato");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        




        private void cbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComprobante.SelectedIndex != -1)
            {
                try
                {
                    objERemitoProveedor = objLRemitoProveedor.ObtenerUnoParaLiquidar(Convert.ToInt32(cbComprobante.SelectedValue), Singleton.Instancia.Empresa);
                   


                    CargarRemitoSeleccionado();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Calcular();
        }
        
        private void CargarRemitoSeleccionado()
        {
            dgvDatos.Rows.Clear();

           // double precioPromedio = 0;
            foreach (Entidades.RemitoProveedor_A_Liquidar r in objERemitoProveedor.Liquidar)
            {
                /*if (r.CantidadVendida > 0)
                {
                    precioPromedio = Utilidades.Redondear.CuatroDecimales(r.ImporteTotal/((double)r.CantidadVendida));
                }
                else {
                    precioPromedio = 0;
                }*/
                dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.CantidadRemitida, r.CantidadVendida, r.CantidadLiquidada, r.CantidadMerma,""/* r.MovStock_Lotes.Cantidad-r.CantidadLiquidada*/,"","", r.Producto.PorcentajeIVA);
            }

        }
        



        private void txtCodigoVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
        
        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;

            if (validar != null)
            {
                DataGridViewCell celda = dgvDatos.CurrentCell;
                if (celda.ColumnIndex != 1)
                {
                    validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
                }
                
               // validar.KeyDown += new KeyEventHandler(this.dgvDatos_KeyDown);
                //dgvDatos_KeyDown
            }
        }

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDatos.CurrentCell.ColumnIndex == 10) { 
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacionCuatroDecimales(sender, e);
            }
            else {
                Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            }
            //Utilidades.ControlesGenerales.CambiarFoco(e);

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
                    neto += Convert.ToDouble(dgr.Cells["Total"].Value);//* (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
                    }
                }
            if (valor == 10.5)
                neto += (txtRedondeo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRedondeo.Text.Trim()));//* (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100));
            return Utilidades.Redondear.DosDecimales(neto);
        }
        
        private double Ivas()
        {
            double iva = 0;
            if (objETipoDocumentoProveedor.TipoDiscIVA.Equals('P')) { 
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if(dgr.Cells["Iva"].Value!=null && !dgr.Cells["Iva"].Value.Equals(""))
                 iva += Convert.ToDouble(dgr.Cells["Iva"].Value);
            }
            iva += txtRedondeo.Text.Trim().Equals("") ? 0 : (Convert.ToDouble(txtRedondeo.Text.Trim()) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim()) / 100))*0.105);
            }
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
                    if (MessageBox.Show("¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Informe(objEFactura.Codigo);
                    }
                    
                
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
            
            Calcular();
        }


        private void Informe(int pCodigo)
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
                //   Utilidades.Impresion cii = new Utilidades.Impresion();
                // cii.ImprimirReporteConDataSources("repLiquidacionProveedor.rdlc", lista);
                //  cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista);




                //  cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista);
                //cii.Imprimir(informe.reportViewer1.LocalReport);
                /* informe.reportViewer1.RefreshReport();
                 cii.Imprimir(informe.reportViewer1.LocalReport);*/



                // cii.ImprimirReporteConDataSources("repLiquidacionProveedor.rdlc", lista);


                //Este es el valido
                /*
                Utilidades.Impresion cii = new Utilidades.Impresion();
                cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista);
                // Utilidades.Impresion cii2 = new Utilidades.Impresion();
                cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor2.rdlc", lista);
                cii = null;
                */
                
                if (Singleton.Instancia.Empresa.Fiscal)
                {

                    Utilidades.Impresion cii = new Utilidades.Impresion();
                   
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor.rdlc", lista, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                   
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor2.rdlc", lista, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                    //Utilidades.ControladorImpresion ci = new Utilidades.ControladorImpresion();
                    //ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
                else {
                    Utilidades.Formularios.AbrirFuera(informe);
                }
            }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Comprobante()
        {

            objEFactura = new Entidades.FacturaCompra();
            objEFactura.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
            objEFactura.TipoDocumentoProveedor = objETipoDocumentoProveedor;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoProveedor.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoProveedor.Numerador.PuntoVenta;
            objEFactura.Numero = objETipoDocumentoProveedor.Numerador.Numero;
            // objEFactura.Numero = objETipoDocumentoProveedor.Numerador.ValorSinGuion;
            objEFactura.Proveedor.Codigo = Convert.ToInt32(objEProveedor.Codigo);
            objEFactura.FechaEmision = dtFecha.Value;
            objEFactura.FechaContable = dtFecha.Value;
            objEFactura.TipoCompra = "BU";
            if (objETipoDocumentoProveedor.TipoDiscIVA.Equals('P'))
            {
                if (Neto(10.5) != 0)
                {
                    objEFactura.Neto1 = Neto(10.5);
                    objEFactura.DescripImp1 = Convert.ToDouble(10.5);
                    objEFactura.ImporteImp1 = Convert.ToDouble(Ivas(10.5));
                    if (Neto(21) != 0)
                    {
                        objEFactura.Neto2 = Neto(21);
                        objEFactura.DescripImp2 = Convert.ToDouble(21);
                        objEFactura.ImporteImp2 = Convert.ToDouble(Ivas(21));
                    }
                }
                else if (Neto(21) != 0)
                {
                    objEFactura.Neto1 = Neto(21);
                    objEFactura.DescripImp1 = Convert.ToDouble(21);
                    objEFactura.ImporteImp1 = Convert.ToDouble(Ivas(21));
                }
            }
            else if (objETipoDocumentoProveedor.TipoDiscIVA.Equals('L'))
            {
                if (Neto(10.5) != 0)
                {
                    objEFactura.Neto1 = Neto(10.5);
                    /*objEFactura.DescripImp1 = Convert.ToDouble(10.5);
                    objEFactura.ImporteImp1 = Convert.ToDouble(Ivas(10.5));*/
                    if (Neto(21) != 0)
                    {
                        objEFactura.Neto2 = Neto(21);
                        /* objEFactura.DescripImp2 = Convert.ToDouble(21);
                         objEFactura.ImporteImp2 = Convert.ToDouble(Ivas(21));*/
                    }
                }
                else if (Neto(21) != 0)
                {
                    objEFactura.Neto1 = Neto(21);
                    /*objEFactura.DescripImp1 = Convert.ToDouble(21);
                    objEFactura.ImporteImp1 = Convert.ToDouble(Ivas(21));*/
                }
            }
            else {
                objEFactura.Neto1 = Neto();
                objEFactura.DescripImp1 = Convert.ToDouble(0);
                objEFactura.ImporteImp1 = Convert.ToDouble(0);
            }
            objEFactura.NoGravado = 0;
            objEFactura.Exento = 0;
            

            
            objEFactura.Comision= Convert.ToDouble(Comision());
            objEFactura.Redondeo = Redondeo();
            objEFactura.Usuario = Singleton.Instancia.Usuario;
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Imputacion = 'F';
            
            

             
             int renglon = 1;
             int renglon2 = 1;
             objEFactura.Detalle.Clear();
             objEFactura.Mermas.Clear();
             int cantidad = 0;
             int cantidadLiq = 0;
             foreach (DataGridViewRow fila in dgvDatos.Rows)
             {
                 cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                 cantidadLiq+= Convert.ToInt32(fila.Cells["CantidadLiq"].Value);

                 if (!fila.Cells["Total"].Value.Equals(""))
                 {
                     objEFacturaDetalle = new Entidades.FacturaCompra_Detalle();
                     objEFacturaDetalle.Renglon = renglon;
                     objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                     objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                     objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                     cantidadLiq += objEFacturaDetalle.MovStock_Lotes.Cantidad;
                     objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                     objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonRemito"].Value);
                     objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                    /* if (objEFactura.TipoDocumentoC.TipoDiscIVA.Equals('L'))
                     {
                         objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioUnitario"].Value) * (1 + (objEFacturaDetalle.PorIva / 100)));
                         objEFacturaDetalle.Iva = 0;
                     }
                     else if (objEFactura.TipoDocumentoCliente.TipoDiscIVA.Equals('P'))
                     {*/
                         objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioUnitario"].Value));
                         objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva"].Value);
                    // }
                     //objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);
                     renglon += 1;
                     objEFactura.Detalle.Add(objEFacturaDetalle);
                 }
                 
                 if (!fila.Cells["Merma"].Value.Equals("") && Convert.ToInt32(fila.Cells["Merma"].Value)!=0)
                 {
                     objEFacturaMerma = new Entidades.FacturaCompra_Merma();
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
            
          
        }
        
        
        private void Asiento() {
            
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.FechaContable;
            objEAsiento.FechaEmision = objEFactura.FechaContable;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = objETipoDocumentoProveedor.Descripcion + " N°: " + objEFactura.Numero;
            Entidades.Asiento_Detalle asientoDetalle;

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 50101020000;
                asientoDetalle.Debe = Neto();//Neto() + Ivas()-Comision();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);

            if (objETipoDocumentoProveedor.TipoDiscIVA.Equals('P')) { 
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105010000;
                asientoDetalle.Debe = Ivas();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 20101020000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Total1();
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 40102010000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Comision();
                objEAsiento.Detalle.Add(asientoDetalle);
            //
        }
        
    
        private bool Validar()
        {
            
            if (Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteProveedor))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }

            DateTime fechaUltimaLiquidacion = objLFactura.ObtenerFechaUltimaLiquidacion(objETipoDocumentoProveedor.Numerador.Letra);

            if (dtFecha.Value.Date < fechaUltimaLiquidacion)
            {
                MessageBox.Show("Error en la Fecha.\nContiene Liquidaciones con Fecha Posterior ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            double total = Neto() + Ivas();
                if (total == 0)
                {
                    MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

            return false;
            
        }
        /*
        public static bool NumeroDocumentoBlanco(ucNumeroComprobante txt)
        {
            bool res = false;
            if (txt.txtLetra.Text.Trim().Equals("") || txt.txtPuntoVenta.Text.Trim().Equals("") || txt.txtNumero.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }*/

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoProveedor.Focus();
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
            
            if (e.ColumnIndex == 8)
            {
                if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value != null && Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value) == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value = 0;// "";
                }
                if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value.Equals(""))
                {
                    if (cantidad - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value) - cantALiq < 0)
                    {

                        MessageBox.Show("Cantidad de Merma incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value = 0;// "";
                    }
                }


            }
            else if (e.ColumnIndex == 9)
            {
                if (cantALiq == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else {
                    if (precioUnitario != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value)*(1-(txtPorcCom.Text.Trim().Equals("")?0:Convert.ToDouble(txtPorcCom.Text.Trim()))/100) * (porcIva / 100));
                    }
                    else {
                        //dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                    if (dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value.Equals(""))
                    {
                        if (cantidad - merma  < 0)
                        {

                            MessageBox.Show("Cantidad a Liquidar incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                        }
                    }
                    else {
                        if (cantidad - merma - Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) < 0)
                        {

                            MessageBox.Show("Cantidad a Liquidar incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                        }
                    }


                }

            }
            else if (e.ColumnIndex == 10)
            {
                if (precioUnitario == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else {
                    if (cantALiq != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (porcIva / 100);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                    }
                    else {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                }
            }

      
            Calcular();
            
             //   Utilidades.ControlesGenerales.CambiarFoco(e);
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
                dgv.Cells["Iva"].Value=Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgv.Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                //   dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100);
            }
            Calcular();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                DataGridViewCell celda = dgvDatos.CurrentCell;
                if (celda.ColumnIndex == 14) {
                    DataGridViewRow fila = dgvDatos.CurrentRow;
                    //int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value) - Convert.ToInt32(fila.Cells["CantidadLiq"].Value);


                    fila.Cells["PrecioUnitario"].Value = Utilidades.Redondear.DosDecimales(objLRemitoProveedor.ObtenerPromedio(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value), dtFecha.Value, Singleton.Instancia.Empresa));
                   // fila.Cells["PrecioUnitario"].Value = Utilidades.Redondear.CuatroDecimales(objLRemitoProveedor.ObtenerPromedio(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value), Singleton.Instancia.Empresa));
                    fila.Cells["Merma"].Value = objLMerma.ObtenerMermasALiquidar(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value),dtFecha.Value ,Singleton.Instancia.Empresa);
                    fila.Cells["CantidadALiq"].Value= /*Convert.ToInt32(fila.Cells["Merma"].Value) +*/ objLRemitoProveedor.ObtenerCantidadALiquidar(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value),dtFecha.Value ,Singleton.Instancia.Empresa);
                    
                    if (Convert.ToInt32(fila.Cells["CantidadALiq"].Value) == 0) {
                        fila.Cells["CantidadALiq"].Value = "";
                      //  fila.Cells["PrecioUnitario"].Value = "";
                    }
                    double porcIva = Convert.ToDouble(fila.Cells["PorcIva"].Value);
                    //cantALiq = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                    if (Convert.ToInt32(fila.Cells["PrecioUnitario"].Value) == 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }else { 
                    fila.Cells["Total"].Value = Convert.ToInt32(fila.Cells["CantidadALiq"].Value) * Convert.ToDouble(fila.Cells["PrecioUnitario"].Value);
                   
                    fila.Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                    }
                    Calcular();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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



        private void dgvDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
          /*  e.SuppressKeyPress = true;
            int numColumn = dgvDatos.CurrentCell.ColumnIndex;
            int numRow = dgvDatos.CurrentCell.RowIndex;
            if (numColumn == dgvDatos.ColumnCount - 1)
            {
                if (dgvDatos.RowCount > (numRow + 1))
                {
                    dgvDatos.CurrentCell = dgvDatos[1, numRow + 1];
                }
            }
            else
                dgvDatos.CurrentCell = dgvDatos[numColumn + 1, numRow];*/
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbContado_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }
        /*
private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
{
if (e.KeyData == Keys.Enter) {
int col = dgvDatos.CurrentCell.ColumnIndex;
int row = dgvDatos.CurrentCell.RowIndex;
if (col < dgvDatos.ColumnCount - 1)
{
col++;
}
else {
col = 0;
row++;
}
if (row == dgvDatos.RowCount)
dgvDatos.Rows.Add();

dgvDatos.CurrentCell = dgvDatos[col, row];
e.Handled = true;
}
}*/
    }
}
