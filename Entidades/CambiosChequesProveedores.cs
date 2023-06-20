using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CambiosChequesProveedores
    {
        public CambiosChequesProveedores() {
            Pago = new Pago();
            Usuario = new Usuario();
            ChequesRechazados = new List<Cheque>();
            FacturaEfectivo = new List<Factura_Efectivo>();
            Tranferencias = new List<Tranferencia>();
            ChequesPropios = new List<Cheque>();
            ChequesTerceros = new List<Cheque>();
        }

        private int codigo;
        private char letra;
        private int puntoDeVenta;
        private int numero;
        private DateTime fecha;
        private Pago pago;
        private Usuario usuario;
        private List<Cheque> chequesRechazados;
        private List<Factura_Efectivo> facturaEfectivo;
        private List<Tranferencia> tranferencias;
        private List<Cheque> chequesPropios;
        private List<Cheque> chequesTerceros;
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

        public Pago Pago
        {
            get
            {
                return pago;
            }

            set
            {
                pago = value;
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

        public List<Cheque> ChequesRechazados
        {
            get
            {
                return chequesRechazados;
            }

            set
            {
                chequesRechazados = value;
            }
        }

        public List<Factura_Efectivo> FacturaEfectivo
        {
            get
            {
                return facturaEfectivo;
            }

            set
            {
                facturaEfectivo = value;
            }
        }

        public List<Tranferencia> Tranferencias
        {
            get
            {
                return tranferencias;
            }

            set
            {
                tranferencias = value;
            }
        }

        public List<Cheque> ChequesPropios
        {
            get
            {
                return chequesPropios;
            }

            set
            {
                chequesPropios = value;
            }
        }

        public List<Cheque> ChequesTerceros
        {
            get
            {
                return chequesTerceros;
            }

            set
            {
                chequesTerceros = value;
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
