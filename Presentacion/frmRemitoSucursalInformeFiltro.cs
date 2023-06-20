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
    public partial class frmRemitoSucursalInformeFiltro : Presentacion.frmColor
    {
        //Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Entidades.Sucursal objEntidadSucursalOrigen = new Entidades.Sucursal();
        Entidades.Sucursal objEntidadSucursalDestino = new Entidades.Sucursal();
        Logica.RubroProducto objLoRubro = new Logica.RubroProducto();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Lote objLLote = new Logica.Lote();

        Logica.Sucursal objLogicaSucursal = new Logica.Sucursal();
        //Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.RubroProducto objEnRubro = new Entidades.RubroProducto();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Lote objELote = new Entidades.Lote();


        public frmRemitoSucursalInformeFiltro()
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
            this.Text = "ENVIO DE MERCADERIAS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoSucursalOrigen, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoSucursalDestino, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoRubro, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 5);
        }

        private void txtCodigoSucursal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoSucursalOrigen.Text.Trim().Equals(""))
                {
                    objEntidadSucursalOrigen = objLogicaSucursal.ObtenerSucursal(Convert.ToInt32(txtCodigoSucursalOrigen.Text.Trim()));
                    if (objEntidadSucursalOrigen != null)
                        lblNombreSucursalOrigen.Text = objEntidadSucursalOrigen.RazonSocial;
                    else
                        lblNombreSucursalOrigen.Text = "";
                }
                else
                {
                    objEntidadSucursalOrigen = new Entidades.Sucursal();
                    lblNombreSucursalOrigen.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSucursales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSucursalesOrigen.Checked)
            {
                this.txtCodigoSucursalOrigen.Enabled = false;
                this.lblSucursal.Enabled = false;
                this.txtCodigoSucursalOrigen.Text = "";
            }
            else
            {
                this.txtCodigoSucursalOrigen.Enabled = true;
                this.lblSucursal.Enabled = true;
                this.txtCodigoSucursalOrigen.Focus();
            }
        }

        private void txtCodigoSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("InformeRemitoSucursal", this));
                    break;
            }

        }

        private void txtCodigoSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void cbRubros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRubros.Checked)
            {
                this.txtCodigoRubro.Enabled = false;
                this.lblRubro.Enabled = false;
                this.txtCodigoRubro.Text = "";
            }
            else
            {
                this.txtCodigoRubro.Enabled = true;
                this.lblRubro.Enabled = true;
                this.txtCodigoRubro.Focus();
            }
        }

        private void txtCodigoRubro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoRubro.Text.Trim().Equals(""))
                {
                    objEnRubro = objLoRubro.ObtenerUnoActivo(Convert.ToInt32(txtCodigoRubro.Text.Trim()));
                    if (objEnRubro != null)
                        lblNombreRubro.Text = objEnRubro.Descripcion;
                    else
                        lblNombreRubro.Text = "";
                }
                else
                {
                    objEnRubro = new Entidades.RubroProducto();
                    lblNombreRubro.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoRubro_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
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

        private void txtCodigoLote_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoLote.Text.Trim().Equals(""))
                {
                    objELote = objLLote.ObtenerUno(Convert.ToInt32(txtCodigoLote.Text.Trim()));
                    if (objELote != null)
                        lblNombreLote.Text = objELote.Producto.Descripcion + " - " + objELote.Proveedor.Nombre;
                    else
                        lblNombreLote.Text = "";
                }
                else
                {
                    objELote = new Entidades.Lote();
                    lblNombreLote.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }

        private void txtCodigoLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void cbLotes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLotes.Checked)
            {
                this.txtCodigoLote.Enabled = false;
                this.lblLote.Enabled = false;
                this.txtCodigoLote.Text = "";
            }
            else
            {
                this.txtCodigoLote.Enabled = true;
                this.lblLote.Enabled = true;
                this.txtCodigoLote.Focus();
            }
        }

        private bool Validar()
        {
            bool res = false;
            if (!cbSucursalesOrigen.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreSucursalOrigen); }
            if (!cbSucursalDestino.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreSucursalDestino); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreLote); }
            /*if (!cbProveedores.Checked) { res = Utilidades.Validar.TextBoxEnBlanco(txtCodigoProveedor); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoLote); }*/
            return res;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            DateTime desde, hasta;
            desde = dtDesde.Value.Date;
            hasta = dtHasta.Value.Date;


            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false)) {
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            if (Validar().Equals(true))
            {
                MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            List<DataTable> lista = new List<DataTable>();
            try
            {
                
                //lista.Add(new Logica.RemitoSucursal().ObtenerTodosDataTable(desde, hasta, objEntidadSucursalOrigen, objEntidadSucursalDestino, objEnRubro, objEProducto, objELote, cbEnviados.Checked, cbRecibidos.Checked));
                lista.Add(new Logica.RemitoSucursal().ObtenerTodosDataTable(desde, hasta, objEntidadSucursalDestino, objEnRubro, objEProducto, objELote, cbEnviados.Checked, cbRecibidos.Checked));

                if (lista[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Envios en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string titulo = "Envios de Mercaderia";

                if (!cbRubros.Checked)
                {
                    titulo += " Rubro: " + lblNombreRubro.Text.Trim();

                }
                if (!cbProductos.Checked)
                {
                    titulo += " Producto: " + lblNombreProducto.Text.Trim();
                }
                if (!cbLotes.Checked)
                {
                    titulo += " Lote: " + txtCodigoLote.Text.Trim();
                }
                

                frmInformes informe = new frmInformes("REMITO DE PROVEEDORES", lista, "repRemitoSucursalInforme");
                //string titulo = "REMITOS DE PROVEEDORES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
                titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();
                

                Utilidades.Formularios.AbrirFuera(informe);
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbLotes.Checked = true;
            cbProductos.Checked = true;
            cbSucursalesOrigen.Checked = true;
            cbRubros.Checked = true;
            cbEnviados.Checked = true;
            cbRecibidos.Checked = true;
            Utilidades.ControlesGenerales.LimpiarControles(this);
        }

        private void txtCodigoSucursalDestino_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoSucursalDestino.Text.Trim().Equals(""))
                {
                    objEntidadSucursalDestino = objLogicaSucursal.ObtenerSucursal(Convert.ToInt32(txtCodigoSucursalDestino.Text.Trim()));
                    if (objEntidadSucursalDestino != null)
                        lblNombreSucursalDestino.Text = objEntidadSucursalDestino.RazonSocial;
                    else
                        lblNombreSucursalDestino.Text = "";
                }
                else
                {
                    objEntidadSucursalDestino = new Entidades.Sucursal();
                    lblNombreSucursalDestino.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSucursalDestino_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSucursalDestino.Checked)
            {
                this.txtCodigoSucursalDestino.Enabled = false;
                this.lblSucursalDestino.Enabled = false;
                this.txtCodigoSucursalDestino.Text = "";
            }
            else
            {
                this.txtCodigoSucursalDestino.Enabled = true;
                this.lblSucursalDestino.Enabled = true;
                this.txtCodigoSucursalDestino.Focus();
            }
        }

        private void txtCodigoSucursalDestino_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoSucursalDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }
    }
}
