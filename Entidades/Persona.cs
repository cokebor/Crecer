using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;

namespace Entidades
{
    public abstract class Persona : DatosGenerales
    {
        public Persona() {
            domicilio = new Domicilio();
            Comunicaciones = new List<Comunicacion>();
        }

        public Persona(int pCodigo, string pNumeroDocumento, string pApellido, string pNombres) {
            this.Codigo = pCodigo;
            this.NumeroDocumento = pNumeroDocumento;
            this.Apellido = pApellido;
            this.Nombres = pNombres;
        }
        public Persona(int pCodigo, string pApellido, string pNombres, Enumeraciones.Enumeraciones.Sexos pSexo, DateTime pFechaNacimiento, Enumeraciones.Enumeraciones.TiposDeDocumentos pTipoDeDocumento, string pNumeroDocumento, Domicilio pDomicilio, Enumeraciones.Enumeraciones.EstadosCiviles pEstadoCivil):base(pCodigo)
        {
            this.Apellido = pApellido;
            this.Nombres = pNombres;
            this.Sexo = pSexo;
            this.FechaNacimiento = pFechaNacimiento;
            this.TipoDeDocumento = pTipoDeDocumento;
            this.NumeroDocumento = pNumeroDocumento;
            this.Domicilio = pDomicilio;
            this.EstadoCivil = pEstadoCivil;
        }

        private string apellido;
        private string nombres;
        private string nombreCompleto;
        private Enumeraciones.Enumeraciones.Sexos sexo;
        private DateTime fechaNacimiento;
        private Enumeraciones.Enumeraciones.TiposDeDocumentos tipoDeDocumento;
        private string numeroDocumento;
        private Domicilio domicilio=new Domicilio();
        private Enumeraciones.Enumeraciones.EstadosCiviles estadoCivil;
        private List<Comunicacion> comunicaciones;

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public Enumeraciones.Enumeraciones.Sexos Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public string SexoParaGuardar() {
            return Convert.ToChar(Sexo.GetHashCode()).ToString();
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public Enumeraciones.Enumeraciones.TiposDeDocumentos TipoDeDocumento
        {
            get
            {
                return tipoDeDocumento;
            }

            set
            {
                tipoDeDocumento = value;
            }
        }

        public int TipoDeDocumentoGuardar()
        {
            return Convert.ToInt32(TipoDeDocumento.GetHashCode());
        }
        public string NumeroDocumento
        {
            get
            {
                return numeroDocumento;
            }

            set
            {
                numeroDocumento = value;
            }
        }

        public Domicilio Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public Enumeraciones.Enumeraciones.EstadosCiviles EstadoCivil
        {
            get
            {
                return estadoCivil;
            }

            set
            {
                estadoCivil = value;
            }
        }

        public List<Comunicacion> Comunicaciones
        {
            get
            {
                return comunicaciones;
            }

            set
            {
                comunicaciones = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return Apellido + ", " + Nombres;
            }
            
        }

        public int EstadoCivilParaGuardar()
        {
            return Convert.ToInt32(EstadoCivil.GetHashCode());
        }
    }
}
