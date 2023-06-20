using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmImpuestoBuscar : frmColor
    {
        Logica.Impuesto objLogicaImpuesto = new Logica.Impuesto();
        Entidades.Impuesto objEntidadImpuesto = new Entidades.Impuesto();


        // DataTable dtEmpleados = new DataTable("dtEmpleados");
        DataView dvImpuestos = new DataView();

        public frmImpuestoBuscar(string llamada, Form f)
        {
            InitializeComponent();
            Llamada = llamada;
            ConfiguracionInicial();

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
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 43;
            dgvDatos.Columns["Estado"].Width = 39;
        }

        private void Titulo()
        {
            this.Text = "BUSQUEDA DE IMPUESTOS";
        }

        private void CargarValores()
        {
            TraerImpuestos();
        }

        private void TraerImpuestos()
        {
            try
            {
             //   if (Llamada.Equals("FacturaCompra"))
                    //dvImpuestos = objLogicaImpuesto.ObtenerTodosCompras().DefaultView;
                    dvImpuestos = objLogicaImpuesto.ObtenerTodosVentas().DefaultView;
             //   else if (Llamada.Equals("PagosClientes"))
             //       dvImpuestos = objLogicaImpuesto.ObtenerTodosVentas().DefaultView;

                dgvDatos.DataSource = dvImpuestos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvImpuestos.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvImpuestos;
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
                        objEntidadImpuesto = objLogicaImpuesto.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        switch (Llamada)
                        {
                            case "FacturaCompra":
                                if (objEntidadImpuesto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmFacturaCompra)formularioAnterior).txtCodigoImpuesto.Text = objEntidadImpuesto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmFacturaCompra)formularioAnterior).txtCodigoImpuesto.Text = "";
                                    MessageBox.Show("Impuesto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "DocumentosCaja":
                                if (objEntidadImpuesto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmDocumentosDeCaja)formularioAnterior).txtCodigoImpuesto.Text = objEntidadImpuesto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmDocumentosDeCaja)formularioAnterior).txtCodigoImpuesto.Text = "";
                                    MessageBox.Show("Impuesto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case "PagosClientes":
                                if (objEntidadImpuesto.Estado == Enumeraciones.Enumeraciones.Estados.Activo)
                                {
                                    ((frmClientesPagos)formularioAnterior).txtCodigoImpuesto.Text = objEntidadImpuesto.Codigo.ToString();
                                }
                                else
                                {
                                    ((frmClientesPagos)formularioAnterior).txtCodigoImpuesto.Text = "";
                                    MessageBox.Show("Impuesto Anulado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                        }
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

        private Form formularioAnterior;
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

    }
}
