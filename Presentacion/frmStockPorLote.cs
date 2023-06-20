using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{

    public partial class frmStockPorLote : Presentacion.frmColor
    {
        Logica.Lote objLLote = new Logica.Lote();

        DataView dvLotes = new DataView();
    
        public frmStockPorLote(Entidades.Producto pProducto)
        {
            InitializeComponent();
            ConfiguracionInicial(pProducto);
        }

        private void ConfiguracionInicial(Entidades.Producto pProducto)
        {
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.MultiSelect = true;
            Titulo(pProducto.Descripcion);   
            Formatos();
            CargarValores(pProducto);
        }
        private void Titulo(string pProducto)
        {
            this.Text = "CONSULTA DE STOCK - "  + pProducto;
        }
        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDatos.Columns["Lote"].Width = 60;
            dgvDatos.Columns["Proveedor"].Width = 190;
            dgvDatos.Columns["Stock"].Width = 60;
           
        }

        private void CargarValores(Entidades.Producto pProducto)
        {
            try
            {
                dvLotes = objLLote.ObtenerTodosPorProducto(pProducto).DefaultView;//objLCheque.ObtenerEnCartera();

                if (cbStockCero.Checked)
                    dvLotes.RowFilter = "Stock<>0";
                dgvDatos.DataSource = dvLotes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbStockCero_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockCero.Checked)
                dvLotes.RowFilter = "Stock<>0";
            else
                dvLotes.RowFilter = "";
            dgvDatos.DataSource = dvLotes;
        }
    }
}