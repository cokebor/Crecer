using System;

namespace Entidades
{
    [Serializable]
    public class CreditoDebito
    {
        public CreditoDebito(){
            Banco = new Banco();
            CuentaBancaria = new CuentaBancaria();
            Moneda = new Moneda();
            TipoDeTarjetas = new TipoDeTarjetas();
            FormaDePago = new FormaDePago();
           // Cuotas = null;
        }

        private FormaDePago formaDePago;
        private Banco banco;
        private CuentaBancaria cuentaBancaria;
        private Moneda moneda;
        private TipoDeTarjetas tipoDeTarjetas;
        private string nroCupon;
        private double importe;
        private int cuotas;

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

        public int Cuotas
        {
            get
            {
                return cuotas;
            }

            set
            {
                cuotas = value;
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
    }
}
