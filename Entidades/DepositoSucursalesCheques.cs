using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoSucursalesCheques
    {
        public DepositoSucursalesCheques(){
            TipoMovimientoBancario = new TipoMovimientoBancario();
            FormaDePago = new FormaDePago();
            CuentaContable = new CuentaContable();
            Cheque = new Cheque();
        }

        private int renglon;
        private DateTime fecha;
        private TipoMovimientoBancario tipoMovimientoBancario;
        private FormaDePago formaDePago;
        private int codigoCaja;
        private string observaciones;
        public Cheque Cheque { get; set; }
        private CuentaContable cuentaContable;
        //private double importe;

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

        public int CodigoCaja
        {
            get
            {
                return codigoCaja;
            }

            set
            {
                codigoCaja = value;
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
        /*
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
        }*/
    }
}
