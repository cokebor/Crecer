using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Transacciones
    {
        public Transacciones(){
            TipoMovimientoBancario = new TipoMovimientoBancario();
            FormaDePago = new FormaDePago();
            CuentaContable = new CuentaContable();
            TipoDeTarjetas = new TipoDeTarjetas();
        }

        private int renglon;
        private DateTime fecha;
        private TipoMovimientoBancario tipoMovimientoBancario;
        private FormaDePago formaDePago;
        private int codigoPago;
        private int renglonPago;
        private string observaciones;
        private CuentaContable cuentaContable;
        private TipoDeTarjetas tipoDeTarjetas;
        private string nroCupon;
        private double importe;

        public int Renglon
        {
            get
            {
                return renglon;
            }

            set
            {
                renglon = value;
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

        public FormaDePago FormaDePago
        {
            get
            {
                return formaDePago;
            }

            set
            {
                formaDePago = value;
            }
        }

        public int CodigoPago
        {
            get
            {
                return codigoPago;
            }

            set
            {
                codigoPago = value;
            }
        }

        public int RenglonPago
        {
            get
            {
                return renglonPago;
            }

            set
            {
                renglonPago = value;
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

        public CuentaContable CuentaContable
        {
            get
            {
                return cuentaContable;
            }

            set
            {
                cuentaContable = value;
            }
        }

        public TipoDeTarjetas TipoDeTarjetas
        {
            get
            {
                return tipoDeTarjetas;
            }

            set
            {
                tipoDeTarjetas = value;
            }
        }

        public string NroCupon
        {
            get
            {
                return nroCupon;
            }

            set
            {
                nroCupon = value;
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
    }
}
