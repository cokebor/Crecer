using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class PagoImputacion
    {
        private DateTime fechaEmision;
        private string tipo;
        private string numero;
        private double total;
        private double imputacionAnterior;
        private double monto;

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

        public double ImputacionAnterior
        {
            get
            {
                return imputacionAnterior;
            }

            set
            {
                imputacionAnterior = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }
    }
}
