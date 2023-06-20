using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmConciliacionTransacciones : Presentacion.frmColor
    {
        Entidades.Conciliacion objEConciliacion = new Entidades.Conciliacion();
        Entidades.FacturaCompra objEFacturaCompra = new Entidades.FacturaCompra();
        //List<Entidades.Transacciones> tranferencias;
        //List<Entidades.Transacciones> debitoCreditos;

        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        //Logica.Cheque objLCheque = new Logica.Cheque();
        //Logica.MovimientoBancario objLMovimiento = new Logica.MovimientoBancario();
        Logica.PagoCliente objLPagoCliente = new Logica.PagoCliente();
        Logica.ConciliacionesTransacciones objLConciliaciones = new Logica.ConciliacionesTransacciones();
        Logica.Impuesto objLImpuesto = new Logica.Impuesto();
        Logica.TipoDeTarjeta objLTipoDeTarjeta = new Logica.TipoDeTarjeta();
        Logica.Caja objLCaja = new Logica.Caja();

        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        Entidades.TipoDeTarjetas objETipoTarjeta = new Entidades.TipoDeTarjetas();
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        Entidades.MovimientoBancario objEMovimientoBancario = new Entidades.MovimientoBancario();

        private double total, gasto, iva, totalCredito, totalDebito, retIva, retIIBB, gastoCredito, gastoDebito, retGanancias;
        public frmConciliacionTransacciones()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            CargarValores();

            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void Titulo()
        {
            this.Text = "CONCILIACION TRANSACCIONES";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbTipo);
            Utilidades.Combo.Formato(cbFormasDePago);
            Utilidades.Grilla.Formato(dgvDatos);
            //Utilidades.Combo.Formato(cbPeriodo);
            dgvDatos.AutoGenerateColumns = false;

            Utilidades.CajaDeTexto.LimiteTamaño(txtGastosBancarios, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtIVA, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetGanancias, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetIIBB, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtRetIVA, 10);

            dgvDatos.Columns["Seleccionar"].ReadOnly = false;

        }

        private void CargarValores()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
                //   Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(), "Periodo", "Meses");
                if (cbBancos.SelectedValue != null)
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
                DataTable dtt = new Logica.TipoDeTarjeta().ObtenerTodosActivos();


                Utilidades.Combo.Llenar(cbTipo, dtt, "Codigo", "Descripcion");
                Utilidades.Combo.Llenar(cbFormasDePago, new Logica.FormaDePago().ObtenerParaTransacciones(), "Codigo", "Descripcion", "DEBITO Y CREDITO");
                cbFormasDePago.SelectedValue = 0;
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion");
                    // cbSucursales.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                CargarDatos();
                CalculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            if (objEFormaDePago.Codigo == 0 || objEFormaDePago.Codigo == 5)
                ObtenerDebitoCredito();
            else if (objEFormaDePago.Codigo == 1)
            {
                ObtenerEfectivo();
            }
            else if (objEFormaDePago.Codigo == 3)
            {
                ObtenerCheques();
            }
        }
        private void ObtenerEfectivo()
        {
            dgvDatos.DataSource = objLCaja.ObtenerDepositoSucursalesPendientes(objECuentaBancaria, objESucursal);
        }

        private void ObtenerCheques()
        {
            dgvDatos.DataSource = objLCaja.ObtenerDepositoChequesSucursalesPendientes(objECuentaBancaria, objESucursal);
        }
        private void ObtenerDebitoCredito()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                dgvDatos.DataSource = objLPagoCliente.ObtenerDebitosCreditos(objECuentaBancaria, objETipoTarjeta, objEFormaDePago, objESucursal);
            }
            else
            {
                dgvDatos.DataSource = objLPagoCliente.ObtenerDebitosCreditos(objECuentaBancaria, objETipoTarjeta, objEFormaDePago);
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
                    HabilitarTipo(objEFormaDePago);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CalculoTotal();
            //  }
        }
        private void CalcularTotal()
        {
            total = 0;
            gasto = 0;
            totalDebito = 0;
            totalCredito = 0;
            retIva = 0;
            retIIBB = 0;
            gastoCredito = 0;
            retGanancias = 0;
            gastoDebito = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    total += Convert.ToDouble(item.Cells["Importe"].Value);
                    if (Convert.ToInt32(item.Cells["CodigoFormaDePago"].Value) == 7)
                    {
                        totalDebito += Convert.ToDouble(item.Cells["Importe"].Value);
                    }
                    else if (Convert.ToInt32(item.Cells["CodigoFormaDePago"].Value) == 8)
                    {
                        totalCredito += Convert.ToDouble(item.Cells["Importe"].Value);
                    }
                }
            }
            //gasto=txtGastosBancarios.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtGastosBancarios.Text.Trim());
            //gasto = CalcularGasto();
            gasto = txtGastosBancarios.Text.ToString().Equals("") ? 0 : Convert.ToDouble(txtGastosBancarios.Text);
            iva = CalcularIVA();
            retIva = txtRetIVA.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRetIVA.Text);
            //retIva = CalcularRetIVA();
            retIIBB = txtRetIIBB.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRetIIBB.Text);
            //retIIBB = CalcularRetIIBB();
            retGanancias = txtRetGanancias.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtRetGanancias.Text);
            //retGanancias = CalcularRetGanancias();
            total = total - gasto - iva - retIva - retIIBB - retGanancias;

        }

        private void CalcularSoloTotal()
        {
            total = 0;
            gasto = 0;
            totalDebito = 0;
            totalCredito = 0;
            retIva = 0;
            retIIBB = 0;
            gastoCredito = 0;
            retGanancias = 0;
            gastoDebito = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    total += Convert.ToDouble(item.Cells["Importe"].Value);
                    if (Convert.ToInt32(item.Cells["CodigoFormaDePago"].Value) == 7)
                    {
                        totalDebito += Convert.ToDouble(item.Cells["Importe"].Value);
                    }
                    else if (Convert.ToInt32(item.Cells["CodigoFormaDePago"].Value) == 8)
                    {
                        totalCredito += Convert.ToDouble(item.Cells["Importe"].Value);
                    }
                }
            }
            gasto = txtGastosBancarios.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtGastosBancarios.Text.Trim());
            //gasto = CalcularGasto();
            iva = CalcularIVA();
            retIva = Convert.ToDouble(txtRetIVA.Text.Equals("") ? 0 : Convert.ToDouble(txtRetIVA.Text));//CalcularRetIVA();
            retIIBB = Convert.ToDouble(txtRetIIBB.Text.Equals("") ? 0 : Convert.ToDouble(txtRetIIBB.Text));//CalcularRetIIBB();
            retGanancias = Convert.ToDouble(txtRetGanancias.Text.Equals("") ? 0 : Convert.ToDouble(txtRetGanancias.Text));//CalcularRetGanancias();
            total = total - gasto - iva - retIva - retIIBB - retGanancias;

        }
        private double CalcularGasto()
        {
            gastoDebito = CalcularGastoDebito();
            gastoCredito = CalcularGastoCredito();
            return gastoDebito + gastoCredito;
        }

        private double CalcularGastoDebito()
        {
            return Utilidades.Redondear.DosDecimales(totalDebito * 0.8 / 100);
        }

        private double CalcularGastoCredito()
        {
            return Utilidades.Redondear.DosDecimales(totalCredito * 1.8 / 100);
        }
        private double CalcularRetIVA()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                if (totalDebito + totalCredito > 2500)
                    return Utilidades.Redondear.DosDecimales(CalcularRetIVADebito() + CalcularRetIVACredito());
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        private double CalcularRetGanancias()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                if (CalcularRetGananciasDebito() + CalcularRetGananciasCredito() > 90)
                    return CalcularRetGananciasDebito() + CalcularRetGananciasCredito();
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        private double CalcularRetIIBB()
        {
            if (Convert.ToInt32(cbTipo.SelectedValue) == 2)
            {
                return Utilidades.Redondear.DosDecimales(((totalDebito + totalCredito) - gasto - iva) * (3.75 / 100));
            }
            else
            {
                return 0;
            }
        }
        private double CalcularRetIVADebito()
        {
            if (Convert.ToInt32(cbTipo.SelectedValue) == 2)
            {
                return Utilidades.Redondear.DosDecimales((totalDebito - gastoDebito) * (0.5 / 100));
            }
            else
            {
                return Utilidades.Redondear.DosDecimales((totalDebito - gastoDebito - Utilidades.Redondear.DosDecimales(gastoDebito * 21 / 100)) * (0.5 / 100));
            }
        }
        private double CalcularRetIVACredito()
        {
            if (Convert.ToInt32(cbTipo.SelectedValue) == 2)
            {
                return Utilidades.Redondear.DosDecimales((totalCredito - gastoCredito) * ((double)1 / 100));
            }
            else
            {
                return Utilidades.Redondear.DosDecimales((totalCredito - gastoCredito - Utilidades.Redondear.DosDecimales(gastoCredito * 21 / 100)) * ((double)1 / 100));
            }
        }

        private double CalcularRetGananciasDebito()
        {
            return Utilidades.Redondear.DosDecimales((totalDebito - gastoDebito) * (0.5 / 100));
        }
        private double CalcularRetGananciasCredito()
        {
            return Utilidades.Redondear.DosDecimales((totalCredito - gastoCredito) * ((double)1 / 100));
        }
        private double CalcularIVA()
        {
            return Utilidades.Redondear.DosDecimales(gasto * 21 / 100);
        }


        private void ObtenerValores()
        {
            objEConciliacion = new Entidades.Conciliacion();
            objEConciliacion.Fecha = dtpFecha.Value;
            objEConciliacion.Usuario = Singleton.Instancia.Usuario;

            Entidades.Transacciones transacciones;
            Entidades.DepositoSucursalesEfectivo depositoEfectivo;
            Entidades.DepositoSucursalesCheques depositoCheques;
            int renglon = 0;
            if (Convert.ToInt32(cbFormasDePago.SelectedValue) == 0)
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        transacciones = new Entidades.Transacciones();
                        transacciones.Renglon = ++renglon;
                        transacciones.FormaDePago.Codigo = Convert.ToInt32(item.Cells["CodigoFormaDePago"].Value);
                        transacciones.CodigoPago = Convert.ToInt32(item.Cells["CodigoPago"].Value);
                        transacciones.RenglonPago = Convert.ToInt32(item.Cells["Renglon"].Value);
                        if (Singleton.Instancia.Empresa.Codigo == 1)
                            transacciones.Observaciones = "Sucursal: " + cbSucursales.Text + " Tipo: " + cbTipo.Text + " Nro Cupon: " + item.Cells["NroCupon"].Value;
                        else
                            transacciones.Observaciones = "Tipo: " + cbTipo.Text + " Nro Cupon: " + item.Cells["NroCupon"].Value;
                        transacciones.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                        transacciones.TipoDeTarjetas = objLTipoDeTarjeta.ObtenerUno(Convert.ToInt32(item.Cells["CodigoTipoTarjeta"].Value), objEBanco);//objETipoTarjeta;
                        transacciones.NroCupon = item.Cells["NroCupon"].Value.ToString();
                        transacciones.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                        objEConciliacion.DebitoCreditos.Add(transacciones);
                    }
                }
            }
            else if(Convert.ToInt32(cbFormasDePago.SelectedValue) == 5)
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        transacciones = new Entidades.Transacciones();
                        transacciones.Renglon = ++renglon;
                        transacciones.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
                        transacciones.TipoMovimientoBancario.Codigo = Convert.ToInt32(item.Cells["CodigoTipoMovimientoBancario"].Value);
                        transacciones.CodigoPago = Convert.ToInt32(item.Cells["CodigoPago"].Value);
                        transacciones.RenglonPago = Convert.ToInt32(item.Cells["Renglon"].Value);
                        if (Singleton.Instancia.Empresa.Codigo == 1)
                            transacciones.Observaciones = "Sucursal: " + cbSucursales.Text + " Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        else
                            transacciones.Observaciones = "Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        transacciones.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                        transacciones.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                        objEConciliacion.Tranferencias.Add(transacciones);
                    }
                }
            }
            else if (Convert.ToInt32(cbFormasDePago.SelectedValue) == 1)
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        depositoEfectivo = new Entidades.DepositoSucursalesEfectivo();
                        depositoEfectivo.Renglon = ++renglon;
                        depositoEfectivo.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
                        depositoEfectivo.TipoMovimientoBancario.Codigo = Convert.ToInt32(item.Cells["CodigoTipoMovimientoBancario"].Value);
                        depositoEfectivo.CodigoCaja = Convert.ToInt32(item.Cells["CodigoCaja"].Value);
                        
                        if (Singleton.Instancia.Empresa.Codigo == 1)
                            depositoEfectivo.Observaciones = "Sucursal: " + cbSucursales.Text + " Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        else
                            depositoEfectivo.Observaciones = "Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        depositoEfectivo.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                        depositoEfectivo.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                        objEConciliacion.DepositoSucursalesEfectivos.Add(depositoEfectivo);
                    }
                }
            }
            else if (Convert.ToInt32(cbFormasDePago.SelectedValue) == 3)
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        depositoCheques = new Entidades.DepositoSucursalesCheques();
                        depositoCheques.Renglon = ++renglon;
                        depositoCheques.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
                        depositoCheques.TipoMovimientoBancario.Codigo = Convert.ToInt32(item.Cells["CodigoTipoMovimientoBancario"].Value);
                        depositoCheques.CodigoCaja = Convert.ToInt32(item.Cells["CodigoCaja"].Value);

                        if (Singleton.Instancia.Empresa.Codigo == 1)
                            depositoCheques.Observaciones = "Sucursal: " + cbSucursales.Text + " Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        else
                            depositoCheques.Observaciones = "Cliente: " + item.Cells["Cliente"].Value + " Nro Comp:" + item.Cells["Numero"].Value;
                        depositoCheques.CuentaContable.Codigo = Convert.ToInt64(item.Cells["CodigoCuentaContable"].Value);
                        depositoCheques.Cheque.Codigo = Convert.ToInt32(item.Cells["CodigoCheque"].Value);
                        depositoCheques.Cheque.Banco.Codigo = Convert.ToInt32(item.Cells["CodigoBancoCheque"].Value);
                        depositoCheques.Cheque.NumeroCheque = item.Cells["NroCheque"].Value.ToString();
                        depositoCheques.Cheque.FechaEmision = Convert.ToDateTime(item.Cells["FechaEmision"].Value);
                        depositoCheques.Cheque.FechaPago = Convert.ToDateTime(item.Cells["FechaPago"].Value);
                        depositoCheques.Cheque.Librador = item.Cells["Librador"].Value.ToString();
                        depositoCheques.Cheque.Cuit =item.Cells["Cuit"].Value.ToString();
                        depositoCheques.Cheque.Moneda.Codigo = Convert.ToInt32(item.Cells["CodigoMonedaCheque"].Value);
                        depositoCheques.Cheque.Moneda.Cotizacion = Convert.ToDouble(item.Cells["CotizacionCheque"].Value);
                        depositoCheques.Cheque.Importe = Convert.ToDouble(item.Cells["Importe"].Value);
                        objEConciliacion.DepositoSucursalesCheques.Add(depositoCheques);
                    }
                }
            }
            objEConciliacion.Gastos = gasto;
            objEConciliacion.IVA = iva;
            Entidades.FacturaImpuesto objEImpuestos;

            if (retIva != 0)
            {
                objEImpuestos = new Entidades.FacturaImpuesto();
                objEImpuestos.Impuesto = objLImpuesto.ObtenerUno(3);
                objEImpuestos.Importe = retIva;
                objEConciliacion.Impuestos.Add(objEImpuestos);
            }
            if (retIIBB != 0)
            {
                objEImpuestos = new Entidades.FacturaImpuesto();
                objEImpuestos.Impuesto = objLImpuesto.ObtenerUno(4);
                objEImpuestos.Importe = retIIBB;
                objEConciliacion.Impuestos.Add(objEImpuestos);
            }
            if (retGanancias != 0)
            {
                objEImpuestos = new Entidades.FacturaImpuesto();
                objEImpuestos.Impuesto = objLImpuesto.ObtenerUno(5);
                objEImpuestos.Importe = retGanancias;
                objEConciliacion.Impuestos.Add(objEImpuestos);
            }
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(false))
            {
                MessageBox.Show("No se pudo guardar ya que no se seleciono nunguna Transaccion!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (cbSucursales.Visible == false)
                {
                    objESucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
                }
                ObtenerValores();
                if (objEFormaDePago.Codigo == 0)
                {
                    CargarAsiento();
                    //CargarFacturaCompra();
                }
                if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                objLConciliaciones.Agregar(objEFormaDePago, objESucursal, objECuentaBancaria, objEConciliacion, Singleton.Instancia.Usuario, objEAsiento, objETipoTarjeta.Proveedor, Singleton.Instancia.Puesto, dtFechaContable.Value.Date);
                //  objLMovimiento.Actualizar(movimientos, objEAsiento,Singleton.Instancia.Usuario);
                //objLConciliaciones.Agregar(objEFormaDePago, objESucursal, objECuentaBancaria, dtpFecha.Value, Singleton.Instancia.Usuario, tranferencias, debitoCreditos, gasto, iva, retIIBB,retIva);
                //objLConciliaciones.Agregar(objEFormaDePago, objEConciliacion);
                CargarDatos();
                CalculoTotal();
                MessageBox.Show("Conciliacion creada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGastosBancarios.Text = "";
                txtRetGanancias.Text = "";
                txtRetIIBB.Text = "";
                txtRetIVA.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void CargarFacturaCompra() {
            objEFacturaCompra = new Entidades.FacturaCompra();
   
            objEFacturaCompra.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
   
            objEFacturaCompra.TipoDocumentoProveedor.Codigo = 2;
            //objEFacturaCompra.Numero = ucNumeroComprobante.ValorConFormato;
            objEFacturaCompra.Proveedor.Codigo = objETipoTarjeta.Proveedor.Codigo;
            objEFacturaCompra.FechaEmision = objEConciliacion.FechaConciliacion;
            objEFacturaCompra.FechaContable = objEConciliacion.FechaConciliacion;
            objEFacturaCompra.TipoCompra = "G";

            objEFacturaCompra.Neto1 = objEConciliacion.Gastos;
            objEFacturaCompra.DescripImp1 = 21.00;
            objEFacturaCompra.ImporteImp1 = objEConciliacion.IVA;
                       
                    
                

           
            objEFacturaCompra.Usuario = Singleton.Instancia.Usuario;
            objEFacturaCompra.PuestoCaja = Singleton.Instancia.Puesto;
            objEFacturaCompra.Impuestos.Clear();
            objEFacturaCompra.Impuestos = objEConciliacion.Impuestos;

                objEFacturaCompra.Imputacion = 'T';
       
    }*/
        private void CargarAsiento()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = dtFechaContable.Value;
            objEAsiento.FechaEmision = dtpFecha.Value;
            string des = (objEFormaDePago.Codigo == 0 ? "DEBITO Y CREDITO" : objEFormaDePago.Descripcion);
            objEAsiento.Descripcion = "Conciliación " + des;
            if (cbTipo.Enabled == true)
            {
                objEAsiento.Descripcion += " " + objETipoTarjeta.Descripcion;
            }
            objEAsiento.Sucursal = objESucursal.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;
            double sum = 0;
            long cuentaContable = 0;
            foreach (Entidades.Transacciones item in objEConciliacion.DebitoCreditos)
            {
                sum += item.Importe;
                cuentaContable = item.CuentaContable.Codigo;
            }
            /*foreach (Entidades.Transacciones item in objEConciliacion.Tranferencias)
            {
                sum += item.Importe;
                
                cuentaContable = item.CuentaContable.Codigo;
            }*/
            if (sum > 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = cuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(sum);
                objEAsiento.Detalle.Add(asientoDetalle);


                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;
                asientoDetalle.Debe = Math.Abs(Utilidades.Redondear.DosDecimales(sum - iva - retIva - retIIBB - gasto - retGanancias));
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);


                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 50103010101;
                asientoDetalle.Debe = Math.Abs(objEConciliacion.Gastos);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105010000;
                asientoDetalle.Debe = Math.Abs(iva);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);

                foreach (Entidades.FacturaImpuesto item in objEConciliacion.Impuestos)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable = item.Impuesto.CuentaContable;
                    asientoDetalle.Debe = Math.Abs(item.Importe);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }
            else if (sum < 0)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = cuentaContable;
                asientoDetalle.Debe = Math.Abs(sum);
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);


                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(Utilidades.Redondear.DosDecimales(sum - iva - retIva - retIIBB - gasto));
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 50103010101;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(objEConciliacion.Gastos);
                objEAsiento.Detalle.Add(asientoDetalle);

                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105010000;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Math.Abs(iva);
                objEAsiento.Detalle.Add(asientoDetalle);

                foreach (Entidades.FacturaImpuesto item in objEConciliacion.Impuestos)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable = item.Impuesto.CuentaContable;
                    asientoDetalle.Debe = 0;
                    asientoDetalle.Haber = Math.Abs(item.Importe);
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
            }


        }

        private bool Validar()
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                {
                    return true;
                }

            }
            return false;
        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {
            //CalculoTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRetIIBB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRetIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtRetIIBB_TextChanged(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void Cargar()
        {
            CalcularSoloTotal();
            txtGastosBancarios.Text = gasto.ToString(); //gasto.ToString("C2");
            txtIVA.Text = iva.ToString();//iva.ToString("C2");
            txtRetIVA.Text = retIva.ToString();
            txtRetIIBB.Text = retIIBB.ToString();
            txtRetGanancias.Text = retGanancias.ToString();
            lblTotal.Text = total.ToString("C2");
        }
        private void txtRetIVA_TextChanged(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void txtRetGanancias_TextChanged(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void frmConciliacionTransacciones_Load(object sender, EventArgs e)
        {

        }

        private void txtRetIIBB_Leave(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtGastosBancarios_Leave(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtRetIVA_Leave(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtRetGanancias_Leave(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objETipoTarjeta.Codigo = Convert.ToInt32(cbTipo.SelectedValue);
                CargarDatos();
                CalculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEFormaDePago.Codigo = Convert.ToInt32(cbFormasDePago.SelectedValue);
                /* switch (objEFormaDePago.Codigo)
                 {
                     case 0:
                         cbTipo.Visible = true;
                         cbTipo.Enabled = true;
                         dtFechaContable.Enabled = true;
                         break;
                     case 1:
                     case 3:
                     case 5:
                         cbTipo.Visible = false;
                         label3.Visible = false;
                         cbTipo.Enabled = false;
                         dtFechaContable.Enabled = false;
                         break;
                 }*/
                HabilitarTipo(objEFormaDePago);
                Grilla(objEFormaDePago.Codigo);
                CargarDatos();
                CalculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void HabilitarTipo(Entidades.FormaDePago objEFormaDePago)
        {
            if (objEFormaDePago.Codigo == 5)
            {
                cbTipo.Enabled = false;
                dtFechaContable.Enabled = false;
            }
            else if ((objEBanco.Codigo == 5001 && (Singleton.Instancia.Empresa.Codigo == 1 || Singleton.Instancia.Empresa.Codigo == 10)))
            {
                cbTipo.Enabled = false;
                // dtFechaContable.Enabled = false;
            }
            else
            {
                cbTipo.Enabled = true;
                dtFechaContable.Enabled = true;
            }
        }
        void Grilla(int pCodigoFormaDePago)
        {
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Seleccionar"].Width = 30;
            dgvDatos.Columns["Cheque"].Visible = false;
            dgvDatos.Columns["FormaDePago"].Visible = false;
            dgvDatos.Columns["TipoMovimientoBancario"].Visible = false;
            dgvDatos.Columns["NroCupon"].Visible = false;
            dgvDatos.Columns["Cliente"].Visible = false;

            txtRetIVA.Enabled = false;
            txtRetIIBB.Enabled = false;
            txtRetGanancias.Enabled = false;
            txtGastosBancarios.Enabled = false;

            dgvDatos.Columns["Numero"].Width = 102;

            if (pCodigoFormaDePago == 0)
            {
                dgvDatos.Columns["FormaDePago"].Visible = true;
                dgvDatos.Columns["FormaDePago"].Width = 100;
                dgvDatos.Columns["NroCupon"].Visible = true;
                dgvDatos.Columns["NroCupon"].Width = 100;
                dgvDatos.Columns["Tipo"].Visible = true;
                dgvDatos.Columns["Tipo"].Width = 100;
                //dgvDatos.Columns["Numero"].Width = 200;
                txtRetIVA.Enabled = true;
                txtRetIIBB.Enabled = true;
                txtRetGanancias.Enabled = true;
                txtGastosBancarios.Enabled = true;
            }
            else if (pCodigoFormaDePago == 5)
            {

                dgvDatos.Columns["TipoMovimientoBancario"].Visible = true;
                dgvDatos.Columns["TipoMovimientoBancario"].Width = 105;

                dgvDatos.Columns["Cliente"].Visible = true;
                dgvDatos.Columns["Cliente"].Width = 170;
                dgvDatos.Columns["Tipo"].Visible = false;

            }
            else if (pCodigoFormaDePago == 1)
            {
                dgvDatos.Columns["TipoMovimientoBancario"].Visible = true;
                dgvDatos.Columns["TipoMovimientoBancario"].Width = 130;
                dgvDatos.Columns["Tipo"].Visible = false;


            }
            else if (pCodigoFormaDePago == 3)
            {

                dgvDatos.Columns["TipoMovimientoBancario"].Visible = true;
                dgvDatos.Columns["TipoMovimientoBancario"].Width = 130;

                dgvDatos.Columns["Cheque"].Visible = true;
                dgvDatos.Columns["Cheque"].Width = 210;
                dgvDatos.Columns["Tipo"].Visible = false;
                dgvDatos.Columns["Numero"].Width = 90;
            }
            
            dgvDatos.Columns["Importe"].Width = 100;
            dgvDatos.Columns["Fecha"].Width = 75;

            txtRetIVA.Text = "";
            txtRetIIBB.Text = "";
            txtRetGanancias.Text = "";
            txtGastosBancarios.Text = "";
        }
        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                CargarDatos();
                CalculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //objETipoTarjeta = objLTipoDeTarjeta.ObtenerUno(Convert.ToInt32(cbTipo.SelectedValue));
                objETipoTarjeta = objLTipoDeTarjeta.ObtenerUno(Convert.ToInt32(cbTipo.SelectedValue), objEBanco);
                CargarDatos();
                CalculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGastosBancarios_TextChanged(object sender, EventArgs e)
        {
            //CalculoTotal();
        }

        void CalculoTotal()
        {
            CalcularTotal();
            txtGastosBancarios.Text = gasto.ToString();//gasto.ToString("C2");
            txtIVA.Text = iva.ToString(); //iva.ToString("C2");
            txtRetIVA.Text = retIva.ToString();//retIva.ToString();
            txtRetIIBB.Text = retIIBB.ToString();//retIIBB.ToString();
            txtRetGanancias.Text = retGanancias.ToString();
            lblTotal.Text = total.ToString("C2");
        }
        private void txtGastosBancarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}
