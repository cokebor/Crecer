using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago: DatosGenerales
    {
        public Pago() {
            TipoDocumentoProveedor = new TipoDocumentoProveedor();
            Proveedor = new Proveedor();
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
            CierreCaja = new CierreDeCaja();
            //Asiento = new Asiento();
            facturaEfectivo = new List<Factura_Efectivo>();
            cheques = new List<Cheque>();
            ChequesPropios = new List<Cheque>();
            FacturasImputacion = new List<FacturaCompraImputacion>();
            Tranferencias = new List<Tranferencia>();
            Impuestos = new List<PagosProveedoresImpuestos>();
            CreditosDebitos = new List<CreditoDebito>();
            // Remito = new RemitoProveedor_M();*/
            CuentaContable = new CuentaContable();
        }

        private Proveedor proveedor;
        private TipoDocumentoProveedor tipoDocumentoProveedor;
        private char letra;
        private int puntoDeVenta;
        private int numero;

        private DateTime fecha;
        private string observaciones;
        private double total;
        
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private CierreDeCaja cierreCaja;
        //private Asiento asiento;
        private List<Factura_Efectivo> facturaEfectivo;
        private List<Cheque> cheques;
        private List<Cheque> chequesPropios;
        //private RemitoProveedor_M remito;
        private List<FacturaCompraImputacion> facturasImputacion;
        private List<Tranferencia> tranferencias;
        private bool chequeRechazado;
        private List<PagosProveedoresImpuestos> impuestos;

        private List<CreditoDebito> creditosDebitos;

        public CuentaContable CuentaContable { get; set; }

        public TipoDocumentoProveedor TipoDocumentoProveedor
        {
            get
            {
                return tipoDocumentoProveedor;
            }

            set
            {
                tipoDocumentoProveedor = value;
            }
        }

        
        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
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
        /*
        public Asiento Asiento
        {
            get
            {
                return asiento;
            }

            set
            {
                asiento = value;
            }
        }
        */
        
        
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

        public List<FacturaCompraImputacion> FacturasImputacion
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
        public List<PagosProveedoresImpuestos> Impuestos
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
        /*

public RemitoProveedor_M Remito
{
get
{
return remito;
}

set
{
remito = value;
}
}
*/
    }
}
