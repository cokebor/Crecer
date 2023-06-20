using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmCambioClave : frmColor
    {
        Entidades.Usuario objEntidadUsuario = new Entidades.Usuario();
        Logica.Usuario objLogicaUsuario = new Logica.Usuario();


        public frmCambioClave()
        {
            InitializeComponent();
            CargarColores();
        }

        private void CargarColores() {
            try
            {
                objEntidadUsuario=Singleton.Instancia.Usuario;
                
                txtPassword.Text = /*Utilidades.Seguridad.DesencriptarClave(*/objEntidadUsuario.Contraseña/*)*/;
                //txtPassword.Text= Utilidades.Seguridad.DesencriptarClave(objEntidadUsuario.ContraseñaEncriptada);
                txtPassword.Focus();
                btnColor.BackColor = Color.FromArgb(Convert.ToInt32(objEntidadUsuario.ColorFormularios));
                btnColorMDI.BackColor = Color.FromArgb(Convert.ToInt32(objEntidadUsuario.ColorFormularioMDI));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       /* private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.Color    = ColorTranslator.FromHtml("ActiveCaption");
            CD.ShowDialog();
       
        }
        */
        private void btnColor_Click(object sender, EventArgs e)
        {
            
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.AnyColor = true;
            cd.SolidColorOnly = false;
            cd.ShowHelp = true;


            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = cd.Color;
            }

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
  
                objEntidadUsuario = Singleton.Instancia.Usuario;
                //objEntidadUsuario.NombreUsuario = Usuario;

                objEntidadUsuario.ContraseñaEncriptada = Utilidades.Seguridad.EncriptarClave(txtPassword.Text.Trim());
                objEntidadUsuario.Contraseña = txtPassword.Text.Trim();
                //Color c = Color.FromArgb(Convert.ToInt32(objEntidadesUsuario.ColorFormularios));
                objEntidadUsuario.ColorFormularios = btnColor.BackColor.ToArgb().ToString();
                objEntidadUsuario.ColorFormularioMDI = btnColorMDI.BackColor.ToArgb().ToString();

             //   MessageBox.Show(Color.DarkSlateGray.ToArgb().ToString());

                if (objLogicaUsuario.CambiarClave(objEntidadUsuario, txtConfirmar.Text.Trim())) {
                    Color c = Color.FromArgb(Convert.ToInt32(objEntidadUsuario.ColorFormularios));
                    frmColor.Color = c;
                    MessageBox.Show("Clave cambiada exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() {
            txtPassword.Text = "";
            txtConfirmar.Text = "";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.AnyColor = true;
            cd.SolidColorOnly = false;
            cd.ShowHelp = true;


            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnColorMDI.BackColor = cd.Color;
            }
        }
    }
}
