using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmRemitoClienteInforme : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.RemitoCliente objLogicaRemitoCliente = new Logica.RemitoCliente();
        public frmRemitoClienteInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            //txtNumeroComprobante1.txtCUIL1.Text = "R";
            LimitesTamaños();
            Formatos();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "REMITOS DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
        }

        private void Formatos()
        {
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Fecha"].Width = 80;
            dgvDatos.Columns["Cliente"].Width = 200;
            //dgvDatos.Columns["Remito"].Width = 70;
            
        }
        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("RemitosClientes", this));
                    break;
            }

        }

        private void cbClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClientes.Checked)
            {
                this.txtCodigoCliente.Enabled = true;
                //this.lblCliente.Enabled = true;
                this.txtCodigoCliente.Focus();
            }
            else
            {
                this.txtCodigoCliente.Enabled = false;
                //this.lblCliente.Enabled = false;
                this.txtCodigoCliente.Text = "";
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
                        lblNombreCliente.Text = objEntidadCliente.Nombre;
                    else
                        lblNombreCliente.Text = "";
                }
                else
                {
                    objEntidadCliente = new Entidades.Cliente();
                    lblNombreCliente.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }
        private void CargarValores()
        {
            TraerRemitos();
        }
        private void TraerRemitos()
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


                if (Validar().Equals(true))
                {
                    MessageBox.Show("No se puede mostrar el informe ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                dgvDatos.DataSource = objLogicaRemitoCliente.ObtenerTodosPorFecha(objEntidadCliente, desde, hasta);

                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Remitos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Validar()
        {
            bool res = false;
            if (cbClientes.Checked) { res = Utilidades.Validar.LabelEnBlanco(lblNombreCliente); }
            /*if (!cbProveedores.Checked) { res = Utilidades.Validar.TextBoxEnBlanco(txtCodigoProveedor); }
            if (!cbRubros.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoRubro); }
            if (!cbProductos.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoProducto); }
            if (!cbLotes.Checked) { res = res || Utilidades.Validar.TextBoxEnBlanco(txtCodigoLote); }*/
            return res;
        }

        private void Informe(int CodigoRemito)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                lista.Add(new Logica.RemitoCliente().ObtenerDataTable(CodigoRemito));
                lista.Add(new Logica.RemitoCliente().ObtenerDataTableDetalle(CodigoRemito));
                Utilidades.Formularios.AbrirFuera(new frmInformes("REMITO DE CLIENTE", lista, "repRemitoCliente"));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dgvDatos != null && dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dg.SelectedRows[0];
                if (row != null)
                {
                    Informe(Convert.ToInt32(row.Cells["Codigo"].Value));
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
               CargarValores();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
