using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Novedades2
{
    public partial class frmNovedades : Form
    {
        Entidades.Empresa empresa;
    


        Logica.Empresa LEmpresa = new Logica.Empresa();
        public frmNovedades(Form f)
        {
            InitializeComponent();
            FormularioAnterior = f;
            Empresa = new Entidades.Empresa();
            Utilidades.Formularios.ConfiguracionInicial(this);
            this.Hide();
        }

        public frmNovedades()
        {
            InitializeComponent();
            //FormularioAnterior = f;
            Empresa = new Entidades.Empresa();
              this.Hide();
              this.Visible = false;
            Utilidades.Formularios.ConfiguracionInicial(this);
        }


        private void frmNovedades_Load(object sender, EventArgs e)
        {
            try
            {
                Empresa = LEmpresa.Obtener();
                this.Visible = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form formularioAnterior;
        public Form FormularioAnterior
        {
            get
            {
                return formularioAnterior;
            }

            set
            {
                formularioAnterior = value;
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }
        //int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                if (ValidarConexionWeb())
                {
                    

                    //if (Empresa.Codigo == 1)// || Empresa.Codigo == 3 || Empresa.Codigo == 4 || Empresa.Codigo == 5 || Empresa.Codigo == 7)
                    {
                        Novedades2.Novedad.Empresa = Empresa;
                        Novedades2.Novedad.EnviarNovedades();
                        //Novedades2.Novedad.RecibirNovedades();
                        string datos = Novedades2.Novedad.RecibirNovedades();
                        if (!datos.Equals(""))
                            lblDato.Text += datos;
                    }
                    /*else {
                        timer1.Enabled = false;
                    }*/
                }
                else
                {
                   // timer1.Enabled = false;
                  //  MessageBox.Show("No se puede establecer conexion con el servidor", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (SqlException sqlex)
            {
                timer1.Enabled = false;

                MessageBox.Show(sqlex.Number.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                timer1.Enabled = false;

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValidarConexionWeb()
        {
            bool res = false;
            LogicaWeb.Prueba P = new LogicaWeb.Prueba();
            try
            {
                res = P.Resultado();
            }
            catch (SqlException sqlex)
            {
                throw new Exception(sqlex.Number.ToString());
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el servidor");
            }
            return res;
        }
    }
}
