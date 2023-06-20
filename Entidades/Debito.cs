using System;

namespace Entidades
{
    [Serializable]
    public class Debito
    {
        public Debito(){
            Banco = new Banco();
            CuentaBancaria = new CuentaBancaria();
            Moneda = new Moneda();
            TipoDeTarjetas = new TipoDeTarjetas();   
        }

        private Banco banco;
        private CuentaBancaria cuentaBancaria;
        private Moneda moneda;
        private TipoDeTarjetas tipoDeTarjetas;
        private string nroCupon;
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
    }
}
