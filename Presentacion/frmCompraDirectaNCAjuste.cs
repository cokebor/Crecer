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
    public partial class frmCompraDirectaNCAjuste : frmColor
    {
        private Entidades.Proveedor objProveedor = new Entidades.Proveedor();
        //private Logica.RemitoProveedor objLRemito = new Logica.RemitoProveedor();
        //private Entidades.RemitoProveedor_M objERemito = new Entidades.RemitoProveedor_M();
        Logica.FacturaCompra objLFacturaCompra = new Logica.FacturaCompra();
        Entidades.FacturaCompra objEFactura = new FacturaCompra();

        public frmCompraDirectaNCAjuste() {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Formatos();
            detalle = new List<FacturaCompra_Detalle>();
        }

        private void Titulo()
        {
            this.Text = "NOTA DE CREDITO COMPRA DIRECTA";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbComprobantes);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 50;    
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["PrecioUnitario"].Width = 70;
            dgvDatos.Columns["DescuentoU"].Width = 70;
            
            dgvDatos.Columns["DescuentoU"].ReadOnly = false;
        }
        public Entidades.Proveedor ObjProveedor
        {
            get
            {
                return objProveedor;
            }

            set
            {
                objProveedor = value;
                try
                {
                    Utilidades.Combo.Llenar(cbComprobantes, objLFacturaCompra.ObtenerPorProveedor(objProveedor),"Codigo","Numero");//objLRemito.ObtenerCompraDirecta(objProveedor),"Codigo","NumRemito");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public double Neto105
        {
            get
            {
                double res = 0.0;
                foreach (DataGridViewRow dgvr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgvr.Cells["PorcIva"].Value) == 10.5)
                        res += Convert.ToDouble(dgvr.Cells["Total"].Value);
                }
                return Utilidades.Redondear.DosDecimales(res);
            }
            
        }

        public double Neto21
        {
            get
            {
                double res = 0.0;
                foreach (DataGridViewRow dgvr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgvr.Cells["PorcIva"].Value) == 21)
                        res += Convert.ToDouble(dgvr.Cells["Total"].Value);
                }
                return Utilidades.Redondear.DosDecimales(res);
            }

        }
        

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!((frmFacturaCompra)formularioAnterior).objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
            {
                ((frmFacturaCompra)FormularioAnterior).txtNeto1.Text = Neto105.ToString("0.00");
                ((frmFacturaCompra)FormularioAnterior).txtNeto2.Text = Neto21.ToString("0.00");
            }
            else {
                ((frmFacturaCompra)FormularioAnterior).txtNoGravado.Text = (Neto105 + Neto21).ToString("0.00");
            }
            this.Hide();
        }

        private void cbComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (cbComprobantes.SelectedValue != null)
                {
                    objEFactura = objLFacturaCompra.ObtenerUnaAjuste(Convert.ToInt32(cbComprobantes.SelectedValue));
                    //objERemito = objLRemito.ObtenerUno(Convert.ToInt32(cbRemitos.SelectedValue));
                }
                else {
                  //  objERemito = new Entidades.RemitoProveedor_M();
                    objEFactura = new FacturaCompra();
                }

                dgvDatos.Rows.Clear();
                foreach (Entidades.FacturaCompra_Detalle r in objEFactura.Detalle)
                {

                    dgvDatos.Rows.Add(r.Renglon, r.Producto.Codigo, r.Producto.Descripcion, r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.PorIva, r.PrecioUnitario);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)

        {
            TextBox validar = e.Control as TextBox;
            if (validar != null)
            {
                validar.KeyPress += new KeyPressEventHandler(this.validar_KeyPress);
             //   validar.TextChanged += new EventHandler(this.validar_TextChanged);
              
            }
        }

        private void validar_KeyPress(object sender, KeyPressEventArgs e) {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacion(sender, e);
        }

        private void validar_TextChanged(object sender, EventArgs e)
        {
         /*
            double precio, porcIVA, total;
            int cantidad;
            if (((TextBox)sender).Text.Trim().Equals("")) {
                precio = 0;
                dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Iva"].Value = 0;
                total = 0;
                dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value = total;
            }
            else {
                if (Convert.ToInt32(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["CantidadDevuelta"].Value) <= Convert.ToInt32(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Cantidad"].Value))
                {
                    //precio = Utilidades.Redondear.DosDecimales((Convert.ToDouble(((TextBox)sender).Text)));
                    precio = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["PrecioUnitario"].Value));
                    porcIVA = Convert.ToDouble(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["PorcIva"].Value);
                    cantidad = Convert.ToInt32(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["CantidadDevuelta"].Value);

                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(precio * (porcIVA / 100));


                    if (cantidad == 0)
                    {
                        dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["CantidadDevuelta"].Value = "";
                    }

                    total = Utilidades.Redondear.DosDecimales(precio * cantidad);
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value = total;
                }
                else
                {
                    MessageBox.Show("Cantidad incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["CantidadDevuelta"].Value = "";
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value = 0;
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Iva"].Value = "";
                }
            }
            */

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCompraDirecta_Load(object sender, EventArgs e)
        {

        }

        private List<Entidades.FacturaCompra_Detalle> detalle;

        public void ObtenerDatos() {
            int renglon = 1;
            detalle.Clear();
            Entidades.FacturaCompra_Detalle objEFacturaDetalle;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                if (fila.Cells["DescuentoU"].Value!=null  && !fila.Cells["DescuentoU"].Value.Equals("") && Convert.ToDouble(fila.Cells["DescuentoU"].Value)>0) { 
                    objEFacturaDetalle = new Entidades.FacturaCompra_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEFacturaDetalle.Cantidad= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                //objEFacturaDetalle.RenglonRemito = Convert.ToInt32(fila.Cells["Renglon"].Value);
                    objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["DescuentoU"].Value);
                    objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva"].Value);
                    objEFacturaDetalle.Codigofactura = Convert.ToInt32(cbComprobantes.SelectedValue);
                    objEFacturaDetalle.RenglonFactura= Convert.ToInt32(fila.Cells["Renglon"].Value);


                    renglon += 1;
                    Detalle.Add(objEFacturaDetalle);

                }
            }
        }

        private Form formularioAnterior;
        public Form FormularioAnterior
        {
            get
            {
                return formularioAnterior;
            }

            set
            {
                formularioAnterior = value;
            }
        }

        public List<FacturaCompra_Detalle> Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*if (Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value) <= Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value))
            {
                double precioUnitario;
                    precioUnitario = Utilidades.Redondear.CuatroDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value));

                double porcIVA = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIVA"].Value);
                int cantDevuelta = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value);
                dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Utilidades.Redondear.CuatroDecimales(cantDevuelta * precioUnitario);
                //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cantDevuelta);

                dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (porcIVA / 100));
                if (cantDevuelta == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "";
                }
            }
            else
            {
                MessageBox.Show("Cantidad incorrecta!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "";
                dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
            }*/
            if (Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DescuentoU"].Value) <= Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value))
            {

                double precioUnitario;
                precioUnitario = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["DescuentoU"].Value));

                double porcIVA = Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["PorcIVA"].Value);
                int cant = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Cantidad"].Value);
                dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = Utilidades.Redondear.DosDecimales(cant * precioUnitario);
                //dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Utilidades.Redondear.CuatroDecimales(precioUnitario * (porcIVA / 100)) * cant);
                dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(Convert.ToDouble(dgvDatos.Rows[e.RowIndex].Cells["Total"].Value) * (porcIVA / 100));
                if (cant == 0 || precioUnitario == 0)
                {
                    dgvDatos.Rows[e.RowIndex].Cells["DescuentoU"].Value = "";
                    dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = 0;
                    dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
                }
            }
            else
            {
                MessageBox.Show("Descuento no puede ser superior al facturado!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDatos.Rows[e.RowIndex].Cells["DescuentoU"].Value = "";
                dgvDatos.Rows[e.RowIndex].Cells["Total"].Value = 0;
                dgvDatos.Rows[e.RowIndex].Cells["Iva"].Value = "";
            }
        }
        
    }
}
