using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmChequesRechazadosBanco : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Caja objLCaja = new Logica.Caja();
        Logica.BancoRechazos objLBancoRe = new Logica.BancoRechazos();
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Entidades.BancoRechazados objEBancoRechazados;
        Entidades.Asiento objEAsiento;

        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public frmChequesRechazadosBanco()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            CargarBancos();
        }

        private void Titulo()
        {
            this.Text = "CHEQUES RECHAZADOS";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbBancoCheques);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name.Equals("Seleccionado"))
                {
                    item.ReadOnly = false;
                }
                else {
                    item.ReadOnly = true;
                }
                
            }
          //  dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Banco"].Width = 130;
            dgvDatos.Columns["NroCheque"].Width = 130;
            dgvDatos.Columns["FechaEmision"].Width = 90;
            dgvDatos.Columns["FechaPago"].Width = 90;
        }

        public void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
                if (cbBancos.SelectedValue != null)
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {

                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                // Utilidades.Combo.Llenar(cbExtraccion, objLCaja.ObtenerCajasConCheques(objECuentaBancaria), "Codigo", "Numero");
                Utilidades.Combo.Llenar(cbBancoCheques, objLBanco.ObtenerActivos(), "Codigo", "Descripcion", "Todos");
                cbBancoCheques.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBancoCheques_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla() {
            try
            {
                dgvDatos.DataSource = objLCaja.ObtenerChequesDepositados(objECuentaBancaria, Convert.ToInt32(cbBancoCheques.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (ValidarComprobante().Equals(false))
            {
                MessageBox.Show("Debe seleccionar un cheque para confirmar!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ValidarFechaConciliacionCuenta().Equals(false)) {
                MessageBox.Show("No se puede grabar el Comprobante.\nCuenta Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {

                CargarValores();
                CargarAsiento();
                objLBancoRe.Agregar(objEBancoRechazados, objEAsiento);
                Limpiar();
                MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEBancoRechazados.Fecha;
            objEAsiento.FechaEmision = objEBancoRechazados.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEAsiento.Descripcion = "Cheque Rechazado Comprobante Nro: " + objEBancoRechazados.Numdoc;

            Entidades.Asiento_Detalle asientoDetalle;

            foreach (Entidades.Cheque item in objEBancoRechazados.Cheques)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;
                asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Codigo);
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber=item.Importe;
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105140000;
                asientoDetalle.Debe = item.Importe;
                asientoDetalle.Haber = 0;
                asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Codigo);
                objEAsiento.Detalle.Add(asientoDetalle);
            }           

        }

        private void Limpiar()
        {
            CargarGrilla();
            txtObservacionesIngresos.Text = "";
            dtpFecha.Value = DateTime.Now;
        }

        private void CargarValores()
        {
            objEBancoRechazados = new Entidades.BancoRechazados();
            Entidades.Numerador objENumerador = new Entidades.Numerador();
            objENumerador = new Logica.Numerador().ObtenerUno(27);
            objEBancoRechazados.Letra = Convert.ToChar(objENumerador.Letra);
            objEBancoRechazados.PuntoDeVenta = Convert.ToInt32(objENumerador.PuntoVenta);
            objEBancoRechazados.Numero = Convert.ToInt32(objENumerador.Numero);
            objEBancoRechazados.Fecha = dtpFecha.Value;
            objEBancoRechazados.CuentaBancaria = objECuentaBancaria;
            objEBancoRechazados.Observaciones = txtObservacionesIngresos.Text.Trim();
            objEBancoRechazados.Usuario= Singleton.Instancia.Usuario;

            Entidades.Cheque objECheque;

            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToInt32(item.Cells["Seleccionado"].Value) == 1) {
                    objECheque = new Entidades.Cheque();
                    objECheque.Codigo = Convert.ToInt32(item.Cells["Codigo"].Value);
                    objECheque.Moneda= objLMoneda.ObtenerUno(Convert.ToInt32(item.Cells["CodigoMoneda"].Value));
                    objECheque.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                    objEBancoRechazados.Cheques.Add(objECheque);
                }
            }
        }

        private bool ValidarComprobante()
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToInt32(item.Cells["Seleccionado"].Value)==1)
                    return true;
               /* DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)item.Cells["Seleccionado"].Value;
                if (celda.Value.Equals(true)) {
                    return true;
                }*/
            }
            return false;
        }
        private bool ValidarFechaConciliacionCuenta() {
            if (dtpFecha.Value.Date <= objECuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
