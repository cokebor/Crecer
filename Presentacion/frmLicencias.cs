using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Presentacion
{
    public partial class frmLicencias : Presentacion.frmColor
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();

        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Licencia objLLicencia = new Logica.Licencia();

        public String DirArchivo { get; set; }
        public frmLicencias()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formatos();
            TraerTiposLicencias();
        }
        private void Titulo()
        {
            this.Text = "ADMINISTRACION DE LICENCIAS";
        }

        private void Formatos()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Grilla.Formato(dgvDatos);
            Utilidades.Combo.Formato(cbTiposLicencias);
            dgvDatos.Columns["Legajo"].Width = 50;
            dgvDatos.Columns["Empleado"].Width = 160;
            dgvDatos.Columns["DesdeL"].Width = 75;
            dgvDatos.Columns["HastaL"].Width = 75;
            dgvDatos.Columns["Dias"].Width = 40;
            dgvDatos.Columns["Licencia"].Width = 110;
            dgvDatos.Columns["Cancelar"].Width = 55;

        }

        private void txtCodigoEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosRapidos(e);
        }

        private void txtCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.CajaDeTexto.SoloNumeros(e);
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void AccesosRapidos(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F1:
                    Utilidades.Formularios.Abrir(this.MdiParent, new frmEmpleadoBuscar("Licencias", this));
                    break;
            }
        }

        private void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoEmpleado.Text.Trim().Equals(""))
                {

                    objEEmpleado = objLEmpleado.ObtenerVendedorUnoActivo(Convert.ToInt32(txtCodigoEmpleado.Text.Trim()));
                    if (objEEmpleado != null)
                    {
                        lblNombreEmpleado.Text = objEEmpleado.Apellido + ", " + objEEmpleado.Nombres;
                    }
                    else
                    {
                        lblNombreEmpleado.Text = "";
                    }
                }
                else
                {
                    objEEmpleado = null;
                    lblNombreEmpleado.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime desde, hasta;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblNombreEmpleado.Text.Equals(""))
                {
                    desde = dtDesde.Value.Date;
                    hasta = dtHasta.Value.Date;


                    if (Utilidades.Validar.ValidarFechas(desde, hasta).Equals(false))
                    {
                        MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DateTime pDesdeL;
                    DateTime pHastaL;
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        /*if (cbLote.SelectedValue != null)
                        {*/
                       
                        if (fila.Cells["CodigoEmpleado"].Value.ToString() == txtCodigoEmpleado.Text.Trim())
                        {
                            pDesdeL = Convert.ToDateTime(fila.Cells["DesdeL"].Value);
                            pHastaL = Convert.ToDateTime(fila.Cells["HastaL"].Value);
                            for (DateTime i = pDesdeL; i <= pHastaL; i = i.AddDays(1))
                            {
                                if ((i >= desde) && (i <= hasta))
                                {
                                    MessageBox.Show("Empleado ya tiene otras licencias dentro del rango indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }


                    List<Entidades.Licencia> licencias = objLLicencia.ObtenerporEmpleado(objEEmpleado);
                    //}
                    foreach (Entidades.Licencia item in licencias)
                    {
                        pDesdeL = item.Desde;
                        pHastaL = item.Hasta;
                        for (DateTime i = pDesdeL; i <= pHastaL; i = i.AddDays(1))
                        {
                            if ((i >= desde) && (i <= hasta))
                            {
                                MessageBox.Show("Empleado ya tiene otras licencias cargadas anteriormente dentro del rango indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    dgvDatos.Rows.Add(objEEmpleado.Codigo, objEEmpleado.Legajo, objEEmpleado.NombreCompleto, dtDesde.Value.Date, dtHasta.Value.Date, Utilidades.Fechas.DiferenciaEntreFechasEnDias(dtHasta.Value, dtDesde.Value), Convert.ToInt32(cbTiposLicencias.SelectedValue), cbTiposLicencias.Text, DirArchivo, txtObservaciones.Text);
                    LimpiarAlAgregar();
                }
                else {
                    MessageBox.Show("Debe seleccionar un Empleado valido", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarAlAgregar()
        {
            txtCodigoEmpleado.Text = "";
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            lblArchivo.Text = "";
            txtObservaciones.Text = "";
            DirArchivo = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void TraerTiposLicencias()
        {
            try
            {
                Utilidades.Combo.Llenar(cbTiposLicencias, new Logica.TipoLicencia().ObtenerTodos(false), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.Rows.Count > 0)
                {
                    Entidades.Licencia objELicencia;
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        objELicencia = new Entidades.Licencia();
                        objELicencia.Empleado.Codigo = Convert.ToInt32(item.Cells["CodigoEmpleado"].Value);
                        objELicencia.TipoLicencia.Codigo= Convert.ToInt32(item.Cells["CodigoTipoLicencia"].Value);
                        objELicencia.Desde= Convert.ToDateTime(item.Cells["DesdeL"].Value);
                        objELicencia.Hasta = Convert.ToDateTime(item.Cells["HastaL"].Value);
                        objELicencia.Dias = Convert.ToInt32(item.Cells["Dias"].Value);
                        objELicencia.Observaciones = item.Cells["Observaciones"].Value.ToString();
                        if (item.Cells["Archivo"].Value != null && item.Cells["Archivo"].Value != "")
                            objELicencia.Certificado = System.IO.File.ReadAllBytes(item.Cells["Archivo"].Value.ToString());
            
                        objLEmpleado.AgregarLicencia(objELicencia, Singleton.Instancia.Usuario);
                    }
                    

                    MessageBox.Show("Licencias Cargadas Exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    
                }
                else
                {
                    MessageBox.Show("No se cargo ninguna Fecha de Licencia", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frmLicencias_Load(object sender, EventArgs e)
        {

        }

        private void cbTiposLicencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblArchivo.Text = "";
            if (Convert.ToInt32(cbTiposLicencias.SelectedValue) == 1)
            {
                btnAdjuntar.Visible = true;
            }
            else
            {
                btnAdjuntar.Visible = false;
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            ofd.FileName = "";
            ofd.Filter = "Todas las imagenes|*.png; *.jpg";//"Todas las imagenes | *.jpeg, *.jpe, *.jpg, *.png, *.bmp, *.*";
            DialogResult r = ofd.ShowDialog();
            DirArchivo = "";

            if (r == DialogResult.OK)
            {
                DirArchivo = ofd.FileName;
            }
            lblArchivo.Text = DirArchivo;
        }

        private void Limpiar()
        {
            txtCodigoEmpleado.Text = "";
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
            Utilidades.Combo.SeleccionarPrimerValor(cbTiposLicencias);
            dgvDatos.Rows.Clear();
            lblArchivo.Text = "";
            DirArchivo = "";
            txtObservaciones.Text = ""; 
        }
    }
}
