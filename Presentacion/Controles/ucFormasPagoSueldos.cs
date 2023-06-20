using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ucFormasPagoSueldos : UserControl
    {
        public double Valores { get; set; }

        Logica.FormaDePago objLFormaPago = new Logica.FormaDePago();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        public List<Entidades.Factura_Efectivo> Efectivos { get; set; }
        public List<Entidades.Tranferencia> Tranferencias { get; set; }
        public ucFormasPagoSueldos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            Efectivos = new List<Entidades.Factura_Efectivo>();
            Tranferencias = new List<Entidades.Tranferencia>();
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            CargarValores();
            this.ucContado.btnAgregar.Click += AgregarEfectivo;
            this.ucTranferenciasBancarias.btnAgregar.Click += AgregarTranferencia;
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Tipo"].Width = 70;
            dgvDatos.Columns["Importe3"].Width = 90;
        }
        private void AgregarEfectivo(object sender, EventArgs e)
        {
            if (this.ucContado.ValidarEfectivo().Equals(true)) {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucContado.txtImporte.Focus();
                return;
            }
            else if (this.ucContado.ValidarMonto().Equals(false))
            {
                MessageBox.Show("El importe ingresado no puede ser 0 o menor!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucContado.txtImporte.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 1 && Convert.ToInt32(fila.Cells["CodigoMoneda"].Value) == Convert.ToInt32(this.ucContado.cbMoneda.SelectedValue))
                {
                    MessageBox.Show("Forma de Pago ya ingresada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double cotizacion = Convert.ToDouble(this.ucContado.lblCotizacion.Text);
            double importe = Convert.ToDouble(this.ucContado.txtImporte.Text);
            double total = cotizacion * importe;



            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucContado.cbMoneda.SelectedValue, this.ucContado.cbMoneda.Text, cotizacion, importe, total.ToString("C2"), objEFormaDePago.CuentaContable.Codigo);
            Valores += total;
            LimpiarEfectivo();
        }

        private void AgregarTranferencia(object sender, EventArgs e)
        {
            if (this.ucTranferenciasBancarias.ValidarTranferencia().Equals(true))
            {
                MessageBox.Show("Falta de ingresar el importe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucTranferenciasBancarias.txtImporte.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["FormaDePago"].Value) == 5 && Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value) == ucTranferenciasBancarias.objECuentaBancaria.Codigo)// && Convert.ToInt32(fila.Cells["CodigoMoneda"].Value) == Convert.ToInt32(objE.Moneda))
                {
                    MessageBox.Show("Forma de Pago ya ingresada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double cotizacion = Convert.ToDouble(this.ucTranferenciasBancarias.lblCotizacion.Text);
            double importe = Convert.ToDouble(this.ucTranferenciasBancarias.txtImporte.Text);
            double total = cotizacion * importe;


            dgvDatos.Rows.Add(cbFormasDePago.SelectedValue, cbFormasDePago.Text, this.ucTranferenciasBancarias.objEMoneda.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Descripcion + " Nº Cuenta: "
                + this.ucTranferenciasBancarias.objECuentaBancaria.NumeroCuenta + " - " + this.ucTranferenciasBancarias.objEMoneda.Descripcion,
                cotizacion, importe, total.ToString("C2"), this.ucTranferenciasBancarias.objECuentaBancaria.CuentaContable.Codigo, this.ucTranferenciasBancarias.ObjEBanco.Codigo, null, null, null, null, null, this.ucTranferenciasBancarias.objECuentaBancaria.Codigo);

            //Valores += total;
            Valores += total;
            LimpiarTranferencia();
        }
        private void LimpiarEfectivo()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucContado.cbMoneda);
            this.ucContado.txtImporte.Text = "";
        }
        private void LimpiarTranferencia()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbFormasDePago);
            Utilidades.Combo.SeleccionarPrimerValor(this.ucTranferenciasBancarias.cbBancos);
            this.ucTranferenciasBancarias.txtImporte.Text = "";
        }
        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbFormasDePago, objLFormaPago.ObtenerTodosPagosSueldosFormasPago(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormasDePago.Text.Equals("CONTADO"))
            {
                ucContado.Visible = true;
                ucTranferenciasBancarias.Visible = false;
            }
            else if (cbFormasDePago.Text.Equals("TRANSFERENCIA BANCARIA"))
            {
                ucContado.Visible = false;
                ucTranferenciasBancarias.Visible = true;
            }
            objEFormaDePago = objLFormaPago.ObtenerUno(Convert.ToInt32(cbFormasDePago.SelectedValue));
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell != null){
                this.cbFormasDePago.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value);
                if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 1)
                {
                    this.ucContado.Visible = true;
                    this.ucTranferenciasBancarias.Visible = false;
                    this.ucContado.cbMoneda.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoMoneda"].Value);
                    this.ucContado.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucContado.txtImporte.Focus();
                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    //Valores -= total;
                    //Total -= total;
                    Valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }
                else if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["FormaDePago"].Value) == 5)
                {
                    this.ucContado.Visible = false;
                    this.ucTranferenciasBancarias.Visible = true;
                    this.ucTranferenciasBancarias.cbBancos.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoBanco"].Value);
                    this.ucTranferenciasBancarias.cbCuentaBancaria.SelectedValue = Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoCuentaBancaria"].Value);
                    this.ucTranferenciasBancarias.txtImporte.Text = dgvDatos.CurrentRow.Cells["Importe2"].Value.ToString();
                    this.ucTranferenciasBancarias.txtImporte.Focus();

                    double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                    Valores -= total;
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                double total = Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe2"].Value) * Convert.ToDouble(dgvDatos.CurrentRow.Cells["Cotizacion"].Value);
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                //Valores -= total;
                Valores -= total;
            }
        }
        public void ObtenerDatos()
        {
            Logica.Moneda objLMoneda = new Logica.Moneda();
            Efectivos.Clear();
            Tranferencias.Clear();

            Entidades.Factura_Efectivo facturaEfectivo=new Entidades.Factura_Efectivo();
            Entidades.Tranferencia tranferencia=new Entidades.Tranferencia();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                switch (Convert.ToInt32(fila.Cells["FormaDePago"].Value))
                {
                    case 1:
                        facturaEfectivo = new Entidades.Factura_Efectivo();
                        facturaEfectivo.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        facturaEfectivo.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Efectivos.Add(facturaEfectivo);
                        break;
                    case 5:
                        tranferencia = new Entidades.Tranferencia();
                        tranferencia.Banco.Codigo = Convert.ToInt32(fila.Cells["CodigoBanco"].Value);
                        tranferencia.CuentaBancaria.Codigo = Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                        tranferencia.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value);
                        tranferencia.Moneda = objLMoneda.ObtenerUno(Convert.ToInt32(fila.Cells["CodigoMoneda"].Value));
                        tranferencia.Importe = Convert.ToDouble(fila.Cells["Importe2"].Value);
                        Tranferencias.Add(tranferencia);
                        break;
                }
            }
        }

        public void Limpiar()
        {
            Valores = 0;
            dgvDatos.Rows.Clear();
        }
    }
}
