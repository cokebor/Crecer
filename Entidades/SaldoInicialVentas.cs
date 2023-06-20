using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SaldoInicialVentas:  DatosGenerales
    {
        public SaldoInicialVentas() {
            tipoDocumentoCliente = new TipoDocumentoCliente();
            vendedor = new Empleado();
            usuario = new Usuario();
            puestoCaja = new PuestoCaja();
            detalle = new List<Factura_Detalle>();
        }

        private TipoDocumentoCliente tipoDocumentoCliente;
        private char letra;
        private int puntoDeVenta;
        private int numero;
                
        private DateTime fecha;
        private Empleado vendedor;
        
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private List<Factura_Detalle> detalle;
        

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

        public Empleado Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
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

        public string Numdoc {
            get {
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

        public List<Factura_Detalle> Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }
    }
}
