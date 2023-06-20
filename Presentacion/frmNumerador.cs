using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmNumerador : Presentacion.frmColor
    {
        Logica.Numerador objLNumerador = new Logica.Numerador();

        Entidades.Numerador objENumerador = new Entidades.Numerador();
        public frmNumerador()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public void ConfiguracionInicial() {
            Titulo();
            LimitesTamaños();
            Formatos();
            BotonesInicial();
            CargarValores();
        }

        public void Titulo() {
            this.Text = "ACTUALIZACION DE NUMERADORES";
        }

        public void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 36);
            Utilidades.CajaDeTexto.LimiteTamaño(txtLetra, 1);
            Utilidades.CajaDeTexto.LimiteTamaño(txtPuntoVenta, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 8);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 60;
            dgvDatos.Columns["Numerador"].Width = 150;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        public void CargarValores() {
            try
            {
                TraerNumeradores();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerNumeradores() {
            try
            {
                dgvDatos.DataSource = objLNumerador.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar()
        {
            this.dgvDatos.ClearSelection();
            if (dgvDatos.Rows.Count > 0)
            {
                this.dgvDatos.Rows[0].Selected = true;
            }
            else
            {
                lblCodigo.Text = "(Codigo)";
                Utilidades.ControlesGenerales.LimpiarControles(this);
                Utilidades.ControlesGenerales.Deshabilitar(this);
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            txtDescripcion.Text = "";
            txtLetra.Text = "";
            txtPuntoVenta.Text = "";
            txtNumero.Text = "";
            //Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtDescripcion.Focus();
        }

        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirSoloLetras(e);
        }

        private void txtPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtPuntoVenta_Leave(object sender, EventArgs e)
        {
            txtPuntoVenta.Text=Utilidades.CajaDeTexto.FormatoCuatroCeros(txtPuntoVenta);
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            txtNumero.Text = Utilidades.CajaDeTexto.FormatoOchoCeros(txtNumero);
        }

        private void txtLetra_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            
            Utilidades.ControlesGenerales.Deshabilitar(this);
            dgvDatos.Enabled = true;
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Numerador"].Value.ToString();
                    txtLetra.Text = row.Cells["Letra"].Value.ToString();
                    txtPuntoVenta.Text = row.Cells["PuntoVenta"].Value.ToString();
                    txtNumero.Text = row.Cells["Numero"].Value.ToString();
                    txtPuntoVenta.Text = Utilidades.CajaDeTexto.FormatoCuatroCeros(txtPuntoVenta);
                    txtNumero.Text=Utilidades.CajaDeTexto.FormatoOchoCeros(txtNumero);
                }
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtDescripcion.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
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
                objENumerador.Codigo = 0;
            }
            else
            {
                objENumerador.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }

            objENumerador.Descripcion = txtDescripcion.Text.Trim();
            objENumerador.Letra = txtLetra.Text.Trim();
            objENumerador.PuntoVenta = Convert.ToInt32(txtPuntoVenta.Text.Trim());
            objENumerador.Numero = Convert.ToInt32(txtNumero.Text.Trim());

            try
            {
                if (objENumerador.Codigo == 0)
                {
                    objLNumerador.Agregar(objENumerador);
                    MessageBox.Show("Numerador agregado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        objLNumerador.Agregar(objENumerador);
                        MessageBox.Show("Numerador Modificado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerNumeradores();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            res=res || Utilidades.Validar.TextBoxEnBlanco(txtLetra);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtPuntoVenta);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtNumero);
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objENumerador.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Numerador?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                try
                {
                    objLNumerador.Eliminar(objENumerador);
                    TraerNumeradores();
                    Limpiar();
                    MessageBox.Show("Numerador eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }
}
