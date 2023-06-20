using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLiquidacionDeSueldos : Presentacion.frmColor
    {
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();


        Entidades.Banco objEBanco = new Entidades.Banco();
        
        public frmLiquidacionDeSueldos()
        {
            InitializeComponent();
            ConfiguracionInicial();

            CargarValores();
            //this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
            dgvDatos.Columns["Monto"].ReadOnly = false;
        }

        void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }
        void Titulo()
        {
            this.Text = "LIQUIDACION DE SUELDOS";
        }
        void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoSalario);
            Utilidades.Combo.Formato(cbPeriodo);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbFormaDePago);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Legajo"].Frozen = true;
            dgvDatos.Columns["Legajo"].Width = 100;

            dgvDatos.Columns["DNI"].Frozen = true;
            dgvDatos.Columns["DNI"].Width = 100;

            dgvDatos.Columns["Empleado"].Frozen = true;
            dgvDatos.Columns["Empleado"].Width = 300;

            //dgvDatos.Columns["Monto"].Frozen = true;

            //       dgvDatos.Columns["Monto"].Frozen = true;
            //      dgvDatos.Columns["Monto"].Width = 155;

            lblTotal.Text = Convert.ToDouble("0").ToString("C2");
        }






        void CargarValores()
        {
            try
            {
                CargarFormasDePago();
                CargarTipoSalario();
                CargarPeriodos();
                CargarBancos();
                this.cbFormaDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormaDePago_SelectedIndexChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPeriodos()
        {

            Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(), "Fecha", "Meses");

        }

        void CargarTipoSalario()
        {

            Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerAlgunos(), "Codigo", "Descripcion");
            cbTipoSalario.SelectedIndex = 1;

        }

        public void CargarBancos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivasParaTransferenciasClientes(), "CodigoBanco", "Banco");
                if (cbBancos.SelectedValue != null)
                {
                    objEBanco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CargarFormasDePago()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));


            dt.Rows.Add(1, "Banco");
            dt.Rows.Add(2, "Efectivo");

            Utilidades.Combo.Llenar(cbFormaDePago, dt, "Codigo", "Descripcion");

        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
            }
        }

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDatos.CurrentCell.ColumnIndex == 4)
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        /*
        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int anio = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(3, 4));
                int mes = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(0, 2));
                int dia = DateTime.DaysInMonth(anio, mes);
                DateTime fecha = new DateTime(anio, mes, dia);
                if (fecha < Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells["FechaIngreso"].Value))
                {
                    años = 0;
                    dia = 0;
                    mes = 0;
                }
                else
                {
                    años = fecha.AddTicks(-Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells["FechaIngreso"].Value).Ticks).Year - 1;
                    mes = fecha.AddTicks(-Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells["FechaIngreso"].Value).Ticks).Month - 1;
                    dia = fecha.AddTicks(-Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells["FechaIngreso"].Value).Ticks).Day - 1;
                }
                if (!(años == 0 && mes == 0)) {
                    dia = 30;
                }


                double diasTrabajados = dia;
                if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 15) 
                {
                    if (dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value == null)
                        dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value = "";
                    just = (dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value);
                    if (dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value == null)
                        dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value = "";
                    injus = (dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value);
                    if (dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value == null)
                        dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value = "";
                    diasVacaciones = (dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value);
                    if (diasTrabajados < just + injus+ diasVacaciones) {
                        switch (e.ColumnIndex)
                        {
                            case 9:
                                dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value = "";
                                just = 0;
                                break;
                            case 10:
                                dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value = "";
                                injus = 0;
                                break;
                            case 15:
                                dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value = "";
                                diasVacaciones = 0;
                                break;
                        }
                        MessageBox.Show("Cantidad de Faltas y/o Vacaciones no puede ser mayor a\n la cantidad de dias trabajados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    diasTrabajados = diasTrabajados - just  - diasVacaciones;
                    dgvDatos.Rows[e.RowIndex].Cells["DiasTrabajados"].Value = diasTrabajados;
                }

                diasTrabajados = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DiasTrabajados"].Value);
                just= (dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["FaltasJustificadas"].Value);
                injus = (dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["FaltasInjustificadas"].Value);
                diasVacaciones = (dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["DiasVacaciones"].Value);
                //if (e.ColumnIndex == 6) { 
                    sueldo2 = Utilidades.Redondear.DosDecimales((Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["SueldoBasico"].Value) / 30) * diasTrabajados);
                dgvDatos.Rows[e.RowIndex].Cells["Sueldo"].Value = sueldo2;
                double basico = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["SueldoBasico"].Value));
                //}
                double descontarinj = 0;
                double sumarjus = 0;

                descontarinj = Utilidades.Redondear.DosDecimales(injus * Utilidades.Redondear.DosDecimales(basico / 30));
                sumarjus = Utilidades.Redondear.DosDecimales(just * Utilidades.Redondear.DosDecimales(basico / 30));

                dgvDatos.Rows[e.RowIndex].Cells["Licencia"].Value = sumarjus;
                dgvDatos.Rows[e.RowIndex].Cells["Inasistencias"].Value = -descontarinj;
                if (dgvDatos.Rows[e.RowIndex].Cells["AOS"].Value == null)
                    dgvDatos.Rows[e.RowIndex].Cells["AOS"].Value = "";
                double adiOS = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["AOS"].Value);

                adelantos = (dgvDatos.Rows[e.RowIndex].Cells["Adelanto"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Adelanto"].Value);
                embargos = (dgvDatos.Rows[e.RowIndex].Cells["Embargo"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Embargo"].Value);

                antiguedad = CalculoAntiguedad(sueldo2 - descontarinj + sumarjus, años);
                dgvDatos.Rows[e.RowIndex].Cells["Ant"].Value = antiguedad;
                if (diasVacaciones > 0)
                {
                    presentismo = CalculoPresentismo(just, injus, sueldo2 + sumarjus);
                }
                else
                {
                    presentismo = CalculoPresentismo(just, injus, Convert.ToDouble(basico));
                }
                double nor = txtNoRem.Text.Equals("") ? 0 : Convert.ToDouble(txtNoRem.Text);
                vacaciones = CalcularVacacionesMensual(Convert.ToDouble(basico), diasVacaciones, años);
                jubilacion = CalcularJubilacion(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                ley19032 = CalcularLey19032(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                obraSocial = CalcularObraSocial(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                sindicato = CalcularSindicato(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                segurosepelio = CalcularSeguroSepelio(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                no = CalcularNoRemunerativo(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);

                total = CalcularTotal(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones, no, nor, jubilacion, ley19032, obraSocial, adiOS, sindicato, segurosepelio, adelantos, embargos);
                dgvDatos.Rows[e.RowIndex].Cells["Pres"].Value = presentismo;
                dgvDatos.Rows[e.RowIndex].Cells["Vac"].Value = vacaciones;
                dgvDatos.Rows[e.RowIndex].Cells["Jubilaciones"].Value = jubilacion;
                dgvDatos.Rows[e.RowIndex].Cells["Ley"].Value = ley19032;
                dgvDatos.Rows[e.RowIndex].Cells["Obra"].Value = obraSocial;
                dgvDatos.Rows[e.RowIndex].Cells["Sindi"].Value = sindicato;
                dgvDatos.Rows[e.RowIndex].Cells["Seguro"].Value = segurosepelio;
                dgvDatos.Rows[e.RowIndex].Cells["NoRem"].Value = no;
                dgvDatos.Rows[e.RowIndex].Cells["Tot"].Value = total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        */












        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar Salarios de Empleados?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                List<Entidades.Salario> listaSalarios =CargarSalarios();
                if (listaSalarios.Count > 0)
                {
                    Entidades.Caja objECaja = CargarCaja(listaSalarios);
                    Entidades.Asiento objEAsiento = CargarAsiento(objECaja);

                    int res = new Logica.Salario().Agregar(listaSalarios, objECaja, objEAsiento);

                    if (res == 1)
                    {
                        MessageBox.Show("Sueldos cargados exitosamente!!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    MessageBox.Show("Debe cargar Sueldo de Empleados!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                obtenerEmpleados();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Entidades.Salario> CargarSalarios()
        {
            List<Entidades.Salario> listaSalarios = new List<Entidades.Salario>();
            Entidades.Salario objESalario;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (item.Cells["Monto"].Value != null)
                {
                    if (!item.Cells["Monto"].Value.Equals("") && Convert.ToDouble(item.Cells["Monto"].Value)>0)
                    {
                        objESalario = new Entidades.Salario();
                        objESalario.TipoSalario.Codigo = Convert.ToInt32(cbTipoSalario.SelectedValue);
                        objESalario.Periodo = cbPeriodo.SelectedValue.ToString();
                        objESalario.Empleado.Codigo = Convert.ToInt32(item.Cells["CodigoEmpleado"].Value);
                        //1-Banco 2-Efectivo
                        if (Convert.ToInt32(cbFormaDePago.SelectedValue) == 1)
                        {
                            objESalario.FormaDePago.Codigo = 5;
                        }
                        else
                        {
                            objESalario.FormaDePago.Codigo = 1;
                        }
                        objESalario.Fecha = dtpFecha.Value;
                        objESalario.Monto = Convert.ToDouble(item.Cells["Monto"].Value);
                        listaSalarios.Add(objESalario);
                    }
                }
            }
            return listaSalarios;
        }

        private Entidades.Caja CargarCaja(List<Entidades.Salario> listaSalarios)
        {
            Entidades.Caja objECaja = new Entidades.Caja();
            objECaja.Fecha= dtpFecha.Value;
            objECaja.TipoDocumentoCaja = new Logica.TipoDocumentoCaja().ObtenerUno(5);
            objECaja.TipoDocumentoCaja.Numerador = new Logica.Numerador().ObtenerUno(objECaja.TipoDocumentoCaja.Numerador.Codigo);
            objECaja.Fecha = dtpFecha.Value;
            objECaja.Letra = Convert.ToChar(objECaja.TipoDocumentoCaja.Numerador.Letra);
            objECaja.PuntoDeVenta = objECaja.TipoDocumentoCaja.Numerador.PuntoVenta;
            objECaja.Numero = objECaja.TipoDocumentoCaja.Numerador.Numero;
            objECaja.Usuario = Singleton.Instancia.Usuario;
            objECaja.PuestoCaja = Singleton.Instancia.Puesto;
            objECaja.Observaciones = cbTipoSalario.Text + " Periodo: " + cbPeriodo.SelectedValue + " Forma de Pago: " + cbFormaDePago.Text ;
            double total = 0;
            foreach (Entidades.Salario item in listaSalarios)
            {
                total += item.Monto;
            }
            // List<Entidades.Tranferencia> trasferencias = new List<Entidades.Tranferencia>();

      
                Entidades.Caja_Detalle cajaDetalle = new Entidades.Caja_Detalle();
                cajaDetalle.Descripcion = "Sueldos Pagados";
                cajaDetalle.CodigoCuentaContable = 50102410000;
                cajaDetalle.Importe = Convert.ToDouble(total);
                objECaja.Detalle.Add(cajaDetalle);
         


            if (Convert.ToInt32(cbFormaDePago.SelectedValue) == 1)
            {
                Entidades.Tranferencia objETransferencia = new Entidades.Tranferencia();
                objETransferencia.Importe = total;
                objETransferencia.Banco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
                
                //objETransferencia.CuentaBancaria.Codigo = Convert.ToInt32(cbCuentaBancaria.SelectedValue);
                objETransferencia.CuentaBancaria = new Logica.CuentaBancaria().ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                //objETransferencia.CuentaBancaria.CuentaContable.Codigo = Convert.ToInt64(fila.Cells["CodigoCuentaContable2"].Value);
                objETransferencia.Moneda = new Logica.Moneda().ObtenerUno(1);
                objETransferencia.Importe = total;
                objECaja.Tranferencias.Add(objETransferencia);
            }
            else {
                Entidades.Factura_Efectivo fe = new Entidades.Factura_Efectivo();
                fe.Moneda = new Logica.Moneda().ObtenerUno(1);
                fe.Importe = total;
                objECaja.FacturaEfectivo.Add(fe);
            }
            return objECaja;    
        }

        private Entidades.Asiento CargarAsiento(Entidades.Caja pCaja)
        {
            Entidades.Asiento objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = pCaja.Fecha;
            objEAsiento.FechaEmision = pCaja.Fecha;
            //  if(objEPago.TipoDocumentoProveedor.TipoDoc.Codigo.Equals("RC"))
            objEAsiento.Descripcion = pCaja.TipoDocumentoCaja.Descripcion + "  N° " + pCaja.Numdoc + " " + pCaja.Observaciones;
            
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;

            Entidades.Asiento_Detalle asientoDetalle;


            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 50102410000;
            double total = 0;
            foreach (var item in pCaja.FacturaEfectivo)
            {
                total += Math.Abs(item.Importe);
            }
            foreach (var item in pCaja.Tranferencias)
            {
                total += item.Importe;
            }


            asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(total);
            asientoDetalle.Haber = 0;

            objEAsiento.Detalle.Add(asientoDetalle);




            foreach (Entidades.Factura_Efectivo fe in pCaja.FacturaEfectivo)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();

                if (fe.Moneda.Codigo == 1)
                    asientoDetalle.CuentaContable = new Logica.FormaDePago().ObtenerUno(1).CuentaContable;
                else
                {
                    Int64 cuenta = 0;
                    switch (Singleton.Instancia.Empresa.Codigo)
                    {
                        case 1:
                            cuenta = 10101020100;
                            break;
                        case 2:
                            cuenta = 10101020600;
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



            foreach (Entidades.Tranferencia tran in pCaja.Tranferencias)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable = tran.CuentaBancaria.CuentaContable;

                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = tran.Importe * tran.Moneda.Cotizacion;
                
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            return objEAsiento;
        }

        private void frmCargaSalarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea Cerrar la Ventana?\nSe perderan los Cambios", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    //objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    objEBanco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valorSeleccionado = Convert.ToInt32(cbFormaDePago.SelectedValue);
            if (valorSeleccionado == 1)
            {
                cbBancos.Visible = true;
                cbCuentaBancaria.Visible = true;
                lblNroCuenta.Visible = true;
                lblBanco.Visible = true;
                obtenerEmpleados();
            }
            else
            {
                cbBancos.Visible = false;
                cbCuentaBancaria.Visible = false;
                lblNroCuenta.Visible = false;
                lblBanco.Visible = false;
            }
        }

        private void obtenerEmpleados()
        {
            try
            {
                dgvDatos.DataSource = objLEmpleado.ObtenerEmpleadosLiquidacionSueldo(Convert.ToInt32(cbFormaDePago.SelectedValue), Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                lblTotal.Text = Calculo().ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerEmpleados();
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            lblTotal.Text = Calculo().ToString("C2");
        }

        private double Calculo()
        {
            double total = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (item.Cells["Monto"].Value != null)
                {
                    if (!item.Cells["Monto"].Value.Equals(""))
                    {
                        total += Convert.ToDouble(item.Cells["Monto"].Value);
                    }
                }
            }
            return total;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            obtenerEmpleados();
        }

        private void cbFormaDePago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            obtenerEmpleados();
        }
    }
}
