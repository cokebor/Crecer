using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPrestamosBancarios : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.FrecuenciaDePago objLFPago = new Logica.FrecuenciaDePago();

        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.FrecuenciaDePago objEFPago = new Entidades.FrecuenciaDePago();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public frmPrestamosBancarios()
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
            this.Text = "PRESTAMOS BANCARIOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtValorPrestamo, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtTNA, 5);
        }
        private void Formato()
        {
            dtFechaOtorgamiento.Value = DateTime.Now;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.TabControl.Formato(tcPrestamos, frmColor.Color);
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
            //tcPagosProveedores.TabPages.Remove(tpImputacion);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbSistemasAmortizacion);
            Utilidades.Combo.Formato(cbFrencuenciaPago);
            Utilidades.Combo.Formato(cbPeriodoDeGracia);
            Utilidades.Grilla.Formato(dgvTablaAmortizacion);

            dgvTablaAmortizacion.AllowUserToOrderColumns = false;
            dgvTablaAmortizacion.AutoGenerateColumns = false;
            //  dgvTablaAmortizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTablaAmortizacion.Columns["Cuota"].Width = 40;
            dgvTablaAmortizacion.Columns["Fecha"].Width = 65;
            dgvTablaAmortizacion.Columns["CapitalAmortizado"].Width = 90;
            dgvTablaAmortizacion.Columns["Interes"].Width = 80;
            dgvTablaAmortizacion.Columns["IVA"].Width = 70;
            dgvTablaAmortizacion.Columns["CuotaAPagar"].Width = 85;
            dgvTablaAmortizacion.Columns["CapitalPendiente"].Width = 95;

            dgvTablaAmortizacion.Columns["CapitalAmortizado"].ReadOnly = false;
            dgvTablaAmortizacion.Columns["Interes"].ReadOnly = false;
            dgvTablaAmortizacion.Columns["IVA"].ReadOnly = false;
        }

        private void txtValorPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
        public void CargarValores()
        {
            try
            {
                CargarBancos();
                CargarSistemasAmortizacion();
                CargarFrecuenciasDePago();
                CargarPeriodosDeGracia();
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
        public void CargarSistemasAmortizacion()
        {
            Utilidades.Combo.Llenar(cbSistemasAmortizacion, new Logica.SistemaAmortizacion().ObtenerTodos(), "Codigo", "Descripcion");
        }

        public void CargarPeriodosDeGracia()
        {
            Utilidades.Combo.Llenar(cbPeriodoDeGracia, new Logica.PeriodoDeGracia().ObtenerTodos(), "Codigo", "Descripcion");

        }

        public void CargarFrecuenciasDePago()
        {
            Utilidades.Combo.Llenar(cbFrencuenciaPago, objLFPago.ObtenerTodos(), "Codigo", "Descripcion");
            cbFrencuenciaPago.SelectedIndex = 3;
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

        private void cbFrencuenciaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFrencuenciaPago.SelectedIndex != -1)
            {
                try
                {
                    objEFPago = objLFPago.ObtenerUno(Convert.ToInt32(cbFrencuenciaPago.SelectedValue));
                    tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
                    dgvTablaAmortizacion.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbPeriodoDeGracia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cbPeriodoDeGracia.SelectedValue) == 1)
            {
                /*    nudCantidadPeriodosGracia.Minimum = 0;
                    nudCantidadPeriodosGracia.Value = 0;
                    nudCantidadPeriodosGracia.Enabled = false;*/
                cbInteresPeriodoDeGracia.Checked = false;
                cbInteresPeriodoDeGracia.Enabled = false;
            }
            else if (Convert.ToInt32(cbPeriodoDeGracia.SelectedValue) == 2)
            {
                /*   nudCantidadPeriodosGracia.Minimum = 1;
                   nudCantidadPeriodosGracia.Value = 1;
                   nudCantidadPeriodosGracia.Enabled = true;*/
                cbInteresPeriodoDeGracia.Checked = false;
                cbInteresPeriodoDeGracia.Enabled = true;
            }
            else if (Convert.ToInt32(cbPeriodoDeGracia.SelectedValue) == 3)
            {
                /*nudCantidadPeriodosGracia.Minimum = 1;
                nudCantidadPeriodosGracia.Value = 1;
                nudCantidadPeriodosGracia.Enabled = true;*/
                cbInteresPeriodoDeGracia.Checked = false;
                cbInteresPeriodoDeGracia.Enabled = false;
            }
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
            dgvTablaAmortizacion.DataSource = null;
        }

        Entidades.PrestamoBancario objEPrestamo;
        private void btnSimular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
                    tcPrestamos.TabPages.Add(tpTablaAmortizacion);
                    tpTablaAmortizacion.BackColor = frmColor.Color;
                    
                    
                    if (Convert.ToInt32(cbSistemasAmortizacion.SelectedValue) == 1)
                    {

                        //dgvTablaAmortizacion.Rows.Clear(); 

                        CargarDatos();
                        
                        DataTable dt = CrearDataTableFrances();
                        dt.Rows.Add("I", "0", null, 0, 0, 0, 0, objEPrestamo.Capital);
                        if (!cbInteresPeriodoDeGracia.Checked)
                        {
                            //dt = 
                            dt = AgregarPeriodosGracia(dt);
                            dt = AgregarCuotas(dt, 0.105);
                        }
                        else
                        {
                            dt = AgregarCuotas(dt, 0.12);
                        }

                        dt = AgregarTotal(dt);


                        //int cantPerGracia =  (int)nudCantidadPeriodosGracia.Value;

                        /*if (cantPerGracia > 0) {
                            dt = AgregarPeriodosGracia(dt, Convert.ToInt32(cbPeriodoDeGracia.SelectedValue), cantPerGracia);
                        }*/

                        dgvTablaAmortizacion.DataSource = dt;
                        tcPrestamos.SelectedTab = tpTablaAmortizacion;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos() {
            objEPrestamo = new Entidades.PrestamoBancario();
            objEPrestamo.FechaOtorgamiento = dtFechaOtorgamiento.Value.Date;
            objEPrestamo.Cuentabancaria = objECuentaBancaria;
            Entidades.SistemaAmortizacion objESA = new Entidades.SistemaAmortizacion();
            objESA.Codigo = Convert.ToInt32(cbSistemasAmortizacion.SelectedValue);
            objEPrestamo.SistemaAmortizacion = objESA;
            objEPrestamo.Capital = Convert.ToDouble(txtValorPrestamo.Text.Trim());
            objEPrestamo.FrecuenciaPago = objEFPago;
            objEPrestamo.CantCuotas = Convert.ToInt32(nupCuotas.Value);
            objEPrestamo.TNA = Convert.ToDouble(txtTNA.Text.Trim());
            Entidades.PeriodoDeGracia objEPeriodoGracia = new Entidades.PeriodoDeGracia();
            objEPeriodoGracia.Codigo = Convert.ToInt32(cbPeriodoDeGracia.SelectedValue);
            //objEPeriodoGracia.Descripcion = cbPeriodoDeGracia.Text;
            objEPrestamo.PeriodoDeGracia = objEPeriodoGracia;
            objEPrestamo.FechaPrimerCuota = dtpFechaPrimerCuota.Value.Date;
            objEPrestamo.PagarEnUnaCUota = cbInteresPeriodoDeGracia.Checked;

            
         
        }

        private void CargarTabla() {
            List<Entidades.TablaAmortizacion> tablaAmortizacion = new List<Entidades.TablaAmortizacion>();
            Entidades.TablaAmortizacion elemento;
            foreach (DataGridViewRow item in dgvTablaAmortizacion.Rows)
            {
                elemento = new Entidades.TablaAmortizacion();

               if (!item.Cells["Cuota"].Value.Equals(""))
                {

                    if (!item.Cells["Cuota"].Value.Equals("0"))
                    {
                        if (!item.Cells["Tipo"].Value.Equals("T"))
                        {
                            elemento.Cuota = Convert.ToInt32(item.Cells["Cuota"].Value);
                            elemento.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
                            elemento.CapitalAmortizado = Convert.ToDouble(item.Cells["CapitalAmortizado"].Value);
                            elemento.Interes = Convert.ToDouble(item.Cells["Interes"].Value);
                            elemento.IVA = Convert.ToDouble(item.Cells["IVA"].Value);
                            elemento.CuotaAPagar = Convert.ToDouble(item.Cells["CuotaAPagar"].Value);
                            elemento.CapitalPendiente = Convert.ToDouble(item.Cells["CapitalPendiente"].Value);
                            elemento.Estado = false;
                            tablaAmortizacion.Add(elemento);
                        }
                    }
                }
            }
            objEPrestamo.TablaAmortizacion = tablaAmortizacion;
            }
        private void CargarAsientos()
        {
            objEPrestamo.Asiento = new Entidades.Asiento();
            objEPrestamo.Asiento.Fecha = objEPrestamo.FechaOtorgamiento;
            objEPrestamo.Asiento.FechaEmision = objEPrestamo.FechaOtorgamiento;
            objEPrestamo.Asiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            objEPrestamo.Asiento.Descripcion = "Prestamo Bancario";
            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContable;
            asientoDetalle.Debe = Math.Abs(objEPrestamo.Capital);
            asientoDetalle.Haber = 0;
            objEPrestamo.Asiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable = objECuentaBancaria.CuentaContablePrestamos;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = Math.Abs(objEPrestamo.Capital);
            objEPrestamo.Asiento.Detalle.Add(asientoDetalle);
        }
        private DataTable AgregarCuotas(DataTable dt, double pIva)
        {
            DateTime fecha = objEPrestamo.FechaPrimerCuota;
            double anualidad = Utilidades.Redondear.DosDecimales(objEPrestamo.Anualidad);
            double capitalPendiente = objEPrestamo.Capital;
            double capitalAmortizado = 0;
            double ta = objEPrestamo.Tasa;
            double inte = 0;
            double iva = 0;
            int filas = dt.Rows.Count;
            for (int i = filas; i <= objEPrestamo.CantCuotas + filas - 1; i++)
            {
                inte = Utilidades.Redondear.DosDecimales(capitalPendiente * ta);
                //Aca a lo mejor tenemos que restar el iva tambien
                capitalAmortizado = Utilidades.Redondear.DosDecimales(anualidad - inte);
                if (i == 1)
                {
                    inte += objEPrestamo.InteresGratificacion;
                }
                iva = Utilidades.Redondear.DosDecimales(inte * pIva);
                capitalPendiente = Utilidades.Redondear.DosDecimales(capitalPendiente - capitalAmortizado);
                //Capital Amortizado - iNTERES - iVA - cUOTA A pAGAR - cAPITAL pENDIENTE
                dt.Rows.Add("C", i, fecha, capitalAmortizado, inte, iva, capitalAmortizado + inte + iva, capitalPendiente);
                fecha = fecha.AddMonths(1);
            }
            return dt;
        }
        private DataTable AgregarTotal(DataTable dt)
        {
            double ca = 0;
            double i = 0;
            double iv = 0;
            double cap = 0;
            foreach (DataRow item in dt.Rows)
            {
                ca += Convert.ToDouble(item["CapitalAmortizado"]);
                i += Convert.ToDouble(item["Interes"]);
                iv += Convert.ToDouble(item["IVA"]);
                cap += Convert.ToDouble(item["CuotaAPagar"]);
            }

            dt.Rows.Add("T", null, null, Utilidades.Redondear.DosDecimales(ca), Utilidades.Redondear.DosDecimales(i), Utilidades.Redondear.DosDecimales(iv), Utilidades.Redondear.DosDecimales(cap), 0);
            return dt;


        }
        /* private DataTable AgregarCuotas(DataTable dt) {
              DateTime fecha = objEPrestamo.FechaPrimerCuota;
              double anualidad = objEPrestamo.Anualidad;
              double capitalPendiente = objEPrestamo.Capital;
              double capitalAmortizado = 0;
              double ta = objEPrestamo.Tasa;
              double inte=0;
              double iva = 0;
              for (int i = 1; i <= objEPrestamo.CantCuotas; i++)
              {
                  inte=Utilidades.Redondear.DosDecimales(capitalPendiente * ta);
                  capitalAmortizado = anualidad - inte;
                  if (i == 1)
                  {
                      inte += objEPrestamo.InteresGratificacion;
                  }
                  iva = Utilidades.Redondear.DosDecimales(inte * 0.12);
                  capitalPendiente = capitalPendiente - capitalAmortizado;
                  //Capital Amortizado - iNTERES - iVA - cUOTA A pAGAR - cAPITAL pENDIENTE
                  dt.Rows.Add("C",i, fecha, capitalAmortizado, inte,iva ,capitalAmortizado+inte+iva, capitalPendiente);
                  fecha = fecha.AddMonths(1);
              }
              return dt;
          }*/

        //        private DataTable AgregarPeriodosGracia(DataTable dt, int pTipoPeriodoGracia,int pCantPerio)
        private DataTable AgregarPeriodosGracia(DataTable dt)
        {
            DateTime f = objEPrestamo.FechaOtorgamiento.AddMonths(1);
            f = Convert.ToDateTime(objEPrestamo.FechaPrimerCuota.Day + "/" + f.Month + "/" + f.Year);

            int meses = Math.Abs((objEPrestamo.FechaPrimerCuota.Month - f.Month) + 12 * (objEPrestamo.FechaPrimerCuota.Year - f.Year));
            


            double inte = 0;
            double iva = 0;
            double ta = objEPrestamo.Tasa;
            switch (Convert.ToInt32(cbPeriodoDeGracia.SelectedValue))
            {

                case 2:



                    for (int i = 1; i <= meses; i++)
                    {
                        if (i == 1)
                        {
                            inte = objEPrestamo.InteresGratificacion;
                        }
                        else
                        {
                            inte = Utilidades.Redondear.DosDecimales(objEPrestamo.Capital * ta);
                        }
                        iva = Utilidades.Redondear.DosDecimales(inte * 0.105);
                        dt.Rows.Add("G", i, f, 0, inte, iva, inte + iva, objEPrestamo.Capital);
                        f = f.AddMonths(1);

                    }
                    break;
                case 3:
                    double c= objEPrestamo.Capital;
                    for (int i = 1; i <= meses; i++)
                    {
                        if (i == 1)
                        {
                            inte = objEPrestamo.InteresGratificacion;
                        }
                        else
                        {
                            inte = Utilidades.Redondear.DosDecimales(c * ta);
                        }
                        //iva = Utilidades.Redondear.DosDecimales(inte * 0.105);
                        c += inte;
                        dt.Rows.Add("G", i, f, 0, 0, 0, 0, c);
                        f = f.AddMonths(1);

                    }
                    break;

            }

            /*
           switch (pTipoPeriodoGracia)
           {
               case 2:

                   for (int i = 1; i <= pCantPerio; i++)
                   {
                      // DateTime f = Convert.ToDateTime(dt.Rows[i - 1]["Fecha"]).AddMonths(1);
                      // double capPendiente = Convert.ToDouble(dt.Rows[i - 1]["CapitalPendiente"]);
                      // double inte = Utilidades.Redondear.DosDecimales(tem * capPendiente);
                      // double iva = Utilidades.Redondear.DosDecimales(inte * 0.21);
                      // double cap = Utilidades.Redondear.DosDecimales(inte + iva);
                      // if (cbInteresPeriodoDeGracia.Checked)
                       {
                      //     dt.Rows.Add("G",i, f, 0, inte, iva, 0, capPendiente);
                       }
//                        else 
{
                       //    dt.Rows.Add("G",i, f, 0, inte, iva, cap, capPendiente);
                       }

                   }
                   break;
               case 3:
                   for (int i = 1; i <= pCantPerio; i++)
                   {
                       DateTime f = Convert.ToDateTime(dt.Rows[i - 1]["Fecha"]).AddMonths(1);
                       double capPendiente = Convert.ToDouble(dt.Rows[i - 1]["CapitalPendiente"]);
                       double inte = Utilidades.Redondear.DosDecimales(tem * capPendiente);
                       double iva = Utilidades.Redondear.DosDecimales(inte * 0.21);
                       double cap = Utilidades.Redondear.DosDecimales(inte + iva);
                       dt.Rows.Add("G", i, f, 0, 0, 0, 0, capPendiente+cap);

                   }
                   break;
           }*/
            return dt;
        }

        private bool Validar()
        {
            if (txtValorPrestamo.Text.Trim().Equals("") || Convert.ToDouble(txtValorPrestamo.Text) <= 0)
            {
                MessageBox.Show("El Valor del Prestamo debe ser mayor a 0!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTNA.Text.Trim().Equals("") || Convert.ToDouble(txtTNA.Text) <= 0)
            {
                MessageBox.Show("El Valor de la TNA debe ser mayor a 0!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtFechaOtorgamiento.Value.Date>dtpFechaPrimerCuota.Value.Date)
            {
                MessageBox.Show("Fecha de Otorgamiento no puede ser superior a la Primer Cuota", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private DataTable CrearDataTableFrances()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo", System.Type.GetType("System.String"));
            dt.Columns.Add("Cuota", System.Type.GetType("System.String"));
            dt.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CapitalAmortizado", System.Type.GetType("System.Double"));
            dt.Columns.Add("Interes", System.Type.GetType("System.Double"));
            dt.Columns.Add("IVA", System.Type.GetType("System.Double"));
            dt.Columns.Add("CuotaAPagar", System.Type.GetType("System.Double"));
            dt.Columns.Add("CapitalPendiente", System.Type.GetType("System.Double"));
            return dt;

        }

        private void cbSistemasAmortizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTablaAmortizacion.DataSource = null;
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
        }

        private void txtTNA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        /*private double TEA(double pTNA, int pCuotasPorAño) {
            return Utilidades.Redondear.DosDecimales(Math.Pow((((pTNA / 100) / pCuotasPorAño) + 1), pCuotasPorAño) - 1);
        }*/

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaBancaria.SelectedIndex != -1)
            {
                try
                {
                    objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                    dgvTablaAmortizacion.DataSource = null;
                    tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbSistemasAmortizacion);
            txtValorPrestamo.Text = "";
            cbFrencuenciaPago.SelectedIndex = 3;
            nupCuotas.Value = 1;
            txtTNA.Text = "";
            Utilidades.Combo.SeleccionarPrimerValor(cbPeriodoDeGracia);
            dtpFechaPrimerCuota.Value = DateTime.Now.Date;
            dtFechaOtorgamiento.Value = DateTime.Now.Date;
            //dgvTablaAmortizacion.DataSource = null;
            //tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar el Prestamo Bancario?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (Validar())
                {
                    if (dgvTablaAmortizacion.Rows.Count == 0) {
                        MessageBox.Show("Debe Simular el Prestamo para poder guardarlo!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Convert.ToInt32(cbSistemasAmortizacion.SelectedValue) == 1)
                    {
                    
                        CargarDatos();
                        CargarTabla();
                        CargarAsientos();
                        new Logica.PrestamoBancario().Agregar(objEPrestamo);
                        Limpiar();
                        MessageBox.Show("Prestamo creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtValorPrestamo_TextChanged(object sender, EventArgs e)
        {
            dgvTablaAmortizacion.DataSource = null;
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
        }

        private void nupCuotas_ValueChanged(object sender, EventArgs e)
        {
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
            dgvTablaAmortizacion.DataSource = null;
        }

        private void txtTNA_TextChanged(object sender, EventArgs e)
        {
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
            dgvTablaAmortizacion.DataSource = null;
        }

        private void dtpFechaPrimerCuota_ValueChanged(object sender, EventArgs e)
        {
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
            dgvTablaAmortizacion.DataSource = null;
        }

        private void cbInteresPeriodoDeGracia_CheckedChanged(object sender, EventArgs e)
        {
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
        }

        private void dtFechaOtorgamiento_ValueChanged(object sender, EventArgs e)
        {
            dgvTablaAmortizacion.DataSource = null;
            tcPrestamos.TabPages.Remove(tpTablaAmortizacion);
        }

       

        private void dgvTablaAmortizacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)


        {
            TextBox validar = e.Control as TextBox;

            if (validar != null)
            {
                DataGridViewCell celda = dgvTablaAmortizacion.CurrentCell;
                if (celda.ColumnIndex != 1)
                {
                    validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
                }

                // validar.KeyDown += new KeyEventHandler(this.dgvDatos_KeyDown);
                //dgvDatos_KeyDown
            }
        }
        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (dgvTablaAmortizacion.CurrentCell.ColumnIndex == 10)
            {*/
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            /*}
            else
            {
                Utilidades.CajaDeTexto.PermitirSoloNumeros(e);
            }*/
            //Utilidades.ControlesGenerales.CambiarFoco(e);

        }

        private void dgvTablaAmortizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow fila = ((DataGridView)sender).CurrentRow;
            double capAmo = 0;
            double inte= 0;
            double iva = 10;
            double cuoApa = 0;
       //     if (dgvTablaAmortizacion.Columns[e.ColumnIndex].Name.Equals("CapitalAmortizado")) {
                
                try
                {
                    capAmo =Double.Parse(dgvTablaAmortizacion.Rows[e.RowIndex].Cells["CapitalAmortizado"].Value.ToString());
                    inte = Double.Parse(dgvTablaAmortizacion.Rows[e.RowIndex].Cells["Interes"].Value.ToString());
                iva = Double.Parse(dgvTablaAmortizacion.Rows[e.RowIndex].Cells["IVA"].Value.ToString());
                dgvTablaAmortizacion.Rows[e.RowIndex].Cells["CuotaAPagar"].Value = capAmo + inte + iva;
                
            }
                catch (Exception)
                {
                    //dgvTablaAmortizacion.Rows[e.RowIndex].Cells["CapitalAmortizado"].Value = 0;
                }
        //    }        

        }

        private void dgvTablaAmortizacion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                switch (dgvTablaAmortizacion.Columns[e.ColumnIndex].Name)
                {
                    case "CapitalAmortizado":
                        dgvTablaAmortizacion.Rows[e.RowIndex].Cells["CapitalAmortizado"].Value = 0;
                        break;
                    case "Interes":
                        dgvTablaAmortizacion.Rows[e.RowIndex].Cells["Interes"].Value = 0;
                        break;
                    case "IVA":
                        dgvTablaAmortizacion.Rows[e.RowIndex].Cells["IVA"].Value = 0;
                        break;
                }
                
                e.Cancel = false;
            }
        }
    }
}
