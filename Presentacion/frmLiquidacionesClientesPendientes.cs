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
    public partial class frmLiquidacionesClientesPendientes : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();

        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.RemitoCliente objLRemito = new Logica.RemitoCliente();
        public frmLiquidacionesClientesPendientes()
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
          //  BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
        }

        private void Titulo()
        {
            this.Text = "LIQUIDACIONES PENDIENTES DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Remito"].Width = 100;
            dgvDatos.Columns["Producto"].Width = 150;
            // dgvDatos.Columns["Cantidad"].Width = 70;
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("LiquidacionesClientesPendientes", this));
                    break;
            }
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
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
                    objEntidadCliente = null;
                    lblNombreCliente.Text = "";
                }
                dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {

                    //dgvDatos.DataSource = objLRemito.ObtenerTodosPorClienteParaLiquidar(objEntidadCliente);

                    dt = objLRemito.ObtenerTodosPorClienteParaLiquidar(objEntidadCliente);

                    if (dt.Rows.Count == 0)
                    {

                        MessageBox.Show("No se registran Remitos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }


            return false;
        }
        DataTable dt;
        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
            List<DataTable> lista = new List<DataTable>();
            try
            {
                if (dt != null)
                {
                    dt.TableName = "dsLiquidaciones";
                    lista.Add(dt);

                    string titulo, cliente="";
                    frmInformes informe = new frmInformes("INFORME DE LIQUIDACIONES DE CLIENTES PENDIENTES", lista, "repLiquidacionesPendientesClientes");
                    titulo = "INFORME DE LIQUIDACIONES DE CLIENTES PENDIENTES";

                    if (lblNombreCliente.Text.Trim().Length > 0)
                    {
                        cliente = "Cliente: " + lblNombreCliente.Text.Trim();
                    }

                    ReportParameter[] parametros = new ReportParameter[2];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    parametros[1] = new ReportParameter("Cliente", cliente);
                    informe.reportViewer1.LocalReport.SetParameters(parametros);

                    informe.reportViewer1.RefreshReport();

                    Utilidades.Formularios.AbrirFuera(informe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCliente.Text = "";
            dgvDatos.DataSource = null;
        }
    }
}
