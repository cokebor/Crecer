using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class EncabezadoLiquidacionCliente
    {
        private DateTime fecha;
        private char letra;
        private string numero;
        private string cliente;
        private DateTime fechaRemito;
        private string remito;
        private string direccion;
        private string tipoInscripcion;
        private string cUIT;
        private string codigo;

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

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public DateTime FechaRemito
        {
            get
            {
                return fechaRemito;
            }

            set
            {
                fechaRemito = value;
            }
        }

        public string Remito
        {
            get
            {
                return remito;
            }

            set
            {
                remito = value;
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

        public string Codigo
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
    }
}
