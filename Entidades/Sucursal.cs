using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Sucursal
    {
        private int codigo;
        private string razonSocial;
        private string cUIT;
        //private int puntoDeVentaElectronico;
        private string domicilio;
        private string puesto;
        private string domicilio2;
        private string ingresosBrutos;
        private string fechaInicioActividad;

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

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
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

        public string Domicilio
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

        public string Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }

        public string Domicilio2
        {
            get
            {
                return domicilio2;
            }

            set
            {
                domicilio2 = value;
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

        public string FechaInicioActividad
        {
            get
            {
                return fechaInicioActividad;
            }

            set
            {
                fechaInicioActividad = value;
            }
        }
    }
}
