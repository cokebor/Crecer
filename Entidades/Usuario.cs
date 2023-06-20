using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;


namespace Entidades
{
    public class Usuario
    {
        private int codigo;

        private string nombre;
        private string apellido;

        private GrupoDeUsuario grupoDeUsuario;
        private string nombreUsuario;
        private string contraseña;
        private string contraseñaEncriptada;
        private string colorFormularios;
        private string colorFormularioMDI;
        private Enumeraciones.Enumeraciones.Estados estado;
        public string ImpresoraComprobantes { get; set; }
        public string ImpresoraInformes { get; set; }

        private List<Entidades.PuestoCaja> puestosDeCaja;
        public bool Termica { get; set; }

        public Usuario() {
          //  empleado = new Empleado();
            grupoDeUsuario = new GrupoDeUsuario();
            //puestosDeCaja = new List<PuestoCaja>();
        }

       /* public Usuario(GrupoDeUsuario pGrupoDeUsuario, string pNombreUsuario, string pColor)
        {
            this.GrupoDeUsuario = pGrupoDeUsuario;
            this.NombreUsuario = pNombreUsuario;
            this.Contraseña = pNombreUsuario;
            this.ContraseñaEncriptada = pNombreUsuario;
            this.ColorFormularios = pColor;
            this.Estado = Enumeraciones.Enumeraciones.Estados.Activo;
        }*/
        public Usuario(GrupoDeUsuario pGrupoDeUsuario, string pNombreUsuario, string pContraseña, string pColorFormularios)
        {
        
            this.GrupoDeUsuario = pGrupoDeUsuario;
            this.NombreUsuario = pNombreUsuario;
            this.Contraseña = pContraseña;
            this.ColorFormularios = pColorFormularios;
            this.Estado = Enumeraciones.Enumeraciones.Estados.Activo;
        }
        

        public GrupoDeUsuario GrupoDeUsuario
        {
            get
            {
                return grupoDeUsuario;
            }

            set
            {
                grupoDeUsuario = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }

            set
            {
                nombreUsuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                //return Utilidades.Seguridad.DesencriptarClave(contraseña);
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        public string ColorFormularios
        {
            get
            {
                return colorFormularios;
            }

            set
            {
                colorFormularios = value;
            }
        }

        public Enumeraciones.Enumeraciones.Estados Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string ContraseñaEncriptada
        {
            get
            {
                //return Utilidades.Seguridad.DesencriptarClave(contraseñaEncriptada);
                return contraseñaEncriptada;
            }

            set
            {
                contraseñaEncriptada = value;// Utilidades.Seguridad.EncriptarClave(value);
            }
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string ColorFormularioMDI
        {
            get
            {
                return colorFormularioMDI;
            }

            set
            {
                colorFormularioMDI = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public List<PuestoCaja> PuestosDeCaja
        {
            get
            {
                return puestosDeCaja;
            }

            set
            {
                puestosDeCaja = value;
            }
        }
    }
}
