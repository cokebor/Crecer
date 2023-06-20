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
    public partial class frmMovimientosBancariosInforme : Form//: Presentacion.frmColor
    {
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.TipoMovimientoBancario objLTipoMovimientoBancario = new Logica.TipoMovimientoBancario();

        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.TipoMovimientoBancario objETipoMovimientoBancario = new Entidades.TipoMovimientoBancario();
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        public frmMovimientosBancariosInforme()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial() {
            Titulo();
            Formato();
            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
            CargarValores();
        }
        private void Titulo() {
            this.Text = "MOVIMIENTOS BANCARIOS";
        }
        private void Formato() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbBancos);
            Utilidades.Combo.Formato(cbCuentaBancaria);
            Utilidades.Combo.Formato(cbMovimientos);
            Utilidades.Reporte.Formato(rvInforme, true);
        }

        public void CargarValores()
        {
            try
            {
                CargarBancos();
                CargarTiposMovimientos();
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

        public void CargarTiposMovimientos()
        {
            Utilidades.Combo.Llenar(cbMovimientos, objLTipoMovimientoBancario.ObtenerTodos(), "Codigo", "Descripcion","Todos");
            cbMovimientos.SelectedValue = 0;
        }
        private void Listar(int pCuenta, int pTipo, DateTime pDesde, DateTime pHasta) {
            // TODO: esta línea de código carga datos en la tabla 'dsFrutar.SP_MOVIMIENTOSBANCARIOS_SELECT' Puede moverla o quitarla según sea necesario.
            this.SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter.Fill(this.dsFrutar.SP_MOVIMIENTOSBANCARIOS_SELECT, pCuenta, pTipo, pDesde, pHasta);
            ReportParameter paramBanco = new ReportParameter("Banco", cbBancos.Text);
            ReportParameter paramCuenta = new ReportParameter("CuentaBancaria", cbCuentaBancaria.Text);
            ReportParameter paramTipo = new ReportParameter("TipoMovimiento", cbMovimientos.Text);
            ReportParameter paramDesde = new ReportParameter("FechaDesde", dtDesde.Value.ToString());
            ReportParameter paramHasta = new ReportParameter("FechaHasta", dtHasta.Value.ToString());
            rvInforme.LocalReport.SetParameters(new ReportParameter[] { paramBanco, paramCuenta, paramTipo, paramDesde, paramHasta });
            this.rvInforme.RefreshReport();
        }
        private void Limpiar() {
            Utilidades.Combo.SeleccionarPrimerValor(cbBancos);
            Utilidades.Combo.SeleccionarPrimerValor(cbCuentaBancaria);
            Utilidades.Combo.SeleccionarPrimerValor(cbMovimientos);

            dtDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtHasta.Value = DateTime.Now;
        }

        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBancos.SelectedIndex != -1)
            {
                try
                {
                    objEBanco = objLBanco.ObtenerUno(Convert.ToInt32(cbBancos.SelectedValue));
                    Utilidades.Combo.Llenar(cbCuentaBancaria, objLCuentaBancaria.ObtenerDeBancos(objEBanco), "Codigo", "NumeroCuenta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void cbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMovimientos.SelectedIndex != -1)
            {
                try
                {
                    objETipoMovimientoBancario = objLTipoMovimientoBancario.ObtenerUno(Convert.ToInt32(cbMovimientos.SelectedValue));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void cbCuentaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuentaBancaria.SelectedIndex != -1)
            {
                try
                {
                    objECuentaBancaria = objLCuentaBancaria.ObtenerUno(Convert.ToInt32(cbCuentaBancaria.SelectedValue));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.rvInforme.LocalReport.ReportEmbeddedResource = "";
            this.rvInforme.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilidades.Validar.ValidarFechas(dtDesde.Value, dtHasta.Value).Equals(false))
                {
                    this.rvInforme.LocalReport.ReportEmbeddedResource = "";
                    this.rvInforme.RefreshReport();
                    MessageBox.Show("Fecha Hasta no puede ser inferior a Desde", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else {
                    this.rvInforme.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repMovimientosBancarios.rdlc";
                    Listar(objECuentaBancaria.Codigo, objETipoMovimientoBancario.Codigo, dtDesde.Value, dtHasta.Value);
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
