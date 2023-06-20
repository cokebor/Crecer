using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmEmpleadosBancos : Presentacion.frmColor
    {
        public frmEmpleadosBancos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            // LimitesTamaños();
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Formatos();
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "BANCOS PARA SUELDOS";
        }

        private void Formatos()
        {
            //Apariencia
            //Color de fondo
            dgvDatos.BackgroundColor = SystemColors.AppWorkspace;
            //Tipo de Borde
            dgvDatos.BorderStyle = BorderStyle.FixedSingle;
            //Color de lineas de cuadricola
            dgvDatos.GridColor = SystemColors.ControlDark;
            //dg.GridColor = Color.SkyBlue;
            //Indica si se muestran los encabezados de las filas
            dgvDatos.RowHeadersVisible = false;


            //Color de fila seleccionada
            //dg.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvDatos.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;


            //Color de Letra seleccionada
            // dg.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvDatos.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            //Comportamiento
            //Indica si mostramos al usuario la opcion agregar fias
            dgvDatos.AllowUserToAddRows = false;
            //Indica si el usuario puede eliminar filas
            dgvDatos.AllowUserToDeleteRows = false;
            //Indica si el usuario puede cambiar el orden de las columnas
            dgvDatos.AllowUserToOrderColumns = true;
            //Indica si los usuarios pueden cambiar el tamaño de la columna
            dgvDatos.AllowUserToResizeColumns = false;
            //Indica si los usuarios pueden cambiar el tamaño de las filas
            dgvDatos.AllowUserToResizeRows = false;
            //Indica si se pueden seleccionar mas de una celda, fila o columna
            dgvDatos.MultiSelect = false;
            //Indica si se pueden modificar los valores de las celdas
            //dg.ReadOnly = true;
            foreach (DataGridViewColumn dgvr in dgvDatos.Columns)
            {
                if(!dgvr.Name.Equals("Banco") && !dgvr.Name.Equals("CuentaBancaria"))
                    dgvr.ReadOnly = true;
            }
            //Forma de seleccion de filas
           // dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Diseño
            //Modo de ajuste automatico de las columnas


            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void CargarValores()
        {

            try
            {
                CargarEmpleados();
                CargarBancos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarEmpleados() {
            Logica.Empleado objLEmpleado = new Logica.Empleado();

            dgvDatos.DataSource = objLEmpleado.ObtenerActivos();

        
        }

        

        private void CargarBancos() {
            DataGridViewComboBoxColumn combo = dgvDatos.Columns["Banco"] as DataGridViewComboBoxColumn;
            
            combo.DataSource = new Logica.Banco().ObtenerActivosDeCuentasActivas();
            combo.DisplayMember = "Banco";
            combo.ValueMember = "CodigoBanco";
            
        }
        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                funcion(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void funcion(DataGridViewCellEventArgs e) {
            if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("Banco"))
            {
                DataGridViewComboBoxCell combo = dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                Entidades.Banco b = new Entidades.Banco();
                b.Codigo = Convert.ToInt32(combo.Value);
                DataGridViewComboBoxCell combo2 = dgvDatos.Rows[e.RowIndex].Cells["CuentaBancaria"] as DataGridViewComboBoxCell;
                combo2.DataSource = new Logica.CuentaBancaria().ObtenerDeBancos(b);
                combo2.DisplayMember = "NumeroCuenta";
                combo2.ValueMember = "Codigo";
                
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    DataGridViewComboBoxCell combo2 = dgvDatos.Rows[item.Index].Cells["CuentaBancaria"] as DataGridViewComboBoxCell;
                    if (Convert.ToInt32(combo2.Value) != 0) { 
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
