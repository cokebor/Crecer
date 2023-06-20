using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Presentacion
{
    public partial class frmVacaciones : Presentacion.frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();

        Logica.Empleado objLEmpleado = new Logica.Empleado();
        public frmVacaciones()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            LlenasCombo();
            Utilidades.Combo.SeleccionarPrimerValor(cbPeriodo);
        }
        private void Titulo()
        {
            this.Text = "VACACIONES";
        }

        private void LimitesTamaños()
        {

        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbPeriodo);
            dgvDatos.Columns["Legajo"].Width = 50;
            dgvDatos.Columns["Empleado"].Width = 180;
            dgvDatos.Columns["Desde"].Width = 75;
            dgvDatos.Columns["Hasta"].Width = 75;
            dgvDatos.Columns["Dias"].Width = 50;
            dgvDatos.Columns["DiasPendientes"].Width = 70;

        }
        public void LlenasCombo()
        {
            int ano = DateTime.Now.Year;

            for (int i = ano - 2; i < ano + 2; i++)
            {
                cbPeriodo.Items.Add(i);
            }
        }

        private void txtCodigoEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("Vacaciones", this));
                    break;
            }
        }

        private int diasVacCorresponden = 0;
        private int diasVacPendientes;
        private void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoEmpleado.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoEmpleado.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreEmpleado.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                        CalculoVacaciones();
                    }
                    else
                    {
                        lblNombreEmpleado.Text = "";
                        lblDiasCorresponden.Text = "0";
                        lblDiasPendientes.Text = "0";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreEmpleado.Text = "";
                    lblDiasCorresponden.Text = "0";
                    lblDiasPendientes.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime desde, hasta;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblNombreEmpleado.Text.Equals(""))
                {
                    desde = dtDesde.Value.Date;
                    hasta = dtHasta.Value.Date;


                    if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                    {
                        MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        /*if (cbLote.SelectedValue != null)
                        {*/
                        if (fila.Cells["CodigoEmpleado"].Value.ToString() == txtCodigoEmpleado.Text.Trim())
                        {
                            MessageBox.Show("Empleado ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //}
                    }


                    //if (diasVacCorresponden >= Utilidades.Fechas.DiferenciaEntreFechasEnDias(dtHasta.Value, dtDesde.Value))
                    if (diasVacPendientes >= Utilidades.Fechas.DiferenciaEntreFechasEnDias(dtHasta.Value, dtDesde.Value))
                    {
                        dgvDatos.Rows.Add(objEEmpleado.Codigo, objEEmpleado.Legajo, objEEmpleado.NombreCompleto, cbPeriodo.Text, dtDesde.Value, dtHasta.Value, Utilidades.Fechas.DiferenciaEntreFechasEnDias(dtHasta.Value, dtDesde.Value), diasVacCorresponden - Utilidades.Fechas.DiferenciaEntreFechasEnDias(dtHasta.Value, dtDesde.Value));
                        LimpiarAlAgregar();
                    }
                    else
                    {
                        MessageBox.Show(objEEmpleado.NombreCompleto + " no dispone de Dias disponibles para vacaciones seleccionadas", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Empleado valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculoVacaciones() {
            diasVacCorresponden = DiasVacacionesCorresponden();
            diasVacPendientes = diasVacCorresponden - objLEmpleado.ObtenerDiasVacacionesYaTomados(objEEmpleado, Convert.ToInt32(cbPeriodo.Text));
            lblDiasCorresponden.Text = diasVacCorresponden.ToString();
            lblDiasPendientes.Text = diasVacPendientes.ToString();
        }
        private int DiasVacacionesCorresponden()
        {
            int antiguedadAños = 0, dias = 0, antiguedadMeses = 0; ;
            DateTime fecha = new DateTime(Convert.ToInt32(cbPeriodo.Text), 12, 31, 0, 0, 0);
            if (objEEmpleado.FechaIngreso < fecha)
            {
                antiguedadAños = Utilidades.Fechas.DiferenciaEntreFechasEnAños(fecha, objEEmpleado.FechaIngreso);
                //antiguedadMeses = fecha.AddTicks(-Convert.ToDateTime(objEEmpleado.FechaIngreso).Ticks).Month - 1;
                //antiguedadMeses= (fecha.Month - objEEmpleado.FechaIngreso.Month) + 12 * (fecha.Year - objEEmpleado.FechaIngreso.Year);
                antiguedadMeses = Utilidades.Fechas.DiferenciaEntreFechasEnMeses(fecha, objEEmpleado.FechaIngreso);

                if (antiguedadMeses < 6)
                {
                    dias = CalcularDias(fecha);
                }
                else
                {
                    if (antiguedadAños < 5)
                        dias = 14;
                    else if (antiguedadAños < 10)
                        dias = 21;
                    else if (antiguedadAños < 20)
                        dias = 28;
                    else //if (antiguedad < 10)
                        dias = 35;
                }
            }

            return dias;
        }

        private int CalcularDias(DateTime pFecha)
        {
            int diasVacaciones = 0;

            frmCantidadDias f = new frmCantidadDias(objEEmpleado);
            f.StartPosition = FormStartPosition.CenterScreen;

            if (f.ShowDialog() == DialogResult.OK)
            {
                int diasTrabajados = f.CantidadDias;
                diasVacaciones = Utilidades.Redondear.SinDecimalesEntero((float)diasTrabajados / 20);
            }
            return diasVacaciones;
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!Utilidades.Validar.LabelEnBlanco(lblNombreEmpleado))
                {
                    CalculoVacaciones();
                }
                else {
                    lblDiasCorresponden.Text = "0";
                    lblDiasPendientes.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarAlAgregar()
        {
            txtCodigoEmpleado.Text = "";
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.Rows.Count > 0)
                {
                    Entidades.Vacaciones vacaciones;
                    List<Entidades.Vacaciones> listaVacaciones = new List<Entidades.Vacaciones>();
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        vacaciones = new Entidades.Vacaciones();
                        vacaciones.Empleado.Codigo = Convert.ToInt32(item.Cells["CodigoEmpleado"].Value);
                        vacaciones.Periodo = Convert.ToInt32(item.Cells["Periodo"].Value);
                        vacaciones.Desde = Convert.ToDateTime(item.Cells["Desde"].Value);
                        vacaciones.Hasta = Convert.ToDateTime(item.Cells["Hasta"].Value);
                        vacaciones.DiasTomados = Convert.ToInt32(item.Cells["Dias"].Value);
                        listaVacaciones.Add(vacaciones);
                    }
                    objLEmpleado.AgregarVacaciones(listaVacaciones, Singleton.Instancia.Usuario);
                    MessageBox.Show("Fechas Cargadas Exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else {
                    MessageBox.Show("No se cargo ninguna Fecha de Vacaciones", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvDatos.Columns[e.ColumnIndex].Name)
                {
                    case "Cancelar":
                        dgvDatos.Rows.RemoveAt(e.RowIndex);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtCodigoEmpleado.Text = "";
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            Utilidades.Combo.SeleccionarPrimerValor(cbPeriodo);
            dgvDatos.Rows.Clear();
        }
    }
}
