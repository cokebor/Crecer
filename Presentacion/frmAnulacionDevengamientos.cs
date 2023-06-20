using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAnulacionDevengamientos : Presentacion.frmColor
    {
        Logica.TipoDocumentoCaja objLTipoDocCaja = new Logica.TipoDocumentoCaja();
        Logica.Caja objLCaja = new Logica.Caja();
        Logica.Concepto objLConcepto = new Logica.Concepto();
        Logica.TipoSalario objLTipoSalario = new Logica.TipoSalario();
        Logica.Secuencia objLSecuencia = new Logica.Secuencia();
        Logica.Devengamiento objLDevengamiento = new Logica.Devengamiento();

        Entidades.Caja objECaja = new Entidades.Caja();
        Entidades.Devengamiento objEDevengamiento = new Entidades.Devengamiento();
        public frmAnulacionDevengamientos()
        {
            InitializeComponent();
            ConfiguracionInicial();
            LlenarCombo();
            CargarConceptos();
        }
        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
        }
        private void Titulo()
        {
            this.Text = "ANULACION DE COMPROBANTES";
        }

        private void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbTipoComprobante);
            Utilidades.Combo.Formato(cbConcepto);
            Utilidades.Combo.Formato(cbPeriodo);
            Utilidades.Combo.Formato(cbTipoSalario);
        }

        private void Limpiar() {
            rbDevengamientos.Checked=true;
            Utilidades.Combo.SeleccionarPrimerValor(cbTipoComprobante);
            Utilidades.Combo.SeleccionarPrimerValor(cbConcepto);
            this.cbConcepto_SelectedIndexChanged(cbConcepto, null);
            //cbConcepto.SelectedIndex = 0;
            ucNumeroComprobante.Limpiar();
        }
        private void CargarConceptos()
        {
            try
            {
                Utilidades.Combo.Llenar(cbConcepto, objLConcepto.ObtenerActivos(), "Codigo", "Descripcion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPagoDevengamientos.Checked)
                    CargarCaja();
                else
                    CargarDevengamiento();
                if (MessageBox.Show("¿Esta seguro que desea anular el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (rbPagoDevengamientos.Checked)
                    objLCaja.Anular(objECaja);
                else
                    objLDevengamiento.Anular(objEDevengamiento);
                MessageBox.Show("Comprobante anulado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCaja() {
            objECaja = new Entidades.Caja();
            objECaja.TipoDocumentoCaja.Codigo = Convert.ToInt32(cbTipoComprobante.SelectedValue);
            objECaja.Letra = Convert.ToChar(ucNumeroComprobante.txtLetra.Text.Trim());
            objECaja.PuntoDeVenta = Convert.ToInt32(ucNumeroComprobante.txtPuntoVenta.Text.Trim());
            objECaja.Numero = Convert.ToInt32(ucNumeroComprobante.txtNumero.Text.Trim());
        }

        private void CargarDevengamiento()
        {
            objEDevengamiento = new Entidades.Devengamiento();
            objEDevengamiento.Codigo = Convert.ToInt32(cbTipoSalario.SelectedValue);
        }

        private void rbDevengamientos_CheckedChanged(object sender, EventArgs e)
        {
            VisualizarPanel();
        }

        private void LlenarCombo() {
            try
            {

                    Utilidades.Combo.Llenar(cbTipoComprobante, objLTipoDocCaja.ObtenerCajaRetenciones(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPagoDevengamientos_CheckedChanged(object sender, EventArgs e)
        {
            VisualizarPanel();
        }

        private void VisualizarPanel() {
            if (rbDevengamientos.Checked)
            {
                pPagos.Visible = false;
                pDevengamientos.Visible = true;
            }
            else
            {
                pPagos.Visible = true;
                pDevengamientos.Visible = false;
            }
        }
        private void frmAnulacionDevengamientos_Load(object sender, EventArgs e)
        {

        }

        private void cbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConcepto.SelectedIndex != -1)
            {
                try
                {
        

                    if (Convert.ToInt32(cbConcepto.SelectedValue) == 1)
                    {
                        /* lblTipo.Visible = true;
                         cbTipoSalario.Visible = true;*/
        //                Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerTodos(), "Codigo", "Descripcion");
                        lblTipo.Text = "Tipo:";
                    }
                    else
                    {
                        /*lblTipo.Visible = false;
                        cbTipoSalario.Visible = false;*/
          //              Utilidades.Combo.Llenar(cbTipoSalario, objLSecuencia.ObtenerTodos(), "Codigo", "Descripcion");
                        lblTipo.Text = "Secuencia:";
                    }
                    int concepto = Convert.ToInt32(cbConcepto.SelectedValue);
                    Utilidades.Combo.Llenar(cbPeriodo, new Logica.Periodo().ObtenerDevengamientosAAnular(concepto), "Periodo", "Meses");
                    if (cbPeriodo.Items.Count==0)
                        cbTipoSalario.DataSource = null;
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPeriodo.SelectedIndex != -1)
            {
                try
                {
                    int concepto = Convert.ToInt32(cbConcepto.SelectedValue);

                    string periodo = cbPeriodo.SelectedValue.ToString();
                    Utilidades.Combo.Llenar(cbTipoSalario, objLTipoSalario.ObtenerParaBorrar(concepto, periodo), "CodigoDevengamiento", "Descripcion");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                cbTipoSalario.DataSource = null;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void cbTipoSalario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoSalario.SelectedIndex != -1)
            {
                lblCodigo.Text = cbTipoSalario.SelectedValue.ToString();
            }
            else {
                lblCodigo.Text = "";
            }
        }
    }
}
