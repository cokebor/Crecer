using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class ClienteFacturaCompra
    {
        private DateTime fecha;
        private char letra;
        private int puntoDeVenta;
        private int numero;
        private int codigoCliente;
        private string cliente;
        private string domicilio;
        private string domicilio2;
        private string tipoInscripcion;
        private string cUIT;
        private bool facturaKilos;
        private string nroRemito;
        private double netoNoGravado;
        private double neto105;
        private double neto21;
        private double iva105;
        private double iva21;
        private string cAE;
        private DateTime fechaVenCae;
        private string codigoBarra;
        private string numeroFactura;
        private DateTime fechaVencimientoPago;
        private bool miPYME;
        private double percepcionMuni;
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

        public int CodigoCliente
        {
            get
            {
                return codigoCliente;
            }

            set
            {
                codigoCliente = value;
            }
        }

        public string Cliente
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

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public string Domicilio2
        {
            get
            {
                return domicilio2;
            }

            set
            {
                domicilio2 = value;
            }
        }

        public string TipoInscripcion
        {
            get
            {
                return tipoInscripcion;
            }

            set
            {
                tipoInscripcion = value;
            }
        }

        public string CUIT
        {
            get
            {
                return cUIT;
            }

            set
            {
                cUIT = value;
            }
        }

        public bool FacturaKilos
        {
            get
            {
                return facturaKilos;
            }

            set
            {
                facturaKilos = value;
            }
        }

        public string NroRemito
        {
            get
            {
                return nroRemito;
            }

            set
            {
                nroRemito = value;
            }
        }

        public double Neto105
        {
            get
            {
                return neto105;
            }

            set
            {
                neto105 = value;
            }
        }

        public double Neto21
        {
            get
            {
                return neto21;
            }

            set
            {
                neto21 = value;
            }
        }

        public double Iva105
        {
            get
            {
                return iva105;
            }

            set
            {
                iva105 = value;
            }
        }

        public double Iva21
        {
            get
            {
                return iva21;
            }

            set
            {
                iva21 = value;
            }
        }

        public string CAE
        {
            get
            {
                return cAE;
            }

            set
            {
                cAE = value;
            }
        }

        public DateTime FechaVenCae
        {
            get
            {
                return fechaVenCae;
            }

            set
            {
                fechaVenCae = value;
            }
        }

        public string CodigoBarra
        {
            get
            {
                return codigoBarra;
            }

            set
            {
                codigoBarra = value;
            }
        }

        public string NumeroFactura
        {
            get
            {
                return numeroFactura;
            }

            set
            {
                numeroFactura = value;
            }
        }

        public double NetoNoGravado
        {
            get
            {
                return netoNoGravado;
            }

            set
            {
                netoNoGravado = value;
            }
        }

        public DateTime FechaVencimientoPago
        {
            get
            {
                return fechaVencimientoPago;
            }

            set
            {
                fechaVencimientoPago = value;
            }
        }

        public bool MiPYME
        {
            get
            {
                return miPYME;
            }

            set
            {
                miPYME = value;
            }
        }

        public double PercepcionMuni
        {
            get
            {
                return percepcionMuni;
            }

            set
            {
                percepcionMuni = value;
            }
        }
    }
}
