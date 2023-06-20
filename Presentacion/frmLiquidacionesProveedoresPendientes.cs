using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLiquidacionesProveedoresPendientes : Presentacion.frmColor
    {
        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEProducto = new Entidades.Producto();

        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.RemitoProveedor objLRemito = new Logica.RemitoProveedor();
        public frmLiquidacionesProveedoresPendientes()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Formatos();
        }

        private void Titulo()
        {
            this.Text = "LIQUIDACIONES PENDIENTES DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Fecha"].Width = 65;
            dgvDatos.Columns["Proveedor"].Width = 155;
            dgvDatos.Columns["Remito"].Width = 98;
            dgvDatos.Columns["Producto"].Width = 155;
            dgvDatos.Columns["Lote"].Width = 50;
            dgvDatos.Columns["Ingreso"].Width = 58;
            dgvDatos.Columns["Mermas"].Width = 58;
            dgvDatos.Columns["Ventas"].Width = 60;
            dgvDatos.Columns["Liquidadas"].Width = 60;
            dgvDatos.Columns["Promedio"].Width = 70;
            // dgvDatos.Columns["Cantidad"].Width = 70;
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("LiquidacionesProveedoresPendientes", this));
                    break;
                case (char)Keys.F5:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("LiquidacionesProveedoresPendientes", this));
                    break;
            }
        }



        DataTable dt = new DataTable();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde, hasta;
                desde = dtDesde.Value.Date;
                hasta = dtHasta.Value.Date;

                if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                {
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Validar())
                {
                    dt= objLRemito.ObtenerLiquidacionesDeProveedoresPendientes(objEntidadProveedor, objEProducto, desde, hasta, Singleton.Instancia.Empresa, cbVendidasTotalmente.Checked);
                    dgvDatos.DataSource = dt;
                   // dgvDatos.DataSource = objLRemito.ObtenerTodosPorClienteParaLiquidar(objEntidadCliente);
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Remitos Pendientes en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {

            if (!cbProveedores.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (!cbProductos.Checked && Utilidades.Validar.LabelEnBlanco(lblNombreProducto))
            {
                MessageBox.Show("Seleccione un Producto Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }

            return false;
        }

        private void cbProveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedores.Checked)
            {
                this.txtCodigoProveedor.Enabled = false;
                this.lblProveedor.Enabled = false;
                this.txtCodigoProveedor.Text = "";
            }
            else
            {
                this.txtCodigoProveedor.Enabled = true;
                this.lblProveedor.Enabled = true;
                this.txtCodigoProveedor.Focus();
            }
            dgvDatos.DataSource = null;
        }

        private void cbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductos.Checked)
            {
                this.txtCodigoProducto.Enabled = false;
                this.lblProducto.Enabled = false;
                this.txtCodigoProducto.Text = "";
            }
            else
            {
                this.txtCodigoProducto.Enabled = true;
                this.lblProducto.Enabled = true;
                this.txtCodigoProducto.Focus();
            }
            dgvDatos.DataSource = null;
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEntidadProveedor = objLogicaProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEntidadProveedor != null)
                        lblNombreProveedor.Text = objEntidadProveedor.Nombre;
                    else
                        lblNombreProveedor.Text = "";
                }
                else
                {
                    objEntidadProveedor = new Entidades.Proveedor();
                    lblNombreProveedor.Text = "";
                }
                dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProducto.Text.Trim().Equals(""))
                {
                    objEProducto = objLProducto.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProducto.Text.Trim()));
                    if (objEProducto != null)
                        lblNombreProducto.Text = objEProducto.Descripcion;
                    else
                        lblNombreProducto.Text = "";
                }
                else
                {
                    objEProducto = new Entidades.Producto();
                    lblNombreProducto.Text = "";
                }
                dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbVendidasTotalmente_CheckedChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
    }
}
