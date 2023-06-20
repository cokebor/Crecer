using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPrincipal : frmColor
    {
        //  System.Diagnostics.Process proceso = new System.Diagnostics.Process();
        Logica.Permiso objLogicaPermiso = new Logica.Permiso();
        List<DataTable> lista;
        public frmPrincipal()
        {
            InitializeComponent();

            Cargar();
        }

        private void Cargar()
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    if (proceso.ProcessName.Equals("Novedades"))
            //       proceso.Kill();
            try
            {
                /* if (enviarYRecibirInformaciónToolStripMenuItem.Checked == true)
                     if (Singleton.Instancia.Empresa.Codigo == 7)
                         Utilidades.Procesos.Detener("Novedades2");
                     else
                         Utilidades.Procesos.Detener("Novedades");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }


        }



        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Utilidades.Formularios.Abrir(this, new frmPais());
        }


        private void comunicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmComunicacion());
        }

        private void gruposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmGrupoDeUsuario());
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProvincia());
        }

        private void localidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLocalidad());
        }


        //frmNovedades novedad = null;

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                tstEmpleado.Text = Singleton.Instancia.Usuario.Apellido + ", " + Singleton.Instancia.Usuario.Nombre;
                tssUsuario.Text = " Usuario: " + Singleton.Instancia.Usuario.NombreUsuario;
                tssGrupo.Text = " Grupo: " + Singleton.Instancia.Usuario.GrupoDeUsuario.Descripcion;
                tssCaja.Text = " Puesto: " + Singleton.Instancia.Puesto.Descripcion;


                DataTable dtPermisos = objLogicaPermiso.ObtenerTodos(Convert.ToInt32(Singleton.Instancia.Usuario.GrupoDeUsuario.Codigo));

                Utilidades.Permisos.Deshabilitar(menuStrip1);

                Utilidades.Permisos.HabilitarVer(dtPermisos, menuStrip1, btn1);



                if (Singleton.Instancia.Empresa.Codigo == 1)
                {
                    informeIvaVentasToolStripMenuItem.Visible = true;
                }

                MdiClient ctlMDI;
                foreach (Control ctl in Controls)
                {
                    try
                    {
                        ctlMDI = (MdiClient)ctl;
                        ctlMDI.BackColor = Color.FromArgb(Convert.ToInt32(Singleton.Instancia.Usuario.ColorFormularioMDI));//Color.DarkSlateGray;
                    }
                    catch (Exception)
                    {
                    }

                }
                if (Singleton.Instancia.Empresa.Convenio)
                    porAjusteDePrecioEnLotesToolStripMenuItem.Text = "Por Ajuste de Precio por Convenios";

                //if (Singleton.Instancia.Empresa.Codigo == 1)// || Singleton.Instancia.Empresa.Codigo == 3 || Singleton.Instancia.Empresa.Codigo == 4 || Singleton.Instancia.Empresa.Codigo == 5 || Singleton.Instancia.Empresa.Codigo == 7)

                switch (Singleton.Instancia.Empresa.Codigo)
                {
                    case 1:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_Deposito;
                        break;
                    case 2:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_Nave_3;
                        break;
                    case 3:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_Nave_7;
                        break;
                    case 4:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_VM;
                        break;
                    case 5:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_rIO_cUARTO;
                        break;
                    case 7:
                        this.BackgroundImage = Properties.Resources.Winay_Logo_Sucursal_6;
                        break;
                }


                /*else if (Singleton.Instancia.Empresa.Codigo == 2)
                     this.BackgroundImage = Properties.Resources.LogoWiki;*/

                BackgroundImageLayout = ImageLayout.Center;
                //   Novedades.frmNovedades nov= new Novedades.frmNovedades(this);
                //  Utilidades.Formularios.AbrirFueraHide(nov);
                /*
                if (Singleton.Instancia.Empresa.Codigo != 7)
                    Utilidades.Procesos.Iniciar("Novedades");
                if (Singleton.Instancia.Empresa.Codigo == 7)
                    Utilidades.Procesos.Iniciar("Novedades2");*/
                //           


                if (!File.Exists(@"Novedades.ini")) {
                    File.Create(@"Novedades.ini");
                }

                string nov ="";
                using (StreamReader sr = new StreamReader(@"Novedades.ini"))
                {
                    nov = sr.ReadToEnd();
                }
                if (nov.Equals("SI"))
                {
                    timer.Enabled = true;
                    this.enviarYRecibirInformaciónToolStripMenuItem.Checked = true;
                }
                else {
                    timer.Enabled = false;
                    this.enviarYRecibirInformaciónToolStripMenuItem.Checked = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmUsuario());
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCambioClave cambio = new frmCambioClave();
            //cambio.Usuario = tssUsuario.Text;
            Utilidades.Formularios.Abrir(this, new frmCambioClave());
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                /*    if (enviarYRecibirInformaciónToolStripMenuItem.Checked == true)
                        if (Singleton.Instancia.Empresa.Codigo == 7)
                            Utilidades.Procesos.Detener("Novedades2");
                        else
                            Utilidades.Procesos.Detener("Novedades");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }


            Application.Exit();
        }

        private void gruposDeUsuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmGrupoDeUsuario());
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPermisos permisos = new frmPermisos();
            //permisos.CodigoGrupoUsuario = Convert.ToInt32(tssCodigoGrupo.Text);
            Utilidades.Formularios.Abrir(this, new frmPermisos(Convert.ToInt32(Singleton.Instancia.Usuario.GrupoDeUsuario.Codigo)));
        }

        private void cerrarSesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /* if (enviarYRecibirInformaciónToolStripMenuItem.Checked == true)
                 {
                     if (Singleton.Instancia.Empresa.Codigo == 7)
                         Utilidades.Procesos.Detener("Novedades2");
                     else
                         Utilidades.Procesos.Detener("Novedades");
                     // Utilidades.Procesos.Detener("Novedades");
                     enviarYRecibirInformaciónToolStripMenuItem.Checked = false;
                 }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Restart();
            }
        }

        private void rubrosDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRubroProducto());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProducto());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProveedor());
        }


        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCliente());
        }

        private void tipoDocumentoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmTipoDocumentoCliente());
        }

        private void numeradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNumerador());
        }

        private void monedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMoneda());
        }

        private void cuentasContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCuentaContable());
        }

        private void enviarYRecibirInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (enviarYRecibirInformaciónToolStripMenuItem.Checked)
            {
                timer.Enabled = false;
                enviarYRecibirInformaciónToolStripMenuItem.Checked = false;
                // backgroundWorker.ReportProgress(0);
                /*if (Singleton.Instancia.Empresa.Codigo == 7)
                    Utilidades.Procesos.Detener("Novedades2");
                else
                    Utilidades.Procesos.Detener("Novedades");*/
            }
            else
            {
                /*if (Singleton.Instancia.Empresa.Codigo == 7)
                    Utilidades.Procesos.Iniciar("Novedades2");
                else
                    Utilidades.Procesos.Iniciar("Novedades");
                    */
                timer.Enabled = true;
                enviarYRecibirInformaciónToolStripMenuItem.Checked = true;
            }
        }
        private void generarBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //FolderBrowserDialog dlg = new FolderBrowserDialog();


                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                Logica.Backup backup = new Logica.Backup();
                string nombreBase = backup.ObtenerNombre();
                string direccion = System.Windows.Forms.Application.StartupPath + @"\Backups\" + nombreBase + "-" + DateTime.Now.ToString("yyyy-MM-dd HH-mm" + ".bak");
                //backup.CrearBackups2(nombreBase, direccion);
                backup.CrearBackups2(nombreBase, direccion);

                FileInfo archivo = new FileInfo(direccion);
                Utilidades.ComprimirYExtraer.Compresion(archivo, Singleton.Instancia.Empresa.DireccionBackup);
                MessageBox.Show("Backup realizado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                /* if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Logica.Backup backup = new Logica.Backup();
                    string nombreBase = backup.ObtenerNombre();
                    string direccion = System.Windows.Forms.Application.StartupPath + @"\Backups\" + nombreBase + "-" + DateTime.Now.ToString("yyyy-MM-dd hh-mm" + ".bak");
                    backup.CrearBackups2(nombreBase, direccion);

                    FileInfo archivo = new FileInfo(direccion);
                    Utilidades.ComprimirYExtraer.Compresion(archivo, dlg.SelectedPath);
                    MessageBox.Show("Backup realizado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
                /*
                if (dlg.ShowDialog() == DialogResult.OK) {
                 Logica.Backup backup = new Logica.Backup();
                 string archivo=backup.CrearBackups(System.Windows.Forms.Application.StartupPath + @"\Backups");


                 FileInfo archivo2 = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\Backups\" + archivo);
                 Utilidades.ComprimirYExtraer.Compresion(archivo2, dlg.SelectedPath);
                 MessageBox.Show("Backup realizado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ejerciciosEconomicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmEjercicios());
        }

        Logica.AsientoTemp objLogicaAsientoTemp = new Logica.AsientoTemp();
        Logica.Asiento objLAsiento = new Logica.Asiento();


        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmImpuestos());
        }


        private void tiposDeDocumentosDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmTipoDocumentoProveedor());
        }

        private void obrasSocialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmObraSocial());
        }

        private void puestosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPuestos());
        }

        private void empleadosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmEmpleado());
        }


        private void remitosDeProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoProveedor());
        }

        private void remitosDeClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoCliente());
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void comprobantesDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmFactura());
        }

        private void fACTURASDECOMPRASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmFacturaCompra());
        }

        private void listadoDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lista = new List<DataTable>();
                lista.Add(new Logica.Empleado().ObtenerActivosEmpleados());
                frmInformes informe = new frmInformes("LISTADO DE EMPLEADOS", lista, "repEmpleados");
                Utilidades.Formularios.AbrirFuera(informe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }
        private void bancosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmBancos());
        }

        private void cuentasBancariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCuentaBancaria());
        }

        private void comprobantesDeVentasManualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmFacturaManual());
        }

        private void listadoDeProductosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                /*lista = new List<DataTable>();
                lista.Add(new Logica.Producto().ObtenerActivos());
                lista.Add(new Logica.Empresa().ObtenerDataTable());
                Utilidades.Formularios.AbrirFuera(new frmInformes("LISTADO DE PRODUCTOS", lista, "repProductos"));*/
                Utilidades.Formularios.Abrir(this, new frmSalidas());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmProveedoresPagos());
            //Utilidades.Formularios.Abrir(this, new frmProveedoresPago());
            Utilidades.Formularios.Abrir(this, new frmProveedoresPagos());
        }

        private void anularComprobantesManualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAnulacionFacturaManual());
        }

        private void porStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNC());
        }

        private void porAjusteDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNCAjuste());
        }


        private void liquidaciínDeRemitosDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionRemitoCliente());
        }

        private void liquidaciónDeRemitosDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmLiquidacionRemitoProveedor());
            if (Singleton.Instancia.Empresa.Codigo == 1)
                Utilidades.Formularios.Abrir(this, new frmLiquidacionRemitoProveedorDeposito());
            //Utilidades.Formularios.Abrir(this, new frmLiquidacionRemitoProveedor());
            else
                Utilidades.Formularios.Abrir(this, new frmLiquidacionRemitoProveedor());
        }

        private void pagosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmClientesPagos());
            //Utilidades.Formularios.Abrir(this, new frmClientePagos());
        }

        private void ventaPorProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmVentaPorProductoInformeFiltro());
        }

        private void informeDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmComprobantesDeVenta());
        }

        private void cargarSaldoInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSaldoInicialCliente());
        }

        private void consultaDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmStock());
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCliente());
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProveedor());
        }

        private void listadoDeProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                lista = new List<DataTable>();
                lista.Add(new Logica.Proveedor().ObtenerActivos());
                Utilidades.Formularios.AbrirFuera(new frmInformes("LISTADO DE PROVEEDORES", lista, "repProveedores"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void informeDeRemitosDeProveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoProveedorInformeFiltro());
        }

        private void informeDeRemitosDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoClienteInforme());
        }

        private void listadoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lista = new List<DataTable>();
                lista.Add(new Logica.Cliente().ObtenerActivos());
                Utilidades.Formularios.AbrirFuera(new frmInformes("LISTADO DE CLIENTES", lista, "repClientes"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void informeDeSaldosDeCuentasCorrientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmClienteCuentaCorriente());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSaldoInicialProveedor());
        }

        private void informeDeSaldosDeCuentasCorrientesDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProveedorCuentaCorriente());
        }

        private void anulaciónDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAnulacionFacturaCompra());
        }

        private void informeDeVentasPorProductoDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmVentaPorProductoDetalladoInformeFiltro());
        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.Asiento objLAsiento = new Logica.Asiento();

                if (Singleton.Instancia.Usuario.Codigo == 1)
                {
                    if (MessageBox.Show("¿Desea solucionar problemas de Agrupacion de Asientos Contables?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //int final = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Cierre de Caja Final: ", "", "100", 100, 0));
                        int final = new Logica.CierreCaja().ObtenerCantidadCajas();
                        objLAsiento.BorrarAsientosAgrupados();
                        for (int i = 1; i <= final; i++)
                        {

                            Entidades.CierreDeCaja objECierre = new Entidades.CierreDeCaja();
                            objECierre.Codigo = i;
                            objECierre = new Logica.CierreCaja().ObtenerUno(objECierre);
                            objLAsiento.Agrupar(objECierre.FechaCierreCaja, i, Singleton.Instancia.Puesto, Singleton.Instancia.Empresa);
                        }
                        MessageBox.Show("Finalizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CerrarCaja();
                    }
                }
                else
                {
                    CerrarCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CerrarCaja()
        {
            if (MessageBox.Show("¿Esta seguro que desea Cerrar Caja?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Entidades.CierreDeCaja objCierreCaja = new Entidades.CierreDeCaja();
            objCierreCaja.FechaCierreCaja = DateTime.Now;
            objCierreCaja.PuestoCaja = Singleton.Instancia.Puesto;
            objCierreCaja.Usuario = Singleton.Instancia.Usuario;

            double importe = new Logica.Movimiento().ObtenerMontoEfectivoSinCierre(Singleton.Instancia.Puesto, 1);
            if (importe != 0 && Singleton.Instancia.Empresa.Codigo != 1)
                if (MessageBox.Show("La Caja tiene " + importe.ToString("C") + " Desea realizar un Egreso de Caja??", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Utilidades.Formularios.Abrir(this, new frmEgresosCaja());
                    return;
                }



            int CierreCaja = new Logica.CierreCaja().Agregar(objCierreCaja);

            objLAsiento = new Logica.Asiento();
            objLAsiento.Agrupar(DateTime.Now, CierreCaja, Singleton.Instancia.Puesto, Singleton.Instancia.Empresa);


            MessageBox.Show("Cierre de Caja N° " + CierreCaja + " creado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Utilidades.Formularios.Abrir(this, new frmClienteBuscar("MovimientosCuentaCorriente", this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void movimientosCuentaCorrienteProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Utilidades.Formularios.Abrir(this, new frmProveedorBuscar("MovimientosCuentaCorriente", this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void recibirBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Datos\Dropbox";
            //ofd.Filter = "Archivos de Backup (*.bak)|" + Application.ProductName + "_*.bak";
            ofd.Filter = "Archivos de Backup (*.rar)|" + Application.ProductName + "_*.rar";
            ofd.RestoreDirectory = true;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //       MessageBox.Show(ofd.FileName);
                            Logica.Backup backup = new Logica.Backup();

                            FileInfo fileI = new FileInfo(ofd.FileName);

                            string archivo = Utilidades.ComprimirYExtraer.Descomprimir(fileI);

                            //backup.Restaurar(ofd.SafeFileName.Substring(0, ofd.SafeFileName.Length - 21), ofd.FileName);
                            backup.Restaurar(ofd.SafeFileName.Substring(0, ofd.SafeFileName.Length - 25), archivo);
                            Directory.CreateDirectory(@"D:\Bases de Datos 2012");
                            int codigoPuesto = Convert.ToInt32(ofd.SafeFileName.Substring(7, 1));
                            string nombreArchivo = ofd.SafeFileName.Substring(9, 16);

                            backup.Agregar(codigoPuesto, nombreArchivo);

                            MessageBox.Show("Backup Restaurado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            File.Delete(archivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void distribuciónDeGuíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoSucursal());
        }

        private void informeDeEnviosDeMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoSucursalInformeFiltro());
        }

        private void mermasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMermas());
        }

        private void informeDeVentasPorLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmVentasPorLote());
        }

        private void integraciónDeDatosTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmIntegracion());
        }

        private void informeDeMermasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMermasInforme());
        }

        private void tiposMovimientosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmTiposMovimientosBancarios());
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasInicialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSaldoInicialVentas());
        }

        private void saldoInicialCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSaldoInicialCaja());
        }

        private void movimientosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMovimientosBancarios());
            //Utilidades.Formularios.Abrir(this, new frmCambioDeCheques());
        }

        private void egresoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmEgresosCaja());

        }

        private void porAjusteDePrecioEnLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNCLotes());
        }

        private void listadoDeCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rendiciónDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRendicionCaja());
        }

        private void informeDeRemitosDeClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitoClienteInformeFiltro());
        }

        private void imputaciónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmImputacionClientes());
        }

        private void informeDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesClientesPendientes());
        }

        private void informeDeRemitosDeProveedoresPendientesDeLiquidarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Informe de Remitos de Proveedores Pendientes de Liquidar
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesProveedorInformeFiltro());
        }

        private void generarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // FolderBrowserDialog dlg = new FolderBrowserDialog();


                // if (dlg.ShowDialog() == DialogResult.OK)
                // {
                Logica.Backup backup = new Logica.Backup();
                string nombreBase = backup.ObtenerNombre();
                string direccion = System.Windows.Forms.Application.StartupPath + @"\Backups\" + nombreBase + "-" + DateTime.Now.ToString("yyyy-MM-dd HH-mm" + ".bak");
                //backup.CrearBackups2(nombreBase, direccion);
                Logica.Movimiento objLMovimiento = new Logica.Movimiento();
                if (objLMovimiento.ObtenerCantidadDeMovimientos() > 0)
                {
                    MessageBox.Show("No se puede realizar el Backup debido a que existen movimientos sin cierre de Caja", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                backup.CrearBackups2(nombreBase, direccion);

                FileInfo archivo = new FileInfo(direccion);
                Utilidades.ComprimirYExtraer.Compresion(archivo, Singleton.Instancia.Empresa.DireccionBackup);
                MessageBox.Show("Backup realizado exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void informeDeLiquidacionesDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesProveedores());
        }

        private void listadoDeIVAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Singleton.Instancia.Empresa.Codigo == 1)
            {
                Utilidades.Formularios.Abrir(this, new frmIVADeposito());
            }
            else
            {
                Utilidades.Formularios.Abrir(this, new frmIVA());
            }
        }

        private void informesDeAsientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmListados());
        }

        private void informeDeIngresosBrutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmIngresosBrutos());
        }

        private void informeDeRetencionesYPercepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRetencionesPercepciones());
        }

        private void fechasBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmVentaPorEmpleado());
            //Utilidades.Formularios.Abrir(this, new frmVentaPorEmpleado());
            Utilidades.Formularios.Abrir(this, new frmBackupsFechas());
        }

        private void informeDeRendicionesDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInfomeRendicionesCaja());
        }

        private void descuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmDescuentos());
        }

        private void consultaDeStockPorSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmStockPorSucursal());
        }

        private void informeDeLiquidacionesDeProveedoresConLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesProveedoresPorLote());
        }

        private void informeDeStockPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmStockPorFecha());
        }

        private void informeDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmStockInforme());
        }

        private void informeDeStockPorLoreYPuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* try
             {
                 Entidades.Sucursal objESucursal = new Entidades.Sucursal();
                 objESucursal.Codigo = Convert.ToInt32(0);

                 Entidades.Producto objEProducto = new Entidades.Producto();
                 objEProducto.Codigo = Convert.ToInt32(0);

                 Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
                 objEProveedor.Codigo = Convert.ToInt32(0);

                 Entidades.Lote objELote = new Entidades.Lote();
                 objELote.IdLote = Convert.ToInt32(0);


                 lista = new List<DataTable>();
                 lista.Add(new Logica.MovStock_Lote().ObtenerStockPorLotePuesto(objEProducto, objEProveedor,objELote, objESucursal));

                 if (lista[0].Rows.Count == 0)
                 {
                     MessageBox.Show("No se registra Stock", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
                 }
                 frmInformes informe = new frmInformes("INFORME DE STOCK", lista, "repStockPorLoteYPuesto");


                 ReportParameter[] parametros = new ReportParameter[1];
                 parametros[0] = new ReportParameter("Titulo", "Informe de Stock");
                 informe.reportViewer1.LocalReport.SetParameters(parametros);



                 informe.reportViewer1.RefreshReport();

                 Utilidades.Formularios.AbrirFuera(informe);


             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
            Utilidades.Formularios.Abrir(this, new frmStockLoteProveedorInforme());
        }

        private void imputaciónDePagosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmImputacionProveedores());
        }

        private void saldoAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSaldoInicialFecha());
        }

        private void devoluciónDeMercaderíaAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmDevolucionMercaderia());
        }

        private void informeDeLiquidacionesDeCleintesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesClientes());
        }

        private void informeDeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRemitosPendientesFacturaCompra());
        }

        private void informeDeLiquidacionesDeProveedoresPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLiquidacionesProveedoresPendientes());
        }

        private void logoDeLaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLogo()); 
                   
        }

        private void conceptosDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmConcepto());
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Utilidades.Formularios.Abrir(this, new frmGastos());
            Utilidades.Formularios.Abrir(this, new frmDocumentosDeCaja());
        }

        private void conciliacionChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmConciliacionCheques());

        }


        private void informeMovimientosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMovimientosBancariosInforme());
        }


        private void informeDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmGastosInforme());
            
        }

        private void devengamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmDevengamiento());
        }

        private void pagoDeDevengamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPagoDevengamientos());
        }


        private void cuentasContablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.AbrirFuera(new frmCuentasContablesInforme());
        }

        private void conceptosDeSueldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmConceptosSueldos());
        }

        private void liquidaciónDeSueldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmCargaSalarios());
            Utilidades.Formularios.Abrir(this, new frmLiquidacionDeSueldos());
        }

        private void informeDeDevengamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmDevengamientosInforme());
        }

        private void notasDeDébitoChequesRechazadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNDChequesRechazados());
        }

        private void notasDeDébitoChequesRechazadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNDChequesRechazadosProveedores());
        }

        private void listadoDeChequesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmChequesListado());
        }

        private void movimientosSinCierreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataTable> lista = new List<DataTable>();
                lista.Add(new Logica.Movimiento().ObtenerEfectivoSinCierre(Singleton.Instancia.Puesto, "Dolares", "dsMovimientosDolares"));
                lista.Add(new Logica.Movimiento().ObtenerEfectivoSinCierre(Singleton.Instancia.Puesto, "Pesos", "dsMovimientosPesos"));
                //  lista.Add(new Logica.MovimientoSinCierre().ObtenerCheques(Singleton.Instancia.Puesto, "Egreso", "dsChequesEgresos"));

                string titulo = "Movimientos de Caja";

                frmInformes informe = new frmInformes("MOVIMIENTO DE CAJA SIN CIERRE", lista, "repMovimientosSinCierre");

                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("Titulo", titulo);

                informe.reportViewer1.LocalReport.SetParameters(parametros);

                informe.reportViewer1.RefreshReport();

                lista.Clear();
                DataTable dt1, dt2 = new DataTable();
                dt1 = new Logica.Movimiento().ObtenerChequesSinCierre(Singleton.Instancia.Puesto, "Egreso", "dsChequesEgresos");
                dt2 = new Logica.Movimiento().ObtenerChequesSinCierre(Singleton.Instancia.Puesto, "Ingreso", "dsChequesIngresos");

                frmInformes informe2 = new frmInformes(); 
                if (dt1.Rows.Count + dt2.Rows.Count > 0)
                {
                    lista.Add(dt1);
                    lista.Add(dt2);


                    informe2 = new frmInformes("MOVIMIENTO DE CAJA SIN CIERRE", lista, "repChequesSinMovimientos");

                    ReportParameter[] parametros2 = new ReportParameter[3];
                    parametros2[0] = new ReportParameter("Titulo", titulo);
                    parametros2[1] = new ReportParameter("Tipo", "Egreso");
                    parametros2[2] = new ReportParameter("Tipo2", "Ingreso");

                    informe2.reportViewer1.LocalReport.SetParameters(parametros2);

                    informe2.reportViewer1.RefreshReport();

                }

                lista.Clear();
                DataTable dt3 = new DataTable();
                dt3 = new Logica.Movimiento().ObtenerTransferenciasSinCierre(Singleton.Instancia.Puesto);

                frmInformes informe3 = new frmInformes();

                if (dt3.Rows.Count > 0)
                {
                    lista.Add(dt3);



                    informe3 = new frmInformes("MOVIMIENTO DE CAJA SIN CIERRE", lista, "repMovimientosSinCierreTransferencias");

                    ReportParameter[] parametros3 = new ReportParameter[1];
                    parametros3[0] = new ReportParameter("Titulo", titulo);

                    informe3.reportViewer1.LocalReport.SetParameters(parametros3);

                    informe3.reportViewer1.RefreshReport();
                }

                Utilidades.Formularios.AbrirFuera(informe, informe2, informe3);
