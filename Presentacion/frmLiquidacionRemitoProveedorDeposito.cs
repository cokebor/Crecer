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
    public partial class frmLiquidacionRemitoProveedorDeposito : Presentacion.frmColor
    {
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Logica.RemitoProveedor objLRemitoProveedor = new Logica.RemitoProveedor();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();
        Logica.Merma objLMerma = new Logica.Merma();

        Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();
        Entidades.FacturaCompra objEFactura2 = new Entidades.FacturaCompra();
        Entidades.FacturaCompra objEFactura3 = new Entidades.FacturaCompra();
        Entidades.FacturaCompra_Detalle objEFacturaDetalle = new Entidades.FacturaCompra_Detalle();
        Entidades.FacturaCompra_Detalle objEFacturaDetalle2 = new Entidades.FacturaCompra_Detalle();
        Entidades.FacturaCompra_Detalle objEFacturaDetalle3 = new Entidades.FacturaCompra_Detalle();
        Entidades.FacturaCompra_Merma objEFacturaMerma = new Entidades.FacturaCompra_Merma();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.Asiento objEAsiento2 = new Entidades.Asiento();
        Entidades.Asiento objEAsiento3 = new Entidades.Asiento();

        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
        Entidades.Proveedor objEProveedor2 = new Entidades.Proveedor();
        Entidades.Proveedor objEProveedor3 = new Entidades.Proveedor();
        Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.RemitoProveedor_M objERemitoProveedor = new Entidades.RemitoProveedor_M();

        public frmLiquidacionRemitoProveedorDeposito()
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
            lblFlete.Text = Convert.ToDouble("0").ToString("C2");
            lblComisiones2.Text = Convert.ToDouble("0").ToString("C2");
            lblOtros.Text = Convert.ToDouble("0").ToString("C2");
            lblSubTotal1.Text = Convert.ToDouble("0").ToString("C2");
            lblSubTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblIVA.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Codigo"].Width = 55;
            dgvDatos.Columns["Descripción"].Width = 160;
            dgvDatos.Columns["Cantidad"].Width = 85;
            dgvDatos.Columns["Lote"].Width = 70;
            dgvDatos.Columns["CantRemitida"].Width = 85;
            dgvDatos.Columns["CantVendida"].Width = 85;
            // dgvDatos.Columns["Cordoba"].Width = 67;
            // dgvDatos.Columns["VillaMaria"].Width = 67;
            // dgvDatos.Columns["RioCuarto"].Width = 67;
            dgvDatos.Columns["CantidadLiq"].Width = 85;
            dgvDatos.Columns["Merma"].Width = 70;
            dgvDatos.Columns["CantidadALiq"].Width = 85;
            dgvDatos.Columns["PrecioUnitario"].Width = 85;
            dgvDatos.Columns["Total"].Width = 85;
            //dgvDatos.Columns["Total"].Width = 102;

            // dgvDatos.Columns["Merma"].ReadOnly = false;
            dgvDatos.Columns["CantidadALiq"].ReadOnly = false;
            //   dgvDatos.Columns["Cordoba"].ReadOnly = false;
            //   dgvDatos.Columns["VillaMaria"].ReadOnly = false;
            //   dgvDatos.Columns["RioCuarto"].ReadOnly = false;
            dgvDatos.Columns["PrecioUnitario"].ReadOnly = false;
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetencionDeImp, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPerspDGR, 10);
            //Utilidades.CajaDeTexto.LimiteTamaño(txtFletes, 10);
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("LiquidacionRemitoProveedorDeposito", this, (TextBox)sender));
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
            if(cbContado.Checked)
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
                dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.CantidadRemitida, r.CantidadVendida/*,r.CantidadVendidaCba,r.CantidadVendidaVM, r.CantidadVendidaRC,*/, r.CantidadLiquidada, r.CantidadMerma, ""/* r.MovStock_Lotes.Cantidad-r.CantidadLiquidada*/, "", "", r.Producto.PorcentajeIVA);
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
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
                // validar.KeyDown += new KeyEventHandler(this.dgvDatos_KeyDown);
                //dgvDatos_KeyDown
            }
        }


        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {

            //|| dgvDatos.CurrentCell.ColumnIndex
            if (dgvDatos.Columns[dgvDatos.CurrentCell.ColumnIndex].Name.Equals("PrecioUnitario") || dgvDatos.Columns[dgvDatos.CurrentCell.ColumnIndex].Name.Equals("Proveedor2") || dgvDatos.Columns[dgvDatos.CurrentCell.ColumnIndex].Name.Equals("Proveedor3"))
            //if ( dgvDatos.CurrentCell.ColumnIndex==18 || dgvDatos.CurrentCell.ColumnIndex==19)
            {
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacionCuatroDecimales(sender, e);
            }
            else
            {
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

            neto += txtRedondeo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRedondeo.Text.Trim());

            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Fletes()
        {
            double flete = 0;

            bool a = false, b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }
                else if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }


            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (a == true && panel1.Visible == true && rbFlete2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    flete += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
                if (b == true && panel2.Visible == true && rbFlete3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    flete += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(flete);
        }


        private double RetencionesIIBB() {
            return Utilidades.CajaDeTexto.ObtenerImporte(txtPerspDGR);
        }

        private double Fletes2()
        {
            double flete = 0;

            bool a = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }
            }


            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (a == true && panel1.Visible == true && rbFlete2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    flete += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(flete);
        }

        private double Fletes3()
        {
            double flete = 0;

            bool b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (b == true && panel2.Visible == true && rbFlete3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    flete += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(flete);
        }

        private double Comisiones()
        {
            double comision = 0;

            bool a = false, b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }
                else if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }

            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }



                if (a == true && panel1.Visible == true && rbComision2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    comision += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
                if (b == true && panel2.Visible == true && rbComision3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    comision += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(comision);
        }

        private double Comisiones2()
        {
            double comision = 0;
            bool a = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }
            }
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (a == true && panel1.Visible == true && rbComision2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    comision += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(comision);
        }

        private double Comisiones3()
        {
            double comision = 0;

            bool b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (b == true && panel2.Visible == true && rbComision3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    comision += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(comision);
        }
        private double Otros()
        {
            double otr = 0;
            bool a = false, b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }
                else if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (a == true && panel1.Visible == true && rbOtros2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    otr += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
                if (b == true && panel2.Visible == true && rbOtros3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    otr += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(otr);
        }

        private double Otros2()
        {
            double otr = 0;
            bool a = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor2"))
                {
                    a = true;
                }

            }
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (a == true && panel1.Visible == true && rbOtros2.Checked && dgr.Cells["Proveedor2"].Value != null && !dgr.Cells["Proveedor2"].Value.Equals(""))
                    otr += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor2"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(otr);
        }
        private double Otros3()
        {
            double otr = 0;
            bool b = false;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Proveedor3"))
                {
                    b = true;
                }
            }
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                int cantALiq = 0;
                if (dgr.Cells["CantidadALiq"].Value != null && !dgr.Cells["CantidadALiq"].Value.Equals(""))
                {
                    cantALiq = Convert.ToInt32(dgr.Cells["CantidadALiq"].Value);
                }
                if (b == true && panel2.Visible == true && rbOtros3.Checked && dgr.Cells["Proveedor3"].Value != null && !dgr.Cells["Proveedor3"].Value.Equals(""))
                    otr += cantALiq * Convert.ToDouble(dgr.Cells["Proveedor3"].Value);// * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100);
            }

            return Utilidades.Redondear.DosDecimales(otr);
        }


        private double SubTotal()
        {
            return Utilidades.Redondear.DosDecimales(Neto() - Comision());
        }

        private double SubTotal1()
        {
            return Utilidades.Redondear.DosDecimales(SubTotal() + Ivas());
        }




        private double Total1()
        {
            //Falta restarle los impuestos
            return SubTotal1(); ;
        }


        private double Neto(double valor)
        {
            double neto = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (dgr.Cells["Total"].Value != null && !dgr.Cells["Total"].Value.Equals("") && Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
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
            if (objETipoDocumentoProveedor!=null && objETipoDocumentoProveedor.TipoDiscIVA.Equals('P'))
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (dgr.Cells["Iva"].Value != null && !dgr.Cells["Iva"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Iva"].Value);
                }
                iva += txtRedondeo.Text.Trim().Equals("") ? 0 : (Convert.ToDouble(txtRedondeo.Text.Trim()) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim()) / 100)) * 0.105);
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double Ivas(double valor)
        {
            double iva = 0;
            foreach (DataGridViewRow dgr in dgvDatos.Rows)
            {
                if (dgr.Cells["Iva"].Value != null && !dgr.Cells["Iva"].Value.Equals("") && Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                {
                    iva += Convert.ToDouble(dgr.Cells["Iva"].Value);
                }
            }
            if (valor == 10.5)
                iva += (txtRedondeo.Text.Trim().Equals("") ? 0 : (Convert.ToDouble(txtRedondeo.Text.Trim()) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100)) * 0.105);

            return Utilidades.Redondear.DosDecimales(iva);
        }







        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    Comprobante();
                    Comprobante2();
                    Comprobante3();
                    Asiento();
                    Asiento2();
                    Asiento3();

                    foreach (Entidades.FacturaCompra_Detalle fcd in objEFactura.Detalle)
                    {
                        int mermas = 0;
                        foreach (Entidades.FacturaCompra_Merma fcm in objEFactura.Mermas)
                        {
                            if (fcm.RenglonRemito == fcd.RenglonFactura)
                            {
                                mermas = fcm.Merma;
                            }
                        }

                        /*if (fcd.MovStock_Lotes.Cantidad - fcd.CantCba - fcd.CantVM - fcd.CantRC != 0)
                        {
                            MessageBox.Show("Ventas de Sucursales no coinciden con cantidad a Liquidar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }*/
                    }

                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    //if((objEFactura.Detalle.Count + objEFactura.Mermas.Count)>0)
                        objEFactura.Codigo = objLFactura.AgregarLiquidacionDeposito(objEFactura, objEAsiento);
                    if (Fletes2() + Comisiones2() + Otros2() > 0)
                    {
                        objLFactura.Agregar(objEFactura2, objEAsiento2);
                    }
                    if (Fletes3() + Comisiones3() + Otros3() > 0)
                    {
                        objLFactura.Agregar(objEFactura3, objEAsiento3);
                    }


                    /*
                    if (MessageBox.Show("¿Desea imprimir el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Informe(objEFactura.Codigo);
                    }
                    */

                    Limpiar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            cbProveedores2.Checked = false;
            cbProveedores3.Checked = false;
            if (dgvDatos.Columns.Contains("Proveedor3"))
                dgvDatos.Columns.Remove("Proveedor3");
            if (dgvDatos.Columns.Contains("Proveedor2"))
                dgvDatos.Columns.Remove("Proveedor2");
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
                    // Utilidades.Impresion cii2 = new Utilidades.Impresion();
                    cii.ImprimirReporteConDataSources(Application.StartupPath + "\\Reportes\\" + "repLiquidacionProveedor2.rdlc", lista, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
                else
                {
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

            



            objEFactura.Comision = Convert.ToDouble(Comision());
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
                cantidadLiq += Convert.ToInt32(fila.Cells["CantidadLiq"].Value);

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

                    objEFacturaDetalle.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["PrecioUnitario"].Value));
                    objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva"].Value);


                    renglon += 1;
                    objEFactura.Detalle.Add(objEFacturaDetalle);
                }

                if (!fila.Cells["Merma"].Value.Equals("") && Convert.ToInt32(fila.Cells["Merma"].Value) != 0)
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


            if (RetencionesIIBB() > 0) {
                Entidades.FacturaImpuesto fi = new Entidades.FacturaImpuesto();
                fi.Impuesto = new Logica.Impuesto().ObtenerUno(4);
                fi.Importe = RetencionesIIBB();
                objEFactura.Impuestos.Add(fi);
            }
                

            

            if (cantidad > cantidadLiq)
            {
                objEFactura.Liquidacion = 'P';
            }
            else
            {
                objEFactura.Liquidacion = 'T';
            }
            //Aca agregar los impuestos
        }

        private void Comprobante2()
        {
            objEFactura2 = new Entidades.FacturaCompra();
            if (cbProveedores2.Checked && lblNombreProveedor2.Text.Length > 0)
            {
                if (rbComision2.Checked)
                {
                    objEFactura2.TipoDocumentoProveedor.Codigo = 21;
                }
                else if (rbFlete2.Checked)
                {
                    objEFactura2.TipoDocumentoProveedor.Codigo = 20;
                }
                else if (rbOtros2.Checked)
                {
                    objEFactura2.TipoDocumentoProveedor.Codigo = 22;
                }

                objEFactura2.TipoDocumentoProveedor = objLTipoDocumentoProveedor.ObtenerUno(objEFactura2.TipoDocumentoProveedor.Codigo);

                objEFactura2.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;

                objEFactura2.Letra = Convert.ToChar(objEFactura2.TipoDocumentoProveedor.Numerador.Letra);
                objEFactura2.PuntoDeVenta = objEFactura2.TipoDocumentoProveedor.Numerador.PuntoVenta;
                objEFactura2.Numero = objEFactura2.TipoDocumentoProveedor.Numerador.Numero;
                // objEFactura.Numero = objETipoDocumentoProveedor.Numerador.ValorSinGuion;
                objEFactura2.Proveedor.Codigo = Convert.ToInt32(objEProveedor2.Codigo);
                objEFactura2.FechaEmision = dtFecha.Value;
                objEFactura2.FechaContable = dtFecha.Value;
                objEFactura2.TipoCompra = "BC";

                if (objEFactura2.TipoDocumentoProveedor.TipoDiscIVA.Equals('N'))
                {
                    switch (objEFactura2.TipoDocumentoProveedor.Codigo)
                    {
                        case 20:
                            objEFactura2.Neto1 = Fletes2();
                            break;
                        case 21:
                            objEFactura2.Neto1 = Comisiones2();
                            break;
                        case 22:
                            objEFactura2.Neto1 = Otros2();
                            break;
                    }
                    objEFactura2.DescripImp1 = 0;
                    objEFactura2.ImporteImp1 = 0;
                }
                objEFactura2.Remito.Codigo = Convert.ToInt32(cbComprobante.SelectedValue);
                objEFactura2.NoGravado = 0;
                objEFactura2.Exento = 0;
                objEFactura2.Detalle.Clear();
                int cantidadLiq = 0;
                int cantidad = 0;
                int renglon = 1;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    cantidadLiq += Convert.ToInt32(fila.Cells["CantidadLiq"].Value);
                    if (fila.Cells["Proveedor2"].Value != null) { 
                    if ( (!fila.Cells["Proveedor2"].Value.Equals("") && Convert.ToDouble(fila.Cells["Proveedor2"].Value) > 0))
                    {
                        objEFacturaDetalle2 = new Entidades.FacturaCompra_Detalle();
                        objEFacturaDetalle2.Renglon = renglon;
                        objEFacturaDetalle2.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                        objEFacturaDetalle2.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                        objEFacturaDetalle2.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                        objEFacturaDetalle2.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                        objEFacturaDetalle2.RenglonRemito = Convert.ToInt32(fila.Cells["RenglonRemito"].Value);

                        objEFacturaDetalle2.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["Proveedor2"].Value));
                        objEFacturaDetalle2.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);

                        objEFacturaDetalle2.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                        cantidadLiq += objEFacturaDetalle2.MovStock_Lotes.Cantidad;




                        objEFacturaDetalle2.Iva = 0; //Convert.ToDouble(fila.Cells["Iva"].Value);
                            objEFacturaDetalle2.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);

                            renglon += 1;
                        objEFactura2.Detalle.Add(objEFacturaDetalle2);
                    }
                    }
                }
                objEFactura2.Usuario = Singleton.Instancia.Usuario;
                objEFactura2.PuestoCaja = Singleton.Instancia.Puesto;

                objEFactura2.Imputacion = 'F';
                if (cantidad > cantidadLiq)
                {
                    objEFactura2.Liquidacion = 'P';
                }
                else
                {
                    objEFactura2.Liquidacion = 'T';
                }
            }
        }

        private void Comprobante3()
        {
            objEFactura3 = new Entidades.FacturaCompra();
            if (cbProveedores3.Checked && lblNombreProveedor3.Text.Length > 0)
            {
                if (rbComision3.Checked)
                {
                    objEFactura3.TipoDocumentoProveedor.Codigo = 21;
                }
                else if (rbFlete3.Checked)
                {
                    objEFactura3.TipoDocumentoProveedor.Codigo = 20;
                }
                else if (rbOtros3.Checked)
                {
                    objEFactura3.TipoDocumentoProveedor.Codigo = 22;
                }

                objEFactura3.TipoDocumentoProveedor = objLTipoDocumentoProveedor.ObtenerUno(objEFactura3.TipoDocumentoProveedor.Codigo);

                objEFactura3.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;

                objEFactura3.Letra = Convert.ToChar(objEFactura3.TipoDocumentoProveedor.Numerador.Letra);
                objEFactura3.PuntoDeVenta = objEFactura3.TipoDocumentoProveedor.Numerador.PuntoVenta;
                objEFactura3.Numero = objEFactura3.TipoDocumentoProveedor.Numerador.Numero;
                // objEFactura.Numero = objETipoDocumentoProveedor.Numerador.ValorSinGuion;
                objEFactura3.Proveedor.Codigo = Convert.ToInt32(objEProveedor3.Codigo);
                objEFactura3.FechaEmision = dtFecha.Value;
                objEFactura3.FechaContable = dtFecha.Value;
                objEFactura3.TipoCompra = "BC";
                objEFactura3.Imputacion = 'F';
                if (objEFactura3.TipoDocumentoProveedor.TipoDiscIVA.Equals('N'))
                {
                    switch (objEFactura3.TipoDocumentoProveedor.Codigo)
                    {
                        case 20:
                            objEFactura3.Neto1 = Fletes3();
                            break;
                        case 21:
                            objEFactura3.Neto1 = Comisiones3();
                            break;
                        case 22:
                            objEFactura3.Neto1 = Otros3();
                            break;
                    }
                    objEFactura3.DescripImp1 = 0;
                    objEFactura3.ImporteImp1 = 0;
                }
                objEFactura3.Remito.Codigo = Convert.ToInt32(cbComprobante.SelectedValue);
                objEFactura3.NoGravado = 0;
                objEFactura3.Exento = 0;
                objEFactura3.Detalle.Clear();
                int cantidadLiq = 0;
                int cantidad = 0;
                int renglon = 1;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    cantidadLiq += Convert.ToInt32(fila.Cells["CantidadLiq"].Value);
                    if (fila.Cells["Proveedor3"].Value != null)
                    {
                        if (!fila.Cells["Proveedor3"].Value.Equals("") && Convert.ToDouble(fila.Cells["Proveedor3"].Value) > 0)
                        {
                            objEFacturaDetalle3 = new Entidades.FacturaCompra_Detalle();
                            objEFacturaDetalle3.Renglon = renglon;
                            objEFacturaDetalle3.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                            objEFacturaDetalle3.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                            objEFacturaDetalle3.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                            //objEFacturaDetalle3.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);
                            
                            objEFacturaDetalle3.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                            objEFacturaDetalle3.RenglonRemito = Convert.ToInt32(fila.Cells["RenglonRemito"].Value);

                            objEFacturaDetalle3.PrecioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["Proveedor3"].Value));
                            objEFacturaDetalle3.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);

                            objEFacturaDetalle3.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["CantidadALiq"].Value);

                            cantidadLiq += objEFacturaDetalle3.MovStock_Lotes.Cantidad;

                            objEFacturaDetalle3.Iva = 0;// Convert.ToDouble(fila.Cells["Iva"].Value);
                           // cantidadLiq += objEFacturaDetalle3.MovStock_Lotes.Cantidad;
                            objEFacturaDetalle3.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);

                            renglon += 1;
                            objEFactura3.Detalle.Add(objEFacturaDetalle3);
                        }
                    }
                }
                objEFactura3.Usuario = Singleton.Instancia.Usuario;
                objEFactura3.PuestoCaja = Singleton.Instancia.Puesto;
                if (cantidad > cantidadLiq)
                {
                    objEFactura3.Liquidacion = 'P';
                }
                else
                {
                    objEFactura3.Liquidacion = 'T';
                }
            }
        }

        private void Calcular()
        {
            lblTotalVentaNeta.Text = Neto().ToString("C2");
            lblComisiones.Text = Comision().ToString("C2");
            lblSubTotal.Text = SubTotal().ToString("C2");
            lblIVA.Text = Ivas().ToString("C2");
            lblFlete.Text = Fletes().ToString("C2");
            lblComisiones2.Text = Comisiones().ToString("C2");
            lblOtros.Text = Otros().ToString("C2");


            lblSubTotal1.Text = SubTotal1().ToString("C2");
            lblTotal.Text = (Total1()+ RetencionesIIBB()).ToString("C2");


        }


        private void Asiento()
        {

            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.FechaContable;
            objEAsiento.FechaEmision = objEFactura.FechaContable;
            objEAsiento.Descripcion = objETipoDocumentoProveedor.Descripcion + " N°: " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 50101020000;
            asientoDetalle.Debe = Neto();//Neto() + Ivas()-Comision();
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            if (objETipoDocumentoProveedor.TipoDiscIVA.Equals('P'))
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105010000;
                asientoDetalle.Debe = Ivas();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.FacturaImpuesto impuesto in objEFactura.Impuestos)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = impuesto.Impuesto.CuentaContable;
                asientoDetalle.Debe = RetencionesIIBB();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 20101020000;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = (Total1()+ RetencionesIIBB());
            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 40102010000;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = Comision();
            objEAsiento.Detalle.Add(asientoDetalle);
            //
        }

        private void Asiento2()
        {

            if (cbProveedores2.Checked && lblNombreProveedor2.Text.Length > 0)
            {
                objEAsiento2 = new Entidades.Asiento();
                objEAsiento2.Fecha = objEFactura2.FechaContable;
                objEAsiento2.FechaEmision = objEFactura2.FechaContable;
                objEAsiento2.Descripcion = objEFactura2.TipoDocumentoProveedor.Descripcion + " N°: " + objEFactura2.Numdoc;
                objEAsiento2.Sucursal = Singleton.Instancia.Empresa.Codigo;
                Entidades.Asiento_Detalle asientoDetalle;


                asientoDetalle = new Entidades.Asiento_Detalle();

                if (rbFlete2.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102010000;
                }
                else if (rbComision2.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102370000;
                }
                else if (rbOtros2.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102380000;
                }


                asientoDetalle.Debe = objEFactura2.Neto;//Neto() + Ivas()-Comision();
                asientoDetalle.Haber = 0;
                objEAsiento2.Detalle.Add(asientoDetalle);

                if (objEFactura2.TipoDocumentoProveedor.TipoDiscIVA.Equals('P'))
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 10105010000;
                    asientoDetalle.Debe = Ivas();
                    asientoDetalle.Haber = 0;
                    objEAsiento2.Detalle.Add(asientoDetalle);
                }

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 20101010000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = objEFactura2.Neto;
                objEAsiento2.Detalle.Add(asientoDetalle);

                
            }
        }


        private void Asiento3()
        {

            if (cbProveedores3.Checked && lblNombreProveedor3.Text.Length > 0)
            {
                objEAsiento3 = new Entidades.Asiento();
                objEAsiento3.Fecha = objEFactura3.FechaContable;
                objEAsiento3.FechaEmision = objEFactura3.FechaContable;
                objEAsiento3.Descripcion = objEFactura3.TipoDocumentoProveedor.Descripcion + " N°: " + objEFactura3.Numdoc;
                objEAsiento3.Sucursal = Singleton.Instancia.Empresa.Codigo;
                Entidades.Asiento_Detalle asientoDetalle;


                asientoDetalle = new Entidades.Asiento_Detalle();

                if (rbFlete3.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102010000;
                }
                else if (rbComision3.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102370000;
                }
                else if (rbOtros3.Checked)
                {
                    asientoDetalle.CuentaContable.Codigo = 50102380000;
                }


                asientoDetalle.Debe = objEFactura3.Neto;//Neto() + Ivas()-Comision();
                asientoDetalle.Haber = 0;
                objEAsiento3.Detalle.Add(asientoDetalle);

                if (objEFactura3.TipoDocumentoProveedor.TipoDiscIVA.Equals('P'))
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 10105010000;
                    asientoDetalle.Debe = Ivas();
                    asientoDetalle.Haber = 0;
                    objEAsiento3.Detalle.Add(asientoDetalle);
                }

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 20101010000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = objEFactura3.Neto;
                objEAsiento3.Detalle.Add(asientoDetalle);


            }
        }

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteProveedor))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Cliente Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (cbProveedores2.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProveedor2))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (cbProveedores3.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProveedor3))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            /*
            DateTime fechaUltimaLiquidacion = objLFactura.ObtenerFechaUltimaLiquidacion(objETipoDocumentoProveedor.Numerador.Letra);
            
            if (dtFecha.Value.Date < fechaUltimaLiquidacion)
            {
                MessageBox.Show("Error en la Fecha.\nContiene Liquidaciones con Fecha Posterior ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }*/
            if (cbProveedores2.Checked)
            {
                if (rbComision2.Checked && Comisiones2() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Comisiones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                if (rbFlete2.Checked && Fletes2() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Fletes", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                if (rbOtros2.Checked && Otros2() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Otros", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            if (cbProveedores3.Checked)
            {
                if (rbComision3.Checked && Comisiones3() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Comisiones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                if (rbFlete3.Checked && Fletes3() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Fletes", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                if (rbOtros3.Checked && Otros3() == 0)
                {
                    MessageBox.Show("No se cargaron los valores de Otros", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
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
            double porcIva = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIva"].Value);
            int merma = 0;
            if (dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value.Equals(""))
            {
                merma = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Merma"].Value);
            }

            if (dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.Equals(""))
            {
                precioUnitario = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
            }
            int cantALiq = 0;
            if (dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value != null && !dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value.Equals(""))
            {
                cantALiq = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value);
            }

            if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("Merma"))
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
            else if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("CantidadALiq"))
            {
                if (cantALiq == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else
                {
                    if (precioUnitario != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                    }
                    else
                    {
                        //dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                    if (dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value.Equals(""))
                    {
                        if (cantidad - merma < 0)
                        {

                            MessageBox.Show("Cantidad a Liquidar incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                            dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                        }
                    }
                    else
                    {
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
            else if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("PrecioUnitario"))
            {
                if (precioUnitario == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
                else
                {
                    if (cantALiq != 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadALiq"].Value) * Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                        //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (porcIva / 100);
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                    }
                    else
                    {
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

            foreach (DataGridViewRow dgv in dgvDatos.Rows)
            {
                double porcIva = Convert.ToDouble(dgv.Cells["PorcIva"].Value);
                if (!dgv.Cells["Total"].Value.Equals(""))
                    dgv.Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgv.Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                //   dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100);
            }
            Calcular();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell celda = dgvDatos.CurrentCell;
                if (dgvDatos.Columns[celda.ColumnIndex].Name.Equals("Boton"))
                {

                    DataGridViewRow fila = dgvDatos.CurrentRow;
                    fila.Cells["PrecioUnitario"].Value = Utilidades.Redondear.DosDecimales(objLRemitoProveedor.ObtenerPromedio(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value), dtFecha.Value, Singleton.Instancia.Empresa));
                    fila.Cells["Merma"].Value = objLMerma.ObtenerMermasALiquidar(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value), dtFecha.Value, Singleton.Instancia.Empresa);
                    fila.Cells["CantidadALiq"].Value = /*Convert.ToInt32(fila.Cells["Merma"].Value) +*/ objLRemitoProveedor.ObtenerCantidadALiquidar(Convert.ToInt32(cbComprobante.SelectedValue), Convert.ToInt32(fila.Cells["Codigo"].Value), Convert.ToInt32(fila.Cells["Lote"].Value), dtFecha.Value, Singleton.Instancia.Empresa);



                    if (Convert.ToInt32(fila.Cells["CantidadALiq"].Value) == 0)
                    {
                        fila.Cells["CantidadALiq"].Value = "";
                    }
                    double porcIva = Convert.ToDouble(fila.Cells["PorcIva"].Value);
                    if (Convert.ToInt32(fila.Cells["PrecioUnitario"].Value) == 0)
                    {
                        dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = "";
                        dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                    }
                    else
                    {
                        fila.Cells["Total"].Value = Convert.ToInt32(fila.Cells["CantidadALiq"].Value) * Convert.ToDouble(fila.Cells["PrecioUnitario"].Value);

                        fila.Cells["Iva"].Value = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(fila.Cells["Total"].Value) * (1 - (txtPorcCom.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcCom.Text.Trim())) / 100) * (porcIva / 100));
                    }
                    Calcular();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double Comision()
        {
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

        private double Redondeo()
        {
            return txtRedondeo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRedondeo.Text.Trim());
        }



        private void dgvDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbProveedores2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedores2.Checked == false)
            {
                this.txtCodigoProveedor2.Enabled = false;
                this.lblProveedor2.Enabled = false;
                this.txtCodigoProveedor2.Text = "";
                this.panel1.Visible = false;
                if (dgvDatos.Columns.Contains("Proveedor2"))
                    dgvDatos.Columns.Remove("Proveedor2");
            }
            else
            {
                this.txtCodigoProveedor2.Enabled = true;
                this.lblProveedor2.Enabled = true;
                this.txtCodigoProveedor2.Focus();
                this.panel1.Visible = true;
                DataGridViewColumn dgv = new DataGridViewColumn();
                dgv.Name = "Proveedor2";
                if (rbComision2.Checked)
                    dgv.HeaderText = "Comision";
                else if (rbFlete2.Checked)
                    dgv.HeaderText = "Flete";
                else if (rbOtros2.Checked)
                    dgv.HeaderText = "Otros";
                dgv.DisplayIndex = dgvDatos.Columns.Count - 1;
                //dgv.ValueType = typeof(double);
                dgv.CellTemplate = new DataGridViewTextBoxCell();
                dgvDatos.Columns.Add(dgv);
                dgvDatos.Columns["Proveedor2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["Proveedor2"].ReadOnly = false;
                //txtPorcCom.Text = objEProveedor.Comision.ToString("0.00");
                //ObtenerTipoDocumento();
                //ObtenerComprobantes();
            }
        }

        private void cbProveedores3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedores3.Checked == false)
            {
                this.txtCodigoProveedor3.Enabled = false;
                this.lblProveedor3.Enabled = false;
                this.txtCodigoProveedor3.Text = "";
                this.panel2.Visible = false;
                if (dgvDatos.Columns.Contains("Proveedor3"))
                    dgvDatos.Columns.Remove("Proveedor3");
            }
            else
            {
                this.txtCodigoProveedor3.Enabled = true;
                this.lblProveedor3.Enabled = true;
                this.txtCodigoProveedor3.Focus();
                this.panel2.Visible = true;
                DataGridViewColumn dgv = new DataGridViewColumn();
                dgv.Name = "Proveedor3";
                if (rbComision3.Checked)
                    dgv.HeaderText = "Comision";
                else if (rbFlete3.Checked)
                    dgv.HeaderText = "Flete";
                else if (rbOtros3.Checked)
                    dgv.HeaderText = "Otros";
                dgv.DisplayIndex = dgvDatos.Columns.Count - 1;
                dgv.CellTemplate = new DataGridViewTextBoxCell();
                dgvDatos.Columns.Add(dgv);
                dgvDatos.Columns["Proveedor3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["Proveedor3"].ReadOnly = false;
            }
        }

        private void txtCodigoProveedor2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor2.Text.Trim().Equals(""))
                {
                    objEProveedor2 = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor2.Text.Trim()));

                    if (objEProveedor2 != null)
                    {
                        lblNombreProveedor2.Text = objEProveedor2.Nombre;
                        
                    }
                    else
                    {
                        lblNombreProveedor2.Text = "";
                    
                        //lblTipoComprobanteProveedor.Text = "";
                        //lblNumero.Text = "";
                        //txtPorcCom.Text = "0.00";
                        //cbComprobante.DataSource = null;
                        //dgvDatos.Rows.Clear();
                    }
                }
                else
                {
                    objEProveedor2 = null;
                    lblNombreProveedor2.Text = "";
            
                    //lblTipoComprobanteProveedor.Text = "";
                    //lblNumero.Text = "";
                    //cbComprobante.DataSource = null;
                    //txtPorcCom.Text = "0.00";
                    //dgvDatos.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor3.Text.Trim().Equals(""))
                {
                    objEProveedor3 = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor3.Text.Trim()));
                    //dgvDatos.Rows.Clear();
                    if (objEProveedor3 != null)
                    {
                        lblNombreProveedor3.Text = objEProveedor3.Nombre;
                        
                        //txtPorcCom.Text = objEProveedor.Comision.ToString("0.00");
                        //ObtenerTipoDocumento();
                        //ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreProveedor3.Text = "";
                    
                        //lblTipoComprobanteProveedor.Text = "";
                        //lblNumero.Text = "";
                        //txtPorcCom.Text = "0.00";
                        //cbComprobante.DataSource = null;
                        //dgvDatos.Rows.Clear();
                    }
                }
                else
                {
                    objEProveedor3 = null;
                    lblNombreProveedor3.Text = "";
                    
                    //lblTipoComprobanteProveedor.Text = "";
                    //lblNumero.Text = "";
                    //cbComprobante.DataSource = null;
                    //txtPorcCom.Text = "0.00";
                    //dgvDatos.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProveedor2_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e, sender);
        }

        private void txtCodigoProveedor3_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e, sender);
        }

        private void rbComision2_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor2();
        }

        private void TipoProveedor2()
        {
            if (dgvDatos.Columns.Contains("Proveedor2")) { 
                if (rbComision2.Checked)
                dgvDatos.Columns["Proveedor2"].HeaderText = "Comision";
            else if (rbFlete2.Checked)
                dgvDatos.Columns["Proveedor2"].HeaderText = "Flete";
            else if (rbOtros2.Checked)
                dgvDatos.Columns["Proveedor2"].HeaderText = "Otros";
           }
            Calcular();
        }
        private void TipoProveedor3()
        {
            if (dgvDatos.Columns.Contains("Proveedor3"))
            {
                if (rbComision3.Checked)
                    dgvDatos.Columns["Proveedor3"].HeaderText = "Comision 2";
                else if (rbFlete3.Checked)
                    dgvDatos.Columns["Proveedor3"].HeaderText = "Flete 2";
                else if (rbOtros3.Checked)
                    dgvDatos.Columns["Proveedor3"].HeaderText = "Otros 2";
            }
            Calcular();
        }

        private void rbFlete2_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor2();
        }

        private void rbOtro2_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor2();
        }

        private void rbComision3_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor3();
        }

        private void rbFlete3_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor3();
        }

        private void rbOtros3_CheckedChanged(object sender, EventArgs e)
        {
            TipoProveedor3();
        }

        private void lblProveedor2_Click(object sender, EventArgs e)
        {

        }

        private void lblFlete_Click(object sender, EventArgs e)
        {

        }

        private void frmLiquidacionRemitoProveedorDeposito_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbContado_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void txtPerspDGR_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void lblProveedor3_Click(object sender, EventArgs e)
        {

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
