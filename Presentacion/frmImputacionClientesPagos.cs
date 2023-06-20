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

    public partial class frmImputacionClientesPagos : Presentacion.frmColor
    {
        Logica.Factura objLFactura = new Logica.Factura();
        //Logica.Cheque objLCheque = new Logica.Cheque();
        //List<Entidades.FacturaCompra> facturas;

        public frmImputacionClientesPagos()
        {
            InitializeComponent();
            ConfiguracionInicial();
          //  facturas = new List<FacturaCompra>();
        }
        
        public frmImputacionClientesPagos(Entidades.Cliente objCliente)
        {
            InitializeComponent();
            ConfiguracionInicial();
            Cliente = objCliente;
            //facturas = new List<FacturaCompra>();
            CargarValores();
        }


        private void ConfiguracionInicial()
        {
            lblDisponible.Text = Convert.ToDouble("0").ToString("C2");
            lblAplicado.Text = Convert.ToDouble("0").ToString("C2");
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            Titulo();   
            Formatos();
//            CargarValores();
        }

        private Entidades.Cliente cliente;

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        private void Titulo()
        {
            this.Text = "IMPUTACION DE FACTURAS";
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);

           // dgvDatos.MultiSelect = true;
            dgvDatos.Columns["Seleccionado"].ReadOnly = false;
            
            dgvDatos.Columns["Seleccionado"].Width = 30;
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Tipo"].Width = 30;
            dgvDatos.Columns["Numero"].Width = 90;
            dgvDatos.Columns["Total2"].Width = 90;
            dgvDatos.Columns["Imputado"].Width = 90;
            dgvDatos.Columns["Pendiente"].Width = 90;
            dgvDatos.Columns["AAplicar"].Width = 90;
            dgvDatos.Columns["AAplicar"].ReadOnly = false;
            // dgvDatos.Columns["Descripción"].Width = 150;
        }

        private void CargarValores()
        {
            try
            {
                
                DataTable dt= objLFactura.ObtenerFacturasSinImputar(Cliente);
                foreach (DataRow dr in dt.Rows) {

                    dgvDatos.Rows.Add(false, Convert.ToDateTime(dr["Fecha"]).ToString("d").Replace("-", "/"), dr["Tipo"], dr["Codigo"],dr["CodigoTipoDocumentoCliente"], dr["Numero"], Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Imputado"]), Convert.ToDouble(dr["Saldo"]),"","");
            
                }
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
            //frmFormasDePagoProveedores.busqueda = "ChequesTerceros";
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == this.dgvDatos.Columns["Seleccionado"].Index) {
                    DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)this.dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"];
                    check.Value = !(Convert.ToBoolean(check.Value));
                    if (Convert.ToBoolean(check.Value) == true)
                    {
                        if (Disponible >= Convert.ToDouble(dgvDatos["Pendiente", e.RowIndex].Value))
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = dgvDatos["Pendiente", e.RowIndex].Value;
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "T";
                        }
                        else if (Disponible == 0) {
                       // dgvDatos.CurrentRow.Cells[0].Value = false;
                        //  dgvDatos.Rows[e.RowIndex].Cells["Seleccionado"].Value = 0;
             //           dgvDatos["Seleccionado",e.RowIndex].Value = false;
                    } else
                        {
                            dgvDatos["AAplicar", e.RowIndex].Value = Disponible;
                            dgvDatos["CodigoImputacion", e.RowIndex].Value = "P";
                    }

                    }
                    else {
                        dgvDatos["AAplicar", e.RowIndex].Value = "";
                        dgvDatos["CodigoImputacion", e.RowIndex].Value = "";
                        
                }
                    Aplicado();
                }
            }
        
        private void frmImputacionProveedoresPagos_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.Validar_KeyPress);
                
                //validar.KeyUp += new KeyEventHandler(this.Validar_TextChanged);
            }
        }
        

        private void Validar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private double total;
        public double Total1
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        private void cargarValores() {
            lblAplicado.Text = Aplicado().ToString("C2");
        }

        public double Aplicado()
        {
            double res = 0;
            foreach (DataGridViewRow dgv in dgvDatos.Rows) {
                if(Convert.ToBoolean(dgv.Cells["Seleccionado"].Value))
                    if(!(dgv.Cells["AAplicar"].Value== null) && !dgv.Cells["AAplicar"].Value.Equals(""))
                        res += Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgv.Cells["AAplicar"].Value));
            }
            lblAplicado.Text = res.ToString("C2");
            lblDisponible.Text = (Total1 - res).ToString("C2");      
            return res;
        }

        public double Disponible {
            get {
                return Utilidades.Redondear.DosDecimales(Total1 - Aplicado());
            }
        }

        private void Cambio() {
            foreach (DataGridViewRow d in dgvDatos.Rows) {
                if (d.Cells["CodigoImputacion"].Value.Equals("")) {
                    d.Cells["Seleccionado"].Value = false;
                }
            }
        }
        
  
        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {

            Aplicado();
            Cambio();
        }

        public List<Entidades.FacturaImputacion> ObtenerDatos()
        {
            List<Entidades.FacturaImputacion> facturas=new List<Entidades.FacturaImputacion>();
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                Entidades.FacturaImputacion factura;
                if (Convert.ToBoolean(fila.Cells["Seleccionado"].Value) == true && !fila.Cells["CodigoImputacion"].Value.Equals(""))
                {
                    factura = new Entidades.FacturaImputacion();

                    factura.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    factura.TipoDocumentoCliente.Codigo = Convert.ToInt32(fila.Cells["CodigoTipoDocumentoProveedor"].Value);
                    factura.Monto = Convert.ToDouble(fila.Cells["AAplicar"].Value);
                    factura.CodigoImputacion = Convert.ToChar(fila.Cells["CodigoImputacion"].Value);
                    factura.ImputacionAnterior= Convert.ToDouble(fila.Cells["Imputado"].Value);
                    facturas.Add(factura);
                    
                }
            }
            return facturas;
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Aplicado();
        }
    }
}