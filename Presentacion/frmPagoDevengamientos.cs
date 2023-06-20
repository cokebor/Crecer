using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPagoDevengamientos : Presentacion.frmColor
    {
        Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
        Logica.Secuencia objLSecuencia = new Logica.Secuencia();
        Logica.ConceptoAsociado objLConAsoc = new Logica.ConceptoAsociado();
        Logica.LibreDisponibilidadAsociado objLLibreDispo = new Logica.LibreDisponibilidadAsociado();
        //Logica.ConceptoAsociado objLConceptoAsociado = new Logica.ConceptoAsociado();
        Logica.Devengamiento objLDevengamiento = new Logica.Devengamiento();
        Entidades.ConceptoAsociado objEConcepto = new Entidades.ConceptoAsociado();
        Entidades.LibreDisponibilidadAsociado objEConceptoLD = new Entidades.LibreDisponibilidadAsociado();
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        int codigoDevengamiento;
        Entidades.Caja objECaja = new Entidades.Caja();
        Entidades.Devengamiento objEDevengamiento;
        Entidades.Asiento objEAsiento;
        frmRetencionesPercepcionesPagos ret1 = new frmRetencionesPercepcionesPagos();
        frmRetencionesPercepcionesPagos ret2 = new frmRetencionesPercepcionesPagos();
        frmRetencionesPercepcionesPagos ret3 = new frmRetencionesPercepcionesPagos();
        frmRetencionesPercepcionesPagos ret4 = new frmRetencionesPercepcionesPagos();
        frmRetencionesPercepcionesPagos ret5 = new frmRetencionesPercepcionesPagos();
        Logica.RetencionAsociacion objLRetAsociacion = new Logica.RetencionAsociacion();


        List<Entidades.Retenciones> retenciones1 = new List<Entidades.Retenciones>();
        List<Entidades.Retenciones> retenciones2 = new List<Entidades.Retenciones>();
        List<Entidades.Retenciones> retenciones3 = new List<Entidades.Retenciones>();
        List<Entidades.Retenciones> retenciones4 = new List<Entidades.Retenciones>();
        List<Entidades.Retenciones> retenciones5 = new List<Entidades.Retenciones>();

        double valores = 0;
        double monto2 = 0;
        double ld = 0;
        double ret = 0;
        double saldoAnterior = 0;
        public frmPagoDevengamientos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarConceptos();
        }
        private void ConfiguracionInicial() {
            Titulo();
            Formatos();
            lblTotal.Text = Convert.ToDouble(0).ToString("C2");
            lblValores.Text = Convert.ToDouble(0).ToString("C2");
            lblSaldo.Text = Convert.ToDouble(0).ToString("C2");
            lblRetenciones.Text = Convert.ToDouble(0).ToString("C2");
            lblLibreDisponibilidad.Text = Convert.ToDouble(0).ToString("C2");
            this.ucFormasPago.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPago.ucChequePropio.btnAgregar.Click += ActualizarValores;
            this.ucFormasPago.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPago.btnEditar.Click += ActualizarValores;
            this.ucFormasPago.btnEliminar.Click += ActualizarValores;
            this.ucFormasPago.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;
            tcPagos.TabPages.Remove(tpRetenciones);
            
        }

        private void ActualizarValores(object sender, EventArgs e)
        {
            CargarTotales();
        }

        void Titulo() {
            this.Text = "PAGO DE DEVENGAMIENTOS";
        }
        void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbConcepto);
            Utilidades.Combo.Formato(cbTipoSalario);
            Utilidades.Combo.Formato(cbPeriodo);
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Combo.Formato(cbCuentaContableLD);
            tpConceptos.BackColor = frmColor.Color;
            tpFormasDePago.BackColor = frmColor.Color;
            tpRetenciones.BackColor = frmColor.Color;
            tpLibreDisponibilidad.BackColor = frmColor.Color;
            dgvRetenciones.AutoGenerateColumns = false;
            //dgvSaldosAnteriores.AutoGenerateColumns = false;
            ucFormasPago.FormularioInicial = this;
        }
        void CargarConceptos() {
            try
            {
                Utilidades.Combo.Llenar(cbConcepto, objLConcepto.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConcepto.SelectedIndex != -1)
            {
                Concepto();
            }
        }

        void Concepto() {
            try
            {
                cbPeriodo.DataSource = null;
                cbTipoSalario.DataSource = null;
                cbCuentaContable.DataSource = null;
                cbPagoSinDevengamiento.Checked = false;
                dgvLibreDisponibilidad.Rows.Clear();
                txtMonto.Text = "";
                saldoAnterior = 0;
                int concepto = Convert.ToInt32(cbConcepto.SelectedValue);
 
                Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(concepto), "Periodo", "Meses");


                if (Convert.ToInt32(cbConcepto.SelectedValue) == 1)
                {

                    lblTipo.Text = "Tipo:";
                }
                else
                {
                    lblTipo.Text = "Secuencia:";
                }
          
                Entidades.Concepto objEConcepto = new Entidades.Concepto();
                objEConcepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);




                Utilidades.Combo.Llenar(cbCuentaContableLD, objLLibreDispo.ObtenerAsociacionesActivas(objEConcepto), "Codigo","Descripcion");
                //dgvSaldosAnteriores.DataSource = objLLibreDispo.ObtenerAsociacionesActivas(objEConcepto);

                DataTable dt = new Logica.RetencionAsociacion().ObtenerAsociacionesActivas(objEConcepto);
                dgvRetenciones.Rows.Clear();
                int ind = 0;
                foreach (DataRow item in dt.Rows)
                {
                    dgvRetenciones.Rows.Add(item["CodigoCuentaContable"], item["Codigo"], item["Descripcion"], 0, 0, item["DebeOHaber"]);
                    switch (ind)
                    {
                        case 0:
                            ret1.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 1:
                            ret2.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 2:
                            ret3.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 3:
                            ret4.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 4:
                            ret5.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        default:
                            MessageBox.Show("No se pueden cargar datos de estas Retenciones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    ind++;
                }
                dgvDatos.Rows.Clear();
                ucFormasPago.Limpiar();
                CargarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ConceptoSinDevengamiento()
        {
            try
            {
                cbPeriodo.DataSource = null;
                cbTipoSalario.DataSource = null;
                cbCuentaContable.DataSource = null;
                txtMonto.Text = "";
                saldoAnterior = 0;
                //int concepto = Convert.ToInt32(cbConcepto.SelectedValue);

                Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(), "Periodo", "Meses");
                
                if (Convert.ToInt32(cbConcepto.SelectedValue) == 1)
                {
                    lblTipo.Text = "Tipo:";
                    //cbPagoSinDevengamiento.Visible = true;
                }
                else
                {

                    //cbPagoSinDevengamiento.Visible = false;
                    lblTipo.Text = "Secuencia:";
                }
                
                Entidades.Concepto objEConcepto = new Entidades.Concepto();
                objEConcepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);
                DataTable dt = new Logica.RetencionAsociacion().ObtenerAsociacionesActivas(objEConcepto);
                dgvRetenciones.Rows.Clear();
                int ind = 0;
                foreach (DataRow item in dt.Rows)
                {
                    dgvRetenciones.Rows.Add(item["CodigoCuentaContable"], item["Codigo"], item["Descripcion"], 0, 0, item["DebeOHaber"]);
                    switch (ind)
                    {
                        case 0:
                            ret1.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 1:
                            ret2.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 2:
                            ret3.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 3:
                            ret4.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        case 4:
                            ret5.LlenarGrilla((Int64)item["CodigoCuentaContable"], (int)item["Codigo"]);
                            break;
                        default:
                            MessageBox.Show("No se pueden cargar datos de estas Retenciones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    ind++;
                }
                dgvDatos.Rows.Clear();
                ucFormasPago.Limpiar();
                CargarTotales();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTipoSalario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoSalario.SelectedIndex != -1)
            {
                try
                {
                    /* int concepto= Convert.ToInt32(cbConcepto.SelectedValue);
                     int tipo = Convert.ToInt32(cbTipoSalario.SelectedValue);
                     Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(concepto, tipo,tipo), "CodigoDevengamiento", "Meses");
                     */
                    if (cbPagoSinDevengamiento.Checked == false)
                    {
                        codigoDevengamiento = Convert.ToInt32(cbTipoSalario.SelectedValue);

                        Utilidades.Combo.Llenar(cbCuentaContable, new Logica.Devengamiento().ObtenerAlgunos(codigoDevengamiento), "Codigo", "Descripcion");
                    }
                    else {
                        codigoDevengamiento = 0;
                        //Aca mostrar todas las AsociacionesConcepto que sean haber y tildado el mostrar pago
                        Entidades.Concepto con = new Entidades.Concepto();
                        con.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);
                        Utilidades.Combo.Llenar(cbCuentaContable, new Logica.ConceptoAsociado().ObtenerAsociacionesActivasParaPagos(con),"Codigo","Descripcion");
                    }

                    //txtMonto.Text = "";
                    dgvDatos.Rows.Clear();
                    /*if (cbPeriodo.Items.Count == 0)
                    {
                        cbCuentaContable.DataSource = null;
                        txtMonto.Text = "";
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                //dgvRetenciones.Rows.Clear();
                CargarTotales();
            }
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (cbPeriodo.SelectedIndex != -1)
            {
                try
                {
                    int concepto = Convert.ToInt32(cbConcepto.SelectedValue);
                    //if (concepto == 1) {
                        if (cbPagoSinDevengamiento.Checked == false)
                        {
                            //int concepto = Convert.ToInt32(cbConcepto.SelectedValue);
                            string periodo = cbPeriodo.SelectedValue.ToString();
                            Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerAlgunos(concepto, periodo), "CodigoDevengamiento", "Descripcion");
                        }
                        else
                        {
                            if(concepto==1)
                                Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerTodos(), "Codigo", "Descripcion");
                            else
                                Utilidades.Combo.Llenar(cbTipoSalario, objLSecuencia.ObtenerTodos(), "Codigo", "Descripcion");


                    }
                    //}

                    /*

                    if (cbPagoSinDevengamiento.Checked == false)
                    {
                        int concepto = Convert.ToInt32(cbConcepto.SelectedValue);
                        string periodo = cbPeriodo.SelectedValue.ToString();
                        Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerAlgunos(concepto, periodo), "CodigoDevengamiento", "Descripcion");
                    }
                    else {
                    
                            Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerTodos(), "Codigo", "Descripcion");
                                      
 
                    }*/

                    dgvDatos.Rows.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          /*  else {

            }*/
            
        }
        private void CargarTotales()
        {
            monto2 = 0;
            ld = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                monto2 += Convert.ToDouble(item.Cells["Monto"].Value);
            }
            foreach (DataGridViewRow item in dgvLibreDisponibilidad.Rows) {
                ld += Convert.ToDouble(item.Cells["MontoLD"].Value);
            }

            valores = ucFormasPago.valores;
            lblRetenciones.Text = ret.ToString("C2");
            lblTotal.Text = monto2.ToString("C2");
            lblLibreDisponibilidad.Text = ld.ToString("C2");
            lblValores.Text = valores.ToString("C2");
            lblSaldo.Text = Saldo().ToString("C2");
        }
        private double Saldo()
        {
            return Utilidades.Redondear.DosDecimales(Utilidades.Redondear.DosDecimales(valores) - Utilidades.Redondear.DosDecimales(monto2) + Utilidades.Redondear.DosDecimales(ld) + Utilidades.Redondear.DosDecimales(ret));
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarConcepto().Equals(true)) {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CodigoConcepto"].Value) == Convert.ToInt32(cbCuentaContable.SelectedValue))
                {
                    MessageBox.Show("Concepto ya ingresado!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (txtMonto.Text.Length > 0 && Convert.ToDouble(txtMonto.Text) == 0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return;
            }
            if(!cbPagoSinDevengamiento.Checked) 
                if ( Convert.ToDouble(txtMonto.Text) > saldoAnterior)
                {
                    MessageBox.Show("No se pudo agregar Concepto ya que el importe a abonar no puede ser mayor al saldo!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMonto.Focus();
                    return;
                }
            try
            {
                int ren = 0;
                if(!cbPagoSinDevengamiento.Checked)
                    ren = objLDevengamiento.ObtenerUno(Convert.ToInt32(cbTipoSalario.SelectedValue), objEConcepto.Codigo);
                dgvDatos.Rows.Add(objEConcepto.CuentaContable.Codigo, objEConcepto.Codigo, objEConcepto.Descripcion, Convert.ToDouble(txtMonto.Text.Trim()), ren,saldoAnterior);
                Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
                txtMonto.Text = "";
                saldoAnterior = 0;
                CargarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private bool ValidarConcepto()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtMonto));
            return res;
        }

        private bool ValidarConceptoLB()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContableLD);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtMontoLD));
            return res;
        }

        private void cbCuentaContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaContable.SelectedIndex != -1)
            {
                try
                {
                    objEConcepto = objLConAsoc.ObtenerUno(Convert.ToInt32(cbCuentaContable.SelectedValue));
                    if (!cbPagoSinDevengamiento.Checked) { 
                        txtMonto.Text = objLConAsoc.ObtenerMontoUno(Convert.ToInt32(cbTipoSalario.SelectedValue), objEConcepto.Codigo).ToString();
                        saldoAnterior = Convert.ToDouble(txtMonto.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CargarTotales();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarTotales();
        }
        void Limpiar()
        {
            //objESalario = new Entidades.Salario();
            objECaja = new Entidades.Caja();
            retenciones1 = new List<Entidades.Retenciones>();
            retenciones2 = new List<Entidades.Retenciones>();
            retenciones3 = new List<Entidades.Retenciones>();
            retenciones4 = new List<Entidades.Retenciones>();
            retenciones5 = new List<Entidades.Retenciones>();
            Utilidades.Combo.SeleccionarPrimerValor(cbConcepto);
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoSalario);
            Utilidades.Combo.SeleccionarPrimerValor(cbPeriodo);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            txtMonto.Text = "";
            saldoAnterior = 0;
            txtObservaciones.Text = "";
            dgvDatos.Rows.Clear();
            dgvRetenciones.Rows.Clear();
            ret1 = new frmRetencionesPercepcionesPagos();
            ret2 = new frmRetencionesPercepcionesPagos();
            ret3 = new frmRetencionesPercepcionesPagos();
            ret4 = new frmRetencionesPercepcionesPagos();
            ret5 = new frmRetencionesPercepcionesPagos();
            ucFormasPago.Limpiar();
            tcPagos.SelectedIndex = 0;
            monto2 = 0;
            valores = 0;
            ret = 0;
            dtpFecha.Value = DateTime.Now;
            CargarTotales();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
             ucFormasPago.ObtenerDatos();
            if (ValidarComprobante().Equals(true)) {
                MessageBox.Show("No se pudo guardar ya que no se ingresaron Conceptos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ucFormasPago.Tranferencias.Count > 0) {
                    Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                    Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                    foreach (Entidades.Tranferencia item in ucFormasPago.Tranferencias)
                    {
                        objECuentaBancaria = objLCuentaBancaria.ObtenerUno(item.CuentaBancaria.Codigo);
                        if (ValidarFechaConciliacionCuenta(objECuentaBancaria).Equals(false))
                        {
                            MessageBox.Show("No se puede grabar el Comprobante.\nCuenta Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                if (ucFormasPago.ChequesPropios.Count > 0)
                {
                    Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
                    Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
                    foreach (Entidades.Cheque item in ucFormasPago.ChequesPropios)
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
            if (monto2 <= 0)
            {
                MessageBox.Show("Total no puede ser 0", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Saldo() != 0)
            {
            
                MessageBox.Show("El saldo del comprobante debe ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
                CargarDatos();
                CargarAsientos();
                Logica.Caja objLCaja = new Logica.Caja();
                objLCaja.AgregarPagoDevengamiento(objECaja, objEDevengamiento, objEAsiento);
                Limpiar();
                CargarTotales();
                CargarConceptos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFechaConciliacionCuentaCheques(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Cheque pCheque)
        {
            if (pCheque.FechaPago <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }

        private bool ValidarFechaConciliacionCuenta(Entidades.CuentaBancaria pCuentaBancaria)
        {
            if (dtpFecha.Value.Date <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }

        bool ValidarComprobante() {
            bool res = false;
            res = Utilidades.Validar.GrillaVacia(dgvDatos);
            return res;
        }
        void CargarDatos() {
            objECaja = new Entidades.Caja();
            if(Convert.ToInt32(cbConcepto.SelectedValue)==1)
                objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(5);
            else
                objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(6);

            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = dtpFecha.Value;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Observaciones= cbConcepto.Text + ' ' + cbTipoSalario.Text + " Periodo: " + cbPeriodo.Text + " " + txtObservaciones.Text.Trim();
            //ucFormasPago.ObtenerDatos();
            objECaja.FacturaEfectivo = ucFormasPago.Efectivos;
            objECaja.Tranferencias = ucFormasPago.Tranferencias;
            objECaja.FacturaEfectivo = ucFormasPago.Efectivos;
            objECaja.Cheques = ucFormasPago.Cheques;
            objECaja.ChequesPropios = ucFormasPago.ChequesPropios;
            objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;

            objEDevengamiento = new Entidades.Devengamiento();
            objEDevengamiento.Codigo = codigoDevengamiento;
            Entidades.DevengamientoDetalle devengamientoDetalle;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                devengamientoDetalle = new Entidades.DevengamientoDetalle();
                devengamientoDetalle.Concepto.Codigo = Convert.ToInt32(item.Cells["CodigoConcepto"].Value);
                devengamientoDetalle.Renglon = Convert.ToInt32(item.Cells["ren"].Value);
                devengamientoDetalle.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                devengamientoDetalle.Debe = Convert.ToDouble(item.Cells["Monto"].Value);
                devengamientoDetalle.SaldoAnterior= Convert.ToDouble(item.Cells["salAnt"].Value);
                objEDevengamiento.Detalles.Add(devengamientoDetalle);
            }
            Entidades.LibreDisponibilidadAsociado libreDisponibilidad;
            foreach (DataGridViewRow item in dgvLibreDisponibilidad.Rows)
            {
                libreDisponibilidad = new Entidades.LibreDisponibilidadAsociado();
                libreDisponibilidad.Codigo = Convert.ToInt32(item.Cells["CodigoConceptoLD"].Value);
                libreDisponibilidad.CuentaContable.Codigo= Convert.ToInt64(item.Cells["CodigoCuentaContableLD"].Value);
                libreDisponibilidad.Monto = Convert.ToDouble(item.Cells["MontoLD"].Value);
                objECaja.LibreDisponibilidad.Add(libreDisponibilidad);
            }
            objECaja.Retenciones.Clear();
            CargarRetencionesEnCaja(retenciones1);
            CargarRetencionesEnCaja(retenciones2);
            CargarRetencionesEnCaja(retenciones3);
            CargarRetencionesEnCaja(retenciones4);
            CargarRetencionesEnCaja(retenciones5);


        }
        void CargarRetencionesEnCaja(List<Entidades.Retenciones> pListaRetenciones) {
            foreach (Entidades.Retenciones r in pListaRetenciones)
            {
                if (objLRetAsociacion.ObtenerUno(r.RetencionAsociado.Codigo).DebeOHaber.Equals('H'))
                    r.Monto *= -1;
                objECaja.Retenciones.Add(r);
            }
        }
        private void CargarAsientos()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objECaja.Fecha;
            objEAsiento.FechaEmision = objECaja.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = objECaja.TipoDocumentoCaja.Descripcion + "  N° " + objECaja.Numdoc + " " +objECaja.Observaciones;
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(fila.Cells["CodigoCuentaContable"].Value));
                asientoDetalle.Debe = Convert.ToDouble(fila.Cells["Monto"].Value);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }


            Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
            Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
            foreach (Entidades.Factura_Efectivo fe in objECaja.FacturaEfectivo)
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
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(Math.Abs(fe.Importe) * fe.Moneda.Cotizacion);
                objEAsiento.Detalle.Add(asientoDetalle);

            }

            foreach (Entidades.Tranferencia tran in objECaja.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque ch in objECaja.Cheques)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = ch.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = ch.Importe * ch.Moneda.Cotizacion;
                asientoDetalle.Cheque.Codigo = ch.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Cheque ch in objECaja.ChequesPropios)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = ch.CuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = ch.Importe * ch.Moneda.Cotizacion;
                asientoDetalle.Cheque.Codigo = ch.Codigo;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.Retenciones r in objECaja.Retenciones)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = r.Impuesto.CuentaContable;
                if (objLRetAsociacion.ObtenerUno(r.RetencionAsociado.Codigo).DebeOHaber.Equals('D'))
                {
                    asientoDetalle.Debe = r.Monto;
                    asientoDetalle.Haber = 0;
                }
                else {
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = r.Monto;
                }
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            foreach (Entidades.LibreDisponibilidadAsociado l in objECaja.LibreDisponibilidad) {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = l.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = l.Monto;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private void dgvRetenciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                switch (e.ColumnIndex)
                {
                    case 6:
                        if (dgvRetenciones.CurrentRow != null)
                        {
                            Int64 pCodigoCuentaContable= Convert.ToInt64(dgvRetenciones.CurrentRow.Cells["CodigoCuentaContable2"].Value);
                            int pCodigoImpuesto = Convert.ToInt32(dgvRetenciones.CurrentRow.Cells["CodigoConcepto2"].Value);
                            //Utilidades.Formularios.Abrir(this.MdiParent, new frmRetencionesPercepcionesPagos(pCodigoCuentaContable, pCodigoImpuesto));
                            //ret.pCodigoCuentaContable = pCodigoCuentaContable;
                            //ret.pCodigoImpuesto = pCodigoImpuesto;
                            switch (dgvRetenciones.CurrentRow.Index)
                            {
                                case 0:
                                    //ret1.LlenarGrilla(pCodigoCuentaContable, pCodigoImpuesto);
                                    
                                    ret1.ShowDialog();
                                    if (objLRetAsociacion.ObtenerUno(pCodigoImpuesto).DebeOHaber.Equals('D'))
                                        dgvRetenciones.Rows[0].Cells["Debe"].Value = CargarValores(retenciones1, ret1.dgvDatos);
                                    else
                                        dgvRetenciones.Rows[0].Cells["Haber"].Value = CargarValores(retenciones1, ret1.dgvDatos);
                                    //CargarRetenciones();
                                    break;
                                case 1:
                                    ret2.ShowDialog();
                                    if(objLRetAsociacion.ObtenerUno(pCodigoImpuesto).DebeOHaber.Equals('D'))
                                        dgvRetenciones.Rows[1].Cells["Debe"].Value=CargarValores(retenciones2, ret2.dgvDatos);
                                    else
                                        dgvRetenciones.Rows[1].Cells["Haber"].Value = CargarValores(retenciones2, ret2.dgvDatos);
                                    break;
                                case 2:
                                    ret3.ShowDialog();
                                    if (objLRetAsociacion.ObtenerUno(pCodigoImpuesto).DebeOHaber.Equals('D'))
                                        dgvRetenciones.Rows[2].Cells["Debe"].Value = CargarValores(retenciones3, ret3.dgvDatos);
                                    else
                                        dgvRetenciones.Rows[2].Cells["Haber"].Value = CargarValores(retenciones3, ret3.dgvDatos);
                                    break;
                                case 3:
                                    //ret4.LlenarGrilla(pCodigoCuentaContable, pCodigoImpuesto);
                                    ret4.ShowDialog();
                                    if (objLRetAsociacion.ObtenerUno(pCodigoImpuesto).DebeOHaber.Equals('D'))
                                        dgvRetenciones.Rows[3].Cells["Debe"].Value = CargarValores(retenciones4, ret4.dgvDatos);
                                    else
                                        dgvRetenciones.Rows[3].Cells["Haber"].Value = CargarValores(retenciones4, ret4.dgvDatos);
                                    break;
                                case 4:
                                    //ret5.LlenarGrilla(pCodigoCuentaContable, pCodigoImpuesto);
                                    ret5.ShowDialog();
                                    if (objLRetAsociacion.ObtenerUno(pCodigoImpuesto).DebeOHaber.Equals('D'))
                                        dgvRetenciones.Rows[4].Cells["Debe"].Value = CargarValores(retenciones5, ret5.dgvDatos);
                                    else
                                        dgvRetenciones.Rows[4].Cells["Haber"].Value = CargarValores(retenciones5, ret5.dgvDatos);
                                    break;
                                default:
                                    MessageBox.Show("No se pueden cargar datos de estas Retenciones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                            //MessageBox.Show(CalcularTotalRetenciones().ToString("C2"));
                        }
                        ret=CalcularTotalRetenciones();
                        CargarTotales();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private double CargarValores(List<Entidades.Retenciones> listaRetenciones, DataGridView dg)
        {
            double total = 0;
            Entidades.Retenciones retencion;
            listaRetenciones.Clear();
            foreach (DataGridViewRow dr in dg.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["Seleccionado"].Value))
                {
                    retencion = new Entidades.Retenciones();
                    total += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dr.Cells["Importe"].Value));
                    retencion.FacturaCompra.Codigo = Convert.ToInt32(dr.Cells["CodigoFactura"].Value);
                    retencion.PagoCliente.Codigo = Convert.ToInt32(dr.Cells["CodigoPago"].Value);
                    retencion.Impuesto.Codigo = Convert.ToInt32(dr.Cells["CodigoImpuesto"].Value);
                    retencion.Impuesto.CuentaContable.Codigo = Convert.ToInt64(dr.Cells["CodigoCuentaContable"].Value);
                    retencion.RetencionAsociado.Codigo = Convert.ToInt32(dr.Cells["CodigoRetAsociada"].Value);
                    retencion.Monto = Convert.ToDouble(dr.Cells["Importe"].Value);
                    retencion.CodigoSucursal = Convert.ToInt32(dr.Cells["CodigoSucursal"].Value);
                    listaRetenciones.Add(retencion);
                }
            }
            return total;
        }
        private double CalcularTotalRetenciones() {
            double debe = 0, haber=0;
            foreach (DataGridViewRow item in dgvRetenciones.Rows)
            {
                debe += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Debe"].Value.ToString()));
                haber += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Haber"].Value.ToString()));
            }
            return Utilidades.Redondear.DosDecimales(Utilidades.Redondear.DosDecimales(haber) - Utilidades.Redondear.DosDecimales(debe));
        }

        private void cbPagoSinDevengamiento_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                ConceptoSinDevengamiento();
            }
            else {
                Concepto();
            }

        }

        private void tpConceptos_Click(object sender, EventArgs e)
        {

        }

        private void txtMontoLD_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarConceptoLB().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoLD.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvLibreDisponibilidad.Rows)
            {
                if (Convert.ToInt32(fila.Cells["CodigoConceptoLD"].Value) == Convert.ToInt32(cbCuentaContableLD.SelectedValue))
                {
                    MessageBox.Show("Concepto ya ingresado!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (txtMontoLD.Text.Length > 0 && Convert.ToDouble(txtMontoLD.Text) == 0)
            {
                MessageBox.Show("No se pudo agregar Concepto ya que el importe no puede ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoLD.Focus();
                return;
            }
            /*if (!cbPagoSinDevengamiento.Checked)
                if (Convert.ToDouble(txtMonto.Text) > saldoAnterior)
                {
                    MessageBox.Show("No se pudo agregar Concepto ya que el importe a abonar no puede ser mayor al saldo!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMonto.Focus();
                    return;
                }*/
            try
            {

                dgvLibreDisponibilidad.Rows.Add(objEConceptoLD.CuentaContable.Codigo, objEConceptoLD.Codigo, objEConceptoLD.Descripcion, Convert.ToDouble(txtMontoLD.Text.Trim()));
                Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContableLD);
                txtMontoLD.Text = "";
                CargarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCuentaContableLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaContableLD.SelectedIndex != -1)
            {
                try
                {
                    objEConceptoLD = objLLibreDispo.ObtenerUno(Convert.ToInt32(cbCuentaContableLD.SelectedValue));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvLibreDisponibilidad.CurrentRow != null)
            {
                dgvLibreDisponibilidad.Rows.Remove(dgvLibreDisponibilidad.CurrentRow);
                CargarTotales();
            }
        }
    }
}
