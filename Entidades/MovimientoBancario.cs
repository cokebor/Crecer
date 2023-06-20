using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovimientoBancario
    {
        public MovimientoBancario() {
            CuentaBancaria = new CuentaBancaria();
            TipoMovimientoBancario = new TipoMovimientoBancario();
        }

        private int codigo;
        private CuentaBancaria cuentaBancaria;
        private TipoMovimientoBancario tipoMovimientoBancario;
        private DateTime fechaMovimiento;
        private string observaciones;
        private double importe;

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

        public TipoMovimientoBancario TipoMovimientoBancario
        {
            get
            {
                return tipoMovimientoBancario;
            }

            set
            {
                tipoMovimientoBancario = value;
            }
        }

        public DateTime FechaMovimiento
        {
            get
            {
                return fechaMovimiento;
            }

            set
            {
                fechaMovimiento = value;
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
    }
}
