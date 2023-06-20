using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmEjercicios : frmColor
    {
        Logica.Ejercicio objLogicaEjercicio = new Logica.Ejercicio();
        /*Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();
        */
        Entidades.Ejercicio objEntidadEjercicio = new Entidades.Ejercicio();
        /*
        Entidades.Pais objEntidadPais = new Entidades.Pais();
        Entidades.Provincia objEntidadProvincia = new Entidades.Provincia();*/
        public frmEjercicios()
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
        }


        private void Titulo()
        {
            this.Text = "EJERCICIOS ECONOMICOS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 50);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Descripción"].Width = 120;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void CargarValores()
        {
            TraerEjercicios();
        }

        private void TraerEjercicios()
        {
            try
            {
                dgvDatos.DataSource = objLogicaEjercicio.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.dtDesde.Enabled = true;
            this.dtHasta.Enabled = true;
            this.txtDescripcion.Enabled = true;

            this.dtDesde.Value = DateTime.Now;
            this.dtHasta.Value = DateTime.Now;

            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.dtDesde.Value = DateTime.Now;
            this.dtHasta.Value = DateTime.Now;
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
            this.txtDescripcion.Enabled = false;
            this.dtDesde.Enabled = false;
            this.dtHasta.Enabled = false;          
            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            dtDesde.Enabled = true;
            dtHasta.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;


            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
            {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            
            if (lblCodigo.Text == "(Codigo)")
            {
                objEntidadEjercicio.Codigo = 0;
            }
            else
            {
                objEntidadEjercicio.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objEntidadEjercicio.Descripcion= txtDescripcion.Text.Trim();
            objEntidadEjercicio.FechaInicio = dtDesde.Value;
            objEntidadEjercicio.FechaFinal = dtHasta.Value;

            try
            {
                if (objEntidadEjercicio.Codigo == 0)
                {
                    objLogicaEjercicio.Agregar(objEntidadEjercicio);
                    MessageBox.Show("Ejercicio Economico agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaEjercicio.Agregar(objEntidadEjercicio);
                        MessageBox.Show("Ejercicio Economico modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerEjercicios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            dtDesde.Enabled = false;
            dtHasta.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    
                    dtDesde.Value = Convert.ToDateTime(row.Cells["FechaInicio"].Value);
                    dtHasta.Value = Convert.ToDateTime(row.Cells["FechaFin"].Value.ToString());
                    
                }
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadEjercicio.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Ejercicio Economico?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaEjercicio.Eliminar(objEntidadEjercicio);
                    TraerEjercicios();
                    Limpiar();
                    MessageBox.Show("Ejercicio Economico eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            return res;
        }
        
        private void frmProvincia_Load(object sender, EventArgs e)
        {

        }
    }
}
    