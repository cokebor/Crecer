using Entidades;
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
    public partial class frmNCLotes : Presentacion.frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.Factura objEFactura = new Entidades.Factura();
        Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Factura objEFacturaOriginal = new Entidades.Factura();

        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        Entidades.Impuesto objEImpuesto = new Entidades.Impuesto();

        Logica.Impuesto objLImpuesto = new Logica.Impuesto();

        WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
        public frmNCLotes()
        {
            InitializeComponent();
            ConfiguracionInicial();

        }

        private void ConfiguracionInicial()
        {

            lblFecha.Text = DateTime.Now.ToString("d").Replace("-", "/");
            Titulo();
            LimitesTamaño();
            Formatos();
            dgvDatos.AutoGenerateColumns = false;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            /*
             lblNeto.Text = Convert.ToDouble("0").ToString("C2");
             lblIva.Text = Convert.ToDouble("0").ToString("C2");
             lblTotal.Text = Convert.ToDouble("0").ToString("C2");*/


        }

        private void Titulo()
        {
            if (Singleton.Instancia.Empresa.Convenio)
                this.Text = "NOTAS DE CREDITO POR CONVENIO";
            else
                this.Text = "NOTAS DE CREDITO POR LOTE";
        }

        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoVendedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescuento, 10);

        }

        private void Formatos()
        {

            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.DefaultCellStyle.SelectionBackColor = SystemColors.Window;
           // dgvDatos.SelectionMode = DataGridViewSelectionMode.;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Comprobante"].Width = 160;
          /*  dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["PUnitario"].Width = 90;
            */
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

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("NCLotes", this));
                    break;
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("NCLotes", this));
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
                    }
                    else
                    {
                        lblNombreCliente.Text = "";
                        dgvDatos.DataSource = null;
                        lblTipoComprobanteCliente.Text = "";
                        //  lblNumero.Text = "";
                    }
                }
                else
                {
                    objECliente = null;
                    lblNombreCliente.Text = "";
                    dgvDatos.DataSource = null;
                    lblTipoComprobanteCliente.Text = "";
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

        private void ObtenerValores()
        {
            if (objETipoDocumentoCliente == null)
            {
                objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
            }

            objETipoDocumentoCliente.Electronico = false;//true;
            objETipoDocumentoCliente.TipoDoc.Codigo = "NC";
            objETipoDocumentoCliente.MiPYME = objEFacturaOriginal.TipoDocumentoCliente.MiPYME;
            if (Singleton.Instancia.Empresa.Convenio == true)
                objETipoDocumentoCliente.TipoDocLotes = true;
            objETipoDocumentoCliente.AfectaStock = "NA";
            FormasDePago();
        }

        private void FormasDePago()
        {

                objETipoDocumentoCliente.AfectaCaja = 'N';
                objETipoDocumentoCliente.AfectaCtaCte = 'C';
        }
        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

  

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*
            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
                if (Convert.ToBoolean(check.Value) == true)
                {
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else {
                    dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }*/
        }
    //    int cantSeleccionados = 0;

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  dgvDatos.ClearSelection();
            /* if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
             {*/
            /*DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            check.Value = !(Convert.ToBoolean(check.Value));
            if (Convert.ToBoolean(check.Value) == true)
            {
                dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            else
            {
                dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
            }
        dgvDatos.ClearSelection();*/

            // }
            DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            check.Value = !(Convert.ToBoolean(check.Value));


            /*
            DataGridViewCheckBoxCell check;
            check = (DataGridViewCheckBoxCell)dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"].Value=!
            dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"].Value=!Convert.ToBoolean(dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"].Value);*/
            if (Convert.ToBoolean(check.Value)){
                dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                if (!txtDescuento.Text.Trim().Equals(""))
                {
                    dgvDatos.Rows[e.RowIndex].Cells["Descuento"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["ImporteConTodasNC2"].Value) * Convert.ToDouble(txtDescuento.Text.Trim()) / 100);
                }
            }
            else
            {
                dgvDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvDatos.Rows[e.RowIndex].Cells["Descuento"].Value = "";
            }
            dgvDatos.ClearSelection();
            CalcularSeleccionados();
            CalcularTotal();
        }


        private void CalcularSeleccionados()
        {
            int cantSeleccionados = 0;
            DataGridViewCheckBoxCell check;
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                check = (DataGridViewCheckBoxCell)dg.Cells["Seleccionado"];
                //check.Value = !(Convert.ToBoolean(check.Value));
                if (Convert.ToBoolean(check.Value) == true) {
                    cantSeleccionados++;
                }
            }
            lblSeleccionados.Text = cantSeleccionados.ToString();
        }
        private void cbSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSeleccion.Checked)
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    fila.Cells["Seleccionado"].Value = true;
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                    if (!txtDescuento.Text.Trim().Equals(""))
                    {
                        fila.Cells["Descuento"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(fila.Cells["ImporteConTodasNC2"].Value) * Convert.ToDouble(txtDescuento.Text.Trim()) / 100);
                    }
                }
            else {
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    fila.Cells["Seleccionado"].Value = false;
                    fila.DefaultCellStyle.BackColor = SystemColors.Window;
                    fila.Cells["Descuento"].Value = "";
                }
            }
            //  dgvDatos.ClearSelection();
            CalcularSeleccionados();
            CalcularTotal();
            dgvDatos.ClearSelection();
        }




        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
     {
            AccesosRapidos(e);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacionNueveDecimales(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarBusqueda())
                {
                    CargarValores();
                    
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime desde, hasta;
        private void CargarValores() {

            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;
            if(cbFacturasViejas.Checked)
                dgvDatos.DataSource = objLFactura.ObtenerPorClienteParaNCLotesViejas(objECliente, desde, hasta);
            else
                dgvDatos.DataSource = objLFactura.ObtenerPorClienteParaNCLotes(objECliente, desde, hasta, cbDescontarSobrePrecioDeFacturacion.Checked);
            PonerNegrita();
        }

        private bool ValidarBusqueda()
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


            return false;
        }



        private void PonerNegrita() {
            foreach (DataGridViewRow dg in dgvDatos.Rows) {
                if (Convert.ToDouble(dg.Cells["ImporteFacturado"].Value) != Convert.ToDouble(dg.Cells["ImporteConNC"].Value))
                    dg.Cells["ImporteConNC"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Bold);
                if (Convert.ToDouble(dg.Cells["ImporteConNC"].Value) != Convert.ToDouble(dg.Cells["ImporteConTodasNC"].Value))
                    dg.Cells["ImporteConTodasNC"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Bold);
            }
        }

        double porcentaje;
        private void btnValidar_Click(object sender, EventArgs e)
        {
            Validar2();
  
        }

        private void Validar2() {
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                DataGridViewCheckBoxCell check;
                check = (DataGridViewCheckBoxCell)dg.Cells["Seleccionado"];
                if (Convert.ToBoolean(check.Value))
                {
                    if (!txtDescuento.Text.Trim().Equals(""))
                    {
                        dg.Cells["Descuento"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dg.Cells["ImporteConTodasNC2"].Value) * Convert.ToDouble(txtDescuento.Text.Trim()) / 100);

                    }
                    else
                    {
                        dg.Cells["Descuento"].Value = "";
                    }

                }
                else
                {
                    dg.Cells["Descuento"].Value = "";
                }
            }
            CalcularTotal();
        }
        private void CalcularTotal() {
            double totalDescuentos = 0;
            foreach (DataGridViewRow dg in dgvDatos.Rows)
            {
                DataGridViewCheckBoxCell check;
                check = (DataGridViewCheckBoxCell)dg.Cells["Seleccionado"];
                if (Convert.ToBoolean(check.Value))
                {
                    if(dg.Cells["Descuento"].Value !=null && !dg.Cells["Descuento"].Value.Equals(""))
                     totalDescuentos += Convert.ToDouble(dg.Cells["Descuento"].Value);
                }
            }
            lblTotal.Text = totalDescuentos.ToString("C2");
        }

        private void frmNCLotes_Load(object sender, EventArgs e)
        {
            //bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");
            bool bResultado;
            if (Singleton.Instancia.Empresa.Fiscal)
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            }
            else
            {
                bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Test, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", @"");

            }
            //   bool bResultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, Singleton.Instancia.Empresa.CUITSinGuion, Application.StartupPath + @"\Certificado\Certificado.pfx", Application.StartupPath + @"\Certificado\licencia.lic");
            fe.ArchivoCertificadoPassword = "030302";



            if (!bResultado)
            {
                MessageBox.Show("Error: " + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar()) {
                    return;
                }
                if (MessageBox.Show("¿Esta seguro que desea guardar los comprobantes con el " + txtDescuento.Text.Trim() + " % de descuento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                
                Validar2();
                DataGridViewCheckBoxCell check;
                foreach (DataGridViewRow dg in dgvDatos.Rows)
                {
                    check = (DataGridViewCheckBoxCell)dg.Cells["Seleccionado"];
                    //check.Value = !(Convert.ToBoolean(check.Value));
                    if (Convert.ToBoolean(check.Value) == true)
                    {
                        int cod = Convert.ToInt32(dg.Cells["Codigo"].Value);

                        int vie = Convert.ToInt32(dg.Cells["Viejos"].Value);

                        /* if (!Validar())
                         {*/
                        // Comprobantes(cod, vie);
                        if (objETipoDocumentoCliente.Electronico)
                        {
                            if (fe.f1TicketEsValido)
                            {
                                Comprobantes(cod, vie);
                                Asiento();
                                if (objEFactura.Iva != 0)
                                {
                                    //objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe,objEFacturaOriginal);
                                    objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe, objEFacturaOriginal);
                                    bool res = fe.F1CAESolicitar();
                                    if (res == true && fe.F1RespuestaCantidadReg > 0)
                                    {
                                        objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                        objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                        objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento, vie);
                                        GuardarPDF("DUPLICADO");
                                        check.Value = false;
                                        dg.DefaultCellStyle.BackColor = SystemColors.Window;
                                        //dg.DefaultCellStyle
                                        //  Limpiar();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: " + fe.f1ErrorMsg1 + "\n" + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }
                            }
                            else
                            {
                                if (fe.f1ObtenerTicketAcceso())
                                {
                                    Comprobantes(cod, vie);
                                    Asiento();
                                    if (objEFactura.Iva != 0)
                                    {
                                        objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe, objEFacturaOriginal);
                                        //objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                                        bool res = fe.F1CAESolicitar();

                                        if (res == true && fe.F1RespuestaCantidadReg > 0)
                                        {

                                            objEFactura.FechaVenCae = Convert.ToDateTime(fe.F1RespuestaDetalleCAEFchVto.Substring(6, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(4, 2) + "/" + fe.F1RespuestaDetalleCAEFchVto.Substring(0, 4));
                                            objEFactura.Cae = fe.F1RespuestaDetalleCae;

                                            objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento, vie);
                                            GuardarPDF("DUPLICADO");
                                            check.Value = false;
                                            dg.DefaultCellStyle.BackColor = SystemColors.Window;
                                            // Limpiar();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error: " + fe.f1ErrorMsg1 + "\n" + fe.F1RespuestaDetalleObservacionMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }


                                }
                                else
                                {
                                    //MessageBox.Show(fe.f1ObtenerTicketAcceso().ToString());
                                    MessageBox.Show("Error de conexion con servidores de AFIP \n" + fe.UltimoMensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }

                            // }
                        }
                        else
                        {
                            Comprobantes(cod, vie);
                            Asiento();
                            if (objEFactura.Neto != 0)
                            {
                                //objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe, objEFacturaOriginal);
                                //objEFactura = FacturaElectronica.FacturaElectronicaPedido(objEFactura, fe);
                                //bool res = fe.F1CAESolicitar();
                                objEFactura.Codigo = objLFactura.AgregarAjustes(objEFactura, objEAsiento, vie);
                                check.Value = false;
                                dg.DefaultCellStyle.BackColor = SystemColors.Window;

                               
                            }
                        }
                    }
          
                    CalcularSeleccionados();
                }

                MessageBox.Show("Comprobantes guardados exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Se ha producido un error durante el procesamiento local de informes."))
                {
                    //  Limpiar();
                }
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (Utilidades.Validar.TextBoxEnBlanco(txtDescuento))
            {
                MessageBox.Show("Seleccione un Porcentaje de descuento valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescuento.Focus();
                return true;
            }

            return false;
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

            //lista.Add(new Logica.Sucursal().ObtenerUno(Singleton.Instancia.Empresa.Codigo));
            DataTable dtEmpresa = new DataTable();
            dtEmpresa = new Logica.Empresa().ObtenerDataTable();
            codigo = dtEmpresa.Rows[0]["CUIT"].ToString().Replace("-", "");
            codigo = codigo + objEFactura.CodigoTipoDocumento.Replace("Cod. ", "");


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
                
                if (Singleton.Instancia.Empresa.Codigo==2 && objECliente.Duplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "DUPLICADO");
                    //parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }

                if (Singleton.Instancia.Empresa.Codigo == 2 && objECliente.Triplicado == true)
                {
                    parametros[0] = new ReportParameter("Tipo", "TRIPLICADO");
                  //  parametros[1] = new ReportParameter("Factura", "");
                    informe.reportViewer1.LocalReport.SetParameters(parametros);
                    informe.reportViewer1.RefreshReport();

                    ci.Imprimir(informe.reportViewer1.LocalReport, Singleton.Instancia.Usuario.ImpresoraComprobantes);
                }
            }


            //ci.Imprimir(informe.reportViewer1.LocalReport);

            //   Utilidades.Formularios.AbrirFuera(informe);
        }



        private void Comprobantes(int pCodigo, int pViejo)
        {
            objEFactura = new Entidades.Factura();
            //objEFactura = objLFactura.ObtenerUnaParaNCLote(pCodigo, pViejo, cbDescontarSobrePrecioDeFacturacion.Checked);
            objEFacturaOriginal = objLFactura.ObtenerUnaParaNCLote(pCodigo, pViejo, cbDescontarSobrePrecioDeFacturacion.Checked);
            ObtenerTipoDocumento();
            objEFactura.FacturaKilos = objEFacturaOriginal.FacturaKilos;
            objEFactura.TipoDocumentoCliente = objETipoDocumentoCliente;
            objEFactura.Letra = Convert.ToChar(objETipoDocumentoCliente.Numerador.Letra);
            objEFactura.PuntoDeVenta = objETipoDocumentoCliente.Numerador.PuntoVenta;
            objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            //objEFactura.Numero = FacturaElectronica.ObtenerNumeroFactura(objEFactura, fe);
            objEFactura.CodigoSucursal = Singleton.Instancia.Empresa.Codigo;
            objEFactura.Fecha = DateTime.Now;
            objECliente.TipoContribuyente.PorcentajePercepcion = objEFacturaOriginal.AlicuotaMunicipal;
            objEFactura.Cliente = objECliente;
            SucursalCliente sc = new SucursalCliente();
            sc.CodigoSucursal = objEFacturaOriginal.SucursalCliente.CodigoSucursal;
            objEFactura.SucursalCliente = sc;
            objEFactura.Vendedor = objEEmpleado;
            if (objETipoDocumentoCliente.AfectaCtaCte.Equals('N'))
            {
                objEFactura.Imputacion = 'T';
            }
            else
            {
                objEFactura.Imputacion = 'F';
            }
            int renglon = 0;
            foreach (Entidades.Factura_Detalle fd in objEFacturaOriginal.Detalles)
            {
                //foreach (Entidades.Factura_Detalle fd in objEFactura.Detalles)
               // {
                    fd.Codigofactura = pCodigo;
                    porcentaje = Convert.ToDouble(txtDescuento.Text.Trim());
                    /*if (objEFactura.FacturaKilos) {
                    }else { */

                    fd.PrecioUnitario = -Utilidades.Redondear.CuatroDecimales((fd.PrecioUnitario) * porcentaje / 100);
                    // if (objEFacturaOriginal.FacturaKilos)
                    if (objEFacturaOriginal.FacturaKilos)
                    {
                        // fd.PrecioUnitario = -Utilidades.Redondear.CuatroDecimales((fd.PrecioUnitario/fd.MovStock_Lotes.Cantidad) * porcentaje / 100);
                        fd.Iva = Convert.ToDouble(Utilidades.Redondear.CuatroDecimales((fd.PrecioUnitario * fd.PorIva / 100)) * fd.Kilos);
                    }
                    else
                    {

                        // fd.PrecioUnitario = -Utilidades.Redondear.CuatroDecimales((fd.PrecioUnitario) * porcentaje / 100);
                        fd.Iva = Convert.ToDouble(Utilidades.Redondear.CuatroDecimales((fd.PrecioUnitario * fd.PorIva / 100)) * fd.MovStock_Lotes.Cantidad);
                    }
                    fd.RenglonFactura = Convert.ToInt32(fd.Renglon);
                    fd.Renglon = ++renglon;

                 //    }
                }
            objEFactura.Detalles = objEFacturaOriginal.Detalles;
            objEFactura.Observaciones = "";
            if (objETipoDocumentoCliente.AfectaIVA.Equals('N'))
            {
                objEFactura.Neto105 = Neto(0);
            }
            else
            {
                objEFactura.Neto105 = Neto(10.5);
                objEFactura.Neto21 = Neto(21);

                objEFactura.Iva105 = IVA(10.5);
                objEFactura.Iva21 = IVA(21);
            }
            objEFactura.PercepcionMunicipal = PercepcionesMunicipales(objEFactura.Neto);

                objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
                objEFactura.Usuario = Singleton.Instancia.Usuario;


         
        }
        private double PercepcionesMunicipales(double pNeto)
        {
            double per = 0;
            if (Singleton.Instancia.Empresa.PercepcionMunicipal && objECliente != null)
            {
                per = Utilidades.Redondear.DosDecimales(pNeto * objEFacturaOriginal.AlicuotaMunicipal / 100);
            }
            return per;
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
            double percMunicipal = PercepcionesMunicipales(neto);
           // double netoDescuentos = NetoDescuentos();
           // double ivaDescuentos = IvaDescuentos();


            asientoDetalle = new Entidades.Asiento_Detalle();
                objEFormaDePago = objLFormaDePago.ObtenerUno(2);
                asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(neto+iva+percMunicipal);
            
                objEAsiento.Detalle.Add(asientoDetalle);
            

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableAjusteSucursal;
            asientoDetalle.Debe = Math.Abs(neto);
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);

            if (iva != 0){ 
            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = Singleton.Instancia.Empresa.CuentaContableIvaDebitoSucursal;
            asientoDetalle.Debe = Math.Abs(iva);
            asientoDetalle.Haber = 0;
            objEAsiento.Detalle.Add(asientoDetalle);
            }

            if (objEFactura.PercepcionMunicipal != 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                objEImpuesto = objLImpuesto.ObtenerUno(1);
                asientoDetalle.CuentaContable = objEImpuesto.CuentaContable;
                asientoDetalle.Debe = Math.Abs(percMunicipal);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private double Neto(double valor)
        {
            double neto = 0;
            // if (objEFactura.FacturaKilos)
            //   {
            foreach (Entidades.Factura_Detalle fd in objEFacturaOriginal.Detalles)
            //foreach (Entidades.Factura_Detalle fd in objEFactura.Detalles)
            {
                   // if (Convert.ToDouble(dgr.Cells["PorcIVA2"].Value) == valor)
                   if(Convert.ToDouble(fd.PorIva)==valor)
                    {
                    if (objEFacturaOriginal.FacturaKilos) {
                    //if (objEFactura.FacturaKilos) {
                        neto += Convert.ToDouble(fd.PrecioUnitario * fd.Kilos);
                    } else
                    { 
                        neto += Convert.ToDouble(fd.PrecioUnitario * fd.MovStock_Lotes.Cantidad);
                    }
                }
                }
            //}
           
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Neto()
        {
            double neto = 0;
            // if (objEFactura.FacturaKilos)
            //   {
            foreach (Entidades.Factura_Detalle fd in objEFacturaOriginal.Detalles)
            //    foreach (Entidades.Factura_Detalle fd in objEFactura.Detalles)
            {

              if (objEFacturaOriginal.FacturaKilos)
              //  if (objEFactura.FacturaKilos)
                {
                    neto += Convert.ToDouble(fd.PrecioUnitario * fd.Kilos);
                }
                else
                {
                    neto += Convert.ToDouble(fd.PrecioUnitario * fd.MovStock_Lotes.Cantidad);
                }
            }
            //}

            return Utilidades.Redondear.DosDecimales(neto);
        }
        private double IVA(double valor)
        {
            double iva = 0;
           /* if (objEFacturaOriginal.FacturaKilos)
            {*/
                foreach (Entidades.Factura_Detalle fd in objEFacturaOriginal.Detalles)
                {
                    if (Convert.ToDouble(fd.PorIva) == valor)
                    {
                        //if (!dgr.Cells["Iva2"].Value.Equals(""))
                            iva += Convert.ToDouble(fd.Iva);
                    }
                }
            /*}
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        if (!dgr.Cells["Ivas"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                    }
                }
            }*/
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private double IVA()
        {
            double iva = 0;
            /* if (objEFacturaOriginal.FacturaKilos)
             {*/
            foreach (Entidades.Factura_Detalle fd in objEFacturaOriginal.Detalles)
            {

                    //if (!dgr.Cells["Iva2"].Value.Equals(""))
                    iva += Convert.ToDouble(fd.Iva);
                
            }
            /*}
            else
            {
                foreach (DataGridViewRow dgr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgr.Cells["PorcIVA"].Value) == valor)
                    {
                        if (!dgr.Cells["Ivas"].Value.Equals(""))
                            iva += Convert.ToDouble(dgr.Cells["Ivas"].Value);
                    }
                }
            }*/
            return Utilidades.Redondear.DosDecimales(iva);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFacturasViejas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFacturasViejas.Checked)
            {
                cbDescontarSobrePrecioDeFacturacion.Checked = false;
                cbDescontarSobrePrecioDeFacturacion.Enabled = false;
            }
            else {
                cbDescontarSobrePrecioDeFacturacion.Enabled = true;
            }
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbDescontarSobrePrecioDeFacturacion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  dgvDatos.ClearSelection();
        }
    }
}
