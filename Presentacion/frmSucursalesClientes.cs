using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmSucursalesClientes : Presentacion.frmColor
    {
        private Cliente objEC;
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.Pais objLogicaPais = new Logica.Pais();
        Logica.Provincia objLogicaProvincia = new Logica.Provincia();
        Logica.Localidad objLogicaLocalidad = new Logica.Localidad();
        Logica.SucursalCliente objLogicaSucursal = new Logica.SucursalCliente();

        Entidades.Pais objEntidadPais = new Pais();
        Entidades.Provincia objEntidadProvincia = new Provincia();
        Entidades.SucursalCliente objEntidadSucursal = new SucursalCliente();

        public frmSucursalesClientes()
        {
            InitializeComponent();
        }

        public frmSucursalesClientes(Cliente objEC)
        {
            InitializeComponent();
            this.objEC = objEC;
            this.Text = "Sucursales del Cliente " + objEC.Nombre;
            LimitesTamaños();
            Formatos();
            CargarPaises();
            CargarSucursales();
        }

        private void CargarSucursales() {
            try
            {
                DataTable dts = new DataTable();
                dts.Columns.Add("CodigoSucursal", typeof(int));
                dts.Columns.Add("NombreSucursal", typeof(string));
                dts.Columns.Add("Domicilio", typeof(string));
                dts.Columns.Add("Direccion", typeof(string));
                dts.Columns.Add("Numero", typeof(string));
                dts.Columns.Add("Barrio", typeof(string));
                dts.Columns.Add("CodigoPostal", typeof(string));
                dts.Columns.Add("CodigoLocalidad", typeof(int));
                dts.Columns.Add("CodigoProvincia", typeof(int));
                dts.Columns.Add("CodigoPais", typeof(int));
                this.objEC.Sucursales = objLCliente.ObtenerSucursales(objEC);
                foreach (Entidades.SucursalCliente sc in objEC.Sucursales)
                {

                    dts.Rows.Add(sc.CodigoSucursal, sc.NombreSucursal, "Calle: " + sc.Domicilio.Direccion + " Nro: " + sc.Domicilio.Numero + " C.P.: " + sc.Domicilio.CodigoPostal + " " + sc.Domicilio.Localidad.Nombre + ", " + sc.Domicilio.Localidad.Provincia.Nombre,
                        sc.Domicilio.Direccion, sc.Domicilio.Numero, sc.Domicilio.Barrio, sc.Domicilio.CodigoPostal, sc.Domicilio.Localidad.Codigo, sc.Domicilio.Localidad.Provincia.Codigo, sc.Domicilio.Localidad.Provincia.Pais.Codigo);
                }
                dgvDatos.DataSource = dts;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
        private void CargarPaises()
        {
            try
            {
                Utilidades.Combo.Llenar(cbPais, objLogicaPais.ObtenerActivos(), "Codigo", "Descripcion");
                if (cbPais.SelectedValue != null)
                {
                    objEntidadPais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));
                    Utilidades.Combo.Llenar(cbProvincias, objLogicaProvincia.ObtenerActivos(objEntidadPais), "Codigo", "Provincia");
                    if (cbProvincias.SelectedValue != null)
                    {
                        objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                        Utilidades.Combo.Llenar(cbLocalidades, objLogicaLocalidad.ObtenerActivos(objEntidadProvincia), "Codigo", "Localidad");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtNombreSucursal, 20);
            Utilidades.CajaDeTexto.LimiteTamaño(txtDireccion, 50);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNumero, 10);
            Utilidades.CajaDeTexto.LimiteTamaño(txtBarrio, 30);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoPostal, 10);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbPais);
            Utilidades.Combo.Formato(cbProvincias);
            Utilidades.Combo.Formato(cbLocalidades);
            Utilidades.Grilla.Formato(dgvDatos);
            btnConfirmar.Enabled = false;
           // dgvDatos.Columns["NombreSucursal"].Width = 100;
            dgvDatos.Columns["Domicilio"].Width = 400;
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Habilitar(this);
            txtNombreSucursal.Focus();
            btnConfirmar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            Utilidades.ControlesGenerales.Deshabilitar(this);
            dgvDatos.Enabled = true;
            //Utilidades.Botones.Inicial(btnNuevo, btnConfirmar, btnEliminar, btnCancelar);
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    lblCodigo.Text = row.Cells["CodigoSucursal"].Value.ToString();
                    txtNombreSucursal.Text= row.Cells["NombreSucursal"].Value.ToString();
                    txtDireccion.Text= row.Cells["Direccion"].Value.ToString();
                    txtBarrio.Text = row.Cells["Barrio"].Value.ToString();
                    txtCodigoPostal.Text = row.Cells["CodigoPostal"].Value.ToString();
                    cbPais.SelectedValue = row.Cells["CodigoPais"].Value;
                    cbProvincias.SelectedValue=row.Cells["CodigoProvincia"].Value;
                    cbLocalidades.SelectedValue = row.Cells["CodigoLocalidad"].Value;
                    /* txtCuentaBancaria.Text = row.Cells["NumeroCuenta"].Value.ToString();
                     cbBancos.SelectedValue = row.Cells["CodigoBanco"].Value;
                     cbMoneda.SelectedValue = row.Cells["CodigoMoneda"].Value;
                     cbCuentaContable.SelectedValue = row.Cells["CodigoCuentaContable"].Value;
                     cbCuentaContableValoresDiferidos.SelectedValue = row.Cells["CodigoCuentaContableValoresDiferidos"].Value;
                     cbCuentaContableTranferencias.SelectedValue = row.Cells["CodigoCuentaContableTranferencias"].Value;
                     cbCuentaContablePrestamos.SelectedValue = row.Cells["CodigoCuentaContablePrestamos"].Value;
                     dtFechaConcialiacion.Value = Convert.ToDateTime(row.Cells["FechaConciliacion"].Value);*/
                }
            }
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPais.SelectedIndex != -1)
            {
                try
                {
                    objEntidadPais = objLogicaPais.ObtenerUno(Convert.ToInt32(cbPais.SelectedValue));
                    Utilidades.Combo.Llenar(cbProvincias, objLogicaProvincia.ObtenerActivos(objEntidadPais), "Codigo", "Provincia");
                    objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                    if (objEntidadProvincia == null)
                        cbLocalidades.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedIndex != -1)
            {
                try
                {
                    objEntidadProvincia = objLogicaProvincia.ObtenerUno(Convert.ToInt32(cbProvincias.SelectedValue));
                    Utilidades.Combo.Llenar(cbLocalidades, objLogicaLocalidad.ObtenerActivos(objEntidadProvincia), "Codigo", "Localidad");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "(Codigo)";
            txtNombreSucursal.Text = "";
            txtDireccion.Text = "";
            txtNumero.Text ="";
            txtBarrio.Text = "";
            txtCodigoPostal.Text = "";
            cbPais.SelectedValue = 1;
            cbProvincias.SelectedValue = 1;
            cbLocalidades.SelectedValue = 1;
            Utilidades.ControlesGenerales.Habilitar(this);
            btnNuevo.Enabled = false;
            btnConfirmar.Enabled = true;
            this.txtNombreSucursal.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreSucursal.Focus();
                return;
            }
            CargarValores();
            try
            {
                if (objEntidadSucursal.CodigoSucursal == 0)
                {
                    objLogicaSucursal.Agregar(objEntidadSucursal);
//                    Limpiar();
                    MessageBox.Show("Sucursal de Cliente agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("¿Desea guardar las modificaciones?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objLogicaSucursal.Agregar(objEntidadSucursal);
  //                      Limpiar();
                        MessageBox.Show("Sucursal de Cliente modificado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                CargarSucursales();
                btnNuevo.Enabled = true;
                btnConfirmar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarValores() {
            try
            {
                objEntidadSucursal = new SucursalCliente();
                objEntidadSucursal.CodigoCliente = objEC.Codigo;

                if (lblCodigo.Text.Equals(Variables.Codigo))
                {
                    objEntidadSucursal.CodigoSucursal = 0;
                }
                else
                {
                    objEntidadSucursal.CodigoSucursal = Convert.ToInt32(lblCodigo.Text.Trim());
                }
                objEntidadSucursal.NombreSucursal = txtNombreSucursal.Text.Trim();
                objEntidadSucursal.Domicilio.Direccion = txtDireccion.Text.Trim();
                objEntidadSucursal.Domicilio.Numero = txtNumero.Text.Trim();
                objEntidadSucursal.Domicilio.Barrio = txtBarrio.Text.Trim();
                objEntidadSucursal.Domicilio.CodigoPostal = txtCodigoPostal.Text.Trim();
                objEntidadSucursal.Domicilio.Localidad.Codigo = Convert.ToInt32(cbLocalidades.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private bool Validar()
        {
            bool res = false;
            res = Utilidades.Validar.TextBoxEnBlanco(txtNombreSucursal);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtDireccion);
            res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoPostal);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbPais);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbProvincias);
            res = res || Utilidades.Validar.ComboBoxSinSeleccionar(cbLocalidades);
            return res;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
            btnNuevo.Enabled = true;
            btnConfirmar.Enabled = false;
        }
    }
}
