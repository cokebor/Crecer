using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoBancarioPago
    {
        private DateTime fechaPago;
        private DateTime fechaContable;
        private CuentaBancaria cuentaBancaria;
        private PrestamoBancario prestamo;
        private TablaAmortizacion tablaAmortizacion;
        private Asiento asiento;
        private Usuario usuario;
        private PuestoCaja puestoCaja;

        public PrestamoBancarioPago(){
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
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

        public PrestamoBancario Prestamo
        {
            get
            {
                return prestamo;
            }

            set
            {
                prestamo = value;
            }
        }

        public TablaAmortizacion TablaAmortizacion
        {
            get
            {
                return tablaAmortizacion;
            }

            set
            {
                tablaAmortizacion = value;
            }
        }

        public Asiento Asiento
        {
            get
            {
                return asiento;
            }

            set
            {
                asiento = value;
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

        public PuestoCaja PuestoCaja
        {
            get
            {
                return puestoCaja;
            }

            set
            {
                puestoCaja = value;
            }
        }
    }
}
