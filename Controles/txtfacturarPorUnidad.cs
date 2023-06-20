using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles2
{
    public partial class txtfacturarPorUnidad : UserControl
    {

        public txtfacturarPorUnidad()
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
        }

        
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloNumeros(e);
            CambiarFoco(e);
        }

        public static void PermitirSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void CambiarFoco(KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloNumeros(e);
            CambiarFoco(e);
        }

        private void cbLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloNumeros(e);
            CambiarFoco(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirNumerosPuntuacion(e,txtPrecio);
            CambiarFoco(e);
        }

        public static void PermitirNumerosPuntuacion(KeyPressEventArgs e, TextBox text)
        {
            if (e.KeyChar == 46) {
                e.KeyChar = ',';
            }

            if (text.Text.Contains(","))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else {
                if (!char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
                if (e.KeyChar == ',' || e.KeyChar == '\b') {
                    e.Handled = false;
                }
            }
        }

        private void AgregarAGrilla()
        {

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (cbLote.SelectedValue != null)
                {
                    if (fila.Cells["Codigo"].Value.ToString() == txtProducto.Text.Trim() && fila.Cells["Lote"].Value.ToString() == cbLote.SelectedValue.ToString())
                    {
                        MessageBox.Show("Producto ya ingresado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (dgvDatos.Rows.Count < 15)
            {
                if (!lblProducto.Text.Equals(""))
                {
                    if (!txtCantidad.Text.Equals("") && Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        if (cbLote.SelectedValue != null)
                        {
                            if (!txtPrecio.Text.Equals("") && Convert.ToDouble(txtPrecio.Text.Trim()) > 0)
                            {
                                dgvDatos.Rows.Add(txtProducto.Text.Trim(), lblProducto.Text, cbLote.SelectedValue, txtCantidad.Text, Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text)*Convert.ToDouble(txtPrecio.Text), Iva);
                                Neto = Neto + Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
                                //IvaTotal = IvaTotal + (Iva* Convert.ToInt32(txtCantidad.Text));
                                CalcularIva();
                                txtProducto.Text = "";
                                txtCantidad.Text = "";
                                txtPrecio.Text = "";
                                Iva = 0;
                                txtProducto.Focus();
                            }
                            else
                            {
                                txtPrecio.Focus();
                                MessageBox.Show("El Precio debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lote no seleccionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        txtCantidad.Focus();
                        MessageBox.Show("La cantidad debe ser mayor a cero.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto valido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProducto.Focus();
                }
            }            
            else
            {
                MessageBox.Show("Se alcanzo cantidad maxima de Productos por Remito.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAGrilla();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                Neto = Neto - (Convert.ToDouble(dgvDatos.CurrentRow.Cells["PrecioUnitario"].Value) * Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cantidad"].Value));
                //IvaTotal = IvaTotal - (Convert.ToDouble(dgvDatos.CurrentRow.Cells["Ivas"].Value) * Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cantidad"].Value)); ;
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CalcularIva();
            }
        }

        private void CalcularIva() {
            IvaTotal = 0;
            foreach (DataGridViewRow dg in dgvDatos.Rows) {
                IvaTotal += Convert.ToDouble(dg.Cells["Ivas"].Value) * Convert.ToInt32(dg.Cells["Cantidad"].Value);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null) {
                txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                //txtProducto.Text = dgvDatos.SelectedRows[0].Cells["Descripción"].Value.ToString();
                cbLote.Text = dgvDatos.SelectedRows[0].Cells["Lote"].Value.ToString();
                txtCantidad.Text = dgvDatos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                txtPrecio.Text = dgvDatos.SelectedRows[0].Cells["PrecioUnitario"].Value.ToString();
                // Iva= Convert.ToDouble(dgvDatos.SelectedRows[0].Cells["Iva"].Value);
                Neto = Neto - (Convert.ToDouble(dgvDatos.CurrentRow.Cells["PrecioUnitario"].Value) * Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cantidad"].Value));
                //IvaTotal = IvaTotal - (Convert.ToDouble(dgvDatos.CurrentRow.Cells["Ivas"].Value) * Convert.ToInt32(dgvDatos.CurrentRow.Cells["Cantidad"].Value)); ;
                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                CalcularIva();
                txtCantidad.Focus();
            }
        }

        private double neto;
        private double ivaTotal;


        private double iva=0;

        public double Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public double Neto
        {
            get
            {
                return neto;
            }

            set
            {
                neto = value;
            }
        }

        public double IvaTotal
        {
            get
            {
                return ivaTotal;
            }

            set
            {
                ivaTotal = value;
            }
        }
    }
}
