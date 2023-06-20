using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmExportarFacturasPDF : Presentacion.frmColor
    {
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.Lote objLLote = new Logica.Lote();

        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.Lote objELote = new Entidades.Lote();

        public frmExportarFacturasPDF()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            CargarValores();
        }

        private void Titulo()
        {
            this.Text = "Exportar Comprobantes a PDF";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.ListView.Formato(lvComprobantes, true);

            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Combo.Formato(cbSucursales);
                lblSucursales.Visible = true;
                cbSucursales.Visible = true;
            }
        }
        private void cbFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechas.Checked)
                pnFecha.Enabled = true;
            else
                pnFecha.Enabled = false;
        }

        private void CargarValores()
        {
            try
            {
                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerTodos(), "Codigo", "Descripcion", "Todos");
                    cbSucursales.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClientes.Checked)
            {
                this.txtCodigoCliente.Enabled = false;
                this.lblCliente.Enabled = false;
                this.txtCodigoCliente.Text = "";
            }
            else
            {
                this.txtCodigoCliente.Enabled = true;
                this.lblCliente.Enabled = true;
                this.txtCodigoCliente.Focus();
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoCliente.Text.Trim().Equals(""))
                {
                    objEntidadCliente = objLogicaCliente.ObtenerUnoActivo(Convert.ToInt32(txtCodigoCliente.Text.Trim()));



                    if (objEntidadCliente != null)
                    {
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                        Utilidades.Combo.Llenar(cbEmail, objLogicaCliente.ObtenerEmails(objEntidadCliente), "0", "Dato");
                    }
                    else {
                        lblNombreCliente.Text = "";
                        cbEmail.DataSource = null;
                    }
                    
                }
                else
                {
                    objEntidadCliente = new Entidades.Cliente();
                    lblNombreCliente.Text = "";
                    cbEmail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    if (!cbClientes.Checked)
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("ExportarPDF", this));
                    break;
            }

        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
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

        private void txtCodigoLote_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
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

        private void CrearGrupos() {
            lvComprobantes.Groups.Add(new ListViewGroup("1", "Deposito"));
            lvComprobantes.Groups.Add(new ListViewGroup("2", "Wiki S.A."));
            lvComprobantes.Groups.Add(new ListViewGroup("3", "Nave 7"));
            lvComprobantes.Groups.Add(new ListViewGroup("4", "Villa Maria"));
            lvComprobantes.Groups.Add(new ListViewGroup("5", "Rio Cuarto"));
            lvComprobantes.Groups.Add(new ListViewGroup("6", "Fruticola Centro"));
            lvComprobantes.Groups.Add(new ListViewGroup("7", "Sucursal 6"));
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CrearGrupos();
            //Datos que necesito
            //CodigoComprobante, CodigoSucursal, TipoComprobante (FA,NC, ND), CodigoCliente, Cliente,Tipo Comprobante, NumeroComprobante
            ListViewItem item;
           
            item = lvComprobantes.Items.Add("a");
            item.Tag = "2";//CodigoFactura
            item.Group = lvComprobantes.Groups["3"];//CodigoSucursal
            item.SubItems.Add("b").Tag="3";
            lvComprobantes.Columns[1].Width = 0;
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
       

        }

        private void frmExportarFacturasPDF_Load(object sender, EventArgs e)
        {

        }
    }
}
