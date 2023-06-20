using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmImputacionClientes : Presentacion.frmColor
    {
        Entidades.Cliente objEntidadCliente = new Entidades.Cliente();
        Entidades.PagoCliente objEPago = new Entidades.PagoCliente();

        Logica.Cliente objLogicaCliente = new Logica.Cliente();
        Logica.PagoCliente objLPagoCliente = new Logica.PagoCliente();
        Logica.Factura objLFactura = new Logica.Factura();
        //Logica.PagoCliente objLPago = new Logica.PagoCliente();

        DataView dvPagos = new DataView();
        DataView dvComprobantes = new DataView();
        public frmImputacionClientes()
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
            // BotonesInicial();
            Utilidades.Formularios.ConfiguracionInicial(this);
            //    CargarValores();
        }

        private void Titulo()
        {
            this.Text = "IMPUTACION DE PAGOS DE CLIENTES";
        }

        private void LimitesTamaños()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoCliente, 4);
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
                    dvComprobantes = null;
                    dvPagos = null;
                }
                dgvDatos.DataSource = null;
                dgvDatos2.DataSource = null;
                cbSaldo.Enabled = true;
                importe = 0;
                Aplicado();
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

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmClienteBuscar("ImputacionCliente", this));
                    break;
            }
        }

        private void Formatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos2.AutoGenerateColumns = false;
            Utilidades.Grilla.Formato(dgvDatos);

            dgvDatos.Columns["Fecha"].Width = 80;
            dgvDatos.Columns["Numero"].Width = 100;
            //  dgvDatos.Columns["Cantidad"].Width = 70;


            Utilidades.Grilla.Formato(dgvDatos2);
            // dgvDatos2.Columns["Seleccionado"].ReadOnly = false;

            dgvDatos2.Columns["Seleccionado"].Width = 30;
            dgvDatos2.Columns["Fecha2"].Width = 70;
            dgvDatos2.Columns["Tipo"].Width = 30;
            dgvDatos2.Columns["Numero2"].Width = 90;
            dgvDatos2.Columns["Total2"].Width = 90;
            dgvDatos2.Columns["Imputado2"].Width = 90;
            dgvDatos2.Columns["Pendiente"].Width = 90;
            dgvDatos2.Columns["AAplicar"].Width = 90;
            //dgvDatos2.Columns["AAplicar"].ReadOnly = false;
            dgvDatos2.DefaultCellStyle.SelectionBackColor = SystemColors.Window;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarBusqueda())
                {
                    CargarPagos();
                    dgvDatos.Enabled = true;
                    CargarComprobantes();
                    importe = 0;
                    Aplicado();
                    PonerEnRojo();
                    /* DataTable dt = objLFactura.ObtenerFacturasSinImputar(Cliente);
                     foreach (DataRow dr in dt.Rows)
                     {

                         dgvDatos.Rows.Add(false, Convert.ToDateTime(dr["Fecha"]).ToString("d").Replace("-", "/"), dr["Tipo"], dr["Codigo"], dr["CodigoTipoDocumentoCliente"], dr["Numero"], Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Imputado"]), Convert.ToDouble(dr["Saldo"]), "", "");

                     }*/
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PonerEnRojo()
        {
            foreach (DataGridViewRow dg in dgvDatos2.Rows)
            {
                if (dg.Cells["Tipo"].Value.Equals("NC")) {
                   // dg.Cells["ImporteConNC"].Style.Font = new Font(dgvDatos.Font.FontFamily, dgvDatos.Font.Size, FontStyle.Regular);
                    dg.Cells["Fecha2"].Style.ForeColor = Color.Red;
                    dg.Cells["Tipo"].Style.ForeColor = Color.Red;
                    dg.Cells["Numero2"].Style.ForeColor = Color.Red;
                    dg.Cells["Total2"].Style.ForeColor = Color.Red;
                    dg.Cells["Imputado2"].Style.ForeColor = Color.Red;
                    dg.Cells["Pendiente"].Style.ForeColor = Color.Red;
                    dg.Cells["AAplicar"].Style.ForeColor = Color.Red;
                    
                }
                    
            }
        }
        private bool ValidarBusqueda()
        {

            if (Utilidades.Validar.LabelEnBlanco(lblNombreCliente))
            {
                MessageBox.Show("Seleccione un Cliente Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoCliente.Focus();
                return true;
            }


            return false;
        }

        private void CargarPagos()
        {
            dvPagos = objLPagoCliente.ObtenerParaImputar(objEntidadCliente).DefaultView;
            if (cbSaldo.Checked)
                dvPagos.RowFilter = "Total<>0";
            else
                dvPagos.RowFilter = "";
            dgvDatos.DataSource = dvPagos;
        }

        private void CargarComprobantes()
        {
            dvComprobantes = objLFactura.ObtenerFacturasParaImputar(objEntidadCliente).DefaultView;
            if (cbComprobantes.Checked)
                dvComprobantes.RowFilter = "Saldo<>0";
            else
                dvComprobantes.RowFilter = "";
            dgvDatos2.DataSource = dvComprobantes;
        }

        double importe = 0;
      //  double disponible = 0;
        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows.Count > 0) { 
                objEPago.Codigo = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Codigo"].Value);
                objEPago.Fecha = Convert.ToDateTime(dgvDatos.Rows[e.RowIndex].Cells["Fecha"].Value);
                objEPago.Letra = Convert.ToChar(dgvDatos.Rows[e.RowIndex].Cells["Numero"].Value.ToString().Substring(0,1));
                objEPago.PuntoDeVenta = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Numero"].Value.ToString().Substring(2, 4));
                objEPago.Numero = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Numero"].Value.ToString().Substring(7, 8));
                importe = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value);
                cbSaldo.Enabled = false;
                dgvDatos.Enabled = false;
                btnDetalle.Enabled = true;
                Aplicado();
            }
        }

        private void cbSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (dvPagos != null)
            {
                if (cbSaldo.Checked)
                    dvPagos.RowFilter = "Total<>0";
                else
                    dvPagos.RowFilter = "";
            }
            dgvDatos.DataSource = dvPagos;
        }

        private void cbComprobantes_CheckedChanged(object sender, EventArgs e)
        {
            if (dvComprobantes != null)
            {
                if (cbComprobantes.Checked)
                    dvComprobantes.RowFilter = "Saldo<>0";
                else
                    dvComprobantes.RowFilter = "";
            }
            dgvDatos2.DataSource = dvComprobantes;
        }

        private void dgvDatos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvDatos.Enabled)
            {
                if (Convert.ToInt32(e.RowIndex) != -1)
                {
                    DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos2.Rows[e.RowIndex].Cells["Seleccionado"];
                    check.Value = !(Convert.ToBoolean(check.Value));

                    if (Convert.ToBoolean(check.Value))
                    {
                        dgvDatos2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        if (Disponible() >= Convert.ToDouble(dgvDatos2["Pendiente", e.RowIndex].Value))
                        {
                            dgvDatos2["AAplicar", e.RowIndex].Value = dgvDatos2["Pendiente", e.RowIndex].Value;
                            dgvDatos2["CodigoImputacion", e.RowIndex].Value = "T";
                            if (Convert.ToDouble(dgvDatos2["AAplicar", e.RowIndex].Value) == 0)
                            {
                                dgvDatos2["AAplicar", e.RowIndex].Value = "";
                                check.Value = !(Convert.ToBoolean(check.Value));
                                dgvDatos2.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                            }
                        }
                        else if (Disponible() == 0)
                        {
                            check.Value = !(Convert.ToBoolean(check.Value));
                            dgvDatos2.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                        }
                        else
                        {
                            dgvDatos2["AAplicar", e.RowIndex].Value = Disponible();
                            dgvDatos2["CodigoImputacion", e.RowIndex].Value = "P";
                        }

                        /* if (!txtDescuento.Text.Trim().Equals(""))
                         {
                             dgvDatos.Rows[e.RowIndex].Cells["Descuento"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["ImporteConNC"].Value) * Convert.ToDouble(txtDescuento.Text.Trim()) / 100);
                         }*/
                    }
                    else
                    {
                        dgvDatos2.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                        dgvDatos2["AAplicar", e.RowIndex].Value = "";
                        dgvDatos2["CodigoImputacion", e.RowIndex].Value = "";
                        //  dgvDatos.Rows[e.RowIndex].Cells["Descuento"].Value = "";
                    }
                    dgvDatos2.ClearSelection();
                    Aplicado();
                    /*CalcularSeleccionados();
                    CalcularTotal();*/
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Pago anteriormente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private double Disponible() {
            return Utilidades.Redondear.DosDecimales(importe - Utilidades.Redondear.DosDecimales(Aplicado()));
        }
        public double Aplicado()
        {
            double res = 0;
            foreach (DataGridViewRow dgv in dgvDatos2.Rows)
            {
                if (Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                    if (!(dgv.Cells["AAplicar"].Value == null) && !dgv.Cells["AAplicar"].Value.Equals(""))
                        res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["AAplicar"].Value));
            }
            res = Utilidades.Redondear.DosDecimales(res);
            lblAplicado.Text = res.ToString("C2");
            lblDisponible.Text = (importe - res).ToString("C2");
            return res;
        }

        public List<Entidades.FacturaImputacion> ObtenerDatos()
        {
            List<Entidades.FacturaImputacion> facturas = new List<Entidades.FacturaImputacion>();
            foreach (DataGridViewRow fila in dgvDatos2.Rows)
            {
                Entidades.FacturaImputacion factura;
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    factura = new Entidades.FacturaImputacion();

                    factura.Codigo = Convert.ToInt32(fila.Cells["Codigo2"].Value);
                    factura.TipoDocumentoCliente.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoCliente"].Value);
                    factura.Monto = Convert.ToDouble(fila.Cells["AAplicar"].Value);
                    factura.CodigoImputacion = Convert.ToChar(fila.Cells["CodigoImputacion"].Value);
                    factura.ImputacionAnterior = Convert.ToDouble(fila.Cells["Imputado2"].Value);
                    facturas.Add(factura);

                }
            }
            return facturas;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarValoresImputacion();

                if ((objEPago.FacturasImputacion.Count == 0))// || importe - Aplicado() != 0))
                {
                    MessageBox.Show("Debe seleccionar comprobantea a imputar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else {
                    if (MessageBox.Show("¿Esta seguro que desea guardar la imputación?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                objLPagoCliente.Imputar(objEPago);
                Limpiar();
                MessageBox.Show("Imputación creada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
        private void Limpiar() {
            txtCodigoCliente.Text = "";
            btnDetalle.Enabled = false;
            cbSaldo.Enabled = true;
        }
        private void CargarValoresImputacion()
        {
            objEPago.Cliente.Codigo = Convert.ToInt32(txtCodigoCliente.Text.Trim());

            objEPago.FacturasImputacion.Clear();
            objEPago.FacturasImputacion = ObtenerDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        frmDetalleImputacion frm;
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this.MdiParent, frm =new frmDetalleImputacion(objEntidadCliente, objEPago));
        }

        private void frmImputacionClientes_Activated(object sender, EventArgs e)
        {
            if (!lblNombreCliente.Text.Trim().Equals("")) { 
                 btnBuscar.PerformClick();
                btnDetalle.Enabled = false;
            }
        }

        private void frmImputacionClientes_Load(object sender, EventArgs e)
        {
            
        }

        private void frmImputacionClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frm != null) {
                frm.Close();
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
