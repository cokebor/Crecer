using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cheque
    {
        public Cheque()
        {
            Banco = new Banco();
            Moneda = new Moneda();
            EstadoValor = new EstadosValores();
            CuentaBancaria = new CuentaBancaria();
        }

        private int codigo;
        private Banco banco;
        private string numeroCheque;
        private CuentaBancaria cuentaBancaria;
        private DateTime fechaEmision;
        private DateTime fechaPago;
        private string librador;
        private string cuit;
        private Moneda moneda;
        private double importe;
        private EstadosValores estadoValor;
        private DateTime fechaCambioEstado;
        public int CodigoCierreCaja { get; set; }

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

        public Banco Banco
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

        public string NumeroCheque
        {
            get
            {
                return numeroCheque;
            }

            set
            {
                numeroCheque = value;
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

        public string Cuit
        {
            get
            {
                return cuit;
            }

            set
            {
                cuit = value;
            }
        }

        public Moneda Moneda
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

        public EstadosValores EstadoValor
        {
            get
            {
                return estadoValor;
            }

            set
            {
                estadoValor = value;
            }
        }

        public DateTime FechaCambioEstado
        {
            get
            {
                return fechaCambioEstado;
            }

            set
            {
                fechaCambioEstado = value;
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
    }
}
