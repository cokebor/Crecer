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
    public partial class frmInversionesInformes : Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.TipoInversiones objLTipoInversiones = new Logica.TipoInversiones();
        Logica.Fondo objLFondos = new Logica.Fondo();
        Logica.Inversion objLInversion = new Logica.Inversion();
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();

        DataTable dtMovimientos;
        public frmInversionesInformes()
        {
            InitializeComponent();
            ConfiguracionInicial();
            //dgvFC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfiguracionInicial()
        {
            Titulo();
            Formato();
            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
            CargarValores();

        }

        private void Titulo()
        {
            this.Text = "INVERSIONES";
        }
        private void Formato()
        {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbInversiones);
            Utilidades.Combo.Formato(cbTipoOperacion);
            Utilidades.Combo.Formato(cbFondos);
            Utilidades.Grilla.Formato(dgvFC);
            dgvFC.AutoGenerateColumns = false;
            dgvFC.Columns["Fecha"].Width = 70;
            dgvFC.Columns["TipoOperacion"].Width = 90;
            dgvFC.Columns["Fondo"].Width = 160;
            dgvFC.Columns["NroReferencia"].Width = 100;
            dgvFC.Columns["Debe"].Width = 110;
            dgvFC.Columns["Haber"].Width = 110;
            dgvFC.Columns["Saldo"].Width = 110;
            dgvFC.Columns["Intereses"].Width = 110;
            dgvFC.Columns["Eliminar"].Width = 60;
        }

        public void CargarValores()
        {
            try
            {
                CargarBancos();
                CargarInversion();
                //CargarTiposMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarBancos()
        {
            Utilidades.Combo.Llenar(cbBancos, objLBanco.ObtenerActivosDeCuentasActivas(), "CodigoBanco", "Banco");
            if (cbBancos.SelectedValue != null)
            {
                objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
            }
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                    CargarFondos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarInversion() {
            Utilidades.Combo.Llenar(cbInversiones, objLTipoInversiones.ObtenerTodos(), "Codigo", "Descripcion");
        }

        private void cbInversiones_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            Utilidades.Combo.Llenar(cbTipoOperacion, CargarDataTable(), "Codigo", "Descripcion", "Todos");
            cbTipoOperacion.SelectedValue = 0;
            CargarFondos();
            dgvFC.DataSource = null;
        }

        private void CargarFondos() {
            if (Convert.ToInt32(cbInversiones.SelectedValue) == 2)
            {
                Utilidades.Combo.Llenar(cbFondos, objLFondos.ObtenerActivos(objEBanco), "Codigo", "Fondo", "Todos");
                cbFondos.SelectedValue = 0;
            }
            else
            {
                cbFondos.DataSource = null;
            }
        }
        private DataTable CargarDataTable() {
            DataTable dtInversiones = new DataTable();
            dtInversiones.Columns.Add("Codigo");
            dtInversiones.Columns.Add("Descripcion");

            if (Convert.ToInt32(cbInversiones.SelectedValue) == 2)
            {
                DataRow row = dtInversiones.NewRow();
                row["Codigo"] = 'S';
                row["Descripcion"] = "Suscripcion";
                dtInversiones.Rows.Add(row);

                row = dtInversiones.NewRow();
                row["Codigo"] = 'R';
                row["Descripcion"] = "Rescate";
                dtInversiones.Rows.Add(row);
            }
            else if (Convert.ToInt32(cbInversiones.SelectedValue) == 1)
            {
                DataRow row = dtInversiones.NewRow();
                row["Codigo"] = 'C';
                row["Descripcion"] = "Creacion";
                dtInversiones.Rows.Add(row);

                row = dtInversiones.NewRow();
                row["Codigo"] = 'V';
                row["Descripcion"] = "Vencimiento";
                dtInversiones.Rows.Add(row);
            }
            

            return dtInversiones;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar() {
            if (Utilidades.Validar.ValidarFechas(dtDesde.Value, dtHasta.Value).Equals(false))
            {
                dgvFC.DataSource = null;
                MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (Convert.ToInt32(cbInversiones.SelectedValue) == 2)
            {
                dgvFC.Visible = true;
                CargarGrillaFondos();
            }
            else if (Convert.ToInt32(cbInversiones.SelectedValue) == 1)
            {
                dgvFC.Visible = false;
            }
        }
        private void CargarGrillaFondos() {
            try
            {
                dtMovimientos = objLInversion.ObtenerFondosComunes(dtDesde.Value.Date, dtHasta.Value.Date, objECuentaBancaria, Convert.ToChar(cbTipoOperacion.SelectedValue), Convert.ToInt32(cbFondos.SelectedValue), cbPendientes.Checked);
                if (dtMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No se registran Movimientos en el periodo indicado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvFC.DataSource = dtMovimientos;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFondos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFC.DataSource = null;
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaBancaria.SelectedIndex != -1)
            {
                try
                {
                    objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                    dgvFC.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvFC.DataSource = null;
        }

        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvFC.DataSource = null;
        }

        private void cbPendientes_CheckedChanged(object sender, EventArgs e)
        {
            dgvFC.DataSource = null;
        }

        private void cbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFC.DataSource = null;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Cargar();
            List<DataTable> lista = new List<DataTable>();
            try
            {
                if (Convert.ToInt32(cbInversiones.SelectedValue) == 2) { 
                    dtMovimientos.TableName = "dsMovimientos";
                    lista.Add(dtMovimientos);
                    lista.Add(new Logica.Empresa().ObtenerDataTable());
                    frmInformes informe;
                    string titulo;
                    informe = new frmInformes("INFORME DE FONDOS COMUNES DE INVERSION BANCO: " + cbBancos.Text, lista, "repFondosComunesDeInversion");
                    titulo = "INFORME DE FONDOS COMUNES DE INVERSION \nBANCO: " + cbBancos.Text + "\nCUENTA BANCARIA: " + cbCuentaBancaria.Text;

                    /*double debe = 0, haber = 0, inter = 0;
                    foreach (DataRow fila in dtMovimientos.Rows)
                    {
                        debe += Convert.ToDouble(fila["Debe"]);
                        haber += Convert.ToDouble(fila["Haber"]);
                        inter += Convert.ToDouble(fila["Intereses"]);
                    }*/
                    double saldo = 0;
                    DataRow sal = dtMovimientos.Rows[dtMovimientos.Rows.Count - 1];
                    saldo = Convert.ToDouble(sal["Total"]);

                    ReportParameter[] parametros = new ReportParameter[2];
                    parametros[0] = new ReportParameter("Titulo", titulo);
                    parametros[1] = new ReportParameter("Saldo", saldo.ToString());
                    informe.reportViewer1.LocalReport.SetParameters(parametros);

                    informe.reportViewer1.RefreshReport();

                    Utilidades.Formularios.AbrirFuera(informe);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFC.Columns[e.ColumnIndex].Name.Equals("Eliminar") && Convert.ToInt32(dgvFC.Rows[e.RowIndex].Cells["Codigo"].Value) > 0) {
                    if (ValidarFechaConciliacionCuenta(objECuentaBancaria, Convert.ToDateTime(dgvFC.Rows[e.RowIndex].Cells["Fecha"].Value)).Equals(false))
                    {
                        MessageBox.Show("No se puede eliminar el Comprobante.\nCuenta de " + objECuentaBancaria.Banco.Descripcion + " Conciliada el " + objECuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    int codigoFondo = Convert.ToInt32(dgvFC.Rows[e.RowIndex].Cells["Codigo"].Value);
                    char codigoTipoOperacion = Convert.ToChar(dgvFC.Rows[e.RowIndex].Cells["CodigoTipoOperacion"].Value);

                    objLInversion.Eliminar(codigoFondo, codigoTipoOperacion);
                    CargarGrillaFondos();
                    MessageBox.Show("Fondo Eliminado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
/*                switch (e.ColumnIndex)
                {
                    case 2:
                        Caja = new Entidades.Caja();
                        Caja.Codigo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells["CodigoPago"].Value);
                        Caja = objLCaja.ObtenerUna(Caja);
                        Utilidades.Formularios.Abrir(this.MdiParent, new frmDevengamientosPagosDetalles(Caja));
                        break;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFechaConciliacionCuenta(Entidades.CuentaBancaria pCuentaBancaria, DateTime pFechaFC)
        {
            if (pFechaFC.Date <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
    }
}
