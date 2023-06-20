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
    public partial class frmCompraDirecta : frmColor
    {
        private Entidades.Proveedor objProveedor = new Entidades.Proveedor();
        private Logica.RemitoProveedor objLRemito = new Logica.RemitoProveedor();
        private Entidades.RemitoProveedor_M objERemito = new Entidades.RemitoProveedor_M();

        

        public frmCompraDirecta() {
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
            this.Text = "FACTURA COMPRA DIRECTA";
        }

        private void Formatos()
        {
            Utilidades.Combo.Formato(cbRemitos);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Codigo"].Width = 50;
            dgvDatos.Columns["Descripción"].Width = 150;
            dgvDatos.Columns["Lote"].Width = 50;    
            dgvDatos.Columns["Cantidad"].Width = 70;
            dgvDatos.Columns["PrecioUnitario"].Width = 70;
            dgvDatos.Columns["PrecioUnitario"].ReadOnly = false;
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
                    Utilidades.Combo.Llenar(cbRemitos, objLRemito.ObtenerCompraDirecta(objProveedor),"Codigo","NumRemito2");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public double Neto0
        {
            get
            {
                double res = 0.0;
                foreach (DataGridViewRow dgvr in dgvDatos.Rows)
                {
                    if (Convert.ToDouble(dgvr.Cells["PorcIva"].Value) == 0)
                        res += Convert.ToDouble(dgvr.Cells["Total"].Value);
                }
                return Utilidades.Redondear.DosDecimales(res);
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
            dgvDatos.Enabled = false;
            if (!((frmFacturaCompra)formularioAnterior).objETipoDocumentoProveedor.AfectaIVA.Equals('N'))
            {
                ((frmFacturaCompra)FormularioAnterior).txtNeto1.Text = Neto0.ToString("0.00");//Neto105.ToString("0.00");
                ((frmFacturaCompra)FormularioAnterior).txtNeto2.Text = Neto21.ToString("0.00");
            }
            else {
                ((frmFacturaCompra)FormularioAnterior).txtNoGravado.Text = (Neto0 + Neto105 + Neto21).ToString("0.00");
            }
            this.Hide();
        }

        private void cbRemitos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {

                if (cbRemitos.SelectedValue != null)
                {
                    //objERemito = objLRemito.ObtenerUno(Convert.ToInt32(cbRemitos.SelectedValue));
                    objERemito = objLRemito.ObtenerUnoParaFacturar(Convert.ToInt32(cbRemitos.SelectedValue));
                }
                else {
                    objERemito = new Entidades.RemitoProveedor_M();
                    
                }

                dgvDatos.Rows.Clear();
                foreach (Entidades.RemitoProveedor_D_Producto r in objERemito.Productos)
                {
                    dgvDatos.Rows.Add(r.Renglon, r.Producto.Codigo, r.Producto.Descripcion, r.MovStock_Lotes.IdLote.IdLote, r.MovStock_Lotes.Cantidad, r.Producto.PorcentajeIVA);
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
                validar.TextChanged += new EventHandler(this.validar_TextChanged);
                //txt.KeyPress += new KeyEventHandler(this.textBox1_KeyPress);
            }
        }

        private void validar_KeyPress(object sender, KeyPressEventArgs e) {
            Utilidades.CajaDeTexto.PermitirNumerosPuntuacionCuatroDecimales(sender, e);
        }

        private void validar_TextChanged(object sender, EventArgs e)
        {
            //double precio= Convert.ToDouble(((TextBox)sender).Text);
            double precio, porcIVA, total;
            int cantidad;
            
            
            if (((TextBox)sender).Text.Trim().Equals("")) {
                precio = 0;
                dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Iva"].Value = 0;
                total = 0;
                dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value = total;
            }
            else { 
            precio = Utilidades.Redondear.CuatroDecimales((Convert.ToDouble(((TextBox)sender).Text)));
            porcIVA = Convert.ToDouble(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["PorcIva"].Value);
            cantidad = Convert.ToInt32(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Cantidad"].Value);
            dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Iva"].Value = Utilidades.Redondear.DosDecimales(precio * (porcIVA/100));
            total = Utilidades.Redondear.DosDecimales(precio * cantidad);
                dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value = total;
            }
        }

        private List<Entidades.FacturaCompra_Detalle> detalle;

        public void ObtenerDatos() {
            int renglon = 1;
            detalle.Clear();
            Entidades.FacturaCompra_Detalle objEFacturaDetalle;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                if (!(fila.Cells["PrecioUnitario"].Value==null) && !fila.Cells["PrecioUnitario"].Value.ToString().Equals("")) { 
                    objEFacturaDetalle = new Entidades.FacturaCompra_Detalle();
                    objEFacturaDetalle.Renglon = renglon;
                    objEFacturaDetalle.Producto.Codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    objEFacturaDetalle.Producto.Descripcion = fila.Cells["Descripción"].Value.ToString();
                    objEFacturaDetalle.Cantidad= Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    objEFacturaDetalle.PorIva = Convert.ToDouble(fila.Cells["PorcIVA"].Value);
                    objEFacturaDetalle.RenglonRemito = Convert.ToInt32(fila.Cells["Renglon"].Value);
                    objEFacturaDetalle.PrecioUnitario = Convert.ToDouble(fila.Cells["PrecioUnitario"].Value);
                    objEFacturaDetalle.Iva = Convert.ToDouble(fila.Cells["Iva"].Value);
                    objEFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(fila.Cells["Lote"].Value);


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

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
                dgvDatos.Rows.Clear();
                try
                {
                if (cbConsignacion.Checked) {
                    Utilidades.Combo.Llenar(cbRemitos, objLRemito.ObtenerConsignacion(objProveedor), "Codigo", "NumRemito2");
                }
                else { 
                    Utilidades.Combo.Llenar(cbRemitos, objLRemito.ObtenerCompraDirecta(objProveedor), "Codigo", "NumRemito2");
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void dgvDatos_EnabledChanged(object sender, EventArgs e)
        {
            if (dgvDatos.Enabled == false)
                //Utilidades.ControlesGenerales.PresionarEnter();
                dgvDatos.EndEdit();
        }
    }
}
