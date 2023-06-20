using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class IvaCompras
    {
        private int nro;
        private DateTime fechaEmision;
        private DateTime fechaContable;
        private string numero;
        private string tipo;
        private string nombre;
        private string cUIT;
        private double neto;
        private double iva;
        private double iva105;
        private double iva21;
        private double iva27;
        private double noGravado;
        private double exento;
        private double comision;
        private double retencionIVA;
        private double retencionIB;
        private double otros;
        private double total;

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

        public DateTime FechaContable
        {
            get
            {
                return fechaContable;
            }

            set
            {
                fechaContable = value;
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

        public double Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public double NoGravado
        {
            get
            {
                return noGravado;
            }

            set
            {
                noGravado = value;
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

        public double RetencionIVA
        {
            get
            {
                return retencionIVA;
            }

            set
            {
                retencionIVA = value;
            }
        }

        public double RetencionIB
        {
            get
            {
                return retencionIB;
            }

            set
            {
                retencionIB = value;
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

        public int Nro
        {
            get
            {
                return nro;
            }

            set
            {
                nro = value;
            }
        }

        public double Exento
        {
            get
            {
                return exento;
            }

            set
            {
                exento = value;
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

        public double Iva27
        {
            get
            {
                return iva27;
            }

            set
            {
                iva27 = value;
            }
        }

        public double Otros
        {
            get
            {
                return otros;
            }

            set
            {
                otros = value;
            }
        }
    }
}
