using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmNumeradorBuscar : frmColor
    {
       Logica.Numerador objLogicaNumerador = new Logica.Numerador();
       Entidades.Numerador objEntidadNumerador = new Entidades.Numerador();
       

       // DataTable dtEmpleados = new DataTable("dtEmpleados");
       DataView dvProveedores = new DataView();

       public frmNumeradorBuscar(string llamada, Form f)
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
            Utilidades.Formularios.ConfiguracionInicial(this);
            CargarValores();
        }
        
        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 43;
        }
        
        private void Titulo()
        {
            this.Text = "BUSQUEDA DE NUMERADORES";
        }
        
        private void CargarValores()
        {
            TraerNumeradores();
        }

        private void TraerNumeradores() {
            try
            {
                dvProveedores = objLogicaNumerador.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvProveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvProveedores.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvProveedores;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    try { 
                    objEntidadNumerador = objLogicaNumerador.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                    //DataTable dt = objLogicaProveedor.ObtenerComunicaciones(objEntidadProveedor);
                       if (Llamada.Equals("TipoDocumento")) 
                            ((frmTipoDocumentoCliente)formularioAnterior).txtCodigoNumerador.Text = objEntidadNumerador.Codigo.ToString();
                        if (Llamada.Equals("TipoDocumentoProveedor"))
                            ((frmTipoDocumentoProveedor)formularioAnterior).txtCodigoNumerador.Text = objEntidadNumerador.Codigo.ToString();
                        
                        this.Close();
                    }catch(Exception ex){
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
