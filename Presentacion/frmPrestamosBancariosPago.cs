using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPrestamosBancariosPago : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.PrestamoBancario objLPrestamo = new Logica.PrestamoBancario();

        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();

        Entidades.PrestamoBancarioPago objPPrestamo = new Entidades.PrestamoBancarioPago();
        public frmPrestamosBancariosPago()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formato();
        }
        private void Titulo()
        {
            this.Text = "PAGOS DE PRESTAMOS BANCARIOS";
        }

        private void LimitesTamaños()
        {
    //        Utilidades.CajaDeTexto.LimiteTamaño(txtCapitalAmortizado, 20);
    //        Utilidades.CajaDeTexto.LimiteTamaño(txtInteres, 20);
    //        Utilidades.CajaDeTexto.LimiteTamaño(txtIva, 20);
        }
        private void Formato()
        {
//            dtFechaOtorgamiento.Value = DateTime.Now;
            Utilidades.Formularios.ConfiguracionInicial(this);
           
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbNroPrestamo);
            Utilidades.Combo.Formato(cbCuotas);
        }
        public void CargarValores()
        {
            try
            {
                CargarBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarBancos()
        {
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
            if (cbBancos.SelectedValue != null)
            {
                objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
            }
            else
            {
                cbCuentaBancaria.DataSource = null;
            }
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaBancaria.SelectedIndex != -1)
            {
                try
                {
                    objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                    Utilidades.Combo.Llenar(cbNroPrestamo, objLPrestamo.ObtenerPrestamosBancariosPendientes(objECuentaBancaria), "CodigoPrestamo", "Descripcion");
                    if (cbNroPrestamo.Items.Count == 0) {
                        cbCuotas.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbNroPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNroPrestamo.SelectedIndex != -1)
            {
                try
                {
                    Utilidades.Combo.Llenar(cbCuotas, objLPrestamo.ObtenerPrestamosBancariosPendientes(Convert.ToInt32(cbNroPrestamo.SelectedValue)), "Cuota", "Descripcion");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                cbCuotas.DataSource = null;
            }
        }

        private void cbCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuotas.SelectedIndex != -1)
            {
                try
                {
                    Entidades.TablaAmortizacion ta = objLPrestamo.ObtenerCuotaUna(Convert.ToInt32(cbNroPrestamo.SelectedValue), Convert.ToInt32(cbCuotas.SelectedValue));
                    txtCapitalAmortizado.Text = ta.CapitalAmortizado.ToString();
                    txtInteres.Text = ta.Interes.ToString();
                    txtIva.Text = ta.IVA.ToString();
                    txtValorCuota.Text = (ta.CapitalAmortizado + ta.Interes + ta.IVA).ToString("C2");
                    dtFecha.Value = ta.Fecha;
                    dtpFechaContable.Value = ta.Fecha;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                txtCapitalAmortizado.Text = "";
                txtInteres.Text = "";
                txtIva.Text = "";
                txtValorCuota.Text = "";
                dtFecha.Value = DateTime.Now.Date;
                dtpFechaContable.Value = DateTime.Now.Date;
            }
        }

        private double CalcularTotalCuota() {
            double capiAmo = txtCapitalAmortizado.Text.Equals("")?0:Convert.ToDouble(txtCapitalAmortizado.Text);
            double inte= txtInteres.Text.Equals("") ? 0 : Convert.ToDouble(txtInteres.Text);
            double iva = txtIva.Text.Equals("") ? 0 : Convert.ToDouble(txtIva.Text);
            return capiAmo + inte + iva;
        }
        private void txtCapitalAmortizado_TextChanged(object sender, EventArgs e)
        {
            txtValorCuota.Text =CalcularTotalCuota().ToString("C2");
        }

        private void txtCapitalAmortizado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtInteres_TextChanged(object sender, EventArgs e)
        {
            txtValorCuota.Text = CalcularTotalCuota().ToString("C2");
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {
            txtValorCuota.Text = CalcularTotalCuota().ToString("C2");
        }

        private bool Validar()
        {
            if (Convert.ToInt32(cbCuotas.SelectedValue) == -1) {
                MessageBox.Show("Debe Seleccionar una Cuota a pagar!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CalcularTotalCuota() <= 0)
            {
                MessageBox.Show("El Valor de la Cuota debe ser mayor a 0!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
       

            return true;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (MessageBox.Show("¿Esta seguro que desea guardar el Pago del Prestamo Bancario?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    CargarDatos();
                        CargarAsientos();
                        new Logica.PrestamoBancario().AgregarPago(objPPrestamo);
                        Limpiar();
                    CargarValores();
                        MessageBox.Show("Pago guardado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaBancaria);
            txtCapitalAmortizado.Text = "";
            txtInteres.Text = "";
            
            txtIva.Text = "";
            dtpFechaContable.Value = DateTime.Now.Date;
            dtFecha.Value = DateTime.Now.Date;
            

        }
        private void CargarDatos()
        {
            objPPrestamo = new Entidades.PrestamoBancarioPago();
            objPPrestamo.FechaPago = dtFecha.Value.Date;
            objPPrestamo.FechaContable = dtpFechaContable.Value.Date;
            objPPrestamo.CuentaBancaria = objECuentaBancaria;
            objPPrestamo.Prestamo = new Entidades.PrestamoBancario();
            objPPrestamo.Prestamo.CodigoPrestamo = Convert.ToInt32(cbNroPrestamo.SelectedValue);
            objPPrestamo.TablaAmortizacion = new Entidades.TablaAmortizacion();
            objPPrestamo.TablaAmortizacion.Cuota= Convert.ToInt32(cbCuotas.SelectedValue);
            objPPrestamo.TablaAmortizacion.CapitalAmortizado = txtCapitalAmortizado.Text.Equals("")?0:Convert.ToDouble(txtCapitalAmortizado.Text);
            objPPrestamo.TablaAmortizacion.Interes = txtInteres.Text.Equals("") ? 0 : Convert.ToDouble(txtInteres.Text);
            objPPrestamo.TablaAmortizacion.IVA = txtIva.Text.Equals("") ? 0 : Convert.ToDouble(txtIva.Text);
            objPPrestamo.TablaAmortizacion.CuotaAPagar= CalcularTotalCuota();
            objPPrestamo.Usuario = Singleton.Instancia.Usuario;
            objPPrestamo.PuestoCaja = Singleton.Instancia.Puesto;
        }
        private void CargarAsientos()
        {
            objPPrestamo.Asiento = new Entidades.Asiento();
            objPPrestamo.Asiento.Fecha = objPPrestamo.FechaContable;
            objPPrestamo.Asiento.FechaEmision = objPPrestamo.FechaPago;
            objPPrestamo.Asiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objPPrestamo.Asiento.Descripcion = "Pago Prestamo Bancario Nº " + objPPrestamo.Prestamo.CodigoPrestamo + " Cuota Nª: " + objPPrestamo.TablaAmortizacion.Cuota;
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = Math.Abs(objPPrestamo.TablaAmortizacion.CuotaAPagar);
            objPPrestamo.Asiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContablePrestamos;
            asientoDetalle.Debe = Math.Abs(objPPrestamo.TablaAmortizacion.CapitalAmortizado);
            asientoDetalle.Haber = 0;
            objPPrestamo.Asiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 50103040100;
            asientoDetalle.Debe = Math.Abs(objPPrestamo.TablaAmortizacion.Interes);
            asientoDetalle.Haber = 0;
            objPPrestamo.Asiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 10105010000;
            asientoDetalle.Debe = Math.Abs(objPPrestamo.TablaAmortizacion.IVA);
            asientoDetalle.Haber = 0;
            objPPrestamo.Asiento.Detalle.Add(asientoDetalle);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
