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
    public partial class frmPermisos : frmColor
    {
        Logica.GrupoDeUsuario objLogicaGrupoDeUsuario = new Logica.GrupoDeUsuario();
        Logica.GrupoMenu objLogicaGrupoMenu = new Logica.GrupoMenu();
        Logica.Menu objLogicaMenu = new Logica.Menu();
        Logica.Permiso objLogicaPermisos = new Logica.Permiso();

        DataTable dtPermisos = new DataTable("dtPermisos");

        public frmPermisos(int codigoGrupoUsuario)
        {
            InitializeComponent();
            //CodigoGrupoUsuario = codigoGrupoUsuario;
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Titulo();
            Formatos();
            CargarValores();
            Actualizar();
            Utilidades.Combo.SeleccionarPrimerValor(cbGruposDeUsuarios);
        }

        private void Titulo()
        {
            this.Text = "PERMISOS DE GRUPOS";
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbGruposDeUsuarios);
            dgvDatos.Columns["Seleccionado"].Width = 40;
            dgvDatos.AllowUserToResizeColumns = false;

            DataColumn CodigoGrupo = dtPermisos.Columns.Add("CodigoGrupo", typeof(int));
            DataColumn CodigoMenu = dtPermisos.Columns.Add("CodigoMenu", typeof(int));
            //dgvDatos.Columns["Menu"].Width = 100;
        }

        private void CargarValores()
        {

            try
            {
                Utilidades.Combo.Llenar(cbGruposDeUsuarios, objLogicaGrupoDeUsuario.ObtenerActivos(), "Codigo", "Descripcion");
                TraerMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerMenus()
        {
            try
            {
                DataTable dtGrupos = objLogicaGrupoMenu.ObtenerTodos();
                DataTable dtMenu = objLogicaMenu.ObtenerTodos();
                foreach (DataRow drG in dtGrupos.Rows)
                {
                    dgvDatos.Rows.Add(drG["Codigo"],"", 0, drG["Descripcion"]);
                    foreach (DataRow drM in dtMenu.Rows)
                    {
                        if(Convert.ToInt32(drG["Codigo"])== Convert.ToInt32(drM["CodigoGrupoMenu"]))
                        dgvDatos.Rows.Add("", drM["Codigo"], 0, "       " + drM["Menu"]);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgvc = dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
            if (Convert.ToBoolean(dgvc.Value) == true)
            {
                dgvc.Value = false;
            }
            else {
                dgvc.Value = true;
            }
        }
        
        /*
        private int codigoGrupoUsuario;
        public int CodigoGrupoUsuario
        {
            get { return codigoGrupoUsuario; }
            set { codigoGrupoUsuario = value; }
        }
        */
        private void Actualizar() {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                dr.Cells["Seleccionado"].Value = false;
            }


                try
            {
                
                DataTable dtPermisos = objLogicaPermisos.ObtenerTodos(Convert.ToInt32(cbGruposDeUsuarios.SelectedValue));
                foreach (DataRow drP in dtPermisos.Rows) {
                    foreach (DataGridViewRow dr in dgvDatos.Rows)
                    {
                        if (dr.Cells["CodigoMenu"].Value.Equals(drP["CodigoMenu"]))
                        {
                            //MessageBox.Show(dr.Cells["CodigoMenu"].Value.ToString());
                            dr.Cells["Seleccionado"].Value = true;
                        }
                        if (dr.Cells["CodigoGrupo"].Value.Equals(drP["CodigoGrupoMenu"]))
                        {
                            dr.Cells["Seleccionado"].Value = true;
                        }
                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            dtPermisos.Clear();
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (item.Cells["Seleccionado"].Value.Equals(true) && !item.Cells["CodigoMenu"].Value.Equals("")) {
                    DataRow filaPermiso = dtPermisos.NewRow();
                    filaPermiso[0] = Convert.ToInt32(cbGruposDeUsuarios.SelectedValue);
                    filaPermiso[1] = Convert.ToInt32(item.Cells["CodigoMenu"].Value);
                    dtPermisos.Rows.Add(filaPermiso);
                }
            }
            try
            {
                objLogicaPermisos.Insertar(Convert.ToInt32(cbGruposDeUsuarios.SelectedValue), dtPermisos);
                MessageBox.Show("Permisos agregados exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {

        }

        private void cbGruposDeUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(cbGruposDeUsuarios.Items.Count>0)
                cbGruposDeUsuarios.SelectedIndex = 0;
        }
    }
}
