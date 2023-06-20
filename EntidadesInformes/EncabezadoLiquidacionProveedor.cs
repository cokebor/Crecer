using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class EncabezadoLiquidacionProveedor
    {
        private DateTime fecha;
        private string proveedor;
        private DateTime fechaRemito;
        private DateTime fechaEmbarque;
        private string remito;
        private string direccion;
        private string tipoInscripcion;
        private string cUIT;
        private double redondeo;
        private double neto;
        private double comision;
        private double iVA;
        private string numero;
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

        public string Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
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

        public double Redondeo
        {
            get
            {
                return redondeo;
            }

            set
            {
                redondeo = value;
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

        public double Comision
        {
            get
            {
                return comision;
            }

            set
            {
                comision = value;
            }
        }

        public double IVA
        {
            get
            {
                return iVA;
            }

            set
            {
                iVA = value;
            }
        }

        public DateTime FechaEmbarque
        {
            get
            {
                return fechaEmbarque;
            }

            set
            {
                fechaEmbarque = value;
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
