using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Cheques
    {
        private DateTime fecha;
        private string tipo;
        private string tipoDocumento;
        private string numero;
        private string banco;
        private string nroCheque;
        private string moneda;
        private double cotizacion;
        private DateTime fechaEmision;
        private DateTime fechaPago;
        private string librador;
        private double importe;
        private string nombre;

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

        public string TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
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

        public string Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }

        public string NroCheque
        {
            get
            {
                return nroCheque;
            }

            set
            {
                nroCheque = value;
            }
        }

        public string Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                moneda = value;
            }
        }

        public double Cotizacion
        {
            get
            {
                return cotizacion;
            }

            set
            {
                cotizacion = value;
            }
        }

        public DateTime FechaEmision
        {
            get
            {
                return fechaEmision;
            }

            set
            {
                fechaEmision = value;
            }
        }

        public DateTime FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                fechaPago = value;
            }
        }

        public string Librador
        {
            get
            {
                return librador;
            }

            set
            {
                librador = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
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
    }
}
