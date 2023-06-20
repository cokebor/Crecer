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
    public partial class frmSalidas : Presentacion.frmColor
    {
        Logica.RubroProducto objLoRubro = new Logica.RubroProducto();
        Logica.Producto objLProducto = new Logica.Producto();

        Entidades.RubroProducto objEnRubro = new Entidades.RubroProducto();
        Entidades.Producto objEProducto = new Entidades.Producto();

        public frmSalidas()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            LimitesTamaños();
            Utilidades.Formularios.ConfiguracionInicial(this);

        }

        private void Titulo()
        {
            this.Text = "INFORME DE SALIDAS DE PRODUCTOS";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoRubro, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProducto, 4);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F5:
                    if (!cbProductos.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmProductoBuscar("InformeSalidaDeProductos", this));
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
            SeleccionarCheckBox();
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
            SeleccionarCheckBox();
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
                lista.Add(new Logica.RemitoSucursal().ObtenerEnviosProductosConSucursales(desde, hasta, objEnRubro, objEProducto, cbRubrosSeleccionados.Checked));

                if (lista[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se registran movimientos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int cantFechas = new Logica.RemitoSucursal().ObtenerCantidadFechas(desde, hasta, objEnRubro, objEProducto, cbRubrosSeleccionados.Checked);

               // lista.Add(new Logica.RemitoSucursal().ObtenerEnviosProductos(desde, hasta, objEnRubro, objEProducto, cbRubrosSeleccionados.Checked));
                                

                string titulo = "Salida de Productos";

   
                if (!cbRubros.Checked)
                {
                    titulo += " Rubro: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreRubro.Text);

                }
                if (!cbProductos.Checked)
                {
                    titulo += " Producto: " + Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(lblNombreProducto.Text);
                }

                frmInformes informe = new frmInformes("INFORME DE SALIDAS DE PRODUCTOS", lista, "repSalidaDeProductos");
                titulo += " del " + desde.ToString("d").Replace("-", "/") + " al " + hasta.ToString("d").Replace("-", "/");

                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("Titulo", titulo);

                parametros[1] = new ReportParameter("CantidadFechas", cantFechas.ToString());
                
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
            cbProductos.Checked = true;
            cbRubros.Checked = true;
            cbRubrosSeleccionados.Checked = true;
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;

        }

        private void cbRubrosSeleccionados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRubrosSeleccionados.Checked)
            {
                cbRubros.Checked = true;
                cbProductos.Checked = true;
                cbRubrosSeleccionados.Checked = true;
            }
        }

        private void SeleccionarCheckBox() {
            if (cbRubros.Checked || cbProductos.Checked)
                cbRubrosSeleccionados.Checked = false;
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
