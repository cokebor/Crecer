using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLiquidacionesProveedorInformeFiltro : Presentacion.frmColor
    {
        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.Producto objLProducto = new Logica.Producto();

        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.Producto objEProducto = new Entidades.Producto();

        public frmLiquidacionesProveedorInformeFiltro()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            /*Formatos();
            BotonesInicial();
            
            CargarValores();*/
        }

        private void Titulo()
        {
            this.Text = "INFORME DE LIQUIDACIONES PENDIENTES DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F6:
                    if(!cbProveedores.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("LiquidacionesPendientesLiquidar", this));
                    break;
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("LiquidacionesPendientesLiquidar", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        

        private bool Validar()
        {
            bool res = false;
            if (!cbProveedores.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreProducto); }
            /*if (!cbProveedores.Checked) { res = Utilidades.Validar.TextBoxEnBlanco(txtCodigoProveedor); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoLote); }*/
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            //DateTime hasta;
            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;

            /*
            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false)) {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            if (Validar().Equals(true))
            {
                MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataTable> lista = new List<DataTable>();
            try
            {
                Int16 vendidas=0;
                if (cbVendidasTotalmente.Checked)
                {
                    vendidas = 1;
                }
                else if (cbVendidasParcialmente.Checked)
                {
                    vendidas = 2;
                }
                else if (cbGuiasVendidos.Checked)
                {
                    vendidas = 3;
                }

                //lista.Add(new Logica.RemitoProveedor().ObtenerLiquidacionesPendientes(objEntidadProveedor, objEProducto, hasta, Singleton.Instancia.Empresa));
                lista.Add(new Logica.RemitoProveedor().ObtenerLiquidacionesPendientes(objEntidadProveedor, objEProducto, desde, hasta, Singleton.Instancia.Empresa, vendidas));
                // lista.Add(new Logica.RemitoProveedor().ObtenerLiquidacionesPendientes(objEntidadProveedor, objEProducto, hasta, Singleton.Instancia.Empresa));

                if (lista[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Remitos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string titulo = "Remitos de Proveedores pendientes de Liquidar";

                if (!cbProveedores.Checked)
                {
                    titulo += " Proveedor: " + lblNombreProveedor.Text.Trim();
                }

                if (!cbProductos.Checked)
                {
                    titulo += " Producto: " + lblNombreProducto.Text.Trim();
                }

                frmInformes informe;
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    informe = new frmInformes("REMITO DE PROVEEDORES PENDIENTES DE LIQUIDAR", lista, "repLiquidacionesProveedoresPendientes2");
                }
                else { 
                    informe = new frmInformes("REMITO DE PROVEEDORES PENDIENTES DE LIQUIDAR", lista, "repLiquidacionesProveedoresPendientes");
                }
                //string titulo = "REMITOS DE PROVEEDORES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
               // titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");
                titulo +=  " al " + hasta.ToString("d").Replace("-", "/");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();
                

                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbProductos.Checked = false;
            cbProveedores.Checked = false;
            cbGuiasVendidos.Checked = false;

            Utilidades.ControlesGenerales.LimpiarControles(this);
        }

        private void cbVendidasTotalmente_Click(object sender, EventArgs e)
        {
            if (cbVendidasParcialmente.Checked)
            {
                cbVendidasParcialmente.Checked = false;
            }
            if (cbGuiasVendidos.Checked)
            {
                cbGuiasVendidos.Checked = false;
            }

            /*if (cbVendidasTotalmente.Checked)
            {
                cbVendidasTotalmente.Checked = false;
            }
            else {
                cbVendidasTotalmente.Checked = true;
            }*/
        }

        private void cbVendidasParcialmente_Click(object sender, EventArgs e)
        {
            if (cbVendidasTotalmente.Checked)
            {
                cbVendidasTotalmente.Checked = false;
            }
            if (cbGuiasVendidos.Checked)
            {
                cbGuiasVendidos.Checked = false;
            }
            /* if (cbVendidasParcialmente.Checked)
             {
                 cbVendidasParcialmente.Checked = false;
             }
             if (!cbVendidasParcialmente.Checked)
             {
                 cbVendidasParcialmente.Checked = true;
             }*/
        }

        private void cbGuiasVendidos_Click(object sender, EventArgs e)
        {
            if (cbVendidasTotalmente.Checked)
            {
                cbVendidasTotalmente.Checked = false;
            }
            if (cbVendidasParcialmente.Checked)
            {
                cbVendidasParcialmente.Checked = false;
            }
        }
    }
}
