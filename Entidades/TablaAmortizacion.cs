using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TablaAmortizacion
    {
        private int cuota;
        private DateTime fecha;
        private double capitalAmortizado;
        private double interes;
        private double iVA;
        private double cuotaAPagar;
        private double capitalPendiente;
        private bool estado;

        public int Cuota
        {
            get
            {
                return cuota;
            }

            set
            {
                cuota = value;
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

        public double CapitalAmortizado
        {
            get
            {
                return capitalAmortizado;
            }

            set
            {
                capitalAmortizado = value;
            }
        }

        public double Interes
        {
            get
            {
                return interes;
            }

            set
            {
                interes = value;
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

        public double CuotaAPagar
        {
            get
            {
                return cuotaAPagar;
            }

            set
            {
                cuotaAPagar = value;
            }
        }

        public double CapitalPendiente
        {
            get
            {
                return capitalPendiente;
            }

            set
            {
                capitalPendiente = value;
            }
        }

        public bool Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
