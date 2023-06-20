using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajaInicial
    {
        public CajaInicial() {
            TipoDocumentoCaja = new TipoDocumentoCaja();
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
            FacturaEfectivo = new List<Factura_Efectivo>();
            Cheques = new List<Cheque>();
            CierreCaja = new CierreDeCaja();
        }


        private TipoDocumentoCaja tipoDocumentoCaja;
        private char letra;
        private int puntoDeVenta;
        private int numero;

        private DateTime fecha;
        private string observaciones;
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private List<Factura_Efectivo> facturaEfectivo;
        private List<Cheque> cheques;
        private CierreDeCaja cierreCaja;

        public TipoDocumentoCaja TipoDocumentoCaja
        {
            get
            {
                return tipoDocumentoCaja;
            }

            set
            {
                tipoDocumentoCaja = value;
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

        public CierreDeCaja CierreCaja
        {
            get
            {
                return cierreCaja;
            }

            set
            {
                cierreCaja = value;
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
    }
}
