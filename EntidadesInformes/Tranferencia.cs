using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesInformes
{
    public class Tranferencia
    {
        private Banco banco;
        private string numeroCuenta;
        private double importe;
        private double total;
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

        public string NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }

            set
            {
                numeroCuenta = value;
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

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
