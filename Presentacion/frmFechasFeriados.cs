using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmFechasFeriados : Presentacion.frmColor
    {
        Logica.FechaFeriado objLFechasFeriados = new Logica.FechaFeriado();

        public frmFechasFeriados()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            //  LimitesTamaños();
            Formatos();
            CargarSucursales();
        }
        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE FECHAS DE FERIADOS";
        }


        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbSucursales);
            Utilidades.Grilla.Formato(dgvDatos);
            dgvDatos.Columns["Fecha"].Width = 70;
            dgvDatos.Columns["Sucursal"].Width = 150;
            dgvDatos.Columns["Pago"].Width = 50;
        }

        private void dtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void Limpiar()
        {
            dtFecha.Value = DateTime.Now;
            Utilidades.Combo.SeleccionarPrimerValor(cbSucursales);
            cbPago.Checked = false;
        }

        private void CargarSucursales()
        {
            try
            {
                Utilidades.Combo.Llenar(cbSucursales, new Logica.Sucursal().ObtenerLocalidades(), "Codigo", "Descripcion", "Todas");
                cbSucursales.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (objLFechasFeriados.VerSiExiste(dtFecha.Value.Date, Convert.ToInt32(cbSucursales.SelectedValue)) == true)
                {
                    MessageBox.Show("Fecha ya ingresada para la sucursal " + cbSucursales.Text + " en el Sistema!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (Convert.ToInt32(cbSucursales.SelectedValue) == Convert.ToInt32(item.Cells["CodigoSucursal"].Value) && dtFecha.Value.Date.Equals(Convert.ToDateTime(item.Cells["Fecha"].Value)))
                    {
                        MessageBox.Show("Fecha ya ingresada para la sucursal " + item.Cells["Sucursal"].Value + "!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                if (Convert.ToInt32(cbSucursales.SelectedValue) == 0)
                {


                    foreach (DataRowView item in cbSucursales.Items)
                    {
                        if (Convert.ToInt32(item[0]) != 0)
                        {
                            if (dgvDatos.Rows.Count > 0)
                            {
                                bool salir = false;

                                if (objLFechasFeriados.VerSiExiste(dtFecha.Value.Date, Convert.ToInt32(item[0])) == true)
                                {
                                    MessageBox.Show("Fecha ya ingresada para la sucursal " + item[1] + " en el Sistema!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    salir = true;
                                    continue;
                                }


                                foreach (DataGridViewRow item2 in dgvDatos.Rows)
                                {
                                    if (Convert.ToInt32(item[0]) == Convert.ToInt32(item2.Cells["CodigoSucursal"].Value))
                                    //&& dtFecha.Value.Date.Equals(Convert.ToDateTime(item2.Cells["Fecha"].Value)))
                                    {
                                        if (dtFecha.Value.Date.Equals(Convert.ToDateTime(item2.Cells["Fecha"].Value)))
                                        {
                                            MessageBox.Show("Fecha ya ingresada para la sucursal " + item[1], Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            salir = true;
                                            break;
                                        }
                                        //                                    dgvDatos.Rows.Add(dtFecha.Value.Date, Convert.ToInt32(item[0]), item[1], cbPago.Checked);
                                    }
                                }
                                if (salir == false)
                                {
                                    dgvDatos.Rows.Add(dtFecha.Value.Date, Convert.ToInt32(item[0]), item[1], cbPago.Checked);
                                }
                            }
                            else
                            {
                                if (objLFechasFeriados.VerSiExiste(dtFecha.Value.Date, Convert.ToInt32(item[0])) == true)
                                {
                                    MessageBox.Show("Fecha ya ingresada para la sucursal " + item[1] + " en el Sistema!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {

                                    dgvDatos.Rows.Add(dtFecha.Value.Date, Convert.ToInt32(item[0]), item[1], cbPago.Checked);
                                }
                            }

                        }

                    }
                }
                else
                {
                    dgvDatos.Rows.Add(dtFecha.Value.Date, Convert.ToInt32(cbSucursales.SelectedValue), cbSucursales.Text, cbPago.Checked);
                }
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar Fechas para poder Guardar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Entidades.FechaFeriado objEFechaFeriado; 
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    objEFechaFeriado = new Entidades.FechaFeriado();
                    objEFechaFeriado.Fecha = Convert.ToDateTime(item.Cells["Fecha"].Value);
                    objEFechaFeriado.Sucursal.Codigo = Convert.ToInt32(item.Cells["CodigoSucursal"].Value);
                    objEFechaFeriado.PagoDiaExtra = Convert.ToBoolean(item.Cells["Pago"].Value);
                    objEFechaFeriado.Usuario = Singleton.Instancia.Usuario;
                    objLFechasFeriados.Agregar(objEFechaFeriado);
                }
                if(dgvDatos.Rows.Count==1)
                    MessageBox.Show("Fecha de Feriado agregada exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Fechas de Feriados agregadas exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                dgvDatos.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            dgvDatos.Rows.Clear();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvDatos.Columns[e.ColumnIndex].Name)
                {
                    case "Cancelar":
                        dgvDatos.Rows.RemoveAt(e.RowIndex);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
