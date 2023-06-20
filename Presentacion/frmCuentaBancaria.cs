using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCuentaBancaria : Presentacion.frmColor
    {
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.CuentaContable objLCuentaContable = new Logica.CuentaContable();

        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public frmCuentaBancaria()
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
            this.Text = "ADMINISTRACION DE CUENTAS BANCARIAS";
        }

        public void LimitesTamaños() {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCuentaBancaria, 20);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbMoneda);
            Utilidades.Combo.Formato(cbCuentaContable);
            Utilidades.Combo.Formato(cbCuentaContableValoresDiferidos);
            Utilidades.Combo.Formato(cbCuentaContableTranferencias);
            Utilidades.Combo.Formato(cbCuentaContablePrestamos);
            Utilidades.Combo.Formato(cbCuentaContableDebitoCreditoCompras);
            Utilidades.Combo.Formato(cbCuentaContablePayWay);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Banco"].Width = 100;
            dgvDatos.Columns["Estado"].Width = 50;
        }
        private void BotonesInicial()
        {
            Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        public void CargarValores() {
            try
            {
                CargarBancos();
                CargarMonedas();
                CargarCuentasContables();
                TraerCuentasBancarias();
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuentasContables() {
            Utilidades.Combo.Llenar(cbCuentaContable, objLCuentaContable.ObtenerBancos(), "Codigo", "Nombre");
            Utilidades.Combo.Llenar(cbCuentaContableValoresDiferidos, objLCuentaContable.ObtenerValoresDiferidos(), "Codigo", "Nombre");
            Utilidades.Combo.Llenar(cbCuentaContableTranferencias, objLCuentaContable.ObtenerBancos(), "Codigo", "Nombre");
            Utilidades.Combo.Llenar(cbCuentaContablePrestamos, objLCuentaContable.ObtenerBancosPrestamos(), "Codigo", "Nombre");
            Utilidades.Combo.Llenar(cbCuentaContableDebitoCreditoCompras, objLCuentaContable.ObtenerTarjetas(), "Codigo", "Nombre");
            Utilidades.Combo.Llenar(cbCuentaContablePayWay, objLCuentaContable.ObtenerBancos(), "Codigo", "Nombre");
        }

        private void CargarBancos() {
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivos(), "Codigo", "Descripcion");
        }
        private void CargarMonedas()
        {
            Utilidades.Combo.Llenar(cbMoneda, objLMoneda.ObtenerActivos(), "CodigoMoneda", "Descripcion");
        }
        private void TraerCuentasBancarias() {
            try
            {
                dgvDatos.DataSource = objLCuentaBancaria.ObtenerTodos();
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
            txtCuentaBancaria.Text = "";
            cbTranferencias.Checked = false;
            cbDebitoCredito.Checked = false;
            cbDebitoCreditoCompras.Checked = false;
            //Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Habilitar(this);
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar, btnCancelar); ;
            this.txtCuentaBancaria.Focus();
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
                    txtCuentaBancaria.Text = row.Cells["NumeroCuenta"].Value.ToString();
                    cbBancos.SelectedValue = row.Cells["CodigoBanco"].Value;
                    cbMoneda.SelectedValue = row.Cells["CodigoMoneda"].Value;
                    cbCuentaContable.SelectedValue = row.Cells["CodigoCuentaContable"].Value;
                    cbCuentaContableValoresDiferidos.SelectedValue = row.Cells["CodigoCuentaContableValoresDiferidos"].Value;
                    cbCuentaContableTranferencias.SelectedValue = row.Cells["CodigoCuentaContableTranferencias"].Value;
                    cbCuentaContablePrestamos.SelectedValue= row.Cells["CodigoCuentaContablePrestamos"].Value;
                    cbCuentaContableDebitoCreditoCompras.SelectedValue = row.Cells["CodigoCuentaContableDebitoCreditoCompras"].Value;
                    cbCuentaContablePayWay.SelectedValue= row.Cells["CodigoCuentaContablePayWay"].Value;
                    dtFechaConcialiacion.Value= Convert.ToDateTime(row.Cells["FechaConciliacion"].Value);
                    cbTranferencias.Checked = Convert.ToBoolean(row.Cells["Tranferencia"].Value);
                    cbDebitoCredito.Checked = Convert.ToBoolean(row.Cells["DebitoCredito"].Value);
                    cbDebitoCreditoCompras.Checked = Convert.ToBoolean(row.Cells["DebitoCreditoCompras"].Value);
                    cbPayWay.Checked = Convert.ToBoolean(row.Cells["PayWay"].Value);
                }
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtCuentaBancaria.Focus();
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCuentaBancaria.Focus();
                return;
            }
            if (lblCodigo.Text == "(Codigo)")
            {
                objECuentaBancaria.Codigo = 0;
            }
            else
            {
                objECuentaBancaria.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objECuentaBancaria.NumeroCuenta= txtCuentaBancaria.Text.Trim();
            objECuentaBancaria.Banco.Codigo = Convert.ToInt32(cbBancos.SelectedValue);
            objECuentaBancaria.Moneda.Codigo = Convert.ToInt32(cbMoneda.SelectedValue);
            objECuentaBancaria.CuentaContable.Codigo= Convert.ToInt64(cbCuentaContable.SelectedValue);
            objECuentaBancaria.CuentaContableValoresDiferidos.Codigo = Convert.ToInt64(cbCuentaContableValoresDiferidos.SelectedValue);
            objECuentaBancaria.CuentaContableTranferencias.Codigo= Convert.ToInt64(cbCuentaContableTranferencias.SelectedValue);
            objECuentaBancaria.CuentaContablePrestamos.Codigo = Convert.ToInt64(cbCuentaContablePrestamos.SelectedValue);
            objECuentaBancaria.CuentaContableDebitoCreditoCompras.Codigo = Convert.ToInt64(cbCuentaContableDebitoCreditoCompras.SelectedValue);
            objECuentaBancaria.CuentaContablePayWay.Codigo = Convert.ToInt64(cbCuentaContablePayWay.SelectedValue);
            objECuentaBancaria.FechaConciliacion = Convert.ToDateTime(dtFechaConcialiacion.Value);
            objECuentaBancaria.Tranferencia = cbTranferencias.Checked;
            objECuentaBancaria.DebitoCredito = cbDebitoCredito.Checked;
            objECuentaBancaria.DebitoCreditoCompras = cbDebitoCreditoCompras.Checked;
            objECuentaBancaria.PayWay = cbPayWay.Checked;
            try
            {
                if (objECuentaBancaria.Codigo == 0)
                {
                    objLCuentaBancaria.Agregar(objECuentaBancaria);
                    MessageBox.Show("CuentaBancaria agregado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        objLCuentaBancaria.Agregar(objECuentaBancaria);
                        MessageBox.Show("Cuenta Bancaria Modificado exitosamente!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TraerCuentasBancarias();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtCuentaBancaria);
            res=res || Utilidades.Validar.ComboBoxSinSeleccionar(cbBancos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbMoneda);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContable);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContableValoresDiferidos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContableTranferencias);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContablePrestamos);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContableDebitoCreditoCompras);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbCuentaContablePayWay);
            return res;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objECuentaBancaria.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar la Cuenta Bancaria?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                try
                {
                    objLCuentaBancaria.Eliminar(objECuentaBancaria);
                    TraerCuentasBancarias();
                    Limpiar();
                    MessageBox.Show("Cuenta Bancaria eliminada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCuentaBancaria_Load(object sender, EventArgs e)
        {

        }
        public static string busqueda = "";
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmBancos());
            busqueda = "Bancos";
        }

        private void frmCuentaBancaria_Activated(object sender, EventArgs e)
        {
           // CargarBancos();
        }
    }
}
