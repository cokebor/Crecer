using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EncabezadoRemitoCliente
    {
        private string numRemito;
        private DateTime fecha;
        private int codigoCliente;
        private string nombre;
        private string cUIT;
        private string direccion;
        private string barrio;
        private string codigoPostal;
        private string localidad;
        private string provincia;
        public string NumRemito
        {
            get
            {
                return numRemito;
            }

            set
            {
                numRemito = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int CodigoCliente
        {
            get
            {
                return codigoCliente;
            }

            set
            {
                codigoCliente = value;
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
    }
}
