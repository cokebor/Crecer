using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Domicilio
    {
        private string direccion;
        private string numero;
        private string barrio;
        private string codigoPostal;
        private Localidad localidad;

        public Domicilio() {
            localidad = new Localidad();
        }
        public Domicilio(string pDireccion,string pNumero ,string pBarrio, string pCodigoPostal, Localidad pLocalidad)
        {
            this.Direccion = pDireccion;
            this.Numero = pNumero;
            this.Barrio = pBarrio;
            this.CodigoPostal = pCodigoPostal;
            this.Localidad = pLocalidad;
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public string Barrio
        {
            get
            {
                return barrio;
            }

            set
            {
                barrio = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public string CodigoPostal
        {
            get
            {
                return codigoPostal;
            }

            set
            {
                codigoPostal = value;
            }
        }

        public Localidad Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }
    }
}
