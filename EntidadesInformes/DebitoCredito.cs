using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class DebitoCredito
    {
        private int codigoFormaDePago;
        private string banco;
        private string tipoDeTarjetas;
        private string nroCupon;
        private string cuotas;
        private double importe;

        public string TipoDeTarjetas
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

        public string Cuotas
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

        public int CodigoFormaDePago
        {
            get
            {
                return codigoFormaDePago;
            }

            set
            {
                codigoFormaDePago = value;
            }
        }

        public string Banco { get => banco; set => banco = value; }
    }
}
