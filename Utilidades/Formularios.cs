using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Formularios
    {
        public static void Abrir(Form mdi, Form pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.MdiParent = mdi;
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.Show();
            }
        }

        public static void Abrir(Form mdi, Form pFormularioAAbrir, Form pFormularioAAbrir2)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.MdiParent = mdi;
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Normal;
                pFormularioAAbrir.Show();
            }

            Form instForm2 = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir2.Name).SingleOrDefault();
            if (instForm2 != null)
            {
                pFormularioAAbrir2.MdiParent = mdi;
                pFormularioAAbrir2.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Normal;
                pFormularioAAbrir2.Show();
            }
        }

        public static void AbrirShowDialog(Form mdi, Form pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                //pFormularioAAbrir.MdiParent = mdi;
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.ShowDialog();
            }
        }

        public static void AbrirFuera(Form pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

           /* if (instForm == null && pFormularioAAbrir.Name != "frmColor")
            {
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
            }
            else {
           */
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
            //}
        }

        public static void AbrirFuera22(Form pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
            }
        }

        public static void AbrirFuera(Form pFormularioAAbrir, Form pFormularioAAbrir2)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null && pFormularioAAbrir.Name != "frmColor")
            {
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
            }

            Form instForm2 = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir2.Name).SingleOrDefault();

            if (instForm2 == null && pFormularioAAbrir2.Name != "frmColor")
            {
                pFormularioAAbrir2.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir2.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir2.Show();
            }
        }

        public static void AbrirFuera(Form pFormularioAAbrir, Form pFormularioAAbrir2, Form pFormularioAAbrir3)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
            }


            Form instForm2 = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir2.Name).SingleOrDefault();

            if (instForm2 != null)
            {
                pFormularioAAbrir2.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir2.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir2.Show();
            }

            Form instForm3 = new Form();//Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir3.Name).SingleOrDefault();

            if (instForm3 != null && pFormularioAAbrir3.Text!="frmColor")
            {
                pFormularioAAbrir3.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir3.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir3.Show();
            }

        }
        public static void AbrirFuera2(Form pFormularioAAbrir2)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre2 => pre2.Name == pFormularioAAbrir2.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir2.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir2.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir2.Show();
            }
        }
        public static void AbrirFueraHide(Form pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.WindowState = FormWindowState.Maximized;
                pFormularioAAbrir.Show();
                pFormularioAAbrir.Hide();
                //pFormularioAAbrir.Show();
            }
        }

        /*
        public static void Abrir(Form mdi, ColorDialog pFormularioAAbrir)
        {//, string pNombreFormulario) { 

            Form instForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == pFormularioAAbrir.Name).SingleOrDefault();

            if (instForm == null)
            {
                pFormularioAAbrir.MdiParent = mdi;
                pFormularioAAbrir.StartPosition = FormStartPosition.CenterScreen;
                pFormularioAAbrir.Show();
            }
        }*/

        public static void ConfiguracionInicial(Form form)
        {
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ShowInTaskbar = false;

            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
