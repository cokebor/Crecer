using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inversion
    {
        public Inversion() {
            TipoInversion = new TipoInversion();
            CuentaBancaria = new CuentaBancaria();
        }

        private int codigo;
        private string nroReferencia;
        private TipoInversion tipoInversion;
        private DateTime fechaInversion;
        private DateTime fechaVencimiento;
        private double capitalInvertido;
        private string observaciones;
        private Usuario usuario;
        private char estado;
        private int plazoDias;
        private double tNA;
        private double intereses;
        private CuentaBancaria cuentaBancaria;

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

        public TipoInversion TipoInversion
        {
            get
            {
                return tipoInversion;
            }

            set
            {
                tipoInversion = value;
            }
        }

        public DateTime FechaInversion
        {
            get
            {
                return fechaInversion;
            }

            set
            {
                fechaInversion = value;
            }
        }

        public DateTime FechaVencimiento
        {
            get
            {
                return fechaVencimiento;
            }

            set
            {
                fechaVencimiento = value;
            }
        }

        public double CapitalInvertido
        {
            get
            {
                return capitalInvertido;
            }

            set
            {
                capitalInvertido = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public char Estado
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

        public int PlazoDias
        {
            get
            {
                return plazoDias;
            }

            set
            {
                plazoDias = value;
            }
        }

        public double TNA
        {
            get
            {
                return tNA;
            }

            set
            {
                tNA = value;
            }
        }

        public double Intereses
        {
            get
            {
                return intereses;
            }

            set
            {
                intereses = value;
            }
        }

        public CuentaBancaria CuentaBancaria
        {
            get
            {
                return cuentaBancaria;
            }

            set
            {
                cuentaBancaria = value;
            }
        }

        public string NroReferencia
        {
            get
            {
                return nroReferencia;
            }

            set
            {
                nroReferencia = value;
            }
        }
    }
}
