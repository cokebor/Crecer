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
    public partial class frmUsuario : frmColor
    {
        /* Logica.Pais objLogicaPais = new Logica.Pais();
         Logica.Provincia objLogicaProvincia = new Logica.Provincia();
         Logica.Localidad objLogicaLocalidad = new Logica.Localidad();
         */
        Logica.Empleado objLogicaEmpleado = new Logica.Empleado();
        Logica.GrupoDeUsuario objLogicaGrupoDeUsuario = new Logica.GrupoDeUsuario();
        Logica.Usuario objLogicaUsuario = new Logica.Usuario();
        Logica.PuestoCaja objLPuestoCaja = new Logica.PuestoCaja();
        /*
        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();
        Entidades.Localidad objEntidadLocalidad = new Entidades.Localidad();
        */

        Entidades.Usuario objEntidadUsuario = new Entidades.Usuario();

        public frmUsuario()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            dgvDatos.AutoGenerateColumns = false;

            Titulo();

            LimitesTamaños();

            Formatos();

            BotonesInicial();

            CargarValores();

            Utilidades.Combo.SeleccionarPrimerValor(cbGruposDeUsuarios);
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
        }
        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE USUARIOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtUsuario, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombre, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtApellido, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtUsuario, 10);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbGruposDeUsuarios);
            dgvDatos.Columns["CodigoUsuario"].Width = 60;
            dgvDatos.Columns["Empleado"].Width = 130;
            dgvDatos.Columns["Grupo"].Width = 100;
            dgvDatos.Columns["Estado"].Width = 50;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }
        private void CargarValores()
        {

            try
            {
                Utilidades.Combo.Llenar(cbGruposDeUsuarios, objLogicaGrupoDeUsuario.ObtenerActivos(), "Codigo", "Descripcion");
                TraerUsuarios();
                TraerPuestosCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerPuestosCaja()
        {
            try
            {
                TreeNode tNode;
                tvPuestosCaja.Nodes.Clear();
                DataTable dt = objLPuestoCaja.ObtenerTodos();
                foreach (DataRow dr in dt.Rows)
                {
                    tNode = tvPuestosCaja.Nodes.Add(dr["Codigo"].ToString(), dr["Descripcion"].ToString());
                    tNode.Tag = Convert.ToInt32(dr["Codigo"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            cbGruposDeUsuarios.Enabled = false;
            tvPuestosCaja.Enabled = false;
            foreach (TreeNode item in tvPuestosCaja.Nodes)
            {
                item.Checked = false;
            }
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            lblGrupo.Text = "";
            lblNombreUsuario.Text = "";
            //Utilidades.Combo.SeleccionarPrimerValor(cbEmpleados);
            //Utilidades.Combo.SeleccionarPrimerValor(cbGruposDeUsuarios);
            BotonesInicial();
        }

        private void TraerUsuarios()
        {
            try
            {
                dgvDatos.DataSource = objLogicaUsuario.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleado());
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmGrupoDeUsuario());
        }

        private void frmUsuario_Activated(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            //CargarValores();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtUsuario.Text = "";
            this.txtUsuario.Enabled = true;
            this.txtNombre.Text = "";
            this.txtNombre.Enabled = true;
            this.txtApellido.Text = "";
            this.txtApellido.Enabled = true;
            this.tvPuestosCaja.Enabled = true;
            foreach (TreeNode item in tvPuestosCaja.Nodes)
            {
                item.Checked = false;
            }
            cbGruposDeUsuarios.Enabled = true;
            lblGrupo.Text = "";
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtNombre.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            if (ValidarCajas() == false)
            {
                MessageBox.Show("Debe Seleccionar al menos una caja!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (lblCodigo.Text == "(Codigo)")
                {
                    objEntidadUsuario.Codigo = 0;
                }
                else
                {
                    objEntidadUsuario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
                }
                objEntidadUsuario.Nombre = txtNombre.Text.Trim();
                objEntidadUsuario.Apellido = txtApellido.Text.Trim();
                objEntidadUsuario.GrupoDeUsuario.Codigo = Convert.ToInt32(cbGruposDeUsuarios.SelectedValue);
                objEntidadUsuario.NombreUsuario = txtUsuario.Text.Trim();
                //objEntidadUsuario.Contraseña = txtDescripcion.Text.Trim();
                objEntidadUsuario.ContraseñaEncriptada = Utilidades.Seguridad.EncriptarClave(txtUsuario.Text.Trim());
                objEntidadUsuario.Contraseña = txtUsuario.Text.Trim();
                objEntidadUsuario.ColorFormularios = "-16744256";//ColorTranslator.FromHtml("ActiveCaption").ToArgb().ToString();
                objEntidadUsuario.ColorFormularioMDI = "-13676721";
                List<Entidades.PuestoCaja> puestos = new List<Entidades.PuestoCaja>();
                Entidades.PuestoCaja objPuesto;
                foreach (TreeNode item in tvPuestosCaja.Nodes)
                {
                    if (item.Checked)
                    {
                        objPuesto = new Entidades.PuestoCaja();
                        objPuesto.Codigo = Convert.ToInt32(item.Tag);
                        puestos.Add(objPuesto);
                    }
                }
                objEntidadUsuario.PuestosDeCaja = puestos;

                //Entidades.Usuario objUsuario = new Entidades.Usuario(objEntidadUsuario.GrupoDeUsuario, objEntidadUsuario.NombreUsuario, objEntidadUsuario.ColorFormularios);
                //objUsuario.ColorFormularioMDI = objEntidadUsuario.ColorFormularioMDI;
                if (objEntidadUsuario.Codigo == 0)
                {
                    if (objLogicaUsuario.ExisteUsuario(objEntidadUsuario))
                    {
                        MessageBox.Show("Nombre de Usuario ya existe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    objLogicaUsuario.Agregar(objEntidadUsuario);
                    MessageBox.Show("Usuario agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TraerUsuarios();
                }
                else
                {
                    if (objLogicaUsuario.ExisteUsuario(objEntidadUsuario))
                    {
                        if (objEntidadUsuario.NombreUsuario != lblNombreUsuario.Text)
                        {
                            MessageBox.Show("Nombre de Usuario ya existe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (MessageBox.Show("¿Desea guardar las modificaciones de Usuario?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            objLogicaUsuario.Modificar(objEntidadUsuario);
                            TraerUsuarios();
                            MessageBox.Show("Usuario modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            Limpiar();


        }

        private bool ValidarCajas()
        {
            bool res = false;
            foreach (TreeNode item in tvPuestosCaja.Nodes)
            {
                if (item.Checked)
                {
                    return true;
                }
            }
            return res;
        }
        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtUsuario);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtApellido);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNombre);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbGruposDeUsuarios);
            return res;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtUsuario.Enabled = true;
            cbGruposDeUsuarios.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            tvPuestosCaja.Enabled = true;
            txtNombre.Focus();
            lblCodigo.Text = dgvDatos.SelectedRows[0].Cells["CodigoUsuario"].Value.ToString();
            lblGrupo.Text = dgvDatos.SelectedRows[0].Cells["CodigoGrupo"].Value.ToString();
            lblNombreUsuario.Text = dgvDatos.SelectedRows[0].Cells["Usuario"].Value.ToString();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }




        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


                txtUsuario.Enabled = false;
                cbGruposDeUsuarios.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                BotonesInicial();
                DataGridView dg = sender as DataGridView;
                if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dg.SelectedRows[0];
                    if (row != null)
                    {
                        // cbEmpleados.SelectedValue = row.Cells["CodigoEmpleado"].Value.ToString();
                        Entidades.Usuario objUsuario = new Entidades.Usuario();
                        objUsuario.Codigo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["CodigoUsuario"].Value);
                        objUsuario = objLogicaUsuario.ObtenerUno(objUsuario.Codigo);
                        lblCodigo.Text = dgvDatos.SelectedRows[0].Cells["CodigoUsuario"].Value.ToString();
                        txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                        txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                        cbGruposDeUsuarios.SelectedValue = row.Cells["CodigoGrupo"].Value.ToString();
                        //lblUsuario.Text= row.Cells["CodigoGrupo"].Value.ToString();
                        txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                        foreach (TreeNode item in tvPuestosCaja.Nodes)
                        {
                            item.Checked = false;
                        }
                        foreach (Entidades.PuestoCaja item in objUsuario.PuestosDeCaja)
                        {
                            foreach (TreeNode item2 in tvPuestosCaja.Nodes)
                            {
                                if (item.Codigo == Convert.ToInt32(item2.Tag))
                                {
                                    item2.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //objEntidadUsuario.GrupoDeUsuario.Codigo = Convert.ToInt32(cbGruposDeUsuarios.SelectedValue);

            if (MessageBox.Show("¿Desea eliminar el Usuario?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objEntidadUsuario.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
                    objLogicaUsuario.Eliminar(objEntidadUsuario);
                    // objEntidadProvincia.Codigo = Convert.ToInt32(cbProvincias.SelectedValue);
                    TraerUsuarios();
                    Limpiar();
                    MessageBox.Show("Usuario eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
