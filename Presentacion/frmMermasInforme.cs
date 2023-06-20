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
    public partial class frmMermasInforme : Presentacion.frmColor
    {
        //Logica.Lote objLogicaLote = new Logica.Lote();
        Logica.RubroProducto objLoRubro = new Logica.RubroProducto();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Lote objLLote = new Logica.Lote();

        //  Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.RubroProducto objEnRubro = new Entidades.RubroProducto();
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Sucursal objESucursal = new Entidades.Sucursal();
        Entidades.Lote objELote = new Entidades.Lote();

        public frmMermasInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();
            CargarValores();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);
            /*Formatos();
            BotonesInicial();
            
            CargarValores();*/
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }

        private void Titulo()
        {
            this.Text = "INFORME DE MERMAS DE PRODUCTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoLote, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoRubro, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
        }

        private void CargarValores()
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todas");
                cbSucursales.SelectedValue = 0;
            }
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


        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("InformeMermas", this));
                    break;
            }

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

        private bool Validar()
        {
            bool res = false;
            if (!cbLotes.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreLote); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.LabelEnBlanco(lblNombreRubro); }
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

                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    objESucursal.Codigo = Convert.ToInt32(cbSucursales.SelectedValue);
                    lista.Add(new Logica.Merma().ObtenerPorLote(desde, hasta, objELote, objEnRubro, objEProducto, objESucursal));
                }
                else
                    lista.Add(new Logica.Merma().ObtenerPorLote(desde, hasta, objELote, objEnRubro, objEProducto));

                if (lista[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Mermas en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                string titulo = "Merma de Productos";

                if (Convert.ToInt32(cbSucursales.SelectedValue)!=0)
                {
                    titulo += " Sucursal: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(cbSucursales.Text);
                }

                if (!cbRubros.Checked)
                {
                    titulo += " Rubro: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreRubro.Text);
                    
                }
                if (!cbProductos.Checked)
                {
                    titulo += " Producto: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreProducto.Text);
                }
                if (!cbLotes.Checked)
                {
                    titulo += " Lote: " + txtCodigoLote.Text.Trim() + " " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreLote.Text);
                }

                lista.Add(new Logica.Empresa().ObtenerDataTable());


                // frmInformes informe = new frmInformes("LISTADO DE VENTA POR PRODUCTOS", lista, "repVentaPorProducto");
                frmInformes informe = new frmInformes("INFORME DE MERMAS DE PRODUCTOS", lista, "repMermas");
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
            Utilidades.ControlesGenerales.LimpiarControles(this);
            cbLotes.Checked = true;
            cbProductos.Checked = true;
            cbRubros.Checked = true;
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
        }

        private void txtCodigoLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
        }
    }
}
/*
             {
                lista.Add(new Logica.RemitoProveedor().ObtenerTodosDataTable(desde, hasta, objEntidadProveedor, objEnRubro, objEProducto, objELote));

                frmInformes informe = new frmInformes("REMITO DE PROVEEDORES", lista, "repRemitoProveedor");
                string titulo = "REMITOS DE PROVEEDORES DEL " + desde.ToString("d").Replace("-", "/") + " AL " + hasta.ToString("d").Replace("-", "/");

                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);
                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();
                

                Utilidades.Formularios.AbrirFuera(informe);
     */
