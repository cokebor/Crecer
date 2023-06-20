using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCargaSalarios : Presentacion.frmColor
    {
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.ConceptosAsociadosASueldos objLConcepto = new Logica.ConceptosAsociadosASueldos();
        Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
        double antiguedad = 0;
        double presentismo = 0;
        double vacaciones = 0;
        int años = 0;
        double just = 0, injus = 0;
        int diasVacaciones;
        double sueldo2 = 0;
        double no = 0;
        double jubilacion = 0;
        double ley19032 = 0;
        double obraSocial = 0;
        double sindicato = 0;
        double segurosepelio = 0;
        double total = 0;
        double adelantos = 0;
        double embargos = 0;
        public frmCargaSalarios()
        {
            InitializeComponent();
            ConfiguracionInicial();
           
            CargarTipoSalario();
            CargarPeriodos();
            CargarValores();
            this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
        }

        void ConfiguracionInicial() {
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
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Utilidades.CajaDeTexto.LimiteTamaño(txtPorcentajeNoRemunerativo, 5);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNoRem, 6);
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Seleccionado"].Frozen = true;
            dgvDatos.Columns["Empleado"].Frozen = true;
            dgvDatos.Columns["SueldoBasico"].Frozen = true;
            dgvDatos.Columns["Sueldo"].Frozen = true;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            dgvDatos.Columns["Seleccionado"].Width = 25;
            dgvDatos.Columns["Empleado"].Width = 130;
            dgvDatos.Columns["Puestos"].Width = 100;
            dgvDatos.Columns["SueldoBasico"].Width = 70;
            dgvDatos.Columns["DiasTrabajados"].Width = 50;
            dgvDatos.Columns["FaltasJustificadas"].Width = 50;
            dgvDatos.Columns["FaltasInjustificadas"].Width = 50;
            dgvDatos.Columns["Sueldo"].Width = 70;
            dgvDatos.Columns["DiasVacaciones"].Width = 50;
            dgvDatos.Columns["Vac"].Width = 70;
            dgvDatos.Columns["Ant"].Width = 70;
            dgvDatos.Columns["Pres"].Width = 70;
            dgvDatos.Columns["NoRem"].Width = 70;
            dgvDatos.Columns["NoRem2"].Width = 70;
            dgvDatos.Columns["Jubilaciones"].Width = 70;
            dgvDatos.Columns["Ley"].Width = 70;
            dgvDatos.Columns["Obra"].Width = 70;
            dgvDatos.Columns["Sindi"].Width = 70;
            dgvDatos.Columns["Seguro"].Width = 70;
            dgvDatos.Columns["AOS"].Width = 70;
            dgvDatos.Columns["Tot"].Width = 70;
            dgvDatos.Columns["Adelanto"].Width = 70;
            dgvDatos.Columns["Embargo"].Width = 70;
            dgvDatos.Columns["Inasistencias"].Width = 70;
            dgvDatos.Columns["Licencia"].Width = 70;

            dgvDatos.Columns["SueldoBasico"].ReadOnly = false;
            //dgvDatos.Columns["DiasTrabajados"].ReadOnly = false;
            dgvDatos.Columns["FaltasJustificadas"].ReadOnly = false;
            dgvDatos.Columns["FaltasInjustificadas"].ReadOnly = false;
            dgvDatos.Columns["DiasVacaciones"].ReadOnly = false;
            dgvDatos.Columns["AOS"].ReadOnly = false;
            dgvDatos.Columns["Adelanto"].ReadOnly = false;
            dgvDatos.Columns["Embargo"].ReadOnly = false;
        }

        void CargarTipoSalario() {
            try
            {
                Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerTodos(), "Codigo", "Descripcion");
                cbTipoSalario.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPeriodos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerTodos(), "Fecha", "Meses");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void CargarValores() {
            try
            {
                dgvDatos.Rows.Clear();
                DataTable dt = objLEmpleado.ObtenerActivosQueSonEmpleados();
                foreach(DataRow dr in dt.Rows){
                    int anio = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(3, 4));
                    int mes = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(0, 2));
                    int dia = DateTime.DaysInMonth(anio, mes);
                    DateTime fecha = new DateTime(anio, mes, dia);

                    if (fecha < Convert.ToDateTime(dr["FechaIngreso"]))
                    {
                        años = 0;
                        dia = 0;
                        mes = 0;
                    }
                    else
                    {
                        años = fecha.AddTicks(-Convert.ToDateTime(dr["FechaIngreso"]).Ticks).Year - 1;
                        mes = fecha.AddTicks(-Convert.ToDateTime(dr["FechaIngreso"]).Ticks).Month - 1;
                        dia = fecha.AddTicks(-Convert.ToDateTime(dr["FechaIngreso"]).Ticks).Day - 1;
                    }


                    if (años == 0 && mes == 0)
                    {
                        if (dia == 0)
                        {
                            sueldo2 = 0;
                        }
                        else if (dia < 30)
                        {
                            sueldo2 = (Convert.ToDouble(dr["Sueldo"]) / 30) * dia;
                        }
                    }
                    else
                    {
                        dia = 30;
                        sueldo2 = Convert.ToDouble(dr["Sueldo"]);
                    }


                    just = 0;
                    injus = 0;
      
                    antiguedad = CalculoAntiguedad(sueldo2, años);
                    presentismo = CalculoPresentismo(just, injus, sueldo2);
                    jubilacion = CalcularJubilacion(sueldo2, antiguedad, presentismo, vacaciones);
                    ley19032= CalcularLey19032(sueldo2, antiguedad, presentismo, vacaciones);
                    obraSocial = CalcularObraSocial(sueldo2, antiguedad, presentismo, vacaciones);
                    sindicato = CalcularSindicato(sueldo2, antiguedad, presentismo, vacaciones);
                    segurosepelio = CalcularSeguroSepelio(sueldo2, antiguedad, presentismo, vacaciones);
                    double nor = txtNoRem.Text.Equals("") ? 0 : Convert.ToDouble(txtNoRem.Text);

                    txtPorcentajeNoRemunerativo.Text = objLConcepto.ObtenerUno(1).Valor.ToString();
                    no = CalcularNoRemunerativo(sueldo2, antiguedad, presentismo, vacaciones);

                    total = CalcularTotal(sueldo2, antiguedad, presentismo, vacaciones, no, nor, jubilacion, ley19032, obraSocial,0, sindicato, segurosepelio,adelantos,embargos);
                    dgvDatos.Rows.Add(false, dr["Codigo"], dr["NombreCompleto"], dr["Puesto"], dr["FechaIngreso"], años, dr["Sueldo"], dia, (Convert.ToDouble(dr["Sueldo"])/30)*dia,"","",0,0, antiguedad, presentismo,"",0,no,"",jubilacion, ley19032, obraSocial,sindicato,segurosepelio,0,0,0,total, dr["Sueldo"]);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex != -1) { 
            DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            check.Value = !(Convert.ToBoolean(check.Value));
            }*/
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
            if (dgvDatos.CurrentCell.ColumnIndex == 6 || dgvDatos.CurrentCell.ColumnIndex == 24 || dgvDatos.CurrentCell.ColumnIndex == 25 || dgvDatos.CurrentCell.ColumnIndex == 26 || dgvDatos.CurrentCell.ColumnIndex == 9 || dgvDatos.CurrentCell.ColumnIndex == 10)
                Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
            if (dgvDatos.CurrentCell.ColumnIndex == 7  || dgvDatos.CurrentCell.ColumnIndex == 15 )
                Utilidades.CajaDeTexto.PermitirSoloNumerosPositivos(e);
        }

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

                    diasTrabajados = diasTrabajados - just /*- injus*/ - diasVacaciones;
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

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked)
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    item.Cells["Seleccionado"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    item.Cells["Seleccionado"].Value = false;
                }
            }
        }

        private void cbVacaciones_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVacaciones.Checked) {     
                
                dgvDatos.Columns["DiasTrabajados"].Visible = true;
                dgvDatos.Columns["DiasVacaciones"].Visible = true;
               // dgvDatos.Columns["Vac"].Visible = true;
            } else {
                dgvDatos.Columns["DiasTrabajados"].Visible = false;
                dgvDatos.Columns["DiasVacaciones"].Visible = false;
                //dgvDatos.Columns["Vac"].Visible = false;
                /*foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    item.Cells["DiasVacaciones"].Value = "";
                }*/
            }
        }

       
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
          /*  try
            {
                CargarGrilla();
            }
            catch (Exception) {
                MessageBox.Show("Error al seleccionar Fecha", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFecha.Value = DateTime.Now;
            }*/
        }


        private void CargarGrilla() {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {


                int anio = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(3, 4));
                int mes = Convert.ToInt32(((String)(cbPeriodo.SelectedValue)).Substring(0, 2));
                int dia = DateTime.DaysInMonth(anio, mes);
                DateTime fecha = new DateTime(anio, mes, dia);
                if (fecha < Convert.ToDateTime(dr.Cells["FechaIngreso"].Value))
                {
                    años = 0;
                    dia = 0;
                    mes = 0;
                }
                else {
                    años = fecha.AddTicks(-Convert.ToDateTime(dr.Cells["FechaIngreso"].Value).Ticks).Year-1;
                    mes= fecha.AddTicks(-Convert.ToDateTime(dr.Cells["FechaIngreso"].Value).Ticks).Month - 1;
                    dia = fecha.AddTicks(-Convert.ToDateTime(dr.Cells["FechaIngreso"].Value).Ticks).Day - 1;
                }

                if (años == 0 && mes == 0)
                {
                    if (dia == 0)
                    {
                        sueldo2 = 0;
                    }
                    else if (dia < 30)
                    {
                        sueldo2 = (Convert.ToDouble(dr.Cells["SueldoBasico"].Value) / 30) * dia;
                    }
                }
                else {
                    dia = 30;
                    sueldo2 = Convert.ToDouble(dr.Cells["SueldoBasico"].Value);
                }


                double basico = sueldo2;
                //double basico2 = Convert.ToDouble(dr.Cells["ControlBasico"].Value);
                int diasTrabajados = dia; ///(dr.Cells["DiasTrabajados"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(dr.Cells["DiasTrabajados"].Value);
                //años = Convert.ToInt32(dr.Cells["Anos"].Value);
                if (dr.Cells["DiasVacaciones"].Value == null)
                    dr.Cells["DiasVacaciones"].Value = "";
                int diasVacaciones = (dr.Cells["DiasVacaciones"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(dr.Cells["DiasVacaciones"].Value);
                if (dr.Cells["AOS"].Value == null)
                    dr.Cells["AOS"].Value = "";
                double adiOS = Convert.ToDouble(dr.Cells["AOS"].Value);
                double descontarinj = 0;
                double sumarjus = 0;
               
                if (dr.Cells["FaltasJustificadas"].Value == null)
                    dr.Cells["FaltasJustificadas"].Value = "";
                just = (dr.Cells["FaltasJustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dr.Cells["FaltasJustificadas"].Value);
                if (dr.Cells["FaltasInjustificadas"].Value == null)
                    dr.Cells["FaltasInjustificadas"].Value = "";
                injus = (dr.Cells["FaltasInjustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dr.Cells["FaltasInjustificadas"].Value);
                descontarinj = Utilidades.Redondear.DosDecimales(injus * Utilidades.Redondear.DosDecimales(basico / 30));
                sumarjus = Utilidades.Redondear.DosDecimales(just * Utilidades.Redondear.DosDecimales(basico / 30));
                antiguedad = CalculoAntiguedad(sueldo2 - descontarinj + sumarjus, años);

                //int diasVacaciones = (dr.Cells["DiasVacaciones"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(dr.Cells["DiasVacaciones"].Value);
                //vacaciones = CalcularVacacionesMensual(Convert.ToDouble(basico), diasVacaciones, años);
                if (diasVacaciones > 0)
                {
                    presentismo = CalculoPresentismo(just, injus, Convert.ToDouble(sueldo2 + sumarjus));
                }
                else
                {
                    presentismo = CalculoPresentismo(just, injus, Convert.ToDouble(basico));
                }
                vacaciones = CalcularVacacionesMensual(Convert.ToDouble(basico), diasVacaciones, años);
                no = CalcularNoRemunerativo(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                jubilacion = CalcularJubilacion(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                ley19032 = CalcularLey19032(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                obraSocial = CalcularObraSocial(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                sindicato = CalcularSindicato(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                segurosepelio = CalcularSeguroSepelio(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones);
                double nor = txtNoRem.Text.Equals("") ? 0 : Convert.ToDouble(txtNoRem.Text);
                adelantos=(dr.Cells["Adelanto"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dr.Cells["Adelanto"].Value);
                embargos = (dr.Cells["Embargo"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(dr.Cells["Embargo"].Value);


                total = CalcularTotal(sueldo2 - descontarinj + sumarjus, antiguedad, presentismo, vacaciones, no, nor, jubilacion, ley19032, obraSocial, adiOS, sindicato, segurosepelio,adelantos,embargos);
                dr.Cells["Sueldo"].Value = sueldo2;
                dr.Cells["DiasTrabajados"].Value = dia;
                dr.Cells["Anos"].Value = años;
                dr.Cells["Ant"].Value = antiguedad;
                dr.Cells["Pres"].Value = presentismo;
                dr.Cells["Vac"].Value = vacaciones;
                dr.Cells["NoRem"].Value = no;
                dr.Cells["Jubilaciones"].Value = jubilacion;
                dr.Cells["Ley"].Value = ley19032;
                dr.Cells["Licencia"].Value = sumarjus;
                dr.Cells["Inasistencias"].Value = -descontarinj;
                dr.Cells["Obra"].Value = obraSocial;
                dr.Cells["Sindi"].Value = sindicato;
                dr.Cells["Seguro"].Value = segurosepelio;
                dr.Cells["Tot"].Value = total;
            }
        }
        public double CalculoAntiguedad(double sueldo, int años) {
            if (años >= 15)
            {
                return Utilidades.Redondear.DosDecimales(sueldo * 0.0125 * años);
            }
            else {
                return Utilidades.Redondear.DosDecimales(sueldo * 0.01 * años);
            }
            
        }

        public double CalculoPresentismo(double faltasJustificadas, double faltasInjustificadas, double sueldo) {
            double presentismo = 0;
            int fjus = (int)faltasJustificadas;
            int finjus = (int)faltasInjustificadas;
            int totalFaltas = fjus + finjus;
            double resFJust=0, resFInjus=0;
            presentismo = Utilidades.Redondear.DosDecimales(sueldo * 0.2);
            if (totalFaltas > 0) {
                if (finjus > 0)
                {
                    if (finjus < 3)
                    {
                        if (fjus > 0)
                        {
                            if (fjus < 5)
                            {
                                resFJust = Utilidades.Redondear.DosDecimales(fjus * Utilidades.Redondear.DosDecimales(presentismo / 5));
                            }
                        }
                        resFInjus = Utilidades.Redondear.DosDecimales(finjus * Utilidades.Redondear.DosDecimales(presentismo / 3));
                    }
                    else
                    {
                        presentismo = 0;
                    }
                }
                else {
                    if (fjus > 0 && fjus <= 5) {
                        resFJust = Utilidades.Redondear.DosDecimales(fjus * Utilidades.Redondear.DosDecimales(presentismo / 5));
                    }
                }
            }
            presentismo = presentismo - resFJust - resFInjus;
            if (presentismo < 0 || Convert.ToInt32(cbTipoSalario.SelectedValue)==4)
                presentismo = 0;
            return presentismo;
        }

        private double CalcularVacacionesMensual(double basico, int diasVacaciones, int años) {
            double sueldoVacaciones = Utilidades.Redondear.DosDecimales(Utilidades.Redondear.DosDecimales(basico / 25) * diasVacaciones);
            double antiguedadVacaciones = 0;
            if (años >= 15)
            {
                antiguedadVacaciones = Utilidades.Redondear.DosDecimales(sueldoVacaciones * 0.0125 * años);
            }
            else {
                antiguedadVacaciones = Utilidades.Redondear.DosDecimales(sueldoVacaciones * 0.01 * años);
            }
            
            double presentismoVacaciones = (CalculoPresentismo(0, 0, sueldoVacaciones));
            return Utilidades.Redondear.DosDecimales(sueldoVacaciones + antiguedadVacaciones + presentismoVacaciones);
        }

        private double CalcularJubilacion(double sueldo, double antiguedad, double presentismo, double vacaciones) {
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.DosDecimales(total * 0.11);
        }

        private double CalcularLey19032(double sueldo, double antiguedad, double presentismo, double vacaciones)
        {
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.DosDecimales(total * 0.03);
        }

        private double CalcularObraSocial(double sueldo, double antiguedad, double presentismo, double vacaciones)
        {
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.DosDecimales(total * 0.03);
        }

        private double CalcularSindicato(double sueldo, double antiguedad, double presentismo, double vacaciones)
        {
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.DosDecimales(total * 0.02);
        }

        private double CalcularSeguroSepelio(double sueldo, double antiguedad, double presentismo, double vacaciones)
        {
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.DosDecimales(total * 0.01);
        }

        private double CalcularTotal(double sueldo, double antiguedad, double presentismo, double vacaciones, double noRemu, double noRe,double jub, double ley, double obra,double adiOS, double sindi, double seguro, double adelantos, double embargos) {
            double total = sueldo + antiguedad + presentismo + vacaciones + noRemu + noRe - jub-ley-obra-sindi-seguro-adiOS-adelantos-embargos;
            return total;
        }
        private void cbNoRemunerativo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoRemunerativo.Checked)
            {
                dgvDatos.Columns["NoRem"].Visible = true;
                txtPorcentajeNoRemunerativo.Enabled = true;
                lblPorc.Enabled = true;
                txtPorcentajeNoRemunerativo.Text = objLConcepto.ObtenerUno(1).Valor.ToString();
                txtPorcentajeNoRemunerativo.Focus();
            }
            else
            {
                dgvDatos.Columns["NoRem"].Visible = false;
                txtPorcentajeNoRemunerativo.Enabled = false;
                lblPorc.Enabled = false;
                txtPorcentajeNoRemunerativo.Text = "";
            }
        }

        private void txtPorcentajeNoRemunerativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void txtPorcentajeNoRemunerativo_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                /* if (item.Cells["FaltasInjustificadas"].Value == null)
                     item.Cells["FaltasInjustificadas"].Value = "";
                 injus = (item.Cells["FaltasInjustificadas"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(item.Cells["FaltasInjustificadas"].Value);
                 double descontar = Utilidades.Redondear.DosDecimales(injus * Utilidades.Redondear.DosDecimales(Convert.ToDouble(item.Cells["Sueldo"].Value) / 30));
                             
                 
                 
                 */
                double adiOS = item.Cells["AOS"].Value.Equals("") ? 0 : Convert.ToDouble(item.Cells["AOS"].Value);
                adelantos = item.Cells["Adelanto"].Value.ToString().Equals("") ? 0 : Convert.ToDouble(item.Cells["Adelanto"].Value);
                embargos = (item.Cells["Embargo"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(item.Cells["Embargo"].Value);
                double ren = item.Cells["NoRem2"].Value.Equals("") ? 0 : Convert.ToDouble(item.Cells["NoRem2"].Value);
                item.Cells["NoRem"].Value = CalcularNoRemunerativo(Convert.ToDouble(item.Cells["Sueldo"].Value) + Convert.ToDouble(item.Cells["Licencia"].Value) + Convert.ToDouble(item.Cells["Inasistencias"].Value), Convert.ToDouble(item.Cells["Ant"].Value), Convert.ToDouble(item.Cells["Pres"].Value), Convert.ToDouble(item.Cells["Vac"].Value));
                item.Cells["Tot"].Value = CalcularTotal(Convert.ToDouble(item.Cells["Sueldo"].Value)+ Convert.ToDouble(item.Cells["Licencia"].Value)+ Convert.ToDouble(item.Cells["Inasistencias"].Value), Convert.ToDouble(item.Cells["Ant"].Value), Convert.ToDouble(item.Cells["Pres"].Value), Convert.ToDouble(item.Cells["Vac"].Value), Convert.ToDouble(item.Cells["NoRem"].Value), ren, Convert.ToDouble(item.Cells["Jubilaciones"].Value), Convert.ToDouble(item.Cells["Ley"].Value), Convert.ToDouble(item.Cells["Obra"].Value), adiOS, Convert.ToDouble(item.Cells["Sindi"].Value), Convert.ToDouble(item.Cells["Seguro"].Value),adelantos, embargos);
            }

        }
        double CalcularNoRemunerativo(double sueldo, double antiguedad, double presentismo, double vacaciones) {
            double porcentaje = (txtPorcentajeNoRemunerativo.Text.Equals("")) ? 0 : Convert.ToDouble(txtPorcentajeNoRemunerativo.Text) / 100;
            double total = sueldo + antiguedad + presentismo + vacaciones;
            return Utilidades.Redondear.SinDecimales(total * porcentaje);
        }

        private void cbNoRemu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoRemu.Checked)
            {
                dgvDatos.Columns["NoRem2"].Visible = true;
                txtNoRem.Enabled = true;
                txtNoRem.Focus();
            }
            else
            {
                dgvDatos.Columns["NoRem2"].Visible = false;
                txtNoRem.Enabled = false;
                txtNoRem.Text = "";
            }
        }

        private void txtNoRem_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                item.Cells["NoRem2"].Value = txtNoRem.Text.Equals("")?0:Convert.ToDouble(txtNoRem.Text);
                adelantos = (item.Cells["Adelanto"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(item.Cells["Adelanto"].Value);
                embargos = (item.Cells["Embargo"].Value.ToString().Equals("")) ? 0 : Convert.ToDouble(item.Cells["Embargo"].Value);
                item.Cells["Tot"].Value = CalcularTotal(Convert.ToDouble(item.Cells["Sueldo"].Value) + Convert.ToDouble(item.Cells["Licencia"].Value) + Convert.ToDouble(item.Cells["Inasistencias"].Value), Convert.ToDouble(item.Cells["Ant"].Value), Convert.ToDouble(item.Cells["Pres"].Value), Convert.ToDouble(item.Cells["Vac"].Value), Convert.ToDouble(item.Cells["NoRem"].Value), Convert.ToDouble(item.Cells["NoRem2"].Value), Convert.ToDouble(item.Cells["Jubilaciones"].Value), Convert.ToDouble(item.Cells["Ley"].Value), Convert.ToDouble(item.Cells["Obra"].Value), Convert.ToDouble(item.Cells["AOS"].Value), Convert.ToDouble(item.Cells["Sindi"].Value), Convert.ToDouble(item.Cells["Seguro"].Value),adelantos,embargos);
            }
            /*foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                item.Cells["NoRem"].Value = CalcularNoRemunerativo(Convert.ToDouble(item.Cells["Sueldo"].Value), Convert.ToDouble(item.Cells["Ant"].Value), Convert.ToDouble(item.Cells["Pres"].Value), Convert.ToDouble(item.Cells["Vac"].Value));
                double ren = item.Cells["NoRem2"].Value.Equals("") ? 0 : Convert.ToDouble(item.Cells["NoRem2"].Value);
                item.Cells["Total"].Value = CalcularTotal(Convert.ToDouble(item.Cells["Sueldo"].Value), Convert.ToDouble(item.Cells["Ant"].Value), Convert.ToDouble(item.Cells["Pres"].Value), Convert.ToDouble(item.Cells["Vac"].Value), Convert.ToDouble(item.Cells["NoRem"].Value), ren, Convert.ToDouble(item.Cells["Jubilaciones"].Value), Convert.ToDouble(item.Cells["Ley"].Value), Convert.ToDouble(item.Cells["Obra"].Value), Convert.ToDouble(item.Cells["Sindi"].Value), Convert.ToDouble(item.Cells["Seguro"].Value));
            }*/
        }

        private void txtNoRem_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPorcentajeNoRemunerativo.Text == null)
                    txtPorcentajeNoRemunerativo.Text = "";
                double valor = txtPorcentajeNoRemunerativo.Text.Trim().Equals("") ? 0 : Convert.ToDouble(txtPorcentajeNoRemunerativo.Text);
                Entidades.ConceptoAsociadoASueldo objEConcepto = new Entidades.ConceptoAsociadoASueldo(1,valor);
                objLConcepto.NoRemunerativoActualizar(objEConcepto);
                Entidades.Empleado objEEmpleado;
                Entidades.Salario objESalario;
                bool validar = false;
                if (MessageBox.Show("¿Esta seguro que desea guardar los comprobantes?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                /*
                foreach (DataGridViewRow item in dgvDatos.Rows) {
                    if (Convert.ToBoolean(item.Cells["Seleccionado"].Value)==true) {
                        objESalario = new Entidades.Salario();
                        objESalario.Fecha = dtpFecha.Value.Date;
                        objESalario.TipoSalario.Codigo = Convert.ToInt32(cbTipoSalario.SelectedValue);
                        objESalario.Periodo = cbPeriodo.SelectedValue.ToString();
                        objEEmpleado = new Entidades.Empleado();
                        objEEmpleado.Codigo = Convert.ToInt32(item.Cells["CodigoEmpleado"].Value);
                       
                        if (Convert.ToInt32(cbTipoSalario.SelectedValue) != 2)
                        {
                            objEEmpleado.SueldoEfectivo = Convert.ToDouble(item.Cells["SueldoBasico"].Value);
                        }
                        else {
                            objEEmpleado.SueldoEfectivo = Convert.ToDouble(item.Cells["ControlBasico"].Value);
                        }
                        
                        objESalario.Empleado = objEEmpleado;
                        objESalario.Monto= Convert.ToDouble(item.Cells["Tot"].Value);
                        Entidades.SalarioDetalle objESalarioDetalle=new Entidades.SalarioDetalle();
                        objESalarioDetalle.ConceptoSalario.Codigo = 1;
                        objESalarioDetalle.Monto = objEEmpleado.Sueldo;
                        objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        if (Convert.ToDouble(item.Cells["DiasTrabajados"].Value) > 0)
                        {
                        objESalarioDetalle = new Entidades.SalarioDetalle();
                        objESalarioDetalle.ConceptoSalario.Codigo = 2;
                        objESalarioDetalle.Unidades = Convert.ToInt32(item.Cells["DiasTrabajados"].Value);
                        objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Sueldo"].Value);
                        objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }

                        if (Convert.ToDouble(item.Cells["Ant"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 3;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Ant"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Pres"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 4;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Pres"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Inasistencias"].Value) < 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 5;
                            objESalarioDetalle.Unidades = Convert.ToDouble(item.Cells["FaltasInjustificadas"].Value);
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Inasistencias"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Licencia"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 6;
                            objESalarioDetalle.Unidades = Convert.ToDouble(item.Cells["FaltasJustificadas"].Value);
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Licencia"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Vac"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 7;
                            objESalarioDetalle.Unidades = Convert.ToInt32(item.Cells["DiasVacaciones"].Value);
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Vac"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["NoRem"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 8;
                            objESalarioDetalle.Descripcion = txtPorcentajeNoRemunerativo.Text + " %";
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["NoRem"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (item.Cells["NoRem2"].Value != null && !item.Cells["NoRem2"].Value.Equals("") && Convert.ToDouble(item.Cells["NoRem2"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 9;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["NoRem2"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Jubilaciones"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 10;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Jubilaciones"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Ley"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 11;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Ley"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Obra"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 12;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Obra"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Sindi"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 13;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Sindi"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Seguro"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 14;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Seguro"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["AOS"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 15;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["AOS"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Adelanto"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 16;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Adelanto"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToDouble(item.Cells["Embargo"].Value) > 0)
                        {
                            objESalarioDetalle = new Entidades.SalarioDetalle();
                            objESalarioDetalle.ConceptoSalario.Codigo = 17;
                            objESalarioDetalle.Monto = Convert.ToDouble(item.Cells["Embargo"].Value);
                            objESalario.SalarioDetalle.Add(objESalarioDetalle);
                        }
                        if (Convert.ToInt32(cbTipoSalario.SelectedValue)==1)
                            objLEmpleado.ActualizarSueldo(objEEmpleado);
                        Logica.Salario objLSalario = new Logica.Salario();
                        
                        if (objLSalario.Agregar(objESalario) > 0)
                        {
                            item.Cells["Seleccionado"].Value = false;
                            validar = true;
                        }
                        else {
                            MessageBox.Show("El Salario del Empleado " + item.Cells["Empleado"].Value.ToString() + " ya fue cargado anteriormente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }*/
                if (validar == true) {
                    MessageBox.Show("Salarios guardados exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoSalario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTipoSalario.SelectedValue) == 2)
            {
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    dr.Cells["SueldoBasico"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dr.Cells["ControlBasico"].Value) / 2);
                }
            }
            else {
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    dr.Cells["SueldoBasico"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dr.Cells["ControlBasico"].Value));
                }
            }
            if (Convert.ToInt32(cbTipoSalario.SelectedValue) ==4)
            {
                //cbNoRemunerativo.Checked = false;
                cbNoRemu.Checked = true;
                txtNoRem.Focus();
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    dr.Cells["DiasTrabajados"].Value = 0;
                    
                }
            }
            else
            {
               // cbNoRemunerativo.Checked = true;
                cbNoRemu.Checked = false;
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    dr.Cells["DiasTrabajados"].Value = 30;
                 
                }
            }
            CargarGrilla();
        }

        private void cbAdelantos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAdelantos.Checked)
            {
                dgvDatos.Columns["Adelanto"].Visible = true;
            }
            else
            {
                dgvDatos.Columns["Adelanto"].Visible = false;
            }
        }

        private void cbEmbargos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmbargos.Checked)
            {
                dgvDatos.Columns["Embargo"].Visible = true;
            }
            else
            {
                dgvDatos.Columns["Embargo"].Visible = false;
            }
        }

        private void frmCargaSalarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea Cerrar la Ventana?\nSe perderan los Cambios", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cbPuestos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPuestos.Checked)
            {
                dgvDatos.Columns["Puestos"].Visible = true;
            }
            else
            {
                dgvDatos.Columns["Puestos"].Visible = false;
            }
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarValores();
                //CargarGrilla();
            }
            catch (Exception) {
                MessageBox.Show("Error al seleccionar Fecha", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFecha.Value = DateTime.Now;
            }
        }



        private void frmCargaSalarios_Load(object sender, EventArgs e)
        {

        }



        private void cbFaltas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFaltas.Checked)
            {
                dgvDatos.Columns["DiasTrabajados"].Visible = true;
                dgvDatos.Columns["FaltasJustificadas"].Visible = true;
                dgvDatos.Columns["FaltasInjustificadas"].Visible = true;
            }
            else
            {
                dgvDatos.Columns["DiasTrabajados"].Visible = false;
                dgvDatos.Columns["FaltasJustificadas"].Visible = false;
                dgvDatos.Columns["FaltasInjustificadas"].Visible = false;
            }
        }
    }
}