//
  //              Utilidades.Formularios.AbrirFuera(informe3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listadoDeCajasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmListadosDeCaja());
        }

        private void conciliacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmConciliacionTransacciones());
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + @"\Manual\Manual.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void porDevolucionDeFacturasAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNCVentasIniciales());
        }

        private void cargaDePreciosPorUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPreciosLotes());
        }

        private void comercioIndustriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInformeComercioIndustria());

        }

        private void detalleDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInformeDetalleCompras());
        }

        private void informeIvaVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInformeIVAVentas());
        }

        private void anulaciónDeComprobantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAnulacionDevengamientos());
        }

        private void anulaciónDeComprobantesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAnulacionSucursal());
        }

        private void informeDePreciosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPreciosVentaInforme());
        }

        private void chequesRechazadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmChequesRechazadosBanco());
        }

        private void cambioDeChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCambioDeCheques());
        }

        private void asientosManualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAsientosAperturaCierre());
        }

        private void inversionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInversiones());
        }


        private void informeDeInversionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmInversionesInformes());
        }

        private void notasDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmNCPrueba());
            //Utilidades.Formularios.Abrir(this, new frmNCAjustePrueba());
            //Utilidades.Formularios.Abrir(this, new frmNCLotesPrueba());
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilidades.Formularios.Abrir(this, new frmNDCliente());

        }

        private void movimientosDeChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmMovimientosDeUnCheque());
        }

        private void impresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmImpresoras());
        }

        private void agregarObservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmClientesObservaciones());
        }

        private void agregarObservacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmProveedoresObservaciones());
        }

        private void porAjusteDePrecioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmND());
        }

        private void porAjusteDePrecioEnLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNDLotes());
        }


        private void cITIComprasYVentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCITIComprasyVentas());
        }

        private void libroDeIVADigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmIVADigital());
        }

        private void exportarComprobantesAPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmExportarFacturasPDF());
        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prestamosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPrestamosBancarios());
        }

        private void pagosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmPrestamosBancariosPago());
        }

        private void percepcionesMunicipalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmRetencionesPercepcionesMunicipales());
        }

        private void transportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmTransportes());
        }

        private void notasDeDébitoChequesRechazadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNDChequesRechazados());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
                backgroundWorker.RunWorkerAsync();
        }



        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                tsError.Text = "";

                Novedades.Novedades.Empresa = Singleton.Instancia.Empresa;

                Novedades.Novedades.EnviarNovedades(/*backgroundWorker*/);
                backgroundWorker.ReportProgress(50);
                Novedades.Novedades.RecibirNovedades(/*backgroundWorker*/);
                backgroundWorker.ReportProgress(100);
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(0);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                tsError.Text = "Error con Novedad: " + ex.Message;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void anulaciónDeComprobantesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAnulacionMovimientoDeCaja());
        }

        private void utilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmUtilidades());
        }

        private void ventasPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmVentaPorEmpleado());
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmFacturaManual());
        }

        private void porDevoluciónVaciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNCVacios());
        }

        private void porAjusteDeFacturasAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmNCAjusteFacturasAnteriores());
        }

        private void conciliaciónPagoAProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmConciliacionProveedores());
        }

        private void informeDeSalidaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmSalidas());
        }

        private void adelantosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmAdelantos());
        }

        private void vacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmVacaciones());
        }

        private void tiposDeLicenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmTiposLicencias());
        }

        private void feriadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmFechasFeriados());
        }

        private void faltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmLicencias());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmEmpleadosBancos());
        }

        private void informeDeGastosSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Utilidades.Formularios.Abrir(this, new frmGastosDetalleInforme());
        }

        private void informeDeCuentasCorrientesDeClientesPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilidades.Formularios.Abrir(this, new frmCuentasCorrientesClientes());
        }
    }
}
