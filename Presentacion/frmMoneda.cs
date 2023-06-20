using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMoneda : frmColor
    {
        Logica.Moneda objLogicaMoneda = new Logica.Moneda();
        

        Entidades.Moneda objEntidadMoneda = new Entidades.Moneda();
        
        public frmMoneda()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            nupCotizacion.Value = 1;

            dgvDatos.AutoGenerateColumns = false;

            Titulo();

            LimitesTamaños();

            Formatos();

            BotonesInicial();

            TraerMonedas();
        }


        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE MONEDAS";
        }
        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 20);
        }
        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Descripción"].Width = 150;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            this.txtDescripcion.Text = "";
            this.nupCotizacion.Value = 1;
            this.txtDescripcion.Enabled = true;
            this.nupCotizacion.Enabled = true;
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
            this.nupCotizacion.Value = 1;
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            
      
            this.txtDescripcion.Enabled = false;


            BotonesInicial();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            nupCotizacion.Enabled = true;
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void TraerMonedas()
        {
            try
            {
                dgvDatos.DataSource = objLogicaMoneda.ObtenerTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            
            if (lblCodigo.Text == "(Codigo)")
            {
                objEntidadMoneda.Codigo = 0;
            }
            else
            {
                objEntidadMoneda.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadMoneda.Descripcion = txtDescripcion.Text.Trim();
            objEntidadMoneda.FechaCotizacion = DateTime.Now;
            objEntidadMoneda.Cotizacion = Convert.ToDouble(nupCotizacion.Value);

            try
            {
                if (objEntidadMoneda.Codigo == 0)
                {
                    objLogicaMoneda.Agregar(objEntidadMoneda);
                    MessageBox.Show("Moneda agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaMoneda.Agregar(objEntidadMoneda);
                        MessageBox.Show("Moneda modificada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerMonedas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            nupCotizacion.Enabled = false;
            BotonesInicial();
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripción"].Value.ToString();
                    nupCotizacion.Value = Convert.ToDecimal(row.Cells["Cotizacion"].Value);
                }
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            objEntidadMoneda.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Moneda?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaMoneda.Eliminar(objEntidadMoneda);
                    TraerMonedas();
                    Limpiar();
                    MessageBox.Show("Moneda eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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


    }
}
    