using System;

namespace Entidades
{
    [Serializable]
    public class Tranferencia
    {
        public Tranferencia(){
            Banco = new Banco();
            CuentaBancaria = new CuentaBancaria();
            Moneda = new Moneda();    
        }

        private Banco banco;
        private CuentaBancaria cuentaBancaria;
        private Moneda moneda;
        private double importe;

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
    }
}
