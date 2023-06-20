using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMovimientosBancarios : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.TipoMovimientoBancario objLTipoMovimientoBancario = new Logica.TipoMovimientoBancario();
        Logica.MovimientoBancario objLMovimientoBancario = new Logica.MovimientoBancario();
        Logica.TipoDocumentoCaja objLTipoDocCaja = new Logica.TipoDocumentoCaja();
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.MovimientoBancario objEMovimientoBancario = new Entidades.MovimientoBancario();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.TipoMovimientoBancario objETipoMovimientoBancario = new Entidades.TipoMovimientoBancario();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        Entidades.Caja objECaja;// = new Entidades.Caja();
        public frmMovimientosBancarios()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            CargarValores();
        }

        public void Titulo()
        {
            this.Text = "ADMINISTRACION DE MOVIMIENTOS BANCARIOS";
        }

        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, null, btnCancelar);
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtImporte, 15);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones, 100);
        }
        private void Formatos()
        {
            // dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbMovimientos);
            /*   Utilidades.Grilla.Formato(dgvDatos);
               dgvDatos.Columns["Codigo"].Width = 50;
               dgvDatos.Columns["Banco"].Width = 100;
               dgvDatos.Columns["Estado"].Width = 50;*/
        }

        public void CargarValores()
        {
            try
            {
                CargarBancos();
                CargarTiposMovimientos();
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
        }

        public void CargarTiposMovimientos()
        {
            Utilidades.Combo.Llenar(cbMovimientos, objLTipoMovimientoBancario.ObtenerAlgunos(), "Codigo", "Descripcion");
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

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void Limpiar()
        {
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);

            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            //txtPorcIva2.Text = "21,00";
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaBancaria);
            Utilidades.Combo.SeleccionarPrimerValor(cbMovimientos);
            objECaja = null;
            BotonesInicial();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, null, btnCancelar);
            txtImporte.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool ValidarFechaConciliacionCuenta()
        {
            if (dtFecha.Value.Date <= objECuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validar().Equals(true))
                {
                    MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    return;
                }
                if (ValidarFechaConciliacionCuenta().Equals(false))
                {
                    MessageBox.Show("No se puede grabar el Comprobante.\nCuenta Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtImporte.Text.Trim().Equals("") || Convert.ToDouble(txtImporte.Text.Trim()) == 0)
                {
                    MessageBox.Show("El Importe del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                Comprobante();
                if (objEMovimientoBancario.TipoMovimientoBancario.Codigo == 2)
                {
                    objLMovimientoBancario.Agregar(objEMovimientoBancario);
                }
                else
                {
                    Asiento();
                    objLMovimientoBancario.Agregar(objEMovimientoBancario, objECaja, objEAsiento);
                }

                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Asiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEMovimientoBancario.FechaMovimiento;
            objEAsiento.FechaEmision = objEMovimientoBancario.FechaMovimiento;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = objEMovimientoBancario.TipoMovimientoBancario.Descripcion + "  N° " + objECaja.Numdoc; ;

            Entidades.Asiento_Detalle asientoDetalle;
            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;

            if (objETipoMovimientoBancario.ComportamientoPredeterminado == 1)
            {
                asientoDetalle.Debe = objEMovimientoBancario.Importe;
                asientoDetalle.Haber = 0;
            }
            else
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = objEMovimientoBancario.Importe;
            }
            objEAsiento.Detalle.Add(asientoDetalle);


            asientoDetalle = new Entidades.Asiento_Detalle();
            if (Singleton.Instancia.Empresa.Codigo == 1 )
                asientoDetalle.CuentaContable.Codigo = 10101010100;
            else if (Singleton.Instancia.Empresa.Codigo == 2)
                asientoDetalle.CuentaContable.Codigo = 10101010600;
            else if (Singleton.Instancia.Empresa.Codigo == 3)
                asientoDetalle.CuentaContable.Codigo = 10101010200;
            else if (Singleton.Instancia.Empresa.Codigo == 4)
                asientoDetalle.CuentaContable.Codigo = 10101010300;
            else if (Singleton.Instancia.Empresa.Codigo == 5)
                asientoDetalle.CuentaContable.Codigo = 10101010400;
            else if (Singleton.Instancia.Empresa.Codigo == 7)
                asientoDetalle.CuentaContable.Codigo = 10101010500;

            if (objETipoMovimientoBancario.ComportamientoPredeterminado == 1)
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = objEMovimientoBancario.Importe;
            }
            else
            {
                asientoDetalle.Debe = objEMovimientoBancario.Importe;
                asientoDetalle.Haber = 0;
            }
            objEAsiento.Detalle.Add(asientoDetalle);


        }
        private bool Validar()
        {
            bool res = false;
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbBancos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaBancaria);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbMovimientos);
            // res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            // res = res || Utilidades.Validar.TextBoxEnBlanco(txtImporte);
            return res;
        }

        private void Comprobante()
        {
            objEMovimientoBancario = new Entidades.MovimientoBancario();

            objEMovimientoBancario.CuentaBancaria.Codigo = Convert.ToInt32(cbCuentaBancaria.SelectedValue);
            /*objEMovimientoBancario.TipoMovimientoBancario.Codigo = Convert.ToInt32(cbMovimientos.SelectedValue);
            objEMovimientoBancario.TipoMovimientoBancario.Descripcion = cbMovimientos.Text.ToString();*/
            objEMovimientoBancario.TipoMovimientoBancario = objETipoMovimientoBancario;
            objEMovimientoBancario.FechaMovimiento = Convert.ToDateTime(dtFecha.Value);
            objEMovimientoBancario.Observaciones = txtObservaciones.Text.Trim();
            objEMovimientoBancario.Importe = Convert.ToDouble(txtImporte.Text.Trim());


            if (objEMovimientoBancario.TipoMovimientoBancario.Codigo == 3 || objEMovimientoBancario.TipoMovimientoBancario.Codigo == 4)
            {
                objECaja = new Entidades.Caja();
                Entidades.Factura_Efectivo facturaEfectivo = new Entidades.Factura_Efectivo();
                facturaEfectivo.Moneda = objECuentaBancaria.Moneda;
                //MessageBox.Show(objECuentaBancaria.Moneda.Descripcion + " " + objECuentaBancaria.Moneda.Cotizacion);


                if (objEMovimientoBancario.TipoMovimientoBancario.ComportamientoPredeterminado == 1)
                {
                    objECaja.TipoDocumentoCaja = objLTipoDocCaja.ObtenerUno(4);
                }
                else
                {
                    objECaja.TipoDocumentoCaja = objLTipoDocCaja.ObtenerUno(3);
                }
                objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
                objECaja.Fecha = objEMovimientoBancario.FechaMovimiento;
                objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
                objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
                objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
                objECaja.Usuario = Singleton.Instancia.Usuario;
                objECaja.PuestoCaja = Singleton.Instancia.Puesto;
                objECaja.Observaciones = txtObservaciones.Text.Trim();
                objECaja.SucursalDestino = Singleton.Instancia.Empresa.Codigo;
                
                //objEMovimientoBancario.Observaciones = objECaja.TipoDocumentoCaja.Descripcion + " " + objECaja.Numdoc + " " + objEMovimientoBancario.Observaciones;

                facturaEfectivo.Importe = objEMovimientoBancario.TipoMovimientoBancario.ComportamientoPredeterminado * objEMovimientoBancario.Importe;
                objECaja.FacturaEfectivo.Add(facturaEfectivo);
                /*
                    
                
                 Convert.ToDouble(fila.Cells["Importe2"].Value);
                listaFacturaEfectivo.Add(facturaEfectivo);*/
            }
        }

        private void cbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMovimientos.SelectedIndex != -1)
            {
                try
                {
                    objETipoMovimientoBancario = objLTipoMovimientoBancario.ObtenerUno(Convert.ToInt32(cbMovimientos.SelectedValue));
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
