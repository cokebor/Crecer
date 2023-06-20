using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class MovimientosSinCierre
    {
        private string moneda;
        private DateTime fecha;
        private string tipo;
        private string nombre;
        private string tipoDocumento;
        private string numero;
        private double cotizacion;
        private double ingreso;
        private double egreso;

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

        public double Ingreso
        {
            get
            {
                return ingreso;
            }

            set
            {
                ingreso = value;
            }
        }

        public double Egreso
        {
            get
            {
                return egreso;
            }

            set
            {
                egreso = value;
            }
        }
    }
}
