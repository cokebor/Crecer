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
    public partial class frmNCAjusteFacturasAnteriores : Presentacion.frmColor
    {
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();

        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();

        Logica.Impuesto objLImpuesto = new Logica.Impuesto();


        //List<Entidades.AsientoTemp> listaAsientosTemporales;
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Factura objEFacturaOriginal = new Entidades.Factura();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Factura_Detalle objEFacturaDetalle = new Entidades.Factura_Detalle();

        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
        public frmNCAjusteFacturasAnteriores()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            lblFecha.Text = DateTime.Now.ToString("d").Replace("-", "/");
            Titulo();
            Formatos();
            LimitesTamaño();
            dgvDatos.AutoGenerateColumns = false;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }
        private void Titulo()
        {
            this.Text = "NOTAS DE CREDITO POR AJUSTE DE PRECIO";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbComprobante);
            lblNeto.Text = Convert.ToDouble("0").ToString("C2");
            lblIva.Text = Convert.ToDouble("0").ToString("C2");
            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
            lblIvaDescuentos.Text = Convert.ToDouble("0").ToString("C2");
            lblDescuentos.Text = Convert.ToDouble("0").ToString("C2");
            lblPercepcionMunicipal.Text = Convert.ToDouble("0").ToString("C2");
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Grilla.Formato(dgvDatos2);

            dgvDatos.Columns["Codigo"].Width = 45;
            dgvDatos2.Columns["Codigo2"].Width = 45;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos2.Columns["Descripción2"].Width = 133;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos2.Columns["Cantidad2"].Width = 60;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos2.Columns["Lote2"].Width = 60;
            dgvDatos2.Columns["Kilos"].Width = 43;
            dgvDatos.Columns["PrecioFacturado"].Width = 87;
            dgvDatos2.Columns["PrecioFacturado2"].Width = 87;
            dgvDatos.Columns["PrecioNC"].Width = 89;
            dgvDatos2.Columns["PrecioNC2"].Width = 89;
            dgvDatos.Columns["DescuentoUnitario"].Width = 102;
            dgvDatos2.Columns["DescuentoUnitario2"].Width = 102;
            dgvDatos.Columns["DescuentoTotal"].Width = 102;
            dgvDatos2.Columns["DescuentoTotal2"].Width = 102;

            dgvDatos.Columns["DescuentoUnitario"].ReadOnly = false;
            dgvDatos2.Columns["DescuentoUnitario2"].ReadOnly = false;
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 50);
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("NCAjuste", this));
                    break;
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("NCAjuste", this));
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
                        ObtenerTipoDocumento();
                        ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        lblTipoComprobanteCliente.Text = "";
                        cbComprobante.DataSource = null;
                        dgvDatos.Rows.Clear();
                        dgvDatos2.Rows.Clear();
                        Calcular();
                        //  lblNumero.Text = "";
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    lblTipoComprobanteCliente.Text = "";
                    cbComprobante.DataSource = null;
                    dgvDatos.Rows.Clear();
                    dgvDatos2.Rows.Clear();
                    Calcular();
                    //lblNumero.Text = "";
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
                /* if (objECliente != null && objECliente.Codigo != 0)// && objETipoDocumentoCliente!=null)
                 {*/
                
                    Utilidades.Combo.Llenar(cbComprobante, objLFactura.ObtenerPorClienteParaNCViejas(objECliente), "Codigo", "Numero");
                //                Utilidades.Combo.Llenar(cbComprobante, objLFactura.ObtenerPorCliente(objECliente), "Codigo", "Numero");
                /*}
                else
                {
                    
                }*/

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
            objETipoDocumentoCliente.Electronico = false;//true;
            objETipoDocumentoCliente.TipoDoc.Codigo = "NC";
            objETipoDocumentoCliente.AfectaStock = "NA";
            objETipoDocumentoCliente.MiPYME = objEFacturaOriginal.TipoDocumentoCliente.MiPYME;
            FormasDePago();
        }


        private void FormasDePago()
        {
            if (cbDevolucionEfectivo.Checked)
            {
                objETipoDocumentoCliente.AfectaCaja = 'E';
                objETipoDocumentoCliente.AfectaCtaCte = 'N';
            }
            else
            {
                objETipoDocumentoCliente.AfectaCaja = 'N';
                objETipoDocumentoCliente.AfectaCtaCte = 'C';
            }

        }

        private void cbDevolucionEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerTipoDocumento();
        }

        private void cbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComprobante.SelectedIndex != -1)
            {
                try
                {
                    objEFacturaOriginal = objLFactura.ObtenerUnaAjuste(Convert.ToInt32(cbComprobante.SelectedValue),1);
                    //Agregue para eliminar los descuentos especiales
                    objEFacturaOriginal.DescuentosEspeciales = new List<Entidades.Factura_DescuentosEspeciales>();
                    if (objEFacturaOriginal.FacturaKilos)
                    {
                        dgvDatos.Visible = false;
                        dgvDatos2.Visible = true;
                    }
                    else
                    {
                        dgvDatos.Visible = true;
                        dgvDatos2.Visible = false;
                    }
                    CargarValoresFacturaSeleccionada();
                    ObtenerTipoDocumento();
                    Calcular();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarValoresFacturaSeleccionada()
        {
            dgvDatos.Rows.Clear();
            dgvDatos2.Rows.Clear();

            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (Entidades.Factura_Detalle r in objEFacturaOriginal.Detalles)
                {
                    //   dgvDatos2.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.Kilos, r.PrecioUnitario, r.PrecioUnitarioConDescuento, "", 0, "", r.PorIva, 0, 0, 0, 0, 0, 0);
                    dgvDatos2.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.Kilos, r.PrecioUnitario, r.PrecioUnitario, "", 0, "", r.PorIva, 0, 0, 0, 0, 0, 0);
                }
            }
            else
            {
                foreach (Entidades.Factura_Detalle r in objEFacturaOriginal.Detalles)
                {
                    //   dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.PrecioUnitario, r.PrecioUnitarioConDescuento, "", 0, "", r.PorIva, 0, 0, 0, 0, 0, 0);
                    dgvDatos.Rows.Add(r.Producto.Codigo, r.Producto.Descripcion, r.Renglon, r.MovStock_Lotes.Cantidad, r.MovStock_Lotes.IdLote.IdLote, r.PrecioUnitario, r.PrecioUnitario, "", 0, "", r.PorIva, 0, 0, 0, 0, 0, 0);
                }
            }
            if (objEFacturaOriginal.TipoDocumentoCliente.AfectaCtaCte.Equals('N'))
            {
                cbDevolucionEfectivo.Checked = true;
            }
            else
            {
                cbDevolucionEfectivo.Checked = false;
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

        private void frmNCAjuste_Load(object sender, EventArgs e)
        {
            //bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");
            // bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            bool bResultado;
            if (Singleton.Instancia.Empresa.Fiscal)
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            }
            else
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");

            }
            fe.ArchivoCertificadoPassword = "030302";



            if (!bResultado)
            {
                MessageBox.Show("Error: " + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);

                //validar.KeyUp += new KeyEventHandler(this.Validar_TextChanged);
            }
        }

        private void dgvDatos2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);

                //validar.KeyUp += new KeyEventHandler(this.Validar_TextChanged);
            }
        }

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double[] precioTotalDescuento = new double[3];
            double[] ivasDescuentos = new double[3];
            double neto = 0;
            if (Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DescuentoUnitario"].Value) <= Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioNC"].Value))
            {

                double precioUnitario;
                precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DescuentoUnitario"].Value));

                double porcIVA = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIVA"].Value);
                int cant = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value);
                neto = Utilidades.Redondear.CuatroDecimales(cant * precioUnitario);
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value = neto;

                //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cant);
                dgvDatos.Rows[e.RowIndex].Cells["Ivas"].Value = Utilidades.Redondear.CuatroDecimales(neto * (porcIVA / 100));
                if (cant == 0 || precioUnitario == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["DescuentoUnitario"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["Ivas"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["PTDescuento1"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["IvaD1"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["PTDescuento2"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["IvaD2"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["PTDescuento3"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["IvaD3"].Value = 0;
                }
                else
                {
                    switch (objEFacturaOriginal.DescuentosEspeciales.Count)
                    {
                        case 1:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento11"].Value = precioTotalDescuento[0];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD11"].Value = ivasDescuentos[0];
                            break;
                        case 2:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento / 100);
                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * porcIVA / 100);
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento11"].Value = precioTotalDescuento[0];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD11"].Value = ivasDescuentos[0];
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento22"].Value = precioTotalDescuento[1];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD22"].Value = ivasDescuentos[1];

                            break;
                        case 3:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento / 100);
                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * porcIVA / 100);
                            precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[2].PorcentajeDescuento / 100);
                            ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * porcIVA / 100);
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento11"].Value = precioTotalDescuento[0];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD11"].Value = ivasDescuentos[0];
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento22"].Value = precioTotalDescuento[1];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD22"].Value = ivasDescuentos[1];
                            dgvDatos.Rows[e.RowIndex].Cells["PTDescuento33"].Value = precioTotalDescuento[2];
                            dgvDatos.Rows[e.RowIndex].Cells["IvaD33"].Value = ivasDescuentos[2];
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Descuento no puede ser superior al facturado!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoUnitario"].Value = "";
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoTotal"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["Ivas"].Value = "";
                dgvDatos.Rows[e.RowIndex].Cells["PTDescuento11"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["IvaD11"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["PTDescuento22"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["IvaD22"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["PTDescuento33"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["IvaD33"].Value = 0;
            }
            Calcular();
        }

        private double Neto()
        {
            double neto = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["DescuentoTotal2"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    neto += Convert.ToDouble(dgr.Cells["DescuentoTotal"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double NetoDescuentos()
        {
            double netoD = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    netoD += Convert.ToDouble(dgr.Cells["PTDescuento1"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento2"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento3"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    netoD += Convert.ToDouble(dgr.Cells["PTDescuento11"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento22"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento33"].Value);
                }
            }
            //        return Utilidades.Redondear.CuatroDecimales(netoD);
            return Utilidades.Redondear.DosDecimales(netoD);
        }

        private double IVA()
        {
            double iva = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (!dgr.Cells["Iva2"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Iva2"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (!dgr.Cells["Ivas"].Value.Equals(""))
                        iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double IVADescuentos()
        {
            double iva = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    iva += (Convert.ToDouble(dgr.Cells["IvaD1"].Value) + Convert.ToDouble(dgr.Cells["IvaD2"].Value) + Convert.ToDouble(dgr.Cells["IvaD3"].Value));
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    iva += (Convert.ToDouble(dgr.Cells["IvaD11"].Value) + Convert.ToDouble(dgr.Cells["IvaD22"].Value) + Convert.ToDouble(dgr.Cells["IvaD33"].Value));
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private void Calcular()
        {
            double n, i, d, id, p = 0;
            n = Neto();
            lblNeto.Text = n.ToString("C2");
            i = IVA();
            lblIva.Text = i.ToString("C2");
            d = NetoDescuentos();
            lblDescuentos.Text = d.ToString("C2");
            id = IVADescuentos();
            lblIvaDescuentos.Text = id.ToString("C2");
            p = PercepcionesMunicipales(n - d);
            lblPercepcionMunicipal.Text = p.ToString("C2");
            lblTotal.Text = (n + i + p - d - id).ToString("C2");
        }

        private double PercepcionesMunicipales(double pNeto)
        {
            double per = 0;
            if (Singleton.Instancia.Empresa.PercepcionMunicipal && objECliente != null && objECliente.TipoContribuyente.Codigo != 4)
            {
                //per = Utilidades.Redondear.DosDecimales(pNeto * objECliente.TipoContribuyente.PorcentajePercepcion / 100);
                per = Utilidades.Redondear.DosDecimales(pNeto * objEFacturaOriginal.AlicuotaMunicipal / 100);
            }
            return per;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objECliente.FechaValidacionCUIT.Equals(Variables.FechaNula) || objECliente.FechaValidacionCUIT < DateTime.Now.Date)
                {
                    if (MessageBox.Show("El Cliente no esta validado.\n¿Esta Seguro desea guardar el Comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (!Validar())
                {
                    if (objETipoDocumentoCliente.Electronico)
                    {
                        if (fe.f1TicketEsValido)
                        {
                            Comprobante();
                            Asiento();
                            objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe, objEFacturaOriginal);
                            bool res = fe.F1CAESolicitar();
                            if (res == true && fe.F1RespuestaCantidadReg > 0)
                            {
                                objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento);
                                GuardarPDF("DUPLICADO");

                                Limpiar();
                            }
                            else
                            {
                                MessageBox.Show("Error: " + fe.f1ErrorMsg1, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            if (fe.f1ObtenerTicketAcceso())
                            {
                                Comprobante();
                                Asiento();
                                objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe, objEFacturaOriginal);
                                bool res = fe.F1CAESolicitar();

                                if (res == true && fe.F1RespuestaCantidadReg > 0)
                                {

                                    objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                    objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                    objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento);
                                    GuardarPDF("DUPLICADO");

                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("Error: " + fe.f1ErrorMsg1, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    MessageBox.Show("No se puede guardar el comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }




                            }
                            else
                            {
                                MessageBox.Show("Error de conexion con servidores de AFIP \n" + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }



                    }
                    else
                    {
                        Comprobante();
                        Asiento();
                        objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento,1);
                        Limpiar();
                    }
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Se ha producido un error durante el procesamiento local de informes."))
                {
                    Limpiar();
                }
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtCodigoVendedor.Text = "";
            txtCodigoCliente.Text = "";
            cbDevolucionEfectivo.Checked = false;
            txtObservaciones.Text = "";
        }

        List<DataTable> lista;
        private void GuardarPDF(string tipo)
        {
            /*EntidadesInformes.EncabezadoFacturaVenta encabezado = new EntidadesInformes.EncabezadoFacturaVenta();
            encabezado.TipoResponsabilidad = "I.V.A. Responsable Inscripto";*/
            lista = new List<DataTable>();
            string codigo;
            DataTable dtEncabezado = new DataTable();
            dtEncabezado.TableName = "dsEncabezado";
            dtEncabezado.Columns.Add("TipoResponsabilidad");
            dtEncabezado.Columns.Add("Codigo");
            dtEncabezado.Columns.Add("CondicionVenta");
            dtEncabezado.Columns.Add("TipoVenta");
            dtEncabezado.Columns.Add("TotalEnLetras");
            dtEncabezado.Rows.Add("I.V.A. Responsable Inscripto", objEFactura.CodigoTipoDocumento, objEFactura.CondicionVenta, objEFactura.TipoVenta, Utilidades.Convertir.PrimeraLetra(Utilidades.NumeroEnLetras.Convertir(objEFactura.Total.ToString(), false)));


            DataTable dtEmpresa = new DataTable();
            dtEmpresa = new Logica.Empresa().ObtenerDataTable();
            codigo = dtEmpresa.Rows[0]["CUIT"].ToString().Replace("-", "");
            codigo = codigo + objEFactura.CodigoTipoDocumento.Replace("Cod. ", "");

            //objEFactura.FacturaKilos = false;
            DataTable dtFactura = new DataTable();
            dtFactura = new Logica.Factura().ObtenerUno(objEFactura.Codigo);

            codigo = codigo + Convert.ToInt32(dtFactura.Rows[0]["PuntoDeVenta"]).ToString("0000");
            codigo = codigo + dtFactura.Rows[0]["CAE"];
            codigo = codigo + Convert.ToDateTime(dtFactura.Rows[0]["FechaVenCae"]).ToString("yyyyMMdd");
            codigo = FacturaElectronica.ToI2of5(codigo);
            dtFactura.Columns.Add("CodigoBarra");
            dtFactura.Rows[0]["CodigoBarra"] = codigo;

            DataTable dtFacturaDetalle = new DataTable();
            dtFacturaDetalle = new Logica.FacturaDetalle().ObtenerUno(objEFactura.Codigo);
            /*
            int filas = 15 - dtFacturaDetalle.Rows.Count;
            for (int i = 0; i <= filas; i++)
            {
                dtFacturaDetalle.Rows.Add(i);
            }*/

            lista.Add(dtEmpresa);
            lista.Add(dtEncabezado);
            lista.Add(dtFactura);
            lista.Add(dtFacturaDetalle);

            frmInformes informe = new frmInformes("NOTA DE CREDITO", lista, "repFacturas");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("Tipo", tipo);
            //VER
            string factura = objLFactura.ObtenerFacturaAfectada(objEFactura.Codigo);
            factura += "; " + objLFactura.ObtenerObservaciones(objEFactura.TipoDocumentoCliente.Codigo, objEFactura.Codigo);
            parametros[1] = new ReportParameter("Factura", factura);

            //informe.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { Tipo, Razon, Domicilio, Puesto, Domicilio2, Letra, Codigo, Tipo2, Numero, Fecha, CUITEmpresa, Ingresos, FechaInicio });
            informe.reportViewer1.LocalReport.SetParameters(parametros);

            informe.reportViewer1.RefreshReport();

            Utilidades.ControladorImpresion ci = new Utilidades.ControladorImpresion();
            ci.ExportarPDF(informe.reportViewer1, "(" + objEFactura.TipoDocumentoCliente.TipoDoc.Codigo + ") " + objEFactura.Numdoc);
            ci.Dispose();

            parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
            informe.reportViewer1.LocalReport.SetParameters(parametros);
            informe.reportViewer1.RefreshReport();

            if (Singleton.Instancia.Empresa.Fiscal)
            {
                if (objECliente.Original == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "ORIGINAL");
                    //parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }

                if (Singleton.Instancia.Empresa.Codigo == 2 && objECliente.Duplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                    // parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }

                if (Singleton.Instancia.Empresa.Codigo == 2 && objECliente.Triplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "TRIPLICADO");
                    // parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
            }

        }

        private void Comprobante()
        {



            objEFactura = new Entidades.Factura();
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
            //objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objEFactura.Cliente = objECliente;

            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.SucursalCliente = objEFacturaOriginal.SucursalCliente;
            objEFactura.Vendedor = objEEmpleado;
            //objEFactura.FacturaKilos = false;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            //objEFormaDePago = objLFormaDePago.ObtenerUno(1);
            Entidades.Factura_Efectivo facturaEfectivo;


            if (cbDevolucionEfectivo.Checked)
            {
                facturaEfectivo = new Entidades.Factura_Efectivo();
                facturaEfectivo.Moneda = new Logica.Moneda().ObtenerUno(1);
                double n = Neto();
                double d = NetoDescuentos();
                facturaEfectivo.Importe = -(n + IVA() + PercepcionesMunicipales(n - d) - d - IVADescuentos());
                objEFactura.FacturaEfectivo.Add(facturaEfectivo);
            }

            if (objETipoDocumentoCliente.AfectaCtaCte.Equals('N'))
            {
                objEFactura.Imputacion = 'T';
            }
            else
            {
                objEFactura.Imputacion = 'F';
            }
            if (objETipoDocumentoCliente.AfectaIVA.Equals('N'))
            {
                objEFactura.Neto105 = -Neto(0);
            }
            else
            {
                objEFactura.Neto105 = -Neto(10.5);
                objEFactura.Neto21 = -Neto(21);
                objEFactura.Iva105 = -IVA(10.5);
                objEFactura.Iva21 = -IVA(21);
            }
            objEFactura.PercepcionMunicipal = PercepcionesMunicipales(objEFactura.Neto);

            objEFactura.Observaciones = txtObservaciones.Text.Trim();

            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;

            int renglon = 1;
            //int renglonDescuentos = 1;
            objEFactura.Detalles.Clear();
            if (objEFacturaOriginal.FacturaKilos == false)
            {
                objEFactura.FacturaKilos = false;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (!fila.Cells["DescuentoUnitario"].Value.Equals(""))
                    {
                        objEFacturaDetalle = new Entidades.Factura_Detalle();
                        objEFacturaDetalle.Renglon = renglon;

                        objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                        objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                        objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonFactura"].Value);
                        objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);

                        objEFacturaDetalle.PrecioUnitario = -Convert.ToDouble(fila.Cells["DescuentoUnitario"].Value);
                        objEFacturaDetalle.Iva = -Convert.ToDouble(fila.Cells["Ivas"].Value);

                        Entidades.Factura_DescuentosEspecialesDetalle objEDescuentosEspe;
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 0)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[0].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento11"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD11"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 1)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[1].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento22"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD22"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 2)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[2].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento33"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[2].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD33"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }

                        renglon += 1;
                        objEFactura.Detalles.Add(objEFacturaDetalle);
                    }
                }
            }
            else
            {
                objEFactura.FacturaKilos = true;

                foreach (DataGridViewRow fila in dgvDatos2.Rows)
                {
                    if (!fila.Cells["DescuentoUnitario2"].Value.Equals(""))
                    {
                        objEFacturaDetalle = new Entidades.Factura_Detalle();
                        objEFacturaDetalle.Renglon = renglon;

                        objEFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(fila.Cells["Cantidad2"].Value);
                        objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA2"].Value);
                        objEFacturaDetalle.RenglonFactura = Convert.ToInt32(fila.Cells["RenglonFactura2"].Value);
                        objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                        objEFacturaDetalle.Kilos = Convert.ToDouble(fila.Cells["Kilos"].Value);

                        objEFacturaDetalle.PrecioUnitario = -Convert.ToDouble(fila.Cells["DescuentoUnitario2"].Value);
                        objEFacturaDetalle.Iva = -Convert.ToDouble(fila.Cells["Iva2"].Value);

                        Entidades.Factura_DescuentosEspecialesDetalle objEDescuentosEspe;
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 0)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[0].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento1"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD1"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 1)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[1].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento2"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD2"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }
                        if (objEFacturaOriginal.DescuentosEspeciales.Count > 2)
                        {
                            objEDescuentosEspe = new Entidades.Factura_DescuentosEspecialesDetalle();
                            objEDescuentosEspe.RenglonFactura = objEFacturaDetalle.RenglonFactura;
                            objEDescuentosEspe.Renglon = renglon;
                            objEDescuentosEspe.Cantidad = objEFacturaDetalle.MovStock_Lotes.Cantidad;
                            objEDescuentosEspe.Codigofactura = Convert.ToInt32(cbComprobante.SelectedValue);
                            objEDescuentosEspe.Kilos = objEFacturaDetalle.Kilos;
                            objEDescuentosEspe.Detalle = "Ajuste " + objEFacturaOriginal.DescuentosEspeciales[2].Descripcion;
                            objEDescuentosEspe.PrecioUnitario = Convert.ToDouble(fila.Cells["PTDescuento3"].Value);
                            objEDescuentosEspe.Porcentaje = objEFacturaOriginal.DescuentosEspeciales[2].PorcentajeDescuento;
                            objEDescuentosEspe.Iva = Convert.ToDouble(fila.Cells["IvaD3"].Value);
                            if (objEDescuentosEspe.PrecioUnitario != 0)
                                objEFactura.DescuentosEspecialesDetalle.Add(objEDescuentosEspe);
                        }
                        renglon += 1;
                        objEFactura.Detalles.Add(objEFacturaDetalle);

                    }
                }
            }

        }

        private void Asiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFactura.Fecha;
            objEAsiento.FechaEmision = objEFactura.Fecha;
            objEAsiento.Descripcion = "Nota de Crédito por Ajuste N° " + objEFactura.Numdoc;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;
            double neto = Neto();
            double iva = IVA();
            double netoDescuentos = NetoDescuentos();
            double percMunicipal = PercepcionesMunicipales(neto - netoDescuentos);
            double ivaDescuentos = IVADescuentos();
            if (cbDevolucionEfectivo.Checked)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = neto + iva + percMunicipal - netoDescuentos - ivaDescuentos;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            else
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(2);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = neto + iva + percMunicipal - netoDescuentos - ivaDescuentos;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableAjusteSucursal;
            asientoDetalle.Debe = neto;
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            if (iva - ivaDescuentos != 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
                asientoDetalle.Debe = iva - ivaDescuentos;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            if (objEFactura.PercepcionMunicipal != 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEImpuesto = objLImpuesto.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEImpuesto.CuentaContable;
                asientoDetalle.Debe = percMunicipal;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            if (objEFactura.DescuentosEspecialesDetalle.Count > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableAjusteSucursal;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = netoDescuentos;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

        }

        private double Neto(double valor)
        {
            double neto = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["DescuentoTotal2"].Value);
                        neto -= (Convert.ToDouble(dgr.Cells["PTDescuento1"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento2"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento3"].Value));
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        neto += Convert.ToDouble(dgr.Cells["DescuentoTotal"].Value);
                        neto -= (Convert.ToDouble(dgr.Cells["PTDescuento11"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento22"].Value) + Convert.ToDouble(dgr.Cells["PTDescuento33"].Value));
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double IVA(double valor)
        {
            double iva = 0;
            if (objEFacturaOriginal.FacturaKilos)
            {
                foreach (DataGridViewRow dgr in dgvDatos2.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                    {
                        if (!dgr.Cells["Iva2"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Iva2"].Value);
                        iva -= (Convert.ToDouble(dgr.Cells["IvaD1"].Value) + Convert.ToDouble(dgr.Cells["IvaD2"].Value) + Convert.ToDouble(dgr.Cells["IvaD3"].Value));
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        if (!dgr.Cells["Ivas"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                        iva -= (Convert.ToDouble(dgr.Cells["IvaD11"].Value) + Convert.ToDouble(dgr.Cells["IvaD22"].Value) + Convert.ToDouble(dgr.Cells["IvaD33"].Value));
                    }
                }
            }
            return Utilidades.Redondear.DosDecimales(iva);
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
            if (Utilidades.Validar.GrillaVacia(dgvDatos) && dgvDatos.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (Utilidades.Validar.GrillaVacia(dgvDatos2) && dgvDatos2.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene productos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            double total = Neto() + IVA() - NetoDescuentos() - IVADescuentos();
            if (total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigoVendedor.Focus();
        }

        private void dgvDatos2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double[] precioTotalDescuento = new double[3];
            double[] ivasDescuentos = new double[3];
            double neto = 0;
            if (Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["DescuentoUnitario2"].Value) < Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["PrecioNC2"].Value))
            {
                double precioUnitario;

                precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["DescuentoUnitario2"].Value));

                double porcIVA = Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["PorcIVA2"].Value);
                double cant = Convert.ToDouble(dgvDatos2.Rows[e.RowIndex].Cells["Kilos"].Value);

                neto = Utilidades.Redondear.CuatroDecimales(cant * precioUnitario);

                dgvDatos2.Rows[e.RowIndex].Cells["DescuentoTotal2"].Value = neto;

                dgvDatos2.Rows[e.RowIndex].Cells["Iva2"].Value = Utilidades.Redondear.CuatroDecimales(neto * (porcIVA / 100));
                if (Convert.ToInt32(dgvDatos2.Rows[e.RowIndex].Cells["Cantidad2"].Value) == 0 || precioUnitario == 0)
                {
                    dgvDatos2.Rows[e.RowIndex].Cells["DescuentoUnitario2"].Value = "";
                    dgvDatos2.Rows[e.RowIndex].Cells["DescuentoTotal2"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["Iva2"].Value = "";
                    dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento1"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["IvaD1"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento2"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["IvaD2"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento3"].Value = 0;
                    dgvDatos2.Rows[e.RowIndex].Cells["IvaD3"].Value = 0;
                }
                else
                {
                    switch (objEFacturaOriginal.DescuentosEspeciales.Count)
                    {
                        case 1:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento1"].Value = precioTotalDescuento[0];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD1"].Value = ivasDescuentos[0];
                            break;
                        case 2:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento / 100);
                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * porcIVA / 100);
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento1"].Value = precioTotalDescuento[0];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD1"].Value = ivasDescuentos[0];
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento2"].Value = precioTotalDescuento[1];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD2"].Value = ivasDescuentos[1];

                            break;
                        case 3:
                            precioTotalDescuento[0] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[0].PorcentajeDescuento / 100);
                            ivasDescuentos[0] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[0] * porcIVA / 100);
                            precioTotalDescuento[1] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[1].PorcentajeDescuento / 100);
                            ivasDescuentos[1] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[1] * porcIVA / 100);
                            precioTotalDescuento[2] = Utilidades.Redondear.CuatroDecimales(neto * objEFacturaOriginal.DescuentosEspeciales[2].PorcentajeDescuento / 100);
                            ivasDescuentos[2] = Utilidades.Redondear.CuatroDecimales(precioTotalDescuento[2] * porcIVA / 100);
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento1"].Value = precioTotalDescuento[0];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD1"].Value = ivasDescuentos[0];
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento2"].Value = precioTotalDescuento[1];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD2"].Value = ivasDescuentos[1];
                            dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento3"].Value = precioTotalDescuento[2];
                            dgvDatos2.Rows[e.RowIndex].Cells["IvaD3"].Value = ivasDescuentos[2];
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Descuento no puede ser superior al facturado!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos2.Rows[e.RowIndex].Cells["DescuentoUnitario2"].Value = "";
                dgvDatos2.Rows[e.RowIndex].Cells["DescuentoTotal2"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["Iva2"].Value = "";
                dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento1"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["IvaD1"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento2"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["IvaD2"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["PTDescuento3"].Value = 0;
                dgvDatos2.Rows[e.RowIndex].Cells["IvaD3"].Value = 0;
            }
            Calcular();

        }
    }
}
