using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class IvaVentas
    {
        private DateTime fecha;
        private string numero;
        private string tipo;
        private char letra;
        private string nombre;
        private string cUIT;
        private string sigla;
        private double neto;
        private double netoNoGravado;
        private double iva105;
        private double iva21;
        private double ingresosBrutos;
        private double percepcionMunicipal;
        private double total;

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

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public char Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
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

        public double Neto
        {
            get
            {
                return neto;
            }

            set
            {
                neto = value;
            }
        }

        public double IngresosBrutos
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

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Sigla
        {
            get
            {
                return sigla;
            }

            set
            {
                sigla = value;
            }
        }

        public double Iva105
        {
            get
            {
                return iva105;
            }

            set
            {
                iva105 = value;
            }
        }

        public double Iva21
        {
            get
            {
                return iva21;
            }

            set
            {
                iva21 = value;
            }
        }

        public double NetoNoGravado
        {
            get
            {
                return netoNoGravado;
            }

            set
            {
                netoNoGravado = value;
            }
        }

        public double PercepcionMunicipal
        {
            get
            {
                return percepcionMunicipal;
            }

            set
            {
                percepcionMunicipal = value;
            }
        }
    }
}
