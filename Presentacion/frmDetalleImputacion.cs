using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmDetalleImputacion : Presentacion.frmColor
    {
        Logica.Factura objLFactura = new Logica.Factura();
        Logica.PagoCliente objLPagoCliente = new Logica.PagoCliente();
        public frmDetalleImputacion(Entidades.Cliente pCliente, Entidades.PagoCliente pPago)
        {
            InitializeComponent();
            ConfiguracionInicial();
            lblCliente.Text = pCliente.Nombre;
            lblFecha.Text = pPago.Fecha.ToString("dd/MM/yyyy");
            lblRecibo.Text = pPago.Numdoc;
            Pago = pPago;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dgvDatos.DataSource = objLFactura.ObtenerImputacionesDetalle(Pago);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Entidades.PagoCliente pago;

        public PagoCliente Pago
        {
            get
            {
                return pago;
            }

            set
            {
                pago = value;
            }
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
          /*  BotonesInicial();
            ObtenerValor();*/
        }

        private void Titulo()
        {
            this.Text = "DETALLE DE IMPUTACION DE PAGO";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["TipoDocumentoCliente"].Width = 160;
            dgvDatos.Columns["Fecha"].Width = 70;
           /* dgvDatos.Columns["Comprobante"].Width = 170;*/
            dgvDatos.Columns["Numero"].Width = 100;
        }

        private void btnEliminarProducto2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                int codFactura = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Codigo"].Value);
                int codTipoDocumento= Convert.ToInt32(dgvDatos.CurrentRow.Cells["CodigoTipoDocumentoCliente"].Value);


                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                objLPagoCliente.Imputar(Pago, codTipoDocumento,codFactura);
                /*lblNeto.Text = Neto().ToString("C2");
                lblIva.Text = Iva().ToString("C2");
                lblTotal.Text = (Neto() + Iva()).ToString("C2");*/
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
