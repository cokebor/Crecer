using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
	public partial class frmInversiones : Presentacion.frmColor
	{
        Entidades.FondoComunInversion objEFCI = new Entidades.FondoComunInversion();
        List<Entidades.FondoComunInversion> objEFondos = new List<Entidades.FondoComunInversion>();
        Entidades.Inversion objEInversion = new Entidades.Inversion();
        Entidades.Asiento objEAsiento = new Entidades.Asiento();
        double cantidadCuotapartesDisponibles = 0;
        Logica.TipoInversiones objLTipoInversion = new Logica.TipoInversiones();
        Logica.Inversion objLInversion = new Logica.Inversion();
		public frmInversiones()
		{
			InitializeComponent();
            ConfiguracionInicial();
		}



        private void ConfiguracionInicial() {
            Titulo();
            Formato();
            CargarCombo();
            CargarEventos();
            
            
          //  this.ucPlazoFijoConstitucion.txtPlazo.TextChanged += TxtPlazo_TextChanged;
          //  this.ucFondoComunRescate.cbCodigoInversiones.SelectedIndexChanged += CambioFondoComun;
        }

        /*
private void CambioFondoComun(object sender, EventArgs e)
{
   objEInversion = ucFondoComunRescate.ObjEInversion;
   ucFondoComunRescate.txtCapital.Text = objEInversion.CapitalInvertido.ToString();
   txtObservaciones.Text = objEInversion.Observaciones;
   int dias = (dtFecha.Value - objEInversion.FechaInversion).Days;
   ucFondoComunRescate.txtPlazo.Text = dias.ToString();
}*/
        /*
        private void TxtPlazo_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbOperaciones.SelectedValue) == 1 && rbConstitucion.Checked)
            {
                int dias = ucPlazoFijoConstitucion.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoConstitucion.txtPlazo.Text);
                ucPlazoFijoConstitucion.dtFechaVencimiento.Value = dtFecha.Value.AddDays(dias);
            }
        }
        */
        private void CargarEventos() {
            ucFondoComunSuscripcion.cbFondo.SelectedIndexChanged += CargarFondos;
            ucFondoComunSuscripcion.cbCuentaBancaria.SelectedIndexChanged += CargarFondos;
            ucFondoComunSuscripcion.txtImporte.TextChanged += CargarFondos;

            ucPlazoFijoVencimiento.cbCodigoPlazoFijo.SelectedValueChanged += CbCodigoPlazoFijo_SelectedValueChanged;
            ucPlazoFijoConstitucion.txtPlazo.TextChanged += CalcularFechaVencimiento;
            dtFecha.ValueChanged += CalcularFechaVencimiento;
        }

        private void CbCodigoPlazoFijo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                objEInversion = objLInversion.ObtenerUna(Convert.ToInt32(ucPlazoFijoVencimiento.cbCodigoPlazoFijo.SelectedValue));

                ucPlazoFijoVencimiento.txtPlazo.Text = objEInversion.PlazoDias.ToString();
                ucPlazoFijoVencimiento.txtCapital.Text = objEInversion.CapitalInvertido.ToString();
                ucPlazoFijoVencimiento.dtFechaVencimiento.Value = objEInversion.FechaVencimiento;
                ucPlazoFijoVencimiento.txtTNA.Text = objEInversion.TNA.ToString();
                ucPlazoFijoVencimiento.txtInteres.Text = objEInversion.Intereses.ToString();
                txtObservaciones.Text = objEInversion.Observaciones.ToString();
                txtNroReferencia.Text = objEInversion.NroReferencia.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFondos(object sender, EventArgs e)
        {
            try
            {
                Carga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Carga() {
            cantidadCuotapartesDisponibles = 0;
            if (ucFondoComunSuscripcion.cbFondo.SelectedIndex != -1 && rbVencimiento.Checked)
            {
                objEFondos = objLInversion.ObtenerFondosComunesConCuotapartes(Convert.ToInt32(ucFondoComunSuscripcion.cbFondo.SelectedValue), Convert.ToInt32(ucFondoComunSuscripcion.cbCuentaBancaria.SelectedValue));
                foreach (Entidades.FondoComunInversion item in objEFondos)
                {
                    cantidadCuotapartesDisponibles += item.CantCuotapartesRestantes;
                }
            }
          
        }
        private void HabilitacionPaneles() {
            try
            {
              //  rbVencimiento.Visible = true;
                int pTipoInversion = Convert.ToInt32(cbOperaciones.SelectedValue);
                char pOpcion;
                txtObservaciones.Text = "";
                txtNroReferencia.Enabled = true;
                txtNroReferencia.Text = "";

                if (pTipoInversion == 1)
                {
                    rbConstitucion.Text = "Constitución";
                    rbVencimiento.Text = "Vencimiento";
                    //rbVencimiento.Visible = false;
                   
                    ucFondoComunSuscripcion.Visible = false;
                    pOpcion = rbConstitucion.Checked ? 'C' : 'V';
                    if (pOpcion.Equals('C'))
                    {
                        dtFecha.Enabled = true;
                        ucPlazoFijoConstitucion.Visible = true;
                        ucPlazoFijoVencimiento.Visible = false;
                        //txtObservaciones.ReadOnly = false;
                    }
                    else {
                        dtFecha.Enabled = false;
                        ucPlazoFijoConstitucion.Visible = false;
                        ucPlazoFijoVencimiento.Visible = true;
                        txtNroReferencia.Enabled = false;
                        ucPlazoFijoVencimiento.CuentaBancaria();
                        //txtObservaciones.ReadOnly = true;
                    }
                }
                else if(pTipoInversion==2){
                    rbConstitucion.Text = "Suscripción";
                    rbVencimiento.Text = "Rescate";
                    ucPlazoFijoConstitucion.Visible = false;
                    ucPlazoFijoVencimiento.Visible = false;
                    dtFecha.Enabled = true;
                    pOpcion = rbConstitucion.Checked ? 'S' : 'R';
                    if (pOpcion.Equals('S'))
                    {
                        ucFondoComunSuscripcion.Visible = true;

                       // txtObservaciones.ReadOnly = false;
                    }
                    else
                    {
                        ucFondoComunSuscripcion.Visible = true;
                       
                       // txtObservaciones.ReadOnly = true;

                    }
                }
                else{
                    ucPlazoFijoConstitucion.Visible = false;
                    ucPlazoFijoVencimiento.Visible = false;
                    ucFondoComunSuscripcion.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombo() {
            try
            {
                Utilidades.Combo.Llenar(cbOperaciones, objLTipoInversion.ObtenerTodos(), "Codigo", "Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Titulo() {
            this.Text = "INVERSIONES";
        }
        private void Formato() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbOperaciones);
            Utilidades.CajaDeTexto.LimiteTamaño(txtObservaciones,100);
            Utilidades.CajaDeTexto.LimiteTamaño(txtNroReferencia, 15);
        }
        private void CalcularFechaVencimiento(object sender, EventArgs e) {
            if (Convert.ToInt32(cbOperaciones.SelectedValue) == 1 && rbConstitucion.Checked)
            {
                int dias = ucPlazoFijoConstitucion.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoConstitucion.txtPlazo.Text);
                ucPlazoFijoConstitucion.dtFechaVencimiento.Value = dtFecha.Value.AddDays(dias);
            }
        }

        private void cbOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitacionPaneles();
            Limpiar2();
        }

        private void rbConstitucion_CheckedChanged(object sender, EventArgs e)
        {
            HabilitacionPaneles();
        }

        private void rbVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            HabilitacionPaneles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            dtFecha.Value = DateTime.Now.Date;
            Utilidades.Combo.SeleccionarPrimerValor(cbOperaciones);
            rbConstitucion.Checked = true;
            ucFondoComunSuscripcion.Limpiar();
            ucPlazoFijoConstitucion.Limpiar();
            ucPlazoFijoVencimiento.Limpiar();
            txtObservaciones.Text = "";
            txtNroReferencia.Text = "";
        }

        private void Limpiar2()
        {
            //Utilidades.Combo.SeleccionarPrimerValor(cbOperaciones);
            rbConstitucion.Checked = true;
            ucFondoComunSuscripcion.Limpiar();
            ucPlazoFijoConstitucion.Limpiar();
            ucPlazoFijoVencimiento.Limpiar();
            txtObservaciones.Text = "";
            txtNroReferencia.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbOperaciones.SelectedValue) == 1)
                {
                    /*if (rbConstitucion.Checked)
                    {*/
                        CargarValoresPlazoFijo();
                        CargarAsientoInversion();
                    /*}
                    else
                    {
                        CargarValoresPlazoFijo();
                        CargarAsientoFinalizarInversion();
                    }*/

                    if (ValidarFechaConciliacionCuenta(objEFCI.CuentaBancaria).Equals(false))
                    {
                        MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objEFCI.CuentaBancaria.Banco.Descripcion + " Conciliada el " + objEFCI.CuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objLInversion.Agregar(objEInversion, objEAsiento);
                    Limpiar();
                    MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (rbConstitucion.Checked)
                    {
                        CargarValoresSuscripcionFC();
                        CargarAsientoSuscripcionFC();
                        if (ValidarFCISuscripcion().Equals(false))
                        {
                            MessageBox.Show("No se pudo guardar ya que faltan ingresar datos!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {

                        CargarValoresRescateFC();
                        Carga();
                        if (cantidadCuotapartesDisponibles < (-1 * objEFCI.CantCuotapartes))
                        {
                            MessageBox.Show("Cantidad de Cuotapartes a Rescatar no puede ser superior a Cuotapartes Suscriptas", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CargarAsientoRescateFC();
                    }

                    if (ValidarFechaConciliacionCuenta(objEFCI.CuentaBancaria).Equals(false))
                    {
                        MessageBox.Show("No se puede grabar el Comprobante.\nCuenta de " + objEFCI.CuentaBancaria.Banco.Descripcion + " Conciliada el " + objEFCI.CuentaBancaria.FechaConciliacion.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                        

                    if (MessageBox.Show("¿Esta seguro que desea guardar el comprobante?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    objLInversion.Agregar(objEFCI, objEAsiento);
                    Limpiar();
                    Carga();
                    MessageBox.Show("Comprobante creado exitosamente!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
               // objLInversion.Agregar(objEInversion, objEAsiento);
                //Limpiar();
               // 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFechaConciliacionCuenta(Entidades.CuentaBancaria pCuentaBancaria)
        {
            if (dtFecha.Value.Date <= pCuentaBancaria.FechaConciliacion)
                return false;
            else
                return true;
        }
        private bool ValidarFCISuscripcion()
        {
            bool res = false;
            res =  !Utilidades.Validar.ComboBoxSinSeleccionar(ucFondoComunSuscripcion.cbCuentaBancaria);
            res = res && !Utilidades.Validar.ComboBoxSinSeleccionar(ucFondoComunSuscripcion.cbFondo);
            res = res && !Utilidades.Validar.TextBoxEnBlanco(ucFondoComunSuscripcion.txtValorCuotaparte);
            res = res && !Utilidades.Validar.TextBoxEnBlanco(ucFondoComunSuscripcion.txtImporte);
            return res;
        }

        private void CargarValoresPlazoFijo() {
            objEInversion = new Entidades.Inversion();
            objEInversion.TipoInversion.Codigo = Convert.ToInt32(cbOperaciones.SelectedValue);
            objEInversion.NroReferencia = txtNroReferencia.Text.Trim();

            objEInversion.FechaInversion = dtFecha.Value.Date;
            objEInversion.TipoInversion.Descripcion = cbOperaciones.Text;


            if (objEInversion.TipoInversion.Codigo == 1)
            {
                if (rbConstitucion.Checked)
                {
                    objEInversion.Estado = 'C';
                    objEInversion.FechaVencimiento = ucPlazoFijoConstitucion.dtFechaVencimiento.Value;
                    objEInversion.CapitalInvertido = ucPlazoFijoConstitucion.txtCapital.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtCapital.Text);
                    objEInversion.PlazoDias = ucPlazoFijoConstitucion.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoConstitucion.txtPlazo.Text);
                    objEInversion.TNA = ucPlazoFijoConstitucion.txtTNA.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtTNA.Text);
                    objEInversion.Intereses = ucPlazoFijoConstitucion.CalculoInteres();//ucPlazoFijoConstitucion.txtInteres.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtInteres.Text);
                                                                                       //objEInversion.CuentaBancaria.Codigo = Convert.ToInt32(ucPlazoFijoConstitucion.cbCuentaBancaria.SelectedValue);
                    objEInversion.CuentaBancaria = ucPlazoFijoConstitucion.ObjECuantaBancaria;
                }
                else
                {
                    objEInversion.Estado = 'V';
                    objEInversion.Codigo = Convert.ToInt32(ucPlazoFijoVencimiento.cbCodigoPlazoFijo.SelectedValue);
                    objEInversion.FechaVencimiento = ucPlazoFijoVencimiento.dtFechaVencimiento.Value;
                    objEInversion.CapitalInvertido = ucPlazoFijoVencimiento.txtCapital.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoVencimiento.txtCapital.Text);
                    objEInversion.PlazoDias = ucPlazoFijoVencimiento.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoVencimiento.txtPlazo.Text);
                    objEInversion.TNA = ucPlazoFijoVencimiento.txtTNA.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoVencimiento.txtTNA.Text);
                    objEInversion.Intereses = ucPlazoFijoVencimiento.CalculoInteres();//ucPlazoFijoConstitucion.txtInteres.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtInteres.Text);
                                                                                       //objEInversion.CuentaBancaria.Codigo = Convert.ToInt32(ucPlazoFijoConstitucion.cbCuentaBancaria.SelectedValue);
                    objEInversion.CuentaBancaria = ucPlazoFijoVencimiento.ObjECuantaBancaria;
                }

                
            }
            else if (objEInversion.TipoInversion.Codigo == 2)
            {
                objEInversion.Estado = 'S';
                objEInversion.FechaVencimiento = Convert.ToDateTime("01/01/2010");
                objEInversion.CapitalInvertido = ucFondoComunSuscripcion.txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtValorCuotaparte.Text);
                objEInversion.CuentaBancaria = ucFondoComunSuscripcion.ObjECuantaBancaria;
                //objEInversion.CuentaBancaria.Codigo = Convert.ToInt32(ucFondoComunSuscripcion.cbCuentaBancaria.SelectedValue);
            }
            objEInversion.Observaciones = txtObservaciones.Text.Trim();
            objEInversion.Usuario = Singleton.Instancia.Usuario;
        }
       /* private void CargarValoresCrearInversion() {
            objEInversion = new Entidades.Inversion();
            objEInversion.TipoInversion.Codigo = Convert.ToInt32(cbOperaciones.SelectedValue);
            objEInversion.NroReferencia = txtNroReferencia.Text.Trim();
            objEInversion.FechaInversion = dtFecha.Value.Date;
            objEInversion.TipoInversion.Descripcion = cbOperaciones.Text;


            if (objEInversion.TipoInversion.Codigo == 1) {
                objEInversion.Estado = 'C';
                objEInversion.FechaVencimiento = ucPlazoFijoConstitucion.dtFechaVencimiento.Value;
                objEInversion.CapitalInvertido = ucPlazoFijoConstitucion.txtCapital.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtCapital.Text);
                objEInversion.PlazoDias=ucPlazoFijoConstitucion.txtPlazo.Text==""?0: Convert.ToInt32(ucPlazoFijoConstitucion.txtPlazo.Text);
                objEInversion.TNA= ucPlazoFijoConstitucion.txtTNA.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtTNA.Text);
                objEInversion.Intereses = ucPlazoFijoConstitucion.CalculoInteres();//ucPlazoFijoConstitucion.txtInteres.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtInteres.Text);
                //objEInversion.CuentaBancaria.Codigo = Convert.ToInt32(ucPlazoFijoConstitucion.cbCuentaBancaria.SelectedValue);
                objEInversion.CuentaBancaria = ucPlazoFijoConstitucion.ObjECuantaBancaria;
            } else if (objEInversion.TipoInversion.Codigo == 2) {
                objEInversion.Estado = 'S';
                objEInversion.FechaVencimiento = Convert.ToDateTime("01/01/2010");
                objEInversion.CapitalInvertido = ucFondoComunSuscripcion.txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtValorCuotaparte.Text);
                objEInversion.CuentaBancaria = ucFondoComunSuscripcion.ObjECuantaBancaria;
                //objEInversion.CuentaBancaria.Codigo = Convert.ToInt32(ucFondoComunSuscripcion.cbCuentaBancaria.SelectedValue);
            }
            objEInversion.Observaciones = txtObservaciones.Text.Trim();
            objEInversion.Usuario = Singleton.Instancia.Usuario;
        }*/
        private void CargarValoresSuscripcionFC()
        {
            objEFCI = new Entidades.FondoComunInversion();

            objEFCI.Fecha = dtFecha.Value.Date;
            objEFCI.Fondo.Codigo = Convert.ToInt32(ucFondoComunSuscripcion.cbFondo.SelectedValue);
            objEFCI.CodigoTipoOperacion = 'S';
            objEFCI.CuentaBancaria = ucFondoComunSuscripcion.ObjECuantaBancaria;
            objEFCI.CantCuotapartes = ucFondoComunSuscripcion.txtCantCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtCantCuotaparte.Text);
            objEFCI.CantCuotapartesRestantes = objEFCI.CantCuotapartes;
            objEFCI.ValorCuotaparte= ucFondoComunSuscripcion.txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtValorCuotaparte.Text);
            objEFCI.NroReferencia = txtNroReferencia.Text.Trim();
            objEFCI.Importe = ucFondoComunSuscripcion.txtImporte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtImporte.Text);
            objEFCI.Observaciones = txtObservaciones.Text.Trim();
            objEFCI.Usuario = Singleton.Instancia.Usuario;

            /*
            objEInversion.TipoInversion.Descripcion = cbOperaciones.Text;


            if (objEInversion.TipoInversion.Codigo == 1)
            {
                objEInversion.Estado = 'C';
                objEInversion.FechaVencimiento = ucPlazoFijoConstitucion.dtFechaVencimiento.Value;
                objEInversion.CapitalInvertido = ucPlazoFijoConstitucion.txtCapital.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtCapital.Text);
                objEInversion.PlazoDias = ucPlazoFijoConstitucion.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoConstitucion.txtPlazo.Text);
                objEInversion.TNA = ucPlazoFijoConstitucion.txtTNA.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoConstitucion.txtTNA.Text);
                objEInversion.Intereses = ucPlazoFijoConstitucion.CalculoInteres();
                
                objEInversion.CuentaBancaria = ucPlazoFijoConstitucion.ObjECuantaBancaria;
            }
            else if (objEInversion.TipoInversion.Codigo == 2)
            {
                
                objEInversion.FechaVencimiento = Convert.ToDateTime("01/01/2010");
                objEInversion.CapitalInvertido = ucFondoComunSuscripcion.txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtValorCuotaparte.Text);
                objEInversion.CuentaBancaria = ucFondoComunSuscripcion.ObjECuantaBancaria;
            }
           */ 
        }

        private void CargarValoresRescateFC()
        {
            objEFCI = new Entidades.FondoComunInversion();

            objEFCI.Fecha = dtFecha.Value.Date;
            objEFCI.Fondo.Codigo = Convert.ToInt32(ucFondoComunSuscripcion.cbFondo.SelectedValue);
            objEFCI.CodigoTipoOperacion = 'R';
            objEFCI.CuentaBancaria = ucFondoComunSuscripcion.ObjECuantaBancaria;
            objEFCI.CantCuotapartes = ucFondoComunSuscripcion.txtCantCuotaparte.Text == "" ? 0 : -Convert.ToDouble(ucFondoComunSuscripcion.txtCantCuotaparte.Text);
            objEFCI.CantCuotapartesRestantes = 0;
            objEFCI.ValorCuotaparte = ucFondoComunSuscripcion.txtValorCuotaparte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtValorCuotaparte.Text);
            objEFCI.Importe = ucFondoComunSuscripcion.txtImporte.Text == "" ? 0 : Convert.ToDouble(ucFondoComunSuscripcion.txtImporte.Text);
            objEFCI.Observaciones = txtObservaciones.Text.Trim();
            objEFCI.NroReferencia = txtNroReferencia.Text.Trim();
            objEFCI.Usuario = Singleton.Instancia.Usuario;


      
                double restante = -objEFCI.CantCuotapartes;
                foreach (Entidades.FondoComunInversion item in objEFondos)
                {
                    Entidades.FondoComunInversion objEFondoC = new Entidades.FondoComunInversion();
                    objEFondoC.Codigo = item.Codigo;
                /*if (item.CantCuotapartesRestantes == 0)
                    continue;*/
                    double cal = item.CantCuotapartesRestantes- restante;
                    if (restante > 0)
                    {
                        if (cal < 0)
                        {
                            objEFondoC.CantCuotapartesRestantes = 0;
                            objEFondoC.CantCuotapartes = item.CantCuotapartesRestantes;
                            objEFondoC.ValorCuotaparte = item.ValorCuotaparte;
                            restante = -cal;
                            objEFCI.Fondos.Add(objEFondoC);
                        }
                        else
                        {
                            objEFondoC.CantCuotapartesRestantes = cal;
                            objEFondoC.CantCuotapartes = restante;
                            objEFondoC.ValorCuotaparte = item.ValorCuotaparte;
                            restante = 0;
                            objEFCI.Fondos.Add(objEFondoC);
                        }
                    }
                    else {
                        break;
                    }
                
            }
            
        }
        private void CargarAsientoSuscripcionFC()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFCI.Fecha;
            objEAsiento.FechaEmision = objEFCI.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            if (rbConstitucion.Checked)
                objEAsiento.Descripcion = rbConstitucion.Text + " " + cbOperaciones.Text;
            else
                objEAsiento.Descripcion = rbVencimiento.Text + " " + cbOperaciones.Text;

            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable.Codigo = 10103010000;
             
            asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEFCI.Importe);
            asientoDetalle.Haber = 0;

            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable = objEFCI.CuentaBancaria.CuentaContable;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = objEFCI.Importe;

            objEAsiento.Detalle.Add(asientoDetalle);
        }

        private void CargarAsientoRescateFC()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEFCI.Fecha;
            objEAsiento.FechaEmision = objEFCI.Fecha;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            if (rbConstitucion.Checked)
                objEAsiento.Descripcion = rbConstitucion.Text + " " + cbOperaciones.Text;
            else
                objEAsiento.Descripcion = rbVencimiento.Text + " " + cbOperaciones.Text;

            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable = objEFCI.CuentaBancaria.CuentaContable;//objEInversion.CuentaBancaria.CuentaContable;

            asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEFCI.Importe);
            asientoDetalle.Haber = 0;

            objEAsiento.Detalle.Add(asientoDetalle);

            double capitalInvertido=0, capitalRescatado=0;
            foreach (Entidades.FondoComunInversion item in objEFCI.Fondos)
            {
                capitalInvertido += Utilidades.Redondear.DosDecimales(item.CantCuotapartes * item.ValorCuotaparte);
                capitalRescatado += Utilidades.Redondear.DosDecimales(item.CantCuotapartes * objEFCI.ValorCuotaparte);
            }


            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable.Codigo = 10103010000;
            asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(capitalInvertido);
            asientoDetalle.Debe = 0;

            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable.Codigo = 40102030100;
            asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(capitalRescatado-capitalInvertido);
            asientoDetalle.Debe = 0;

            objEAsiento.Detalle.Add(asientoDetalle);
        }
        /*private void CargarValoresFinalizarInversion() {
            objEInversion = new Entidades.Inversion();
            //objEInversion.TipoInversion.Codigo = Convert.ToInt32(cbOperaciones.SelectedValue);
            //objEInversion.TipoInversion.Descripcion = cbOperaciones.Text;
            //objEInversion.NroReferencia = txtNroReferencia.Text.Trim();

            if (objEInversion.TipoInversion.Codigo == 1)
            {
                objEInversion.Codigo=Convert.ToInt32(ucPlazoFijoVencimiento.cbCodigoPlazoFijo.SelectedValue);
                objEInversion.CuentaBancaria = ucPlazoFijoVencimiento.ObjECuantaBancaria;
                
               // objEInversion.FechaInversion = DateTime.Now;
                objEInversion.FechaVencimiento = ucPlazoFijoVencimiento.dtFechaVencimiento.Value;
                objEInversion.Estado = 'V';
                objEInversion.PlazoDias = ucPlazoFijoVencimiento.txtPlazo.Text == "" ? 0 : Convert.ToInt32(ucPlazoFijoVencimiento.txtPlazo.Text);
                objEInversion.TNA=ucPlazoFijoVencimiento.txtTNA.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoVencimiento.txtTNA.Text);
                objEInversion.Intereses = ucPlazoFijoVencimiento.CalculoInteres();//.txtInteres.Text == "" ? 0 : Convert.ToDouble(ucPlazoFijoVencimiento.txtInteres.Text);
            }

            objEInversion.Observaciones = txtObservaciones.Text.Trim();
            objEInversion.Usuario = Singleton.Instancia.Usuario;
        }*/

        private void CargarAsientoInversion()
        {
            objEAsiento = new Entidades.Asiento();
            
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            if (rbConstitucion.Checked) { 
                objEAsiento.Fecha = objEInversion.FechaInversion;
                objEAsiento.FechaEmision = objEInversion.FechaInversion;
            objEAsiento.Descripcion = rbConstitucion.Text + " " + objEInversion.TipoInversion.Descripcion;
            }
            else {
                objEAsiento.Fecha = objEInversion.FechaVencimiento;
                objEAsiento.FechaEmision = objEInversion.FechaVencimiento;
                objEAsiento.Descripcion = rbVencimiento.Text + " " + objEInversion.TipoInversion.Descripcion;

            }

            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();

            /*if (objEInversion.Estado.Equals('C'))
            {*/
                asientoDetalle.CuentaContable.Codigo = 10103020000;
            //}
            /*else if (objEInversion.Estado.Equals('S'))
            {
                asientoDetalle.CuentaContable.Codigo = 10103010000;
            }*/
            if (objEInversion.Estado.Equals('C'))
            {
                asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido + objEInversion.Intereses);
                asientoDetalle.Haber = 0;
            }
            else {
                asientoDetalle.Debe = 0; 
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido + objEInversion.Intereses);
            }
            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable = objEInversion.CuentaBancaria.CuentaContable;
            if (objEInversion.Estado.Equals('C'))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido);
            }
            else {
                asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido + objEInversion.Intereses);
                asientoDetalle.Haber = 0;
            }
            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 10103030000;

            if (objEInversion.Estado.Equals('C'))
            {
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.Intereses);
            }
            else {
                asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEInversion.Intereses);
                asientoDetalle.Haber = 0;
            }

            objEAsiento.Detalle.Add(asientoDetalle);

            if (objEInversion.Estado.Equals('V'))
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 40102030100;
                asientoDetalle.Debe = 0;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.Intereses);
                objEAsiento.Detalle.Add(asientoDetalle);
            }
            


        }

     /*   private void CargarAsientoFinalizarInversion()
        {
            objEAsiento = new Entidades.Asiento();
            objEAsiento.Fecha = objEInversion.FechaInversion;
            objEAsiento.FechaEmision = objEInversion.FechaInversion;
            objEAsiento.Sucursal = Singleton.Instancia.Empresa.Codigo;
            if (rbConstitucion.Checked)
                objEAsiento.Descripcion = rbConstitucion.Text + " " + objEInversion.TipoInversion.Descripcion;
            else
                objEAsiento.Descripcion = rbVencimiento.Text + " " + objEInversion.TipoInversion.Descripcion;


            Entidades.Asiento_Detalle asientoDetalle;

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable = objEInversion.CuentaBancaria.CuentaContable;
            asientoDetalle.Debe = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido +objEInversion.Intereses);
            asientoDetalle.Haber = 0;

            objEAsiento.Detalle.Add(asientoDetalle);

            asientoDetalle = new Entidades.Asiento_Detalle();

            asientoDetalle.CuentaContable.Codigo = 10103020000;
            asientoDetalle.Debe = 0; 
            asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido + objEInversion.Intereses);

            objEAsiento.Detalle.Add(asientoDetalle);



            if (objEInversion.Estado.Equals('V'))
            {
                asientoDetalle = new Entidades.Asiento_Detalle();
                asientoDetalle.CuentaContable.Codigo = 10103030000;
                asientoDetalle.Debe = objEInversion.Intereses;
                asientoDetalle.Haber = 0;
                objEAsiento.Detalle.Add(asientoDetalle);
            }

            asientoDetalle = new Entidades.Asiento_Detalle();

/*            if (objEInversion.Estado.Equals('V'))
            {
                asientoDetalle.CuentaContable.Codigo = 10103020000;
                
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido + objEInversion.Intereses);
            }
            else if (objEInversion.Estado.Equals('R'))
            {
                asientoDetalle.CuentaContable.Codigo = 10103010000;
                asientoDetalle.Haber = Utilidades.Redondear.DosDecimales(objEInversion.CapitalInvertido);
            }
            
            asientoDetalle.Debe = 0;

            objEAsiento.Detalle.Add(asientoDetalle);
            
            asientoDetalle = new Entidades.Asiento_Detalle();
            asientoDetalle.CuentaContable.Codigo = 40102030100;
            asientoDetalle.Debe = 0;
            asientoDetalle.Haber = objEInversion.Intereses;
            objEAsiento.Detalle.Add(asientoDetalle);


        }*/
        //string busqueda = "";
        private void frmInversiones_Activated(object sender, EventArgs e)
        {
            if (ucFondoComunSuscripcion.busqueda.Equals("Fondos"))
                ucFondoComunSuscripcion.CargarFondos();
            
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
