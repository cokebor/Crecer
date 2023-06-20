using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmEmpleadoBuscar : frmColor
    {
        Logica.Empleado objLogicaEmpleado = new Logica.Empleado();
        Entidades.Empleado objEntidadEmpleado = new Entidades.Empleado();


        // DataTable dtEmpleados = new DataTable("dtEmpleados");
        DataView dvEmpleados = new DataView();

        public frmEmpleadoBuscar(string llamada, Form f)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Llamada = llamada;
            FormularioAnterior = f;
        }
        private void ConfiguracionInicial()
        {
            Formatos();
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 33;
            dgvDatos.Columns["Legajo"].Width = 33;
            dgvDatos.Columns["DNI"].Width = 47;
            dgvDatos.Columns["Estado"].Width = 39;
        }

        private void Titulo()
        {
            this.Text = "BUSQUEDA DE EMPLEADOS";
        }

        private void CargarValores()
        {
            TraerEmpleados();
        }

        private void TraerEmpleados()
        {
            try
            {
                dvEmpleados = objLogicaEmpleado.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvEmpleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvEmpleados.RowFilter = "Apellido like '%" + txtDato.Text.Trim() + "%' or Nombres like '%" + txtDato.Text.Trim() + "%' or NumeroDocumento like '%" + txtDato.Text.Trim() + "%' or Legajo like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvEmpleados;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    try
                    {
                        objEntidadEmpleado = objLogicaEmpleado.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        DataTable dt = objLogicaEmpleado.ObtenerComunicaciones(objEntidadEmpleado);
                        switch (Llamada)
                        {
                            case "ComprobanteCaja":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFactura)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmFactura)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ComprobanteCajaManual":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFacturaManual)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmFacturaManual)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "Licencias":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLicencias)FormularioAnterior).txtCodigoEmpleado.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmLicencias)FormularioAnterior).txtCodigoEmpleado.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NC":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNC)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmNC)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "Adelantos":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmAdelantos)FormularioAnterior).txtCodigoEmpleado.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmAdelantos)FormularioAnterior).txtCodigoEmpleado.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "Vacaciones":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmVacaciones)FormularioAnterior).txtCodigoEmpleado.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmVacaciones)FormularioAnterior).txtCodigoEmpleado.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCVacios":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCVacios)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmNCVacios)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCAjuste":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCAjuste)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmNCAjuste)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "ND":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmND)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmND)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NDCheque":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNDChequesRechazados)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmNDChequesRechazados)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "LiquidacionRemitoCliente":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmLiquidacionRemitoCliente)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmLiquidacionRemitoCliente)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "Descuentos":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmDescuentos)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmDescuentos)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "SaldoInicial":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSaldoInicialCliente)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmSaldoInicialCliente)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case "SaldoInicialVentas":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmSaldoInicialVentas)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmSaldoInicialVentas)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "NCLotes":
                                if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmNCLotes)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                    ((frmNCLotes)FormularioAnterior).txtCodigoVendedor.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                                
                            case "Alta":
                                Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleado(objEntidadEmpleado, dt));
                                break;
                        }
                        /*
                        if (Llamada.Equals("ComprobanteCaja")) {
                            if (objEntidadEmpleado.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                            {
                                ((frmFactura)FormularioAnterior).txtCodigoVendedor.Text = objEntidadEmpleado.Codigo.ToString();
                                ((frmFactura)FormularioAnterior).txtCodigoVendedor.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Empleado Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else { 
                        if (Llamada.Equals("Alta")) { 
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleado(objEntidadEmpleado, dt));
                            }
                        }*/
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private string llamada;
        private Form formularioAnterior;

        public string Llamada
        {
            get
            {
                return llamada;
            }

            set
            {
                llamada = value;
            }
        }

        public Form FormularioAnterior
        {
            get
            {
                return formularioAnterior;
            }

            set
            {
                formularioAnterior = value;
            }
        }

        private void frmEmpleadoBuscar_Load(object sender, EventArgs e)
        {

        }

        private void frmEmpleadoBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Llamada.Equals("Alta"))
                Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleado());
        }
    }
}