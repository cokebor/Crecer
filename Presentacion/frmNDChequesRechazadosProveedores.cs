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
    public partial class frmNDChequesRechazadosProveedores : Presentacion.frmColor
    {
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.TipoDocumentoProveedor objLTipoDocumentoProveedor = new Logica.TipoDocumentoProveedor();
        Logica.Cheque objLCheque = new Logica.Cheque();
        Logica.FacturaCompra objLFactura = new Logica.FacturaCompra();

        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
        Entidades.TipoDocumentoProveedor objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
        Entidades.Cheque objCheque = new Entidades.Cheque();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        Entidades.FacturaCompra objEFactura = new Entidades.FacturaCompra();


        Logica.FormaDePago objLFormaDePago = new Logica.FormaDePago();
        

        
        
        
        
        
        Entidades.FormaDePago objEFormaDePago = new Entidades.FormaDePago();
        public frmNDChequesRechazadosProveedores()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        public static bool NumeroDocumentoBlanco(ucNumeroComprobante txt)
        {
            bool res = false;
            if (txt.txtLetra.Text.Trim().Equals("") || txt.txtPuntoVenta.Text.Trim().Equals("") || txt.txtNumero.Text.Trim().Equals(""))
            {
                res = true;
            }
            return res;
        }

        private void ConfiguracionInicial() {
            Titulo();
            Formatos();
            LimitesTamaño();
        }
        private void Titulo() {
            this.Text = "NOTAS DE DEBITO CHEQUES RECHAZADOS";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);

            // dgvDatos.MultiSelect = true;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            lblTotal.Text = 0.ToString("C2");

            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Banco"].Width = 150;
        }
        private void LimitesTamaño()
        {
            Utilidades.CajaDeTexto.LimiteTamaño(txtCodigoProveedor, 4);
            Utilidades.CajaDeTexto.LimiteTamaño(txtGastos, 8);
            Utilidades.CajaDeTexto.LimiteTamaño(txtMotivo, 150);
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
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmProveedorBuscar("NDCheque", this));
                    break;
            }
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoProveedor.Text.Trim().Equals(""))
                {
                    objEProveedor = objLProveedor.ObtenerUnoActivo(Convert.ToInt32(txtCodigoProveedor.Text.Trim()));
                    if (objEProveedor != null)
                    {
                        lblNombreProveedor.Text = objEProveedor.Nombre;
                        ObtenerTipoDocumento();
                        //ObtenerComprobantes();
                    }
                    else
                    {
                        lblNombreProveedor.Text = "";
                        lblTipoComprobanteProveedor.Text = "";
                        dgvDatos.DataSource = null;
                       /* cbComprobante.DataSource = null;
                        dgvDatos.Rows.Clear();
                        dgvDatos2.Rows.Clear();*/
                        Calcular();
                    }
                }
                else
                {
                    objEProveedor = null;
                    lblNombreProveedor.Text = "";
                    lblTipoComprobanteProveedor.Text = "";
                    dgvDatos.DataSource = null;
                    /* cbComprobante.DataSource = null;
                     dgvDatos.Rows.Clear();
                     dgvDatos2.Rows.Clear();*/
                     Calcular();
                }
                dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double Calcular()
        {
            double sum = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionado"].Value)) {
                    sum += Convert.ToDouble(item.Cells["Importe"].Value);
                }
            }
            lblTotal.Text = (sum + Gastos() + IVA()).ToString("C2");
            return sum;
        }
        private void ObtenerTipoDocumento()
        {
            try
            {
                if (objEProveedor != null && objEProveedor.Codigo != 0)// && objETipoDocumentoCliente!=null)
                {
                    ObtenerValores();
                    objETipoDocumentoProveedor = objLTipoDocumentoProveedor.ObtenerDeProveedor(objEProveedor.Codigo, objETipoDocumentoProveedor);

                    if (objETipoDocumentoProveedor != null)
                    {
                        lblTipoComprobanteProveedor.Text = objETipoDocumentoProveedor.Descripcion;
                        //  lblNumero.Text = objETipoDocumentoCliente.Numerador.Valor;
                    }
                    else
                    {
                        lblTipoComprobanteProveedor.Text = "";
                        // lblNumero.Text = "";
                    }
                }
                else
                {
                    lblTipoComprobanteProveedor.Text = "";
                    // lblNumero.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerValores()
        {
            if (objETipoDocumentoProveedor == null)
            {
                objETipoDocumentoProveedor = new Entidades.TipoDocumentoProveedor();
            }
            objETipoDocumentoProveedor.TipoDoc.Codigo = "ND";
            FormasDePago();
        }

        private void FormasDePago()
        {
            objETipoDocumentoProveedor.AfectaCaja = 'N';
            objETipoDocumentoProveedor.AfectaCtaCte = 'D';
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objEProveedor != null)
                    dgvDatos.DataSource = objLCheque.ObtenerTresMesesEnProveedor(objEProveedor, cbTiempo.Checked);
                else
                    dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                check.Value = !(Convert.ToBoolean(check.Value));
            }
            Calcular();
        }
        private int SumarCantidad() {
            int cantidad = 0;
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Seleccionado"].Value)) {
                    cantidad++;
                }
            }
            return cantidad;
        }

        private void txtGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender,e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    Comprobante();
                    Asiento();

                    objLFactura.AgregarChequesRechazados(objEFactura, txtMotivo.Text.Trim(), objEAsiento);
                    Limpiar();
                    MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<DataTable> lista;

        private bool Validar()
        {
            if (Utilidades.Validar.LabelEnBlanco(lblNombreProveedor))
            {
                MessageBox.Show("Seleccione un Proveedor Valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.LabelEnBlanco(lblTipoComprobanteProveedor))
            {
                MessageBox.Show("No existe Tipo De Comprobante para Proveedor Seleccionado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoProveedor.Focus();
                return true;
            }
            if (Utilidades.Validar.GrillaVacia(dgvDatos) && dgvDatos.Visible == true)
            {
                MessageBox.Show("El Comprobante no contiene Cheques Rechazados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (NumeroDocumentoBlanco(ucNumeroComprobante))
            {
                MessageBox.Show("Falta ingresar Número de comprobante", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            
            double total = NetoNoGravado() + Gastos() + IVA();
            if (total == 0)
            {
                MessageBox.Show("El Total del comprobante no puede ser $0.00.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }
        private double NetoNoGravado()
        {
            double neto = Calcular();
            return Utilidades.Redondear.DosDecimales(neto);
        }

        private double Gastos() {
            double gas = txtGastos.Text.Equals("") ? 0 : Convert.ToDouble(txtGastos.Text);
            return Utilidades.Redondear.DosDecimales(gas);
        }

        private double IVA()
        {
           double iva = 0;
            iva = Gastos() * 0.21;
           return Utilidades.Redondear.DosDecimales(iva);
        }

        private void Limpiar()
        {
            txtCodigoProveedor.Text = "";
            txtGastos.Text = "";
            txtMotivo.Text = "";
            ucNumeroComprobante.Limpiar();
        }

        private void Comprobante()
        {
            objEFactura = new Entidades.FacturaCompra();
            objEFactura.Sucursal.Codigo = Singleton.Instancia.Empresa.Codigo;
            objEFactura.TipoDocumentoProveedor = objETipoDocumentoProveedor;
            objEFactura.Letra = ucNumeroComprobante.Letra;
            objEFactura.PuntoDeVenta = ucNumeroComprobante.PuntoDeVenta;
            objEFactura.Numero = ucNumeroComprobante.Numero;
            objEFactura.Proveedor.Codigo = Convert.ToInt32(txtCodigoProveedor.Text.Trim());
            objEFactura.FechaEmision = dtFecha.Value;
            objEFactura.FechaContable = dtFechaCont.Value;
            objEFactura.TipoCompra = "CR";


            //objEFactura.FacturaKilos = false;
            List<Entidades.FormaDePago> formasDePago = new List<Entidades.FormaDePago>();
            //objEFormaDePago = objLFormaDePago.ObtenerUno(1);

            if (objETipoDocumentoProveedor.AfectaCtaCte.Equals('N'))
            {
                objEFactura.Imputacion = 'T';
            }
            else
            {
                objEFactura.Imputacion = 'F';
            }

            objEFactura.NoGravado = NetoNoGravado();
            //objEFactura.Neto105 = 0;
            objEFactura.Neto1 = Gastos();
            //objEFactura.Iva105 = 0;
            objEFactura.DescripImp1 = 21.00;
            objEFactura.ImporteImp1 = IVA();
            //objEFactura.FechaVenCae = Convert.ToDateTime("01/01/2000");
            objEFactura.PuestoCaja = Singleton.Instancia.Puesto;
            objEFactura.Usuario = Singleton.Instancia.Usuario;

            objEFactura.Cheques.Clear();
                
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value))
                        {
                            objCheque = new Entidades.Cheque();
                            objCheque.Codigo= Convert.ToInt32(fila.Cells["Codigo"].Value);
                            objCheque.CuentaBancaria.Codigo= Convert.ToInt32(fila.Cells["CodigoCuentaBancaria"].Value);
                            objCheque.Importe=Convert.ToDouble(fila.Cells["Importe"].Value);
                    //objCheque.EstadoValor.Codigo = "RE";
                    objEFactura.Cheques.Add(objCheque);
                        }
                }
           
        }

        private void Asiento()
        {
            /*try
            {*/
            objEAsiento = new Entidades.Asiento();
            //objEAsiento.Fecha = objEFactura.FechaEmision;
            objEAsiento.Fecha = objEFactura.FechaContable;
            objEAsiento.FechaEmision = objEFactura.FechaEmision;
            objEAsiento.Descripcion = "Nota de Débito N° " + objEFactura.Numdoc + " de " + lblNombreProveedor.Text; ;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            Entidades.Asiento_Detalle asientoDetalle;
            
            asientoDetalle = new Entidades.Asiento_Detalle();
            
            objEFormaDePago = objLFormaDePago.ObtenerUno(4);
            asientoDetalle.CuentaContable = objEFormaDePago.CuentaContable;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = NetoNoGravado() + Gastos() + IVA();
            objEAsiento.Detalle.Add(asientoDetalle);

            int propios = 0, terceros=0;
            foreach (Entidades.Cheque che in objEFactura.Cheques)
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                if (che.CuentaBancaria.Codigo == 0)
                {
                    //propios++;
                    terceros++;
                    asientoDetalle.CuentaContable.Codigo = 10105140000;
                }
                else {
                    //terceros++;
                    propios++;
                    che.CuentaBancaria = new Logica.CuentaBancaria().ObtenerUno(che.CuentaBancaria.Codigo);
                    if (objLCheque.ObtenerSiEstaConciliado(che) == 1)
                    {
                        asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContable;
                    }
                    else {
                        asientoDetalle.CuentaContable = che.CuentaBancaria.CuentaContableValoresDiferidos;
                    }
                }
                
                
                asientoDetalle.Cheque.Codigo = che.Codigo;
                asientoDetalle.Debe = che.Importe;
                //asientoDetalle.Debe = NetoNoGrabado();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            double valor = Utilidades.Redondear.DosDecimales(Gastos() / objEFactura.Cheques.Count);
            if (valor > 0) { 
                if (terceros > 0){
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 50103010102;
                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(valor *terceros);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }
                if (propios > 0)
                {
                    asientoDetalle = new Entidades.Asiento_Detalle();
                    asientoDetalle.CuentaContable.Codigo = 50103010101;
                    asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(valor * propios);
                    asientoDetalle.Haber = 0;
                    objEAsiento.Detalle.Add(asientoDetalle);
                }


                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10105010000;
                asientoDetalle.Debe = IVA();
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtGastos_TextChanged(object sender, EventArgs e)
        {
            txtIVA.Text = IVA().ToString("C2");
            Calcular();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
