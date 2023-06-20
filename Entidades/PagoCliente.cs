using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagoCliente: DatosGenerales
    {
        public PagoCliente() {
            TipoDocumentoCliente = new TipoDocumentoCliente();
            Cliente = new Cliente();
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
            CierreCaja = new CierreDeCaja();
            facturaEfectivo = new List<Factura_Efectivo>();
            cheques = new List<Cheque>();
            ChequesPropios = new List<Cheque>();
            FacturasImputacion = new List<FacturaImputacion>();
            impuestos = new List<FacturaImpuesto>();
            Tranferencias = new List<Tranferencia>();
            CreditosDebitos = new List<CreditoDebito>();
        }

        private Cliente cliente;
        private TipoDocumentoCliente tipoDocumentoCliente;
        private char letra;
        private int puntoDeVenta;
        private int numero;

        private DateTime fecha;
        private string observaciones;
        private double total;
        
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private CierreDeCaja cierreCaja;

        private List<Factura_Efectivo> facturaEfectivo;
        private List<Cheque> cheques;
        private List<Cheque> chequesPropios;
        private List<FacturaImpuesto> impuestos;
        private List<Tranferencia> tranferencias;
        private List<CreditoDebito> creditosDebitos;

        private List<FacturaImputacion> facturasImputacion;
        private char imputacion;
        private bool chequeRechazado;

        public TipoDocumentoCliente TipoDocumentoCliente
        {
            get
            {
                return tipoDocumentoCliente;
            }

            set
            {
                tipoDocumentoCliente = value;
            }
        }

        
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
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

        internal CierreDeCaja CierreCaja
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

        public string NumdocSinLetra
        {
            get
            {
                return PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }

        public List<FacturaImputacion> FacturasImputacion
        {
            get
            {
                return facturasImputacion;
            }

            set
            {
                facturasImputacion = value;
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

        public char Imputacion
        {
            get
            {
                return imputacion;
            }

            set
            {
                imputacion = value;
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

        public List<CreditoDebito> CreditosDebitos
        {
            get
            {
                return creditosDebitos;
            }

            set
            {
                creditosDebitos = value;
            }
        }

        public bool ChequeRechazado
        {
            get
            {
                return chequeRechazado;
            }

            set
            {
                chequeRechazado = value;
            }
        }
    }
}
