using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmRemitoClienteBuscar : frmColor
    {
       Logica.RemitoCliente objLogicaRemito = new Logica.RemitoCliente();
       Entidades.RemitoCliente_M objEntidadRemito = new Entidades.RemitoCliente_M();
       

       // DataTable dtEmpleados = new DataTable("dtEmpleados");
       DataView dvRemitos = new DataView();

       public frmRemitoClienteBuscar(string llamada, Form f, int codigoCliente)
       {
            InitializeComponent();
            Llamada = llamada;
            Formulario = f;
            CodigoCliente = codigoCliente;
            ConfiguracionInicial();
            
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
            dgvDatos.Columns["Fecha"].Width = 60;
            dgvDatos.Columns["Remito"].Width = 100;
            /* dgvDatos.Columns["Codigo"].Width = 43;
             dgvDatos.Columns["Legajo"].Width = 43;
             dgvDatos.Columns["DNI"].Width = 60;*/
        }
        
        private void Titulo()
        {
            this.Text = "BUSQUEDA DE REMITOS";
        }
        
        private void CargarValores()
        {
            TraerRemitos();
        }

        private void TraerRemitos() {
            try
            {
                Entidades.Cliente objCliente = new Entidades.Cliente();
                objCliente.Codigo = CodigoCliente;
               
                dvRemitos = objLogicaRemito.ObtenerTodos(objCliente).DefaultView;
                dgvDatos.DataSource = dvRemitos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDato_TextChanged(object sender, EventArgs e)
        {
            dvRemitos.RowFilter = "NumRemito like '%" + txtDato.Text.Trim() + "%'";
            dgvDatos.DataSource = dvRemitos;
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
                        objEntidadRemito = objLogicaRemito.ObtenerUno(Convert.ToInt32(row.Cells["Codigo"].Value));
                        if (Llamada.Equals("Remito")) {
                            Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoCliente(objEntidadRemito));

                            // ((frmRemitoProveedor)Formulario).txtCodigoProveedor.Text = objEntidadRemito.Proveedor.Codigo.ToString();
                            // ((frmRemitoProveedor)Formulario).txtNumeroComprobante1.cargarValor(objEntidadRemito.NumRemito);
                            // ((frmRemitoProveedor)Formulario).cbCanal
                        }
                        this.Close();
                    
                    }catch(Exception ex){
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string llamada;
        private Form formulario;
        private int codigoCliente;
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

        public Form Formulario
        {
            get
            {
                return formulario;
            }

            set
            {
                formulario = value;
            }
        }

        public int CodigoCliente
        {
            get
            {
                return codigoCliente;
            }

            set
            {
                codigoCliente = value;
            }
        }

        private void frmRemitoClienteBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objEntidadRemito.Codigo == 0)
            {
                if (Llamada.Equals("Remito"))
                {
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmRemitoCliente());
                }
            }
        }
    }
}
