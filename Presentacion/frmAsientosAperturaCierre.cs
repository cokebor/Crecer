using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAsientosAperturaCierre : Presentacion.frmColor
    {
        Logica.TiposAsientos objLTiposAsientos = new Logica.TiposAsientos();
        Logica.Ejercicio objLEjercicios = new Logica.Ejercicio();
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();
        Logica.Asiento objLAsiento = new Logica.Asiento();

        Entidades.Ejercicio objEEjercicio = new Entidades.Ejercicio();
        Entidades.CuentaContable objECuentaContable = new Entidades.CuentaContable();
        Entidades.Asiento objEAsientoApertura = new Entidades.Asiento();
        Entidades.Asiento objEAsientoCierre = new Entidades.Asiento();
        public frmAsientosAperturaCierre()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial() {
            Titulo();
            Formato();
            CargarDatos();
        }

        private void Titulo() {
            this.Text = "CARGA DE ASIENTOS";
        }
        private void Formato() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Combo.Formato(cbEjercicio);
            Utilidades.Combo.Formato(cbCuentaContable);
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.AutoGenerateColumns = false;
           
          
            dgvDatos.Columns["CuentaContable"].Width = dgvDatos.Size.Width*60/100;
            dgvDatos.Columns["Debe"].Width = dgvDatos.Size.Width * 20 / 100;
            lblDebe.Location = new Point(dgvDatos.Size.Width - 2 * (dgvDatos.Size.Width * 20 / 100)+15, lblDebe.Location.Y);
            

            lblDebe.Width= dgvDatos.Size.Width * 20 / 100;
            dgvDatos.Columns["Haber"].Width = dgvDatos.Size.Width * 20 / 100;
            lblHaber.Width = dgvDatos.Size.Width * 20 / 100;
            lblHaber.Location = new Point(dgvDatos.Size.Width - (dgvDatos.Size.Width * 20 / 100)+15, lblHaber.Location.Y);
            lblDiferencia.Width= dgvDatos.Size.Width * 20 / 100;
            lblDiferencia.Location = new Point(dgvDatos.Size.Width - (dgvDatos.Size.Width * 20 / 100) + 15, lblDiferencia.Location.Y);
            lblDifTitulo.Width = dgvDatos.Size.Width * 20 / 100;
            lblDifTitulo.Location = new Point(dgvDatos.Size.Width - 2*(dgvDatos.Size.Width * 20 / 100) + 15, lblDifTitulo.Location.Y);

            CargarSumas();


        }
        private void CargarDatos() {
            try
            {
                Utilidades.Combo.Llenar(cbTipo, objLTiposAsientos.ObtenerTodos(), "Codigo", "Descripcion");
                Utilidades.Combo.Llenar(cbEjercicio, objLEjercicios.ObtenerTodos(), "Codigo", "Descripcion");
                Utilidades.Combo.Llenar(cbCuentaContable, objLCuentaContable.ObtenerTodosParaAperturaYCierre(), "Codigo", "NombreCompleto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cbTipo.SelectedValue) == 1) {
                    if (cbEjercicio.SelectedValue != null)
                    {
                        objEEjercicio = objLEjercicios.ObtenerUno(Convert.ToInt32(cbEjercicio.SelectedValue));
                        dtpFechaApertura.Value = objEEjercicio.FechaFinal.AddDays(1);
                        dtpFechaCierre.Value = objEEjercicio.FechaFinal;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private double SumaDebe() {
            double debe = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                debe += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Debe"].Value));
            }
            return Utilidades.Redondear.DosDecimales(debe);
        }
        private double SumaHaber()
        {
            double haber = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                haber += Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Haber"].Value));
            }
            return Utilidades.Redondear.DosDecimales(haber);
        }

        private void CargarSumas() {
            double debe = SumaDebe();
            double haber = SumaHaber();
            lblDebe.Text = debe.ToString("C2");
            lblHaber.Text = haber.ToString("C2");
            lblDiferencia.Text = (debe - haber).ToString("C2");
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFechaApertura.Enabled = true;
            dtpFechaCierre.Enabled = true;
            if (Convert.ToInt32(cbTipo.SelectedValue) != 1)
            {
                cbEjercicio.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                dtpFechaCierre.Visible = false;
                label1.Text = "Fecha:";
            }
            else
            {
                label1.Text = "Fecha Apertura:";
                label2.Visible = true;
                cbEjercicio.Visible = true;
                label3.Visible = true;
                dtpFechaCierre.Visible = true;
                dtpFechaApertura.Enabled = false;
                dtpFechaCierre.Enabled = false;
                if (cbEjercicio.SelectedValue != null)
                {
                    objEEjercicio = objLEjercicios.ObtenerUno(Convert.ToInt32(cbEjercicio.SelectedValue));
                    dtpFechaApertura.Value = objEEjercicio.FechaFinal.AddDays(1);
                    dtpFechaCierre.Value = objEEjercicio.FechaFinal;
                }
            }
            dgvDatos.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDato().Equals(true))
            {
                MessageBox.Show("No se pudo agregar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }
            if (Convert.ToDouble(txtImporte.Text) <= 0) {
                MessageBox.Show("El Importe a Ingresar debe ser mayor a Cero!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporte.Focus();
                return;
            }
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (objECuentaContable.Codigo == Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value)) {
                    MessageBox.Show("Cuenta Contable ya ingresada!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                if (rbDebe.Checked)
                    dgvDatos.Rows.Add(objECuentaContable.Codigo, objECuentaContable.Nombre, Convert.ToDouble(txtImporte.Text), 0);
                else
                    dgvDatos.Rows.Add(objECuentaContable.Codigo, objECuentaContable.Nombre, 0, Convert.ToDouble(txtImporte.Text));

                CargarSumas();
                Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
                txtImporte.Text = "";
                rbDebe.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDato()
        {
            bool res = false;
            res = Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            res = res || (Utilidades.Validar.TextBoxEnBlanco(txtImporte));
            return res;
        }

        private void cbCuentaContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objECuentaContable = objLCuentaContable.ObtenerUno(Convert.ToInt64(cbCuentaContable.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CargarSumas();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                cbCuentaContable.SelectedValue = dgvDatos.CurrentRow.Cells["CodigoCuentaContable"].Value;
                if (Convert.ToDouble(dgvDatos.CurrentRow.Cells["Debe"].Value) == 0)
                {
                    rbHaber.Checked = true;
                    txtImporte.Text= dgvDatos.CurrentRow.Cells["Haber"].Value.ToString();
                }
                else {
                    rbDebe.Checked = true;
                    txtImporte.Text = dgvDatos.CurrentRow.Cells["Debe"].Value.ToString();
                }
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CargarSumas();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                double debe = SumaDebe();
                double haber = SumaHaber();




                if (dgvDatos.Rows.Count > 0)
                {
                    //if (Utilidades.Redondear.DosDecimales(debe) - Utilidades.Redondear.DosDecimales(haber) == 0)
                        if ((debe) - (haber) == 0)
                        {
                        if (MessageBox.Show("¿Esta seguro que desea guardar el Asiento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        if (Convert.ToInt32(cbTipo.SelectedValue) == 1)
                        {
                          
                            CargarAsientosCierre();
                            CargarAsientosApertura();
                            if (objLAsiento.ValidarFecha(objEAsientoApertura.Fecha) == 1)
                            {
                                MessageBox.Show("No se puede cargar Asiento\nAsiento con Fecha Apertura: " + objEAsientoApertura.Fecha.Date.ToShortDateString() + " ya fue cargado anteriormente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            objLAsiento.AgregarAjustes(objEAsientoCierre, Convert.ToInt32(cbTipo.SelectedValue), Singleton.Instancia.Usuario.Codigo);
                            objLAsiento.AgregarAjustes(objEAsientoApertura, Convert.ToInt32(cbTipo.SelectedValue), Singleton.Instancia.Usuario.Codigo);
                        }
                        else
                        {
                            CargarAsientosAjuste();
                            objLAsiento.AgregarAjustes(objEAsientoApertura, Convert.ToInt32(cbTipo.SelectedValue), Singleton.Instancia.Usuario.Codigo);
                        }
                        Limpiar();
                        MessageBox.Show("Asiento creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La Diferencia entre debe y haber debe ser Cero!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CargarAsientosCierre() {
            objEAsientoCierre = new Entidades.Asiento();
            objEAsientoCierre.Fecha = dtpFechaCierre.Value;
            objEAsientoCierre.FechaEmision = dtpFechaCierre.Value;
            objEAsientoCierre.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsientoCierre.Descripcion = "Asiento de Cierre Ejercicio:" + objEEjercicio.Descripcion;
            Entidades.Asiento_Detalle asientoDetalle;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                asientoDetalle.Debe= Convert.ToDouble(item.Cells["Debe"].Value);
                asientoDetalle.Haber = Convert.ToDouble(item.Cells["Haber"].Value);
                objEAsientoCierre.Detalle.Add(asientoDetalle);
            }
        }

        private void CargarAsientosApertura()
        {
            objEAsientoApertura = new Entidades.Asiento();
            objEAsientoApertura.Fecha = dtpFechaApertura.Value;
            objEAsientoApertura.FechaEmision = dtpFechaApertura.Value;
            objEAsientoApertura.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsientoApertura.Descripcion = "Asiento de Apertura Ejercicio:" + objEEjercicio.Descripcion;

            Entidades.Asiento_Detalle asientoDetalle;
            foreach (Entidades.Asiento_Detalle item in objEAsientoCierre.Detalle)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = item.CuentaContable.Codigo;
                asientoDetalle.Debe = item.Haber;
                asientoDetalle.Haber = item.Debe;
                objEAsientoApertura.Detalle.Add(asientoDetalle);
            }
        }

        private void CargarAsientosAjuste()
        {
            objEAsientoApertura = new Entidades.Asiento();
            objEAsientoApertura.Fecha = dtpFechaApertura.Value;
            objEAsientoApertura.FechaEmision = dtpFechaApertura.Value;
            objEAsientoApertura.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsientoApertura.Descripcion = "Asiento de Ajuste";
            Entidades.Asiento_Detalle asientoDetalle;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                asientoDetalle.Debe = Convert.ToDouble(item.Cells["Debe"].Value);
                asientoDetalle.Haber = Convert.ToDouble(item.Cells["Haber"].Value);
                objEAsientoApertura.Detalle.Add(asientoDetalle);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            objEAsientoApertura = new Entidades.Asiento();
            objEAsientoCierre = new Entidades.Asiento();
            objEEjercicio = new Entidades.Ejercicio();
            objECuentaContable = new Entidades.CuentaContable();
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaContable);
            txtImporte.Text = "";
            rbDebe.Checked = true;
            dgvDatos.Rows.Clear();
            CargarSumas();

        }
    }
}
