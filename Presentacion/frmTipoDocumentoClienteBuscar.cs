using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmTipoDocumentoClienteBuscar : frmColor
    {
       Logica.TipoDocumentoCliente objLTipoDocumentoCliente = new Logica.TipoDocumentoCliente();
       Entidades.TipoDocumentoCliente objETipoDocumentoCliente = new Entidades.TipoDocumentoCliente();
       

       // DataTable dtEmpleados = new DataTable("dtEmpleados");
       DataView dvTipoDocumentoCliente = new DataView();

       public frmTipoDocumentoClienteBuscar(string llamada, Form f)
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
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.MultiSelect = false;
            dgvDatos.Columns["Codigo"].Width = 43;
            dgvDatos.Columns["Estado"].Width = 43;
        }
        
        private void Titulo()
        {
            this.Text = "BUSQUEDA DE TIPO DE DOCUMENTO DE CLIENTES";
        }
        
        private void CargarValores()
        {
            TraerTipoDocumento();
        }

        private void TraerTipoDocumento() {
            try
            {
                dvTipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerTodos().DefaultView;
                dgvDatos.DataSource = dvTipoDocumentoCliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvTipoDocumentoCliente.RowFilter = "Descripcion like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvTipoDocumentoCliente;
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
                    objETipoDocumentoCliente = objLTipoDocumentoCliente.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                    //DataTable dt = objLogicaProveedor.ObtenerComunicaciones(objEntidadProveedor);
                       if (Llamada.Equals("TipoDocumento")) { 
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmTipoDocumentoCliente(objETipoDocumentoCliente));
                        }
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
