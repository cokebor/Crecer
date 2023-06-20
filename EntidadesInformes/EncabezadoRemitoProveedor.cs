using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class EncabezadoRemitoProveedor
    {
        private string nombre;
        private string cUIT;
        private string ingresosBrutos;
        private string direccion;
        private string direccion2;
        private string fecha;
        private string numRemito2;
        private string tipoInscripcion;
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

        public string Direccion2
        {
            get
            {
                return direccion2;
            }

            set
            {
                direccion2 = value;
            }
        }

        public string Fecha
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

        public string NumRemito2
        {
            get
            {
                return numRemito2;
            }

            set
            {
                numRemito2 = value;
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
    }
}
