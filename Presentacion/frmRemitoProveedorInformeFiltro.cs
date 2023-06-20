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
    public partial class frmRemitoProveedorInformeFiltro : Presentacion.frmColor
    {
        Logica.Proveedor objLogicaProveedor = new Logica.Proveedor();
        Logica.RubroProducto objLoRubro = new Logica.RubroProducto();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Lote objLLote = new Logica.Lote();
        Logica.Canal objLCanal = new Logica.Canal();

        Entidades.Proveedor objEntidadProveedor = new Entidades.Proveedor();
        Entidades.RubroProducto objEnRubro = new Entidades.RubroProducto();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Lote objELote = new Entidades.Lote();
        Entidades.Canal objECanal = new Entidades.Canal();

        public frmRemitoProveedorInformeFiltro()
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
            this.Text = "INFORME DE REMITOS DE PROVEEDORES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoRubro, 4);
            // Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCanal, 2);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 5);
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
                    if (!cbProveedores.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("InformeRemitoProveedor", this));
                    break;
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("InformeRemitoProveedor", this));
                    break;
            }

        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!cbProveedores.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreProveedor); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreLote); }
            // if (!cbCanales.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreCanal); }
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


            if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
            {
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
                lista.Add(new Logica.RemitoProveedor().ObtenerTodosDataTable(desde, hasta, objEntidadProveedor, objEnRubro, objEProducto, objELote, objECanal));

                if (lista[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Remitos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string titulo = "Remitos de Proveedores";

                if (!cbProveedores.Checked)
                {
                    titulo += " Proveedor: " + lblNombreProveedor.Text.Trim();
                }

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

                string nombreinforme = "";
                if (rbFecha.Checked)
                {
                    nombreinforme = "repRemitoProveedor";
                }
                else if (rbProducto.Checked)
                {
                    nombreinforme = "repRemitoProveedorPorProducto";
                }
                else if (rbProveedor.Checked)
                {
                    if (cbResumido.Checked)
                    {
                        nombreinforme = "repRemitoProveedorResumido";
                    }
                    else
                    {
                        nombreinforme = "repRemitoProveedorPorProveedor";
                    }
                }



                //frmInformes informe = new frmInformes("REMITO DE PROVEEDORES", lista, "repRemitoProveedor");
                frmInformes informe = new frmInformes("REMITO DE PROVEEDORES", lista, nombreinforme);
                //string titulo = "REMITOS DE PROVEEDORES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");
                titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");


                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();


                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbLotes.Checked = true;
            cbProductos.Checked = true;
            cbProveedores.Checked = true;
            cbRubros.Checked = true;
            rbProveedor.Checked = true;
            Utilidades.ControlesGenerales.LimpiarControles(this);
        }
        /*
        private void cbCanales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCanales.Checked)
            {
                this.txtCodigoCanal.Enabled = false;
                this.lblNombreCanal.Enabled = false;
                this.txtCodigoCanal.Text = "";
            }
            else
            {
                this.txtCodigoCanal.Enabled = true;
                this.lblNombreCanal.Enabled = true;
                this.txtCodigoCanal.Focus();
            }
        }
        */
        private void txtCodigoCanal_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoCanal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }
        /*
        private void txtCodigoCanal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCanal.Text.Trim().Equals(""))
                {
                    objECanal = objLCanal.ObtenerUno(Convert.ToInt32(txtCodigoCanal.Text.Trim()));
                    if (objECanal != null)
                        lblNombreCanal.Text = objECanal.Descripcion;
                    else
                        lblNombreCanal.Text = "";
                }
                else
                {
                    objECanal = new Entidades.Canal();
                    lblNombreCanal.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        void HabilitarCheck() {
            cbResumido.Checked = false;
            if (rbProveedor.Checked)
            {
                cbResumido.Visible = true;
            }
            else {
                cbResumido.Visible = false; ;
            }
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheck();
        }

        private void rbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheck();
        }

        private void rbProducto_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheck();
        }
    }
}
