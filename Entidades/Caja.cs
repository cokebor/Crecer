using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caja:DatosGenerales
    {
        public Caja() {
            TipoDocumentoCaja = new TipoDocumentoCaja();
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
            FacturaEfectivo = new List<Factura_Efectivo>();
            Cheques = new List<Cheque>();
            ChequesPropios = new List<Cheque>();
            Tranferencias = new List<Tranferencia>();
            CierreCaja = new CierreDeCaja();
            CuentaBancaria = new CuentaBancaria();
            Retenciones = new List<Entidades.Retenciones>();
            LibreDisponibilidad = new List<LibreDisponibilidadAsociado>();
            CreditosDebitos = new List<CreditoDebito>();
            Detalle = new List<Caja_Detalle>();
            Impuestos = new List<FacturaImpuesto>();
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
        private List<Cheque> chequesPropios;
        private List<Tranferencia> tranferencias;
        private List<CreditoDebito> creditosDebitos;
        private CierreDeCaja cierreCaja;
        private int sucursalDestino;
        private CuentaBancaria cuentaBancaria;
        private List<Retenciones> retenciones;
        private List<LibreDisponibilidadAsociado> libreDisponibilidad;
        private List<Caja_Detalle> detalle;
        private List<FacturaImpuesto> impuestos;
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

        public string Numdoc
        {
            get
            {
                return Letra + "-" + PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }

        public int SucursalDestino
        {
            get
            {
                return sucursalDestino;
            }

            set
            {
                sucursalDestino = value;
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

        public List<Retenciones> Retenciones
        {
            get
            {
                return retenciones;
            }

            set
            {
                retenciones = value;
            }
        }

        public List<LibreDisponibilidadAsociado> LibreDisponibilidad
        {
            get
            {
                return libreDisponibilidad;
            }

            set
            {
                libreDisponibilidad = value;
            }
        }

        public List<FacturaImpuesto> Impuestos
        {
            get
            {
                return impuestos;
            }

            set
            {
                impuestos = value;
            }
        }
        public List<CreditoDebito> CreditosDebitos { get => creditosDebitos; set => creditosDebitos = value; }
        public List<Caja_Detalle> Detalle { get => detalle; set => detalle = value; }
    }
}
