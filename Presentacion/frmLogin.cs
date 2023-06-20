using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLogin : frmColor
    {
        Logica.Usuario objLogicaUsuario = new Logica.Usuario();
        Logica.PuestoCaja objLogicaPuesto = new Logica.PuestoCaja();
        Logica.Empresa objLogicaEmpresa = new Logica.Empresa();

        Entidades.Usuario objEntidadesUsuario = new Entidades.Usuario();
        Entidades.PuestoCaja objEntidadPuestoCaja = new Entidades.PuestoCaja();
        public frmLogin()
        {
            InitializeComponent();
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbCaja);
            try
            {
                CargarValores();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //new Logica.Asiento.GuardarImagen(@"D:\Datos\Descargas\PPP\logoGrande222.png");            
        }

        private void CargarValores()
        {
            Utilidades.Combo.Llenar(cbCaja, objLogicaPuesto.ObtenerTodos(), "Codigo", "Descripcion");
            Singleton.Instancia.Empresa = objLogicaEmpresa.Obtener();
            this.Text = "Login " + Singleton.Instancia.Empresa.NombreSucursal;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            objEntidadesUsuario.NombreUsuario = txtUsuario.Text.Trim();
            objEntidadesUsuario.Contraseña = txtPassword.Text.Trim();
            objEntidadesUsuario.ContraseñaEncriptada = Utilidades.Seguridad.EncriptarClave(objEntidadesUsuario.Contraseña);
            try
            {
                objEntidadesUsuario = objLogicaUsuario.ObtenerUno(objEntidadesUsuario,Convert.ToInt32(cbCaja.SelectedValue));
                if (objEntidadesUsuario.Apellido != null)
                {
                    // MessageBox.Show(objEntidadesUsuario.Empleado.Apellido);
                    //foreach(frmPrincipal.ControlCollection)
                    this.Hide();
                    //Color c = ColorTranslator.FromHtml(objEntidadesUsuario.ColorFormularios.ToString());
                    //Color c= Color.FromArgb()
                   // frmColor.Color = c;
                    Color c=Color.FromArgb(Convert.ToInt32(objEntidadesUsuario.ColorFormularios));
                    frmColor.Color = c;

                    frmPrincipal principal = new frmPrincipal();
                    principal.ssPrincipal.BackColor = c;
                    Singleton.Instancia.Usuario = objEntidadesUsuario;
                    objEntidadPuestoCaja = objLogicaPuesto.ObtenerUno(Convert.ToInt32(cbCaja.SelectedValue));
                    Singleton.Instancia.Puesto = objEntidadPuestoCaja;

                   // Singleton.Instancia.Empresa = objLogicaEmpresa.Obtener();

                    principal.Text = Singleton.Instancia.Empresa.NombreSucursal;

                    string direccion = System.Windows.Forms.Application.StartupPath + @"\Backups";
                    Directory.CreateDirectory(direccion);
                    FileIOPermission permiso = new FileIOPermission(FileIOPermissionAccess.AllAccess, direccion);
                    
                    

                  /*  if (Singleton.Instancia.Empresa.Codigo==7)
                        Utilidades.Procesos.Detener("Novedades2");
                    else
                         Utilidades.Procesos.Detener("Novedades");
                         */
                    principal.Show();
                    
                }
                else {
                    MessageBox.Show("Usuario o contraseña incorrectos",Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtPassword.Text="";
            if (cbCaja.Items.Count>0)
                cbCaja.SelectedIndex = 0;
            txtUsuario.Focus();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }

        private void cbCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.ControlesGenerales.CambiarFoco(e);
        }
    }
}
