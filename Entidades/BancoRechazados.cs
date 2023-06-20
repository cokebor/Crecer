using System;
using System.Collections.Generic;

namespace Entidades
{
    public class BancoRechazados
    {
        public BancoRechazados()
        {
            Usuario = new Usuario();
            Cheques = new List<Cheque>();
            CuentaBancaria = new CuentaBancaria();

        }
        private char letra;
        private int puntoDeVenta;
        private int numero;
        private DateTime fecha;
        private string observaciones;
        private Usuario usuario;
        private CuentaBancaria cuentaBancaria;
        private List<Cheque> cheques;

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

        public List<Cheque> Cheques
        {
            get
            {
                return cheques;
            }

            set
            {
                cheques = value;
            }
        }

        public char Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
            }
        }

        public int PuntoDeVenta
        {
            get
            {
                return puntoDeVenta;
            }

            set
            {
                puntoDeVenta = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Numdoc
        {
            get
            {
                return Letra + "-" + PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }
    }
}