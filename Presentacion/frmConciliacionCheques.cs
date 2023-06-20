using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConciliacionCheques : Presentacion.frmColor
    {
        List<Entidades.MovimientoBancario> movimientos = new List<Entidades.MovimientoBancario>();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Cheque objLCheque = new Logica.Cheque();
        Logica.MovimientoBancario objLMovimiento = new Logica.MovimientoBancario();

        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();

        private double total;
        public frmConciliacionCheques()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
          //  LimitesTamaños();
            Formatos();
            CargarValores();
           /* this.ucFormasPagoCompras.ucContado.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEditar.Click += ActualizarValores;
            this.ucFormasPagoCompras.btnEliminar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequesTerceros.btnChequesTerceros.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucChequePropio.btnAgregar.Click += ActualizarValores;
            this.ucFormasPagoCompras.ucTranferenciasBancarias.btnAgregar.Click += ActualizarValores;*/
        }

        private void Titulo()
        {
            this.Text = "CONCILIACION CHEQUES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;

            dgvDatos.Columns["Seleccionar"].Width = 30;
            dgvDatos.Columns["Banco"].Width = 100;
            dgvDatos.Columns["NroCheque"].Width = 80;
            dgvDatos.Columns["FechaEmision"].Width = 60;
            dgvDatos.Columns["FechaPago"].Width = 60;
            dgvDatos.Columns["Importe"].Width = 100;

            dgvDatos.Columns["Seleccionar"].ReadOnly = false;
            //dgvDatos.MultiSelect = true;
        }

        private void CargarValores() {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
                if (cbBancos.SelectedValue != null)
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                ObtenerCheques();
                CalcularTotal();
                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerCheques() {
            dgvDatos.DataSource=objLCheque.ObtenerParaConciliacion(objECuentaBancaria);
            /*foreach (DataRow dr in objLCheque.ObtenerParaConciliacion(objECuentaBancaria).Rows) {
                dgvDatos.Rows.Add(false, dr["CodigoCheque"], dr["Banco"], dr["CodigoMovimientoBancario"], dr["NroCheque"], dr["FechaEmision"], dr["FechaPago"], dr["Importe"]);
            }*/
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

        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = dtpFecha.Value;
            objEAsiento.FechaEmision = dtpFecha.Value;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = "Conciliacion Cheques " + objEAsiento.Fecha.ToShortDateString();
            /*  else if (objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("CR"))
                  objEAsiento.Descripcion = "Segun Contra Recibo de Pago N° " + objEPago.Numdoc + " de " + lblNombreProveedor.Text;
             */
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;

            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = objECuentaBancaria.CuentaContableValoresDiferidos.Codigo;

                    asientoDetalle.Debe = Convert.ToDouble(item.Cells["Importe"].Value);
                    asientoDetalle.Haber = 0;
                    asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Cells["CodigoCheque"].Value);
                    objEAsiento.Detalle.Add(asientoDetalle);

                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = objECuentaBancaria.CuentaContable.Codigo;

                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Convert.ToDouble(item.Cells["Importe"].Value);
                    asientoDetalle.Cheque.Codigo = Convert.ToInt32(item.Cells["CodigoCheque"].Value);
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }

          
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (e.RowIndex != -1)
            {*/
                if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionar"].Index)
                {
                    DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)dgvDatos.CurrentRow.Cells["Seleccionar"];
                    celda.Value = !Convert.ToBoolean(celda.Value);
                }
                /*if (Convert.ToBoolean(celda.Value))
                {
                    total += Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe"].Value);
                }
                else {
                    total -= Convert.ToDouble(dgvDatos.CurrentRow.Cells["Importe"].Value);
                }*/
                CalcularTotal();
                lblTotal.Text = total.ToString("C2");
          //  }
        }
        private void CalcularTotal() {
            total = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    total += Convert.ToDouble(item.Cells["Importe"].Value);
                }
            }
        }
        private void ObtenerValores()
        {
            movimientos.Clear();
            Entidades.MovimientoBancario movimiento;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    movimiento = new Entidades.MovimientoBancario();
                    movimiento.Codigo = Convert.ToInt32(item.Cells["CodigoMovimientoBancario"].Value);
                    movimiento.CuentaBancaria.Codigo = Convert.ToInt32(cbCuentaBancaria.SelectedValue);
                    movimientos.Add(movimiento);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(false))
            {
                MessageBox.Show("No se pudo guardar ya que no se selleciono ningun cheque!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ObtenerValores();
                CargarAsiento();
                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLMovimiento.Actualizar(movimientos, objEAsiento, Singleton.Instancia.Usuario,objECuentaBancaria);
                ObtenerCheques();
                CalcularTotal();
                lblTotal.Text = total.ToString("C2");
                MessageBox.Show("Conciliacion creada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = total > 0;
            return res;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
