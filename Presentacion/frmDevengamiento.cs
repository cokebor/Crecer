using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDevengamiento : Presentacion.frmColor
    {
        Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
        Logica.ConceptoAsociado objLConAsoc = new Logica.ConceptoAsociado();
        Logica.Secuencia objLSecuencia = new Logica.Secuencia();
        Logica.Devengamiento objLDevengamiento = new Logica.Devengamiento();
        Entidades.ConceptoAsociado objEConcAsoc = new Entidades.ConceptoAsociado();
        Entidades.Devengamiento objEDevengamiento = new Entidades.Devengamiento();
        Entidades.Caja objECaja = new Entidades.Caja();
        //  Entidades.Concepto objEConcepto = new Entidades.Concepto();
        /*Entidades.Salario objESalario = new Entidades.Salario();
          Entidades.ConceptoAsociadoASueldo objEConcepto = new Entidades.ConceptoAsociadoASueldo();
          Logica.ConceptoAsociadoASueldo objLConcepto = new Logica.ConceptoAsociadoASueldo();
          Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
          Logica.Salario objLSalario = new Logica.Salario();*/

        double debe = 0, haber = 0;
        public frmDevengamiento()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarConceptos();
            CargarPeriodos();
            CargarPagos();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            lblDebe.Text = Convert.ToDouble(0).ToString("C2");
            lblHasta.Text = Convert.ToDouble(0).ToString("C2");
        }
        private void Titulo()
        {
            this.Text = "DEVENGAMIENTO";
        }
        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbConcepto);
            Utilidades.Combo.Formato(cbTipoSalario);
            Utilidades.Combo.Formato(cbPagos);
            Utilidades.Combo.Formato(cbPeriodo);
            Utilidades.Combo.Formato(cbCuentaContable);
        }
        private void CargarConceptos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbConcepto, objLConcepto.ObtenerActivos(), "Codigo", "Descripcion");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos() {
            try
            {
                Utilidades.Combo.Llenar(cbPagos, new Logica.Caja().ObtenerPagos(), "Codigo", "Numero");
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
                try
                {
                    //objEConcepto = objLConcepto.ObtenerUno(Convert.ToInt32(cbConcepto.SelectedValue));
                    if (Convert.ToInt32(cbConcepto.SelectedValue) == 1)
                    {
                        /* lblTipo.Visible = true;
                         cbTipoSalario.Visible = true;*/
                        Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerTodos(), "Codigo", "Descripcion");
                        lblTipo.Text = "Tipo:";
                        cbPago.Visible = true;
                    }
                    else
                    {
                        /*lblTipo.Visible = false;
                        cbTipoSalario.Visible = false;*/
                        Utilidades.Combo.Llenar(cbTipoSalario, objLSecuencia.ObtenerTodos(), "Codigo", "Descripcion");
                        lblTipo.Text = "Secuencia:";
                        cbPago.Visible = false;
                        cbPagos.Visible = false;
                        lblPago.Visible = false;
                        cbPago.Visible = true;
                    }
                    Entidades.Concepto objEConcepto = new Entidades.Concepto();
                    objEConcepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);
                    Utilidades.Combo.Llenar(cbCuentaContable, objLConAsoc.ObtenerAsociacionesActivas(objEConcepto), "Codigo", "Descripcion");
                    dgvDatos.Rows.Clear();
                    CargarTotales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarPeriodos() {
            try
            {
                Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(), "Fecha", "Meses");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCuentaContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaContable.SelectedIndex != -1)
            {
                try
                {
                    objEConcAsoc = objLConAsoc.ObtenerUno(Convert.ToInt32(cbCuentaContable.SelectedValue));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                objEConcAsoc = null;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true)) {
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
            if (objEConcAsoc.DebeOHaber.Equals('D'))
                dgvDatos.Rows.Add(objEConcAsoc.CuentaContable.Codigo, objEConcAsoc.Codigo, objEConcAsoc.Descripcion, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtMonto.Text.Trim())), 0);
            
            else
                dgvDatos.Rows.Add(objEConcAsoc.CuentaContable.Codigo, objEConcAsoc.Codigo, objEConcAsoc.Descripcion, 0, Utilidades.Redondear.DosDecimales(Convert.ToDouble(txtMonto.Text.Trim())));
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            txtMonto.Text = "";
            CargarTotales();
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtMonto));
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CargarTotales();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarTotales();
        }

        private void CargarTotales()
        {
            debe = 0;
            haber = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                debe += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Debe2"].Value));
                haber += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Haber2"].Value));
            }

            lblDebe.Text = debe.ToString("C2");
            lblHasta.Text = haber.ToString("C2");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            if (objEDevengamiento.Asiento.Detalle.Count == 0)
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCuentaContable.Focus();
                return;
            }
            if (Diferencia().Equals(false))
            {
                MessageBox.Show("La diferencia entre Debe y Haber debe ser 0!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar el Devengamiento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                
                if (objLDevengamiento.ValidarExistencia(objEDevengamiento)) {
                    if (MessageBox.Show("Ya existe Devengamientos.\n¿Esta seguro que desea guardar el Devengamiento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                objLDevengamiento.Agregar(objEDevengamiento, objECaja);
                Limpiar();
                CargarTotales();
                MessageBox.Show("Devengamiento guardado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CargarDatos()
        {
            objEDevengamiento = new Entidades.Devengamiento();
            objECaja = new Entidades.Caja();
            objEDevengamiento.Concepto.Codigo = Convert.ToInt32(cbConcepto.SelectedValue);
            if(cbPago.Checked)
                objECaja.Codigo= Convert.ToInt32(cbPagos.SelectedValue);
            if (Convert.ToInt32(cbConcepto.SelectedValue) == 1)
                objEDevengamiento.TipoSalario.Codigo = Convert.ToInt32(cbTipoSalario.SelectedValue);
            else
                objEDevengamiento.Secuencia.Codigo= Convert.ToInt32(cbTipoSalario.SelectedValue);
            objEDevengamiento.Periodo= cbPeriodo.SelectedValue.ToString();
            DateTime fecha;
            if (cbFecha.Checked)
            {
                fecha = dtpFecha.Value.Date;
            }
            else {
                int anio = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(3, 4));
                int mes = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(0, 2));
                int dia = DateTime.DaysInMonth(anio, mes);
                fecha = new DateTime(anio, mes, dia);
            }
            objEDevengamiento.Fecha = fecha;
            objEDevengamiento.Usuario = Singleton.Instancia.Usuario;
            Entidades.Asiento asiento = new Entidades.Asiento();

            asiento.Fecha = objEDevengamiento.Fecha;
            asiento.FechaEmision = objEDevengamiento.Fecha;
            asiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            asiento.Descripcion =cbConcepto.Text + ' '  + cbTipoSalario.Text + " Periodo: " + cbPeriodo.Text;
            Entidades.Asiento_Detalle asientoDetalle;
            Entidades.DevengamientoDetalle devDetalle;
            int renglon = 1;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                devDetalle = new Entidades.DevengamientoDetalle();
                devDetalle.Renglon = renglon;
                devDetalle.Concepto.Codigo = Convert.ToInt32(item.Cells["CodigoConcepto"].Value);
                asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                devDetalle.CuentaContable = asientoDetalle.CuentaContable;
                asientoDetalle.Debe = Convert.ToDouble(item.Cells["Debe2"].Value);
                devDetalle.Debe = asientoDetalle.Debe;
                asientoDetalle.Haber = Convert.ToDouble(item.Cells["Haber2"].Value);
                devDetalle.Haber = asientoDetalle.Haber;
                asiento.Detalle.Add(asientoDetalle);
                objEDevengamiento.Detalles.Add(devDetalle);
                renglon++;
            }
            objEDevengamiento.Asiento = asiento;
        }
        private bool Diferencia()
        {
            bool res = false;
            if (Utilidades.Redondear.DosDecimales(debe) - Utilidades.Redondear.DosDecimales(haber) == 0)
                res = true;
            return res;
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                lblFecha.Enabled = true;
                dtpFecha.Enabled = true;
            }
            else {
                lblFecha.Enabled = false;
                dtpFecha.Enabled = false;
            }
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void cbTipoSalario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPago.Checked)
            {
                
                    cbPagos.Visible = true;
                    lblPago.Visible = true;
               
            }
            else {
                cbPagos.Visible = false;
                lblPago.Visible = false;
            }
        }

        private void cbPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
          try {
                objECaja = new Entidades.Caja();
                objECaja.Codigo = Convert.ToInt32(cbPagos.SelectedValue);
                objECaja = new Logica.Caja().ObtenerUna(objECaja);
                lblPago.Text = objECaja.Observaciones.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Limpiar() {
            objEDevengamiento = new Entidades.Devengamiento();
            Utilidades.Combo.SeleccionarPrimerValor(cbConcepto);
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoSalario);
            Utilidades.Combo.SeleccionarPrimerValor(cbPeriodo);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            txtMonto.Text = "";
            dtpFecha.Value = DateTime.Now;
            cbFecha.Checked = false;
            dgvDatos.Rows.Clear();
        }
    }

}
