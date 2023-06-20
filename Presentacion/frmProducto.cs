using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmProducto : Presentacion.frmColor
    {
        Logica.RubroProducto objLogicaRubro = new Logica.RubroProducto();
        Logica.Producto objLogicaProducto = new Logica.Producto();
        Entidades.Producto objEntidadProducto = new Entidades.Producto();

        string busqueda = "";
        public frmProducto()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        public frmProducto(Entidades.Producto pProducto)
        {
            InitializeComponent();
            ConfiguracionInicial2(pProducto);
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Formatos();
            BotonesInicial();
            CargarValores();
        }

        private void ConfiguracionInicial2(Entidades.Producto pProducto)
        {
            Titulo();
            LimitesTamaños();
            Formatos();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Botones.Modificar(btnNuevo, btnConfirmar, btnEliminar);
            Utilidades.ControlesGenerales.Habilitar(this);
            txtStock.Enabled = false;
            CargarValores();
            CargarValoresProductoSeleccionado(pProducto);
            //            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            //           Utilidades.Combo.SeleccionarPrimerValor(cbPais);

        }

        private void CargarValoresProductoSeleccionado(Entidades.Producto pProducto)
        {
            lblCodigo.Text = pProducto.Codigo.ToString();
            txtDescripcion.Text = pProducto.Descripcion;
            cbRubroProducto.SelectedValue = pProducto.RubroProducto.Codigo;
            cbUnidadMedida.Text = pProducto.UnidadDeMedida.ToString();
            nupPeso.Value = Convert.ToDecimal(pProducto.Peso);
            nupStockMinimo.Value = Convert.ToDecimal(pProducto.StockMinimo);
            txtStock.Text = pProducto.Stock.ToString();
            txtCodigoDeBarra.Text = pProducto.CodigoBarra.ToString();
            if (pProducto.PorcentajeIVA == 0)
                cbIVA.SelectedIndex = 0;
            else
                cbIVA.Text = pProducto.PorcentajeIVA.ToString("#.00");
            cbFacturacionPorCubeta.Checked = pProducto.FacturacionPorCubeta;
            cbVacio.Checked = pProducto.Vacio;
        }

        private void Titulo()
        {
            this.Text = "ACTUALIZACION DE PRODUCTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtDescripcion, 35);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoDeBarra, 30);
        }
        private void Formatos()
        {
            Utilidades.Combo.Formato(cbRubroProducto);
            Utilidades.Combo.Formato(cbUnidadMedida);
            Utilidades.Combo.Formato(cbIVA);
        }
        private void BotonesInicial()
        {
            if(Singleton.Instancia.Empresa.Codigo==1 || Singleton.Instancia.Empresa.Codigo == 10)// || Singleton.Instancia.Empresa.Codigo == 6)
                Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            else
                Utilidades.Botones.Inicial(null, btnConfirmar, btnEliminar, btnCancelar);
            Utilidades.Combo.SeleccionarPrimerValor(cbIVA);
            Utilidades.Combo.SeleccionarPrimerValor(cbUnidadMedida);
        }
        private void CargarValores()
        {

            try
            {
                Utilidades.Combo.Llenar(cbRubroProducto, objLogicaRubro.ObtenerActivos(), "Codigo", "Descripcion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtStock.Enabled = false;
            cbFacturacionPorCubeta.Checked = false;
            cbVacio.Checked = false;
            Utilidades.Botones.Nuevo(btnNuevo, btnConfirmar, btnEliminar);
            txtDescripcion.Focus();
        }

        private void cbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUnidadMedida.Text.Equals("Unidad") || cbUnidadMedida.Text.Equals("Cubetas")) {
                lblUnidad.Text = "Cant.:";
                nupPeso.DecimalPlaces = 0;
                nupPeso.Increment = 1;
            }
            else { 
                lblUnidad.Text = "Peso:";
                nupPeso.DecimalPlaces = 2;
                nupPeso.Increment = 0.1m;
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
            if (ValidarUnidades().Equals(false))
            {
                MessageBox.Show("No se pudo guardar. "+ lblUnidad.Text +" debe ser mayor a cero." , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            if (lblCodigo.Text.Equals(Variables.Codigo))
            {
                objEntidadProducto.Codigo = 0;
            }
            else
            {
                objEntidadProducto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            }
            objEntidadProducto.Descripcion = txtDescripcion.Text.Trim();
            objEntidadProducto.RubroProducto.Codigo = Convert.ToInt32(cbRubroProducto.SelectedValue);
            objEntidadProducto.UnidadDeMedida = cbUnidadMedida.Text;
            objEntidadProducto.Peso = Convert.ToDouble(nupPeso.Value);
            objEntidadProducto.StockMinimo = Convert.ToInt32(nupStockMinimo.Value);
            objEntidadProducto.Stock = 0;
            objEntidadProducto.CodigoBarra = txtCodigoDeBarra.Text.Trim();
            objEntidadProducto.PorcentajeIVA = Convert.ToDouble(cbIVA.Text);
            objEntidadProducto.FacturacionPorCubeta = Convert.ToBoolean(cbFacturacionPorCubeta.Checked);
            objEntidadProducto.Vacio = Convert.ToBoolean(cbVacio.Checked);
            try
            {
                if (objEntidadProducto.Codigo == 0)
                {
                    objLogicaProducto.Agregar(objEntidadProducto,Singleton.Instancia.Empresa);
                    Limpiar();
                    MessageBox.Show("Producto agregado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaProducto.Agregar(objEntidadProducto, Singleton.Instancia.Empresa);
                        Limpiar();
                        MessageBox.Show("Producto modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            lblCodigo.Text = "(Codigo)";
            Utilidades.ControlesGenerales.LimpiarControles(this);
            Utilidades.ControlesGenerales.Deshabilitar(this);
            cbFacturacionPorCubeta.Checked = false;
            cbVacio.Checked = false;
            BotonesInicial();
        }

        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtDescripcion);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbRubroProducto);
            return res;
        }
        private bool ValidarUnidades()
        {
            bool res = true;
            if (cbFacturacionPorCubeta.Checked) {
                if (nupPeso.Value <= 0) {
                    res = false;
                }
            }
            return res;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmRubroProducto());
            busqueda = "Rubros";
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }

        private void frmProducto_Activated(object sender, EventArgs e)
        {
            if (busqueda.Equals("Rubros"))
                CargarValores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("Alta", this));
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objEntidadProducto.Codigo = Convert.ToInt32(lblCodigo.Text.Trim());
            if (MessageBox.Show("¿Desea eliminar el Producto seleccionado?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objLogicaProducto.Eliminar(objEntidadProducto);
                    Limpiar();
                    MessageBox.Show("Producto eliminado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbRubroProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void nupPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void nupStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoDeBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbIVA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cmsRubro_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
