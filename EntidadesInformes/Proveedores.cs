using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Proveedores
    {
        private string nombre;
        private string direccion;
        private string barrio;
        private string codigoPostal;
        private string localidad;
        private string provincia;
        private string pais;
        private string tipoInscripcion;
        private string cUIT;
        private string ingresosBrutos;

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

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
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
                barrio = value;
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

        public string Localidad
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

        public string Provincia
        {
            get
            {
                return provincia;
            }

            set
            {
                provincia = value;
            }
        }

        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }

        public string TipoInscripcion
        {
            get
            {
                return tipoInscripcion;
            }

            set
            {
                tipoInscripcion = value;
            }
        }

        public string CUIT
        {
            get
            {
                return cUIT;
            }

            set
            {
                cUIT = value;
            }
        }

        public string IngresosBrutos
        {
            get
            {
                return ingresosBrutos;
            }

            set
            {
                ingresosBrutos = value;
            }
        }
    }
}
